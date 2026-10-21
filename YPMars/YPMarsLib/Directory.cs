using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class Directory
    {
        public List<string> GetCounterparties()
        {
            var list = new List<string>();
            using (var connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(
                    "SELECT name FROM counterparties ORDER BY name;", connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["name"].ToString());
                    }
                }
            }
            return list;
        }

        public List<string> GetNomenclature()
        {
            var list = new List<string>();
            using (var connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(
                    "SELECT name FROM nomenclature ORDER BY name;", connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["name"].ToString());
                    }
                }
            }
            return list;
        }

        public decimal GetUnitPrice(string nomenclatureName)
        {
            using (var connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(
                    "SELECT unit_price FROM nomenclature WHERE name = @name LIMIT 1;", connection))
                {
                    cmd.Parameters.AddWithValue("name", nomenclatureName);
                    var result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        return 0m;
                    }
                    return Convert.ToDecimal(result);
                }
            }
        }

        public List<string> SearchCounterparties(string query)
        {
            var list = new List<string>();
            if (string.IsNullOrWhiteSpace(query)) return list;

            using (var connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(
                    "SELECT name FROM counterparties WHERE name ILIKE @q ORDER BY name LIMIT 20;",
                    connection))
                {
                    cmd.Parameters.AddWithValue("q", $"%{query}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader["name"].ToString());
                        }
                    }
                }
            }
            return list;
        }

        public List<string> SearchNomenclature(string query)
        {
            var list = new List<string>();
            if (string.IsNullOrWhiteSpace(query)) return list;

            using (var connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(
                    "SELECT name FROM nomenclature WHERE name ILIKE @q ORDER BY name LIMIT 20;",
                    connection))
                {
                    cmd.Parameters.AddWithValue("q", $"%{query}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader["name"].ToString());
                        }
                    }
                }
            }
            return list;
        }
    }
}
