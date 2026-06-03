using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacultyWorkloadSystem.DAL;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.Forms
{
    public partial class LeaveApprovalForm : Form
    {
        private bool _isDragging = false;
        private Point _dragStart;
        private int _selectedLrId = 0;

        public LeaveApprovalForm()
        {
            InitializeComponent();
        }

        // ══════════════════════════════════════════
        //  LOAD
        // ══════════════════════════════════════════
        private void LeaveApprovalForm_Load(
            object sender, EventArgs e)
        {
            try
            {
                SetupGrid();
                LoadFilterCombo();
                LoadRequests();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        // ══════════════════════════════════════════
        //  FILTER COMBO SETUP
        // ══════════════════════════════════════════
        private void LoadFilterCombo()
        {
            cboFilter.Items.Clear();
            cboFilter.Items.AddRange(new object[]
            {
                "All",
                "Pending",
                "Approved",
                "Rejected"
            });
            cboFilter.SelectedIndex = 1; // Pending
        }

        // ══════════════════════════════════════════
        //  GRID SETUP
        // ══════════════════════════════════════════
        private void SetupGrid()
        {
            dgvApproval.Columns.Clear();
            dgvApproval
                .EnableHeadersVisualStyles = false;
            dgvApproval
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvApproval
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvApproval
                .ColumnHeadersDefaultCellStyle
                .Font = new Font(
                    "Segoe UI", 9f,
                    FontStyle.Bold);
            dgvApproval.ColumnHeadersHeight = 36;
            dgvApproval
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;
            dgvApproval.RowTemplate.Height = 32;
            dgvApproval.GridColor =
                Color.FromArgb(220, 230, 242);
            dgvApproval.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    Visible = false
                });

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colFaculty",
                    HeaderText = "Faculty Name",
                    Width = 180,
                    ReadOnly = true
                });

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDept",
                    HeaderText = "Department",
                    Width = 150,
                    ReadOnly = true
                });

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colType",
                    HeaderText = "Leave Type",
                    Width = 120,
                    ReadOnly = true
                });

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colFrom",
                    HeaderText = "From",
                    Width = 100,
                    ReadOnly = true
                });

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colTo",
                    HeaderText = "To",
                    Width = 100,
                    ReadOnly = true
                });

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDays",
                    HeaderText = "Days",
                    Width = 55,
                    ReadOnly = true
                });

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colReason",
                    HeaderText = "Reason",
                    Width = 200,
                    ReadOnly = true
                });

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Status",
                    Width = 90,
                    ReadOnly = true
                });

            dgvApproval.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colApplied",
                    HeaderText = "Applied On",
                    Width = 110,
                    ReadOnly = true
                });

            dgvApproval.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colApprove",
                    HeaderText = "Approve",
                    Text = "✔ Approve",
                    UseColumnTextForButtonValue =
                        true,
                    Width = 100,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = {
                        BackColor =
                            Color.FromArgb(
                                13, 140, 106),
                        ForeColor =
                            Color.White }
                });

            dgvApproval.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colReject",
                    HeaderText = "Reject",
                    Text = "✖ Reject",
                    UseColumnTextForButtonValue =
                        true,
                    Width = 90,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = {
                        BackColor =
                            Color.FromArgb(
                                220, 53, 69),
                        ForeColor =
                            Color.White }
                });
        }

        // ══════════════════════════════════════════
        //  LOAD DATA
        // ══════════════════════════════════════════
        private void LoadRequests()
        {
            try
            {
                string status =
                    cboFilter.SelectedItem?
                    .ToString() ?? "All";
                string kw =
                    txtSearch.Text.Trim();

                List<LeaveRequest> list =
                    LeaveApprovalDAL
                    .GetFiltered(status, kw);

                PopulateGrid(list);
                UpdateCountLabel(list.Count);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        private void PopulateGrid(
            List<LeaveRequest> list)
        {
            dgvApproval.Rows.Clear();

            foreach (LeaveRequest lr in list)
            {
                int idx = dgvApproval.Rows.Add(
                    lr.RequestId,
                    lr.FacultyName,
                    lr.DeptName,
                    lr.LeaveTypeName,
                    lr.FromDate.ToString(
                        "dd MMM yyyy"),
                    lr.ToDate.ToString(
                        "dd MMM yyyy"),
                    lr.TotalDays,
                    lr.Reason,
                    lr.Status,
                    lr.AppliedOn.ToString(
                        "dd MMM yyyy"));

                // Color by status
                Color bg;
                switch (lr.Status)
                {
                    case "Approved":
                        bg = Color.FromArgb(
                            220, 255, 220);
                        break;
                    case "Rejected":
                        bg = Color.FromArgb(
                            255, 220, 220);
                        break;
                    default:
                        bg = Color.FromArgb(
                            255, 252, 220);
                        break;
                }

                // Color only text cells
                for (int c = 0; c <= 9; c++)
                {
                    dgvApproval.Rows[idx]
                        .Cells[c].Style
                        .BackColor = bg;
                }

                // Hide Approve/Reject buttons
                // for already-decided requests
                if (lr.Status != "Pending")
                {
                    dgvApproval.Rows[idx]
                        .Cells["colApprove"]
                        .Value = "";
                    dgvApproval.Rows[idx]
                        .Cells["colReject"]
                        .Value = "";
                }
            }
        }

        private void UpdateCountLabel(int count)
        {
            lblCount.Text =
                "Showing " + count +
                " record(s)";
        }

        // ══════════════════════════════════════════
        //  CELL CLICK — Approve / Reject
        // ══════════════════════════════════════════
        private void dgvApproval_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int approveIdx =
                dgvApproval
                .Columns["colApprove"].Index;
            int rejectIdx =
                dgvApproval
                .Columns["colReject"].Index;

            string status =
                dgvApproval.Rows[e.RowIndex]
                    .Cells["colStatus"]
                    .Value?.ToString() ?? "";

            if (status != "Pending")
            {
                if (e.ColumnIndex == approveIdx
                 || e.ColumnIndex == rejectIdx)
                {
                    ValidationHelper.ShowError(
                        "This request has already " +
                        "been " + status + ".");
                }
                return;
            }

            int lrId = Convert.ToInt32(
                dgvApproval.Rows[e.RowIndex]
                    .Cells["colId"].Value);

            string facultyName =
                dgvApproval.Rows[e.RowIndex]
                    .Cells["colFaculty"]
                    .Value?.ToString() ?? "";

            if (e.ColumnIndex == approveIdx)
                ShowApproveDialog(
                    lrId, facultyName, true);
            else if (e.ColumnIndex == rejectIdx)
                ShowApproveDialog(
                    lrId, facultyName, false);
        }

        // ══════════════════════════════════════════
        //  APPROVE / REJECT DIALOG
        // ══════════════════════════════════════════
        private void ShowApproveDialog(
            int lrId,
            string facultyName,
            bool isApprove)
        {
            string action =
                isApprove ? "APPROVE" : "REJECT";
            string actionLower =
                isApprove ? "approve" : "reject";

            // Remarks input dialog
            Form dlg = new Form
            {
                Text = action + " LEAVE",
                Size = new Size(480, 240),
                FormBorderStyle =
                    FormBorderStyle.FixedDialog,
                StartPosition =
                    FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label
            {
                Text =
                    action + " leave for: " +
                    facultyName + "\n\n" +
                    "Remarks (optional):",
                Location = new Point(16, 16),
                Size = new Size(440, 50),
                Font = new Font(
                    "Segoe UI", 9f,
                    FontStyle.Bold)
            };

            TextBox txtRem = new TextBox
            {
                Location = new Point(16, 74),
                Size = new Size(440, 60),
                Multiline = true,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font(
                    "Segoe UI", 9f)
            };

            Button btnOk = new Button
            {
                Text = action,
                Location = new Point(220, 154),
                Size = new Size(110, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor =
                    isApprove
                    ? Color.FromArgb(13, 140, 106)
                    : Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Font = new Font(
                    "Segoe UI", 9f,
                    FontStyle.Bold),
                DialogResult = DialogResult.OK
            };
            btnOk.FlatAppearance.BorderSize = 0;

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(346, 154),
                Size = new Size(110, 36),
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel,
                Font = new Font(
                    "Segoe UI", 9f)
            };

            dlg.Controls.AddRange(new Control[]
            {
                lbl, txtRem, btnOk, btnCancel
            });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog(this) !=
                DialogResult.OK)
                return;

            string remarks =
                txtRem.Text.Trim();

            try
            {
                bool ok = isApprove
                    ? LeaveApprovalDAL.Approve(
                        lrId, remarks,
                        SessionManager.UserId)
                    : LeaveApprovalDAL.Reject(
                        lrId, remarks,
                        SessionManager.UserId);

                if (ok)
                {
                    ValidationHelper.ShowSuccess(
                        "Leave request " +
                        actionLower + "d " +
                        "successfully.");
                    LoadRequests();
                }
                else
                {
                    ValidationHelper.ShowError(
                        "Action failed. Request " +
                        "may already be processed.");
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to " +
                    actionLower + " request.");
            }
        }

        // ══════════════════════════════════════════
        //  FILTER & SEARCH
        // ══════════════════════════════════════════
        private void cboFilter_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void btnSearch_Click(
            object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void btnShowAll_Click(
            object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cboFilter.SelectedIndex = 0; // All
            LoadRequests();
        }

        private void txtSearch_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadRequests();
        }

        // ══════════════════════════════════════════
        //  FILE MENU
        // ══════════════════════════════════════════
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
            LoadRequests();
        }

        private void menuClose_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        // ══════════════════════════════════════════
        //  DRAG
        // ══════════════════════════════════════════
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
    }
}