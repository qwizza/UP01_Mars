using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class DBConnection
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                    _connectionString = ResolveConnectionString();
                return _connectionString;
            }
            set => _connectionString = value;
        }

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }

        private static string ResolveConnectionString()
        {
            string activeDb = ConfigurationManager.AppSettings["ActiveDb"] ?? "Auto";

            if (!string.Equals(activeDb, "Auto", StringComparison.OrdinalIgnoreCase))
            {
                var exact = ConfigurationManager.ConnectionStrings[activeDb];
                if (exact != null && !string.IsNullOrWhiteSpace(exact.ConnectionString))
                    return exact.ConnectionString;
            }

            foreach (ConnectionStringSettings cs in ConfigurationManager.ConnectionStrings)
            {
                if (string.IsNullOrWhiteSpace(cs.ConnectionString) || cs.Name == "LocalSqlServer")
                    continue;

                if (CanConnect(cs.ConnectionString))
                    return cs.ConnectionString;
            }

            var fallback = ConfigurationManager.ConnectionStrings["HomeDB"]
                        ?? ConfigurationManager.ConnectionStrings["CollegeDB"];
            return fallback?.ConnectionString ?? string.Empty;
        }

        private static bool CanConnect(string connStr)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}