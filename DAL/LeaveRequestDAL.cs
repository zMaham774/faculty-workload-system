using System;
using System.Collections.Generic;
using System.Data;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;
using MySql.Data.MySqlClient;

namespace FacultyWorkloadSystem.DAL
{
    public static class LeaveRequestDAL
    {
        // ── Get All (Admin/HOD sees all) ──────────────
        public static List<LeaveRequest> GetAll()
        {
            string sql = @"
                SELECT
                    lr.request_id,
                    lr.emp_id,
                    f.name          AS faculty_name,
                    d.dept_name,
                    lr.leave_type_id,
                    lt.leave_type_name,
                    lr.from_date,
                    lr.to_date,
                    lr.total_days,
                    lr.reason,
                    lr.status,
                    lr.applied_on,
                    lr.approved_by,
                    lr.approval_remarks,
                    lr.approved_on
                FROM   leave_requests  lr
                JOIN   faculty         f
                    ON lr.emp_id       = f.emp_id
                JOIN   departments     d
                    ON f.dept_id       = d.dept_id
                JOIN   leave_types     lt
                    ON lr.leave_type_id =
                       lt.leave_type_id
                ORDER  BY lr.applied_on DESC";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql);
            var list = new List<LeaveRequest>();
            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));
            return list;
        }

        // ── Get By Faculty (Faculty sees own) ─────────
        public static List<LeaveRequest>
            GetByFaculty(int empId)
        {
            string sql = @"
                SELECT
                    lr.request_id,
                    lr.emp_id,
                    f.name          AS faculty_name,
                    d.dept_name,
                    lr.leave_type_id,
                    lt.leave_type_name,
                    lr.from_date,
                    lr.to_date,
                    lr.total_days,
                    lr.reason,
                    lr.status,
                    lr.applied_on,
                    lr.approved_by,
                    lr.approval_remarks,
                    lr.approved_on
                FROM   leave_requests  lr
                JOIN   faculty         f
                    ON lr.emp_id       = f.emp_id
                JOIN   departments     d
                    ON f.dept_id       = d.dept_id
                JOIN   leave_types     lt
                    ON lr.leave_type_id =
                       lt.leave_type_id
                WHERE  lr.emp_id = @empId
                ORDER  BY lr.applied_on DESC";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId", empId)
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql, p);
            var list = new List<LeaveRequest>();
            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));
            return list;
        }

        // ── Get Pending (For approval form) ───────────
        public static List<LeaveRequest>
            GetPending()
        {
            string sql = @"
                SELECT
                    lr.request_id,
                    lr.emp_id,
                    f.name          AS faculty_name,
                    d.dept_name,
                    lr.leave_type_id,
                    lt.leave_type_name,
                    lr.from_date,
                    lr.to_date,
                    lr.total_days,
                    lr.reason,
                    lr.status,
                    lr.applied_on,
                    lr.approved_by,
                    lr.approval_remarks,
                    lr.approved_on
                FROM   leave_requests  lr
                JOIN   faculty         f
                    ON lr.emp_id       = f.emp_id
                JOIN   departments     d
                    ON f.dept_id       = d.dept_id
                JOIN   leave_types     lt
                    ON lr.leave_type_id =
                       lt.leave_type_id
                WHERE  lr.status = 'Pending'
                ORDER  BY lr.applied_on ASC";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql);
            var list = new List<LeaveRequest>();
            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));
            return list;
        }

        // ── Get By Id ─────────────────────────────────
        public static LeaveRequest GetById(int id)
        {
            string sql = @"
                SELECT
                    lr.request_id,
                    lr.emp_id,
                    f.name          AS faculty_name,
                    d.dept_name,
                    lr.leave_type_id,
                    lt.leave_type_name,
                    lr.from_date,
                    lr.to_date,
                    lr.total_days,
                    lr.reason,
                    lr.status,
                    lr.applied_on,
                    lr.approved_by,
                    lr.approval_remarks,
                    lr.approved_on
                FROM   leave_requests  lr
                JOIN   faculty         f
                    ON lr.emp_id       = f.emp_id
                JOIN   departments     d
                    ON f.dept_id       = d.dept_id
                JOIN   leave_types     lt
                    ON lr.leave_type_id =
                       lt.leave_type_id
                WHERE  lr.request_id = @id";

            var p = new[]
            {
                new MySqlParameter("@id", id)
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql, p);
            return dt.Rows.Count == 0
                ? null : Map(dt.Rows[0]);
        }

        // ── Insert (Apply leave) ───────────────────────
        public static bool Insert(LeaveRequest lr)
        {
            string sql = @"
                INSERT INTO leave_requests
                    (emp_id, leave_type_id,
                     from_date, to_date,
                     total_days, reason,
                     status, applied_on)
                VALUES
                    (@empId, @typeId,
                     @from, @to,
                     @days, @reason,
                     'Pending', NOW())";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId",  lr.EmpId),
                new MySqlParameter(
                    "@typeId", lr.LeaveTypeId),
                new MySqlParameter(
                    "@from",
                    lr.FromDate
                    .ToString("yyyy-MM-dd")),
                new MySqlParameter(
                    "@to",
                    lr.ToDate
                    .ToString("yyyy-MM-dd")),
                new MySqlParameter(
                    "@days",   lr.TotalDays),
                new MySqlParameter(
                    "@reason", lr.Reason)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Delete (Only Pending can be deleted) ───────
        public static bool Delete(int id)
        {
            string sql = @"
                DELETE FROM leave_requests
                WHERE  request_id = @id
                  AND  status     = 'Pending'";

            var p = new[]
            {
                new MySqlParameter("@id", id)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Approve ───────────────────────────────────
        public static bool Approve(
            int requestId,
            int approvedBy,
            string remarks)
        {
            string sql = @"
                UPDATE leave_requests
                SET    status          = 'Approved',
                       approved_by     = @by,
                       approval_remarks = @remarks,
                       approved_on     = NOW()
                WHERE  request_id      = @id
                  AND  status          = 'Pending'";

            var p = new[]
            {
                new MySqlParameter(
                    "@by",      approvedBy),
                new MySqlParameter(
                    "@remarks", remarks ?? ""),
                new MySqlParameter(
                    "@id",      requestId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Reject ────────────────────────────────────
        public static bool Reject(
            int requestId,
            int rejectedBy,
            string remarks)
        {
            string sql = @"
                UPDATE leave_requests
                SET    status          = 'Rejected',
                       approved_by     = @by,
                       approval_remarks = @remarks,
                       approved_on     = NOW()
                WHERE  request_id      = @id
                  AND  status          = 'Pending'";

            var p = new[]
            {
                new MySqlParameter(
                    "@by",      rejectedBy),
                new MySqlParameter(
                    "@remarks", remarks ?? ""),
                new MySqlParameter(
                    "@id",      requestId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Check overlapping leave ────────────────────
        public static bool HasOverlap(
            int empId,
            DateTime from,
            DateTime to,
            int excludeId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   leave_requests
                WHERE  emp_id     = @empId
                  AND  status    != 'Rejected'
                  AND  request_id != @ex
                  AND  (
                      from_date BETWEEN
                          @from AND @to
                   OR  to_date   BETWEEN
                          @from AND @to
                   OR  (@from BETWEEN
                          from_date AND to_date)
                  )";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId", empId),
                new MySqlParameter(
                    "@from",
                    from.ToString("yyyy-MM-dd")),
                new MySqlParameter(
                    "@to",
                    to.ToString("yyyy-MM-dd")),
                new MySqlParameter(
                    "@ex",    excludeId)
            };

            object r =
                DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(r) > 0;
        }

        // ── Get leave types for combo ──────────────────
        public static DataTable GetLeaveTypesForCombo()
        {
            string sql = @"
        SELECT lt_id   AS leave_type_id,
               lt_name AS leave_type_name
        FROM   leave_types
        ORDER  BY lt_name ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }
        // ── Get balance for faculty ────────────────────
        public static DataTable GetBalance(
            int empId, int year)
        {
            string sql = @"
                SELECT
                    lt.leave_type_name,
                    COALESCE(lb.total_allowed,
                        lt.max_days_per_year)
                        AS total_allowed,
                    COALESCE(lb.days_taken, 0)
                        AS days_taken,
                    COALESCE(lb.days_remaining,
                        lt.max_days_per_year)
                        AS days_remaining
                FROM   leave_types     lt
                LEFT   JOIN leave_balances lb
                    ON lb.leave_type_id =
                       lt.leave_type_id
                   AND lb.emp_id  = @empId
                   AND lb.year    = @year
                ORDER  BY lt.leave_type_name ASC";

            var p = new[]
            {
                new MySqlParameter(
                    "@empId", empId),
                new MySqlParameter(
                    "@year",  year)
            };

            return DatabaseHelper.ExecuteQuery(sql, p);
        }

        // ── Calculate working days ─────────────────────
        public static int CalcWorkingDays(
            DateTime from, DateTime to)
        {
            int days = 0;
            for (DateTime d = from;
                 d <= to;
                 d = d.AddDays(1))
            {
                if (d.DayOfWeek !=
                    DayOfWeek.Saturday &&
                    d.DayOfWeek !=
                    DayOfWeek.Sunday)
                    days++;
            }
            return days;
        }

        // ── Search ────────────────────────────────────
        public static List<LeaveRequest> Search(
            string keyword)
        {
            string sql = @"
                SELECT
                    lr.request_id,
                    lr.emp_id,
                    f.name          AS faculty_name,
                    d.dept_name,
                    lr.leave_type_id,
                    lt.leave_type_name,
                    lr.from_date,
                    lr.to_date,
                    lr.total_days,
                    lr.reason,
                    lr.status,
                    lr.applied_on,
                    lr.approved_by,
                    lr.approval_remarks,
                    lr.approved_on
                FROM   leave_requests  lr
                JOIN   faculty         f
                    ON lr.emp_id       = f.emp_id
                JOIN   departments     d
                    ON f.dept_id       = d.dept_id
                JOIN   leave_types     lt
                    ON lr.leave_type_id =
                       lt.leave_type_id
                WHERE  f.name          LIKE @kw
                    OR lt.leave_type_name LIKE @kw
                    OR lr.status       LIKE @kw
                ORDER  BY lr.applied_on DESC";

            var p = new[]
            {
                new MySqlParameter(
                    "@kw", "%" + keyword + "%")
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql, p);
            var list = new List<LeaveRequest>();
            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));
            return list;
        }

        // ── Private mapper ─────────────────────────────
        private static LeaveRequest Map(DataRow row)
        {
            return new LeaveRequest
            {
                RequestId =
                    Convert.ToInt32(
                        row["request_id"]),
                EmpId =
                    Convert.ToInt32(row["emp_id"]),
                FacultyName =
                    row["faculty_name"].ToString(),
                DeptName =
                    row["dept_name"].ToString(),
                LeaveTypeId =
                    Convert.ToInt32(
                        row["leave_type_id"]),
                LeaveTypeName =
                    row["leave_type_name"].ToString(),
                FromDate =
                    Convert.ToDateTime(
                        row["from_date"]),
                ToDate =
                    Convert.ToDateTime(
                        row["to_date"]),
                TotalDays =
                    Convert.ToInt32(
                        row["total_days"]),
                Reason =
                    row["reason"].ToString(),
                Status =
                    row["status"].ToString(),
                AppliedOn =
                    Convert.ToDateTime(
                        row["applied_on"]),
                ApprovedBy =
                    row["approved_by"] ==
                    DBNull.Value
                    ? (int?)null
                    : Convert.ToInt32(
                        row["approved_by"]),
                ApprovalRemarks =
                    row["approval_remarks"]
                    == DBNull.Value
                    ? ""
                    : row["approval_remarks"]
                      .ToString(),
                ApprovedOn =
                    row["approved_on"] ==
                    DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(
                        row["approved_on"])
            };
        }
    }
}