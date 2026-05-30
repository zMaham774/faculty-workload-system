using FacultyWorkloadSystem.DAL;
using FacultyWorkloadSystem.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FacultyWorkloadSystem.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly Color _navy = Color.FromArgb(9, 74, 158);
        private readonly Color _sky = Color.FromArgb(33, 145, 245);
        private readonly Color _green = Color.FromArgb(13, 140, 106);
        private readonly Color _orange = Color.FromArgb(224, 123, 0);
        private readonly Color _red = Color.FromArgb(192, 57, 43);
        private readonly Color _purple = Color.FromArgb(103, 58, 183);

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(
            object sender, EventArgs e)
        {
            try
            {
                picLogo.Image =
                    FacultyWorkloadSystem.Properties
                    .Resources.Uet_logo;
            }
            catch { }
            try
            {
                SetNavIcon(picDashboard, Properties.Resources.ic_dashboard, btnDashboard, 6);

                SetNavIcon(picLogout, Properties.Resources.ic_logout, btnLogout, 2);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Icon Loading Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblAvatar.Text =
                GetInitials(SessionManager.Username);
            lblWelcome.Text =
                "Welcome back,  " +
                SessionManager.Username + "!";
            lblRole.Text =
                "Role: " + SessionManager.Role;
            lblDate.Text =
                DateTime.Now.ToString(
                    "dddd, dd MMMM yyyy");

            string sem =
                DashboardDAL.GetCurrentSemester();
            lblPageSubtitle.Text =
                sem == "No Active Semester"
                ? "No active semester — please add one"
                : sem;

            ApplySidebarPermissions();
            LoadStats();
            LoadTodaySchedule();
            LoadPendingLeaves();
            LoadUpcomingEvents();


            try
            {
                SetNavIcon(picDashboard,
                    Properties.Resources.ic_dashboard,
                    btnDashboard, 6);
                SetNavIcon(picFaculty,
                    Properties.Resources.ic_faculty,
                    btnFaculty, 50);
                SetNavIcon(picDepts,
                    Properties.Resources.ic_department,
                    btnDepts, 94);
                SetNavIcon(picCourses,
                    Properties.Resources.ic_courses,
                    btnCourses, 138);
                SetNavIcon(picWorkload,
                    Properties.Resources.ic_workload,
                    btnWorkload, 182);
                SetNavIcon(picTimetable,
                    Properties.Resources.ic_timetable,
                    btnTimetable, 226);
                SetNavIcon(picAttendance,
                    Properties.Resources.ic_attendance,
                    btnAttendance, 270);
                SetNavIcon(picLeave,
                    Properties.Resources.ic_leave,
                    btnLeave, 314);
                SetNavIcon(picLeaveApp,
                    Properties.Resources.ic_leaveapp,
                    btnLeaveApp, 358);
                SetNavIcon(picCalendar,
                    Properties.Resources.ic_calender,
                    btnCalendar, 402);
                SetNavIcon(picReports,
                    Properties.Resources.ic_reports,
                    btnReports, 446);
                SetNavIcon(picUsers,
                    Properties.Resources.ic_user,
                    btnUsers, 490);
                SetNavIcon(picSemesters,
                    Properties.Resources.ic_semester,
                    btnSemesters, 534);
                SetNavIcon(picLogout,
                    Properties.Resources.ic_logout,
                    btnLogout, 2);
            }
            catch { }
        }

        // ── Stats from DB ──────────────────────────────
        private void LoadStats()
        {
            try
            {
                lblStatFaculty.Text =
                    DashboardDAL.GetTotalFaculty()
                    .ToString();
                lblStatCourses.Text =
                    DashboardDAL.GetTotalCourses()
                    .ToString();
                lblStatDepts.Text =
                    DashboardDAL.GetTotalDepartments()
                    .ToString();
                lblStatLeaves.Text =
                    DashboardDAL.GetPendingLeaves()
                    .ToString();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        // ── Today's Schedule ───────────────────────────
        private void LoadTodaySchedule()
        {
            try
            {
                panelSchedule.Controls.Clear();
                DataTable dt =
                    DashboardDAL.GetTodaySchedule(
                        SessionManager.EmpId);

                if (dt.Rows.Count == 0)
                {
                    panelSchedule.Controls.Add(
                        NoData("No classes today."));
                    return;
                }

                Color[] clr = {
                    _sky, _green, _orange,
                    _navy, _red, _purple };
                int y = 4, ci = 0;

                foreach (DataRow row in dt.Rows)
                {
                    Color ac = clr[ci % clr.Length];
                    var card = new Panel
                    {
                        Location = new Point(4, y),
                        Size = new Size(
                            panelSchedule.Width - 12, 64),
                        BackColor = Color.White
                    };

                    card.Controls.Add(new Panel
                    {
                        Location = new Point(0, 0),
                        Size = new Size(4, 64),
                        BackColor = ac
                    });

                    card.Controls.Add(new Label
                    {
                        Text =
                            row["CourseCode"] +
                            " — " + row["CourseName"],
                        Font = new Font(
                            "Segoe UI", 9.5F,
                            FontStyle.Bold),
                        ForeColor =
                            Color.FromArgb(9, 74, 158),
                        BackColor = Color.Transparent,
                        Location = new Point(12, 8),
                        Size = new Size(
                            card.Width - 16, 20)
                    });

                    string room =
                        row["Room"] == DBNull.Value
                        ? "—"
                        : row["Room"].ToString();

                    card.Controls.Add(new Label
                    {
                        Text =
                            row["TimeSlot"] +
                            "  |  Room: " + room,
                        Font = new Font(
                            "Segoe UI", 8.5F),
                        ForeColor =
                            Color.FromArgb(
                                100, 130, 170),
                        BackColor = Color.Transparent,
                        Location = new Point(12, 32),
                        Size = new Size(
                            card.Width - 16, 18)
                    });

                    panelSchedule.Controls.Add(card);
                    y += 70; ci++;
                }
                panelSchedule.AutoScrollMinSize =
                    new Size(0, y);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        // ── Pending Leaves ─────────────────────────────
        private void LoadPendingLeaves()
        {
            try
            {
                panelLeaves.Controls.Clear();
                DataTable dt =
                    DashboardDAL.GetPendingLeaveList();

                if (dt.Rows.Count == 0)
                {
                    panelLeaves.Controls.Add(
                        NoData("No pending requests."));
                    return;
                }

                int y = 4;
                foreach (DataRow row in dt.Rows)
                {
                    string name =
                        row["FacultyName"].ToString();
                    string ini = GetInitials(name);
                    int days =
                        Convert.ToInt32(row["Days"]);

                    var card = new Panel
                    {
                        Location = new Point(4, y),
                        Size = new Size(
                            panelLeaves.Width - 12, 58),
                        BackColor = Color.White
                    };

                    var av = new Panel
                    {
                        Location = new Point(8, 10),
                        Size = new Size(36, 36),
                        BackColor =
                            Color.FromArgb(
                                220, 235, 255)
                    };
                    string ic = ini;
                    av.Paint += (s, ev) =>
                    {
                        ev.Graphics.SmoothingMode =
                            SmoothingMode.AntiAlias;
                        ev.Graphics.FillEllipse(
                            new SolidBrush(
                                Color.FromArgb(
                                    210, 230, 255)),
                            0, 0, 35, 35);
                        ev.Graphics.DrawString(ic,
                            new Font("Segoe UI", 9F,
                                FontStyle.Bold),
                            new SolidBrush(_navy),
                            new RectangleF(0, 0, 35, 35),
                            new StringFormat
                            {
                                Alignment =
                                    StringAlignment
                                    .Center,
                                LineAlignment =
                                    StringAlignment
                                    .Center
                            });
                    };

                    card.Controls.Add(av);
                    card.Controls.Add(new Label
                    {
                        Text = name,
                        Font = new Font(
                            "Segoe UI", 9F,
                            FontStyle.Bold),
                        ForeColor =
                            Color.FromArgb(9, 74, 158),
                        BackColor = Color.Transparent,
                        Location = new Point(52, 8),
                        Size = new Size(
                            card.Width - 130, 18)
                    });
                    card.Controls.Add(new Label
                    {
                        Text =
                            row["LeaveType"] +
                            " · " + days + " day(s)",
                        Font = new Font(
                            "Segoe UI", 8F),
                        ForeColor =
                            Color.FromArgb(
                                100, 130, 170),
                        BackColor = Color.Transparent,
                        Location = new Point(52, 28),
                        Size = new Size(
                            card.Width - 130, 16)
                    });
                    card.Controls.Add(new Label
                    {
                        Text = "Pending",
                        Font = new Font(
                            "Segoe UI", 7.5F,
                            FontStyle.Bold),
                        ForeColor = _orange,
                        BackColor =
                            Color.FromArgb(
                                255, 243, 224),
                        Location = new Point(
                            card.Width - 78, 16),
                        Size = new Size(70, 22),
                        TextAlign =
                            ContentAlignment
                            .MiddleCenter
                    });

                    panelLeaves.Controls.Add(card);
                    panelLeaves.Controls.Add(
                        new Panel
                        {
                            Location =
                                new Point(8, y + 57),
                            Size = new Size(
                                panelLeaves.Width
                                - 20, 1),
                            BackColor =
                                Color.FromArgb(
                                    230, 235, 245)
                        });
                    y += 64;
                }
                panelLeaves.AutoScrollMinSize =
                    new Size(0, y);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
            }
        }

        // ── Upcoming Events ────────────────────────────
        private void LoadUpcomingEvents()
        {
            try
            {
                DataTable dt =
                    DashboardDAL.GetUpcomingEvents();
                if (dt.Rows.Count == 0)
                {
                    lblEventBanner.Text =
                        "No upcoming events " +
                        "in the current semester.";
                    return;
                }
                DataRow r = dt.Rows[0];
                DateTime d =
                    Convert.ToDateTime(
                        r["event_date"]);
                int days =
                    (d - DateTime.Today).Days;
                lblEventBanner.Text =
                    "Upcoming: " +
                    r["event_name"] +
                    "  —  in " + days +
                    " days  (" +
                    d.ToString("MMM dd, yyyy") + ")";
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                lblEventBanner.Text =
                    "Could not load events.";
            }
        }

        // ── Role Permissions ───────────────────────────
        private void ApplySidebarPermissions()
        {
            string role = SessionManager.Role;
            bool isAdmin = (role == "Admin");
            bool isHOD = (role == "HOD");

            // Admin only
            btnFaculty.Visible = isAdmin;
            btnDepts.Visible = isAdmin;
            btnCalendar.Visible = isAdmin;
            btnUsers.Visible = isAdmin;
            btnSemesters.Visible = isAdmin;

            // Admin + HOD
            btnCourses.Visible = isAdmin || isHOD;
            btnWorkload.Visible = isAdmin || isHOD;
            btnLeaveApp.Visible = isAdmin || isHOD;
            btnReports.Visible = isAdmin || isHOD;

            // Everyone
            btnTimetable.Visible = true;
            btnAttendance.Visible = true;
            btnLeave.Visible = true;
        }

        // ── Nav Clicks ─────────────────────────────────
        private void btnFaculty_Click( object sender, EventArgs e)
        {
            FacultyForm facultyForm = new FacultyForm();
            this.Hide();
            facultyForm.ShowDialog();
            this.Show();
        }

        private void btnDepts_Click(object sender, EventArgs e)
        {
            DepartmentForm deptForm = new DepartmentForm();
            this.Hide();
            deptForm.ShowDialog();
            this.Show();
        }

        private void btnCourses_Click(object s, EventArgs e)
        {
            CourseForm form = new CourseForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnWorkload_Click(object sender, EventArgs e)
        {
            WorkloadAssignmentForm workloadForm = new WorkloadAssignmentForm();
            this.Hide();
            workloadForm.ShowDialog();
            this.Show();
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            TimetableForm timetableForm = new TimetableForm();
            this.Hide();
            timetableForm.ShowDialog();
            this.Show();
        }

        private void btnAttendance_Click(
            object s, EventArgs e) =>
            MessageBox.Show(
                "Attendance — Coming Soon",
                "Info", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        private void btnLeave_Click(
            object s, EventArgs e) =>
            MessageBox.Show("Leave — Coming Soon",
                "Info", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        private void btnLeaveApp_Click(
            object s, EventArgs e) =>
            MessageBox.Show(
                "Leave Approval — Coming Soon",
                "Info", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            AcademicCalendarForm calendarForm = new AcademicCalendarForm();
            this.Hide();
            calendarForm.ShowDialog();
            this.Show();
        }

        private void btnReports_Click(
            object s, EventArgs e) =>
            MessageBox.Show("Reports — Coming Soon",
                "Info", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            this.Hide();
            userForm.ShowDialog();
            this.Show();
        }

        private void btnSemesters_Click(object s, EventArgs e)
        {
            SemesterForm form = new SemesterForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnLogout_Click(
            object s, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                LogManager.LogInfo(
                    "User '" +
                    SessionManager.Username +
                    "' logged out.");
                SessionManager.Clear();
                this.Hide();
                new LoginForm().Show();
            }
        }

        // ── Helpers ────────────────────────────────────
        private string GetInitials(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "?";
            var p = name.Trim().Split(' ');
            return p.Length == 1
                ? p[0].Substring(0, 1).ToUpper()
                : (p[0].Substring(0, 1) +
                   p[p.Length - 1].Substring(0, 1))
                  .ToUpper();
        }

        private Label NoData(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9F),
                ForeColor =
                    Color.FromArgb(150, 150, 160),
                Location = new Point(12, 14),
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }

        protected override void OnPaint(
            PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode =
                SmoothingMode.AntiAlias;
            g.FillRectangle(
                new SolidBrush(
                    Color.FromArgb(244, 248, 255)),
                210, 0,
                this.Width - 210, this.Height);
            using (var b = new SolidBrush(
                Color.FromArgb(16, 33, 145, 245)))
                g.FillEllipse(b,
                    this.Width - 300, -80, 380, 380);
            using (var b = new SolidBrush(
                Color.FromArgb(12, 9, 74, 158)))
                g.FillEllipse(b,
                    160, this.Height - 220, 280, 280);
            using (var b = new SolidBrush(
                Color.FromArgb(10, 33, 145, 245)))
                g.FillEllipse(b,
                    this.Width / 2 - 140,
                    this.Height - 160, 260, 260);
        }

        private void SetNavIcon(
         System.Windows.Forms.PictureBox pic,
         System.Drawing.Image img,
         System.Windows.Forms.Button btn,
         int yPos)
        {
            if (img == null) return;

            pic.Image = img;
            pic.Size = new Size(18, 18);

            pic.Location = new Point(14, (btn.Height - pic.Height) / 2);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic.BackColor = Color.Transparent;


            btn.Controls.Add(pic);


            pic.BringToFront();

            btn.Padding = new System.Windows.Forms.Padding(36, 0, 0, 0);
        }


    }
}