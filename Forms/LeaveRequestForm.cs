using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FacultyWorkloadSystem.DAL;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.Forms
{
    public partial class LeaveRequestForm : Form
    {
        private bool _isDragging = false;
        private Point _dragStart;

        public LeaveRequestForm()
        {
            InitializeComponent();
        }

        // ══════════════════════════════════════════════
        //  LOAD
        // ══════════════════════════════════════════════
        private void LeaveRequestForm_Load(
            object sender, EventArgs e)
        {
            try
            {
                SetupGrids();
                LoadLeaveTypeCombo();
                LoadMyRequests();
                LoadBalancePanel();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        // ══════════════════════════════════════════════
        //  COMBO — leave types
        // ══════════════════════════════════════════════
        private void LoadLeaveTypeCombo()
        {
            try
            {
                cboLeaveType.DataSource = null;
                cboLeaveType.Items.Clear();

                DataTable dt =
                    LeaveRequestDAL
                    .GetLeaveTypesForCombo();

                cboLeaveType.DataSource = dt;
                cboLeaveType.DisplayMember =
                    "leave_type_name";   // alias se match
                cboLeaveType.ValueMember =
                    "leave_type_id";     // alias se match
                cboLeaveType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        // ══════════════════════════════════════════════
        //  BALANCE PANEL
        // ══════════════════════════════════════════════
        private void LoadBalancePanel()
        {
            try
            {
                DataTable dt =
                   LeaveRequestDAL.GetBalance(
    SessionManager.EmpId.Value,
    DateTime.Today.Year);

                dgvBalance.Rows.Clear();

                if (dt.Rows.Count == 0)
                {
                    lblBalanceNote.Text =
                        "No leave balance " +
                        "records found for " +
                        "this year.";
                    lblBalanceNote.Visible = true;
                    return;
                }

                lblBalanceNote.Visible = false;

                foreach (DataRow row in dt.Rows)
                {
                    dgvBalance.Rows.Add(
                        row["leave_type_name"],
                        row["total_allowed"],
                        row["days_taken"],
                        row["days_remaining"]);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        // ══════════════════════════════════════════════
        //  DATE CHANGED — auto calc days
        // ══════════════════════════════════════════════
        private void dtpFrom_ValueChanged(
            object sender, EventArgs e)
        {
            CalcDays();
        }

        private void dtpTo_ValueChanged(
            object sender, EventArgs e)
        {
            CalcDays();
        }

        private void CalcDays()
        {
            if (dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                lblDaysCount.Text =
                    "End date before start!";
                lblDaysCount.ForeColor = Color.Red;
                return;
            }

            int days =
                LeaveRequestDAL.CalcWorkingDays(
                    dtpFrom.Value.Date,
                    dtpTo.Value.Date);

            lblDaysCount.Text =
                days + " working day(s)";
            lblDaysCount.ForeColor =
                Color.FromArgb(9, 74, 158);
        }

        // ══════════════════════════════════════════════
        //  GRID SETUP
        // ══════════════════════════════════════════════
        private void SetupGrids()
        {
            // ── Requests grid ──────────────────────────
            dgvRequests.Columns.Clear();
            dgvRequests
                .EnableHeadersVisualStyles = false;
            dgvRequests
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvRequests
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvRequests
                .ColumnHeadersDefaultCellStyle
                .Font = new Font(
                    "Segoe UI", 9f,
                    FontStyle.Bold);
            dgvRequests.ColumnHeadersHeight = 36;
            dgvRequests
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;
            dgvRequests.RowTemplate.Height = 30;
            dgvRequests.GridColor =
                Color.FromArgb(220, 230, 242);

            dgvRequests.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    Visible = false
                });

            dgvRequests.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colType",
                    HeaderText = "Leave Type",
                    Width = 140,
                    ReadOnly = true
                });

            dgvRequests.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colFrom",
                    HeaderText = "From",
                    Width = 110,
                    ReadOnly = true
                });

            dgvRequests.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colTo",
                    HeaderText = "To",
                    Width = 110,
                    ReadOnly = true
                });

            dgvRequests.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDays",
                    HeaderText = "Days",
                    Width = 60,
                    ReadOnly = true
                });

            dgvRequests.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colReason",
                    HeaderText = "Reason",
                    Width = 220,
                    ReadOnly = true
                });

            dgvRequests.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Status",
                    Width = 90,
                    ReadOnly = true
                });

            dgvRequests.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colRemarks",
                    HeaderText = "HOD Remarks",
                    Width = 160,
                    ReadOnly = true
                });

            dgvRequests.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colApplied",
                    HeaderText = "Applied On",
                    Width = 110,
                    ReadOnly = true
                });

            dgvRequests.Columns.Add(new DataGridViewButtonColumn
            {
                    Name = "colCancel",
                    HeaderText = "Action",
                    UseColumnTextForButtonValue = false, 
                    Width = 90,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = {
                    BackColor = Color.FromArgb(220, 53, 69),
                    ForeColor = Color.White }
            });

            // ── Balance grid ───────────────────────────
            dgvBalance.Columns.Clear();
            dgvBalance
                .EnableHeadersVisualStyles = false;
            dgvBalance
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvBalance
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvBalance
                .ColumnHeadersDefaultCellStyle
                .Font = new Font(
                    "Segoe UI", 9f,
                    FontStyle.Bold);
            dgvBalance.ColumnHeadersHeight = 32;
            dgvBalance.RowTemplate.Height = 28;
            dgvBalance.GridColor =
                Color.FromArgb(220, 230, 242);

            dgvBalance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colBType",
                    HeaderText = "Leave Type",
                    Width = 130,
                    ReadOnly = true
                });

            dgvBalance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colBAllowed",
                    HeaderText = "Allowed",
                    Width = 70,
                    ReadOnly = true
                });

            dgvBalance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colBTaken",
                    HeaderText = "Taken",
                    Width = 60,
                    ReadOnly = true
                });

            dgvBalance.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colBRemaining",
                    HeaderText = "Remaining",
                    Width = 80,
                    ReadOnly = true
                });
        }

        // ══════════════════════════════════════════════
        //  LOAD MY REQUESTS
        // ══════════════════════════════════════════════
        private void LoadMyRequests()
        {
            try
            {
                List<LeaveRequest> list =
       LeaveRequestDAL.GetByFaculty(
           SessionManager.EmpId.Value);

                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        private void PopulateGrid(List<LeaveRequest> list)
        {
            dgvRequests.Rows.Clear();
            foreach (LeaveRequest lr in list)
            {
                int idx = dgvRequests.Rows.Add(
                    lr.RequestId,
                    lr.LeaveTypeName,
                    lr.FromDate.ToString("dd MMM yyyy"),
                    lr.ToDate.ToString("dd MMM yyyy"),
                    lr.TotalDays,
                    lr.Reason,
                    lr.Status,
                    lr.ApprovalRemarks ?? "—",
                    lr.AppliedOn.ToString("dd MMM yyyy"));

                ColorStatusRow(idx, lr.Status);

                // Set Cancel button per row based on status
                var cancelCell = dgvRequests
                    .Rows[idx].Cells["colCancel"];

                if (lr.Status == "Pending")
                {
                    cancelCell.Value = "Cancel";
                    cancelCell.Style.BackColor = Color.FromArgb(220, 53, 69);
                    cancelCell.Style.ForeColor = Color.White;
                    cancelCell.Style.SelectionBackColor = Color.FromArgb(180, 30, 50);
                    cancelCell.Style.SelectionForeColor = Color.White;
                }
                else
                {
                    cancelCell.Value = "";
                    cancelCell.Style.BackColor = Color.FromArgb(240, 240, 240);
                    cancelCell.Style.ForeColor = Color.FromArgb(240, 240, 240);
                    cancelCell.Style.SelectionBackColor = Color.FromArgb(220, 230, 242);
                    cancelCell.Style.SelectionForeColor = Color.FromArgb(220, 230, 242);
                }
            }
        }

        private void ColorStatusRow(
            int rowIdx, string status)
        {
            Color bg;
            switch (status)
            {
                case "Approved":
                    bg = Color.FromArgb(220, 255, 220);
                    break;
                case "Rejected":
                    bg = Color.FromArgb(255, 220, 220);
                    break;
                default:
                    bg = Color.FromArgb(255, 252, 220);
                    break;
            }

            for (int c = 0;
                 c < dgvRequests.Columns.Count - 1;
                 c++)
            {
                dgvRequests.Rows[rowIdx]
                    .Cells[c].Style.BackColor = bg;
            }
        }

        // ══════════════════════════════════════════════
        //  SUBMIT REQUEST
        // ══════════════════════════════════════════════
        private void btnSave_Click(
            object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                int days =
                    LeaveRequestDAL.CalcWorkingDays(
                        dtpFrom.Value.Date,
                        dtpTo.Value.Date);

                
                   var lr = new LeaveRequest
{
    EmpId = SessionManager.EmpId.Value,
                    LeaveTypeId =
                        Convert.ToInt32(
                            cboLeaveType
                            .SelectedValue),
                    FromDate =
                        dtpFrom.Value.Date,
                    ToDate =
                        dtpTo.Value.Date,
                    TotalDays = days,
                    Reason =
                        txtReason.Text.Trim()
                };

                if (LeaveRequestDAL.Insert(lr))
                {
                    ValidationHelper.ShowSuccess(
                        "Leave request submitted.\n" +
                        "It will be reviewed by " +
                        "HOD/Admin.");
                    ClearForm();
                    LoadMyRequests();
                    LoadBalancePanel();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to submit request.");
            }
        }

        // ══════════════════════════════════════════════
        //  VALIDATION
        // ══════════════════════════════════════════════
        private bool ValidateInputs()
        {
            if (cboLeaveType.SelectedIndex < 0)
            {
                ValidationHelper.ShowError(
                    "Please select a Leave Type.");
                cboLeaveType.Focus();
                return false;
            }

            if (dtpFrom.Value.Date < DateTime.Today)
            {
                ValidationHelper.ShowError(
                    "From date cannot be in the past.");
                dtpFrom.Focus();
                return false;
            }

            if (dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                ValidationHelper.ShowError(
                    "End date must be on or " +
                    "after start date.");
                dtpTo.Focus();
                return false;
            }

            if (ValidationHelper.IsEmpty(
                txtReason.Text))
            {
                ValidationHelper.ShowError(
                    "Please provide a reason.");
                txtReason.Focus();
                return false;
            }

            if (LeaveRequestDAL.HasOverlap(
     SessionManager.EmpId.Value,
     dtpFrom.Value.Date,
     dtpTo.Value.Date))
            {
                ValidationHelper.ShowError(
                    "You already have a leave " +
                    "request for this date range.");
                return false;
            }

            return true;
        }

        // ══════════════════════════════════════════════
        //  CLEAR
        // ══════════════════════════════════════════════
        private void btnClear_Click(
            object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cboLeaveType.SelectedIndex = -1;
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            txtReason.Text = "";
            lblDaysCount.Text =
                "0 working day(s)";
            lblDaysCount.ForeColor =
                Color.FromArgb(9, 74, 158);
        }

        // ══════════════════════════════════════════════
        //  GRID CELL CLICK — Cancel pending request
        // ══════════════════════════════════════════════
        private void dgvRequests_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int cancelIdx =
                dgvRequests
                .Columns["colCancel"].Index;

            if (e.ColumnIndex != cancelIdx) return;

            string status =
                dgvRequests
                    .Rows[e.RowIndex]
                    .Cells["colStatus"]
                    .Value?.ToString() ?? "";

            if (status != "Pending")
            {
                ValidationHelper.ShowError(
                    "Only Pending requests " +
                    "can be cancelled.");
                return;
            }

            if (!ValidationHelper.Confirm(
                "Cancel this leave request?"))
                return;

            int id = Convert.ToInt32(
                dgvRequests
                    .Rows[e.RowIndex]
                    .Cells["colId"].Value);

            try
            {
                if (LeaveRequestDAL.Delete(id))
                {
                    ValidationHelper.ShowSuccess(
                        "Request cancelled.");
                    LoadMyRequests();
                    LoadBalancePanel();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to cancel request.");
            }
        }

        // ══════════════════════════════════════════════
        //  FILE MENU
        // ══════════════════════════════════════════════
        private void menuMaximize_Click(
            object sender, EventArgs e)
        {
            if (this.WindowState ==
                FormWindowState.Maximized)
            {
                this.WindowState =
                    FormWindowState.Normal;
                menuMaximize.Text = "Maximize";
            }
            else
            {
                this.WindowState =
                    FormWindowState.Maximized;
                menuMaximize.Text = "Restore";
            }
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
            ClearForm();
            LoadLeaveTypeCombo();
            LoadMyRequests();
            LoadBalancePanel();
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

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            LoadBalancePanel();
        }

        private void dgvRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex ==
                dgvRequests.Columns["colCancel"].Index)
            {
                string status = dgvRequests
                    .Rows[e.RowIndex]
                    .Cells["colStatus"]
                    .Value?.ToString() ?? "";

                if (status == "Pending")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(180, 30, 50);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.ForeColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(240, 240, 240);
                }

                e.FormattingApplied = true;
            }
        }
    }
}