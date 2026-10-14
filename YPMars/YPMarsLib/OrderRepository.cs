using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderRepository : IOrderRepository
    {
        public string CreateOrder(Order order)
        {
            if (order == null)
            {
                return "Заказ не сформирован";
            }

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        // 1. Находим counterparty_id по имени
                        int counterpartyId;
                        using (var cmd = new NpgsqlCommand(
                            "SELECT counterparty_id FROM counterparties WHERE name = @name LIMIT 1;",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("name", order.CounterpartyName);
                            var result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                transaction.Rollback();
                                return "Контрагент не найден в справочнике";
                            }
                            counterpartyId = Convert.ToInt32(result);
                        }

                        // 2. Вставляем заказ
                        int orderId;
                        using (var cmd = new NpgsqlCommand(
                            @"INSERT INTO customer_orders
                                (contract_number, order_date, counterparty_id, employee_id, order_status, planned_shipment_date)
                              VALUES (@contract_number, @order_date, @counterparty_id, @employee_id, @order_status, @planned_shipment_date)
                              RETURNING order_id;",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("contract_number", order.ContractNumber);
                            cmd.Parameters.AddWithValue("order_date", order.OrderDate);
                            cmd.Parameters.AddWithValue("counterparty_id", counterpartyId);
                            cmd.Parameters.AddWithValue("order_status", order.Status.ToString());
                            cmd.Parameters.AddWithValue("planned_shipment_date", order.PlannedShipmentDate);

                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 3. Вставляем позиции
                        foreach (var item in order.Items)
                        {
                            // 3.1. Находим item_id по имени
                            int nomenclatureId;
                            using (var cmd = new NpgsqlCommand(
                                "SELECT item_id FROM nomenclature WHERE name = @name LIMIT 1;",
                                connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("name", item.NomenclatureName);
                                var result = cmd.ExecuteScalar();
                                if (result == null || result == DBNull.Value)
                                {
                                    transaction.Rollback();
                                    return $"Номенклатура \"{item.NomenclatureName}\" не найдена в справочнике";
                                }
                                nomenclatureId = Convert.ToInt32(result);
                            }

                            // 3.2. Цена. TODO: подставляем из nomenclature.unit_price.
                            // Если такой колонки нет — заменить на явную передачу из Справочники.GetUnitPrice().
                            decimal unitPrice = item.UnitPrice;

                            // 3.3. INSERT позиции
                            using (var cmd = new NpgsqlCommand(
                                @"INSERT INTO order_items
                                    (order_id, item_id, quantity, unit_price, total_price)
                                  VALUES (@order_id, @item_id, @quantity, @unit_price, @total_price);",
                                connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("order_id", orderId);
                                cmd.Parameters.AddWithValue("item_id", nomenclatureId);
                                cmd.Parameters.AddWithValue("quantity", item.Quantity);
                                cmd.Parameters.AddWithValue("unit_price", unitPrice);
                                cmd.Parameters.AddWithValue("total_price", item.TotalPrice);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Ошибка при сохранении заказа: " + ex.Message;
            }
        }

        public int GetLastOrderNumberInYear(int year)
        {
            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(
                        @"SELECT contract_number FROM customer_orders
                          WHERE contract_number LIKE @pattern
                          ORDER BY contract_number DESC
                          LIMIT 1;", connection))
                    {
                        cmd.Parameters.AddWithValue("pattern", $"ДГ-{year:D4}-%");
                        var result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            return 0;
                        }

                        string contractNumber = result.ToString();
                        // Формат: ДГ-2026-000001 → берём последние 6 символов
                        string tail = contractNumber.Substring(contractNumber.Length - 6);
                        if (int.TryParse(tail, out int number))
                        {
                            return number;
                        }
                        return 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public List<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            var map = new Dictionary<int, Order>();

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(
                        @"SELECT o.order_id, o.contract_number, o.order_date, c.name AS counterparty_name,
                                 o.order_status, o.planned_shipment_date,
                                 n.name AS nomenclature_name, oi.quantity, oi.unit_price
                          FROM customer_orders o
                          JOIN counterparties c ON o.counterparty_id = c.counterparty_id
                          LEFT JOIN order_items oi ON o.order_id = oi.order_id
                          LEFT JOIN nomenclature n ON oi.item_id = n.item_id
                          ORDER BY o.order_id;", connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int orderId = Convert.ToInt32(reader["order_id"]);
                            if (!map.TryGetValue(orderId, out var order))
                            {
                                order = new Order
                                {
                                    ContractNumber = reader["contract_number"].ToString(),
                                    OrderDate = Convert.ToDateTime(reader["order_date"]),
                                    CounterpartyName = reader["counterparty_name"].ToString(),
                                    Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader["order_status"].ToString()),
                                    PlannedShipmentDate = Convert.ToDateTime(reader["planned_shipment_date"]),
                                    Items = new List<OrderItem>()
                                };
                                map.Add(orderId, order);
                                orders.Add(order);
                            }

                            if (reader["nomenclature_name"] != DBNull.Value)
                            {
                                order.Items.Add(new OrderItem
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
            catch
            {
                // Возвращаем то, что успели прочитать
            }

            return orders;
        }
    }
}
