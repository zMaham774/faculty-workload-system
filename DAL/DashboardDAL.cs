using FacultyWorkloadSystem.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace FacultyWorkloadSystem.DAL
{
    public static class DashboardDAL
    {
        // ── Total Faculty (active only) ───────────────────
        public static int GetTotalFaculty()
        {
            string q = @"SELECT COUNT(*) 
                         FROM faculty 
                         WHERE is_active = 1";
            object r = DatabaseHelper.ExecuteScalar(q);
            return r == null ? 0 : Convert.ToInt32(r);
        }

        // ── Total Departments (active only) ───────────────
        public static int GetTotalDepartments()
        {
            string q = @"SELECT COUNT(*) 
                         FROM departments 
                         WHERE is_active = 1";
            object r = DatabaseHelper.ExecuteScalar(q);
            return r == null ? 0 : Convert.ToInt32(r);
        }

        // ── Total Courses (active only) ───────────────────
        public static int GetTotalCourses()
        {
            string q = @"SELECT COUNT(*) 
                         FROM courses 
                         WHERE is_active = 1";
            object r = DatabaseHelper.ExecuteScalar(q);
            return r == null ? 0 : Convert.ToInt32(r);
        }

        // ── Pending Leave Requests ─────────────────────────
        public static int GetPendingLeaves()
        {
            string q = @"SELECT COUNT(*) 
                         FROM leave_requests 
                         WHERE appr_status = 'Pending'";
            object r = DatabaseHelper.ExecuteScalar(q);
            return r == null ? 0 : Convert.ToInt32(r);
        }

        // ── Current Semester Name ──────────────────────────
        public static string GetCurrentSemester()
        {
            string q = @"SELECT sem_name 
                         FROM semesters 
                         WHERE is_current = 1 
                         LIMIT 1";
            object r = DatabaseHelper.ExecuteScalar(q);
            return r == null ? "No Active Semester" : r.ToString();
        }

        // ── Today's Schedule using VIEW ───────────────────
        public static DataTable GetTodaySchedule(int? empId)
        {
            string q;
            MySqlParameter[] p;

            if (empId == null)
            {
                // Admin/HOD — view already filters
                // by today + current semester
                q = @"SELECT emp_id,
                     faculty_name  AS FacultyName,
                     course_title  AS CourseName,
                     course_code   AS CourseCode,
                     slot_label    AS TimeSlot,
                     room          AS Room,
                     day_of_week   AS DayOfWeek
              FROM   vw_todays_timetable
              ORDER  BY start_time ASC";

                p = null;
            }
            else
            {
                // Faculty — filter view by their emp_id
                q = @"SELECT emp_id,
                     faculty_name  AS FacultyName,
                     course_title  AS CourseName,
                     course_code   AS CourseCode,
                     slot_label    AS TimeSlot,
                     room          AS Room,
                     day_of_week   AS DayOfWeek
              FROM   vw_todays_timetable
              WHERE  emp_id = @empId
              ORDER  BY start_time ASC";

                p = new[]
                {
            new MySqlParameter(
                "@empId", empId.Value)
        };
            }

            return p == null
                ? DatabaseHelper.ExecuteQuery(q)
                : DatabaseHelper.ExecuteQuery(q, p);
        }

        // ── Pending Leave List (for panel) ────────────────
        public static DataTable GetPendingLeaveList()
        {
            string q = @"SELECT 
                           f.name       AS FacultyName,
                           lt.lt_name   AS LeaveType,
                           lr.start_date,
                           lr.end_date,
                           DATEDIFF(lr.end_date, 
                                    lr.start_date) + 1 
                                    AS Days,
                           lr.lr_id
                         FROM leave_requests lr
                         JOIN faculty     f  
                              ON f.emp_id  = lr.emp_id
                         JOIN leave_types lt 
                              ON lt.lt_id  = lr.lt_id
                         WHERE lr.appr_status = 'Pending'
                         ORDER BY lr.submitted_on DESC
                         LIMIT 5";
            return DatabaseHelper.ExecuteQuery(q);
        }

        // ── Upcoming Calendar Events ───────────────────────
        public static DataTable GetUpcomingEvents()
        {
            string q = @"SELECT 
                           ac.event_name,
                           ac.event_date,
                           ac.event_type
                         FROM academic_calendar ac
                         JOIN semesters s 
                              ON s.sem_id = ac.sem_id
                         WHERE s.is_current = 1
                           AND ac.event_date >= CURDATE()
                         ORDER BY ac.event_date
                         LIMIT 3";
            return DatabaseHelper.ExecuteQuery(q);
        }
    }
}