using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib.Models;

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

        public bool RegisterStockWriteOff(WarehouseItem writeOffItem, string userName, out string error)
        {
            error = string.Empty;

            if (writeOffItem == null)
            {
                error = "Данные списания не переданы.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(writeOffItem.NomenclatureName))
            {
                error = "Необходимо указать наименование номенклатуры.";
                return false;
            }
            if (writeOffItem.TotalQuantity <= 0)
            {
                error = "Количество списания должно быть больше нуля.";
                return false;
            }
            if (writeOffItem.UnitPrice < 0)
            {
                error = "Цена за единицу не может быть отрицательной.";
                return false;
            }

            string name = writeOffItem.NomenclatureName.Trim();
            int quantity = writeOffItem.TotalQuantity;

            const string selectQuery = @"
        SELECT item_id,
               COALESCE(total_quantity, 0)    AS total_quantity,
               COALESCE(reserved_quantity, 0) AS reserved_quantity
        FROM nomenclature
        WHERE LOWER(name) = LOWER(@name)
        FOR UPDATE;";

            const string updateQuery = @"
        UPDATE nomenclature
        SET total_quantity = COALESCE(total_quantity, 0) - @quantity
        WHERE item_id = @itemId;";

            const string insertQuery = @"
        INSERT INTO warehouse_write_offs
            (write_off_date, item_id, quantity, unit_price, user_name)
        VALUES (NOW(), @itemId, @quantity, @unitPrice, @userName);";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int itemId, totalQuantity, reservedQuantity;

                            using (var cmd = new NpgsqlCommand(selectQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("name", name);
                                using (var reader = cmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        transaction.Rollback();
                                        error = "Номенклатура не найдена на складе.";
                                        return false;
                                    }
                                    itemId = Convert.ToInt32(reader["item_id"]);
                                    totalQuantity = Convert.ToInt32(reader["total_quantity"]);
                                    reservedQuantity = Convert.ToInt32(reader["reserved_quantity"]);
                                }
                            }

                            int available = Math.Max(0, totalQuantity - reservedQuantity);
                            if (quantity > available)
                            {
                                transaction.Rollback();
                                error = $"Недостаточно доступного остатка для списания. Доступно: {available} шт.";
                                return false;
                            }

                            using (var cmd = new NpgsqlCommand(updateQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("quantity", quantity);
                                cmd.Parameters.AddWithValue("itemId", itemId);
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = new NpgsqlCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("itemId", itemId);
                                cmd.Parameters.AddWithValue("quantity", quantity);
                                cmd.Parameters.AddWithValue("unitPrice", writeOffItem.UnitPrice);
                                cmd.Parameters.AddWithValue("userName", userName ?? string.Empty);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
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
                error = "Ошибка базы данных при оформлении списания: " + ex.Message;
                return false;
            }
        }

        public List<WarehouseWriteOffRecord> GetWriteOffReport(WarehouseWriteOffFilter filter, out string error)
        {
            error = string.Empty;
            var records = new List<WarehouseWriteOffRecord>();

            if (filter == null)
            {
                error = "Не задан период отчёта.";
                return records;
            }

            string query = @"
        SELECT w.write_off_id,
               w.write_off_date,
               n.name AS nomenclature_name,
               w.quantity,
               w.unit_price,
               w.user_name
        FROM warehouse_write_offs w
        JOIN nomenclature n ON n.item_id = w.item_id
        WHERE w.write_off_date >= @startDate
          AND w.write_off_date <= @endDate";

            if (!string.IsNullOrWhiteSpace(filter.NomenclatureName))
                query += " AND LOWER(n.name) = LOWER(@nomenclatureName)";

            query += " ORDER BY w.write_off_date DESC;";

            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("startDate", filter.StartDate);
                        cmd.Parameters.AddWithValue("endDate", filter.EndDate);
                        if (!string.IsNullOrWhiteSpace(filter.NomenclatureName))
                            cmd.Parameters.AddWithValue("nomenclatureName", filter.NomenclatureName);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                records.Add(new WarehouseWriteOffRecord
                                {
                                    WriteOffId = Convert.ToInt32(reader["write_off_id"]),
                                    WriteOffDate = Convert.ToDateTime(reader["write_off_date"]),
                                    NomenclatureName = reader["nomenclature_name"].ToString(),
                                    Quantity = Convert.ToInt32(reader["quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["unit_price"]),
                                    UserName = reader["user_name"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка загрузки отчёта о списаниях: " + ex.Message;
                records.Clear();
            }

            return records;
        }
    }
}
