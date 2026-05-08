using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FacultyWorkloadSystem.Helpers
{
    public class DatabaseHelper
    {
        private static readonly string _connStr =
            ConfigurationManager
            .ConnectionStrings["FacultyDB"].ConnectionString;

        // Get a new connection
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connStr);
        }

        // Test if connection works
        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
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

        // For SELECT queries — returns a DataTable
        public static DataTable ExecuteQuery(string query,
            MySqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // For INSERT, UPDATE, DELETE — returns rows affected
        public static int ExecuteNonQuery(string query,
            MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // For getting a single value — e.g. COUNT(*)
        public static object ExecuteScalar(string query,
            MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        // For transactions — approve leave + deduct balance etc.
        public static bool ExecuteTransaction(
            string[] queries,
            MySqlParameter[][] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < queries.Length; i++)
                    {
                        MySqlCommand cmd =
                            new MySqlCommand(queries[i], conn, transaction);
                        if (parameters != null && parameters[i] != null)
                            cmd.Parameters.AddRange(parameters[i]);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LogManager.LogError(ex);
                    return false;
                }
            }
        }
    }
}