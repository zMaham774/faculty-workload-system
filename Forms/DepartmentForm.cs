using FacultyWorkloadSystem.DAL;
using FacultyWorkloadSystem.Helpers;
using FacultyWorkloadSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FacultyWorkloadSystem.Forms
{
    public partial class DepartmentForm : Form
    {
        private bool _isEditMode = false;
        private int _editingId = 0;
        private bool _isDragging = false;
        private Point _dragStartPoint;

        public DepartmentForm()
        {
            InitializeComponent();
        }

        //  FORM LOAD
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadHodCombo();
            LoadDepartments();
        }

        //  DATAGRIDVIEW SETUP
        private void SetupDataGridView()
        {
            dgvDepartments.Columns.Clear();

            dgvDepartments.EnableHeadersVisualStyles = false;

            dgvDepartments.ColumnHeadersDefaultCellStyle.BackColor
                = Color.FromArgb(9, 74, 158);
            dgvDepartments.ColumnHeadersDefaultCellStyle.ForeColor
                = Color.White;
            dgvDepartments.ColumnHeadersDefaultCellStyle.Font
                = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvDepartments.ColumnHeadersDefaultCellStyle.Padding
                = new Padding(5, 0, 0, 0);

            dgvDepartments.ColumnHeadersHeight = 36;
            dgvDepartments.ColumnHeadersHeightSizeMode
                = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // Row height
            dgvDepartments.RowTemplate.Height = 36;
            dgvDepartments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            
            dgvDepartments.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(210, 228, 255);
            dgvDepartments.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(30, 30, 30);

            // Grid line colour
            dgvDepartments.GridColor
                = Color.FromArgb(220, 230, 242);
            dgvDepartments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                });

            dgvDepartments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colName",
                    HeaderText = "Department Name",
                    Width = 220,
                    ReadOnly = true
                });

            dgvDepartments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colHod",
                    HeaderText = "HOD Name",
                    Width = 160,
                    ReadOnly = true
                });

            dgvDepartments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colContact",
                    HeaderText = "Contact",
                    Width = 120,
                    ReadOnly = true
                });

            dgvDepartments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colEmail",
                    HeaderText = "Email",
                    Width = 180,
                    ReadOnly = true
                });

            dgvDepartments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Status",
                    Width = 80,
                    ReadOnly = true
                });

            dgvDepartments.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colEdit",
                    HeaderText = "Edit",
                    Text = "✏ Edit",
                    UseColumnTextForButtonValue = true,
                    Width = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle =
                    {
                        BackColor = Color.FromArgb(33, 145, 245),
                        ForeColor = Color.White
                    }
                });

            dgvDepartments.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colDelete",
                    HeaderText = "Delete",
                    Text = "🗑 Delete",
                    UseColumnTextForButtonValue = true,
                    Width = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle =
                    {
                        BackColor = Color.FromArgb(220, 53, 69),
                        ForeColor = Color.White
                    }
                });
        }

        //  LOAD DEPARTMENTS
        private void LoadDepartments()
        {
            try
            {
                List<Department> list = DepartmentDAL.GetAll();
                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load departments.");
            }
        }

        private void PopulateGrid(List<Department> list)
        {
            dgvDepartments.Rows.Clear();

            foreach (Department d in list)
            {
                dgvDepartments.Rows.Add(
                    d.DeptId,
                    d.DeptName,
                    d.HodName,
                    d.Contact,
                    d.Email,
                    d.IsActive ? "Active" : "Inactive"
                );
            }
            // Clears auto-selection of first row
            dgvDepartments.ClearSelection();
        }

        //  SAVE BUTTON
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                Department dept = new Department
                {
                    DeptName = txtDeptName.Text.Trim(),

                    // Get the display text (name) from combo
                    // not the value (emp_id)
                    HodName = cboHodName.SelectedIndex <= 0
                ? ""
                : cboHodName.Text.Trim(),

                    Contact = txtContact.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    IsActive = rbActive.Checked
                };

                if (_isEditMode)
                {
                    dept.DeptId = _editingId;

                    if (DepartmentDAL.Update(dept))
                    {
                        ValidationHelper.ShowSuccess("Department updated successfully.");
                        ClearForm();
                        LoadDepartments();
                    }
                }
                else
                {
                    if (DepartmentDAL.Insert(dept))
                    {
                        ValidationHelper.ShowSuccess("Department added successfully.");
                        ClearForm();
                        LoadDepartments();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to save department.\n" +"Please try again.");
            }
        }

        //  VALIDATION
        private bool ValidateInputs()
        {
            if (ValidationHelper.IsEmpty(txtDeptName.Text))
            {
                ValidationHelper.ShowError("Department Name is required.");
                return false;
            }

            if (DepartmentDAL.NameExists(txtDeptName.Text.Trim(), _editingId))
            {
                ValidationHelper.ShowError("A department with this name " +"already exists.");
                return false;
            }

            if (!ValidationHelper.IsValidEmail(txtEmail.Text.Trim()))
            {
                ValidationHelper.ShowError("Please enter a valid email address.");
                return false;
            }

            if (!ValidationHelper.IsValidPhone(txtContact.Text.Trim()))
            {
                ValidationHelper.ShowError("Please enter a valid contact number.");
                return false;
            }

            return true;
        }

        //  CLEAR BUTTON
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtDeptName.Text = "";
            cboHodName.SelectedIndex = 0;  
            txtContact.Text = "";
            txtEmail.Text = "";
            rbActive.Checked = true;

            _isEditMode = false;
            _editingId = 0;
            btnSave.Text = "Save";
            lblFormTitle.Text = "ADD / EDIT DEPARTMENT";
        }

        //  GRID CELL CLICK
        private void dgvDepartments_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int deptId = Convert.ToInt32(
                dgvDepartments.Rows[e.RowIndex]
                              .Cells["colId"].Value);

            if (e.ColumnIndex == dgvDepartments.Columns["colEdit"].Index)
            {
                LoadIntoForm(deptId);
            }
            else if (e.ColumnIndex == dgvDepartments.Columns["colDelete"].Index)
            {
                DeleteDepartment(deptId);
            }
        }

        private void LoadIntoForm(int deptId)
        {
            try
            {
                Department dept =
                    DepartmentDAL.GetById(deptId);
                if (dept == null) return;

                txtDeptName.Text = dept.DeptName;
                txtContact.Text = dept.Contact;
                txtEmail.Text = dept.Email;
                rbActive.Checked = dept.IsActive;
                rbInactive.Checked = !dept.IsActive;

                // Set HOD combo to match stored name
                // Faculty who is HOD cannot be deleted
                // so name always exists in faculty table
                foreach (DataRowView item in
                         cboHodName.Items)
                {
                    if (item["name"].ToString()
                        == dept.HodName)
                    {
                        cboHodName.SelectedValue =
                            item["emp_id"];
                        break;
                    }
                }

                _isEditMode = true;
                _editingId = deptId;
                btnSave.Text = "Update";
                lblFormTitle.Text = "EDIT DEPARTMENT";
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load department.");
            }
        }

        private void DeleteDepartment(int deptId)
        {
            if (DepartmentDAL.HasFaculty(deptId))
            {
                ValidationHelper.ShowError(
                    "Cannot delete this department.\n" +
                    "Faculty members are assigned to it.\n" +
                    "Please reassign them first.");
                return;
            }

            if (!ValidationHelper.Confirm(
                "Are you sure you want to delete " +
                "this department?\n" +
                "This action cannot be undone."))
                return;

            try
            {
                if (DepartmentDAL.Delete(deptId))
                {
                    ValidationHelper.ShowSuccess("Department deleted successfully.");
                    ClearForm();
                    LoadDepartments();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to delete department.");
            }
        }

        //  SEARCH
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (ValidationHelper.IsEmpty(keyword))
            {
                ValidationHelper.ShowError("Please enter a search term.");
                return;
            }

            try
            {
                List<Department> results =
                    DepartmentDAL.Search(keyword);

                if (results.Count == 0)
                {
                    ValidationHelper.ShowError(
                        "No departments found matching: "
                        + keyword);
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
            LoadDepartments();
        }

        private void txtSearch_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        //  FILE MENU
        private void menuMaximize_Click(object sender,
                                         EventArgs e)
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
            LoadHodCombo();
            LoadDepartments();
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //  DRAGGING
        private void gradientPanel1_MouseDown(object sender,
            MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragStartPoint = e.Location;
            }
        }

        private void gradientPanel1_MouseMove(object sender,
            MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point current = this.PointToScreen(e.Location);
                this.Location = new Point(
                    current.X - _dragStartPoint.X,
                    current.Y - _dragStartPoint.Y);
            }
        }

        private void gradientPanel1_MouseUp(object sender,
            MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void LoadHodCombo()
        {
            try
            {
                cboHodName.DataSource = null;
                cboHodName.Items.Clear();

                DataTable dt =
                    FacultyDAL.GetAllForCombo();

                // Add blank first option
                DataRow blank = dt.NewRow();
                blank["emp_id"] = DBNull.Value;
                blank["name"] = "-- Select HOD --";
                dt.Rows.InsertAt(blank, 0);

                cboHodName.DataSource = dt;
                cboHodName.DisplayMember = "name";
                cboHodName.ValueMember = "emp_id";
                cboHodName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load faculty list " +
                    "for HOD selection.");
            }
        }

        private void btnAddHodFaculty_Click(object sender, EventArgs e)
        {
            FacultyForm form = new FacultyForm();
            form.ShowDialog();

            // Refresh combo after adding faculty
            LoadHodCombo();
        }

        private void dgvDepartments_CellFormatting(
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

            // Apply alternating row colour
            // only to non-button columns
            if (e.ColumnIndex != editIdx &&
                e.ColumnIndex != delIdx)
            {
                if (e.RowIndex % 2 == 0)
                {
                    // Even rows — white
                    e.CellStyle.BackColor =
                        Color.White;
                    e.CellStyle.ForeColor =
                        Color.FromArgb(30, 30, 30);
                }
                else
                {
                    // Odd rows — light blue
                    e.CellStyle.BackColor =
                        Color.FromArgb(240, 248, 255);
                    e.CellStyle.ForeColor =
                        Color.FromArgb(30, 30, 30);
                }
            }
            else
            {
                // Button columns — always
                // keep their own colours
                // regardless of row index
                if (e.ColumnIndex == editIdx)
                {
                    e.CellStyle.BackColor =
                        Color.FromArgb(33, 145, 245);
                    e.CellStyle.ForeColor =
                        Color.White;
                }
                else if (e.ColumnIndex == delIdx)
                {
                    e.CellStyle.BackColor =
                        Color.FromArgb(220, 53, 69);
                    e.CellStyle.ForeColor =
                        Color.White;
                }
            }
        }
    }
}