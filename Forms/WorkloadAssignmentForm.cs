using FacultyWorkloadSystem.DAL;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FacultyWorkloadSystem.Forms
{
    public partial class WorkloadAssignmentForm : Form
    {
        private bool _isEditMode = false;
        private int _editingId = 0;
        private int _editEmpId = 0;
        private int _editCourseId = 0;
        private int _editSemId = 0;
        private bool _isDragging = false;
        private Point _dragStart;

        public WorkloadAssignmentForm()
        {
            InitializeComponent();
        }

        //  FORM LOAD
        private void WorkloadAssignmentForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadFacultyCombo();
            LoadCourseCombo();
            LoadSemesterCombo();
            LoadFilterCombos();
            LoadAssignments();
        }

        //  LOAD COMBOS
        private void LoadFacultyCombo()
        {
            try
            {
                cboFaculty.DataSource = null;
                cboFaculty.Items.Clear();

                DataTable dt = FacultyDAL.GetAllForCombo();

                cboFaculty.DataSource = dt;
                cboFaculty.DisplayMember = "name";
                cboFaculty.ValueMember = "emp_id";
                cboFaculty.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load faculty.");
            }
        }

        private void LoadCourseCombo()
        {
            try
            {
                cboCourse.DataSource = null;
                cboCourse.Items.Clear();

                DataTable dt = CourseDAL.GetAllForCombo();

                cboCourse.DataSource = dt;
                cboCourse.DisplayMember = "course_display";
                cboCourse.ValueMember = "course_id";
                cboCourse.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load courses.");
            }
        }

        private void LoadSemesterCombo()
        {
            try
            {
                cboSemester.DataSource = null;
                cboSemester.Items.Clear();

                DataTable dt = SemesterDAL.GetAllForCombo();

                cboSemester.DataSource = dt;
                cboSemester.DisplayMember = "sem_name";
                cboSemester.ValueMember = "sem_id";
                cboSemester.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load semesters.");
            }
        }

        private void LoadFilterCombos()
        {
            try
            {
                // Filter semester combo
                DataTable semDt = SemesterDAL.GetAllForCombo();

                DataRow allSem = semDt.NewRow();
                allSem["sem_id"] = 0;
                allSem["sem_name"] =
                    "-- All Semesters --";
                semDt.Rows.InsertAt(allSem, 0);

                cboFilterSemester.DataSource = semDt;
                cboFilterSemester.DisplayMember  = "sem_name";
                cboFilterSemester.ValueMember = "sem_id";
                cboFilterSemester.SelectedIndex = 0;

                // Filter dept combo
                DataTable deptDt = DepartmentDAL.GetAllForCombo();

                DataRow allDept = deptDt.NewRow();
                allDept["dept_id"] = 0;
                allDept["dept_name"] =
                    "-- All Departments --";
                deptDt.Rows.InsertAt(allDept, 0);

                cboFilterDept.DataSource = deptDt;
                cboFilterDept.DisplayMember = "dept_name";
                cboFilterDept.ValueMember = "dept_id";
                cboFilterDept.SelectedIndex = 0;

                // Reassign To combo
                cboReassignTo.DataSource = FacultyDAL.GetAllForCombo();
                cboReassignTo.DisplayMember = "name";
                cboReassignTo.ValueMember = "emp_id";
                cboReassignTo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load filters.");
            }
        }

        //  COURSE SELECTED — auto fill hours
        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCourse.SelectedIndex == -1)
                return;

            try
            {
                int courseId = Convert.ToInt32(cboCourse.SelectedValue);

                Course c = CourseDAL.GetById(courseId);

                if (c != null)
                    nudTotalHours.Value = c.CreditHours;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        //  MANAGE STANDARDS BUTTON
        private void btnManageStandards_Click(object sender, EventArgs e)
        {
            WorkloadStandardForm form = new WorkloadStandardForm();
            form.ShowDialog();
        }

        //  GRID SETUP
        private void SetupGrid()
        {
            dgvAssignments.Columns.Clear();

            dgvAssignments
                .EnableHeadersVisualStyles = false;
            dgvAssignments
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvAssignments
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvAssignments
                .ColumnHeadersDefaultCellStyle
                .Font =
                    new Font("Segoe UI", 9f,
                             FontStyle.Bold);
            dgvAssignments
                .ColumnHeadersHeight = 36;
            dgvAssignments
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;
            dgvAssignments
                .RowTemplate.Height = 32;
            dgvAssignments.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;
            dgvAssignments.GridColor =
                Color.FromArgb(220, 230, 242);
            dgvAssignments
                .DefaultCellStyle
                .SelectionBackColor =
                    Color.FromArgb(210, 228, 255);
            dgvAssignments
                .DefaultCellStyle
                .SelectionForeColor =
                    Color.FromArgb(30, 30, 30);

            dgvAssignments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                });

            dgvAssignments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colFaculty",
                    HeaderText = "Faculty",
                    Width = 180,
                    ReadOnly = true
                });

            dgvAssignments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colCourse",
                    HeaderText = "Course",
                    Width = 200,
                    ReadOnly = true
                });

            dgvAssignments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDept",
                    HeaderText = "Department",
                    Width = 150,
                    ReadOnly = true
                });

            dgvAssignments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSem",
                    HeaderText = "Semester",
                    Width = 120,
                    ReadOnly = true
                });

            dgvAssignments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colHours",
                    HeaderText = "Hours",
                    Width = 70,
                    ReadOnly = true
                });

            dgvAssignments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Status",
                    Width = 100,
                    ReadOnly = true
                });

            dgvAssignments.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colEdit",
                    HeaderText = "Edit",
                    Text = "✏ Edit",
                    UseColumnTextForButtonValue
                                 = true,
                    Width = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle =
                    {
                        BackColor =
                            Color.FromArgb(
                                33, 145, 245),
                        ForeColor = Color.White
                    }
                });

            dgvAssignments.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colDelete",
                    HeaderText = "Delete",
                    Text = "🗑 Delete",
                    UseColumnTextForButtonValue
                                 = true,
                    Width = 90,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle =
                    {
                        BackColor =
                            Color.FromArgb(
                                220, 53, 69),
                        ForeColor = Color.White
                    }
                });
        }

        //  LOAD ASSIGNMENTS
        private void LoadAssignments()
        {
            try
            {
                List<WorkloadAssignment> list = WorkloadAssignmentDAL.GetCurrentSemester();
                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load assignments.");
            }
        }

        private void PopulateGrid(List<WorkloadAssignment> list)
        {
            dgvAssignments.Rows.Clear();

            foreach (WorkloadAssignment wa in list)
            {
                dgvAssignments.Rows.Add(
                    wa.WaId,
                    wa.FacultyName,
                    wa.CourseCode + " - " +
                        wa.CourseTitle,
                    wa.DeptName,
                    wa.SemName,
                    wa.TotalHours,
                    wa.Status
                );
            }

            dgvAssignments.ClearSelection();
        }

        //  CELL FORMATTING
        private void dgvAssignments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView dgv = sender as DataGridView;

            int editIdx = dgv.Columns["colEdit"].Index;
            int delIdx = dgv.Columns["colDelete"].Index;
            int statIdx = dgv.Columns["colStatus"].Index;

            if (e.ColumnIndex != editIdx && e.ColumnIndex != delIdx)
            {
                // Colour-code status column
                if (e.ColumnIndex == statIdx && e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "Active":
                            e.CellStyle.ForeColor =
                                Color.FromArgb(
                                    30, 130, 70);
                            e.CellStyle.Font =
                                new Font("Segoe UI",
                                    9f,
                                    FontStyle.Bold);
                            break;
                        case "Dropped":
                            e.CellStyle.ForeColor =
                                Color.FromArgb(
                                    180, 50, 50);
                            e.CellStyle.Font =
                                new Font("Segoe UI",
                                    9f,
                                    FontStyle.Bold);
                            break;
                        case "Substituted":
                            e.CellStyle.ForeColor =
                                Color.FromArgb(
                                    180, 120, 0);
                            e.CellStyle.Font =
                                new Font("Segoe UI",
                                    9f,
                                    FontStyle.Bold);
                            break;
                    }
                }

                e.CellStyle.BackColor =
                    e.RowIndex % 2 == 0
                    ? Color.White
                    : Color.FromArgb(
                        240, 248, 255);
            }
            else
            {
                e.CellStyle.BackColor =
                    e.ColumnIndex == editIdx
                    ? Color.FromArgb(33, 145, 245)
                    : Color.FromArgb(220, 53, 69);
                e.CellStyle.ForeColor =
                    Color.White;
            }
        }

        //  SAVE — new assignment
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                int empId = Convert.ToInt32(cboFaculty.SelectedValue);
                int courseId = Convert.ToInt32(cboCourse.SelectedValue);
                int semId = Convert.ToInt32(cboSemester.SelectedValue);

                var wa = new WorkloadAssignment
                {
                    EmpId = empId,
                    CourseId = courseId,
                    SemId = semId,
                    TotalHours = nudTotalHours.Value,
                    Status = cboStatus.SelectedItem.ToString(),
                    AssignedDate = dtpAssignedDate.Value.Date
                };

                if (_isEditMode)
                {
                    wa.WaId = _editingId;

                    if (WorkloadAssignmentDAL
                            .Update(wa))
                    {
                        ValidationHelper.ShowSuccess("Assignment updated " + "successfully.");
                        ClearForm();
                        LoadAssignments();
                    }
                }
                else
                {
                    if (WorkloadAssignmentDAL.Insert(wa))
                    {
                        ValidationHelper.ShowSuccess("Assignment added " + "successfully.");
                        ClearForm();
                        LoadAssignments();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to save assignment.\n" + "Please try again.");
            }
        }

        //  REASSIGN, uses transaction
        private void btnReassign_Click(object sender, EventArgs e)
        {
            if (!ValidateReassign()) return;

            try
            {
                int toEmpId = Convert.ToInt32(cboReassignTo.SelectedValue);

                bool success =
                    WorkloadAssignmentDAL.Reassign(
                        _editingId,
                        _editEmpId,
                        toEmpId,
                        _editCourseId,
                        _editSemId,
                        txtReassignReason.Text.Trim());

                if (success)
                {
                    ValidationHelper.ShowSuccess("Course reassigned " + "successfully.\n" + "Change has been logged.");
                    ClearForm();
                    LoadAssignments();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Reassignment failed.\n" + "Both changes were rolled back.");
            }
        }

        //  VALIDATION
        private bool ValidateInputs()
        {
            if (cboFaculty.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select a Faculty member.");
                cboFaculty.Focus();
                return false;
            }

            if (cboCourse.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select a Course.");
                cboCourse.Focus();
                return false;
            }

            if (cboSemester.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select a Semester.");
                cboSemester.Focus();
                return false;
            }

            if (cboStatus.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select a Status.");
                cboStatus.Focus();
                return false;
            }

            int empId = Convert.ToInt32(cboFaculty.SelectedValue);
            int courseId = Convert.ToInt32(cboCourse.SelectedValue);
            int semId = Convert.ToInt32(cboSemester.SelectedValue);

            // Only block if it's a brand new assignment record
            if (!_isEditMode)
            {
                Semester selectedSem = SemesterDAL.GetById(semId);
                if (selectedSem != null && !selectedSem.IsCurrent)
                {
                    ValidationHelper.ShowError("Cannot create new assignments for an inactive semester.");
                    return false;
                }
            }

            // Duplicate check
            if (WorkloadAssignmentDAL.Exists(empId, courseId, semId, _editingId))
            {
                ValidationHelper.ShowError("This faculty member is " + "already assigned to this " + "course in this semester.");
                return false;
            }

            // Workload standards check
            Semester sem = SemesterDAL.GetById(semId);

            if (sem != null)
            {
                WorkloadStandard standard =
                    WorkloadStandardDAL
                    .GetByDeptAndSem(
                        // get dept from faculty
                        GetFacultyDeptId(empId),
                        semId);

                if (standard != null)
                {
                    decimal existing =
                        WorkloadAssignmentDAL
                        .GetTotalHoursForFaculty(
                            empId, semId,
                            _editingId);

                    decimal newTotal = existing + nudTotalHours.Value;

                    if (newTotal > standard.MaxHours)
                    {
                        ValidationHelper.ShowError(
                            "This assignment would " +
                            "exceed the maximum " +
                            "workload of " +
                            standard.MaxHours +
                            " hours for this " +
                            "department.\n" +
                            "Current total: " +
                            existing + " hours.");
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ValidateReassign()
        {
            if (cboReassignTo.SelectedIndex == -1)
            {
                ValidationHelper.ShowError( "Please select the faculty " + "member to reassign to.");
                cboReassignTo.Focus();
                return false;
            }

            int toEmpId = Convert.ToInt32(cboReassignTo.SelectedValue);

            if (toEmpId == _editEmpId)
            {
                ValidationHelper.ShowError("Cannot reassign to the same " + "faculty member.");
                cboReassignTo.Focus();
                return false;
            }

            // Check duplicate for new faculty
            if (WorkloadAssignmentDAL.Exists(
                    toEmpId,
                    _editCourseId,
                    _editSemId))
            {
                ValidationHelper.ShowError(
                    "The selected faculty member " + "is already assigned to this " + "course in this semester.");
                return false;
            }

            return true;
        }

        // Helper: get faculty dept ID 
        private int GetFacultyDeptId(int empId)
        {
            string sql = @"
                SELECT dept_id
                FROM   faculty
                WHERE  emp_id = @empId";

            var p = new[]
            {
                new MySqlParameter("@empId", empId)
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);

            return result == null
                ? 0
                : Convert.ToInt32(result);
        }

        //  CLEAR
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cboFaculty.SelectedIndex = -1;
            cboCourse.SelectedIndex = -1;
            cboSemester.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
            nudTotalHours.Value = 0;
            dtpAssignedDate.Value = DateTime.Today;

            // Hide reassign section
            pnlReassign.Visible = false;
            btnReassign.Visible = false;
            cboReassignTo.SelectedIndex = -1;
            txtReassignReason.Text = "";

            _isEditMode = false;
            _editingId = 0;
            _editEmpId = 0;
            _editCourseId = 0;
            _editSemId = 0;

            btnSave.Text = "Save";
            lblFormTitle.Text = "ADD / REASSIGN WORKLOAD";
        }

        //  GRID CELL CLICK
        private void dgvAssignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int waId = Convert.ToInt32(
                dgvAssignments.Rows[e.RowIndex].Cells["colId"].Value);

            int editIdx = dgvAssignments.Columns["colEdit"].Index;
            int delIdx = dgvAssignments.Columns["colDelete"].Index;

            if (e.ColumnIndex == editIdx)
                LoadIntoForm(waId);
            else if (e.ColumnIndex == delIdx)
                DeleteAssignment(waId);
        }

        private void LoadIntoForm(int waId)
        {
            try
            {
                WorkloadAssignment wa = WorkloadAssignmentDAL.GetById(waId);
                if (wa == null) return;

                cboFaculty.SelectedValue = wa.EmpId;
                cboCourse.SelectedValue = wa.CourseId;
                cboSemester.SelectedValue = wa.SemId;
                cboStatus.SelectedItem = wa.Status;
                nudTotalHours.Value = wa.TotalHours;
                dtpAssignedDate.Value = wa.AssignedDate;

                // Show reassign section in edit mode
                pnlReassign.Visible = true;
                btnReassign.Visible = true;

                // Store for reassign transaction
                _isEditMode = true;
                _editingId = waId;
                _editEmpId = wa.EmpId;
                _editCourseId = wa.CourseId;
                _editSemId = wa.SemId;

                btnSave.Text = "Update";
                lblFormTitle.Text = "EDIT / REASSIGN WORKLOAD";
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load assignment.");
            }
        }

        private void DeleteAssignment(int waId)
        {
            if (WorkloadAssignmentDAL.HasRelatedData(waId))
            {
                ValidationHelper.ShowError(
                    "Cannot delete this assignment.\n" +
                    "It has timetable or attendance " +
                    "records linked to it.\n" +
                    "Please remove those first.");
                return;
            }

            if (!ValidationHelper.Confirm(
                "Are you sure you want to " +
                "delete this assignment?\n" +
                "This cannot be undone."))
                return;

            try
            {
                if (WorkloadAssignmentDAL
                        .Delete(waId))
                {
                    ValidationHelper.ShowSuccess("Assignment deleted.");
                    ClearForm();
                    LoadAssignments();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to delete assignment.");
            }
        }

        //  FILTER
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                int semId = Convert.ToInt32(cboFilterSemester.SelectedValue);
                int deptId = Convert.ToInt32(cboFilterDept.SelectedValue);

                List<WorkloadAssignment> list = WorkloadAssignmentDAL.GetFiltered(semId, deptId);

                if (list.Count == 0)
                {
                    ValidationHelper.ShowError("No assignments found " + "for the selected filters.");
                    return;
                }

                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Filter failed.");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cboFilterSemester.SelectedIndex = 0;
            cboFilterDept.SelectedIndex = 0;
            LoadAssignments();
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

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadFacultyCombo();
            LoadCourseCombo();
            LoadSemesterCombo();
            LoadFilterCombos();
            LoadAssignments();
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
                Point cur =
                    this.PointToScreen(e.Location);
                this.Location = new Point(
                    cur.X - _dragStart.X,
                    cur.Y - _dragStart.Y);
            }
        }

        private void gradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }
    }
}