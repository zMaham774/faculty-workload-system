using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.DAL
{
    public static class WorkloadAssignmentDAL
    {
        // Get All via VIEW 
        // vw_faculty_workload only shows
        // current semester assignments
        public static List<WorkloadAssignment> GetCurrentSemester()
        {
            string sql = @"
                SELECT wa_id,
                       emp_id,
                       faculty_name,
                       course_id,
                       course_title,
                       course_code,
                       credit_hours,
                       dept_name,
                       sem_id,
                       sem_name,
                       total_hours,
                       status,
                       assigned_date
                FROM   vw_faculty_workload
                ORDER  BY faculty_name ASC,
                          course_title ASC";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            return MapToList(dt);
        }

        // Get All with filters 
        public static List<WorkloadAssignment> GetFiltered(int semId = 0, int deptId = 0)
        {
            string sql = @"
                SELECT   wa.wa_id,
                         f.emp_id,
                         f.name       AS faculty_name,
                         c.course_id,
                         c.title      AS course_title,
                         c.course_code,
                         c.credit_hours,
                         d.dept_name,
                         s.sem_id,
                         s.sem_name,
                         wa.total_hours,
                         wa.status,
                         wa.assigned_date
                FROM     workload_assignments wa
                JOIN     faculty     f
                      ON wa.emp_id    = f.emp_id
                JOIN     courses     c
                      ON wa.course_id = c.course_id
                JOIN     semesters   s
                      ON wa.sem_id    = s.sem_id
                JOIN     departments d
                      ON f.dept_id    = d.dept_id
                WHERE    (@semId  = 0
                          OR wa.sem_id  = @semId)
                AND      (@deptId = 0
                          OR f.dept_id = @deptId)
                ORDER BY f.name ASC,
                         c.title ASC";

            var p = new[]
            {
                new MySqlParameter("@semId",  semId),
                new MySqlParameter("@deptId", deptId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            return MapToList(dt);
        }

        //  Get By ID 
        public static WorkloadAssignment GetById(int waId)
        {
            string sql = @"
                SELECT   wa.wa_id,
                         f.emp_id,
                         f.name       AS faculty_name,
                         c.course_id,
                         c.title      AS course_title,
                         c.course_code,
                         c.credit_hours,
                         d.dept_name,
                         s.sem_id,
                         s.sem_name,
                         wa.total_hours,
                         wa.status,
                         wa.assigned_date
                FROM     workload_assignments wa
                JOIN     faculty     f
                      ON wa.emp_id    = f.emp_id
                JOIN     courses     c
                      ON wa.course_id = c.course_id
                JOIN     semesters   s
                      ON wa.sem_id    = s.sem_id
                JOIN     departments d
                      ON f.dept_id    = d.dept_id
                WHERE    wa.wa_id     = @waId";

            var p = new[]
            {
                new MySqlParameter("@waId", waId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);

            return dt.Rows.Count == 0
                ? null
                : MapToObject(dt.Rows[0]);
        }

        // Insert 
        public static bool Insert(WorkloadAssignment wa)
        {
            string sql = @"
                INSERT INTO workload_assignments
                    (emp_id,       course_id,
                     sem_id,       total_hours,
                     status,       assigned_date)
                VALUES
                    (@empId,       @courseId,
                     @semId,       @totalHours,
                     @status,      @assignedDate)";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",       wa.EmpId),
                new MySqlParameter(
                    "@courseId",    wa.CourseId),
                new MySqlParameter(
                    "@semId",       wa.SemId),
                new MySqlParameter(
                    "@totalHours",  wa.TotalHours),
                new MySqlParameter(
                    "@status",      wa.Status),
                new MySqlParameter(
                    "@assignedDate",
                    wa.AssignedDate.Date)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Update status and hours only
        public static bool Update(WorkloadAssignment wa)
        {
            string sql = @"
                UPDATE workload_assignments
                SET    total_hours   = @totalHours,
                       status        = @status,
                       assigned_date = @assignedDate
                WHERE  wa_id         = @waId";

            var p = new[]
            {
                new MySqlParameter(
                    "@totalHours",
                    wa.TotalHours),
                new MySqlParameter(
                    "@status",
                    wa.Status),
                new MySqlParameter(
                    "@assignedDate",
                    wa.AssignedDate.Date),
                new MySqlParameter(
                    "@waId", wa.WaId)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // ── Reassign course via TRANSACTION ───────────
        // UPDATE workload_assignments emp_id
        // INSERT course_reassignment_log
        // Both succeed or both rollback
        public static bool Reassign(int waId, int fromEmpId, int toEmpId, int courseId, int semId, string reason)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Step 1 — Update assignment
                    // to new faculty member
                    string updateSql = @"
                        UPDATE workload_assignments
                        SET    emp_id = @toEmpId
                        WHERE  wa_id  = @waId";

                    var updateCmd =
                        new MySqlCommand(
                            updateSql, conn,
                            transaction);

                    updateCmd.Parameters
                        .AddWithValue(
                            "@toEmpId", toEmpId);
                    updateCmd.Parameters
                        .AddWithValue(
                            "@waId", waId);

                    updateCmd.ExecuteNonQuery();

                    // Step 2 — Log the reassignment
                    string logSql = @"
                        INSERT INTO
                            course_reassignment_log
                            (course_id,
                             sem_id,
                             from_emp_id,
                             to_emp_id,
                             reason,
                             reassigned_on,
                             reassigned_by)
                        VALUES
                            (@courseId,
                             @semId,
                             @fromEmpId,
                             @toEmpId,
                             @reason,
                             NOW(),
                             @reassignedBy)";

                    var logCmd =
                        new MySqlCommand(
                            logSql, conn,
                            transaction);

                    logCmd.Parameters
                        .AddWithValue(
                            "@courseId",
                            courseId);
                    logCmd.Parameters
                        .AddWithValue(
                            "@semId",
                            semId);
                    logCmd.Parameters
                        .AddWithValue(
                            "@fromEmpId",
                            fromEmpId);
                    logCmd.Parameters
                        .AddWithValue(
                            "@toEmpId",
                            toEmpId);
                    logCmd.Parameters
                        .AddWithValue(
                            "@reason",
                            string.IsNullOrEmpty(
                                reason)
                            ? (object)DBNull.Value
                            : reason);
                    logCmd.Parameters
                        .AddWithValue(
                            "@reassignedBy",
                            SessionManager.UserId);

                    logCmd.ExecuteNonQuery();

                    // Step 3 — Commit both together
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback both if anything fails
                    transaction.Rollback();
                    LogManager.LogError(ex);
                    throw;
                }
            }
        }

        // Delete 
        public static bool Delete(int waId)
        {
            string sql = @"
                DELETE FROM workload_assignments
                WHERE  wa_id = @waId";

            var p = new[]
            {
                new MySqlParameter("@waId", waId)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Check duplicate assignment
        public static bool Exists(int empId, int courseId, int semId, int excludeId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   workload_assignments
                WHERE  emp_id    = @empId
                AND    course_id = @courseId
                AND    sem_id    = @semId
                AND    wa_id    != @excludeId";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",     empId),
                new MySqlParameter(
                    "@courseId",  courseId),
                new MySqlParameter(
                    "@semId",     semId),
                new MySqlParameter(
                    "@excludeId", excludeId)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Check workload against standards 
        // Returns total hours already assigned
        // to faculty in a semester
        public static decimal GetTotalHoursForFaculty(int empId, int semId, int excludeWaId = 0)
        {
            string sql = @"
                SELECT COALESCE(
                           SUM(total_hours), 0)
                FROM   workload_assignments
                WHERE  emp_id  = @empId
                AND    sem_id  = @semId
                AND    wa_id  != @excludeId
                AND    status  = 'Active'";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",     empId),
                new MySqlParameter(
                    "@semId",     semId),
                new MySqlParameter(
                    "@excludeId", excludeWaId)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToDecimal(result);
        }

        // Has timetable or attendance 
        public static bool HasRelatedData(int waId)
        {
            string sql = @"
                SELECT (
                    SELECT COUNT(*)
                    FROM   timetable
                    WHERE  wa_id = @waId
                ) + (
                    SELECT COUNT(*)
                    FROM   attendance_records
                    WHERE  wa_id = @waId
                ) AS total";

            var p = new[]
            {
                new MySqlParameter("@waId", waId)
            };

            object result =
                DatabaseHelper.ExecuteScalar(
                    sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Map DataTable to List 
        private static List<WorkloadAssignment> MapToList(DataTable dt)
        {
            var list =  new List<WorkloadAssignment>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToObject(row));
            return list;
        }

        // Map DataRow to WorkloadAssignment 
        private static WorkloadAssignment MapToObject(DataRow row)
        {
            return new WorkloadAssignment(
                Convert.ToInt32(row["wa_id"]),
                Convert.ToInt32(row["emp_id"]),
                row["faculty_name"].ToString(),
                Convert.ToInt32(row["course_id"]),
                row["course_title"].ToString(),
                row["course_code"].ToString(),
                Convert.ToInt32(
                    row["credit_hours"]),
                row["dept_name"].ToString(),
                Convert.ToInt32(row["sem_id"]),
                row["sem_name"].ToString(),
                Convert.ToDecimal(
                    row["total_hours"]),
                row["status"].ToString(),
                Convert.ToDateTime(
                    row["assigned_date"])
            );
        }
    }
}