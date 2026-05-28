using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacultyWorkloadSystem.DAL;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;

namespace FacultyWorkloadSystem.Forms
{
    public partial class SemesterForm : Form
    {
        private bool _isEditMode = false;
        private int _editingId = 0;
        private bool _isDragging = false;
        private Point _dragStart;

       
            public SemesterForm()
        {
            InitializeComponent();

         
        }
        

        // ══════════════════════════════════════════════
        //  LOAD
        // ══════════════════════════════════════════════
        private void SemesterForm_Load(
            object sender, EventArgs e)
        {
            SetupGrid();
            LoadSemesters();
        }

        // ══════════════════════════════════════════════
        //  GRID SETUP — exact same as DepartmentForm
        // ══════════════════════════════════════════════
        private void SetupGrid()
        {
            dgvSemesters.Columns.Clear();

            dgvSemesters.EnableHeadersVisualStyles = false;
            dgvSemesters.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(9, 74, 158);
            dgvSemesters.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvSemesters.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvSemesters.ColumnHeadersHeight = 36;
            dgvSemesters.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;

            dgvSemesters.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(210, 228, 255);
            dgvSemesters.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(30, 30, 30);

            dgvSemesters.RowTemplate.Height = 32;
            dgvSemesters.GridColor =
                Color.FromArgb(220, 230, 242);

            dgvSemesters.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                });

            dgvSemesters.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colName",
                    HeaderText = "Semester Name",
                    Width = 220,
                    ReadOnly = true
                });

            dgvSemesters.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colYear",
                    HeaderText = "Acad Year",
                    Width = 100,
                    ReadOnly = true
                });

            dgvSemesters.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStart",
                    HeaderText = "Start Date",
                    Width = 120,
                    ReadOnly = true
                });

            dgvSemesters.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colEnd",
                    HeaderText = "End Date",
                    Width = 120,
                    ReadOnly = true
                });

            dgvSemesters.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colCurrent",
                    HeaderText = "Current",
                    Width = 80,
                    ReadOnly = true
                });

            dgvSemesters.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colSetCurrent",
                    HeaderText = "Set Current",
                    Text = "Set",
                    UseColumnTextForButtonValue = true,
                    Width = 90,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = {
                BackColor = Color.FromArgb(13, 140, 106),
                ForeColor = Color.White }
                });

            dgvSemesters.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colEdit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    Width = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = {
                BackColor = Color.FromArgb(33, 145, 245),
                ForeColor = Color.White }
                });

            dgvSemesters.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colDelete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    Width = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = {
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White }
                });
        }

        // ══════════════════════════════════════════════
        //  LOAD DATA
        // ══════════════════════════════════════════════
        private void LoadSemesters()
        {
            try
            {
                List<Semester> list =
                    SemesterDAL.GetAll();
                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load semesters.");
            }
        }

        private void PopulateGrid(
            List<Semester> list)
        {
            dgvSemesters.Rows.Clear();
            foreach (Semester s in list)
            {
                dgvSemesters.Rows.Add(
                    s.SemId,
                    s.SemName,
                    s.AcadYear,
                    s.StartDate
                     .ToString("dd MMM yyyy"),
                    s.EndDate
                     .ToString("dd MMM yyyy"),
                    s.IsCurrent
                        ? "✔ Active"
                        : "—");
            }
            dgvSemesters.ClearSelection();
        }

        // ══════════════════════════════════════════════
        //  SAVE
        // ══════════════════════════════════════════════
        private void btnSave_Click(
            object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var sem = new Semester
                {
                    SemName =
                        txtSemName.Text.Trim(),
                    AcadYear =
                        txtAcadYear.Text.Trim(),
                    StartDate =
                        dtpStartDate.Value.Date,
                    EndDate =
                        dtpEndDate.Value.Date,
                    IsCurrent = chkIsCurrent.Checked
                };

                if (_isEditMode)
                {
                    sem.SemId = _editingId;

                    // If setting as current, use
                    // transaction to reset others
                    if (sem.IsCurrent)
                        SemesterDAL
                            .SetAsCurrent(sem.SemId);

                    if (SemesterDAL.Update(sem))
                    {
                        ValidationHelper.ShowSuccess(
                            "Semester updated " +
                            "successfully.");
                        ClearForm();
                        LoadSemesters();
                    }
                }
                else
                {
                    if (SemesterDAL.Insert(sem))
                    {
                        // After insert, if marked
                        // current, set it
                        if (sem.IsCurrent)
                        {
                            // Get the new sem_id
                            var all =
                                SemesterDAL.GetAll();
                            if (all.Count > 0)
                            {
                                // Most recent first
                                SemesterDAL
                                    .SetAsCurrent(
                                    all[0].SemId);
                            }
                        }

                        ValidationHelper.ShowSuccess(
                            "Semester added " +
                            "successfully.");
                        ClearForm();
                        LoadSemesters();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to save semester.\n" +
                    "Please try again.");
            }
        }

        // ══════════════════════════════════════════════
        //  VALIDATION
        // ══════════════════════════════════════════════
        private bool ValidateInputs()
        {
            if (ValidationHelper.IsEmpty(
                txtSemName.Text))
            {
                ValidationHelper.ShowError(
                    "Semester Name is required.");
                txtSemName.Focus();
                return false;
            }

            if (SemesterDAL.NameExists(
                txtSemName.Text.Trim(),
                _editingId))
            {
                ValidationHelper.ShowError(
                    "A semester with this name " +
                    "already exists.");
                txtSemName.Focus();
                return false;
            }

            if (ValidationHelper.IsEmpty(
                txtAcadYear.Text))
            {
                ValidationHelper.ShowError(
                    "Academic Year is required.\n" +
                    "Format: 2024-25");
                txtAcadYear.Focus();
                return false;
            }

            if (dtpEndDate.Value.Date <=
                dtpStartDate.Value.Date)
            {
                ValidationHelper.ShowError(
                    "End Date must be after " +
                    "Start Date.");
                dtpEndDate.Focus();
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
            txtSemName.Text = "";
            txtAcadYear.Text = "";
            dtpStartDate.Value =
                DateTime.Today;
            dtpEndDate.Value =
                DateTime.Today.AddMonths(4);
            chkIsCurrent.Checked = false;

            _isEditMode = false;
            _editingId = 0;
            btnSave.Text = "Save";
            lblFormTitle.Text =
                "ADD / EDIT SEMESTER";
            txtSemName.Focus();
        }

        // ══════════════════════════════════════════════
        //  GRID CELL CLICK
        // ══════════════════════════════════════════════
        private void dgvSemesters_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(
                dgvSemesters
                    .Rows[e.RowIndex]
                    .Cells["colId"].Value);

            int setIdx =
                dgvSemesters
                .Columns["colSetCurrent"].Index;
            int editIdx =
                dgvSemesters
                .Columns["colEdit"].Index;
            int delIdx =
                dgvSemesters
                .Columns["colDelete"].Index;

            if (e.ColumnIndex == setIdx)
                SetCurrentSemester(id);
            else if (e.ColumnIndex == editIdx)
                LoadIntoForm(id);
            else if (e.ColumnIndex == delIdx)
                DeleteSemester(id);
        }

        private void SetCurrentSemester(int id)
        {
            if (!ValidationHelper.Confirm(
                "Set this as the current " +
                "active semester?\n" +
                "All other semesters will be " +
                "marked inactive."))
                return;

            try
            {
                if (SemesterDAL.SetAsCurrent(id))
                {
                    ValidationHelper.ShowSuccess(
                        "Semester set as current " +
                        "successfully.");
                    LoadSemesters();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to set current semester.");
            }
        }

        private void LoadIntoForm(int id)
        {
            try
            {
                Semester s =
                    SemesterDAL.GetById(id);
                if (s == null) return;

                txtSemName.Text = s.SemName;
                txtAcadYear.Text = s.AcadYear;
                dtpStartDate.Value = s.StartDate;
                dtpEndDate.Value = s.EndDate;
                chkIsCurrent.Checked = s.IsCurrent;

                _isEditMode = true;
                _editingId = id;
                btnSave.Text = "Update";
                lblFormTitle.Text =
                    "EDIT SEMESTER";
                txtSemName.Focus();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load semester.");
            }
        }

        private void DeleteSemester(int id)
        {
            if (SemesterDAL.HasAssignments(id))
            {
                ValidationHelper.ShowError(
                    "Cannot delete this semester.\n" +
                    "Workload assignments exist.\n" +
                    "Please remove them first.");
                return;
            }

            if (!ValidationHelper.Confirm(
                "Are you sure you want to delete " +
                "this semester?\n" +
                "This action cannot be undone."))
                return;

            try
            {
                if (SemesterDAL.Delete(id))
                {
                    ValidationHelper.ShowSuccess(
                        "Semester deleted.");
                    ClearForm();
                    LoadSemesters();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to delete semester.");
            }
        }

        // ══════════════════════════════════════════════
        //  SEARCH
        // ══════════════════════════════════════════════
        private void btnSearch_Click(
            object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            if (ValidationHelper.IsEmpty(kw))
            {
                ValidationHelper.ShowError(
                    "Please enter a search term.");
                return;
            }

            try
            {
                List<Semester> results =
                    SemesterDAL.Search(kw);

                if (results.Count == 0)
                {
                    ValidationHelper.ShowError(
                        "No semesters found " +
                        "matching: " + kw);
                    return;
                }

                PopulateGrid(results);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Search failed.");
            }
        }

        private void btnShowAll_Click(
            object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadSemesters();
        }

        private void txtSearch_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
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
            LoadSemesters();
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

      
        private void dgvSemesters_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView dgv =
                sender as DataGridView;

            int editIdx =
                dgv.Columns["colEdit"].Index;
            int delIdx =
                dgv.Columns["colDelete"].Index;

            if (e.ColumnIndex != editIdx &&
                e.ColumnIndex != delIdx)
            {
                e.CellStyle.BackColor =
                    e.RowIndex % 2 == 0
                    ? Color.White
                    : Color.FromArgb(240, 248, 255);
                e.CellStyle.ForeColor =
                    Color.FromArgb(30, 30, 30);
            }
            else
            {
                e.CellStyle.BackColor =
                    e.ColumnIndex == editIdx
                    ? Color.FromArgb(33, 145, 245)
                    : Color.FromArgb(220, 53, 69);
                e.CellStyle.ForeColor = Color.White;
            }
        }
    }
}