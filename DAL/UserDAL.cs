using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

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

        //  USER MANAGEMENT — used by UserForm

        // Get all users with faculty name
        public static List<User> GetAll()
        {
            string sql = @"
                SELECT   u.user_id,
                         u.emp_id,
                         u.username,
                         u.role,
                         u.is_active,
                         COALESCE(f.name, 'N/A')
                             AS faculty_name
                FROM     users u
                LEFT JOIN faculty f
                       ON u.emp_id = f.emp_id
                ORDER BY u.username ASC";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            return MapToList(dt);
        }

        // Get user by ID
        public static User GetById(int userId)
        {
            string sql = @"
                SELECT   u.user_id,
                         u.emp_id,
                         u.username,
                         u.role,
                         u.is_active,
                         COALESCE(f.name, 'N/A')
                             AS faculty_name
                FROM     users u
                LEFT JOIN faculty f
                       ON u.emp_id = f.emp_id
                WHERE    u.user_id = @userId";

            var p = new[]
            {
                new MySqlParameter("@userId", userId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);

            return dt.Rows.Count == 0 ? null : MapToObject(dt.Rows[0]);
        }

        // Search users 
        public static List<User> Search(
            string keyword)
        {
            string sql = @"
                SELECT   u.user_id,
                         u.emp_id,
                         u.username,
                         u.role,
                         u.is_active,
                         COALESCE(f.name, 'N/A')
                             AS faculty_name
                FROM     users u
                LEFT JOIN faculty f
                       ON u.emp_id = f.emp_id
                WHERE    u.username LIKE @kw
                OR       u.role     LIKE @kw
                OR       f.name     LIKE @kw
                ORDER BY u.username ASC";

            var p = new[]
            {
                new MySqlParameter("@kw", "%" + keyword + "%")
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            return MapToList(dt);
        }

        // Insert new user 
        public static bool Insert(User u, string hashedPassword)
        {
            string sql = @"
                INSERT INTO users
                    (emp_id,    username,
                     password,  role,
                     is_active)
                VALUES
                    (@empId,    @username,
                     @password, @role,
                     @isActive)";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",
                    u.EmpId == null
                        ? (object)DBNull.Value
                        : u.EmpId),
                new MySqlParameter(
                    "@username",  u.Username),
                new MySqlParameter(
                    "@password",  hashedPassword),
                new MySqlParameter(
                    "@role",      u.Role),
                new MySqlParameter(
                    "@isActive",
                    u.IsActive ? 1 : 0)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Update user without password change 
        public static bool Update(User u)
        {
            string sql = @"
                UPDATE users
                SET    emp_id    = @empId,
                       username  = @username,
                       role      = @role,
                       is_active = @isActive
                WHERE  user_id   = @userId";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",
                    u.EmpId == null
                        ? (object)DBNull.Value
                        : u.EmpId),
                new MySqlParameter(
                    "@username",  u.Username),
                new MySqlParameter(
                    "@role",      u.Role),
                new MySqlParameter(
                    "@isActive",
                    u.IsActive ? 1 : 0),
                new MySqlParameter(
                    "@userId",    u.UserId)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Update user WITH new password
        public static bool UpdateWithPassword(User u, string hashedPassword)
        {
            string sql = @"
                UPDATE users
                SET    emp_id    = @empId,
                       username  = @username,
                       password  = @password,
                       role      = @role,
                       is_active = @isActive
                WHERE  user_id   = @userId";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",
                    u.EmpId == null
                        ? (object)DBNull.Value
                        : u.EmpId),
                new MySqlParameter(
                    "@username",  u.Username),
                new MySqlParameter(
                    "@password",  hashedPassword),
                new MySqlParameter(
                    "@role",      u.Role),
                new MySqlParameter(
                    "@isActive",
                    u.IsActive ? 1 : 0),
                new MySqlParameter(
                    "@userId",    u.UserId)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // ── Delete user ───────────────────────────────
        public static bool Delete(int userId)
        {
            // Cannot delete your own account
            if (userId == SessionManager.UserId)
                return false;

            string sql = @"
                DELETE FROM users
                WHERE  user_id = @userId";

            var p = new[]
            {
                new MySqlParameter(
                    "@userId", userId)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Username exists check
        public static bool UsernameExists(string username,int excludeId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   users
                WHERE  username = @username
                AND    user_id != @excludeId";

            var p = new[]
            {
                new MySqlParameter(
                    "@username",  username),
                new MySqlParameter(
                    "@excludeId", excludeId)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Faculty already has a user account
        public static bool FacultyHasUser( int empId, int excludeUserId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   users
                WHERE  emp_id   = @empId
                AND    user_id != @excludeId";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",     empId),
                new MySqlParameter(
                    "@excludeId", excludeUserId)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Faculty is already an HOD
        public static bool IsAlreadyHOD(
            int empId,
            int excludeUserId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   users
                WHERE  emp_id   = @empId
                AND    role     = 'HOD'
                AND    user_id != @excludeId";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",     empId),
                new MySqlParameter(
                    "@excludeId", excludeUserId)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Map DataTable to List<User> 
        private static List<User> MapToList( DataTable dt)
        {
            var list = new List<User>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToObject(row));
            return list;
        }

        // Map DataRow to User 
        private static User MapToObject(DataRow row)
        {
            return new User(
                Convert.ToInt32(row["user_id"]),
                row["emp_id"] == DBNull.Value
                    ? (int?)null
                    : Convert.ToInt32(
                        row["emp_id"]),
                row["username"].ToString(),
                row["role"].ToString(),
                Convert.ToBoolean(row["is_active"]),
                row["faculty_name"].ToString()
            );
        }
    }
}
