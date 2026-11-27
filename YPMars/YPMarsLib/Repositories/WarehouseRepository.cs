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
        public bool RegisterStockReceipt(WarehouseItem receiptItem, out string error)
        {
            error = string.Empty;

            if (receiptItem == null)
            {
                error = "Данные поступления не переданы.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(receiptItem.NomenclatureName))
            {
                error = "Необходимо указать наименование номенклатуры.";
                return false;
            }

            if (receiptItem.TotalQuantity <= 0)
            {
                error = "Количество поступления должно быть больше нуля.";
                return false;
            }

            if (receiptItem.UnitPrice < 0)
            {
                error = "Цена за единицу не может быть отрицательной.";
                return false;
            }

            string name = receiptItem.NomenclatureName.Trim();
            string checkQuery = "SELECT COUNT(1) FROM nomenclature WHERE LOWER(name) = LOWER(@name);";
            string updateQuery = @"
                UPDATE nomenclature
                SET total_quantity = COALESCE(total_quantity, 0) + @quantity,
                    unit_price = @unitPrice
                WHERE LOWER(name) = LOWER(@name);";
            string insertQuery = @"
                INSERT INTO nomenclature (article, name, item_type, unit, total_quantity, reserved_quantity, unit_price)
                VALUES (@article, @name, @itemType, @unit, @quantity, 0, @unitPrice);";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();

                    long exists;
                    using (var checkCmd = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("name", name);
                        exists = Convert.ToInt64(checkCmd.ExecuteScalar());
                    }

                    string sql = exists > 0 ? updateQuery : insertQuery;
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("name", name);
                        cmd.Parameters.AddWithValue("quantity", receiptItem.TotalQuantity);
                        cmd.Parameters.AddWithValue("unitPrice", receiptItem.UnitPrice);

                        if (exists == 0)
                        {
                            string generatedArticle = "PRD-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
                            cmd.Parameters.AddWithValue("article", generatedArticle);
                            cmd.Parameters.AddWithValue("itemType", "Готовое изделие");
                            cmd.Parameters.AddWithValue("unit", "шт.");
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return true;

                        error = "Не удалось зарегистрировать поступление на склад.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка базы данных при оформлении поступления: " + ex.Message;
                return false;
            }
        }
    }
}
