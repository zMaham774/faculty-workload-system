using System;
using System.Collections.Generic;
using System.Data;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;
using MySql.Data.MySqlClient;

namespace FacultyWorkloadSystem.DAL
{
    public static class AttendanceDAL
    {
        // ══════════════════════════════════════════════
        // VIEW — Get faculty + their status for a date
        // Uses: vw_attendance_daily (with date param)
        // ══════════════════════════════════════════════
        public static DataTable GetFacultyForDate(
            DateTime date)
        {
            // We query the base tables directly
            // since VIEW uses CURDATE() —
            // for any date we pass a direct query
            string sql = @"
                SELECT
                    f.emp_id,
                    f.name              AS faculty_name,
                    f.emp_type,
                    d.dept_name,
                    des.designation_name,
                    COALESCE(
                        (SELECT ar.attendance_id
                         FROM   attendance_records ar
                         WHERE  ar.emp_id   = f.emp_id
                           AND  ar.att_date = @date
                         LIMIT  1), 0
                    )                   AS att_id,
                    COALESCE(
                        (SELECT ar.status
                         FROM   attendance_records ar
                         WHERE  ar.emp_id   = f.emp_id
                           AND  ar.att_date = @date
                         LIMIT  1), 'Not Marked'
                    )                   AS att_status,
                    COALESCE(
                        (SELECT ar.remarks
                         FROM   attendance_records ar
                         WHERE  ar.emp_id   = f.emp_id
                           AND  ar.att_date = @date
                         LIMIT  1), ''
                    )                   AS remarks
                FROM   faculty      f
                JOIN   departments  d
                    ON f.dept_id        = d.dept_id
                JOIN   designations des
                    ON f.designation_id =
                       des.designation_id
                WHERE  f.is_active = 1
                ORDER  BY d.dept_name ASC,
                          f.name      ASC";

            var p = new[]
            {
                new MySqlParameter(
                    "@date",
                    date.ToString("yyyy-MM-dd"))
            };

            return DatabaseHelper.ExecuteQuery(sql, p);
        }

        // ══════════════════════════════════════════════
        // Check if date is a teaching day
        // ══════════════════════════════════════════════
        public static bool IsWorkingDay(
            DateTime date)
        {
            // Weekend check
            if (date.DayOfWeek == DayOfWeek.Saturday
             || date.DayOfWeek == DayOfWeek.Sunday)
                return false;

            // Academic calendar check
            try
            {
                string sql = @"
                    SELECT COUNT(*)
                    FROM   academic_calendar
                    WHERE  event_date  = @date
                      AND  is_teaching = 0";

                var p = new[]
                {
                    new MySqlParameter(
                        "@date",
                        date.ToString("yyyy-MM-dd"))
                };

                object r =
                    DatabaseHelper
                    .ExecuteScalar(sql, p);

                if (Convert.ToInt32(r) > 0)
                    return false;
            }
            catch
            {
                // If academic_calendar is empty
                // or table issue — still allow marking
                // because semester may not have events
            }

            return true;
        }

        // ══════════════════════════════════════════════
        // Get block reason for non-working day
        // ══════════════════════════════════════════════
        public static string GetBlockReason(
            DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday)
                return "Saturday — weekend, " +
                       "no attendance.";

            if (date.DayOfWeek == DayOfWeek.Sunday)
                return "Sunday — weekend, " +
                       "no attendance.";

            try
            {
                string sql = @"
                    SELECT event_name, event_type
                    FROM   academic_calendar
                    WHERE  event_date  = @date
                      AND  is_teaching = 0
                    LIMIT  1";

                var p = new[]
                {
                    new MySqlParameter(
                        "@date",
                        date.ToString("yyyy-MM-dd"))
                };

                DataTable dt =
                    DatabaseHelper.ExecuteQuery(sql, p);

                if (dt.Rows.Count > 0)
                    return dt.Rows[0]["event_type"]
                               .ToString() +
                           " — " +
                           dt.Rows[0]["event_name"]
                               .ToString();
            }
            catch { }

            return "Non-working day.";
        }

        // ══════════════════════════════════════════════
        // Insert single attendance record
        // ══════════════════════════════════════════════
        public static bool Insert(Attendance a)
        {
            string sql = @"
                INSERT INTO attendance_records
                    (emp_id,    att_date,
                     status,    remarks,
                     marked_by, marked_on)
                VALUES
                    (@empId,    @date,
                     @status,   @remarks,
                     @markedBy, NOW())";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",    a.EmpId),
                new MySqlParameter(
                    "@date",
                    a.AttDate.ToString("yyyy-MM-dd")),
                new MySqlParameter(
                    "@status",   a.Status),
                new MySqlParameter(
                    "@remarks",  a.Remarks ?? ""),
                new MySqlParameter(
                    "@markedBy", a.MarkedBy)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ══════════════════════════════════════════════
        // Update existing attendance record
        // ══════════════════════════════════════════════
        public static bool Update(Attendance a)
        {
            string sql = @"
                UPDATE attendance_records
                SET    status     = @status,
                       remarks    = @remarks,
                       marked_by  = @markedBy,
                       marked_on  = NOW()
                WHERE  attendance_id = @id";

            var p = new[]
            {
                new MySqlParameter(
                    "@status",   a.Status),
                new MySqlParameter(
                    "@remarks",  a.Remarks ?? ""),
                new MySqlParameter(
                    "@markedBy", a.MarkedBy),
                new MySqlParameter(
                    "@id",       a.AttendanceId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ══════════════════════════════════════════════
        // Bulk mark all faculty Present for a date
        // ══════════════════════════════════════════════
        public static int BulkMarkPresent(
            DateTime date, int markedBy)
        {
            // Get faculty not yet marked
            string sqlFac = @"
                SELECT emp_id
                FROM   faculty
                WHERE  is_active = 1
                  AND  emp_id NOT IN
                    (SELECT emp_id
                     FROM   attendance_records
                     WHERE  att_date = @date)";

            var pf = new[]
            {
                new MySqlParameter(
                    "@date",
                    date.ToString("yyyy-MM-dd"))
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sqlFac, pf);

            if (dt.Rows.Count == 0) return 0;

            var queries = new List<string>();
            var pars =
                new List<MySqlParameter[]>();

            foreach (DataRow row in dt.Rows)
            {
                queries.Add(@"
                    INSERT INTO attendance_records
                        (emp_id,  att_date,
                         status,  remarks,
                         marked_by, marked_on)
                    VALUES
                        (@empId, @date,
                         'Present', '',
                         @markedBy, NOW())");

                pars.Add(new[]
                {
                    new MySqlParameter(
                        "@empId",
                        Convert.ToInt32(
                            row["emp_id"])),
                    new MySqlParameter(
                        "@date",
                        date.ToString("yyyy-MM-dd")),
                    new MySqlParameter(
                        "@markedBy", markedBy)
                });
            }

            bool ok = DatabaseHelper
                .ExecuteTransaction(
                    queries.ToArray(),
                    pars.ToArray());

            return ok ? dt.Rows.Count : 0;
        }
    }
}