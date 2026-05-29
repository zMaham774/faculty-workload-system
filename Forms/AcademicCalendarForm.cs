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
    public partial class AcademicCalendarForm : Form
    {
        private bool  _isEditMode = false;
        private int   _editingId  = 0;
        private bool  _isDragging = false;
        private Point _dragStart;

        public AcademicCalendarForm()
        {
            InitializeComponent();
        }

        //  FORM LOAD
        private void AcademicCalendarForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadSemesterCombo();
            LoadFilterCombo();
            LoadAllEvents();
        }

        //  LOAD COMBOS
        private void LoadSemesterCombo()
        {
            try
            {
                cboSemester.DataSource = null;
                cboSemester.Items.Clear();

                DataTable dt = SemesterDAL.GetAllForCombo();

                cboSemester.DataSource = dt;
                cboSemester.DisplayMember = "sem_name";
                cboSemester.ValueMember   = "sem_id";
                cboSemester.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load semesters.");
            }
        }

        private void LoadFilterCombo()
        {
            try
            {
                cboFilterSemester.DataSource = null;
                cboFilterSemester.Items.Clear();

                DataTable dt = SemesterDAL.GetAllForCombo();

                // Add show all option first
                DataRow all = dt.NewRow();
                all["sem_id"]   = 0;
                all["sem_name"] = "-- All Semesters --";
                dt.Rows.InsertAt(all, 0);

                cboFilterSemester.DataSource = dt;
                cboFilterSemester.DisplayMember = "sem_name";
                cboFilterSemester.ValueMember = "sem_id";
                cboFilterSemester.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load filter.");
            }
        }

        //  EVENT TYPE COMBO, auto set is_teaching
        private void cboEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEventType.SelectedItem == null)
                return;

            string type = cboEventType.SelectedItem.ToString();

            // WorkingDay = classes run
            // everything else = no classes
            if (type == "WorkingDay")
                rbYesClasses.Checked = true;
            else
                rbNoClasses.Checked  = true;
        }

        //  FILTER COMBO , load by semester
        private void cboFilterSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Guard against null values
            if (cboFilterSemester.SelectedValue == null)
                return;

            // 2. Safely capture the value string or handle raw DataRowView initialization
            string rawValue = cboFilterSemester.SelectedValue.ToString();

            // If it returns the class name during initial binding, skip execution
            if (rawValue == "System.Data.DataRowView")
                return;

            // 3. Try parsing the text value to an integer safely
            if (!int.TryParse(rawValue, out int semId))
                return;

            try
            {
                if (semId == 0)
                {
                    LoadAllEvents();
                }
                else
                {
                    List<AcademicCalendar> list = AcademicCalendarDAL.GetBySemester(semId);
                    PopulateGrid(list);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to filter events.");
            }
        }

        //  GRID SETUP
        private void SetupGrid()
        {
            dgvCalendar.Columns.Clear();

            dgvCalendar
                .EnableHeadersVisualStyles = false;
            dgvCalendar
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvCalendar
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvCalendar
                .ColumnHeadersDefaultCellStyle
                .Font =
                    new Font("Segoe UI", 9f,
                             FontStyle.Bold);
            dgvCalendar
                .ColumnHeadersHeight = 36;
            dgvCalendar
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;
            dgvCalendar
                .RowTemplate.Height = 36;
            dgvCalendar.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;
            dgvCalendar.GridColor =
                Color.FromArgb(220, 230, 242);
            dgvCalendar
                .DefaultCellStyle
                .SelectionBackColor =
                    Color.FromArgb(210, 228, 255);
            dgvCalendar
                .DefaultCellStyle
                .SelectionForeColor =
                    Color.FromArgb(30, 30, 30);

            dgvCalendar.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name       = "colId",
                    HeaderText = "ID",
                    Width      = 50,
                    ReadOnly   = true
                });

            dgvCalendar.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name       = "colSem",
                    HeaderText = "Semester",
                    Width      = 140,
                    ReadOnly   = true
                });

            dgvCalendar.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name       = "colEventName",
                    HeaderText = "Event Name",
                    Width      = 200,
                    ReadOnly   = true
                });

            dgvCalendar.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name       = "colEventType",
                    HeaderText = "Event Type",
                    Width      = 120,
                    ReadOnly   = true
                });

            dgvCalendar.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name       = "colDate",
                    HeaderText = "Date",
                    Width      = 110,
                    ReadOnly   = true
                });

            dgvCalendar.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name       = "colClasses",
                    HeaderText = "Classes",
                    Width      = 100,
                    ReadOnly   = true
                });

            dgvCalendar.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name       = "colEdit",
                    HeaderText = "Edit",
                    Text       = "✏ Edit",
                    UseColumnTextForButtonValue
                                 = true,
                    Width      = 80,
                    FlatStyle  = FlatStyle.Flat,
                    DefaultCellStyle =
                    {
                        BackColor =
                            Color.FromArgb(
                                33, 145, 245),
                        ForeColor = Color.White
                    }
                });

            dgvCalendar.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name       = "colDelete",
                    HeaderText = "Delete",
                    Text       = "🗑 Delete",
                    UseColumnTextForButtonValue
                                 = true,
                    Width      = 90,
                    FlatStyle  = FlatStyle.Flat,
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
        private void LoadAllEvents()
        {
            try
            {
                List<AcademicCalendar> list = AcademicCalendarDAL.GetAll();
                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load calendar events.");
            }
        }

        private void PopulateGrid(List<AcademicCalendar> list)
        {
            dgvCalendar.Rows.Clear();

            foreach (AcademicCalendar ac in list)
            {
                dgvCalendar.Rows.Add(
                    ac.CalId,
                    ac.SemName,
                    ac.EventName,
                    ac.EventType,
                    ac.EventDate
                        .ToString("dd/MM/yyyy"),
                    ac.IsTeaching
                        ? "Classes Run"
                        : "No Classes"
                );
            }

            dgvCalendar.ClearSelection();
        }

        //  CELL FORMATTING
        private void dgvCalendar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView dgv = sender as DataGridView;

            int editIdx = dgv.Columns["colEdit"].Index;
            int delIdx  = dgv.Columns["colDelete"].Index;
            int classIdx = dgv.Columns["colClasses"].Index;

            if (e.ColumnIndex != editIdx && e.ColumnIndex != delIdx)
            {
                // Colour-code Classes column
                if (e.ColumnIndex == classIdx && e.Value != null)
                {
                    if (e.Value.ToString() == "No Classes")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(180, 50, 50);
                        e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(30, 130, 70);
                        e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    }
                }

                // Alternating row colour
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

        //  SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var ac = new AcademicCalendar
                {
                    SemId = Convert.ToInt32(cboSemester.SelectedValue),
                    EventDate = dtpEventDate.Value.Date,
                    EventType = cboEventType.SelectedItem.ToString(),
                    EventName = txtEventName.Text.Trim(),
                    IsTeaching = rbYesClasses.Checked,
                    Description = txtDescription.Text.Trim(),
                    CreatedBy = SessionManager.UserId
                };

                if (_isEditMode)
                {
                    ac.CalId = _editingId;

                    if (AcademicCalendarDAL.Update(ac))
                    {
                        ValidationHelper.ShowSuccess("Calendar event updated " + "successfully.");
                        ClearForm();
                        LoadAllEvents();
                    }
                }
                else
                {
                    if (AcademicCalendarDAL.Insert(ac))
                    {
                        ValidationHelper.ShowSuccess("Calendar event added " + "successfully.");
                        ClearForm();
                        LoadAllEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to save calendar event.\n" + "Please try again.");
            }
        }

        //  VALIDATION
        private bool ValidateInputs()
        {
            if (cboSemester.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select a Semester.");
                cboSemester.Focus();
                return false;
            }

            if (cboEventType.SelectedIndex == -1)
            {
                ValidationHelper.ShowError("Please select an Event Type.");
                cboEventType.Focus();
                return false;
            }

            if (ValidationHelper.IsEmpty(txtEventName.Text))
            {
                ValidationHelper.ShowError("Event Name is required.");
                txtEventName.Focus();
                return false;
            }

            // Check date is within semester range
            int semId = Convert.ToInt32(cboSemester.SelectedValue);

            Semester sem = SemesterDAL.GetById(semId);

            if (sem != null)
            {
                if (dtpEventDate.Value.Date < sem.StartDate.Date || dtpEventDate.Value.Date > sem.EndDate.Date)
                {
                    ValidationHelper.ShowError(
                        "Event date must be within " + "the selected semester.\n" + "Semester runs from " + sem.StartDate.ToString("dd/MM/yyyy") + " to " + sem.EndDate.ToString("dd/MM/yyyy"));
                    return false;
                }
            }

            // Check duplicate
            if (AcademicCalendarDAL.Exists(semId, dtpEventDate.Value.Date, cboEventType.SelectedItem.ToString(), _editingId))
            {
                ValidationHelper.ShowError("An event of this type already " + "exists on this date for the " + "selected semester.");
                return false;
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
            cboSemester.SelectedIndex = -1;
            cboEventType.SelectedIndex = -1;
            txtEventName.Text = "";
            dtpEventDate.Value = DateTime.Today;
            rbNoClasses.Checked = true;
            txtDescription.Text = "";

            _isEditMode = false;
            _editingId  = 0;
            btnSave.Text = "Save";
            lblFormTitle.Text = "ADD / EDIT CALENDAR EVENT";
        }

        //  GRID CELL CLICK
        private void dgvCalendar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int calId = Convert.ToInt32(dgvCalendar.Rows[e.RowIndex].Cells["colId"].Value);

            int editIdx = dgvCalendar.Columns["colEdit"].Index;
            int delIdx  = dgvCalendar.Columns["colDelete"].Index;

            if (e.ColumnIndex == editIdx)
                LoadIntoForm(calId);
            else if (e.ColumnIndex == delIdx)
                DeleteEvent(calId);
        }

        private void LoadIntoForm(int calId)
        {
            try
            {
                AcademicCalendar ac = AcademicCalendarDAL.GetById(calId);
                if (ac == null) return;

                cboSemester.SelectedValue = ac.SemId;
                cboEventType.SelectedItem = ac.EventType;
                txtEventName.Text  = ac.EventName;
                dtpEventDate.Value = ac.EventDate;
                rbYesClasses.Checked = ac.IsTeaching;
                rbNoClasses.Checked  = !ac.IsTeaching;
                txtDescription.Text  = ac.Description;

                _isEditMode = true;
                _editingId = calId;
                btnSave.Text = "Update";
                lblFormTitle.Text = "EDIT CALENDAR EVENT";
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to load event details.");
            }
        }

        private void DeleteEvent(int calId)
        {
            if (!ValidationHelper.Confirm(
                "Are you sure you want to " +
                "delete this calendar event?\n" +
                "This cannot be undone."))
                return;

            try
            {
                if (AcademicCalendarDAL.Delete(calId))
                {
                    ValidationHelper.ShowSuccess("Event deleted successfully.");
                    ClearForm();
                    LoadAllEvents();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError("Failed to delete event.");
            }
        }

        //  SHOW ALL BUTTON
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cboFilterSemester.SelectedIndex = 0;
            LoadAllEvents();
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
            LoadSemesterCombo();
            LoadFilterCombo();
            LoadAllEvents();
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
                _dragStart  = e.Location;
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