using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderReportRepository : IOrderReportRepository
    {
        public OrderReport GetOrderReportData(string contractNumber, out string error)
        {
            error = string.Empty;
            string query = @"
                SELECT 
                    o.contract_number, o.order_date, o.order_status, o.planned_shipment_date,
                    c.name AS counterparty_name, c.inn AS counterparty_inn, c.kpp AS counterparty_kpp, c.address AS counterparty_address,
                    n.name AS nomenclature_name, oi.quantity, oi.unit_price
                FROM customer_orders o
                JOIN counterparties c ON o.counterparty_id = c.counterparty_id
                LEFT JOIN order_items oi ON o.order_id = oi.order_id
                LEFT JOIN nomenclature n ON oi.item_id = n.item_id
                WHERE o.contract_number = @contractNumber
                ORDER BY n.name;";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("contractNumber", contractNumber);
                        OrderReport report = null;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (report == null)
                                {
                                    report = new OrderReport
                                    {
                                        ContractNumber = reader["contract_number"].ToString(),
                                        OrderDate = Convert.ToDateTime(reader["order_date"]),
                                        StatusText = reader["order_status"].ToString(),
                                        PlannedShipmentDate = reader["planned_shipment_date"] == DBNull.Value
                                            ? (DateTime?)null
                                            : Convert.ToDateTime(reader["planned_shipment_date"]),
                                        CounterpartyName = reader["counterparty_name"].ToString(),
                                        CounterpartyINN = reader["counterparty_inn"]?.ToString(),
                                        CounterpartyKPP = reader["counterparty_kpp"]?.ToString(),
                                        CounterpartyAddress = reader["counterparty_address"]?.ToString(),
                                        Items = new List<OrderItem>()
                                    };
                                }

                                if (reader["nomenclature_name"] != DBNull.Value)
                                {
                                    report.Items.Add(new OrderItem
                                    {
                                        NomenclatureName = reader["nomenclature_name"].ToString(),
                                        Quantity = Convert.ToInt32(reader["quantity"]),
                                        UnitPrice = Convert.ToDecimal(reader["unit_price"])
                                    });
                                }
                            }
                        }

                        if (report == null)
                        {
                            error = "Заказ не найден";
                            return null;
                        }
                        return report;
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка при загрузке данных: " + ex.Message;
                return null;
            }
        }
    }
}
