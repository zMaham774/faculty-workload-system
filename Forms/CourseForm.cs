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
    public partial class CourseForm : Form
    {
        private bool _isEditMode = false;
        private int _editingId = 0;
        private bool _isDragging = false;
        private Point _dragStart;

        public CourseForm()
        {
            InitializeComponent();
        }

        // ══════════════════════════════════════════════
        //  LOAD
        // ══════════════════════════════════════════════
        private void CourseForm_Load(
            object sender, EventArgs e)
        {
            LoadDepartmentsCombo();
            SetupGrid();
            LoadCourses();
        }

        // ══════════════════════════════════════════════
        //  COMBO — departments
        // ══════════════════════════════════════════════
        private void LoadDepartmentsCombo()
        {
            try
            {
                DataTable dt =
                    DepartmentDAL.GetAllForCombo();
                cboDept.DisplayMember = "dept_name";
                cboDept.ValueMember = "dept_id";
                cboDept.DataSource = dt;
                cboDept.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        // ══════════════════════════════════════════════
        //  GRID SETUP
        // ══════════════════════════════════════════════
        private void SetupGrid()
        {
            dgvCourses.Columns.Clear();

            dgvCourses.EnableHeadersVisualStyles
                = false;
            dgvCourses
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvCourses
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvCourses
                .ColumnHeadersDefaultCellStyle
                .Font =
                    new Font("Segoe UI", 9f,
                             FontStyle.Bold);
            dgvCourses.ColumnHeadersHeight = 36;
            dgvCourses.ColumnHeadersHeightSizeMode
                = DataGridViewColumnHeadersHeightSizeMode
                  .DisableResizing;
            dgvCourses
                .AlternatingRowsDefaultCellStyle
                .BackColor =
                    Color.FromArgb(240, 248, 255);
            dgvCourses.RowTemplate.Height = 32;
            dgvCourses.GridColor =
                Color.FromArgb(220, 230, 242);

            dgvCourses.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                });

            dgvCourses.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colCode",
                    HeaderText = "Course Code",
                    Width = 120,
                    ReadOnly = true
                });

            dgvCourses.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colTitle",
                    HeaderText = "Title",
                    Width = 260,
                    ReadOnly = true
                });

            dgvCourses.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colCH",
                    HeaderText = "Credit Hrs",
                    Width = 90,
                    ReadOnly = true
                });

            dgvCourses.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colType",
                    HeaderText = "Type",
                    Width = 110,
                    ReadOnly = true
                });

            dgvCourses.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDept",
                    HeaderText = "Department",
                    Width = 200,
                    ReadOnly = true
                });

            dgvCourses.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Status",
                    Width = 80,
                    ReadOnly = true
                });

            dgvCourses.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colEdit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    Width = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = {
                        BackColor =
                            Color.FromArgb(
                                33, 145, 245),
                        ForeColor = Color.White }
                });

            dgvCourses.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colDelete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    Width = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = {
                        BackColor =
                            Color.FromArgb(
                                220, 53, 69),
                        ForeColor = Color.White }
                });
        }

        // ══════════════════════════════════════════════
        //  LOAD DATA
        // ══════════════════════════════════════════════
        private void LoadCourses()
        {
            try
            {
                List<Course> list =
                    CourseDAL.GetAll();
                PopulateGrid(list);
                UpdateSummary(list.Count);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load courses.");
            }
        }

        private void PopulateGrid(
            List<Course> list)
        {
            dgvCourses.Rows.Clear();
            foreach (Course c in list)
            {
                dgvCourses.Rows.Add(
                    c.CourseId,
                    c.CourseCode,
                    c.Title,
                    c.CreditHours,
                    c.CourseType,
                    c.DeptName,
                    c.IsActive
                        ? "Active"
                        : "Inactive");
            }
        }

        private void UpdateSummary(int count)
        {
            lblSummary.Text =
                "Total Courses: " + count;
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
                var c = new Course
                {
                    CourseCode =
                        txtCourseCode.Text.Trim()
                        .ToUpper(),
                    Title =
                        txtTitle.Text.Trim(),
                    CreditHours =
                        (int)nudCreditHours.Value,
                    CourseType =
                        cboCourseType.SelectedItem
                        .ToString(),
                    DeptId =
                        Convert.ToInt32(
                            cboDept.SelectedValue),
                    IsActive = rbActive.Checked
                };

                if (_isEditMode)
                {
                    c.CourseId = _editingId;
                    if (CourseDAL.Update(c))
                    {
                        ValidationHelper.ShowSuccess(
                            "Course updated " +
                            "successfully.");
                        ClearForm();
                        LoadCourses();
                    }
                }
                else
                {
                    if (CourseDAL.Insert(c))
                    {
                        ValidationHelper.ShowSuccess(
                            "Course added " +
                            "successfully.");
                        ClearForm();
                        LoadCourses();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to save course.\n" +
                    "Please try again.");
            }
        }

        // ══════════════════════════════════════════════
        //  VALIDATION
        // ══════════════════════════════════════════════
        private bool ValidateInputs()
        {
            if (ValidationHelper.IsEmpty(
                txtCourseCode.Text))
            {
                ValidationHelper.ShowError(
                    "Course Code is required.");
                txtCourseCode.Focus();
                return false;
            }

            if (CourseDAL.CodeExists(
                txtCourseCode.Text.Trim(),
                _editingId))
            {
                ValidationHelper.ShowError(
                    "A course with this code " +
                    "already exists.");
                txtCourseCode.Focus();
                return false;
            }

            if (ValidationHelper.IsEmpty(
                txtTitle.Text))
            {
                ValidationHelper.ShowError(
                    "Course Title is required.");
                txtTitle.Focus();
                return false;
            }

            if (nudCreditHours.Value < 1)
            {
                ValidationHelper.ShowError(
                    "Credit Hours must be " +
                    "at least 1.");
                nudCreditHours.Focus();
                return false;
            }

            if (cboCourseType.SelectedIndex < 0)
            {
                ValidationHelper.ShowError(
                    "Please select a Course Type.");
                cboCourseType.Focus();
                return false;
            }

            if (cboDept.SelectedIndex < 0 ||
                cboDept.SelectedValue == null)
            {
                ValidationHelper.ShowError(
                    "Please select a Department.");
                cboDept.Focus();
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
            txtCourseCode.Text = "";
            txtTitle.Text = "";
            nudCreditHours.Value = 3;
            cboCourseType.SelectedIndex = 0;
            cboDept.SelectedIndex = -1;
            rbActive.Checked = true;

            _isEditMode = false;
            _editingId = 0;
            btnSave.Text = "Save";
            lblFormTitle.Text =
                "ADD / EDIT COURSE";
            txtCourseCode.Focus();
        }

        // ══════════════════════════════════════════════
        //  GRID CELL CLICK
        // ══════════════════════════════════════════════
        private void dgvCourses_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(
                dgvCourses
                    .Rows[e.RowIndex]
                    .Cells["colId"].Value);

            int editIdx =
                dgvCourses.Columns["colEdit"].Index;
            int delIdx =
                dgvCourses.Columns["colDelete"].Index;

            if (e.ColumnIndex == editIdx)
                LoadIntoForm(id);
            else if (e.ColumnIndex == delIdx)
                DeleteCourse(id);
        }

        private void LoadIntoForm(int id)
        {
            try
            {
                Course c = CourseDAL.GetById(id);
                if (c == null) return;

                txtCourseCode.Text = c.CourseCode;
                txtTitle.Text = c.Title;
                nudCreditHours.Value = c.CreditHours;

                cboCourseType.SelectedItem =
                    c.CourseType;
                cboDept.SelectedValue = c.DeptId;

                rbActive.Checked = c.IsActive;
                rbInactive.Checked = !c.IsActive;

                _isEditMode = true;
                _editingId = id;
                btnSave.Text = "Update";
                lblFormTitle.Text = "EDIT COURSE";
                txtCourseCode.Focus();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load course.");
            }
        }

        private void DeleteCourse(int id)
        {
            if (CourseDAL.HasWorkload(id))
            {
                ValidationHelper.ShowError(
                    "Cannot delete this course.\n" +
                    "It is assigned in workload.\n" +
                    "Please remove assignments first.");
                return;
            }

            if (!ValidationHelper.Confirm(
                "Are you sure you want to delete " +
                "this course?\n" +
                "This action cannot be undone."))
                return;

            try
            {
                if (CourseDAL.Delete(id))
                {
                    ValidationHelper.ShowSuccess(
                        "Course deleted successfully.");
                    ClearForm();
                    LoadCourses();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to delete course.");
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
                List<Course> results =
                    CourseDAL.Search(kw);

                if (results.Count == 0)
                {
                    ValidationHelper.ShowError(
                        "No courses found " +
                        "matching: " + kw);
                    return;
                }

                PopulateGrid(results);
                UpdateSummary(results.Count);
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
            LoadCourses();
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
            LoadCourses();
        }

        private void menuClose_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        // ══════════════════════════════════════════════
        //  DRAG  (header panel)
        // ══════════════════════════════════════════════
        private void pnlHeader_MouseDown(
            object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragStart = e.Location;
            }
        }

        private void pnlHeader_MouseMove(
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

        private void pnlHeader_MouseUp(
            object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }
    }
}