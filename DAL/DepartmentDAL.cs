using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.DAL
{
    public class DepartmentDAL
    {
        // Get all departments
        public static List<Department> GetAll()
        {
            string query = @"SELECT dept_id, dept_name, 
                                    hod_name, contact, 
                                    email, is_active
                             FROM   departments
                             ORDER  BY dept_id ASC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            return MapToList(dt);
        }

        // Get active departments only 
        public static List<Department> GetAllActive()
        {
            string query = @"SELECT dept_id, dept_name,
                                    hod_name, contact,
                                    email, is_active
                             FROM   departments
                             WHERE  is_active = 1
                             ORDER  BY dept_name";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            return MapToList(dt);
        }

        //  Get single department by ID 
        public static Department GetById(int deptId)
        {
            string query = @"SELECT dept_id, dept_name,
                                    hod_name, contact,
                                    email, is_active
                             FROM   departments
                             WHERE  dept_id = @deptId";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@deptId", deptId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 1)
                return MapToObject(dt.Rows[0]);

            return null;
        }

        // Search departments by name 
        public static List<Department> Search(string keyword)
        {
            string query = @"SELECT dept_id, dept_name,
                                    hod_name, contact,
                                    email, is_active
                             FROM   departments
                             WHERE  dept_name LIKE @keyword
                             OR     hod_name  LIKE @keyword
                             ORDER  BY dept_name";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@keyword", "%" + keyword + "%")
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return MapToList(dt);
        }

        // Insert new department 
        public static bool Insert(Department dept)
        {
            string query = @"INSERT INTO departments
                                (dept_name, hod_name,
                                 contact, email, is_active)
                             VALUES
                                (@deptName, @hodName,
                                 @contact, @email, @isActive)";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@deptName", dept.DeptName),
                new MySqlParameter("@hodName",
                    string.IsNullOrEmpty(dept.HodName)
                    ? (object)DBNull.Value : dept.HodName),
                new MySqlParameter("@contact",
                    string.IsNullOrEmpty(dept.Contact)
                    ? (object)DBNull.Value : dept.Contact),
                new MySqlParameter("@email",
                    string.IsNullOrEmpty(dept.Email)
                    ? (object)DBNull.Value : dept.Email),
                new MySqlParameter("@isActive", dept.IsActive ? 1 : 0)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        //  Update existing department 
        public static bool Update(Department dept)
        {
            string query = @"UPDATE departments
                             SET    dept_name = @deptName,
                                    hod_name  = @hodName,
                                    contact   = @contact,
                                    email     = @email,
                                    is_active = @isActive
                             WHERE  dept_id   = @deptId";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@deptName", dept.DeptName),
                new MySqlParameter("@hodName",
                    string.IsNullOrEmpty(dept.HodName)
                    ? (object)DBNull.Value : dept.HodName),
                new MySqlParameter("@contact",
                    string.IsNullOrEmpty(dept.Contact)
                    ? (object)DBNull.Value : dept.Contact),
                new MySqlParameter("@email",
                    string.IsNullOrEmpty(dept.Email)
                    ? (object)DBNull.Value : dept.Email),
                new MySqlParameter("@isActive", dept.IsActive ? 1 : 0),
                new MySqlParameter("@deptId",   dept.DeptId)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        //  Delete department 
        public static bool Delete(int deptId)
        {
            string query = @"DELETE FROM departments
                             WHERE  dept_id = @deptId";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@deptId", deptId)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // Check if name already exists (for validation) 
        public static bool NameExists(string deptName,
                                      int excludeId = 0)
        {
            string query = @"SELECT COUNT(*) FROM departments
                             WHERE  dept_name = @deptName
                             AND    dept_id  != @excludeId";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@deptName",  deptName),
                new MySqlParameter("@excludeId", excludeId)
            };

            object result = DatabaseHelper.ExecuteScalar(
                                query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        // Check if dept has faculty (before delete)
        public static bool HasFaculty(int deptId)
        {
            string query = @"SELECT COUNT(*) FROM faculty
                             WHERE  dept_id = @deptId";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@deptId", deptId)
            };

            object result = DatabaseHelper.ExecuteScalar(
                                query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        //  Map DataTable to List<Department> 
        private static List<Department> MapToList(DataTable dt)
        {
            List<Department> list = new List<Department>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToObject(row));
            return list;
        }

        //  Map single DataRow to Department object 
        private static Department MapToObject(DataRow row)
        {
            return new Department(
                Convert.ToInt32(row["dept_id"]),
                row["dept_name"].ToString(),
                row["hod_name"] == DBNull.Value
                    ? "" : row["hod_name"].ToString(),
                row["contact"] == DBNull.Value
                    ? "" : row["contact"].ToString(),
                row["email"] == DBNull.Value
                    ? "" : row["email"].ToString(),
                Convert.ToBoolean(row["is_active"])
            );
        }

        // Get All for ComboBox 
        public static DataTable GetAllForCombo()
        {
            string sql = @"
        SELECT dept_id,
               dept_name
        FROM   departments
        WHERE  is_active = 1
        ORDER  BY dept_name ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }
     
    }
}