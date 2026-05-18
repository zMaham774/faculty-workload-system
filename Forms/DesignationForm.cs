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
    public partial class DesignationForm : Form
    {
        private bool _isEditMode = false;
        private int _editingId = 0;
        private bool _isDragging = false;
        private Point _dragStart;

        public DesignationForm()
        {
            InitializeComponent();
        }

        // ══════════════════════════════════════════════
        //  FORM LOAD
        // ══════════════════════════════════════════════
        private void DesignationForm_Load(
            object sender, EventArgs e)
        {
            SetupGrid();
            LoadDesignations();
        }

        // ══════════════════════════════════════════════
        //  GRID SETUP
        // ══════════════════════════════════════════════
        private void SetupGrid()
        {
            dgvDesignations.Columns.Clear();

            // Force header style
            dgvDesignations
                .EnableHeadersVisualStyles = false;

            dgvDesignations
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvDesignations
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvDesignations
                .ColumnHeadersDefaultCellStyle
                .Font =
                    new Font("Segoe UI", 9f,
                             FontStyle.Bold);
            dgvDesignations
                .ColumnHeadersHeight = 36;
            dgvDesignations
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;

            dgvDesignations
                .AlternatingRowsDefaultCellStyle
                .BackColor =
                    Color.FromArgb(240, 248, 255);

            dgvDesignations
                .RowTemplate.Height = 32;

            dgvDesignations.GridColor =
                Color.FromArgb(220, 230, 242);

            // ── Columns ───────────────────────────────
            dgvDesignations.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    Width = 60,
                    ReadOnly = true
                });

            dgvDesignations.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colName",
                    HeaderText = "Designation Name",
                    Width = 260,
                    ReadOnly = true
                });

            dgvDesignations.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colRank",
                    HeaderText = "Rank Order",
                    Width = 100,
                    ReadOnly = true
                });

            dgvDesignations.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colFaculty",
                    HeaderText = "Faculty Count",
                    Width = 120,
                    ReadOnly = true
                });

            dgvDesignations.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colEdit",
                    HeaderText = "Edit",
                    Text = "✏ Edit",
                    UseColumnTextForButtonValue
                                 = true,
                    Width = 90,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle =
                    {
                        BackColor =
                            Color.FromArgb(
                                33, 145, 245),
                        ForeColor = Color.White
                    }
                });

            dgvDesignations.Columns.Add(
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

        // ══════════════════════════════════════════════
        //  LOAD DATA — single query with faculty count
        // ══════════════════════════════════════════════
        private void LoadDesignations()
        {
            try
            {
                DataTable dt =
                    DesignationDAL
                    .GetAllWithFacultyCount();

                dgvDesignations.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvDesignations.Rows.Add(
                        row["designation_id"],
                        row["designation_name"],
                        row["rank_order"],
                        row["faculty_count"]
                            + " faculty"
                    );
                }

                lblSummary.Text =
                    "Total Designations: "
                    + dt.Rows.Count;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load designations.");
            }
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
                var d = new Designation
                {
                    DesignationName =
                        txtDesignationName
                        .Text.Trim(),
                    RankOrder =
                        (int)nudRankOrder.Value
                };

                if (_isEditMode)
                {
                    d.DesignationId = _editingId;

                    if (DesignationDAL.Update(d))
                    {
                        ValidationHelper.ShowSuccess(
                            "Designation updated " +
                            "successfully.");
                        ClearForm();
                        LoadDesignations();
                    }
                }
                else
                {
                    if (DesignationDAL.Insert(d))
                    {
                        ValidationHelper.ShowSuccess(
                            "Designation added " +
                            "successfully.");
                        ClearForm();
                        LoadDesignations();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to save designation.\n" +
                    "Please try again.");
            }
        }

        // ══════════════════════════════════════════════
        //  VALIDATION
        // ══════════════════════════════════════════════
        private bool ValidateInputs()
        {
            if (ValidationHelper.IsEmpty(
                txtDesignationName.Text))
            {
                ValidationHelper.ShowError(
                    "Designation Name is required.");
                txtDesignationName.Focus();
                return false;
            }

            if (DesignationDAL.NameExists(
                txtDesignationName.Text.Trim(),
                _editingId))
            {
                ValidationHelper.ShowError(
                    "A designation with this name " +
                    "already exists.");
                txtDesignationName.Focus();
                return false;
            }

            if (nudRankOrder.Value < 1)
            {
                ValidationHelper.ShowError(
                    "Rank Order must be at least 1.");
                nudRankOrder.Focus();
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
            txtDesignationName.Text = "";
            nudRankOrder.Value = 1;
            _isEditMode = false;
            _editingId = 0;
            btnSave.Text = "Save";
            lblFormTitle.Text =
                "ADD / EDIT DESIGNATION";
            txtDesignationName.Focus();
        }

        // ══════════════════════════════════════════════
        //  GRID CELL CLICK
        // ══════════════════════════════════════════════
        private void dgvDesignations_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(
                dgvDesignations
                    .Rows[e.RowIndex]
                    .Cells["colId"].Value);

            int editIdx = dgvDesignations
                .Columns["colEdit"].Index;
            int delIdx = dgvDesignations
                .Columns["colDelete"].Index;

            if (e.ColumnIndex == editIdx)
                LoadIntoForm(id);
            else if (e.ColumnIndex == delIdx)
                DeleteDesignation(id);
        }

        private void LoadIntoForm(int id)
        {
            try
            {
                Designation d =
                    DesignationDAL.GetById(id);
                if (d == null) return;

                txtDesignationName.Text =
                    d.DesignationName;
                nudRankOrder.Value = d.RankOrder;

                _isEditMode = true;
                _editingId = id;
                btnSave.Text = "Update";
                lblFormTitle.Text =
                    "EDIT DESIGNATION";
                txtDesignationName.Focus();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load designation.");
            }
        }

        private void DeleteDesignation(int id)
        {
            if (DesignationDAL.HasFaculty(id))
            {
                ValidationHelper.ShowError(
                    "Cannot delete this designation.\n" +
                    "Faculty members are assigned " +
                    "to it.\nPlease reassign them first.");
                return;
            }

            if (!ValidationHelper.Confirm(
                "Are you sure you want to delete " +
                "this designation?\n" +
                "This action cannot be undone."))
                return;

            try
            {
                if (DesignationDAL.Delete(id))
                {
                    ValidationHelper.ShowSuccess(
                        "Designation deleted.");
                    ClearForm();
                    LoadDesignations();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to delete designation.");
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
                List<Designation> results =
                    DesignationDAL.Search(kw);

                if (results.Count == 0)
                {
                    ValidationHelper.ShowError(
                        "No designations found " +
                        "matching: " + kw);
                    return;
                }

                dgvDesignations.Rows.Clear();

                foreach (Designation d in results)
                {
                    int fc = DesignationDAL
                        .GetFacultyCount(
                            d.DesignationId);

                    dgvDesignations.Rows.Add(
                        d.DesignationId,
                        d.DesignationName,
                        d.RankOrder,
                        fc + " faculty"
                    );
                }

                lblSummary.Text =
                    "Showing: " + results.Count
                    + " result(s)";
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
            LoadDesignations();
        }

        private void txtSearch_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        // ══════════════════════════════════════════════
        //  MENU STRIP
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
            LoadDesignations();
        }

        private void menuClose_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        // ══════════════════════════════════════════════
        //  CLOSE BUTTON ON GRADIENT PANEL
        // ══════════════════════════════════════════════
        private void btnFormClose_Click(
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
    }
}