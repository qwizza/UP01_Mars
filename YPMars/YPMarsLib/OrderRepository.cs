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
                return "Заказ не сформирован";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Находим counterparty_id
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

                            // 2. Вставляем заказ (order_id генерируется БД)
                            int orderId;
                            using (var cmd = new NpgsqlCommand(
                                @"INSERT INTO customer_orders
                                (contract_number, order_date, counterparty_id, order_status, planned_shipment_date)
                              VALUES (@contract_number, @order_date, @counterparty_id, @order_status, @planned_shipment_date)
                              RETURNING order_id;",
                                connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("contract_number", order.ContractNumber);
                                cmd.Parameters.AddWithValue("order_date", order.OrderDate);
                                cmd.Parameters.AddWithValue("counterparty_id", counterpartyId);
                                cmd.Parameters.AddWithValue("order_status", (int)order.Status);
                                cmd.Parameters.AddWithValue("planned_shipment_date",
                                    (object)order.PlannedShipmentDate ?? DBNull.Value);

                                orderId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // 3. Вставляем позиции
                            foreach (var item in order.Items)
                            {
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

                                // total_price НЕ указываем — БД считает его сама (generated column)
                                using (var cmd = new NpgsqlCommand(
                                    @"INSERT INTO order_items
                                    (order_id, item_id, quantity, unit_price)
                                  VALUES (@order_id, @item_id, @quantity, @unit_price);",
                                    connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("order_id", orderId);
                                    cmd.Parameters.AddWithValue("item_id", nomenclatureId);
                                    cmd.Parameters.AddWithValue("quantity", item.Quantity);
                                    cmd.Parameters.AddWithValue("unit_price", item.UnitPrice);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return string.Empty;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
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
                            return 0;

                        string contractNumber = result.ToString();
                        string tail = contractNumber.Substring(contractNumber.Length - 6);
                        return int.TryParse(tail, out int number) ? number : 0;
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
                                    Status = (OrderStatus)Convert.ToInt32(reader["order_status"]),
                                    PlannedShipmentDate = reader["planned_shipment_date"] == DBNull.Value
                                        ? (DateTime?)null
                                        : Convert.ToDateTime(reader["planned_shipment_date"]),
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
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка в GetAllOrders: " + ex.Message);
            }

            return orders;
        }

        public List<Order> GetOrdersByFilter(OrderFilter filter)
        {
            var orders = new List<Order>();
            var map = new Dictionary<int, Order>();

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();

                    // Базовый запрос
                    var sql = new StringBuilder(@"
                        SELECT o.order_id, o.contract_number, o.order_date, c.name AS counterparty_name,
                               o.order_status, o.planned_shipment_date,
                               n.name AS nomenclature_name, oi.quantity, oi.unit_price
                        FROM customer_orders o
                        JOIN counterparties c ON o.counterparty_id = c.counterparty_id
                        LEFT JOIN order_items oi ON o.order_id = oi.order_id
                        LEFT JOIN nomenclature n ON oi.item_id = n.item_id
                        WHERE 1=1");

                    // Динамически добавляем условия
                    if (!string.IsNullOrWhiteSpace(filter.CounterpartyName))
                        sql.Append(" AND c.name = @counterparty_name");

                    if (filter.Status.HasValue)
                        sql.Append(" AND o.order_status = @status");

                    if (filter.OrderDateFrom.HasValue)
                        sql.Append(" AND o.order_date >= @date_from");

                    if (filter.OrderDateTo.HasValue)
                        sql.Append(" AND o.order_date <= @date_to");

                    if (filter.PlannedShipmentFrom.HasValue)
                        sql.Append(" AND o.planned_shipment_date >= @ship_from");

                    if (filter.PlannedShipmentTo.HasValue)
                        sql.Append(" AND o.planned_shipment_date <= @ship_to");

                    sql.Append(" ORDER BY o.order_id;");

                    using (var cmd = new NpgsqlCommand(sql.ToString(), connection))
                    {
                        // Добавляем параметры (только если они есть)
                        if (!string.IsNullOrWhiteSpace(filter.CounterpartyName))
                            cmd.Parameters.AddWithValue("counterparty_name", filter.CounterpartyName);
                        if (filter.Status.HasValue)
                            cmd.Parameters.AddWithValue("status", (int)filter.Status.Value);
                        if (filter.OrderDateFrom.HasValue)
                            cmd.Parameters.AddWithValue("date_from", filter.OrderDateFrom.Value);
                        if (filter.OrderDateTo.HasValue)
                            cmd.Parameters.AddWithValue("date_to", filter.OrderDateTo.Value);
                        if (filter.PlannedShipmentFrom.HasValue)
                            cmd.Parameters.AddWithValue("ship_from", filter.PlannedShipmentFrom.Value);
                        if (filter.PlannedShipmentTo.HasValue)
                            cmd.Parameters.AddWithValue("ship_to", filter.PlannedShipmentTo.Value);

                        using (var reader = cmd.ExecuteReader())
                        {
                            MapOrders(reader, map, orders);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка в GetOrdersByFilter: " + ex.Message);
            }
            return orders;
        }

        public List<Order> GetOrdersSorted(string sortField, bool ascending)
        {
            var orders = new List<Order>();
            var map = new Dictionary<int, Order>();

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();

                    string column;
                    switch (sortField)
                    {
                        case "ContractNumber":
                            column = "o.contract_number";
                            break;
                        case "OrderDate":
                            column = "o.order_date";
                            break;
                        case "Status":
                            column = "o.order_status";
                            break;
                        case "PlannedShipmentDate":
                            column = "o.planned_shipment_date";
                            break;
                        default:
                            column = "o.order_id";
                            break;
                    }

                    string direction = ascending ? "ASC" : "DESC";

                    string sql = $@"
                SELECT o.order_id, o.contract_number, o.order_date, c.name AS counterparty_name,
                       o.order_status, o.planned_shipment_date,
                       n.name AS nomenclature_name, oi.quantity, oi.unit_price
                FROM customer_orders o
                JOIN counterparties c ON o.counterparty_id = c.counterparty_id
                LEFT JOIN order_items oi ON o.order_id = oi.order_id
                LEFT JOIN nomenclature n ON oi.item_id = n.item_id
                ORDER BY {column} {direction};";

                    using (var cmd = new NpgsqlCommand(sql, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        MapOrders(reader, map, orders);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка в GetOrdersSorted: " + ex.Message);
            }
            return orders;
        }

        private void MapOrders(NpgsqlDataReader reader, Dictionary<int, Order> map, List<Order> orders)
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
                        Status = (OrderStatus)Convert.ToInt32(reader["order_status"]),
                        PlannedShipmentDate = reader["planned_shipment_date"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(reader["planned_shipment_date"]),
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
