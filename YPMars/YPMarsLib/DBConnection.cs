using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class DBConnection
    {
        private static string _connectionString;

        static DBConnection()
        {
            _connectionString = "Host=192.168.1.48;Username=st50-11;Password=5011;Database=MarsFactoryDB"; 
        }
        public static string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }
        public static NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            return connection;
        }
    }
}
