using System;
using System.Data;
using System.Data.OleDb;

namespace MukeshShop
{
    public static class DB
    {
        // 🔐 If password protected
        private static readonly string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\db_shop.accdb;Jet OLEDB:Database Password=12345687;";

        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(connStr);
        }

        // Basic query without parameters
        public static DataTable GetData(string query)
        {
            using (OleDbConnection conn = GetConnection())
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                da.Fill(dt);
                return dt;
            }
        }

        // Overloaded version with parameters
        public static DataTable GetData(string query, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = GetConnection())
            {
                DataTable dt = new DataTable();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddRange(parameters);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        // Basic execute without parameters
        public static int ExecuteQuery(string query)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // Overloaded version with parameters
        public static int ExecuteQuery(string query, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // Execute scalar query (for single value returns)
        public static object ExecuteScalar(string query, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        // Helper method to create parameters
        public static OleDbParameter CreateParameter(string name, object value, OleDbType type)
        {
            return new OleDbParameter(name, type) { Value = value };
        }

        // Helper method for date parameters (common in sales queries)
        public static OleDbParameter CreateDateParameter(string name, DateTime value)
        {
            return CreateParameter(name, value.Date, OleDbType.Date);
        }
    }
}