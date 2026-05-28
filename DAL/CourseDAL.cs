using System;
using System.Collections.Generic;
using System.Data;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;
using MySql.Data.MySqlClient;

namespace FacultyWorkloadSystem.DAL
{
    public static class CourseDAL
    {
        // ── Get All ───────────────────────────────────
        public static List<Course> GetAll()
        {
            string sql = @"
                SELECT c.course_id,
                       c.course_code,
                       c.title,
                       c.credit_hours,
                       c.course_type,
                       c.dept_id,
                       d.dept_name,
                       c.is_active
                FROM   courses c
                JOIN   departments d
                    ON c.dept_id = d.dept_id
                ORDER  BY c.course_id ASC";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql);

            var list = new List<Course>();
            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));
            return list;
        }

        // ── Get By Id ─────────────────────────────────
        public static Course GetById(int id)
        {
            string sql = @"
                SELECT c.course_id,
                       c.course_code,
                       c.title,
                       c.credit_hours,
                       c.course_type,
                       c.dept_id,
                       d.dept_name,
                       c.is_active
                FROM   courses c
                JOIN   departments d
                    ON c.dept_id = d.dept_id
                WHERE  c.course_id = @id";

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
        public static bool Insert(Course c)
        {
            string sql = @"
                INSERT INTO courses
                    (course_code, title,
                     credit_hours, course_type,
                     dept_id,     is_active)
                VALUES
                    (@code, @title, @ch,
                     @type, @dept, @active)";

            var p = new[]
            {
                new MySqlParameter(
                    "@code",   c.CourseCode),
                new MySqlParameter(
                    "@title",  c.Title),
                new MySqlParameter(
                    "@ch",     c.CreditHours),
                new MySqlParameter(
                    "@type",   c.CourseType),
                new MySqlParameter(
                    "@dept",   c.DeptId),
                new MySqlParameter(
                    "@active", c.IsActive ? 1 : 0)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Update ────────────────────────────────────
        public static bool Update(Course c)
        {
            string sql = @"
                UPDATE courses
                SET    course_code  = @code,
                       title        = @title,
                       credit_hours = @ch,
                       course_type  = @type,
                       dept_id      = @dept,
                       is_active    = @active
                WHERE  course_id    = @id";

            var p = new[]
            {
                new MySqlParameter(
                    "@code",   c.CourseCode),
                new MySqlParameter(
                    "@title",  c.Title),
                new MySqlParameter(
                    "@ch",     c.CreditHours),
                new MySqlParameter(
                    "@type",   c.CourseType),
                new MySqlParameter(
                    "@dept",   c.DeptId),
                new MySqlParameter(
                    "@active", c.IsActive ? 1 : 0),
                new MySqlParameter(
                    "@id",     c.CourseId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Delete ────────────────────────────────────
        public static bool Delete(int id)
        {
            string sql = @"
                DELETE FROM courses
                WHERE  course_id = @id";

            var p = new[]
            {
                new MySqlParameter("@id", id)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Code Exists ───────────────────────────────
        public static bool CodeExists(
            string code, int excludeId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   courses
                WHERE  course_code = @code
                  AND  course_id  != @ex";

            var p = new[]
            {
                new MySqlParameter("@code", code),
                new MySqlParameter("@ex", excludeId)
            };

            object r =
                DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(r) > 0;
        }

        // ── Has Workload ──────────────────────────────
        public static bool HasWorkload(int id)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   workload_assignments
                WHERE  course_id = @id";

            var p = new[]
            {
                new MySqlParameter("@id", id)
            };

            object r =
                DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(r) > 0;
        }

        // ── Search ────────────────────────────────────
        public static List<Course> Search(
            string keyword)
        {
            string sql = @"
                SELECT c.course_id,
                       c.course_code,
                       c.title,
                       c.credit_hours,
                       c.course_type,
                       c.dept_id,
                       d.dept_name,
                       c.is_active
                FROM   courses c
                JOIN   departments d
                    ON c.dept_id = d.dept_id
                WHERE  c.course_code
                           LIKE @kw
                    OR c.title
                           LIKE @kw
                    OR d.dept_name
                           LIKE @kw
                ORDER  BY c.course_code ASC";

            var p = new[]
            {
                new MySqlParameter(
                    "@kw", "%" + keyword + "%")
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql, p);

            var list = new List<Course>();
            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));
            return list;
        }

        // ── Get All For ComboBox ───────────────────────
        public static DataTable GetAllForCombo()
        {
            string sql = @"
                SELECT course_id,
                       CONCAT(course_code,
                              ' - ', title)
                           AS course_label
                FROM   courses
                WHERE  is_active = 1
                ORDER  BY course_code ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // ── Private mapper ────────────────────────────
        private static Course Map(DataRow row)
        {
            return new Course
            {
                CourseId =
                    Convert.ToInt32(
                        row["course_id"]),
                CourseCode =
                    row["course_code"].ToString(),
                Title =
                    row["title"].ToString(),
                CreditHours =
                    Convert.ToInt32(
                        row["credit_hours"]),
                CourseType =
                    row["course_type"].ToString(),
                DeptId =
                    Convert.ToInt32(
                        row["dept_id"]),
                DeptName =
                    row["dept_name"].ToString(),
                IsActive =
                    Convert.ToInt32(
                        row["is_active"]) == 1
            };
        }
    }
}