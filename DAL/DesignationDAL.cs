using System;
using System.Collections.Generic;
using System.Data;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;
using MySql.Data.MySqlClient;

namespace FacultyWorkloadSystem.DAL
{
    public static class DesignationDAL
    {
        // ── Get All ───────────────────────────────────
        public static List<Designation> GetAll()
        {
            string sql = @"
                SELECT designation_id,
                       designation_name,
                       rank_order
                FROM   designations
                ORDER  BY rank_order ASC,
                          designation_name ASC";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql);

            var list = new List<Designation>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Designation
                {
                    DesignationId =
                        Convert.ToInt32(
                            row["designation_id"]),
                    DesignationName =
                        row["designation_name"]
                        .ToString(),
                    RankOrder =
                        Convert.ToInt32(
                            row["rank_order"])
                });
            }
            return list;
        }

        // ── Get All with Faculty Count ─────────────────
        public static DataTable GetAllWithFacultyCount()
        {
            string sql = @"
                SELECT   d.designation_id,
                         d.designation_name,
                         d.rank_order,
                         COUNT(f.emp_id)
                             AS faculty_count
                FROM     designations d
                LEFT JOIN faculty f
                       ON d.designation_id =
                          f.designation_id
                GROUP BY d.designation_id,
                         d.designation_name,
                         d.rank_order
                ORDER BY d.rank_order ASC,
                         d.designation_name ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // ── Get All for ComboBox ───────────────────────
        public static DataTable GetAllForCombo()
        {
            string sql = @"
                SELECT designation_id,
                       designation_name
                FROM   designations
                ORDER  BY rank_order ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // ── Get By Id ─────────────────────────────────
        public static Designation GetById(int id)
        {
            string sql = @"
                SELECT designation_id,
                       designation_name,
                       rank_order
                FROM   designations
                WHERE  designation_id = @id";

            var p = new[]
            {
                new MySqlParameter("@id", id)
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql, p);

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new Designation
            {
                DesignationId =
                    Convert.ToInt32(
                        row["designation_id"]),
                DesignationName =
                    row["designation_name"]
                    .ToString(),
                RankOrder =
                    Convert.ToInt32(
                        row["rank_order"])
            };
        }

        // ── Insert ────────────────────────────────────
        public static bool Insert(Designation d)
        {
            string sql = @"
                INSERT INTO designations
                    (designation_name, rank_order)
                VALUES
                    (@name, @rank)";

            var p = new[]
            {
                new MySqlParameter(
                    "@name", d.DesignationName),
                new MySqlParameter(
                    "@rank", d.RankOrder)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Update ────────────────────────────────────
        public static bool Update(Designation d)
        {
            string sql = @"
                UPDATE designations
                SET    designation_name = @name,
                       rank_order       = @rank
                WHERE  designation_id   = @id";

            var p = new[]
            {
                new MySqlParameter(
                    "@name", d.DesignationName),
                new MySqlParameter(
                    "@rank", d.RankOrder),
                new MySqlParameter(
                    "@id",   d.DesignationId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Delete ────────────────────────────────────
        public static bool Delete(int id)
        {
            string sql = @"
                DELETE FROM designations
                WHERE  designation_id = @id";

            var p = new[]
            {
                new MySqlParameter("@id", id)
            };

            return DatabaseHelper
                .ExecuteNonQuery(sql, p) > 0;
        }

        // ── Name Exists ───────────────────────────────
        public static bool NameExists(
            string name, int excludeId = 0)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   designations
                WHERE  designation_name = @name
                  AND  designation_id  != @ex";

            var p = new[]
            {
                new MySqlParameter("@name", name),
                new MySqlParameter("@ex",   excludeId)
            };

            object result =
                DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(result) > 0;
        }

        // ── Get Faculty Count ─────────────────────────
        public static int GetFacultyCount(
            int designationId)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM   faculty
                WHERE  designation_id = @id";

            var p = new[]
            {
                new MySqlParameter(
                    "@id", designationId)
            };

            object result =
                DatabaseHelper.ExecuteScalar(sql, p);
            return Convert.ToInt32(result);
        }

        // ── Has Faculty (reuses GetFacultyCount) ──────
        public static bool HasFaculty(int id)
        {
            return GetFacultyCount(id) > 0;
        }

        // ── Search ────────────────────────────────────
        public static List<Designation> Search(
            string keyword)
        {
            string sql = @"
                SELECT designation_id,
                       designation_name,
                       rank_order
                FROM   designations
                WHERE  designation_name
                       LIKE @kw
                ORDER  BY rank_order ASC";

            var p = new[]
            {
                new MySqlParameter(
                    "@kw", "%" + keyword + "%")
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(sql, p);

            var list = new List<Designation>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Designation
                {
                    DesignationId =
                        Convert.ToInt32(
                            row["designation_id"]),
                    DesignationName =
                        row["designation_name"]
                        .ToString(),
                    RankOrder =
                        Convert.ToInt32(
                            row["rank_order"])
                });
            }
            return list;
        }
    }
}