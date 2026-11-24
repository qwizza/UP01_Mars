using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class WarehouseRepository : IWarehouseRepository
    {
        public List<WarehouseItem> GetWarehouseStock(out string error)
        {
            error = string.Empty;
            var stockList = new List<WarehouseItem>();

            string query = @"
                SELECT 
                    name AS nomenclature_name,
                    'Основной склад' AS storage_zone,
                    COALESCE(total_quantity, 0) AS total_quantity,
                    COALESCE(reserved_quantity, 0) AS reserved_quantity,
                    COALESCE(unit_price, 0) AS unit_price
                FROM nomenclature";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new WarehouseItem
                                {
                                    NomenclatureName = reader["nomenclature_name"].ToString(),
                                    StorageZone = reader["storage_zone"].ToString(),
                                    TotalQuantity = Convert.ToInt32(reader["total_quantity"]),
                                    ReservedQuantity = Convert.ToInt32(reader["reserved_quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["unit_price"])
                                };
                                stockList.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка получения складских остатков: " + ex.Message;
            }

            return stockList;
        }
    }
}
