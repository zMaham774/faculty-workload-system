using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.DAL
{
    public static class AcademicCalendarDAL
    {
        // Get All
        public static List<AcademicCalendar> GetAll()
        {
            string sql = @"
                SELECT   ac.cal_id,
                         ac.sem_id,
                         s.sem_name,
                         ac.event_date,
                         ac.event_type,
                         ac.event_name,
                         ac.is_teaching,
                         ac.description,
                         ac.created_by
                FROM     academic_calendar ac
                JOIN     semesters s
                      ON ac.sem_id = s.sem_id
                ORDER BY ac.event_date ASC";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            return MapToList(dt);
        }

        // Get By Semester 
        public static List<AcademicCalendar> GetBySemester(int semId)
        {
            string sql = @"
                SELECT   ac.cal_id,
                         ac.sem_id,
                         s.sem_name,
                         ac.event_date,
                         ac.event_type,
                         ac.event_name,
                         ac.is_teaching,
                         ac.description,
                         ac.created_by
                FROM     academic_calendar ac
                JOIN     semesters s
                      ON ac.sem_id = s.sem_id
                WHERE    ac.sem_id = @semId
                ORDER BY ac.event_date ASC";

            var p = new[]
            {
                new MySqlParameter(
                    "@semId", semId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            return MapToList(dt);
        }

        // Get By ID
        public static AcademicCalendar GetById(int calId)
        {
            string sql = @"
                SELECT   ac.cal_id,
                         ac.sem_id,
                         s.sem_name,
                         ac.event_date,
                         ac.event_type,
                         ac.event_name,
                         ac.is_teaching,
                         ac.description,
                         ac.created_by
                FROM     academic_calendar ac
                JOIN     semesters s
                      ON ac.sem_id = s.sem_id
                WHERE    ac.cal_id = @calId";

            var p = new[]
            {
                new MySqlParameter(
                    "@calId", calId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);

            return dt.Rows.Count == 0
                ? null
                : MapToObject(dt.Rows[0]);
        }

        // Check if date is a teaching day 
        // Used by AttendanceForm before marking
        public static bool IsTeachingDay(int semId, DateTime date)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   academic_calendar
                WHERE  sem_id     = @semId
                AND    event_date = @date
                AND    is_teaching = 0";

            var p = new[]
            {
                new MySqlParameter("@semId", semId),
                new MySqlParameter("@date",  date.Date)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);

            // Returns true if NO blocking
            // event exists on this date
            return Convert.ToInt32(result) == 0;
        }

        // Get event on a specific date
        // Used by AttendanceForm to show event name
        public static AcademicCalendar
            GetByDate(int semId, DateTime date)
        {
            string sql = @"
                SELECT   ac.cal_id,
                         ac.sem_id,
                         s.sem_name,
                         ac.event_date,
                         ac.event_type,
                         ac.event_name,
                         ac.is_teaching,
                         ac.description,
                         ac.created_by
                FROM     academic_calendar ac
                JOIN     semesters s
                      ON ac.sem_id = s.sem_id
                WHERE    ac.sem_id     = @semId
                AND      ac.event_date = @date
                LIMIT    1";

            var p = new[]
            {
                new MySqlParameter("@semId", semId),
                new MySqlParameter("@date",  date.Date)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);

            return dt.Rows.Count == 0
                ? null
                : MapToObject(dt.Rows[0]);
        }

        // Insert
        public static bool Insert(AcademicCalendar ac)
        {
            string sql = @"
                INSERT INTO academic_calendar
                    (sem_id,      event_date,
                     event_type,  event_name,
                     is_teaching, description,
                     created_by)
                VALUES
                    (@semId,      @eventDate,
                     @eventType,  @eventName,
                     @isTeaching, @description,
                     @createdBy)";

            var p = new[]
            {
                new MySqlParameter(
                    "@semId",      ac.SemId),
                new MySqlParameter(
                    "@eventDate",  ac.EventDate.Date),
                new MySqlParameter(
                    "@eventType",  ac.EventType),
                new MySqlParameter(
                    "@eventName",  ac.EventName),
                new MySqlParameter(
                    "@isTeaching",
                    ac.IsTeaching ? 1 : 0),
                new MySqlParameter(
                    "@description",
                    string.IsNullOrEmpty(
                        ac.Description)
                        ? (object)DBNull.Value
                        : ac.Description),
                new MySqlParameter(
                    "@createdBy",
                    ac.CreatedBy == null
                        ? (object)DBNull.Value
                        : ac.CreatedBy)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Update
        public static bool Update(
            AcademicCalendar ac)
        {
            string sql = @"
                UPDATE academic_calendar
                SET    sem_id      = @semId,
                       event_date  = @eventDate,
                       event_type  = @eventType,
                       event_name  = @eventName,
                       is_teaching = @isTeaching,
                       description = @description
                WHERE  cal_id      = @calId";

            var p = new[]
            {
                new MySqlParameter(
                    "@semId",      ac.SemId),
                new MySqlParameter(
                    "@eventDate",  ac.EventDate.Date),
                new MySqlParameter(
                    "@eventType",  ac.EventType),
                new MySqlParameter(
                    "@eventName",  ac.EventName),
                new MySqlParameter(
                    "@isTeaching",
                    ac.IsTeaching ? 1 : 0),
                new MySqlParameter(
                    "@description",
                    string.IsNullOrEmpty(
                        ac.Description)
                        ? (object)DBNull.Value
                        : ac.Description),
                new MySqlParameter(
                    "@calId",      ac.CalId)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Delete
        public static bool Delete(int calId)
        {
            string sql = @"
                DELETE FROM academic_calendar
                WHERE  cal_id = @calId";

            var p = new[]
            {
                new MySqlParameter("@calId", calId)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Check duplicate sem+date+type
        public static bool Exists(int semId, DateTime date, string eventType, int excludeId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   academic_calendar
                WHERE  sem_id     = @semId
                AND    event_date = @date
                AND    event_type = @eventType
                AND    cal_id    != @excludeId";

            var p = new[]
            {
                new MySqlParameter(
                    "@semId",     semId),
                new MySqlParameter(
                    "@date",      date.Date),
                new MySqlParameter(
                    "@eventType", eventType),
                new MySqlParameter(
                    "@excludeId", excludeId)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // Map DataTable to List 
        private static List<AcademicCalendar> MapToList(DataTable dt)
        {
            var list = new List<AcademicCalendar>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToObject(row));
            return list;
        }

        // Map DataRow to AcademicCalendar
        private static AcademicCalendar MapToObject(DataRow row)
        {
            return new AcademicCalendar(
                Convert.ToInt32(row["cal_id"]),
                Convert.ToInt32(row["sem_id"]),
                row["sem_name"].ToString(),
                Convert.ToDateTime(
                    row["event_date"]),
                row["event_type"].ToString(),
                row["event_name"].ToString(),
                Convert.ToBoolean(
                    row["is_teaching"]),
                row["description"] == DBNull.Value
                    ? ""
                    : row["description"].ToString(),
                row["created_by"] == DBNull.Value
                    ? (int?)null
                    : Convert.ToInt32(
                        row["created_by"])
            );
        }
    }
}