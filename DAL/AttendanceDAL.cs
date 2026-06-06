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
        /// ══════════════════════════════════════════════
        // Get all active faculty with their attendance
        // status for a given date.
        // Calls: sp_get_attendance(p_date)
        // ══════════════════════════════════════════════
        public static DataTable GetFacultyForDate(
            DateTime date)
        {
            var p = new[]
            {
        new MySqlParameter(
            "p_date",
            date.ToString("yyyy-MM-dd"))
    };

            return DatabaseHelper
                .ExecuteStoredProcedure(
                    "sp_get_attendance", p);
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
            // Resolve wa_id for this faculty
            string sqlWa = @"
        SELECT wa_id
        FROM   workload_assignments
        WHERE  emp_id = @empId
        LIMIT  1";

            var pw = new[]
            {
        new MySqlParameter("@empId", a.EmpId)
    };

            object waResult =
                DatabaseHelper.ExecuteScalar(sqlWa, pw);
            object waId = (waResult != null)
                            ? waResult
                            : (object)DBNull.Value;

            string sql = @"
        INSERT INTO attendance_records
            (wa_id,   att_date,
             slot_id, cal_id,
             status,  remarks)
        VALUES
            (@waId,  @date,
             NULL,   NULL,
             @status, @remarks)";

            var p = new[]
            {
        new MySqlParameter("@waId",    waId),
        new MySqlParameter("@date",
            a.AttDate.ToString("yyyy-MM-dd")),
        new MySqlParameter("@status",  a.Status),
        new MySqlParameter("@remarks", a.Remarks ?? "")
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
        SET    status  = @status,
               remarks = @remarks
        WHERE  ar_id   = @id";

            var p = new[]
            {
        new MySqlParameter("@status",
            a.Status),
        new MySqlParameter("@remarks",
            a.Remarks ?? ""),
        new MySqlParameter("@id",
            a.AttendanceId)
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
            // checking via workload_assignments join
            string sqlFac = @"
        SELECT f.emp_id,
               (SELECT wa.wa_id
                FROM   workload_assignments wa
                WHERE  wa.emp_id = f.emp_id
                LIMIT  1)       AS wa_id
        FROM   faculty f
        WHERE  f.is_active = 1
          AND  f.emp_id NOT IN
            (SELECT wa2.emp_id
             FROM   attendance_records ar
             JOIN   workload_assignments wa2
                 ON ar.wa_id    = wa2.wa_id
             WHERE  ar.att_date = @date)";

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
            var pars = new List<MySqlParameter[]>();

            foreach (DataRow row in dt.Rows)
            {
                queries.Add(@"
            INSERT INTO attendance_records
                (wa_id,   att_date,
                 slot_id, cal_id,
                 status,  remarks)
            VALUES
                (@waId,  @date,
                 NULL,   NULL,
                 'Present', '')");

                pars.Add(new[]
                {
            new MySqlParameter("@waId",
                row["wa_id"] == DBNull.Value
                    ? (object)DBNull.Value
                    : Convert.ToInt32(
                        row["wa_id"])),
            new MySqlParameter("@date",
                date.ToString("yyyy-MM-dd"))
        });
            }

            bool ok = DatabaseHelper
                .ExecuteTransaction(
                    queries.ToArray(),
                    pars.ToArray());

            return ok ? dt.Rows.Count : 0;
        }

        // ══════════════════════════════════════════════
        // Get single faculty attendance for a date
        // Used when role = Faculty (view only)
        // ══════════════════════════════════════════════
        public static DataTable GetFacultyOwnAttendance(int empId, DateTime date)
        {
            string sql = @"
        SELECT
            f.emp_id,
            f.name              AS faculty_name,
            d.dept_name,
            des.designation_name,
            f.emp_type,
            COALESCE(
                (SELECT ar.ar_id
                 FROM   attendance_records ar
                 JOIN   workload_assignments wa
                     ON ar.wa_id = wa.wa_id
                 WHERE  wa.emp_id   = f.emp_id
                   AND  ar.att_date = @date
                 LIMIT  1), 0
            )                   AS att_id,
            COALESCE(
                (SELECT ar.status
                 FROM   attendance_records ar
                 JOIN   workload_assignments wa
                     ON ar.wa_id = wa.wa_id
                 WHERE  wa.emp_id   = f.emp_id
                   AND  ar.att_date = @date
                 LIMIT  1), 'Not Marked'
            )                   AS att_status,
            COALESCE(
                (SELECT ar.remarks
                 FROM   attendance_records ar
                 JOIN   workload_assignments wa
                     ON ar.wa_id = wa.wa_id
                 WHERE  wa.emp_id   = f.emp_id
                   AND  ar.att_date = @date
                 LIMIT  1), ''
            )                   AS remarks
        FROM   faculty      f
        JOIN   departments  d
            ON f.dept_id        = d.dept_id
        JOIN   designations des
            ON f.designation_id = des.designation_id
        WHERE  f.is_active = 1
          AND  f.emp_id    = @empId";

            var p = new[]
            {
        new MySqlParameter("@empId", empId),
        new MySqlParameter("@date",
            date.ToString("yyyy-MM-dd"))
    };

            return DatabaseHelper.ExecuteQuery(sql, p);
        }
    }
}