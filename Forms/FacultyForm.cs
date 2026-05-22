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
    public partial class FacultyForm : Form
    {
        private bool _isEditMode = false;
        private int _editingId = 0;
        private bool _isDragging = false;
        private Point _dragStart;

        public FacultyForm()
        {
            InitializeComponent();
        }

        //  FORM LOAD
        private void FacultyForm_Load(
            object sender, EventArgs e)
        {
            SetupGrid();
            LoadDepartmentCombo();
            LoadDesignationCombo();
            LoadFaculty();
        }

        //  LOAD COMBOS
        private void LoadDepartmentCombo()
        {
            try
            {
                cboDepartment.DataSource = null;
                cboDepartment.Items.Clear();

                DataTable dt =
                    DepartmentDAL.GetAllForCombo();

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
                ValidationHelper.ShowError(
                    "Failed to load departments.");
            }
        }

        private void LoadDesignationCombo()
        {
            try
            {
                cboDesignation.DataSource = null;
                cboDesignation.Items.Clear();

                DataTable dt =
                    DesignationDAL.GetAllForCombo();

                cboDesignation.DataSource = dt;
                cboDesignation.DisplayMember =
                    "designation_name";
                cboDesignation.ValueMember =
                    "designation_id";
                cboDesignation.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load designations.");
            }
        }

        //  GRID SETUP
        private void SetupGrid()
        {
            dgvFaculty.Columns.Clear();

            dgvFaculty.EnableHeadersVisualStyles
                = false;
            dgvFaculty
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvFaculty
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvFaculty
                .ColumnHeadersDefaultCellStyle
                .Font =
                    new Font("Segoe UI", 9f,
                             FontStyle.Bold);
            dgvFaculty.ColumnHeadersHeight = 36;
            dgvFaculty.ColumnHeadersHeightSizeMode
                = DataGridViewColumnHeadersHeightSizeMode
                  .DisableResizing;
            dgvFaculty
                .AlternatingRowsDefaultCellStyle
                .BackColor =
                    Color.FromArgb(240, 248, 255);
            dgvFaculty.RowTemplate.Height = 32;
            dgvFaculty.GridColor =
                Color.FromArgb(220, 230, 242);

            dgvFaculty.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                });

            dgvFaculty.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colName",
                    HeaderText = "Name",
                    Width = 180,
                    ReadOnly = true
                });

            dgvFaculty.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDept",
                    HeaderText = "Department",
                    Width = 160,
                    ReadOnly = true
                });

            dgvFaculty.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDesig",
                    HeaderText = "Designation",
                    Width = 160,
                    ReadOnly = true
                });

            dgvFaculty.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colEmpType",
                    HeaderText = "Type",
                    Width = 100,
                    ReadOnly = true
                });

            dgvFaculty.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colEmail",
                    HeaderText = "Email",
                    Width = 160,
                    ReadOnly = true
                });

            dgvFaculty.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Status",
                    Width = 80,
                    ReadOnly = true
                });

            dgvFaculty.Columns.Add(
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

            dgvFaculty.Columns.Add(
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

        //  LOAD FACULTY — uses VIEW
        private void LoadFaculty()
        {
            try
            {
                List<Faculty> list =
                    FacultyDAL.GetAll();
                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load faculty.");
            }
        }

        private void PopulateGrid(
            List<Faculty> list)
        {
            dgvFaculty.Rows.Clear();

            foreach (Faculty f in list)
            {
                dgvFaculty.Rows.Add(
                    f.EmpId,
                    f.Name,
                    f.DeptName,
                    f.DesignationName,
                    f.EmpType,
                    f.Email,
                    f.Status
                );
            }
        }

        //  SAVE — trigger fires automatically on UPDATE
        private void btnSave_Click(
            object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var faculty = new Faculty
                {
                    Name =
                        txtName.Text.Trim(),
                    DeptId =
                        Convert.ToInt32(
                            cboDepartment
                            .SelectedValue),
                    DesignationId =
                        Convert.ToInt32(
                            cboDesignation
                            .SelectedValue),
                    EmpType =
                        rbPermanent.Checked
                            ? "Permanent"
                        : rbVisiting.Checked
                            ? "Visiting"
                            : "Contractual",
                    Email =
                        txtEmail.Text.Trim(),
                    Phone =
                        txtPhone.Text.Trim(),
                    Qualification =
                        txtQualification
                        .Text.Trim(),
                    IsActive = rbActive.Checked
                };

                if (_isEditMode)
                {
                    faculty.EmpId = _editingId;

                    // Trigger trg_faculty_update_log
                    // fires automatically here
                    if (FacultyDAL.Update(faculty))
                    {
                        ValidationHelper.ShowSuccess(
                            "Faculty updated " +
                            "successfully.");
                        ClearForm();
                        LoadFaculty();
                    }
                }
                else
                {
                    if (FacultyDAL.Insert(faculty))
                    {
                        ValidationHelper.ShowSuccess(
                            "Faculty added " +
                            "successfully.");
                        ClearForm();
                        LoadFaculty();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to save faculty.\n" +
                    "Please try again.");
            }
        }

        //  VALIDATION
        private bool ValidateInputs()
        {
            if (ValidationHelper.IsEmpty(
                    txtName.Text))
            {
                ValidationHelper.ShowError(
                    "Faculty Name is required.");
                txtName.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidName(
                    txtName.Text.Trim()))
            {
                ValidationHelper.ShowError(
                    "Name should only contain " +
                    "letters and spaces.");
                txtName.Focus();
                return false;
            }

            if (cboDepartment.SelectedIndex == -1)
            {
                ValidationHelper.ShowError(
                    "Please select a Department.");
                cboDepartment.Focus();
                return false;
            }

            if (cboDesignation.SelectedIndex == -1)
            {
                ValidationHelper.ShowError(
                    "Please select a Designation.");
                cboDesignation.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidEmail(
                    txtEmail.Text.Trim()))
            {
                ValidationHelper.ShowError(
                    "Please enter a valid " +
                    "email address.");
                txtEmail.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidPhone(
                    txtPhone.Text.Trim()))
            {
                ValidationHelper.ShowError(
                    "Please enter a valid " +
                    "phone number.");
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        //  CLEAR
        private void btnClear_Click( object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtQualification.Text = "";
            cboDepartment.SelectedIndex = -1;
            cboDesignation.SelectedIndex = -1;
            rbPermanent.Checked = true;
            rbActive.Checked = true;

            _isEditMode = false;
            _editingId = 0;
            btnSave.Text = "Save";
            lblFormTitle.Text = "ADD / EDIT FACULTY";
            txtName.Focus();
        }

        //  GRID CELL CLICK
        private void dgvFaculty_CellClick( object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int empId = Convert.ToInt32(
                dgvFaculty
                    .Rows[e.RowIndex]
                    .Cells["colId"].Value);

            int editIdx =
                dgvFaculty.Columns["colEdit"].Index;
            int delIdx =
                dgvFaculty.Columns["colDelete"].Index;

            if (e.ColumnIndex == editIdx)
                LoadIntoForm(empId);
            else if (e.ColumnIndex == delIdx)
                DeleteFaculty(empId);
        }

        private void LoadIntoForm(int empId)
        {
            try
            {
                Faculty f = FacultyDAL.GetById(empId);
                if (f == null) return;

                txtName.Text = f.Name;
                txtEmail.Text = f.Email;
                txtPhone.Text = f.Phone;
                txtQualification.Text = f.Qualification;

                // Set department combo
                cboDepartment.SelectedValue =
                    f.DeptId;

                // Set designation combo
                cboDesignation.SelectedValue =
                    f.DesignationId;

                // Set emp type radio
                rbPermanent.Checked =
                    f.EmpType == "Permanent";
                rbVisiting.Checked =
                    f.EmpType == "Visiting";
                rbContractual.Checked =
                    f.EmpType == "Contractual";

                // Set status radio
                rbActive.Checked = f.IsActive;
                rbInactive.Checked = !f.IsActive;

                _isEditMode = true;
                _editingId = empId;
                btnSave.Text = "Update";
                lblFormTitle.Text = "EDIT FACULTY";
                txtName.Focus();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load faculty details.");
            }
        }

        private void DeleteFaculty(int empId)
        {
            if (FacultyDAL.HasAssignments(empId))
            {
                ValidationHelper.ShowError(
                    "Cannot delete this faculty.\n" +
                    "They have workload assignments.\n" +
                    "Please remove assignments first.");
                return;
            }

            if (!ValidationHelper.Confirm(
                "Are you sure you want to delete " +
                "this faculty member?\n" +
                "This action cannot be undone."))
                return;

            try
            {
                if (FacultyDAL.Delete(empId))
                {
                    ValidationHelper.ShowSuccess( "Faculty deleted successfully.");
                    ClearForm();
                    LoadFaculty();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError( "Failed to delete faculty.");
            }
        }

        //  SEARCH — uses STORED PROCEDURE
        private void btnSearch_Click( object sender, EventArgs e)
        {
            string keyword =  txtSearch.Text.Trim();

            if (ValidationHelper.IsEmpty(keyword))
            {
                ValidationHelper.ShowError( "Please enter a search term.");
                return;
            }

            try
            {
                // Calls sp_search_faculty
                List<Faculty> results =
                    FacultyDAL.Search(keyword);

                if (results.Count == 0)
                {
                    ValidationHelper.ShowError(
                        "No faculty found matching: "
                        + keyword);
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
            LoadFaculty();
        }

        private void txtSearch_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        //  MANAGE DESIGNATIONS BUTTON
        private void btnManageDesig_Click(
            object sender, EventArgs e)
        {
            DesignationForm form =
                new DesignationForm();
            form.ShowDialog();

            // Refresh designation combo after
            // managing designations
            LoadDesignationCombo();
        }

        //  FILE MENU
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
            LoadDepartmentCombo();
            LoadDesignationCombo();
            LoadFaculty();
        }

        private void menuExport_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show(
                "Export to PDF will be available\n" +
                "when the Reports module " +
                "is complete.",
                "Coming Soon",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void menuClose_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        //  DRAG
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