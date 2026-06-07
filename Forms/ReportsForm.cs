using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FacultyWorkloadSystem.DAL;
using FacultyWorkloadSystem.Helpers;

namespace FacultyWorkloadSystem.Forms
{
    public partial class ReportsForm : Form
    {
        private bool _isDragging = false;
        private Point _dragStart;

        public ReportsForm()
        {
            InitializeComponent();
        }

        //  FORM LOAD
        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Select first item by default
            if (cboReportType.Items.Count > 0)
            {
                cboReportType.SelectedIndex = 0;
            }
        }

        //  GENERATE PDF BUTTON
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboReportType.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select a report.");
                return;
            }

            string reportName = cboReportType.SelectedItem.ToString();

            // Show busy cursor
            this.Cursor = Cursors.WaitCursor;
            btnGenerate.Enabled = false;
            btnGenerate.Text = "Generating...";

            try
            {
                string filePath = GenerateSelectedReport(reportName);

                if (string.IsNullOrEmpty(filePath))
                {
                    return;
                }
                ValidationHelper.ShowSuccess("Report generated successfully!\n" + "Opening PDF...");

                // Open the PDF
                PdfHelper.OpenPdf(filePath);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to generate report.\n" + "Error: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGenerate.Enabled = true;
                btnGenerate.Text = "Generate PDF";
            }
        }

        //  ROUTE TO CORRECT REPORT
        private string GenerateSelectedReport(string reportName)
        {
            DataTable dt;
            int index = cboReportType.SelectedIndex;

            switch (index)
            {
                case 0:
                    dt = ReportsDAL.GetFacultyStatus();
                    return PdfHelper.GenerateFacultyStatusReport(dt);

                case 1:
                    dt = ReportsDAL.GetDepartmentFaculty();
                    return PdfHelper.GenerateDepartmentFacultyReport(dt);

                case 2:
                    dt = ReportsDAL.GetAcademicCalendar();
                    return PdfHelper.GenerateAcademicCalendarReport(dt);

                case 3:
                    dt = ReportsDAL.GetFacultyWorkload();
                    return PdfHelper.GenerateFacultyWorkloadReport(dt);

                case 4:
                    dt = ReportsDAL.GetFacultyCourseAssignment();
                    return PdfHelper.GenerateFacultyCourseAssignmentReport(dt);

                case 5:
                    dt = ReportsDAL.GetTimetable();
                    return PdfHelper.GenerateTimetableReport(dt);

                case 6:
                    dt = ReportsDAL.GetSemesterWorkloadSummary();
                    return PdfHelper.GenerateSemesterWorkloadSummaryReport(dt);

                case 7:
                    dt = ReportsDAL.GetCourseDistribution();
                    return PdfHelper.GenerateCourseDistributionReport(dt);

                case 8:
                    dt = ReportsDAL.GetRoomUtilization();
                    return PdfHelper.GenerateRoomUtilizationReport(dt);

                case 9:
                    dt = ReportsDAL.GetFacultyChangeHistory();
                    return PdfHelper.GenerateFacultyChangeHistoryReport(dt);

                default:
                    ValidationHelper.ShowError("Please select a valid report.");
                    return null;
            }
        }

        //  FILE MENU
        private void menuMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                menuMaximize.Text = "Maximize";
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                menuMaximize.Text = "Restore";
            }
        }

        private void menuMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //  DRAG
        private void gradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragStart = e.Location;
            }
        }

        private void gradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point cur = this.PointToScreen(e.Location);
                this.Location = new Point(cur.X - _dragStart.X, cur.Y - _dragStart.Y);
            }
        }

        private void gradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }
    }
}