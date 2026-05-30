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
    public partial class TimetableForm : Form
    {
        private bool _isEditMode = false;
        private int _editingId = 0;
        private int _editWaId = 0;
        private bool _isDragging = false;
        private Point _dragStart;

        public TimetableForm()
        {
            InitializeComponent();
        }

        // ══════════════════════════════════════════════
        //  FORM LOAD
        // ══════════════════════════════════════════════
        private void TimetableForm_Load(
            object sender, EventArgs e)
        {
            SetupGrid();
            LoadAssignmentCombo();
            LoadTimeSlotCombo();
            LoadFilterCombos();
            LoadTimetable();
        }

        // ══════════════════════════════════════════════
        //  LOAD COMBOS
        // ══════════════════════════════════════════════
        private void LoadAssignmentCombo()
        {
            try
            {
                cboAssignment.DataSource = null;
                cboAssignment.Items.Clear();

                DataTable dt =
                    TimetableDAL
                    .GetAssignmentsForCombo();

                cboAssignment.DataSource = dt;
                cboAssignment.DisplayMember =
                    "assignment_display";
                cboAssignment.ValueMember =
                    "wa_id";
                cboAssignment.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load assignments.");
            }
        }

        private void LoadTimeSlotCombo()
        {
            try
            {
                cboTimeSlot.DataSource = null;
                cboTimeSlot.Items.Clear();

                DataTable dt =
                    TimeSlotDAL.GetAllForCombo();

                cboTimeSlot.DataSource = dt;
                cboTimeSlot.DisplayMember =
                    "slot_label";
                cboTimeSlot.ValueMember =
                    "slot_id";
                cboTimeSlot.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load time slots.");
            }
        }

        private void LoadFilterCombos()
        {
            try
            {
                // Filter semester
                DataTable semDt =
                    SemesterDAL.GetAllForCombo();

                DataRow allSem = semDt.NewRow();
                allSem["sem_id"] = 0;
                allSem["sem_name"] =
                    "-- All Semesters --";
                semDt.Rows.InsertAt(allSem, 0);

                cboFilterSemester.DataSource
                    = semDt;
                cboFilterSemester.DisplayMember
                    = "sem_name";
                cboFilterSemester.ValueMember
                    = "sem_id";
                cboFilterSemester.SelectedIndex
                    = 0;

                // Filter faculty
                DataTable facDt =
                    FacultyDAL.GetAllForCombo();

                DataRow allFac = facDt.NewRow();
                allFac["emp_id"] = 0;
                allFac["name"] =
                    "-- All Faculty --";
                facDt.Rows.InsertAt(allFac, 0);

                cboFilterFaculty.DataSource
                    = facDt;
                cboFilterFaculty.DisplayMember
                    = "name";
                cboFilterFaculty.ValueMember
                    = "emp_id";
                cboFilterFaculty.SelectedIndex
                    = 0;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load filters.");
            }
        }

        // ══════════════════════════════════════════════
        //  CONFLICT CHECK — fires on day/slot/room change
        // ══════════════════════════════════════════════
        private void cboDayOfWeek_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            CheckConflictDisplay();
        }

        private void cboTimeSlot_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            CheckConflictDisplay();
        }

        private void txtRoom_TextChanged(
            object sender, EventArgs e)
        {
            CheckConflictDisplay();
        }

        private void CheckConflictDisplay()
        {
            if (cboDayOfWeek.SelectedIndex < 0 ||
                cboTimeSlot.SelectedIndex < 0 ||
                string.IsNullOrEmpty(
                    txtRoom.Text.Trim()))
            {
                lblConflict.Visible = false;
                return;
            }

            try
            {
                int slotId = Convert.ToInt32(
                    cboTimeSlot.SelectedValue);
                string day =
                    cboDayOfWeek.SelectedItem
                                .ToString();
                string room = txtRoom.Text.Trim();

                bool conflict =
                    TimetableDAL.CheckConflict(
                        slotId, day, room,
                        _editingId);

                lblConflict.Visible = conflict;
            }
            catch
            {
                lblConflict.Visible = false;
            }
        }

        // ══════════════════════════════════════════════
        //  GRID SETUP
        // ══════════════════════════════════════════════
        private void SetupGrid()
        {
            dgvTimetable.Columns.Clear();

            dgvTimetable
                .EnableHeadersVisualStyles = false;
            dgvTimetable
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(9, 74, 158);
            dgvTimetable
                .ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
            dgvTimetable
                .ColumnHeadersDefaultCellStyle
                .Font =
                    new Font("Segoe UI", 9f,
                             FontStyle.Bold);
            dgvTimetable
                .ColumnHeadersHeight = 36;
            dgvTimetable
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;
            dgvTimetable
                .RowTemplate.Height = 36;
            dgvTimetable.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;
            dgvTimetable.GridColor =
                Color.FromArgb(220, 230, 242);
            dgvTimetable
                .DefaultCellStyle
                .SelectionBackColor =
                    Color.FromArgb(210, 228, 255);
            dgvTimetable
                .DefaultCellStyle
                .SelectionForeColor =
                    Color.FromArgb(30, 30, 30);

            dgvTimetable.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                });

            dgvTimetable.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colFaculty",
                    HeaderText = "Faculty",
                    Width = 180,
                    ReadOnly = true
                });

            dgvTimetable.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colCourse",
                    HeaderText = "Course",
                    Width = 160,
                    ReadOnly = true
                });

            dgvTimetable.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSem",
                    HeaderText = "Semester",
                    Width = 120,
                    ReadOnly = true
                });

            dgvTimetable.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDay",
                    HeaderText = "Day",
                    Width = 100,
                    ReadOnly = true
                });

            dgvTimetable.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSlot",
                    HeaderText = "Time Slot",
                    Width = 140,
                    ReadOnly = true
                });

            dgvTimetable.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colRoom",
                    HeaderText = "Room",
                    Width = 80,
                    ReadOnly = true
                });

            dgvTimetable.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colConflict",
                    HeaderText = "Conflict",
                    Width = 80,
                    ReadOnly = true
                });

            dgvTimetable.Columns.Add(
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

            dgvTimetable.Columns.Add(
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
        //  LOAD TIMETABLE
        // ══════════════════════════════════════════════
        private void LoadTimetable()
        {
            try
            {
                List<Timetable> list =
                    TimetableDAL.GetAll();
                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load timetable.");
            }
        }

        private void PopulateGrid(
            List<Timetable> list)
        {
            dgvTimetable.Rows.Clear();

            foreach (Timetable tt in list)
            {
                dgvTimetable.Rows.Add(
                    tt.TtId,
                    tt.FacultyName,
                    tt.CourseCode + " - " +
                        tt.CourseTitle,
                    tt.SemName,
                    tt.DayOfWeek,
                    tt.SlotLabel,
                    tt.Room,
                    tt.ConflictFlag
                        ? "⚠ Yes" : "No"
                );
            }

            dgvTimetable.ClearSelection();
        }

        // ══════════════════════════════════════════════
        //  CELL FORMATTING
        // ══════════════════════════════════════════════
        private void dgvTimetable_CellFormatting(
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
            int confIdx =
                dgv.Columns["colConflict"].Index;

            if (e.ColumnIndex != editIdx &&
                e.ColumnIndex != delIdx)
            {
                // Colour conflict column
                if (e.ColumnIndex == confIdx &&
                    e.Value != null)
                {
                    if (e.Value.ToString()
                            .StartsWith("⚠"))
                    {
                        e.CellStyle.ForeColor =
                            Color.FromArgb(
                                200, 80, 0);
                        e.CellStyle.Font =
                            new Font("Segoe UI",
                                9f, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor =
                            Color.FromArgb(
                                30, 130, 70);
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

        // ══════════════════════════════════════════════
        //  SAVE — uses TRANSACTION
        // ══════════════════════════════════════════════
        private void btnSave_Click(
            object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var tt = new Timetable
                {
                    WaId = Convert.ToInt32(
                        cboAssignment.SelectedValue),
                    DayOfWeek =
                        cboDayOfWeek.SelectedItem
                                    .ToString(),
                    SlotId = Convert.ToInt32(
                        cboTimeSlot.SelectedValue),
                    Room = txtRoom.Text.Trim()
                };

                if (_isEditMode)
                {
                    tt.TtId = _editingId;
                    tt.WaId = _editWaId;

                    if (TimetableDAL.Update(tt))
                    {
                        ValidationHelper
                            .ShowSuccess(
                            "Timetable entry updated.");
                        ClearForm();
                        LoadTimetable();
                    }
                }
                else
                {
                    // Transaction:
                    // INSERT timetable +
                    // UPDATE workload total_hours
                    if (TimetableDAL.Insert(tt))
                    {
                        ValidationHelper
                            .ShowSuccess(
                            "Timetable entry added.\n" +
                            "Workload hours updated.");
                        ClearForm();
                        LoadTimetable();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to save timetable.\n" +
                    "Changes were rolled back.");
            }
        }

        // ══════════════════════════════════════════════
        //  VALIDATION
        // ══════════════════════════════════════════════
        private bool ValidateInputs()
        {
            if (cboAssignment.SelectedIndex < 0 ||
                cboAssignment.SelectedValue == null)
            {
                ValidationHelper.ShowError(
                    "Please select a " +
                    "Workload Assignment.");
                cboAssignment.Focus();
                return false;
            }

            if (cboDayOfWeek.SelectedIndex < 0)
            {
                ValidationHelper.ShowError(
                    "Please select a Day of Week.");
                cboDayOfWeek.Focus();
                return false;
            }

            if (cboTimeSlot.SelectedIndex < 0 ||
                cboTimeSlot.SelectedValue == null)
            {
                ValidationHelper.ShowError(
                    "Please select a Time Slot.");
                cboTimeSlot.Focus();
                return false;
            }

            int waId = Convert.ToInt32(
                cboAssignment.SelectedValue);
            string day =
                cboDayOfWeek.SelectedItem.ToString();
            int slotId = Convert.ToInt32(
                cboTimeSlot.SelectedValue);

            // Duplicate slot check
            if (TimetableDAL.SlotExists(
                    waId, day, slotId, _editingId))
            {
                ValidationHelper.ShowError(
                    "This assignment already has " +
                    "a slot on " + day +
                    " at this time.");
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
            cboAssignment.SelectedIndex = -1;
            cboDayOfWeek.SelectedIndex = -1;
            cboTimeSlot.SelectedIndex = -1;
            txtRoom.Text = "";
            lblConflict.Visible = false;

            _isEditMode = false;
            _editingId = 0;
            _editWaId = 0;
            btnSave.Text = "Save";
            lblFormTitle.Text =
                "ADD / EDIT TIMETABLE ENTRY";
        }

        // ══════════════════════════════════════════════
        //  GRID CELL CLICK
        // ══════════════════════════════════════════════
        private void dgvTimetable_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int ttId = Convert.ToInt32(
                dgvTimetable
                    .Rows[e.RowIndex]
                    .Cells["colId"].Value);

            int editIdx = dgvTimetable
                .Columns["colEdit"].Index;
            int delIdx = dgvTimetable
                .Columns["colDelete"].Index;

            if (e.ColumnIndex == editIdx)
                LoadIntoForm(ttId);
            else if (e.ColumnIndex == delIdx)
                DeleteEntry(ttId);
        }

        private void LoadIntoForm(int ttId)
        {
            try
            {
                Timetable tt =
                    TimetableDAL.GetById(ttId);
                if (tt == null) return;

                cboAssignment.SelectedValue =
                    tt.WaId;
                cboDayOfWeek.SelectedItem =
                    tt.DayOfWeek;
                cboTimeSlot.SelectedValue =
                    tt.SlotId;
                txtRoom.Text = tt.Room;

                _isEditMode = true;
                _editingId = ttId;
                _editWaId = tt.WaId;
                btnSave.Text = "Update";
                lblFormTitle.Text =
                    "EDIT TIMETABLE ENTRY";

                // Show conflict if exists
                lblConflict.Visible =
                    tt.ConflictFlag;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to load entry.");
            }
        }

        private void DeleteEntry(int ttId)
        {
            if (!ValidationHelper.Confirm(
                "Delete this timetable entry?\n" +
                "Workload hours will be " +
                "recalculated.\n" +
                "This cannot be undone."))
                return;

            try
            {
                // Get waId before delete
                // for hours recalculation
                Timetable tt =
                    TimetableDAL.GetById(ttId);
                if (tt == null) return;

                if (TimetableDAL.Delete(
                        ttId, tt.WaId))
                {
                    ValidationHelper.ShowSuccess(
                        "Entry deleted.\n" +
                        "Workload hours updated.");
                    ClearForm();
                    LoadTimetable();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Failed to delete entry.");
            }
        }

        // ══════════════════════════════════════════════
        //  FILTER
        // ══════════════════════════════════════════════
        private void btnFilter_Click(
            object sender, EventArgs e)
        {
            try
            {
                int semId = cboFilterSemester
                    .SelectedIndex < 0 ? 0
                    : Convert.ToInt32(
                        cboFilterSemester
                        .SelectedValue);

                int empId = cboFilterFaculty
                    .SelectedIndex < 0 ? 0
                    : Convert.ToInt32(
                        cboFilterFaculty
                        .SelectedValue);

                string day =
                    cboFilterDay.SelectedIndex <= 0
                    ? ""
                    : cboFilterDay.SelectedItem
                                  .ToString();

                List<Timetable> list =
                    TimetableDAL.GetFiltered(
                        semId, empId, day);

                if (list.Count == 0)
                {
                    ValidationHelper.ShowError(
                        "No entries found for " +
                        "selected filters.");
                    return;
                }

                PopulateGrid(list);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                ValidationHelper.ShowError(
                    "Filter failed.");
            }
        }

        private void btnShowAll_Click(
            object sender, EventArgs e)
        {
            cboFilterSemester.SelectedIndex = 0;
            cboFilterFaculty.SelectedIndex = 0;
            cboFilterDay.SelectedIndex = 0;
            LoadTimetable();
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
            LoadAssignmentCombo();
            LoadTimeSlotCombo();
            LoadFilterCombos();
            LoadTimetable();
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
    }
}