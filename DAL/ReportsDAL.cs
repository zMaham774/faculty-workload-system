using System;
using System.Data;
using MySql.Data.MySqlClient;
using FacultyWorkloadSystem.Helpers;

namespace FacultyWorkloadSystem.DAL
{
    public static class ReportsDAL
    {
        // Report 1 - Faculty Status 
        public static DataTable GetFacultyStatus()
        {
            string sql = @"
                SELECT
                    f.emp_id        AS 'Emp ID',
                    f.name          AS 'Name',
                    d.dept_name     AS 'Department',
                    des.designation_name
                                    AS 'Designation',
                    f.emp_type      AS 'Type',
                    f.email         AS 'Email',
                    f.phone         AS 'Phone',
                    f.qualification AS 'Qualification',
                    CASE WHEN f.is_active = 1
                         THEN 'Active'
                         ELSE 'Inactive'
                    END             AS 'Status'
                FROM   faculty      f
                JOIN   departments  d
                    ON f.dept_id        = d.dept_id
                JOIN   designations des
                    ON f.designation_id =
                       des.designation_id
                WHERE  f.is_deleted = 0
                ORDER  BY d.dept_name ASC,
                          f.name      ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Report 2 - Department Faculty 
        public static DataTable GetDepartmentFaculty()
        {
            string sql = @"
                SELECT
                    d.dept_name      AS 'Department',
                    d.hod_name       AS 'HOD',
                    d.contact        AS 'Contact',
                    d.email          AS 'Email',
                    COUNT(f.emp_id)  AS 'Total Faculty',
                    SUM(CASE WHEN f.is_active = 1
                             THEN 1 ELSE 0 END)
                                     AS 'Active',
                    SUM(CASE WHEN f.is_active = 0
                             THEN 1 ELSE 0 END)
                                     AS 'Inactive'
                FROM   departments d
                LEFT JOIN faculty  f
                    ON d.dept_id   = f.dept_id
                    AND f.is_deleted = 0
                WHERE  d.is_deleted = 0
                GROUP  BY d.dept_id,
                          d.dept_name,
                          d.hod_name,
                          d.contact,
                          d.email
                ORDER  BY d.dept_name ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        //  Report 3 - Academic Calendar
        public static DataTable GetAcademicCalendar()
        {
            string sql = @"
                SELECT
                    s.sem_name     AS 'Semester',
                    ac.event_date  AS 'Date',
                    ac.event_name  AS 'Event Name',
                    ac.event_type  AS 'Event Type',
                    CASE WHEN ac.is_teaching = 1
                         THEN 'Yes'
                         ELSE 'No'
                    END            AS 'Classes Run',
                    ac.description AS 'Description'
                FROM   academic_calendar ac
                JOIN   semesters         s
                    ON ac.sem_id    = s.sem_id
                WHERE  ac.is_deleted = 0
                AND    s.is_deleted  = 0
                ORDER  BY s.sem_id        ASC,
                          ac.event_date   ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Report 4 - Faculty Workload
        public static DataTable  GetFacultyWorkload()
        {
            string sql = @"
                SELECT
                    s.sem_name      AS 'Semester',
                    f.name          AS 'Faculty',
                    d.dept_name     AS 'Department',
                    COUNT(wa.wa_id) AS 'Courses Assigned',
                    SUM(wa.total_hours)
                                    AS 'Total Hours',
                    ws.min_hours    AS 'Min Hours',
                    ws.std_hours    AS 'Std Hours',
                    ws.max_hours    AS 'Max Hours',
                    CASE
                        WHEN SUM(wa.total_hours)
                             < ws.min_hours
                        THEN 'Under'
                        WHEN SUM(wa.total_hours)
                             > ws.max_hours
                        THEN 'Over'
                        ELSE 'Within Range'
                    END             AS 'Workload Status'
                FROM   workload_assignments wa
                JOIN   faculty             f
                    ON wa.emp_id     = f.emp_id
                JOIN   departments         d
                    ON f.dept_id     = d.dept_id
                JOIN   semesters           s
                    ON wa.sem_id     = s.sem_id
                LEFT JOIN workload_standards ws
                    ON ws.dept_id   = d.dept_id
                    AND ws.sem_id   = s.sem_id
                WHERE  wa.is_deleted = 0
                AND    f.is_deleted  = 0
                AND    s.is_deleted  = 0
                AND    wa.status     = 'Active'
                GROUP  BY s.sem_id,
                          f.emp_id,
                          f.name,
                          d.dept_name,
                          ws.min_hours,
                          ws.std_hours,
                          ws.max_hours
                ORDER  BY s.sem_name ASC,
                          d.dept_name ASC,
                          f.name      ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Report 5 - Faculty Course Assignment
        public static DataTable GetFacultyCourseAssignment()
        {
            string sql = @"
                SELECT
                    s.sem_name       AS 'Semester',
                    f.name           AS 'Faculty',
                    d.dept_name      AS 'Department',
                    c.course_code    AS 'Code',
                    c.title          AS 'Course Title',
                    c.credit_hours   AS 'Credits',
                    c.course_type    AS 'Type',
                    wa.total_hours   AS 'Hours',
                    wa.status        AS 'Status',
                    wa.assigned_date AS 'Assigned On'
                FROM   workload_assignments wa
                JOIN   faculty             f
                    ON wa.emp_id     = f.emp_id
                JOIN   courses             c
                    ON wa.course_id  = c.course_id
                JOIN   departments         d
                    ON f.dept_id     = d.dept_id
                JOIN   semesters           s
                    ON wa.sem_id     = s.sem_id
                WHERE  wa.is_deleted = 0
                AND    f.is_deleted  = 0
                AND    c.is_deleted  = 0
                AND    s.is_deleted  = 0
                ORDER  BY s.sem_name  ASC,
                          d.dept_name ASC,
                          f.name      ASC,
                          c.title     ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Report 6 - Timetable
        public static DataTable GetTimetable()
        {
            string sql = @"
        SELECT
            s.sem_name       AS 'Semester',
            f.name           AS 'Faculty',
            d.dept_name      AS 'Department',
            c.course_code    AS 'Code',
            c.title          AS 'Course',
            tt.day_of_week   AS 'Day',
            ts.slot_label    AS 'Time Slot',
            tt.room          AS 'Room',
            CASE WHEN tt.conflict_flag = 1
                 THEN 'Yes'
                 ELSE 'No'
            END              AS 'Conflict'
        FROM   timetable            tt
        JOIN   workload_assignments wa
            ON tt.wa_id     = wa.wa_id
        JOIN   faculty              f
            ON wa.emp_id    = f.emp_id
        JOIN   courses              c
            ON wa.course_id = c.course_id
        JOIN   departments          d
            ON f.dept_id    = d.dept_id
        JOIN   semesters            s
            ON wa.sem_id    = s.sem_id
        JOIN   time_slots           ts
            ON tt.slot_id   = ts.slot_id
        WHERE  tt.is_deleted  = 0
        AND    wa.is_deleted  = 0
        AND    f.is_deleted   = 0
        AND    s.is_deleted   = 0
        ORDER  BY s.sem_name    ASC,
                  d.dept_name   ASC,
                  f.name        ASC,
                  FIELD(tt.day_of_week,
                    'Monday','Tuesday',
                    'Wednesday','Thursday',
                    'Friday','Saturday'),
                  ts.start_time ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Report 7 - Semester Workload Summary
        public static DataTable GetSemesterWorkloadSummary()
        {
            string sql = @"
        SELECT
            s.sem_name          AS 'Semester',
            d.dept_name         AS 'Department',
            COUNT(DISTINCT
                wa.emp_id)      AS 'Faculty Count',
            COUNT(wa.wa_id)     AS 'Total Assignments',
            SUM(wa.total_hours) AS 'Total Hours',
            AVG(wa.total_hours) AS 'Avg Hours/Faculty',
            ws.min_hours        AS 'Min Standard',
            ws.std_hours        AS 'Std Standard',
            ws.max_hours        AS 'Max Standard',
            SUM(CASE
                WHEN wa.total_hours < ws.min_hours
                THEN 1 ELSE 0 END)
                                AS 'Under Loaded',
            SUM(CASE
                WHEN wa.total_hours > ws.max_hours
                THEN 1 ELSE 0 END)
                                AS 'Over Loaded'
        FROM   workload_assignments wa
        JOIN   faculty             f
            ON wa.emp_id   = f.emp_id
        JOIN   departments         d
            ON f.dept_id   = d.dept_id
        JOIN   semesters           s
            ON wa.sem_id   = s.sem_id
        LEFT JOIN workload_standards ws
            ON ws.dept_id  = d.dept_id
            AND ws.sem_id  = s.sem_id
        WHERE  wa.is_deleted = 0
        AND    f.is_deleted  = 0
        AND    s.is_deleted  = 0
        AND    wa.status     = 'Active'
        GROUP  BY s.sem_id,
                  s.sem_name,
                  d.dept_id,
                  d.dept_name,
                  ws.min_hours,
                  ws.std_hours,
                  ws.max_hours
        ORDER  BY s.sem_name  ASC,
                  d.dept_name ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Report 8 - Course Distribution 
        public static DataTable GetCourseDistribution()
        {
            string sql = @"
        SELECT
            d.dept_name       AS 'Department',
            c.course_code     AS 'Code',
            c.title           AS 'Course Title',
            c.credit_hours    AS 'Credits',
            c.course_type     AS 'Type',
            COUNT(wa.wa_id)   AS 'Times Assigned',
            COUNT(DISTINCT
                wa.sem_id)    AS 'Semesters Run',
            COUNT(DISTINCT
                wa.emp_id)    AS 'Faculty Taught',
            CASE WHEN c.is_active = 1
                 THEN 'Active'
                 ELSE 'Inactive'
            END               AS 'Status'
        FROM   courses             c
        JOIN   departments         d
            ON c.dept_id    = d.dept_id
        LEFT JOIN workload_assignments wa
            ON wa.course_id = c.course_id
            AND wa.is_deleted = 0
        WHERE  c.is_deleted = 0
        AND    d.is_deleted = 0
        GROUP  BY c.course_id,
                  c.course_code,
                  c.title,
                  c.credit_hours,
                  c.course_type,
                  c.is_active,
                  d.dept_name
        ORDER  BY d.dept_name ASC,
                  c.title     ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Report 9 - Room Utilization 
        public static DataTable GetRoomUtilization()
        {
            string sql = @"
        SELECT
            tt.room               AS 'Room',
            s.sem_name            AS 'Semester',
            COUNT(tt.tt_id)       AS 'Total Slots',
            COUNT(DISTINCT
                tt.day_of_week)   AS 'Days Used',
            GROUP_CONCAT(
                DISTINCT
                tt.day_of_week
                ORDER BY FIELD(
                    tt.day_of_week,
                    'Monday','Tuesday',
                    'Wednesday','Thursday',
                    'Friday','Saturday')
                SEPARATOR ', ')   AS 'Days',
            SUM(CASE
                WHEN tt.conflict_flag = 1
                THEN 1 ELSE 0 END)
                                  AS 'Conflicts'
        FROM   timetable            tt
        JOIN   workload_assignments wa
            ON tt.wa_id   = wa.wa_id
        JOIN   semesters            s
            ON wa.sem_id  = s.sem_id
        WHERE  tt.is_deleted  = 0
        AND    wa.is_deleted  = 0
        AND    s.is_deleted   = 0
        AND    tt.room        IS NOT NULL
        AND    tt.room        != ''
        GROUP  BY tt.room,
                  s.sem_id,
                  s.sem_name
        ORDER  BY s.sem_name ASC,
                  tt.room    ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Report 10 - Faculty Change History
        public static DataTable GetFacultyChangeHistory()
        {
            string sql = @"
        SELECT
            f.name              AS 'Faculty',
            d.dept_name         AS 'Department',
            fcl.change_type     AS 'Change Type',
            CASE fcl.change_type
                WHEN 'Designation' THEN
                    COALESCE(
                        (SELECT designation_name
                         FROM   designations
                         WHERE  designation_id =
                                fcl.old_value),
                        fcl.old_value)

                WHEN 'Department' THEN
                    COALESCE(
                        (SELECT dept_name
                         FROM   departments
                         WHERE  dept_id =
                                fcl.old_value),
                        fcl.old_value)

                -- Status change
                -- resolve 1/0 to text
                WHEN 'Status' THEN
                    CASE fcl.old_value
                        WHEN '1' THEN 'Active'
                        WHEN '0' THEN 'Inactive'
                        ELSE fcl.old_value
                    END

                ELSE fcl.old_value
            END                 AS 'Old Value',

            CASE fcl.change_type

                WHEN 'Designation' THEN
                    COALESCE(
                        (SELECT designation_name
                         FROM   designations
                         WHERE  designation_id =
                                fcl.new_value),
                        fcl.new_value)

                WHEN 'Department' THEN
                    COALESCE(
                        (SELECT dept_name
                         FROM   departments
                         WHERE  dept_id =
                                fcl.new_value),
                        fcl.new_value)

                WHEN 'Status' THEN
                    CASE fcl.new_value
                        WHEN '1' THEN 'Active'
                        WHEN '0' THEN 'Inactive'
                        ELSE fcl.new_value
                    END

                ELSE fcl.new_value
            END                 AS 'New Value',

            fcl.changed_on      AS 'Changed On',
            u.username          AS 'Changed By'
        FROM   faculty_change_log fcl
        JOIN   faculty            f
            ON fcl.emp_id     = f.emp_id
        JOIN   departments        d
            ON f.dept_id      = d.dept_id
        LEFT JOIN users           u
            ON fcl.changed_by = u.user_id
        WHERE  f.is_deleted = 0
        ORDER  BY fcl.changed_on DESC";

            return DatabaseHelper.ExecuteQuery(sql);
        }
    }
}