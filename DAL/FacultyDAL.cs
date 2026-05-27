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

        // ── Update faculty + sync hod_name ────────────
        // Uses transaction to keep faculty name and
        // departments.hod_name in sync atomically.
        // Trigger trg_faculty_update_log still fires
        // automatically on the faculty UPDATE.
        public static bool Update(Faculty f)
        {
            using (var conn =
                DatabaseHelper.GetConnection())
            {
                conn.Open();

                MySqlTransaction transaction =
                    conn.BeginTransaction();

                try
                {
                    // Step 1 — Set session variable
                    // so trigger knows who made change
                    var setUser = new MySqlCommand(
                        "SET @current_user_id = @userId",
                        conn, transaction);
                    setUser.Parameters.AddWithValue(
                        "@userId",
                        SessionManager.UserId);
                    setUser.ExecuteNonQuery();

                    // Step 2 — Get old name BEFORE
                    // update so we can match it
                    // in departments table
                    string getOldName = @"
                SELECT name
                FROM   faculty
                WHERE  emp_id = @empId";

                    var getCmd = new MySqlCommand(
                        getOldName, conn, transaction);
                    getCmd.Parameters.AddWithValue(
                        "@empId", f.EmpId);

                    string oldName =
                        getCmd.ExecuteScalar()
                              ?.ToString() ?? "";

                    // Step 3 — Update faculty row
                    // Trigger fires automatically here
                    string updateFaculty = @"
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

                    var updCmd = new MySqlCommand(
                        updateFaculty, conn, transaction);

                    updCmd.Parameters.AddWithValue(
                        "@name", f.Name);
                    updCmd.Parameters.AddWithValue(
                        "@deptId", f.DeptId);
                    updCmd.Parameters.AddWithValue(
                        "@desigId", f.DesignationId);
                    updCmd.Parameters.AddWithValue(
                        "@empType", f.EmpType);
                    updCmd.Parameters.AddWithValue(
                        "@email",
                        string.IsNullOrEmpty(f.Email)
                            ? (object)DBNull.Value
                            : f.Email);
                    updCmd.Parameters.AddWithValue(
                        "@phone",
                        string.IsNullOrEmpty(f.Phone)
                            ? (object)DBNull.Value
                            : f.Phone);
                    updCmd.Parameters.AddWithValue(
                        "@qual",
                        string.IsNullOrEmpty(
                            f.Qualification)
                            ? (object)DBNull.Value
                            : f.Qualification);
                    updCmd.Parameters.AddWithValue(
                        "@isActive",
                        f.IsActive ? 1 : 0);
                    updCmd.Parameters.AddWithValue(
                        "@empId", f.EmpId);

                    updCmd.ExecuteNonQuery();

                    // Step 4 — If name changed sync
                    // hod_name in departments table
                    if (!string.IsNullOrEmpty(oldName) &&
                        oldName != f.Name)
                    {
                        string syncHod = @"
                    UPDATE departments
                    SET    hod_name = @newName
                    WHERE  hod_name = @oldName";

                        var syncCmd = new MySqlCommand(
                            syncHod, conn, transaction);

                        syncCmd.Parameters.AddWithValue(
                            "@newName", f.Name);
                        syncCmd.Parameters.AddWithValue(
                            "@oldName", oldName);

                        syncCmd.ExecuteNonQuery();
                    }

                    // Step 5 — Commit both updates
                    // together as one atomic operation
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // If anything fails roll back
                    // both updates together
                    transaction.Rollback();
                    LogManager.LogError(ex);
                    throw;
                }
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

        // Get active faculty for ComboBox 
        public static DataTable GetAllForCombo()
        {
            string sql = @"
        SELECT emp_id,
               name
        FROM   faculty
        WHERE  is_active = 1
        ORDER  BY name ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // ── Check if faculty is HOD of any dept ───────
        public static bool IsHOD(int empId)
        {
            // Get faculty name first
            string getName = @"
        SELECT name FROM faculty
        WHERE  emp_id = @empId";

            var p = new[]
            {
        new MySqlParameter("@empId", empId)
    };

            object nameResult =
                DatabaseHelper.ExecuteScalar(
                    getName, p);

            if (nameResult == null) return false;

            string facultyName = nameResult.ToString();

            // Check if name exists as hod_name
            // in any active department
            string checkHod = @"
        SELECT COUNT(*)
        FROM   departments
        WHERE  hod_name  = @name
        AND    is_active = 1";

            var p2 = new[]
            {
        new MySqlParameter("@name", facultyName)
    };

            object result =
                DatabaseHelper.ExecuteScalar(
                    checkHod, p2);

            return Convert.ToInt32(result) > 0;
        }
    }
}