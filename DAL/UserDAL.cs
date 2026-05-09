using System;
using System.Data;
using MySql.Data.MySqlClient;
using FacultyWorkloadSystem.Helpers;

namespace FacultyWorkloadSystem.DAL
{
    public class UserDAL
    {
        public static DataRow GetUserByCredentials(string username, string hashedPassword)
        {
            string query = @"SELECT user_id, username, role, emp_id
                             FROM   users
                             WHERE  username  = @username
                             AND    password  = @password
                             AND    is_active = 1";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", hashedPassword)
            };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);
            if (result.Rows.Count == 1)
            {
                return result.Rows[0];
            }
            else
            {
                return null;
            }
        }
        public static void UpdateLastLogin(int userId)
        {
            string query = "UPDATE users SET last_login = NOW() WHERE user_id = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", userId) };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}