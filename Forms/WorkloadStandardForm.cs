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
    public partial class WorkloadStandardForm : Form
    {
        private bool _isEditMode = false;
        private int _editingId = 0;
        private bool _isDragging = false;
        private Point _dragStart;

        public WorkloadStandardForm()
        {
            InitializeComponent();
        }

        //  FORM LOAD
        private void WorkloadStandardForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadDepartmentCombo();
            LoadSemesterCombo();
            LoadStandards();
        }

        //  LOAD COMBOS
        private void LoadDepartmentCombo()
        {
            try
            {
                cboDepartment.DataSource = null;
                cboDepartment.Items.Clear();

                DataTable dt = DepartmentDAL.GetAllForCombo();

                cboDepartment.DataSource = dt;
                cboDepartment.DisplayMember =
                    "dept_name";
                cboDepartment.ValueMember =
                    "dept_id";
                cboDepartment.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load departments.");
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
                cboSemester.DisplayMember =
                    "sem_name";
                cboSemester.ValueMember =
                    "sem_id";
                cboSemester.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load semesters.");
            }
        }

        //  GRID SETUP
        private void SetupGrid()
        {
            dgvStandards.Columns.Clear();

            dgvStandards
                .EnableHeadersVisualStyles = false;
            dgvStandards
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvStandards
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvStandards
                .ColumnHeadersDefaultCellStyle
                .Font =
                    new Font("Segoe UI", 9f,
                             FontStyle.Bold);
            dgvStandards
                .ColumnHeadersHeight = 36;
            dgvStandards
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;
            dgvStandards
                .RowTemplate.Height = 32;
            dgvStandards
                .AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;
            dgvStandards.GridColor =
                Color.FromArgb(220, 230, 242);
            dgvStandards
                .DefaultCellStyle
                .SelectionBackColor =
                    Color.FromArgb(210, 228, 255);
            dgvStandards
                .DefaultCellStyle
                .SelectionForeColor =
                    Color.FromArgb(30, 30, 30);

            dgvStandards.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                });

            dgvStandards.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDept",
                    HeaderText = "Department",
                    Width = 200,
                    ReadOnly = true
                });

            dgvStandards.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSem",
                    HeaderText = "Semester",
                    Width = 160,
                    ReadOnly = true
                });

            dgvStandards.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colMin",
                    HeaderText = "Min Hours",
                    Width = 100,
                    ReadOnly = true
                });

            dgvStandards.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStd",
                    HeaderText = "Std Hours",
                    Width = 100,
                    ReadOnly = true
                });

            dgvStandards.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colMax",
                    HeaderText = "Max Hours",
                    Width = 100,
                    ReadOnly = true
                });

            dgvStandards.Columns.Add(
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

            dgvStandards.Columns.Add(
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

        //  LOAD DATA
        private void LoadStandards()
        {
            try
            {
                List<WorkloadStandard> list = WorkloadStandardDAL.GetAll();
                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load " + "workload standards.");
            }
        }

        private void PopulateGrid(List<WorkloadStandard> list)
        {
            dgvStandards.Rows.Clear();

            foreach (WorkloadStandard ws in list)
            {
                dgvStandards.Rows.Add(
                    ws.WsId,
                    ws.DeptName,
                    ws.SemName,
                    ws.MinHours,
                    ws.StdHours,
                    ws.MaxHours
                );
            }

            dgvStandards.ClearSelection();
        }

        //  CELL FORMATTING
        private void dgvStandards_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView dgv = sender as DataGridView;

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
                    : Color.FromArgb(
                        240, 248, 255);
                e.CellStyle.ForeColor =
                    Color.FromArgb(30, 30, 30);
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

        //  SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var ws = new WorkloadStandard
                {
                    DeptId = Convert.ToInt32(cboDepartment.SelectedValue),
                    SemId = Convert.ToInt32(cboSemester.SelectedValue),
                    MinHours = (int)nudMinHours.Value,
                    StdHours = (int)nudStdHours.Value,
                    MaxHours = (int)nudMaxHours.Value
                };

                if (_isEditMode)
                {
                    ws.WsId = _editingId;

                    if (WorkloadStandardDAL.Update(ws))
                    {
                        ValidationHelper.ShowSuccess("Workload standard " + "updated successfully.");
                        ClearForm();
                        LoadStandards();
                    }
                }
                else
                {
                    if (WorkloadStandardDAL.Insert(ws))
                    {
                        ValidationHelper.ShowSuccess("Workload standard " + "added successfully.");
                        ClearForm();
                        LoadStandards();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to save workload " + "standard.\nPlease try again.");
            }
        }

        //  VALIDATION
        private bool ValidateInputs()
        {
            if (cboDepartment.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select a Department.");
                cboDepartment.Focus();
                return false;
            }

            if (cboSemester.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select a Semester.");
                cboSemester.Focus();
                return false;
            }

            // Check Min <= Std <= Max
            if (nudMinHours.Value > nudStdHours.Value)
            {
                ValidationHelper.ShowError("Min Hours cannot be greater " + "than Standard Hours.");
                nudMinHours.Focus();
                return false;
            }

            if (nudStdHours.Value > nudMaxHours.Value)
            {
                ValidationHelper.ShowError("Standard Hours cannot be " + "greater than Max Hours.");
                nudStdHours.Focus();
                return false;
            }

            if (nudMinHours.Value == nudMaxHours.Value)
            {
                ValidationHelper.ShowError("Min Hours and Max Hours " + "cannot be equal.\n" + "Please set a valid range.");
                nudMinHours.Focus();
                return false;
            }

            // Check duplicate dept+sem
            int deptId = Convert.ToInt32(cboDepartment.SelectedValue);
            int semId = Convert.ToInt32(cboSemester.SelectedValue);

            if (WorkloadStandardDAL.Exists(deptId, semId, _editingId))
            {
                ValidationHelper.ShowError("A workload standard already " + "exists for this Department " + "and Semester combination.");
                cboDepartment.Focus();
                return false;
            }

            return true;
        }

        // CLEAR
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cboDepartment.SelectedIndex = -1;
            cboSemester.SelectedIndex = -1;
            nudMinHours.Value = 9;
            nudStdHours.Value = 15;
            nudMaxHours.Value = 21;

            _isEditMode = false;
            _editingId = 0;
            btnSave.Text = "Save";
            lblFormTitle.Text =
                "ADD / EDIT WORKLOAD STANDARD";
        }

        //  GRID CELL CLICK
        private void dgvStandards_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int wsId = Convert.ToInt32(
                dgvStandards
                    .Rows[e.RowIndex]
                    .Cells["colId"].Value);

            int editIdx = dgvStandards
                .Columns["colEdit"].Index;
            int delIdx = dgvStandards
                .Columns["colDelete"].Index;

            if (e.ColumnIndex == editIdx)
                LoadIntoForm(wsId);
            else if (e.ColumnIndex == delIdx)
                DeleteStandard(wsId);
        }

        private void LoadIntoForm(int wsId)
        {
            try
            {
                WorkloadStandard ws =
                    WorkloadStandardDAL
                    .GetById(wsId);
                if (ws == null) return;

                cboDepartment.SelectedValue = ws.DeptId;
                cboSemester.SelectedValue = ws.SemId;
                nudMinHours.Value = ws.MinHours;
                nudStdHours.Value = ws.StdHours;
                nudMaxHours.Value = ws.MaxHours;

                _isEditMode = true;
                _editingId = wsId;
                btnSave.Text = "Update";
                lblFormTitle.Text =
                    "EDIT WORKLOAD STANDARD";
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load standard.");
            }
        }

        private void DeleteStandard(int wsId)
        {
            if (!ValidationHelper.Confirm(
                "Are you sure you want to " +
                "delete this workload standard?\n" +
                "This cannot be undone."))
                return;

            try
            {
                if (WorkloadStandardDAL.Delete(wsId))
                {
                    ValidationHelper.ShowSuccess("Deleted successfully.");
                    ClearForm();
                    LoadStandards();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to delete standard.");
            }
        }

        //  SEARCH
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();

            if (ValidationHelper.IsEmpty(kw))
            {
                ValidationHelper.ShowError("Please enter a search term.");
                return;
            }

            try
            {
                List<WorkloadStandard> results = WorkloadStandardDAL.Search(kw);

                if (results.Count == 0)
                {
                    ValidationHelper.ShowError("No standards found " + "matching: " + kw);
                    return;
                }

                PopulateGrid(results);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Search failed.");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadStandards();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
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
            LoadDepartmentCombo();
            LoadSemesterCombo();
            LoadStandards();
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