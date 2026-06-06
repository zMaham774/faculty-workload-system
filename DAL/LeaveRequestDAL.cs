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
        public static List<LeaveRequest> GetAll(string userRole, int loggedInEmpId)
        {
            string sql = @"
        SELECT lr_id, emp_id,
               faculty_name, dept_name,
               leave_type_name,
               start_date, end_date,
               total_days, reason, status,
               approval_remarks, applied_on,
               approved_by
        FROM   vw_leave_requests 
        WHERE  1 = 1"; // Base filter to dynamically append conditions

            var pList = new List<MySqlParameter>();

            // If HOD, exclude their own records from the retrieved log
            if (userRole == "HOD")
            {
                sql += " AND emp_id != @loggedInEmpId";
                pList.Add(new MySqlParameter("@loggedInEmpId", loggedInEmpId));
            }

            sql += " ORDER BY applied_on DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, pList.ToArray());
            var list = new List<LeaveRequest>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapFromView(row));
            return list;
        }

        // ── Get By Faculty (Faculty sees own) ─────────
        public static List<LeaveRequest> GetByFaculty(int empId)
        {
            string sql = @"
        SELECT lr_id, emp_id,
               faculty_name, dept_name,
               leave_type_name,
               start_date, end_date,
               total_days, reason, status,
               approval_remarks, applied_on,
               approved_by
        FROM   vw_leave_requests
        WHERE  emp_id = @empId
        ORDER  BY applied_on DESC";

            var p = new[]
            {
        new MySqlParameter("@empId", empId)
    };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            var list = new List<LeaveRequest>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapFromView(row));
            return list;
        }

        // ── Get Pending (For approval form) ───────────
        public static List<LeaveRequest> GetPending(string userRole, int loggedInEmpId)
        {
            string sql = @"
        SELECT lr_id, emp_id,
               faculty_name, dept_name,
               leave_type_name,
               start_date, end_date,
               total_days, reason, status,
               approval_remarks, applied_on,
               approved_by
        FROM   vw_leave_requests
        WHERE  status = 'Pending'";

            var pList = new List<MySqlParameter>();

            // Restrict HOD from seeing or approving their own leave request
            if (userRole == "HOD")
            {
                sql += " AND emp_id != @loggedInEmpId";
                pList.Add(new MySqlParameter("@loggedInEmpId", loggedInEmpId));
            }

            sql += " ORDER BY applied_on ASC";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, pList.ToArray());
            var list = new List<LeaveRequest>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapFromView(row));
            return list;
        }


        // ── Get By Id ─────────────────────────────────
        public static LeaveRequest GetById(int id)
        {
            string sql = @"
        SELECT lr_id, emp_id,
               faculty_name, dept_name,
               leave_type_name,
               start_date, end_date,
               total_days, reason, status,
               approval_remarks, applied_on,
               approved_by
        FROM   vw_leave_requests
        WHERE  lr_id = @id";

            var p = new[]
            {
        new MySqlParameter("@id", id)
    };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            return dt.Rows.Count == 0
                ? null : MapFromView(dt.Rows[0]);
        }

        // ── Insert (Apply leave) ───────────────────────
        public static bool Insert(LeaveRequest lr)
        {
            string sql = @"
        INSERT INTO leave_requests
            (emp_id,     lt_id,
             start_date, end_date,
             reason,     appr_status,
             submitted_on)
        VALUES
            (@empId,    @typeId,
             @from,     @to,
             @reason,   'Pending',
             NOW())";

            var p = new[]
            {
        new MySqlParameter("@empId",  lr.EmpId),
        new MySqlParameter("@typeId", lr.LeaveTypeId),
        new MySqlParameter("@from",
            lr.FromDate.ToString("yyyy-MM-dd")),
        new MySqlParameter("@to",
            lr.ToDate.ToString("yyyy-MM-dd")),
        new MySqlParameter("@reason", lr.Reason)
    };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // ── Delete (Only Pending can be deleted) ───────
        public static bool Delete(int id)
        {
            string sql = @"
        DELETE FROM leave_requests
        WHERE  lr_id       = @id
          AND  appr_status = 'Pending'";

            var p = new[]
            {
        new MySqlParameter("@id", id)
    };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // ── Approve ───────────────────────────────────
        public static bool Approve(
    int requestId,
    string remarks,
    int approvedBy)
        {
            string sql = @"
        UPDATE leave_requests
        SET    appr_status  = 'Approved',
               appr_remarks = @remarks,
               approved_by  = @by
        WHERE  lr_id        = @id
          AND  appr_status  = 'Pending'";

            var p = new[]
            {
        new MySqlParameter("@remarks", remarks ?? ""),
        new MySqlParameter("@by",      approvedBy),
        new MySqlParameter("@id",      requestId)
    };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // ── Reject ────────────────────────────────────
        public static bool Reject(
    int requestId,
    string remarks,
    int rejectedBy)
        {
            string sql = @"
        UPDATE leave_requests
        SET    appr_status  = 'Rejected',
               appr_remarks = @remarks,
               approved_by  = @by
        WHERE  lr_id        = @id
          AND  appr_status  = 'Pending'";

            var p = new[]
            {
        new MySqlParameter("@remarks", remarks ?? ""),
        new MySqlParameter("@by",      rejectedBy),
        new MySqlParameter("@id",      requestId)
    };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // ── Check overlapping leave ────────────────────
        public static bool HasOverlap(
    int empId, DateTime from,
    DateTime to, int excludeId = 0)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM   leave_requests
        WHERE  emp_id      = @empId
          AND  appr_status != 'Rejected'
          AND  lr_id       != @ex
          AND  (
              start_date BETWEEN @from AND @to
           OR end_date   BETWEEN @from AND @to
           OR (@from BETWEEN start_date AND end_date)
          )";

            var p = new[]
            {
        new MySqlParameter("@empId", empId),
        new MySqlParameter("@from",
            from.ToString("yyyy-MM-dd")),
        new MySqlParameter("@to",
            to.ToString("yyyy-MM-dd")),
        new MySqlParameter("@ex", excludeId)
    };

            object r = DatabaseHelper.ExecuteScalar(sql, p);
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
        public static DataTable GetBalance(int empId, int year)
        {
            string sql = @"
        SELECT
            lt.lt_name          AS leave_type_name,
            COALESCE(
                lb.total_entitled,
                lt.default_entitlement)
                                AS total_allowed,
            COALESCE(
                lb.total_entitled -
                lb.balance_remaining, 0)
                                AS days_taken,
            COALESCE(
                lb.balance_remaining,
                lt.default_entitlement)
                                AS days_remaining
        FROM   leave_types     lt
        LEFT   JOIN leave_balances lb
            ON lb.lt_id    = lt.lt_id
           AND lb.emp_id   = @empId
           AND lb.acad_year = @year
        ORDER  BY lt.lt_name ASC";

            var p = new[]
            {
        new MySqlParameter("@empId", empId),
        new MySqlParameter("@year",  year.ToString())
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
        public static List<LeaveRequest> Search(string keyword)
        {
            string sql = @"
        SELECT lr_id, emp_id,
               faculty_name, dept_name,
               leave_type_name,
               start_date, end_date,
               total_days, reason, status,
               approval_remarks, applied_on,
               approved_by
        FROM   vw_leave_requests
        WHERE  faculty_name    LIKE @kw
            OR dept_name       LIKE @kw
            OR leave_type_name LIKE @kw
            OR status          LIKE @kw
        ORDER  BY applied_on DESC";

            var p = new[]
            {
        new MySqlParameter("@kw", "%" + keyword + "%")
    };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            var list = new List<LeaveRequest>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapFromView(row));
            return list;
        }

        // ── Private mapper ─────────────────────────────
        private static LeaveRequest MapFromView(DataRow row)
        {
            return new LeaveRequest
            {
                RequestId = Convert.ToInt32(row["lr_id"]),
                EmpId = Convert.ToInt32(row["emp_id"]),
                FacultyName = row["faculty_name"].ToString(),
                DeptName = row["dept_name"].ToString(),
                LeaveTypeName = row["leave_type_name"].ToString(),
                FromDate = Convert.ToDateTime(row["start_date"]),
                ToDate = Convert.ToDateTime(row["end_date"]),
                TotalDays = Convert.ToInt32(row["total_days"]),
                Reason = row["reason"].ToString(),
                Status = row["status"].ToString(),
                AppliedOn = Convert.ToDateTime(row["applied_on"]),
                ApprovedBy = row["approved_by"] == DBNull.Value
                                ? (int?)null
                                : Convert.ToInt32(row["approved_by"]),
                ApprovalRemarks =
                    row["approval_remarks"] == DBNull.Value
                        ? "" : row["approval_remarks"].ToString()
            };
        }
    }
}