using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.DAL
{
    public static class TimetableDAL
    {
        // Get All 
        public static List<Timetable> GetAll()
        {
            string sql = @"
                SELECT   tt.tt_id,
                         tt.wa_id,
                         f.name       AS faculty_name,
                         c.title      AS course_title,
                         c.course_code,
                         s.sem_name,
                         s.sem_id,
                         f.emp_id,
                         d.dept_name,
                         tt.day_of_week,
                         tt.slot_id,
                         ts.slot_label,
                         tt.room,
                         tt.conflict_flag
                FROM     timetable            tt
                JOIN     workload_assignments wa
                      ON tt.wa_id     = wa.wa_id
                JOIN     faculty              f
                      ON wa.emp_id    = f.emp_id
                JOIN     courses              c
                      ON wa.course_id = c.course_id
                JOIN     semesters            s
                      ON wa.sem_id    = s.sem_id
                JOIN     departments          d
                      ON f.dept_id    = d.dept_id
                JOIN     time_slots           ts
                      ON tt.slot_id   = ts.slot_id
                ORDER BY s.sem_name    ASC,
                         f.name        ASC,
                         tt.day_of_week ASC,
                         ts.start_time  ASC";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            return MapToList(dt);
        }

        // Get filtered
        public static List<Timetable> GetFiltered(int semId = 0, int empId = 0, string dayOfWeek = "")
        {
            string sql = @"
                SELECT   tt.tt_id,
                         tt.wa_id,
                         f.name       AS faculty_name,
                         c.title      AS course_title,
                         c.course_code,
                         s.sem_name,
                         s.sem_id,
                         f.emp_id,
                         d.dept_name,
                         tt.day_of_week,
                         tt.slot_id,
                         ts.slot_label,
                         tt.room,
                         tt.conflict_flag
                FROM     timetable            tt
                JOIN     workload_assignments wa
                      ON tt.wa_id     = wa.wa_id
                JOIN     faculty              f
                      ON wa.emp_id    = f.emp_id
                JOIN     courses              c
                      ON wa.course_id = c.course_id
                JOIN     semesters            s
                      ON wa.sem_id    = s.sem_id
                JOIN     departments          d
                      ON f.dept_id    = d.dept_id
                JOIN     time_slots           ts
                      ON tt.slot_id   = ts.slot_id
                WHERE    (@semId = 0
                          OR wa.sem_id  = @semId)
                AND      (@empId = 0
                          OR wa.emp_id  = @empId)
                AND      (@day = ''
                          OR tt.day_of_week = @day)
                ORDER BY f.name        ASC,
                         tt.day_of_week ASC,
                         ts.start_time  ASC";

            var p = new[]
            {
                new MySqlParameter("@semId", semId),
                new MySqlParameter("@empId", empId),
                new MySqlParameter("@day", dayOfWeek)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            return MapToList(dt);
        }

        // Get By ID
        public static Timetable GetById(int ttId)
        {
            string sql = @"
                SELECT   tt.tt_id,
                         tt.wa_id,
                         f.name       AS faculty_name,
                         c.title      AS course_title,
                         c.course_code,
                         s.sem_name,
                         s.sem_id,
                         f.emp_id,
                         d.dept_name,
                         tt.day_of_week,
                         tt.slot_id,
                         ts.slot_label,
                         tt.room,
                         tt.conflict_flag
                FROM     timetable            tt
                JOIN     workload_assignments wa
                      ON tt.wa_id     = wa.wa_id
                JOIN     faculty              f
                      ON wa.emp_id    = f.emp_id
                JOIN     courses              c
                      ON wa.course_id = c.course_id
                JOIN     semesters            s
                      ON wa.sem_id    = s.sem_id
                JOIN     departments          d
                      ON f.dept_id    = d.dept_id
                JOIN     time_slots           ts
                      ON tt.slot_id   = ts.slot_id
                WHERE    tt.tt_id     = @ttId";

            var p = new[]
            {
                new MySqlParameter("@ttId", ttId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);

            return dt.Rows.Count == 0
                ? null
                : MapToObject(dt.Rows[0]);
        }


        // Insert via TRANSACTION
        // INSERT timetable slot
        // UPDATE workload_assignments total_hours
        // Both commit or both rollback
        public static bool Insert(Timetable tt)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Check for conflict
                    // (same room + slot + day)
                    bool conflict =
                        CheckConflict(
                            tt.SlotId,
                            tt.DayOfWeek,
                            tt.Room,
                            0,
                            conn,
                            transaction);

                    // Insert timetable row
                    string insertSql = @"
                        INSERT INTO timetable
                            (wa_id,       day_of_week,
                             slot_id,     room,
                             conflict_flag)
                        VALUES
                            (@waId,       @day,
                             @slotId,     @room,
                             @conflictFlag)";

                    var insertCmd =
                        new MySqlCommand(insertSql, conn, transaction);

                    insertCmd.Parameters.AddWithValue("@waId", tt.WaId);
                    insertCmd.Parameters.AddWithValue("@day", tt.DayOfWeek);
                    insertCmd.Parameters.AddWithValue("@slotId", tt.SlotId);
                    insertCmd.Parameters
                        .AddWithValue(
                            "@room",
                            string.IsNullOrEmpty(
                                tt.Room)
                            ? (object)DBNull.Value
                            : tt.Room);
                    insertCmd.Parameters
                        .AddWithValue(
                            "@conflictFlag",
                            conflict ? 1 : 0);

                    insertCmd.ExecuteNonQuery();

                    // Recalculate and
                    // UPDATE total_hours in
                    // workload_assignments
                    // Count slots × credit hours
                    string updateHoursSql = @"
                        UPDATE workload_assignments wa
                        JOIN   courses c
                               ON wa.course_id =
                                  c.course_id
                        SET    wa.total_hours =
                               (SELECT COUNT(*)
                                FROM   timetable t
                                WHERE  t.wa_id =
                                       wa.wa_id)
                               * c.credit_hours
                        WHERE  wa.wa_id = @waId";

                    var updateCmd =
                        new MySqlCommand(updateHoursSql, conn, transaction);

                    updateCmd.Parameters.AddWithValue("@waId", tt.WaId);

                    updateCmd.ExecuteNonQuery();

                    // Commit both together
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LogManager.LogError(ex);
                    throw;
                }
            }
        }

        // Update (without transaction) 
        // Just updates day/slot/room/conflict
        // Does not change total_hours
        public static bool Update(Timetable tt)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    bool conflict =
                        CheckConflict(tt.SlotId, tt.DayOfWeek, tt.Room, tt.TtId, conn, transaction);

                    string sql = @"
                        UPDATE timetable
                        SET    day_of_week   = @day,
                               slot_id       = @slotId,
                               room          = @room,
                               conflict_flag =
                                   @conflictFlag
                        WHERE  tt_id         = @ttId";

                    var cmd = new MySqlCommand(sql, conn, transaction);

                    cmd.Parameters.AddWithValue("@day", tt.DayOfWeek);
                    cmd.Parameters.AddWithValue("@slotId", tt.SlotId);
                    cmd.Parameters.AddWithValue(
                        "@room",
                        string.IsNullOrEmpty(tt.Room)
                        ? (object)DBNull.Value
                        : tt.Room);
                    cmd.Parameters.AddWithValue(
                        "@conflictFlag",
                        conflict ? 1 : 0);
                    cmd.Parameters.AddWithValue("@ttId", tt.TtId);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LogManager.LogError(ex);
                    throw;
                }
            }
        }

        // Delete 
        public static bool Delete(int ttId,int waId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Step 1 — Delete slot
                    string deleteSql = @"
                        DELETE FROM timetable
                        WHERE  tt_id = @ttId";

                    var deleteCmd =
                        new MySqlCommand(
                            deleteSql, conn,
                            transaction);
                    deleteCmd.Parameters
                        .AddWithValue(
                            "@ttId", ttId);
                    deleteCmd.ExecuteNonQuery();

                    // Step 2 — Recalculate hours
                    string updateSql = @"
                        UPDATE workload_assignments wa
                        JOIN   courses c
                               ON wa.course_id =
                                  c.course_id
                        SET    wa.total_hours =
                               (SELECT COUNT(*)
                                FROM   timetable t
                                WHERE  t.wa_id =
                                       wa.wa_id)
                               * c.credit_hours
                        WHERE  wa.wa_id = @waId";

                    var updateCmd = new MySqlCommand(updateSql, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@waId", waId);
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LogManager.LogError(ex);
                    throw;
                }
            }
        }

        // Check room conflict 
        public static bool CheckConflict(
            int slotId,
            string dayOfWeek,
            string room,
            int excludeTtId = 0,
            MySqlConnection conn = null,
            MySqlTransaction tr = null)
        {
            if (string.IsNullOrEmpty(room))
                return false;

            string sql = @"
                SELECT COUNT(*)
                FROM   timetable
                WHERE  slot_id    = @slotId
                AND    day_of_week = @day
                AND    room       = @room
                AND    tt_id     != @excludeId";

            bool ownConn = conn == null;

            if (ownConn)
            {
                conn = DatabaseHelper.GetConnection();
                conn.Open();
            }

            try
            {
                var cmd = tr != null
                    ? new MySqlCommand(
                          sql, conn, tr)
                    : new MySqlCommand(
                          sql, conn);

                cmd.Parameters.AddWithValue("@slotId", slotId);
                cmd.Parameters.AddWithValue("@day", dayOfWeek);
                cmd.Parameters.AddWithValue("@room", room);
                cmd.Parameters.AddWithValue("@excludeId", excludeTtId);

                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) > 0;
            }
            finally
            {
                if (ownConn) conn.Dispose();
            }
        }

        // Check duplicate slot for assignment
        public static bool SlotExists(int waId, string dayOfWeek, int slotId, int excludeTtId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   timetable
                WHERE  wa_id      = @waId
                AND    day_of_week = @day
                AND    slot_id    = @slotId
                AND    tt_id     != @excludeId";

            var p = new[]
            {
                new MySqlParameter("@waId", waId),
                new MySqlParameter("@day", dayOfWeek),
                new MySqlParameter("@slotId", slotId),
                new MySqlParameter("@excludeId", excludeTtId)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Get assignments for combo 
        public static DataTable GetAssignmentsForCombo()
        {
            string sql = @"
                SELECT   wa.wa_id,
                         CONCAT(f.name,
                                ' → ',
                                c.course_code,
                                ' → ',
                                s.sem_name)
                             AS assignment_display
                FROM     workload_assignments wa
                JOIN     faculty   f
                      ON wa.emp_id    = f.emp_id
                JOIN     courses   c
                      ON wa.course_id = c.course_id
                JOIN     semesters s
                      ON wa.sem_id    = s.sem_id
                WHERE    wa.status   = 'Active'
                ORDER BY s.sem_name  ASC,
                         f.name      ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Map DataTable to List<Timetable> 
        private static List<Timetable> MapToList(DataTable dt)
        {
            var list = new List<Timetable>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToObject(row));
            return list;
        }

        // Map DataRow to Timetable 
        private static Timetable MapToObject(DataRow row)
        {
            return new Timetable(
                Convert.ToInt32(row["tt_id"]),
                Convert.ToInt32(row["wa_id"]),
                row["faculty_name"].ToString(),
                row["course_title"].ToString(),
                row["course_code"].ToString(),
                row["sem_name"].ToString(),
                Convert.ToInt32(row["sem_id"]),
                Convert.ToInt32(row["emp_id"]),
                row["dept_name"].ToString(),
                row["day_of_week"].ToString(),
                Convert.ToInt32(row["slot_id"]),
                row["slot_label"].ToString(),
                row["room"] == DBNull.Value
                    ? ""
                    : row["room"].ToString(),
                Convert.ToBoolean(
                    row["conflict_flag"])
            );
        }
    }
}