using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.DAL
{
    public static class FacultyDAL
    {
        // Get All via VIEW
        public static List<Faculty> GetAll()
        {
            string sql = @"
                SELECT emp_id,
                       name,
                       dept_id,
                       dept_name,
                       designation_id,
                       designation_name,
                       emp_type,
                       email,
                       phone,
                       qualification,
                       is_active,
                       status
                FROM   vw_faculty_details
                ORDER  BY name ASC";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            return MapToList(dt);
        }

        // Search via STORED PROCEDURE 
        public static List<Faculty> Search( string keyword, int deptId = 0, int desigId = 0)
        {
            var list = new List<Faculty>();

            using (var conn =
                DatabaseHelper.GetConnection())
            {
                conn.Open();

                var cmd = new MySqlCommand(
                    "sp_search_faculty", conn);
                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@p_keyword",
                    string.IsNullOrEmpty(keyword)
                        ? (object)DBNull.Value
                        : keyword);

                cmd.Parameters.AddWithValue(
                    "@p_dept_id",
                    deptId == 0
                        ? (object)DBNull.Value
                        : deptId);

                cmd.Parameters.AddWithValue(
                    "@p_desig_id",
                    desigId == 0
                        ? (object)DBNull.Value
                        : desigId);

                var adapter =
                    new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                    list.Add(MapToObject(row));
            }

            return list;
        }

        // Get By ID
        public static Faculty GetById(int empId)
        {
            string sql = @"
                SELECT emp_id,
                       name,
                       dept_id,
                       dept_name,
                       designation_id,
                       designation_name,
                       emp_type,
                       email,
                       phone,
                       qualification,
                       is_active,
                       status
                FROM   vw_faculty_details
                WHERE  emp_id = @empId";

            var p = new[]
            {
                new MySqlParameter("@empId", empId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);

            if (dt.Rows.Count == 0) return null;
            return MapToObject(dt.Rows[0]);
        }

        // Insert 
        public static bool Insert(Faculty f)
        {
            string sql = @"
                INSERT INTO faculty
                    (name, dept_id,
                     designation_id, emp_type,
                     email, phone,
                     qualification, is_active)
                VALUES
                    (@name, @deptId,
                     @desigId, @empType,
                     @email, @phone,
                     @qual, @isActive)";

            var p = new[]
            {
                new MySqlParameter(
                    "@name",     f.Name),
                new MySqlParameter(
                    "@deptId",   f.DeptId),
                new MySqlParameter(
                    "@desigId",  f.DesignationId),
                new MySqlParameter(
                    "@empType",  f.EmpType),
                new MySqlParameter(
                    "@email",
                    string.IsNullOrEmpty(f.Email)
                        ? (object)DBNull.Value
                        : f.Email),
                new MySqlParameter(
                    "@phone",
                    string.IsNullOrEmpty(f.Phone)
                        ? (object)DBNull.Value
                        : f.Phone),
                new MySqlParameter(
                    "@qual",
                    string.IsNullOrEmpty(
                        f.Qualification)
                        ? (object)DBNull.Value
                        : f.Qualification),
                new MySqlParameter(
                    "@isActive",
                    f.IsActive ? 1 : 0)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // Update
        public static bool Update(Faculty f)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // Step 1 — Tell MySQL who is logged in
                // by setting a session variable
                // Trigger reads this as @current_user_id
                var setUser = new MySqlCommand(
                    "SET @current_user_id = @userId",
                    conn);
                setUser.Parameters.AddWithValue(
                    "@userId",
                    SessionManager.UserId);
                setUser.ExecuteNonQuery();

                // Step 2 — Run the actual UPDATE
                // Trigger fires here and reads
                // @current_user_id automatically
                string sql = @"
            UPDATE faculty
            SET    name           = @name,
                   dept_id        = @deptId,
                   designation_id = @desigId,
                   emp_type       = @empType,
                   email          = @email,
                   phone          = @phone,
                   qualification  = @qual,
                   is_active      = @isActive
            WHERE  emp_id         = @empId";

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue(
                    "@name", f.Name);
                cmd.Parameters.AddWithValue(
                    "@deptId", f.DeptId);
                cmd.Parameters.AddWithValue(
                    "@desigId", f.DesignationId);
                cmd.Parameters.AddWithValue(
                    "@empType", f.EmpType);
                cmd.Parameters.AddWithValue(
                    "@email",
                    string.IsNullOrEmpty(f.Email)
                        ? (object)DBNull.Value : f.Email);
                cmd.Parameters.AddWithValue(
                    "@phone",
                    string.IsNullOrEmpty(f.Phone)
                        ? (object)DBNull.Value : f.Phone);
                cmd.Parameters.AddWithValue(
                    "@qual",
                    string.IsNullOrEmpty(f.Qualification)
                        ? (object)DBNull.Value
                        : f.Qualification);
                cmd.Parameters.AddWithValue(
                    "@isActive",
                    f.IsActive ? 1 : 0);
                cmd.Parameters.AddWithValue(
                    "@empId", f.EmpId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Delete 
        public static bool Delete(int empId)
        {
            string sql = @"
                DELETE FROM faculty
                WHERE  emp_id = @empId";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId", empId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // Check if name exists 
        public static bool NameExists(
            string name, int excludeId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   faculty
                WHERE  name    = @name
                  AND  emp_id != @excludeId";

            var p = new[]
            {
                new MySqlParameter(
                    "@name",      name),
                new MySqlParameter(
                    "@excludeId", excludeId)
            };

            object result =
                DatabaseHelper.ExecuteScalar(
                    sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Check if faculty has assignments 
        public static bool HasAssignments(int empId)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   workload_assignments
                WHERE  emp_id = @empId";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId", empId)
            };

            object result =
                DatabaseHelper.ExecuteScalar(
                    sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Map DataTable to List<Faculty> 
        private static List<Faculty> MapToList(
            DataTable dt)
        {
            var list = new List<Faculty>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToObject(row));
            return list;
        }

        // Map DataRow to Faculty object 
        private static Faculty MapToObject(DataRow row)
        {
            return new Faculty(
                Convert.ToInt32(row["emp_id"]),
                row["name"].ToString(),
                Convert.ToInt32(row["dept_id"]),
                row["dept_name"].ToString(),
                Convert.ToInt32(
                    row["designation_id"]),
                row["designation_name"].ToString(),
                row["emp_type"].ToString(),
                row["email"] == DBNull.Value
                    ? "" : row["email"].ToString(),
                row["phone"] == DBNull.Value
                    ? "" : row["phone"].ToString(),
                row["qualification"] == DBNull.Value
                    ? ""
                    : row["qualification"].ToString(),
                Convert.ToBoolean(row["is_active"]),
                row["status"].ToString()
            );
        }
    }
}