using System;
using System.Collections.Generic;
using System.Data;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;
using MySql.Data.MySqlClient;

namespace FacultyWorkloadSystem.DAL
{
    public static class LeaveApprovalDAL
    {
        // ── Get all pending requests ───────────────
        public static List<LeaveRequest> GetPending()
        {
            string sql = @"
                SELECT lr_id, emp_id,
                       faculty_name, dept_name,
                       leave_type_name,
                       start_date, end_date,
                       total_days, reason,
                       status, approval_remarks,
                       applied_on
                FROM   vw_leave_requests
                WHERE  status = 'Pending'
                ORDER  BY applied_on ASC";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql);

            return MapList(dt);
        }

        // ── Get all requests (all statuses) ───────
        public static List<LeaveRequest> GetAll()
        {
            string sql = @"
                SELECT lr_id, emp_id,
                       faculty_name, dept_name,
                       leave_type_name,
                       start_date, end_date,
                       total_days, reason,
                       status, approval_remarks,
                       applied_on
                FROM   vw_leave_requests
                ORDER  BY applied_on DESC";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql);

            return MapList(dt);
        }

        // ── Search / Filter ───────────────────────
        public static List<LeaveRequest> GetFiltered(string status, string keyword, string userRole, int loggedInEmpId)
        {
            string sql = @"
        SELECT lr_id, emp_id,
               faculty_name, dept_name,
               leave_type_name,
               start_date, end_date,
               total_days, reason,
               status, approval_remarks,
               applied_on
        FROM   vw_leave_requests
        WHERE  1 = 1";

            var pList = new List<MySqlParameter>();

            // Enforce role-based isolation early in the query configuration
            if (userRole == "HOD")
            {
                sql += " AND emp_id != @loggedInEmpId";
                pList.Add(new MySqlParameter("@loggedInEmpId", loggedInEmpId));
            }

            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                sql += " AND status = @st";
                pList.Add(new MySqlParameter("@st", status));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                sql += @" AND (
            faculty_name    LIKE @kw OR
            dept_name       LIKE @kw OR
            leave_type_name LIKE @kw)";
                pList.Add(new MySqlParameter("@kw", "%" + keyword + "%"));
            }

            sql += " ORDER BY applied_on DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, pList.ToArray());
            return MapList(dt);
        }

        // ── Approve ───────────────────────────────
        public static bool Approve(int lrId, string remarks, int approvedBy)
        {
            string sql = @"
        UPDATE leave_requests
        SET    appr_status  = 'Approved',
               appr_remarks = @rem,
               approved_by  = @uid
        WHERE  lr_id        = @id
          AND  appr_status  = 'Pending'";

            var p = new[]
            {
        new MySqlParameter("@rem", remarks),
        new MySqlParameter("@uid", approvedBy),
        new MySqlParameter("@id",  lrId)
    };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool Reject(int lrId, string remarks, int rejectedBy)
        {
            string sql = @"
        UPDATE leave_requests
        SET    appr_status  = 'Rejected',
               appr_remarks = @rem,
               approved_by  = @uid
        WHERE  lr_id        = @id
          AND  appr_status  = 'Pending'";

            var p = new[]
            {
        new MySqlParameter("@rem", remarks),
        new MySqlParameter("@uid", rejectedBy),
        new MySqlParameter("@id",  lrId)
    };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        

        // ── Private mapper ────────────────────────
        private static List<LeaveRequest>
            MapList(DataTable dt)
        {
            var list = new List<LeaveRequest>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new LeaveRequest
                {
                    RequestId =
                        Convert.ToInt32(
                            row["lr_id"]),
                   
                     EmpId = Convert.ToInt32(row["emp_id"]),
                    FacultyName =
                        row["faculty_name"]
                        .ToString(),
                    DeptName =
                        row["dept_name"].ToString(),
                    LeaveTypeName =
                        row["leave_type_name"]
                        .ToString(),
                    FromDate =
                        Convert.ToDateTime(
                            row["start_date"]),
                    ToDate =
                        Convert.ToDateTime(
                            row["end_date"]),
                    TotalDays =
                        Convert.ToInt32(
                            row["total_days"]),
                    Reason =
                        row["reason"].ToString(),
                    Status =
                        row["status"].ToString(),
                    ApprovalRemarks =
                        row["approval_remarks"]
                        == DBNull.Value
                        ? ""
                        : row["approval_remarks"]
                          .ToString(),
                    AppliedOn =
                        Convert.ToDateTime(
                            row["applied_on"])
                });
            }
            return list;
        }
    }
}