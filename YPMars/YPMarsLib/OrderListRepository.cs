using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderListRepository : IOrderListRepository
    {
        public OrderListRepository()
        {
        }

        public List<Order> GetOrdersByPeriod(OrderDateFilter filterDate, out string error)
        {
            error = string.Empty;
            var ordersDict = new Dictionary<int, Order>();

            // Заменено n.id на n.item_id для соединения с номенклатурой
            string query = @"
                SELECT 
                    o.order_id,
                    o.contract_number, 
                    o.order_date, 
                    c.name AS counterparty_name, 
                    o.order_status, 
                    o.planned_shipment_date,
                    n.name AS nomenclature_name,
                    oi.quantity,
                    oi.unit_price
                FROM customer_orders o
                JOIN counterparties c ON o.counterparty_id = c.counterparty_id
                LEFT JOIN order_items oi ON o.order_id = oi.order_id
                LEFT JOIN nomenclature n ON oi.item_id = n.item_id
                WHERE o.order_date >= @startDate AND o.order_date <= @endDate
                ORDER BY o.order_date DESC;";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("startDate", filterDate.StartDate);
                        cmd.Parameters.AddWithValue("endDate", filterDate.EndDate);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int orderId = Convert.ToInt32(reader["order_id"]);

                                if (!ordersDict.TryGetValue(orderId, out var orderRow))
                                {
                                    orderRow = new Order
                                    {
                                        ContractNumber = reader["contract_number"].ToString(),
                                        OrderDate = Convert.ToDateTime(reader["order_date"]),
                                        CounterpartyName = reader["counterparty_name"].ToString(),
                                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader["order_status"].ToString()),
                                        PlannedShipmentDate = Convert.ToDateTime(reader["planned_shipment_date"]),
                                        Items = new List<OrderItem>()
                                    };
                                    ordersDict.Add(orderId, orderRow);
                                }

                                if (reader["nomenclature_name"] != DBNull.Value)
                                {
                                    var item = new OrderItem
                                    {
                                        NomenclatureName = reader["nomenclature_name"].ToString(),
                                        Quantity = Convert.ToInt32(reader["quantity"]),
                                        UnitPrice = Convert.ToDecimal(reader["unit_price"])
                                    };
                                    orderRow.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка при загрузке списка заказов: " + ex.Message;
                return new List<Order>();
            }

            return new List<Order>(ordersDict.Values);
        }

        public List<Order> GetAllOrders(out string error)
        {
            var filter = new OrderDateFilter
            {
                StartDate = new DateTime(2000, 1, 1),
                EndDate = DateTime.Now.AddYears(1)
            };
            return GetOrdersByPeriod(filter, out error);
        }

        public string UpdateOrderStatus(string contractNumber, OrderStatus newStatus)
        {
            string query = "UPDATE customer_orders SET order_status = @status WHERE contract_number = @contractNumber;";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("status", (int)newStatus);
                        cmd.Parameters.AddWithValue("contractNumber", contractNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            return "Заказ с указанным номером договора не найден в базе данных.";
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Ошибка базы данных при обновлении статуса: " + ex.Message;
            }
        }

        public List<OrderItem> GetOrderItemsByContract(string contractNumber, out string error)
        {
            error = string.Empty;
            var items = new List<OrderItem>();

            string query = @"
                SELECT n.name AS nomenclature_name, oi.quantity, oi.unit_price 
                FROM order_items oi
                JOIN customer_orders o ON oi.order_id = o.order_id
                JOIN nomenclature n ON oi.item_id = n.item_id
                WHERE o.contract_number = @contractNumber;";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("contractNumber", contractNumber);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                items.Add(new OrderItem
                                {
                                    NomenclatureName = reader["nomenclature_name"].ToString(),
                                    Quantity = Convert.ToInt32(reader["quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["unit_price"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка при загрузке состава заказа: " + ex.Message;
                items.Clear();
            }

            return items;
        }

        public bool AddOrderItem(string contractNumber, OrderItem item, out string error)
        {
            error = string.Empty;

            if (item.Quantity <= 0)
            {
                error = "Количество должно быть больше нуля.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(item.NomenclatureName))
            {
                error = "Необходимо выбрать номенклатуру.";
                return false;
            }

                        string query = @"
        INSERT INTO order_items (order_id, item_id, quantity, unit_price)
        SELECT o.order_id, n.item_id, @quantity, @unitPrice
        FROM customer_orders o
        CROSS JOIN nomenclature n
        WHERE o.contract_number = @contractNumber AND n.name = @nomenclatureName;";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("contractNumber", contractNumber);
                        cmd.Parameters.AddWithValue("quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("unitPrice", item.UnitPrice); // Передаем цену
                        cmd.Parameters.AddWithValue("nomenclatureName", item.NomenclatureName);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0) return true;

                        error = "Не удалось добавить позицию: заказ или номенклатура не найдены.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка базы данных при добавлении позиции: " + ex.Message;
                return false;
            }
        }

        public bool UpdateOrderItem(string contractNumber, OrderItem item, out string error)
        {
            error = string.Empty;

            if (item.Quantity <= 0)
            {
                error = "Количество должно быть больше нуля.";
                return false;
            }

            string query = @"
                UPDATE order_items oi
                SET quantity = @quantity
                FROM customer_orders o, nomenclature n
                WHERE oi.order_id = o.order_id 
                  AND oi.item_id = n.item_id
                  AND o.contract_number = @contractNumber 
                  AND n.name = @nomenclatureName;";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("contractNumber", contractNumber);
                        cmd.Parameters.AddWithValue("nomenclatureName", item.NomenclatureName);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0) return true;

                        error = "Позиция не найдена в базе данных.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка базы данных при обновлении позиции: " + ex.Message;
                return false;
            }
        }

        public bool DeleteOrderItem(string contractNumber, OrderItem item, out string error)
        {
            error = string.Empty;

            string query = @"
                DELETE FROM order_items oi
                USING customer_orders o, nomenclature n
                WHERE oi.order_id = o.order_id 
                  AND oi.item_id = n.item_id
                  AND o.contract_number = @contractNumber 
                  AND n.name = @nomenclatureName;";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("contractNumber", contractNumber);
                        cmd.Parameters.AddWithValue("nomenclatureName", item.NomenclatureName);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0) return true;

                        error = "Позиция не найдена в базе данных.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка базы данных при удалении позиции: " + ex.Message;
                return false;
            }
        }

        public Dictionary<string, decimal> GetNomenclaturePrices(out string error)
        {
            error = string.Empty;
            var nomenclaturePrices = new Dictionary<string, decimal>();

            // Сначала заполняем всю номенклатуру из справочника с базовой ценой 0
            string queryNom = "SELECT name FROM nomenclature ORDER BY name;";

            // И подтягиваем реальные цены из истории заказов (order_items), если они там есть
            string queryPrices = @"
        SELECT n.name, oi.unit_price 
        FROM nomenclature n
        JOIN order_items oi ON n.item_id = oi.item_id;";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();

                    using (var cmd = new NpgsqlCommand(queryNom, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nomenclaturePrices[reader["name"].ToString()] = 0m;
                            }
                        }
                    }

                    using (var cmd = new NpgsqlCommand(queryPrices, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["name"].ToString();
                                decimal price = Convert.ToDecimal(reader["unit_price"]);
                                nomenclaturePrices[name] = price; 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка загрузки цен номенклатуры: " + ex.Message;
                nomenclaturePrices.Clear();
            }

            return nomenclaturePrices;
        }
    }
}
