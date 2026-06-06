using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FacultyWorkloadSystem.DAL;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.Forms
{
    public partial class AttendanceForm : Form
    {
        private bool _isDragging = false;
        private Point _dragStart;

        public AttendanceForm()
        {
            InitializeComponent();
        }

        // ══════════════════════════════════════════════
        //  LOAD 
        // ══════════════════════════════════════════════
        private void AttendanceForm_Load(
            object sender, EventArgs e)
        {
            SetupGrid();
            ApplyRoleRestrictions();
            dtpDate.Value = DateTime.Today;
            RefreshForDate(DateTime.Today);
        }

        // ══════════════════════════════════════════════
        //  DATE CHANGED
        // ══════════════════════════════════════════════
        private void dtpDate_ValueChanged(
            object sender, EventArgs e)
        {
            RefreshForDate(dtpDate.Value.Date);
        }

        // ══════════════════════════════════════════════
        //  MAIN REFRESH — all logic here
        // ══════════════════════════════════════════════
        private void RefreshForDate(DateTime date)
        {
            bool isWorking =
                AttendanceDAL.IsWorkingDay(date);

            lblDateDisplay.Text =
                date.ToString(
                    "dddd, dd MMMM yyyy");

            if (!isWorking)
            {
                string reason =
                    AttendanceDAL
                    .GetBlockReason(date);

                // Show warning
                pnlWarning.Visible = true;
                lblWarning.Text =
                    "  Attendance cannot be " +
                    "marked: " + reason;

                // Disable buttons
                btnMarkAll.Enabled = false;
                btnSaveAll.Enabled = false;

                // Clear grid but don't crash
                dgvAttendance.Rows.Clear();
                UpdateSummary(0, 0, 0, 0, 0);
                return;
            }

            // Working day
            pnlWarning.Visible = false;
            btnMarkAll.Enabled = true;
            btnSaveAll.Enabled = true;

            LoadGridForDate(date);
        }

        // ══════════════════════════════════════════════
        //  LOAD GRID — uses DAL
        // ══════════════════════════════════════════════
        private void LoadGridForDate(DateTime date)
        {
            try
            {
                dgvAttendance.Rows.Clear();

                DataTable dt = SessionManager.IsFaculty ? AttendanceDAL.GetFacultyOwnAttendance(SessionManager.EmpId.Value, date) : AttendanceDAL.GetFacultyForDate(date);

                if (dt == null ||
                    dt.Rows.Count == 0)
                {
                    UpdateSummary(0, 0, 0, 0, 0);
                    return;
                }

                int present = 0, absent = 0,
                    leave = 0, late = 0,
                    notMarked = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string status =
                        row["att_status"].ToString();
                    int attId =
                        Convert.ToInt32(
                            row["att_id"]);

                    // Default to Present in combo
                    // if not yet marked
                    string comboVal =
                        status == "Not Marked"
                        ? "Present"
                        : status;

                    dgvAttendance.Rows.Add(
                        attId,
                        row["emp_id"],
                        row["faculty_name"],
                        row["dept_name"],
                        row["designation_name"],
                        comboVal,
                        row["remarks"].ToString(),
                        status == "Not Marked"
                            ? "Pending"
                            : "Saved");

                    switch (status)
                    {
                        case "Present":
                            present++; break;
                        case "Absent":
                            absent++; break;
                        case "Leave":
                            leave++; break;
                        case "Late":
                            late++; break;
                        default:
                            notMarked++; break;
                    }
                }

                UpdateSummary(
                    present, absent,
                    late, leave, notMarked);
            }
            catch (Exception ex)
            {
             
                LogManager.LogError(ex);
                UpdateSummary(0, 0, 0, 0, 0);
            }
        }

        // ══════════════════════════════════════════════
        //  GRID SETUP
        // ══════════════════════════════════════════════
        private void SetupGrid()
        {
            dgvAttendance.Columns.Clear();
            dgvAttendance
                .EnableHeadersVisualStyles = false;
            dgvAttendance
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvAttendance
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvAttendance
                .ColumnHeadersDefaultCellStyle
                .Font = new Font(
                    "Segoe UI", 9f,
                    FontStyle.Bold);
            dgvAttendance.ColumnHeadersHeight = 36;
            dgvAttendance
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;
            dgvAttendance.RowTemplate.Height = 34;
            dgvAttendance.GridColor =
                Color.FromArgb(220, 230, 242);
            dgvAttendance.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            // Hidden columns
            dgvAttendance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colAttId",
                    Visible = false
                });
            dgvAttendance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colEmpId",
                    Visible = false
                });

            // Visible columns
            dgvAttendance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colName",
                    HeaderText = "Faculty Name",
                    Width = 220,
                    ReadOnly = true
                });
            dgvAttendance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDept",
                    HeaderText = "Department",
                    Width = 180,
                    ReadOnly = true
                });
            dgvAttendance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDesig",
                    HeaderText = "Designation",
                    Width = 160,
                    ReadOnly = true
                });

            // Status ComboBox
            var cboCol =
                new DataGridViewComboBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Status",
                    Width = 130,
                    FlatStyle = FlatStyle.Flat
                };
            cboCol.Items.AddRange(new object[]
            {
                "Present", "Absent",
                "Leave",   "Late"
            });
            dgvAttendance.Columns.Add(cboCol);

            dgvAttendance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colRemarks",
                    HeaderText = "Remarks",
                    Width = 200,
                    ReadOnly = false
                });

            dgvAttendance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colRecord",
                    HeaderText = "Record",
                    Width = 80,
                    ReadOnly = true
                });

            // Save button
            dgvAttendance.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colSave",
                    HeaderText = "Save",
                    Text = "Save",
                    UseColumnTextForButtonValue =
                        true,
                    Width = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = {
                        BackColor =
                            Color.FromArgb(
                                33, 145, 245),
                        ForeColor = Color.White
                    }
                });
        }

        // ══════════════════════════════════════════════
        //  CELL CLICK — per row Save
        // ══════════════════════════════════════════════
        private void dgvAttendance_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int saveIdx =
                dgvAttendance
                .Columns["colSave"].Index;

            if (e.ColumnIndex == saveIdx)
                SaveRow(e.RowIndex);
        }

        private void SaveRow(int rowIndex)
        {
            try
            {
                var row =
                    dgvAttendance.Rows[rowIndex];

                int attId =
                    Convert.ToInt32(
                        row.Cells["colAttId"].Value);
                int empId =
                    Convert.ToInt32(
                        row.Cells["colEmpId"].Value);

                object sv =
                    row.Cells["colStatus"].Value;
                if (sv == null)
                {
                    ValidationHelper.ShowError(
                        "Please select a status.");
                    return;
                }

                string status = sv.ToString();
                string remarks =
                    row.Cells["colRemarks"]
                    .Value?.ToString() ?? "";

                var att = new Attendance
                {
                    AttendanceId = attId,
                    EmpId = empId,
                    AttDate =
                        dtpDate.Value.Date,
                    Status = status,
                    Remarks = remarks,
                    MarkedBy = SessionManager.UserId
                };

                bool ok = (attId == 0)
                    ? AttendanceDAL.Insert(att)
                    : AttendanceDAL.Update(att);

                if (ok)
                {
                    row.Cells["colRecord"].Value =
                        "Saved";
                    row.DefaultCellStyle
                        .BackColor =
                        Color.FromArgb(
                            230, 255, 235);

                    // Refresh to get new att_id
                    LoadGridForDate(
                        dtpDate.Value.Date);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to save this row.");
            }
        }

        // ══════════════════════════════════════════════
        //  MARK ALL PRESENT
        // ══════════════════════════════════════════════
        private void btnMarkAll_Click(
            object sender, EventArgs e)
        {
            if (SessionManager.IsFaculty) return;

            if (!ValidationHelper.Confirm(
                "Mark all unmarked faculty as " +
                "Present for " +
                dtpDate.Value.ToString(
                    "dd MMM yyyy") + "?"))
                return;

            try
            {
                int count =
                    AttendanceDAL.BulkMarkPresent(
                        dtpDate.Value.Date,
                        SessionManager.UserId);

                if (count > 0)
                    ValidationHelper.ShowSuccess(
                        count +
                        " faculty marked Present.");
                else
                    ValidationHelper.ShowSuccess(
                        "All faculty already marked.");

                LoadGridForDate(
                    dtpDate.Value.Date);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Bulk mark failed.");
            }
        }

        // ══════════════════════════════════════════════
        //  SAVE ALL
        // ══════════════════════════════════════════════
        private void btnSaveAll_Click(
            object sender, EventArgs e)
        {
            int saved = 0, failed = 0;

            if (SessionManager.IsFaculty) return;

            for (int i = 0;
                 i < dgvAttendance.Rows.Count;
                 i++)
            {
                try
                {
                    var row = dgvAttendance.Rows[i];
                    int attId =
                        Convert.ToInt32(
                            row.Cells["colAttId"]
                            .Value);
                    int empId =
                        Convert.ToInt32(
                            row.Cells["colEmpId"]
                            .Value);

                    object sv =
                        row.Cells["colStatus"]
                        .Value;
                    if (sv == null) continue;

                    string status =
                        sv.ToString();
                    string remarks =
                        row.Cells["colRemarks"]
                        .Value?.ToString() ?? "";

                    var att = new Attendance
                    {
                        AttendanceId = attId,
                        EmpId = empId,
                        AttDate =
                            dtpDate.Value.Date,
                        Status = status,
                        Remarks = remarks,
                        MarkedBy = SessionManager.UserId
                    };

                    bool ok = (attId == 0)
                        ? AttendanceDAL.Insert(att)
                        : AttendanceDAL.Update(att);

                    if (ok)
                    {
                        saved++;
                        row.Cells["colRecord"]
                            .Value = "Saved";
                        row.DefaultCellStyle
                            .BackColor =
                            Color.FromArgb(
                                230, 255, 235);
                    }
                    else failed++;
                }
                catch { failed++; }
            }

            string msg =
                saved + " record(s) saved.";
            if (failed > 0)
                msg += " " + failed + " failed.";

            ValidationHelper.ShowSuccess(msg);
            LoadGridForDate(dtpDate.Value.Date);
        }

        // ══════════════════════════════════════════════
        //  CELL FORMATTING — color by status
        // ══════════════════════════════════════════════
        private void dgvAttendance_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = sender as DataGridView;
            int si =
                dgv.Columns["colStatus"].Index;
            int saveI =
                dgv.Columns["colSave"].Index;

            if (e.ColumnIndex == si &&
                e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "Present":
                        e.CellStyle.BackColor =
                            Color.FromArgb(
                                220, 255, 220);
                        e.CellStyle.ForeColor =
                            Color.FromArgb(
                                20, 120, 40);
                        break;
                    case "Absent":
                        e.CellStyle.BackColor =
                            Color.FromArgb(
                                255, 220, 220);
                        e.CellStyle.ForeColor =
                            Color.FromArgb(
                                180, 30, 30);
                        break;
                    case "Leave":
                        e.CellStyle.BackColor =
                            Color.FromArgb(
                                255, 245, 200);
                        e.CellStyle.ForeColor =
                            Color.FromArgb(
                                160, 110, 0);
                        break;
                    case "Late":
                        e.CellStyle.BackColor =
                            Color.FromArgb(
                                220, 210, 255);
                        e.CellStyle.ForeColor =
                            Color.FromArgb(
                                80, 40, 160);
                        break;
                }
            }
            if (e.ColumnIndex == saveI)
            {
                e.CellStyle.BackColor = Color.FromArgb(33, 145, 245);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(10, 100, 200);
                e.CellStyle.SelectionForeColor = Color.White;
                e.FormattingApplied = true;
            }
        }

        // ══════════════════════════════════════════════
        //  STATS UPDATE
        // ══════════════════════════════════════════════
        private void UpdateSummary(
            int present, int absent,
            int late, int leave, int notMarked)
        {
            lblPresent.Text =
                "Present: " + present;
            lblAbsent.Text =
                "Absent: " + absent;
            lblLate.Text =
                "Late: " + late;
            lblLeave.Text =
                "Leave: " + leave;
            lblPending.Text =
                "Pending: " + notMarked;
        }

        // ══════════════════════════════════════════════
        //  FILE MENU
        // ══════════════════════════════════════════════
        private void menuMaximize_Click(
            object sender, EventArgs e)
        {
            this.WindowState =
                this.WindowState ==
                FormWindowState.Maximized
                ? FormWindowState.Normal
                : FormWindowState.Maximized;

            menuMaximize.Text =
                this.WindowState ==
                FormWindowState.Maximized
                ? "Restore" : "Maximize";
        }

        private void menuMinimize_Click(
            object sender, EventArgs e)
        {
            this.WindowState =
                FormWindowState.Minimized;
        }

        private void menuRefresh_Click(
            object sender, EventArgs e)
        {
            RefreshForDate(dtpDate.Value.Date);
        }

        private void menuClose_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        // ══════════════════════════════════════════════
        //  DRAG
        // ══════════════════════════════════════════════
        private void gradientPanel1_MouseDown(
            object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragStart = e.Location;
            }
        }

        private void gradientPanel1_MouseMove(
            object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point cur =
                    this.PointToScreen(e.Location);
                this.Location = new Point(
                    cur.X - _dragStart.X,
                    cur.Y - _dragStart.Y);
            }
        }

        private void gradientPanel1_MouseUp(
            object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        // ══════════════════════════════════════════════
        //  ROLE RESTRICTIONS
        // ══════════════════════════════════════════════
        private void ApplyRoleRestrictions()
        {
            if (!SessionManager.IsFaculty) return;

            // Hide action buttons
            btnMarkAll.Visible = false;
            btnSaveAll.Visible = false;

            // Hide Save column
            dgvAttendance.Columns["colSave"].Visible
                = false;

            // Make Status read-only
            dgvAttendance.Columns["colStatus"].ReadOnly
                = true;

            // Make Remarks read-only
            dgvAttendance.Columns["colRemarks"].ReadOnly
                = true;

            // Lock date picker — faculty views
            // any date but cannot mark
            dtpDate.Enabled = true; // can browse dates
        }
    }
}