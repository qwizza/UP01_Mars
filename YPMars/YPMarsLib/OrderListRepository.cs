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

        public List<OrderRow> GetOrdersByPeriod(OrderDateFilter filterDate, out string error)
        {
            error = string.Empty;
            var ordersDict = new Dictionary<int, OrderRow>();

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
                                    orderRow = new OrderRow
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
                return new List<OrderRow>();
            }

            return new List<OrderRow>(ordersDict.Values);
        }

        public List<OrderRow> GetAllOrders(out string error)
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
                        cmd.Parameters.AddWithValue("status", newStatus.ToString());
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
    }
}
