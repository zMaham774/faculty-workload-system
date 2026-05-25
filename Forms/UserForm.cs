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
    public partial class UserForm : Form
    {
        private bool _isEditMode = false;
        private int _editingId = 0;
        private bool _isDragging = false;
        private Point _dragStart;

        public UserForm()
        {
            InitializeComponent();
        }

        //  FORM LOAD
        private void UserForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadFacultyCombo();
            LoadUsers();
        }

        //  LOAD FACULTY COMBO
        private void LoadFacultyCombo()
        {
            try
            {
                cboFaculty.DataSource = null;
                cboFaculty.Items.Clear();

                DataTable dt = FacultyDAL.GetAllForCombo();

                // Blank first row
                DataRow blank = dt.NewRow();
                blank["emp_id"] = DBNull.Value;
                blank["name"] = "-- None --";
                dt.Rows.InsertAt(blank, 0);

                cboFaculty.DataSource = dt;
                cboFaculty.DisplayMember = "name";
                cboFaculty.ValueMember = "emp_id";
                cboFaculty.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load faculty list.");
            }
        }

        //  ROLE COMBO — controls faculty combo
        //  and hint label
        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedItem == null)
                return;

            string role = cboRole.SelectedItem.ToString();

            if (role == "Admin")
            {
                cboFaculty.Enabled = false;
                btnAddFaculty.Enabled = false;
                cboFaculty.SelectedIndex = 0;
                lblFacultyHint.Text = "";
            }
            else if (role == "HOD")
            {
                cboFaculty.Enabled = true;
                btnAddFaculty.Enabled = true;
                lblFacultyHint.Text =
                    "Select the faculty member " +
                    "who is HOD of their department";
            }
            else // Faculty
            {
                cboFaculty.Enabled = true;
                btnAddFaculty.Enabled = true;
                lblFacultyHint.Text =
                    "Select the faculty member " +
                    "to link this account to";
            }
        }

        //  ADD FACULTY BUTTON
        //  Opens FacultyForm if faculty doesn't exist
        private void btnAddFaculty_Click(object sender, EventArgs e)
        {
            FacultyForm form = new FacultyForm();
            form.ShowDialog();

            // Refresh combo after adding
            LoadFacultyCombo();

            // Auto select last added faculty
            if (cboFaculty.Items.Count > 1)
                cboFaculty.SelectedIndex = cboFaculty.Items.Count - 1;
        }

        //  GRID SETUP
        private void SetupGrid()
        {
            dgvUsers.Columns.Clear();

            dgvUsers.EnableHeadersVisualStyles
                = false;
            dgvUsers
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvUsers
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvUsers
                .ColumnHeadersDefaultCellStyle
                .Font =
                    new Font("Segoe UI", 9f,
                             FontStyle.Bold);
            dgvUsers.ColumnHeadersHeight = 36;
            dgvUsers.ColumnHeadersHeightSizeMode
                = DataGridViewColumnHeadersHeightSizeMode
                  .DisableResizing;
            dgvUsers
                .AlternatingRowsDefaultCellStyle
                .BackColor =
                    Color.FromArgb(240, 248, 255);
            dgvUsers.RowTemplate.Height = 32;
            dgvUsers.GridColor =
                Color.FromArgb(220, 230, 242);

            dgvUsers.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                });

            dgvUsers.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colUsername",
                    HeaderText = "Username",
                    Width = 160,
                    ReadOnly = true
                });

            dgvUsers.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colRole",
                    HeaderText = "Role",
                    Width = 100,
                    ReadOnly = true
                });

            dgvUsers.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colFaculty",
                    HeaderText = "Linked Faculty",
                    Width = 200,
                    ReadOnly = true
                });

            dgvUsers.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Status",
                    Width = 80,
                    ReadOnly = true
                });

            dgvUsers.Columns.Add(
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

            dgvUsers.Columns.Add(
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

        //  LOAD USERS
        private void LoadUsers()
        {
            try
            {
                List<User> list =
                    UserDAL.GetAll();
                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load users.");
            }
        }

        private void PopulateGrid(List<User> list)
        {
            dgvUsers.Rows.Clear();

            foreach (User u in list)
            {
                dgvUsers.Rows.Add(
                    u.UserId,
                    u.Username,
                    u.Role,
                    u.FacultyName,
                    u.IsActive
                        ? "Active"
                        : "Inactive"
                );
            }
        }

        //  SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                // Resolve faculty ID
                int? empId = null;
                if (cboFaculty.Enabled &&
                    cboFaculty.SelectedIndex > 0 &&
                    cboFaculty.SelectedValue
                        != DBNull.Value)
                {
                    empId = Convert.ToInt32(cboFaculty.SelectedValue);
                }

                var user = new User
                {
                    Username = txtUsername.Text.Trim(),
                    Role = cboRole.SelectedItem.ToString(),
                    EmpId = empId,
                    IsActive = rbActive.Checked
                };

                if (_isEditMode)
                {
                    user.UserId = _editingId;

                    bool success;

                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        // Password changed
                        string hashed = PasswordHelper.HashPassword(txtPassword.Text);
                        success = UserDAL.UpdateWithPassword(user, hashed);
                    }
                    else
                    {
                        // Password unchanged
                        success = UserDAL.Update(user);
                    }

                    if (success)
                    {
                        ValidationHelper.ShowSuccess("User updated " + "successfully.");
                        ClearForm();
                        LoadUsers();
                    }
                }
                else
                {
                    string hashed = PasswordHelper.HashPassword(txtPassword.Text);

                    if (UserDAL.Insert(user, hashed))
                    {
                        ValidationHelper.ShowSuccess("User added " + "successfully.");
                        ClearForm();
                        LoadUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to save user.\n" + "Please try again.");
            }
        }

        //  VALIDATION
        private bool ValidateInputs()
        {
            // Username required
            if (ValidationHelper.IsEmpty(txtUsername.Text))
            {
                ValidationHelper.ShowError("Username is required.");
                txtUsername.Focus();
                return false;
            }

            // Username unique
            if (UserDAL.UsernameExists(txtUsername.Text.Trim(), _editingId))
            {
                ValidationHelper.ShowError("This username already exists.");
                txtUsername.Focus();
                return false;
            }

            // Role required
            if (cboRole.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select a Role.");
                cboRole.Focus();
                return false;
            }

            // Password required for new user
            if (!_isEditMode && ValidationHelper.IsEmpty(txtPassword.Text))
            {
                ValidationHelper.ShowError("Password is required.");
                txtPassword.Focus();
                return false;
            }

            // Password minimum length
            if (!ValidationHelper.IsEmpty(txtPassword.Text) && txtPassword.Text.Length < 6)
            {
                ValidationHelper.ShowError(
                    "Password must be at least " + "6 characters.");
                txtPassword.Focus();
                return false;
            }

            // Passwords must match
            if (!ValidationHelper.IsEmpty(txtPassword.Text) && txtPassword.Text != txtConfirmPassword.Text)
            {
                ValidationHelper.ShowError("Passwords do not match.");
                txtConfirmPassword.Focus();
                return false;
            }

            string role = cboRole.SelectedItem.ToString();

            // HOD and Faculty must be
            // linked to a faculty member
            if (role != "Admin" && cboFaculty.SelectedIndex <= 0)
            {
                ValidationHelper.ShowError(
                    "Please link this user to " +
                    "a faculty member.\n" +
                    "If the faculty member does " +
                    "not exist yet click " +
                    "'+ Add Faculty'.");
                cboFaculty.Focus();
                return false;
            }

            if (cboFaculty.Enabled && cboFaculty.SelectedIndex > 0)
            {
                int empId = Convert.ToInt32(cboFaculty.SelectedValue);

                // Faculty already has account
                if (UserDAL.FacultyHasUser(empId, _editingId))
                {
                    ValidationHelper.ShowError("This faculty member " + "already has a user " + "account.");
                    cboFaculty.Focus();
                    return false;
                }

                // Faculty already HOD
                if (role == "HOD" && UserDAL.IsAlreadyHOD(empId, _editingId))
                {
                    ValidationHelper.ShowError(
                        "This faculty member " +
                        "is already an HOD.\n" +
                        "A faculty member cannot " +
                        "be HOD of two departments.");
                    cboFaculty.Focus();
                    return false;
                }
            }

            return true;
        }

        //  CLEAR
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cboRole.SelectedIndex = -1;
            cboFaculty.SelectedIndex = 0;
            cboFaculty.Enabled = false;
            btnAddFaculty.Enabled = false;
            rbActive.Checked = true;
            lblPasswordHint.Visible = false;
            lblFacultyHint.Text = "";

            _isEditMode = false;
            _editingId = 0;
            btnSave.Text = "Save";
            lblFormTitle.Text = "ADD / EDIT USER";
            txtUsername.Focus();
        }

        //  GRID CELL CLICK
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["colId"].Value);

            int editIdx = dgvUsers.Columns["colEdit"].Index;
            int delIdx = dgvUsers.Columns["colDelete"].Index;

            if (e.ColumnIndex == editIdx)
                LoadIntoForm(userId);
            else if (e.ColumnIndex == delIdx)
                DeleteUser(userId);
        }

        private void LoadIntoForm(int userId)
        {
            try
            {
                User u = UserDAL.GetById(userId);
                if (u == null) return;

                txtUsername.Text = u.Username;
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";

                // Show hint in edit mode
                lblPasswordHint.Visible = true;

                // Set role combo
                cboRole.SelectedItem = u.Role;

                // Set faculty combo
                if (u.EmpId != null)
                {
                    cboFaculty.Enabled = true;
                    btnAddFaculty.Enabled = true;
                    cboFaculty.SelectedValue = u.EmpId;

                    // Set hint based on role
                    lblFacultyHint.Text =
                        u.Role == "HOD"
                        ? "Select the faculty " +
                          "member who is HOD of " +
                          "their department"
                        : "Select the faculty " +
                          "member to link this " +
                          "account to";
                }
                else
                {
                    cboFaculty.Enabled = false;
                    btnAddFaculty.Enabled = false;
                    cboFaculty.SelectedIndex = 0;
                    lblFacultyHint.Text = "";
                }

                rbActive.Checked = u.IsActive;
                rbInactive.Checked = !u.IsActive;

                _isEditMode = true;
                _editingId = userId;
                btnSave.Text = "Update";
                lblFormTitle.Text = "EDIT USER";
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load user details.");
            }
        }

        private void DeleteUser(int userId)
        {
            if (userId == SessionManager.UserId)
            {
                ValidationHelper.ShowError("You cannot delete " + "your own account.");
                return;
            }

            if (!ValidationHelper.Confirm(
                "Are you sure you want to " +
                "delete this user?\n" +
                "This cannot be undone."))
                return;

            try
            {
                if (UserDAL.Delete(userId))
                {
                    ValidationHelper.ShowSuccess("User deleted successfully.");
                    ClearForm();
                    LoadUsers();
                }
                else
                {
                    ValidationHelper.ShowError("Cannot delete this user.");
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to delete user.");
            }
        }

        //  SEARCH
        private void btnSearch_Click(
            object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();

            if (ValidationHelper.IsEmpty(kw))
            {
                ValidationHelper.ShowError("Please enter a search term.");
                return;
            }

            try
            {
                List<User> results = UserDAL.Search(kw);

                if (results.Count == 0)
                {
                    ValidationHelper.ShowError("No users found " + "matching: " + kw);
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
            LoadUsers();
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
            LoadFacultyCombo();
            LoadUsers();
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