namespace FacultyWorkloadSystem.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer
            components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            // ── Sidebar controls ──────────────────────
            this.panelSidebar =
                new System.Windows.Forms.Panel();
            this.picLogo =
                new System.Windows.Forms.PictureBox();
            this.lblAppName =
                new System.Windows.Forms.Label();
            this.lblAppSub =
                new System.Windows.Forms.Label();
            this.panelNav =
                new System.Windows.Forms.Panel();

            // Nav buttons — each declared separately
            this.btnDashboard =
                new System.Windows.Forms.Button();
            this.btnFaculty =
                new System.Windows.Forms.Button();
            this.btnDepts =
                new System.Windows.Forms.Button();
            this.btnCourses =
                new System.Windows.Forms.Button();
            this.btnWorkload =
                new System.Windows.Forms.Button();
            this.btnTimetable =
                new System.Windows.Forms.Button();
            this.btnAttendance =
                new System.Windows.Forms.Button();
            this.btnLeave =
                new System.Windows.Forms.Button();
            this.btnLeaveApp =
                new System.Windows.Forms.Button();
            this.btnCalendar =
                new System.Windows.Forms.Button();
            this.btnReports =
                new System.Windows.Forms.Button();
            this.btnUsers =
                new System.Windows.Forms.Button();
            this.btnSemesters =
                new System.Windows.Forms.Button();
            this.btnLogout =
                new System.Windows.Forms.Button();

            // ── Main area controls ────────────────────
            this.panelMain =
                new System.Windows.Forms.Panel();
            this.panelTopBar =
                new System.Windows.Forms.Panel();
            this.lblPageTitle =
                new System.Windows.Forms.Label();
            this.lblPageSubtitle =
                new System.Windows.Forms.Label();
            this.lblWelcome =
                new System.Windows.Forms.Label();
            this.lblRole =
                new System.Windows.Forms.Label();
            this.lblDate =
                new System.Windows.Forms.Label();
            this.lblAvatar =
                new System.Windows.Forms.Label();

            // Stat cards
            this.cardFaculty =
                new System.Windows.Forms.Panel();
            this.lblStatFacultyTitle =
                new System.Windows.Forms.Label();
            this.lblStatFaculty =
                new System.Windows.Forms.Label();
            this.lblStatFacultySub =
                new System.Windows.Forms.Label();

            this.cardCourses =
                new System.Windows.Forms.Panel();
            this.lblStatCoursesTitle =
                new System.Windows.Forms.Label();
            this.lblStatCourses =
                new System.Windows.Forms.Label();
            this.lblStatCoursesSub =
                new System.Windows.Forms.Label();

            this.cardDepts =
                new System.Windows.Forms.Panel();
            this.lblStatDeptsTitle =
                new System.Windows.Forms.Label();
            this.lblStatDepts =
                new System.Windows.Forms.Label();
            this.lblStatDeptsSub =
                new System.Windows.Forms.Label();

            this.cardLeaves =
                new System.Windows.Forms.Panel();
            this.lblStatLeavesTitle =
                new System.Windows.Forms.Label();
            this.lblStatLeaves =
                new System.Windows.Forms.Label();
            this.lblStatLeavesSub =
                new System.Windows.Forms.Label();

            // Schedule + Leaves panels
            this.panelSchedCard =
                new System.Windows.Forms.Panel();
            this.lblSchedTitle =
                new System.Windows.Forms.Label();
            this.panelSchedule =
                new System.Windows.Forms.Panel();

            this.panelLeavesCard =
                new System.Windows.Forms.Panel();
            this.lblLeavesTitle =
                new System.Windows.Forms.Label();
            this.panelLeaves =
                new System.Windows.Forms.Panel();

            // Banner
            this.panelBanner =
                new System.Windows.Forms.Panel();
            this.lblEventBanner =
                new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.picLogo)).BeginInit();
            this.panelSidebar.SuspendLayout();
            this.panelNav.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            this.cardFaculty.SuspendLayout();
            this.cardCourses.SuspendLayout();
            this.cardDepts.SuspendLayout();
            this.cardLeaves.SuspendLayout();
            this.panelSchedCard.SuspendLayout();
            this.panelLeavesCard.SuspendLayout();
            this.panelBanner.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════
            // SIDEBAR
            // ══════════════════════════════════════════
            this.panelSidebar.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.panelSidebar.Location =
                new System.Drawing.Point(0, 0);
            this.panelSidebar.Size =
                new System.Drawing.Size(210, 660);
            this.panelSidebar.Controls.Add(
                this.picLogo);
            this.panelSidebar.Controls.Add(
                this.lblAppName);
            this.panelSidebar.Controls.Add(
                this.lblAppSub);
            this.panelSidebar.Controls.Add(
                this.panelNav);
            this.panelSidebar.Controls.Add(
                this.btnLogout);

            // Logo
            this.picLogo.Location =
                new System.Drawing.Point(10, 12);
            this.picLogo.Size =
                new System.Drawing.Size(42, 42);
            this.picLogo.SizeMode =
                System.Windows.Forms
                .PictureBoxSizeMode.StretchImage;
            this.picLogo.BackColor =
                System.Drawing.Color.Transparent;

            // App name labels
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor =
                System.Drawing.Color.Transparent;
            this.lblAppName.Font =
                new System.Drawing.Font(
                    "Segoe UI", 11F,
                    System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor =
                System.Drawing.Color.White;
            this.lblAppName.Location =
                new System.Drawing.Point(58, 12);
            this.lblAppName.Text = "FACULTY";

            this.lblAppSub.AutoSize = true;
            this.lblAppSub.BackColor =
                System.Drawing.Color.Transparent;
            this.lblAppSub.Font =
                new System.Drawing.Font(
                    "Segoe UI", 7F);
            this.lblAppSub.ForeColor =
                System.Drawing.Color.FromArgb(
                    160, 200, 240);
            this.lblAppSub.Location =
                new System.Drawing.Point(58, 34);
            this.lblAppSub.Text =
                "MANAGEMENT SYSTEM";

            // Nav panel
            this.panelNav.AutoScroll = true;
            this.panelNav.BackColor =
                System.Drawing.Color.Transparent;
            this.panelNav.Location =
                new System.Drawing.Point(0, 62);
            this.panelNav.Size =
                new System.Drawing.Size(210, 558);

            // ── Helper inline setup ────────────────────
            System.Drawing.Color navBlue =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            System.Drawing.Color navText =
                System.Drawing.Color.FromArgb(
                    170, 210, 250);
            System.Drawing.Color navHover =
                System.Drawing.Color.FromArgb(
                    50, 33, 145, 245);
            System.Drawing.Font navFont =
                new System.Drawing.Font(
                    "Segoe UI", 9.5F);

            // Dashboard (active)
            this.btnDashboard.BackColor = navBlue;
            this.btnDashboard.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.FlatAppearance
                .BorderSize = 0;
            this.btnDashboard.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnDashboard.Font = navFont;
            this.btnDashboard.ForeColor =
                System.Drawing.Color.White;
            this.btnDashboard.Location =
                new System.Drawing.Point(0, 6);
            this.btnDashboard.Size =
                new System.Drawing.Size(210, 40);
            this.btnDashboard.Text =
                "  Dashboard";
            this.btnDashboard.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnDashboard.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnDashboard.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // Faculty
            this.btnFaculty.BackColor =
                System.Drawing.Color.Transparent;
            this.btnFaculty.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnFaculty.FlatAppearance
                .BorderSize = 0;
            this.btnFaculty.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnFaculty.Font = navFont;
            this.btnFaculty.ForeColor = navText;
            this.btnFaculty.Location =
                new System.Drawing.Point(0, 50);
            this.btnFaculty.Size =
                new System.Drawing.Size(210, 40);
            this.btnFaculty.Text = "  Faculty";
            this.btnFaculty.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnFaculty.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnFaculty.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnFaculty.Click +=
                new System.EventHandler(
                    this.btnFaculty_Click);

            // Departments
            this.btnDepts.BackColor =
                System.Drawing.Color.Transparent;
            this.btnDepts.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnDepts.FlatAppearance
                .BorderSize = 0;
            this.btnDepts.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnDepts.Font = navFont;
            this.btnDepts.ForeColor = navText;
            this.btnDepts.Location =
                new System.Drawing.Point(0, 94);
            this.btnDepts.Size =
                new System.Drawing.Size(210, 40);
            this.btnDepts.Text = "  Departments";
            this.btnDepts.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnDepts.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnDepts.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnDepts.Click +=
                new System.EventHandler(
                    this.btnDepts_Click);

            // Courses
            this.btnCourses.BackColor =
                System.Drawing.Color.Transparent;
            this.btnCourses.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnCourses.FlatAppearance
                .BorderSize = 0;
            this.btnCourses.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnCourses.Font = navFont;
            this.btnCourses.ForeColor = navText;
            this.btnCourses.Location =
                new System.Drawing.Point(0, 138);
            this.btnCourses.Size =
                new System.Drawing.Size(210, 40);
            this.btnCourses.Text = "  Courses";
            this.btnCourses.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnCourses.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnCourses.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnCourses.Click +=
                new System.EventHandler(
                    this.btnCourses_Click);

            // Workload
            this.btnWorkload.BackColor =
                System.Drawing.Color.Transparent;
            this.btnWorkload.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkload.FlatAppearance
                .BorderSize = 0;
            this.btnWorkload.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnWorkload.Font = navFont;
            this.btnWorkload.ForeColor = navText;
            this.btnWorkload.Location =
                new System.Drawing.Point(0, 182);
            this.btnWorkload.Size =
                new System.Drawing.Size(210, 40);
            this.btnWorkload.Text = "  Workload";
            this.btnWorkload.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnWorkload.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnWorkload.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnWorkload.Click +=
                new System.EventHandler(
                    this.btnWorkload_Click);

            // Timetable
            this.btnTimetable.BackColor =
                System.Drawing.Color.Transparent;
            this.btnTimetable.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnTimetable.FlatAppearance
                .BorderSize = 0;
            this.btnTimetable.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnTimetable.Font = navFont;
            this.btnTimetable.ForeColor = navText;
            this.btnTimetable.Location =
                new System.Drawing.Point(0, 226);
            this.btnTimetable.Size =
                new System.Drawing.Size(210, 40);
            this.btnTimetable.Text = "  Timetable";
            this.btnTimetable.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnTimetable.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnTimetable.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnTimetable.Click +=
                new System.EventHandler(
                    this.btnTimetable_Click);

            // Attendance
            this.btnAttendance.BackColor =
                System.Drawing.Color.Transparent;
            this.btnAttendance.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.FlatAppearance
                .BorderSize = 0;
            this.btnAttendance.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnAttendance.Font = navFont;
            this.btnAttendance.ForeColor = navText;
            this.btnAttendance.Location =
                new System.Drawing.Point(0, 270);
            this.btnAttendance.Size =
                new System.Drawing.Size(210, 40);
            this.btnAttendance.Text =
                "  Attendance";
            this.btnAttendance.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnAttendance.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnAttendance.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnAttendance.Click +=
                new System.EventHandler(
                    this.btnAttendance_Click);

            // Leave
            this.btnLeave.BackColor =
                System.Drawing.Color.Transparent;
            this.btnLeave.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLeave.FlatAppearance
                .BorderSize = 0;
            this.btnLeave.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnLeave.Font = navFont;
            this.btnLeave.ForeColor = navText;
            this.btnLeave.Location =
                new System.Drawing.Point(0, 314);
            this.btnLeave.Size =
                new System.Drawing.Size(210, 40);
            this.btnLeave.Text = "  Leave";
            this.btnLeave.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnLeave.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnLeave.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnLeave.Click +=
                new System.EventHandler(
                    this.btnLeave_Click);

            // Leave Approval
            this.btnLeaveApp.BackColor =
                System.Drawing.Color.Transparent;
            this.btnLeaveApp.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveApp.FlatAppearance
                .BorderSize = 0;
            this.btnLeaveApp.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnLeaveApp.Font = navFont;
            this.btnLeaveApp.ForeColor = navText;
            this.btnLeaveApp.Location =
                new System.Drawing.Point(0, 358);
            this.btnLeaveApp.Size =
                new System.Drawing.Size(210, 40);
            this.btnLeaveApp.Text =
                "  Leave Approval";
            this.btnLeaveApp.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnLeaveApp.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnLeaveApp.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnLeaveApp.Click +=
                new System.EventHandler(
                    this.btnLeaveApp_Click);

            // Calendar
            this.btnCalendar.BackColor =
                System.Drawing.Color.Transparent;
            this.btnCalendar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendar.FlatAppearance
                .BorderSize = 0;
            this.btnCalendar.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnCalendar.Font = navFont;
            this.btnCalendar.ForeColor = navText;
            this.btnCalendar.Location =
                new System.Drawing.Point(0, 402);
            this.btnCalendar.Size =
                new System.Drawing.Size(210, 40);
            this.btnCalendar.Text =
                "  Calendar";
            this.btnCalendar.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnCalendar.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnCalendar.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnCalendar.Click +=
                new System.EventHandler(
                    this.btnCalendar_Click);

            // Reports
            this.btnReports.BackColor =
                System.Drawing.Color.Transparent;
            this.btnReports.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.FlatAppearance
                .BorderSize = 0;
            this.btnReports.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnReports.Font = navFont;
            this.btnReports.ForeColor = navText;
            this.btnReports.Location =
                new System.Drawing.Point(0, 446);
            this.btnReports.Size =
                new System.Drawing.Size(210, 40);
            this.btnReports.Text = "  Reports";
            this.btnReports.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnReports.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnReports.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnReports.Click +=
                new System.EventHandler(
                    this.btnReports_Click);

            // Users
            this.btnUsers.BackColor =
                System.Drawing.Color.Transparent;
            this.btnUsers.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.FlatAppearance
                .BorderSize = 0;
            this.btnUsers.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnUsers.Font = navFont;
            this.btnUsers.ForeColor = navText;
            this.btnUsers.Location =
                new System.Drawing.Point(0, 490);
            this.btnUsers.Size =
                new System.Drawing.Size(210, 40);
            this.btnUsers.Text = "  Users";
            this.btnUsers.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnUsers.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnUsers.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnUsers.Click +=
                new System.EventHandler(
                    this.btnUsers_Click);

            // Semesters
            this.btnSemesters.BackColor =
                System.Drawing.Color.Transparent;
            this.btnSemesters.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnSemesters.FlatAppearance
                .BorderSize = 0;
            this.btnSemesters.FlatAppearance
                .MouseOverBackColor = navHover;
            this.btnSemesters.Font = navFont;
            this.btnSemesters.ForeColor = navText;
            this.btnSemesters.Location =
                new System.Drawing.Point(0, 534);
            this.btnSemesters.Size =
                new System.Drawing.Size(210, 40);
            this.btnSemesters.Text = "  Semesters";
            this.btnSemesters.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnSemesters.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnSemesters.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnSemesters.Click +=
                new System.EventHandler(
                    this.btnSemesters_Click);

            // Add all nav buttons to panelNav
            // ── PictureBox declarations ───────────────────────
            this.picDashboard = new System.Windows.Forms.PictureBox();
            this.picFaculty = new System.Windows.Forms.PictureBox();
            this.picDepts = new System.Windows.Forms.PictureBox();
            this.picCourses = new System.Windows.Forms.PictureBox();
            this.picWorkload = new System.Windows.Forms.PictureBox();
            this.picTimetable = new System.Windows.Forms.PictureBox();
            this.picAttendance = new System.Windows.Forms.PictureBox();
            this.picLeave = new System.Windows.Forms.PictureBox();
            this.picLeaveApp = new System.Windows.Forms.PictureBox();
            this.picCalendar = new System.Windows.Forms.PictureBox();
            this.picReports = new System.Windows.Forms.PictureBox();
            this.picUsers = new System.Windows.Forms.PictureBox();
            this.picSemesters = new System.Windows.Forms.PictureBox();
            this.picLogout = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.picDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFaculty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDepts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWorkload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimetable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeaveApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSemesters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            this.panelNav.Controls.Add(
                this.btnDashboard);
            this.panelNav.Controls.Add(
                this.btnFaculty);
            this.panelNav.Controls.Add(
                this.btnDepts);
            this.panelNav.Controls.Add(
                this.btnCourses);
            this.panelNav.Controls.Add(
                this.btnWorkload);
            this.panelNav.Controls.Add(
                this.btnTimetable);
            this.panelNav.Controls.Add(
                this.btnAttendance);
            this.panelNav.Controls.Add(
                this.btnLeave);
            this.panelNav.Controls.Add(
                this.btnLeaveApp);
            this.panelNav.Controls.Add(
                this.btnCalendar);
            this.panelNav.Controls.Add(
                this.btnReports);
            this.panelNav.Controls.Add(
                this.btnUsers);
            this.panelNav.Controls.Add(
                this.btnSemesters);

            // Logout
            this.btnLogout.BackColor =
                System.Drawing.Color.Transparent;
            this.btnLogout.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance
                .BorderSize = 0;
            this.btnLogout.FlatAppearance
                .MouseOverBackColor =
                System.Drawing.Color.FromArgb(
                    40, 220, 80, 60);
            this.btnLogout.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor =
                System.Drawing.Color.FromArgb(
                    220, 80, 60);
            this.btnLogout.Location =
                new System.Drawing.Point(0, 622);
            this.btnLogout.Size =
                new System.Drawing.Size(210, 38);
            this.btnLogout.Text = "  Logout";
            this.btnLogout.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;
            this.btnLogout.Padding =
                new System.Windows.Forms.Padding(
                    12, 0, 0, 0);
            this.btnLogout.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Click +=
                new System.EventHandler(
                    this.btnLogout_Click);

            // ══════════════════════════════════════════
            // MAIN PANEL
            // ══════════════════════════════════════════
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor =
                System.Drawing.Color.Transparent;
            this.panelMain.Location =
                new System.Drawing.Point(210, 0);
            this.panelMain.Size =
                new System.Drawing.Size(990, 660);

            // TOP BAR
            this.panelTopBar.BackColor =
                System.Drawing.Color.White;
            this.panelTopBar.Location =
                new System.Drawing.Point(0, 0);
            this.panelTopBar.Size =
                new System.Drawing.Size(990, 70);

            this.lblPageTitle.AutoSize = false;
            this.lblPageTitle.BackColor =
                System.Drawing.Color.Transparent;
            this.lblPageTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 16F,
                    System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblPageTitle.Location =
                new System.Drawing.Point(18, 8);
            this.lblPageTitle.Size =
                new System.Drawing.Size(340, 30);
            this.lblPageTitle.Text = "Dashboard";

            this.lblPageSubtitle.AutoSize = false;
            this.lblPageSubtitle.BackColor =
                System.Drawing.Color.Transparent;
            this.lblPageSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F);
            this.lblPageSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            this.lblPageSubtitle.Location =
                new System.Drawing.Point(20, 42);
            this.lblPageSubtitle.Size =
                new System.Drawing.Size(380, 18);
            this.lblPageSubtitle.Text =
                "Loading semester...";

            this.lblWelcome.AutoSize = false;
            this.lblWelcome.BackColor =
                System.Drawing.Color.Transparent;
            this.lblWelcome.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblWelcome.Location =
                new System.Drawing.Point(490, 8);
            this.lblWelcome.Size =
                new System.Drawing.Size(400, 20);
            this.lblWelcome.Text = "Welcome back!";

            this.lblRole.AutoSize = false;
            this.lblRole.BackColor =
                System.Drawing.Color.Transparent;
            this.lblRole.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8.5F);
            this.lblRole.ForeColor =
                System.Drawing.Color.FromArgb(
                    100, 130, 170);
            this.lblRole.Location =
                new System.Drawing.Point(490, 30);
            this.lblRole.Size =
                new System.Drawing.Size(300, 16);
            this.lblRole.Text = "Role:";

            this.lblDate.AutoSize = false;
            this.lblDate.BackColor =
                System.Drawing.Color.Transparent;
            this.lblDate.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8F);
            this.lblDate.ForeColor =
                System.Drawing.Color.FromArgb(
                    120, 150, 190);
            this.lblDate.Location =
                new System.Drawing.Point(490, 48);
            this.lblDate.Size =
                new System.Drawing.Size(380, 16);
            this.lblDate.Text = "";

            this.lblAvatar.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblAvatar.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor =
                System.Drawing.Color.White;
            this.lblAvatar.Location =
                new System.Drawing.Point(944, 16);
            this.lblAvatar.Size =
                new System.Drawing.Size(38, 38);
            this.lblAvatar.Text = "AD";
            this.lblAvatar.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleCenter;

            this.panelTopBar.Controls.Add(
                this.lblPageTitle);
            this.panelTopBar.Controls.Add(
                this.lblPageSubtitle);
            this.panelTopBar.Controls.Add(
                this.lblWelcome);
            this.panelTopBar.Controls.Add(
                this.lblRole);
            this.panelTopBar.Controls.Add(
                this.lblDate);
            this.panelTopBar.Controls.Add(
                this.lblAvatar);

            // ── STAT CARD: Faculty ─────────────────────
            this.cardFaculty.BackColor =
                System.Drawing.Color.White;
            this.cardFaculty.Location =
                new System.Drawing.Point(20, 82);
            this.cardFaculty.Size =
                new System.Drawing.Size(220, 94);

            var stripeFac =
                new System.Windows.Forms.Panel();
            stripeFac.BackColor =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            stripeFac.Location =
                new System.Drawing.Point(0, 0);
            stripeFac.Size =
                new System.Drawing.Size(5, 94);

            this.lblStatFacultyTitle.AutoSize = false;
            this.lblStatFacultyTitle.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatFacultyTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8.5F);
            this.lblStatFacultyTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    110, 140, 180);
            this.lblStatFacultyTitle.Location =
                new System.Drawing.Point(14, 10);
            this.lblStatFacultyTitle.Size =
                new System.Drawing.Size(200, 18);
            this.lblStatFacultyTitle.Text =
                "Total Faculty";

            this.lblStatFaculty.AutoSize = false;
            this.lblStatFaculty.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatFaculty.Font =
                new System.Drawing.Font(
                    "Segoe UI", 28F,
                    System.Drawing.FontStyle.Bold);
            this.lblStatFaculty.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblStatFaculty.Location =
                new System.Drawing.Point(14, 28);
            this.lblStatFaculty.Size =
                new System.Drawing.Size(200, 44);
            this.lblStatFaculty.Text = "0";

            this.lblStatFacultySub.AutoSize = false;
            this.lblStatFacultySub.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatFacultySub.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8F);
            this.lblStatFacultySub.ForeColor =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            this.lblStatFacultySub.Location =
                new System.Drawing.Point(14, 72);
            this.lblStatFacultySub.Size =
                new System.Drawing.Size(200, 16);
            this.lblStatFacultySub.Text =
                "Active members";

            this.cardFaculty.Controls.Add(stripeFac);
            this.cardFaculty.Controls.Add(
                this.lblStatFacultyTitle);
            this.cardFaculty.Controls.Add(
                this.lblStatFaculty);
            this.cardFaculty.Controls.Add(
                this.lblStatFacultySub);

            // ── STAT CARD: Courses ─────────────────────
            this.cardCourses.BackColor =
                System.Drawing.Color.White;
            this.cardCourses.Location =
                new System.Drawing.Point(256, 82);
            this.cardCourses.Size =
                new System.Drawing.Size(220, 94);

            var stripeCrs =
                new System.Windows.Forms.Panel();
            stripeCrs.BackColor =
                System.Drawing.Color.FromArgb(
                    13, 140, 106);
            stripeCrs.Location =
                new System.Drawing.Point(0, 0);
            stripeCrs.Size =
                new System.Drawing.Size(5, 94);

            this.lblStatCoursesTitle.AutoSize = false;
            this.lblStatCoursesTitle.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatCoursesTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8.5F);
            this.lblStatCoursesTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    110, 140, 180);
            this.lblStatCoursesTitle.Location =
                new System.Drawing.Point(14, 10);
            this.lblStatCoursesTitle.Size =
                new System.Drawing.Size(200, 18);
            this.lblStatCoursesTitle.Text =
                "Total Courses";

            this.lblStatCourses.AutoSize = false;
            this.lblStatCourses.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatCourses.Font =
                new System.Drawing.Font(
                    "Segoe UI", 28F,
                    System.Drawing.FontStyle.Bold);
            this.lblStatCourses.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblStatCourses.Location =
                new System.Drawing.Point(14, 28);
            this.lblStatCourses.Size =
                new System.Drawing.Size(200, 44);
            this.lblStatCourses.Text = "0";

            this.lblStatCoursesSub.AutoSize = false;
            this.lblStatCoursesSub.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatCoursesSub.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8F);
            this.lblStatCoursesSub.ForeColor =
                System.Drawing.Color.FromArgb(
                    13, 140, 106);
            this.lblStatCoursesSub.Location =
                new System.Drawing.Point(14, 72);
            this.lblStatCoursesSub.Size =
                new System.Drawing.Size(200, 16);
            this.lblStatCoursesSub.Text =
                "This semester";

            this.cardCourses.Controls.Add(stripeCrs);
            this.cardCourses.Controls.Add(
                this.lblStatCoursesTitle);
            this.cardCourses.Controls.Add(
                this.lblStatCourses);
            this.cardCourses.Controls.Add(
                this.lblStatCoursesSub);

            // ── STAT CARD: Departments ─────────────────
            this.cardDepts.BackColor =
                System.Drawing.Color.White;
            this.cardDepts.Location =
                new System.Drawing.Point(492, 82);
            this.cardDepts.Size =
                new System.Drawing.Size(220, 94);

            var stripeDpt =
                new System.Windows.Forms.Panel();
            stripeDpt.BackColor =
                System.Drawing.Color.FromArgb(
                    224, 123, 0);
            stripeDpt.Location =
                new System.Drawing.Point(0, 0);
            stripeDpt.Size =
                new System.Drawing.Size(5, 94);

            this.lblStatDeptsTitle.AutoSize = false;
            this.lblStatDeptsTitle.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatDeptsTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8.5F);
            this.lblStatDeptsTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    110, 140, 180);
            this.lblStatDeptsTitle.Location =
                new System.Drawing.Point(14, 10);
            this.lblStatDeptsTitle.Size =
                new System.Drawing.Size(200, 18);
            this.lblStatDeptsTitle.Text =
                "Departments";

            this.lblStatDepts.AutoSize = false;
            this.lblStatDepts.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatDepts.Font =
                new System.Drawing.Font(
                    "Segoe UI", 28F,
                    System.Drawing.FontStyle.Bold);
            this.lblStatDepts.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblStatDepts.Location =
                new System.Drawing.Point(14, 28);
            this.lblStatDepts.Size =
                new System.Drawing.Size(200, 44);
            this.lblStatDepts.Text = "0";

            this.lblStatDeptsSub.AutoSize = false;
            this.lblStatDeptsSub.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatDeptsSub.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8F);
            this.lblStatDeptsSub.ForeColor =
                System.Drawing.Color.FromArgb(
                    224, 123, 0);
            this.lblStatDeptsSub.Location =
                new System.Drawing.Point(14, 72);
            this.lblStatDeptsSub.Size =
                new System.Drawing.Size(200, 16);
            this.lblStatDeptsSub.Text =
                "Active depts";

            this.cardDepts.Controls.Add(stripeDpt);
            this.cardDepts.Controls.Add(
                this.lblStatDeptsTitle);
            this.cardDepts.Controls.Add(
                this.lblStatDepts);
            this.cardDepts.Controls.Add(
                this.lblStatDeptsSub);

            // ── STAT CARD: Leaves ──────────────────────
            this.cardLeaves.BackColor =
                System.Drawing.Color.White;
            this.cardLeaves.Location =
                new System.Drawing.Point(728, 82);
            this.cardLeaves.Size =
                new System.Drawing.Size(220, 94);

            var stripeLv =
                new System.Windows.Forms.Panel();
            stripeLv.BackColor =
                System.Drawing.Color.FromArgb(
                    192, 57, 43);
            stripeLv.Location =
                new System.Drawing.Point(0, 0);
            stripeLv.Size =
                new System.Drawing.Size(5, 94);

            this.lblStatLeavesTitle.AutoSize = false;
            this.lblStatLeavesTitle.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatLeavesTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8.5F);
            this.lblStatLeavesTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    110, 140, 180);
            this.lblStatLeavesTitle.Location =
                new System.Drawing.Point(14, 10);
            this.lblStatLeavesTitle.Size =
                new System.Drawing.Size(200, 18);
            this.lblStatLeavesTitle.Text =
                "Pending Leaves";

            this.lblStatLeaves.AutoSize = false;
            this.lblStatLeaves.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatLeaves.Font =
                new System.Drawing.Font(
                    "Segoe UI", 28F,
                    System.Drawing.FontStyle.Bold);
            this.lblStatLeaves.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblStatLeaves.Location =
                new System.Drawing.Point(14, 28);
            this.lblStatLeaves.Size =
                new System.Drawing.Size(200, 44);
            this.lblStatLeaves.Text = "0";

            this.lblStatLeavesSub.AutoSize = false;
            this.lblStatLeavesSub.BackColor =
                System.Drawing.Color.Transparent;
            this.lblStatLeavesSub.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8F);
            this.lblStatLeavesSub.ForeColor =
                System.Drawing.Color.FromArgb(
                    192, 57, 43);
            this.lblStatLeavesSub.Location =
                new System.Drawing.Point(14, 72);
            this.lblStatLeavesSub.Size =
                new System.Drawing.Size(200, 16);
            this.lblStatLeavesSub.Text =
                "Need approval";

            this.cardLeaves.Controls.Add(stripeLv);
            this.cardLeaves.Controls.Add(
                this.lblStatLeavesTitle);
            this.cardLeaves.Controls.Add(
                this.lblStatLeaves);
            this.cardLeaves.Controls.Add(
                this.lblStatLeavesSub);

            // ── SCHEDULE CARD ──────────────────────────
            this.panelSchedCard.BackColor =
                System.Drawing.Color.White;
            this.panelSchedCard.Location =
                new System.Drawing.Point(20, 196);
            this.panelSchedCard.Size =
                new System.Drawing.Size(456, 270);

            this.lblSchedTitle.AutoSize = false;
            this.lblSchedTitle.BackColor =
                System.Drawing.Color.Transparent;
            this.lblSchedTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.lblSchedTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblSchedTitle.Location =
                new System.Drawing.Point(14, 12);
            this.lblSchedTitle.Size =
                new System.Drawing.Size(428, 22);
            this.lblSchedTitle.Text =
                "Today's Schedule";

            this.panelSchedule.AutoScroll = true;
            this.panelSchedule.BackColor =
                System.Drawing.Color.Transparent;
            this.panelSchedule.Location =
                new System.Drawing.Point(0, 42);
            this.panelSchedule.Size =
                new System.Drawing.Size(456, 226);

            this.panelSchedCard.Controls.Add(
                this.lblSchedTitle);
            this.panelSchedCard.Controls.Add(
                this.panelSchedule);

            // ── LEAVES CARD ────────────────────────────
            this.panelLeavesCard.BackColor =
                System.Drawing.Color.White;
            this.panelLeavesCard.Location =
                new System.Drawing.Point(492, 196);
            this.panelLeavesCard.Size =
                new System.Drawing.Size(478, 270);

            this.lblLeavesTitle.AutoSize = false;
            this.lblLeavesTitle.BackColor =
                System.Drawing.Color.Transparent;
            this.lblLeavesTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.lblLeavesTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblLeavesTitle.Location =
                new System.Drawing.Point(14, 12);
            this.lblLeavesTitle.Size =
                new System.Drawing.Size(450, 22);
            this.lblLeavesTitle.Text =
                "Pending Leave Requests";

            this.panelLeaves.AutoScroll = true;
            this.panelLeaves.BackColor =
                System.Drawing.Color.Transparent;
            this.panelLeaves.Location =
                new System.Drawing.Point(0, 42);
            this.panelLeaves.Size =
                new System.Drawing.Size(478, 226);

            this.panelLeavesCard.Controls.Add(
                this.lblLeavesTitle);
            this.panelLeavesCard.Controls.Add(
                this.panelLeaves);

            // ── EVENT BANNER ───────────────────────────
            this.panelBanner.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.panelBanner.Location =
                new System.Drawing.Point(20, 482);
            this.panelBanner.Size =
                new System.Drawing.Size(950, 52);

            this.lblEventBanner.AutoSize = false;
            this.lblEventBanner.BackColor =
                System.Drawing.Color.Transparent;
            this.lblEventBanner.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.lblEventBanner.ForeColor =
                System.Drawing.Color.White;
            this.lblEventBanner.Location =
                new System.Drawing.Point(16, 0);
            this.lblEventBanner.Size =
                new System.Drawing.Size(920, 52);
            this.lblEventBanner.Text = "";
            this.lblEventBanner.TextAlign =
                System.Drawing.ContentAlignment
                .MiddleLeft;

            this.panelBanner.Controls.Add(
                this.lblEventBanner);

            // ── Add everything to panelMain ────────────
            this.panelMain.Controls.Add(
                this.panelTopBar);
            this.panelMain.Controls.Add(
                this.cardFaculty);
            this.panelMain.Controls.Add(
                this.cardCourses);
            this.panelMain.Controls.Add(
                this.cardDepts);
            this.panelMain.Controls.Add(
                this.cardLeaves);
            this.panelMain.Controls.Add(
                this.panelSchedCard);
            this.panelMain.Controls.Add(
                this.panelLeavesCard);
            this.panelMain.Controls.Add(
                this.panelBanner);

            // ── FORM ───────────────────────────────────
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode =
                System.Windows.Forms
                .AutoScaleMode.Font;
            this.BackColor =
                System.Drawing.Color.FromArgb(
                    244, 248, 255);
            this.ClientSize =
                new System.Drawing.Size(1200, 660);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle =
                System.Windows.Forms
                .FormBorderStyle.None;
            this.StartPosition =
                System.Windows.Forms
                .FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load +=
                new System.EventHandler(
                    this.DashboardForm_Load);

            ((System.ComponentModel.ISupportInitialize)
                (this.picLogo)).EndInit();
            this.panelBanner.ResumeLayout(false);
            this.panelLeavesCard.ResumeLayout(false);
            this.panelSchedCard.ResumeLayout(false);
            this.cardLeaves.ResumeLayout(false);
            this.cardDepts.ResumeLayout(false);
            this.cardCourses.ResumeLayout(false);
            this.cardFaculty.ResumeLayout(false);
            this.panelTopBar.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelNav.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // Declarations
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppSub;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnFaculty;
        private System.Windows.Forms.Button btnDepts;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnWorkload;
        private System.Windows.Forms.Button btnTimetable;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Button btnLeaveApp;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnSemesters;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Panel cardFaculty;
        private System.Windows.Forms.Label lblStatFacultyTitle;
        private System.Windows.Forms.Label lblStatFaculty;
        private System.Windows.Forms.Label lblStatFacultySub;
        private System.Windows.Forms.Panel cardCourses;
        private System.Windows.Forms.Label lblStatCoursesTitle;
        private System.Windows.Forms.Label lblStatCourses;
        private System.Windows.Forms.Label lblStatCoursesSub;
        private System.Windows.Forms.Panel cardDepts;
        private System.Windows.Forms.Label lblStatDeptsTitle;
        private System.Windows.Forms.Label lblStatDepts;
        private System.Windows.Forms.Label lblStatDeptsSub;
        private System.Windows.Forms.Panel cardLeaves;
        private System.Windows.Forms.Label lblStatLeavesTitle;
        private System.Windows.Forms.Label lblStatLeaves;
        private System.Windows.Forms.Label lblStatLeavesSub;
        private System.Windows.Forms.Panel panelSchedCard;
        private System.Windows.Forms.Label lblSchedTitle;
        private System.Windows.Forms.Panel panelSchedule;
        private System.Windows.Forms.Panel panelLeavesCard;
        private System.Windows.Forms.Label lblLeavesTitle;
        private System.Windows.Forms.Panel panelLeaves;
        private System.Windows.Forms.Panel panelBanner;
        private System.Windows.Forms.Label lblEventBanner;
        private System.Windows.Forms.PictureBox picDashboard;
        private System.Windows.Forms.PictureBox picFaculty;
        private System.Windows.Forms.PictureBox picDepts;
        private System.Windows.Forms.PictureBox picCourses;
        private System.Windows.Forms.PictureBox picWorkload;
        private System.Windows.Forms.PictureBox picTimetable;
        private System.Windows.Forms.PictureBox picAttendance;
        private System.Windows.Forms.PictureBox picLeave;
        private System.Windows.Forms.PictureBox picLeaveApp;
        private System.Windows.Forms.PictureBox picCalendar;
        private System.Windows.Forms.PictureBox picReports;
        private System.Windows.Forms.PictureBox picUsers;
        private System.Windows.Forms.PictureBox picSemesters;
        private System.Windows.Forms.PictureBox picLogout;
    }
}