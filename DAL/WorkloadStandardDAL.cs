using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.DAL
{
    public static class WorkloadStandardDAL
    {
        // Get All 
        public static List<WorkloadStandard> GetAll()
        {
            string sql = @"
                SELECT   ws.ws_id,
                         ws.dept_id,
                         d.dept_name,
                         ws.sem_id,
                         s.sem_name,
                         ws.min_hours,
                         ws.max_hours,
                         ws.std_hours
                FROM     workload_standards ws
                JOIN     departments d
                      ON ws.dept_id = d.dept_id
                JOIN     semesters   s
                      ON ws.sem_id  = s.sem_id
                ORDER BY ws.ws_id ASC";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            return MapToList(dt);
        }

        // Get By ID 
        public static WorkloadStandard GetById(int wsId)
        {
            string sql = @"
                SELECT   ws.ws_id,
                         ws.dept_id,
                         d.dept_name,
                         ws.sem_id,
                         s.sem_name,
                         ws.min_hours,
                         ws.max_hours,
                         ws.std_hours
                FROM     workload_standards ws
                JOIN     departments d
                      ON ws.dept_id = d.dept_id
                JOIN     semesters   s
                      ON ws.sem_id  = s.sem_id
                WHERE    ws.ws_id   = @wsId";

            var p = new[]
            {
                new MySqlParameter("@wsId", wsId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);

            return dt.Rows.Count == 0
                ? null
                : MapToObject(dt.Rows[0]);
        }

        // Search 
        public static List<WorkloadStandard> Search(string keyword)
        {
            string sql = @"
                SELECT   ws.ws_id,
                         ws.dept_id,
                         d.dept_name,
                         ws.sem_id,
                         s.sem_name,
                         ws.min_hours,
                         ws.max_hours,
                         ws.std_hours
                FROM     workload_standards ws
                JOIN     departments d
                      ON ws.dept_id = d.dept_id
                JOIN     semesters   s
                      ON ws.sem_id  = s.sem_id
                WHERE    d.dept_name LIKE @kw
                OR       s.sem_name  LIKE @kw
                ORDER BY ws.ws_id ASC";

            var p = new[]
            {
                new MySqlParameter(
                    "@kw", "%" + keyword + "%")
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            return MapToList(dt);
        }

        // Insert 
        public static bool Insert(WorkloadStandard ws)
        {
            string sql = @"
                INSERT INTO workload_standards
                    (dept_id,   sem_id,
                     min_hours, max_hours,
                     std_hours)
                VALUES
                    (@deptId,   @semId,
                     @minHours, @maxHours,
                     @stdHours)";

            var p = new[]
            {
                new MySqlParameter(
                    "@deptId",   ws.DeptId),
                new MySqlParameter(
                    "@semId",    ws.SemId),
                new MySqlParameter(
                    "@minHours", ws.MinHours),
                new MySqlParameter(
                    "@maxHours", ws.MaxHours),
                new MySqlParameter(
                    "@stdHours", ws.StdHours)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Update 
        public static bool Update(WorkloadStandard ws)
        {
            string sql = @"
                UPDATE workload_standards
                SET    dept_id   = @deptId,
                       sem_id    = @semId,
                       min_hours = @minHours,
                       max_hours = @maxHours,
                       std_hours = @stdHours
                WHERE  ws_id     = @wsId";

            var p = new[]
            {
                new MySqlParameter(
                    "@deptId",   ws.DeptId),
                new MySqlParameter(
                    "@semId",    ws.SemId),
                new MySqlParameter(
                    "@minHours", ws.MinHours),
                new MySqlParameter(
                    "@maxHours", ws.MaxHours),
                new MySqlParameter(
                    "@stdHours", ws.StdHours),
                new MySqlParameter(
                    "@wsId",     ws.WsId)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Delete 
        public static bool Delete(int wsId)
        {
            string sql = @"
                DELETE FROM workload_standards
                WHERE  ws_id = @wsId";

            var p = new[]
            {
                new MySqlParameter("@wsId", wsId)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Check duplicate dept+sem combo 
        public static bool Exists(
            int deptId,
            int semId,
            int excludeId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   workload_standards
                WHERE  dept_id = @deptId
                AND    sem_id  = @semId
                AND    ws_id  != @excludeId";

            var p = new[]
            {
                new MySqlParameter(
                    "@deptId",    deptId),
                new MySqlParameter(
                    "@semId",     semId),
                new MySqlParameter(
                    "@excludeId", excludeId)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Get for specific dept+sem
        public static WorkloadStandard GetByDeptAndSem(int deptId, int semId)
        {
            string sql = @"
                SELECT   ws.ws_id,
                         ws.dept_id,
                         d.dept_name,
                         ws.sem_id,
                         s.sem_name,
                         ws.min_hours,
                         ws.max_hours,
                         ws.std_hours
                FROM     workload_standards ws
                JOIN     departments d
                      ON ws.dept_id = d.dept_id
                JOIN     semesters   s
                      ON ws.sem_id  = s.sem_id
                WHERE    ws.dept_id = @deptId
                AND      ws.sem_id  = @semId";

            var p = new[]
            {
                new MySqlParameter(
                    "@deptId", deptId),
                new MySqlParameter(
                    "@semId",  semId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);

            return dt.Rows.Count == 0
                ? null
                : MapToObject(dt.Rows[0]);
        }

        // Map DataTable to List 
        private static List<WorkloadStandard> MapToList(DataTable dt)
        {
            var list =
                new List<WorkloadStandard>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToObject(row));
            return list;
        }

        // Map DataRow to WorkloadStandard
        private static WorkloadStandard
            MapToObject(DataRow row)
        {
            return new WorkloadStandard(
                Convert.ToInt32(row["ws_id"]),
                Convert.ToInt32(row["dept_id"]),
                row["dept_name"].ToString(),
                Convert.ToInt32(row["sem_id"]),
                row["sem_name"].ToString(),
                Convert.ToInt32(row["min_hours"]),
                Convert.ToInt32(row["max_hours"]),
                Convert.ToInt32(row["std_hours"])
            );
        }
    }
}