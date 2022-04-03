using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace WinFormsApp1
{
    internal class DatabaseConnection
    {
        private NpgsqlConnection conn;
        public DatabaseConnection()
        {
            conn = new NpgsqlConnection(@"Server=localhost;Port=55000;User Id=postgres;Password=714;Database=AUTOSERVICE;");
            conn.Open();
        }
        public void closeConnection()
        {
            conn.Close();
        }
        public NpgsqlConnection GetConnection()
        {
            return conn;
        }
        public bool TestConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else return false;
        }
    }
}
