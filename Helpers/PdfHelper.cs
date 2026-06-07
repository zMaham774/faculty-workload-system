using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using FacultyWorkloadSystem.Helpers;

namespace FacultyWorkloadSystem.Helpers
{
    public static class PdfHelper
    {
        // Output folder
        private static readonly string _outputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Resources", "reports");

        // Colours
        private static readonly BaseColor _headerColor = new BaseColor(9, 74, 158);

        private static readonly BaseColor _altRowColor = new BaseColor(240, 248, 255);

        private static readonly BaseColor _white = BaseColor.WHITE;

        private static readonly BaseColor _borderColor = new BaseColor(200, 215, 235);

        // Fonts 
        private static readonly Font _fontTitle = new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD, BaseColor.WHITE);

        private static readonly Font _fontSubtitle = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, new BaseColor(100, 100, 100));

        private static readonly Font _fontTableHeader = new Font(Font.FontFamily.HELVETICA, 9f, Font.BOLD, BaseColor.WHITE);

        private static readonly Font _fontTableCell = new Font(Font.FontFamily.HELVETICA, 8.5f, Font.NORMAL, new BaseColor(40, 40, 40));

        private static readonly Font _fontFooter = new Font(Font.FontFamily.HELVETICA, 8f, Font.ITALIC, new BaseColor(130, 130, 130));

        //  PUBLIC REPORT METHODS

        public static string GenerateFacultyStatusReport(DataTable dt)
        {
            return GenerateReport(dt, "Faculty Status Report","All Faculty Members - Status Overview", "faculty_status");
        }

        public static string GenerateDepartmentFacultyReport(DataTable dt)
        {
            return GenerateReport(dt, "Department Faculty Report", "Faculty Distribution by Department", "department_faculty");
        }

        public static string GenerateAcademicCalendarReport(DataTable dt)
        {
            return GenerateReport(dt,"Academic Calendar Report", "Events and Holidays by Semester", "academic_calendar", PageSize.A4.Rotate());
        }

        public static string GenerateFacultyWorkloadReport(DataTable dt)
        {
            return GenerateReport(dt, "Faculty Workload Report", "Workload Summary per Faculty", "faculty_workload", PageSize.A4.Rotate());
        }

        public static string GenerateFacultyCourseAssignmentReport(DataTable dt)
        {
            return GenerateReport(dt,"Faculty Course Assignment Report", "Course Assignments per Faculty", "faculty_course_assignment", PageSize.A4.Rotate());
        }

        public static string
    GenerateTimetableReport(DataTable dt)
        {
            return GenerateReport(
                dt,
                "Timetable Report",
                "Weekly Schedule by Faculty",
                "timetable",
                PageSize.A4.Rotate());
        }

        public static string
            GenerateSemesterWorkloadSummaryReport(
                DataTable dt)
        {
            return GenerateReport(
                dt,
                "Semester Workload Summary",
                "Workload Distribution by Semester and Department",
                "semester_workload_summary",
                PageSize.A4.Rotate());
        }

        public static string GenerateCourseDistributionReport(DataTable dt)
        {
            return GenerateReport(dt, "Course Distribution Report", "Course Assignment Statistics by Department", "course_distribution", PageSize.A4.Rotate());
        }

        public static string GenerateRoomUtilizationReport(DataTable dt)
        {
            return GenerateReport(dt, "Room Utilization Report", "Room Usage and Slot Allocation", "room_utilization");
        }

        public static string GenerateFacultyChangeHistoryReport(DataTable dt)
        {
            return GenerateReport(dt, "Faculty Change History Report", "Audit Log of Faculty Record Changes", "faculty_change_history", PageSize.A4.Rotate());
        }

        // CORE ENGINE
        private static string GenerateReport(DataTable dt, string title, string subtitle, string filePrefix, Rectangle pageSize = null)
        {
            if (pageSize == null)
            {
                pageSize = PageSize.A4;
            }
            // Ensure output folder exists
            if (!Directory.Exists(_outputFolder))
            {
                Directory.CreateDirectory(_outputFolder);
            }
            string fileName = $"{filePrefix}_" + $"{DateTime.Now:yyyyMMdd_HHmmss}" + ".pdf";

            string filePath = Path.Combine(_outputFolder, fileName);

            using (var doc = new Document(pageSize, 30, 30, 40, 30))
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                doc.Open();

                // Header band
                AddHeader(doc, title, subtitle);

                // Table
                AddTable(doc, dt);

                // Footer
                AddFooter(doc);

                doc.Close();
            }

            return filePath;
        }

        //  HEADER
        private static void AddHeader(Document doc, string title, string subtitle)
        {
            // Title band
            PdfPTable header = new PdfPTable(1);
            header.WidthPercentage = 100f;
            header.SpacingAfter = 12f;

            var titleCell = new PdfPCell(new Phrase(title, _fontTitle))
            {
                BackgroundColor = _headerColor,
                Border = Rectangle.NO_BORDER,
                Padding = 14f,
                HorizontalAlignment = Element.ALIGN_CENTER
            };

            header.AddCell(titleCell);
            doc.Add(header);

            // Subtitle + generated info
            PdfPTable sub = new PdfPTable(2);
            sub.WidthPercentage = 100f;
            sub.SpacingAfter = 16f;
            sub.SetWidths(new float[] { 70f, 30f });

            sub.AddCell(new PdfPCell(new Phrase(subtitle, _fontSubtitle))
            {
                Border = Rectangle.NO_BORDER,
                Padding = 4f
            });

            sub.AddCell(new PdfPCell(new Phrase("Generated: " + DateTime.Now.ToString("dd MMM yyyy  HH:mm"), _fontSubtitle))
            {
                Border = Rectangle.NO_BORDER,
                Padding = 4f,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });

            doc.Add(sub);
        }

        //  DATA TABLE
        private static void AddTable(Document doc, DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                doc.Add(new Paragraph("No data available " + "for this report.", _fontSubtitle));
                return;
            }

            int colCount = dt.Columns.Count;

            PdfPTable table = new PdfPTable(colCount);
            table.WidthPercentage = 100f;
            table.SpacingBefore = 5f;

            // Equal column widths
            float[] widths = new float[colCount];
            for (int i = 0; i < colCount; i++)
                widths[i] = 100f / colCount;
            table.SetWidths(widths);

            // Column headers
            foreach (DataColumn col in dt.Columns)
            {
                table.AddCell(
                    new PdfPCell(new Phrase(col.ColumnName, _fontTableHeader))
                    {
                        BackgroundColor = _headerColor,
                        Border = Rectangle.NO_BORDER,
                        Padding = 7f,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
            }

            // Data rows
            bool alt = false;
            foreach (DataRow row in dt.Rows)
            {
                BaseColor rowColor = alt ? _altRowColor : _white;
                alt = !alt;

                foreach (DataColumn col in dt.Columns)
                {
                    string val = row[col] == DBNull.Value ? "—" : row[col].ToString();

                    // Format dates 
                    if (row[col] is DateTime dt2)
                    {
                        val = dt2.ToString("dd/MM/yyyy");
                    }
                    table.AddCell(new PdfPCell(new Phrase(val, _fontTableCell))
                        {
                            BackgroundColor = rowColor,
                            BorderColor = _borderColor,
                            BorderWidth = 0.3f,
                            Padding = 5f
                        });
                }
            }

            doc.Add(table);

            // Row count
            doc.Add(new Paragraph($"\nTotal records: " + $"{dt.Rows.Count}", _fontSubtitle)
            {
                SpacingBefore = 6f
            });
        }

        //  FOOTER
        private static void AddFooter(Document doc)
        {
            doc.Add(new Paragraph("\n\n" + "Faculty Workload & Attendance " + "Management System  •  " + "Confidential  •  " + DateTime.Now.ToString("yyyy"), _fontFooter)
            {
                Alignment = Element.ALIGN_CENTER
            });
        }

        //  OPEN PDF AFTER GENERATING
        public static void OpenPdf(string path)
        {
            if (!File.Exists(path)) return;

            // Edge 
            string edgePath =
                @"C:\Program Files (x86)\" +
                @"Microsoft\Edge\Application\" +
                @"msedge.exe";

            if (File.Exists(edgePath))
            {
                System.Diagnostics.Process.Start(
                    edgePath,
                    "\"" + path + "\"");
                return;
            }

            // Chrome fallback
            string chromePath =
                @"C:\Program Files\Google\" +
                @"Chrome\Application\chrome.exe";

            if (File.Exists(chromePath))
            {
                System.Diagnostics.Process.Start(
                    chromePath,
                    "\"" + path + "\"");
                return;
            }

            // Last resort — Windows default handler
            System.Diagnostics.Process.Start(
                new System.Diagnostics
                    .ProcessStartInfo(path)
                {
                    UseShellExecute = true
                });
        }
    }
}