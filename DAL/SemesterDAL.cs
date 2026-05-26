using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.DAL
{
    public static class SemesterDAL
    {
        // ── Get All ───────────────────────────────────
        public static List<Semester> GetAll()
        {
            string sql = @"
                SELECT sem_id, sem_name,
                       acad_year, start_date,
                       end_date,  is_current
                FROM   semesters
                ORDER  BY start_date DESC";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql);
            var list = new List<Semester>();
            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));
            return list;
        }

        // ── Get By Id ─────────────────────────────────
        public static Semester GetById(int id)
        {
            string sql = @"
                SELECT sem_id, sem_name,
                       acad_year, start_date,
                       end_date,  is_current
                FROM   semesters
                WHERE  sem_id = @id";

            var p = new[]
            {
                new MySqlParameter("@id", id)
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql, p);
            return dt.Rows.Count == 0
                ? null : Map(dt.Rows[0]);
        }

        // ── Insert ────────────────────────────────────
        public static bool Insert(Semester s)
        {
            string sql = @"
                INSERT INTO semesters
                    (sem_name, acad_year,
                     start_date, end_date,
                     is_current)
                VALUES
                    (@name, @year,
                     @start, @end,
                     @current)";

            var p = new[]
            {
                new MySqlParameter(
                    "@name",    s.SemName),
                new MySqlParameter(
                    "@year",    s.AcadYear),
                new MySqlParameter(
                    "@start",
                    s.StartDate
                    .ToString("yyyy-MM-dd")),
                new MySqlParameter(
                    "@end",
                    s.EndDate
                    .ToString("yyyy-MM-dd")),
                new MySqlParameter(
                    "@current",
                    s.IsCurrent ? 1 : 0)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Update ────────────────────────────────────
        public static bool Update(Semester s)
        {
            string sql = @"
                UPDATE semesters
                SET    sem_name   = @name,
                       acad_year  = @year,
                       start_date = @start,
                       end_date   = @end,
                       is_current = @current
                WHERE  sem_id     = @id";

            var p = new[]
            {
                new MySqlParameter(
                    "@name",    s.SemName),
                new MySqlParameter(
                    "@year",    s.AcadYear),
                new MySqlParameter(
                    "@start",
                    s.StartDate
                    .ToString("yyyy-MM-dd")),
                new MySqlParameter(
                    "@end",
                    s.EndDate
                    .ToString("yyyy-MM-dd")),
                new MySqlParameter(
                    "@current",
                    s.IsCurrent ? 1 : 0),
                new MySqlParameter(
                    "@id",      s.SemId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Delete ────────────────────────────────────
        public static bool Delete(int id)
        {
            string sql = @"
                DELETE FROM semesters
                WHERE  sem_id = @id";

            var p = new[]
            {
                new MySqlParameter("@id", id)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Set As Current ────────────────────────────
        // First reset all, then set selected one
        public static bool SetAsCurrent(int id)
        {
            string[] queries = new[]
            {
                @"UPDATE semesters
                  SET is_current = 0",
                @"UPDATE semesters
                  SET is_current = 1
                  WHERE sem_id   = @id"
            };

            MySqlParameter[][] pars =
                new MySqlParameter[][]
            {
                null,
                new MySqlParameter[]
                {
                    new MySqlParameter("@id", id)
                }
            };

            return DatabaseHelper
                .ExecuteTransaction(queries, pars);
        }

        // ── Name Exists ───────────────────────────────
        public static bool NameExists(
            string name, int excludeId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   semesters
                WHERE  sem_name = @name
                  AND  sem_id  != @ex";

            var p = new[]
            {
                new MySqlParameter(
                    "@name", name),
                new MySqlParameter(
                    "@ex",   excludeId)
            };

            object r =
                DatabaseHelper
                .ExecuteScalar(sql, p);
            return Convert.ToInt32(r) > 0;
        }

        // ── Has Assignments ───────────────────────────
        public static bool HasAssignments(int id)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   workload_assignments
                WHERE  sem_id = @id";

            var p = new[]
            {
                new MySqlParameter("@id", id)
            };

            object r =
                DatabaseHelper
                .ExecuteScalar(sql, p);
            return Convert.ToInt32(r) > 0;
        }

        // ── Search ────────────────────────────────────
        public static List<Semester> Search(
            string keyword)
        {
            string sql = @"
                SELECT sem_id, sem_name,
                       acad_year, start_date,
                       end_date,  is_current
                FROM   semesters
                WHERE  sem_name  LIKE @kw
                    OR acad_year LIKE @kw
                ORDER  BY start_date DESC";

            var p = new[]
            {
                new MySqlParameter(
                    "@kw",
                    "%" + keyword + "%")
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql, p);
            var list = new List<Semester>();
            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));
            return list;
        }

        // ── Private mapper ─────────────────────────────
        private static Semester Map(DataRow row)
        {
            return new Semester
            {
                SemId =
                    Convert.ToInt32(
                        row["sem_id"]),
                SemName =
                    row["sem_name"].ToString(),
                AcadYear =
                    row["acad_year"].ToString(),
                StartDate =
                    Convert.ToDateTime(
                        row["start_date"]),
                EndDate =
                    Convert.ToDateTime(
                        row["end_date"]),
                IsCurrent =
                    Convert.ToInt32(
                        row["is_current"]) == 1
            };
        }
    }
}
