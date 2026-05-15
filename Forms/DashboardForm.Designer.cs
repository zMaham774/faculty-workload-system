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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppSub = new System.Windows.Forms.Label();
            this.panelNav = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnFaculty = new System.Windows.Forms.Button();
            this.btnDepts = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnWorkload = new System.Windows.Forms.Button();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.btnLeaveApp = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnSemesters = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.cardFaculty = new System.Windows.Forms.Panel();
            this.stripeFac = new System.Windows.Forms.Panel();
            this.lblStatFacultyTitle = new System.Windows.Forms.Label();
            this.lblStatFaculty = new System.Windows.Forms.Label();
            this.lblStatFacultySub = new System.Windows.Forms.Label();
            this.cardCourses = new System.Windows.Forms.Panel();
            this.stripeCrs = new System.Windows.Forms.Panel();
            this.lblStatCoursesTitle = new System.Windows.Forms.Label();
            this.lblStatCourses = new System.Windows.Forms.Label();
            this.lblStatCoursesSub = new System.Windows.Forms.Label();
            this.cardDepts = new System.Windows.Forms.Panel();
            this.stripeDpt = new System.Windows.Forms.Panel();
            this.lblStatDeptsTitle = new System.Windows.Forms.Label();
            this.lblStatDepts = new System.Windows.Forms.Label();
            this.lblStatDeptsSub = new System.Windows.Forms.Label();
            this.cardLeaves = new System.Windows.Forms.Panel();
            this.stripeLv = new System.Windows.Forms.Panel();
            this.lblStatLeavesTitle = new System.Windows.Forms.Label();
            this.lblStatLeaves = new System.Windows.Forms.Label();
            this.lblStatLeavesSub = new System.Windows.Forms.Label();
            this.panelSchedCard = new System.Windows.Forms.Panel();
            this.lblSchedTitle = new System.Windows.Forms.Label();
            this.panelSchedule = new System.Windows.Forms.Panel();
            this.panelLeavesCard = new System.Windows.Forms.Panel();
            this.lblLeavesTitle = new System.Windows.Forms.Label();
            this.panelLeaves = new System.Windows.Forms.Panel();
            this.panelBanner = new System.Windows.Forms.Panel();
            this.lblEventBanner = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
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
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.panelSidebar.Controls.Add(this.picLogo);
            this.panelSidebar.Controls.Add(this.lblAppName);
            this.panelSidebar.Controls.Add(this.lblAppSub);
            this.panelSidebar.Controls.Add(this.panelNav);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(210, 660);
            this.panelSidebar.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(10, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(42, 42);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(58, 12);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(72, 20);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "FACULTY";
            // 
            // lblAppSub
            // 
            this.lblAppSub.AutoSize = true;
            this.lblAppSub.BackColor = System.Drawing.Color.Transparent;
            this.lblAppSub.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblAppSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(200)))), ((int)(((byte)(240)))));
            this.lblAppSub.Location = new System.Drawing.Point(58, 34);
            this.lblAppSub.Name = "lblAppSub";
            this.lblAppSub.Size = new System.Drawing.Size(109, 12);
            this.lblAppSub.TabIndex = 2;
            this.lblAppSub.Text = "MANAGEMENT SYSTEM";
            // 
            // panelNav
            // 
            this.panelNav.AutoScroll = true;
            this.panelNav.BackColor = System.Drawing.Color.Transparent;
            this.panelNav.Controls.Add(this.btnDashboard);
            this.panelNav.Controls.Add(this.btnFaculty);
            this.panelNav.Controls.Add(this.btnDepts);
            this.panelNav.Controls.Add(this.btnCourses);
            this.panelNav.Controls.Add(this.btnWorkload);
            this.panelNav.Controls.Add(this.btnTimetable);
            this.panelNav.Controls.Add(this.btnAttendance);
            this.panelNav.Controls.Add(this.btnLeave);
            this.panelNav.Controls.Add(this.btnLeaveApp);
            this.panelNav.Controls.Add(this.btnCalendar);
            this.panelNav.Controls.Add(this.btnReports);
            this.panelNav.Controls.Add(this.btnUsers);
            this.panelNav.Controls.Add(this.btnSemesters);
            this.panelNav.Location = new System.Drawing.Point(0, 62);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(210, 558);
            this.panelNav.TabIndex = 3;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 6);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(210, 40);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "  Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnFaculty
            // 
            this.btnFaculty.BackColor = System.Drawing.Color.Transparent;
            this.btnFaculty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFaculty.FlatAppearance.BorderSize = 0;
            this.btnFaculty.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnFaculty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaculty.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnFaculty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnFaculty.Location = new System.Drawing.Point(0, 50);
            this.btnFaculty.Name = "btnFaculty";
            this.btnFaculty.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnFaculty.Size = new System.Drawing.Size(210, 40);
            this.btnFaculty.TabIndex = 1;
            this.btnFaculty.Text = "  Faculty";
            this.btnFaculty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFaculty.UseVisualStyleBackColor = false;
            this.btnFaculty.Click += new System.EventHandler(this.btnFaculty_Click);
            // 
            // btnDepts
            // 
            this.btnDepts.BackColor = System.Drawing.Color.Transparent;
            this.btnDepts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepts.FlatAppearance.BorderSize = 0;
            this.btnDepts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnDepts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepts.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDepts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnDepts.Location = new System.Drawing.Point(0, 94);
            this.btnDepts.Name = "btnDepts";
            this.btnDepts.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDepts.Size = new System.Drawing.Size(210, 40);
            this.btnDepts.TabIndex = 2;
            this.btnDepts.Text = "  Departments";
            this.btnDepts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepts.UseVisualStyleBackColor = false;
            this.btnDepts.Click += new System.EventHandler(this.btnDepts_Click);
            // 
            // btnCourses
            // 
            this.btnCourses.BackColor = System.Drawing.Color.Transparent;
            this.btnCourses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCourses.FlatAppearance.BorderSize = 0;
            this.btnCourses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourses.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnCourses.Location = new System.Drawing.Point(0, 138);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCourses.Size = new System.Drawing.Size(210, 40);
            this.btnCourses.TabIndex = 3;
            this.btnCourses.Text = "  Courses";
            this.btnCourses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourses.UseVisualStyleBackColor = false;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            // 
            // btnWorkload
            // 
            this.btnWorkload.BackColor = System.Drawing.Color.Transparent;
            this.btnWorkload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWorkload.FlatAppearance.BorderSize = 0;
            this.btnWorkload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnWorkload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkload.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnWorkload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnWorkload.Location = new System.Drawing.Point(0, 182);
            this.btnWorkload.Name = "btnWorkload";
            this.btnWorkload.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnWorkload.Size = new System.Drawing.Size(210, 40);
            this.btnWorkload.TabIndex = 4;
            this.btnWorkload.Text = "  Workload";
            this.btnWorkload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorkload.UseVisualStyleBackColor = false;
            this.btnWorkload.Click += new System.EventHandler(this.btnWorkload_Click);
            // 
            // btnTimetable
            // 
            this.btnTimetable.BackColor = System.Drawing.Color.Transparent;
            this.btnTimetable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimetable.FlatAppearance.BorderSize = 0;
            this.btnTimetable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnTimetable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimetable.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTimetable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnTimetable.Location = new System.Drawing.Point(0, 226);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnTimetable.Size = new System.Drawing.Size(210, 40);
            this.btnTimetable.TabIndex = 5;
            this.btnTimetable.Text = "  Timetable";
            this.btnTimetable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimetable.UseVisualStyleBackColor = false;
            this.btnTimetable.Click += new System.EventHandler(this.btnTimetable_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.Transparent;
            this.btnAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttendance.FlatAppearance.BorderSize = 0;
            this.btnAttendance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnAttendance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnAttendance.Location = new System.Drawing.Point(0, 270);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnAttendance.Size = new System.Drawing.Size(210, 40);
            this.btnAttendance.TabIndex = 6;
            this.btnAttendance.Text = "  Attendance";
            this.btnAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.BackColor = System.Drawing.Color.Transparent;
            this.btnLeave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeave.FlatAppearance.BorderSize = 0;
            this.btnLeave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeave.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLeave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnLeave.Location = new System.Drawing.Point(0, 314);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLeave.Size = new System.Drawing.Size(210, 40);
            this.btnLeave.TabIndex = 7;
            this.btnLeave.Text = "  Leave";
            this.btnLeave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeave.UseVisualStyleBackColor = false;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // btnLeaveApp
            // 
            this.btnLeaveApp.BackColor = System.Drawing.Color.Transparent;
            this.btnLeaveApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaveApp.FlatAppearance.BorderSize = 0;
            this.btnLeaveApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnLeaveApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveApp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLeaveApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnLeaveApp.Location = new System.Drawing.Point(0, 358);
            this.btnLeaveApp.Name = "btnLeaveApp";
            this.btnLeaveApp.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLeaveApp.Size = new System.Drawing.Size(210, 40);
            this.btnLeaveApp.TabIndex = 8;
            this.btnLeaveApp.Text = "  Leave Approval";
            this.btnLeaveApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeaveApp.UseVisualStyleBackColor = false;
            this.btnLeaveApp.Click += new System.EventHandler(this.btnLeaveApp_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.BackColor = System.Drawing.Color.Transparent;
            this.btnCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalendar.FlatAppearance.BorderSize = 0;
            this.btnCalendar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCalendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnCalendar.Location = new System.Drawing.Point(0, 402);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCalendar.Size = new System.Drawing.Size(210, 40);
            this.btnCalendar.TabIndex = 9;
            this.btnCalendar.Text = "  Calendar";
            this.btnCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalendar.UseVisualStyleBackColor = false;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Transparent;
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnReports.Location = new System.Drawing.Point(0, 446);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(210, 40);
            this.btnReports.TabIndex = 10;
            this.btnReports.Text = "  Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnUsers.Location = new System.Drawing.Point(0, 490);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(210, 40);
            this.btnUsers.TabIndex = 11;
            this.btnUsers.Text = "  Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnSemesters
            // 
            this.btnSemesters.BackColor = System.Drawing.Color.Transparent;
            this.btnSemesters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSemesters.FlatAppearance.BorderSize = 0;
            this.btnSemesters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnSemesters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemesters.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSemesters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnSemesters.Location = new System.Drawing.Point(0, 534);
            this.btnSemesters.Name = "btnSemesters";
            this.btnSemesters.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSemesters.Size = new System.Drawing.Size(210, 40);
            this.btnSemesters.TabIndex = 12;
            this.btnSemesters.Text = "  Semesters";
            this.btnSemesters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSemesters.UseVisualStyleBackColor = false;
            this.btnSemesters.Click += new System.EventHandler(this.btnSemesters_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 622);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(210, 38);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "  Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.panelTopBar);
            this.panelMain.Controls.Add(this.cardFaculty);
            this.panelMain.Controls.Add(this.cardCourses);
            this.panelMain.Controls.Add(this.cardDepts);
            this.panelMain.Controls.Add(this.cardLeaves);
            this.panelMain.Controls.Add(this.panelSchedCard);
            this.panelMain.Controls.Add(this.panelLeavesCard);
            this.panelMain.Controls.Add(this.panelBanner);
            this.panelMain.Location = new System.Drawing.Point(210, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(978, 705);
            this.panelMain.TabIndex = 1;
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.White;
            this.panelTopBar.Controls.Add(this.lblPageTitle);
            this.panelTopBar.Controls.Add(this.lblPageSubtitle);
            this.panelTopBar.Controls.Add(this.lblWelcome);
            this.panelTopBar.Controls.Add(this.lblRole);
            this.panelTopBar.Controls.Add(this.lblDate);
            this.panelTopBar.Controls.Add(this.lblAvatar);
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(990, 70);
            this.panelTopBar.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblPageTitle.Location = new System.Drawing.Point(18, 8);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(340, 30);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Dashboard";
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.lblPageSubtitle.Location = new System.Drawing.Point(20, 42);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(380, 18);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "Loading semester...";
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblWelcome.Location = new System.Drawing.Point(490, 8);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(400, 20);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Welcome back!";
            // 
            // lblRole
            // 
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
            this.lblRole.Location = new System.Drawing.Point(490, 30);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(300, 16);
            this.lblRole.TabIndex = 3;
            this.lblRole.Text = "Role:";
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.lblDate.Location = new System.Drawing.Point(490, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(380, 16);
            this.lblDate.TabIndex = 4;
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(944, 16);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(38, 38);
            this.lblAvatar.TabIndex = 5;
            this.lblAvatar.Text = "AD";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardFaculty
            // 
            this.cardFaculty.BackColor = System.Drawing.Color.White;
            this.cardFaculty.Controls.Add(this.stripeFac);
            this.cardFaculty.Controls.Add(this.lblStatFacultyTitle);
            this.cardFaculty.Controls.Add(this.lblStatFaculty);
            this.cardFaculty.Controls.Add(this.lblStatFacultySub);
            this.cardFaculty.Location = new System.Drawing.Point(20, 82);
            this.cardFaculty.Name = "cardFaculty";
            this.cardFaculty.Size = new System.Drawing.Size(220, 94);
            this.cardFaculty.TabIndex = 1;
            // 
            // stripeFac
            // 
            this.stripeFac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.stripeFac.Location = new System.Drawing.Point(0, 0);
            this.stripeFac.Name = "stripeFac";
            this.stripeFac.Size = new System.Drawing.Size(5, 94);
            this.stripeFac.TabIndex = 0;
            // 
            // lblStatFacultyTitle
            // 
            this.lblStatFacultyTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblStatFacultyTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatFacultyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.lblStatFacultyTitle.Location = new System.Drawing.Point(14, 10);
            this.lblStatFacultyTitle.Name = "lblStatFacultyTitle";
            this.lblStatFacultyTitle.Size = new System.Drawing.Size(200, 18);
            this.lblStatFacultyTitle.TabIndex = 1;
            this.lblStatFacultyTitle.Text = "Total Faculty";
            // 
            // lblStatFaculty
            // 
            this.lblStatFaculty.BackColor = System.Drawing.Color.Transparent;
            this.lblStatFaculty.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblStatFaculty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblStatFaculty.Location = new System.Drawing.Point(14, 28);
            this.lblStatFaculty.Name = "lblStatFaculty";
            this.lblStatFaculty.Size = new System.Drawing.Size(200, 44);
            this.lblStatFaculty.TabIndex = 2;
            this.lblStatFaculty.Text = "0";
            // 
            // lblStatFacultySub
            // 
            this.lblStatFacultySub.BackColor = System.Drawing.Color.Transparent;
            this.lblStatFacultySub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStatFacultySub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.lblStatFacultySub.Location = new System.Drawing.Point(14, 72);
            this.lblStatFacultySub.Name = "lblStatFacultySub";
            this.lblStatFacultySub.Size = new System.Drawing.Size(200, 16);
            this.lblStatFacultySub.TabIndex = 3;
            this.lblStatFacultySub.Text = "Active members";
            // 
            // cardCourses
            // 
            this.cardCourses.BackColor = System.Drawing.Color.White;
            this.cardCourses.Controls.Add(this.stripeCrs);
            this.cardCourses.Controls.Add(this.lblStatCoursesTitle);
            this.cardCourses.Controls.Add(this.lblStatCourses);
            this.cardCourses.Controls.Add(this.lblStatCoursesSub);
            this.cardCourses.Location = new System.Drawing.Point(256, 82);
            this.cardCourses.Name = "cardCourses";
            this.cardCourses.Size = new System.Drawing.Size(220, 94);
            this.cardCourses.TabIndex = 2;
            // 
            // stripeCrs
            // 
            this.stripeCrs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(140)))), ((int)(((byte)(106)))));
            this.stripeCrs.Location = new System.Drawing.Point(0, 0);
            this.stripeCrs.Name = "stripeCrs";
            this.stripeCrs.Size = new System.Drawing.Size(5, 94);
            this.stripeCrs.TabIndex = 0;
            // 
            // lblStatCoursesTitle
            // 
            this.lblStatCoursesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblStatCoursesTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatCoursesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.lblStatCoursesTitle.Location = new System.Drawing.Point(14, 10);
            this.lblStatCoursesTitle.Name = "lblStatCoursesTitle";
            this.lblStatCoursesTitle.Size = new System.Drawing.Size(200, 18);
            this.lblStatCoursesTitle.TabIndex = 1;
            this.lblStatCoursesTitle.Text = "Total Courses";
            // 
            // lblStatCourses
            // 
            this.lblStatCourses.BackColor = System.Drawing.Color.Transparent;
            this.lblStatCourses.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblStatCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblStatCourses.Location = new System.Drawing.Point(14, 28);
            this.lblStatCourses.Name = "lblStatCourses";
            this.lblStatCourses.Size = new System.Drawing.Size(200, 44);
            this.lblStatCourses.TabIndex = 2;
            this.lblStatCourses.Text = "0";
            // 
            // lblStatCoursesSub
            // 
            this.lblStatCoursesSub.BackColor = System.Drawing.Color.Transparent;
            this.lblStatCoursesSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStatCoursesSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(140)))), ((int)(((byte)(106)))));
            this.lblStatCoursesSub.Location = new System.Drawing.Point(14, 72);
            this.lblStatCoursesSub.Name = "lblStatCoursesSub";
            this.lblStatCoursesSub.Size = new System.Drawing.Size(200, 16);
            this.lblStatCoursesSub.TabIndex = 3;
            this.lblStatCoursesSub.Text = "This semester";
            // 
            // cardDepts
            // 
            this.cardDepts.BackColor = System.Drawing.Color.White;
            this.cardDepts.Controls.Add(this.stripeDpt);
            this.cardDepts.Controls.Add(this.lblStatDeptsTitle);
            this.cardDepts.Controls.Add(this.lblStatDepts);
            this.cardDepts.Controls.Add(this.lblStatDeptsSub);
            this.cardDepts.Location = new System.Drawing.Point(492, 82);
            this.cardDepts.Name = "cardDepts";
            this.cardDepts.Size = new System.Drawing.Size(220, 94);
            this.cardDepts.TabIndex = 3;
            // 
            // stripeDpt
            // 
            this.stripeDpt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(123)))), ((int)(((byte)(0)))));
            this.stripeDpt.Location = new System.Drawing.Point(0, 0);
            this.stripeDpt.Name = "stripeDpt";
            this.stripeDpt.Size = new System.Drawing.Size(5, 94);
            this.stripeDpt.TabIndex = 0;
            // 
            // lblStatDeptsTitle
            // 
            this.lblStatDeptsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblStatDeptsTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatDeptsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.lblStatDeptsTitle.Location = new System.Drawing.Point(14, 10);
            this.lblStatDeptsTitle.Name = "lblStatDeptsTitle";
            this.lblStatDeptsTitle.Size = new System.Drawing.Size(200, 18);
            this.lblStatDeptsTitle.TabIndex = 1;
            this.lblStatDeptsTitle.Text = "Departments";
            // 
            // lblStatDepts
            // 
            this.lblStatDepts.BackColor = System.Drawing.Color.Transparent;
            this.lblStatDepts.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblStatDepts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblStatDepts.Location = new System.Drawing.Point(14, 28);
            this.lblStatDepts.Name = "lblStatDepts";
            this.lblStatDepts.Size = new System.Drawing.Size(200, 44);
            this.lblStatDepts.TabIndex = 2;
            this.lblStatDepts.Text = "0";
            // 
            // lblStatDeptsSub
            // 
            this.lblStatDeptsSub.BackColor = System.Drawing.Color.Transparent;
            this.lblStatDeptsSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStatDeptsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(123)))), ((int)(((byte)(0)))));
            this.lblStatDeptsSub.Location = new System.Drawing.Point(14, 72);
            this.lblStatDeptsSub.Name = "lblStatDeptsSub";
            this.lblStatDeptsSub.Size = new System.Drawing.Size(200, 16);
            this.lblStatDeptsSub.TabIndex = 3;
            this.lblStatDeptsSub.Text = "Active depts";
            // 
            // cardLeaves
            // 
            this.cardLeaves.BackColor = System.Drawing.Color.White;
            this.cardLeaves.Controls.Add(this.stripeLv);
            this.cardLeaves.Controls.Add(this.lblStatLeavesTitle);
            this.cardLeaves.Controls.Add(this.lblStatLeaves);
            this.cardLeaves.Controls.Add(this.lblStatLeavesSub);
            this.cardLeaves.Location = new System.Drawing.Point(728, 82);
            this.cardLeaves.Name = "cardLeaves";
            this.cardLeaves.Size = new System.Drawing.Size(220, 94);
            this.cardLeaves.TabIndex = 4;
            // 
            // stripeLv
            // 
            this.stripeLv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.stripeLv.Location = new System.Drawing.Point(0, 0);
            this.stripeLv.Name = "stripeLv";
            this.stripeLv.Size = new System.Drawing.Size(5, 94);
            this.stripeLv.TabIndex = 0;
            // 
            // lblStatLeavesTitle
            // 
            this.lblStatLeavesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblStatLeavesTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatLeavesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.lblStatLeavesTitle.Location = new System.Drawing.Point(14, 10);
            this.lblStatLeavesTitle.Name = "lblStatLeavesTitle";
            this.lblStatLeavesTitle.Size = new System.Drawing.Size(200, 18);
            this.lblStatLeavesTitle.TabIndex = 1;
            this.lblStatLeavesTitle.Text = "Pending Leaves";
            // 
            // lblStatLeaves
            // 
            this.lblStatLeaves.BackColor = System.Drawing.Color.Transparent;
            this.lblStatLeaves.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblStatLeaves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblStatLeaves.Location = new System.Drawing.Point(14, 28);
            this.lblStatLeaves.Name = "lblStatLeaves";
            this.lblStatLeaves.Size = new System.Drawing.Size(200, 44);
            this.lblStatLeaves.TabIndex = 2;
            this.lblStatLeaves.Text = "0";
            // 
            // lblStatLeavesSub
            // 
            this.lblStatLeavesSub.BackColor = System.Drawing.Color.Transparent;
            this.lblStatLeavesSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStatLeavesSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblStatLeavesSub.Location = new System.Drawing.Point(14, 72);
            this.lblStatLeavesSub.Name = "lblStatLeavesSub";
            this.lblStatLeavesSub.Size = new System.Drawing.Size(200, 16);
            this.lblStatLeavesSub.TabIndex = 3;
            this.lblStatLeavesSub.Text = "Need approval";
            // 
            // panelSchedCard
            // 
            this.panelSchedCard.BackColor = System.Drawing.Color.White;
            this.panelSchedCard.Controls.Add(this.lblSchedTitle);
            this.panelSchedCard.Controls.Add(this.panelSchedule);
            this.panelSchedCard.Location = new System.Drawing.Point(20, 196);
            this.panelSchedCard.Name = "panelSchedCard";
            this.panelSchedCard.Size = new System.Drawing.Size(456, 270);
            this.panelSchedCard.TabIndex = 5;
            // 
            // lblSchedTitle
            // 
            this.lblSchedTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSchedTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSchedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblSchedTitle.Location = new System.Drawing.Point(14, 12);
            this.lblSchedTitle.Name = "lblSchedTitle";
            this.lblSchedTitle.Size = new System.Drawing.Size(428, 22);
            this.lblSchedTitle.TabIndex = 0;
            this.lblSchedTitle.Text = "Today\'s Schedule";
            // 
            // panelSchedule
            // 
            this.panelSchedule.AutoScroll = true;
            this.panelSchedule.BackColor = System.Drawing.Color.Transparent;
            this.panelSchedule.Location = new System.Drawing.Point(0, 42);
            this.panelSchedule.Name = "panelSchedule";
            this.panelSchedule.Size = new System.Drawing.Size(456, 226);
            this.panelSchedule.TabIndex = 1;
            // 
            // panelLeavesCard
            // 
            this.panelLeavesCard.BackColor = System.Drawing.Color.White;
            this.panelLeavesCard.Controls.Add(this.lblLeavesTitle);
            this.panelLeavesCard.Controls.Add(this.panelLeaves);
            this.panelLeavesCard.Location = new System.Drawing.Point(492, 196);
            this.panelLeavesCard.Name = "panelLeavesCard";
            this.panelLeavesCard.Size = new System.Drawing.Size(478, 270);
            this.panelLeavesCard.TabIndex = 6;
            // 
            // lblLeavesTitle
            // 
            this.lblLeavesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLeavesTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLeavesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblLeavesTitle.Location = new System.Drawing.Point(14, 12);
            this.lblLeavesTitle.Name = "lblLeavesTitle";
            this.lblLeavesTitle.Size = new System.Drawing.Size(450, 22);
            this.lblLeavesTitle.TabIndex = 0;
            this.lblLeavesTitle.Text = "Pending Leave Requests";
            // 
            // panelLeaves
            // 
            this.panelLeaves.AutoScroll = true;
            this.panelLeaves.BackColor = System.Drawing.Color.Transparent;
            this.panelLeaves.Location = new System.Drawing.Point(0, 42);
            this.panelLeaves.Name = "panelLeaves";
            this.panelLeaves.Size = new System.Drawing.Size(478, 226);
            this.panelLeaves.TabIndex = 1;
            // 
            // panelBanner
            // 
            this.panelBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.panelBanner.Controls.Add(this.lblEventBanner);
            this.panelBanner.Location = new System.Drawing.Point(20, 482);
            this.panelBanner.Name = "panelBanner";
            this.panelBanner.Size = new System.Drawing.Size(950, 52);
            this.panelBanner.TabIndex = 7;
            // 
            // lblEventBanner
            // 
            this.lblEventBanner.BackColor = System.Drawing.Color.Transparent;
            this.lblEventBanner.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEventBanner.ForeColor = System.Drawing.Color.White;
            this.lblEventBanner.Location = new System.Drawing.Point(16, 0);
            this.lblEventBanner.Name = "lblEventBanner";
            this.lblEventBanner.Size = new System.Drawing.Size(920, 52);
            this.lblEventBanner.TabIndex = 0;
            this.lblEventBanner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1212, 660);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelTopBar.ResumeLayout(false);
            this.cardFaculty.ResumeLayout(false);
            this.cardCourses.ResumeLayout(false);
            this.cardDepts.ResumeLayout(false);
            this.cardLeaves.ResumeLayout(false);
            this.panelSchedCard.ResumeLayout(false);
            this.panelLeavesCard.ResumeLayout(false);
            this.panelBanner.ResumeLayout(false);
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
        private System.Windows.Forms.Panel stripeFac;
        private System.Windows.Forms.Panel stripeCrs;
        private System.Windows.Forms.Panel stripeDpt;
        private System.Windows.Forms.Panel stripeLv;
    }
}