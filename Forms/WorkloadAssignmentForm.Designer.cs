namespace FacultyWorkloadSystem.Forms
{
    partial class WorkloadAssignmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMaximize = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientPanel1 = new FacultyWorkloadSystem.Helpers.GradientPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.btnManageStandards = new System.Windows.Forms.Button();
            this.btnReassign = new System.Windows.Forms.Button();
            this.pnlReassign = new System.Windows.Forms.Panel();
            this.txtReassignReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.cboReassignTo = new System.Windows.Forms.ComboBox();
            this.lblReassignTo = new System.Windows.Forms.Label();
            this.lblReassignTitle = new System.Windows.Forms.Label();
            this.nudTotalHours = new System.Windows.Forms.NumericUpDown();
            this.lblHours = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.dtpAssignedDate = new System.Windows.Forms.DateTimePicker();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.cboFaculty = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboFilterDept = new System.Windows.Forms.ComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.cboFilterSemester = new System.Windows.Forms.ComboBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblFilterSem = new System.Windows.Forms.Label();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlReassign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalHours)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1340, 33);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMaximize,
            this.minimizeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem2,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuMaximize
            // 
            this.menuMaximize.Name = "menuMaximize";
            this.menuMaximize.Size = new System.Drawing.Size(270, 34);
            this.menuMaximize.Text = "Maximize";
            this.menuMaximize.Click += new System.EventHandler(this.menuMaximize_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.menuMinimize_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(267, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(267, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.lblTitle);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.gradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.gradientPanel1.gradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.gradientPanel1.Location = new System.Drawing.Point(0, 33);
            this.gradientPanel1.MaximumSize = new System.Drawing.Size(0, 60);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1340, 60);
            this.gradientPanel1.TabIndex = 7;
            this.gradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseDown);
            this.gradientPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseMove);
            this.gradientPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(400, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(580, 38);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "WORKLOAD ASSIGNMENT MANAGEMENT";
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.Controls.Add(this.btnManageStandards);
            this.pnlForm.Controls.Add(this.btnReassign);
            this.pnlForm.Controls.Add(this.pnlReassign);
            this.pnlForm.Controls.Add(this.nudTotalHours);
            this.pnlForm.Controls.Add(this.lblHours);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.cboStatus);
            this.pnlForm.Controls.Add(this.dtpAssignedDate);
            this.pnlForm.Controls.Add(this.cboSemester);
            this.pnlForm.Controls.Add(this.cboCourse);
            this.pnlForm.Controls.Add(this.cboFaculty);
            this.pnlForm.Controls.Add(this.lblStatus);
            this.pnlForm.Controls.Add(this.lblDate);
            this.pnlForm.Controls.Add(this.lblCourse);
            this.pnlForm.Controls.Add(this.lblFaculty);
            this.pnlForm.Controls.Add(this.lblSemester);
            this.pnlForm.Controls.Add(this.lblFormTitle);
            this.pnlForm.Location = new System.Drawing.Point(0, 95);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1340, 331);
            this.pnlForm.TabIndex = 8;
            // 
            // btnManageStandards
            // 
            this.btnManageStandards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageStandards.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnManageStandards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStandards.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageStandards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnManageStandards.Location = new System.Drawing.Point(20, 285);
            this.btnManageStandards.Name = "btnManageStandards";
            this.btnManageStandards.Size = new System.Drawing.Size(185, 40);
            this.btnManageStandards.TabIndex = 46;
            this.btnManageStandards.Text = "Manage Standards";
            this.btnManageStandards.UseVisualStyleBackColor = true;
            this.btnManageStandards.Click += new System.EventHandler(this.btnManageStandards_Click);
            // 
            // btnReassign
            // 
            this.btnReassign.BackColor = System.Drawing.Color.DarkOrange;
            this.btnReassign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReassign.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReassign.FlatAppearance.BorderSize = 0;
            this.btnReassign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReassign.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReassign.ForeColor = System.Drawing.Color.White;
            this.btnReassign.Location = new System.Drawing.Point(623, 284);
            this.btnReassign.Name = "btnReassign";
            this.btnReassign.Size = new System.Drawing.Size(150, 40);
            this.btnReassign.TabIndex = 45;
            this.btnReassign.Text = "Reassign";
            this.btnReassign.UseVisualStyleBackColor = false;
            this.btnReassign.Visible = false;
            this.btnReassign.Click += new System.EventHandler(this.btnReassign_Click);
            // 
            // pnlReassign
            // 
            this.pnlReassign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.pnlReassign.Controls.Add(this.txtReassignReason);
            this.pnlReassign.Controls.Add(this.lblReason);
            this.pnlReassign.Controls.Add(this.cboReassignTo);
            this.pnlReassign.Controls.Add(this.lblReassignTo);
            this.pnlReassign.Controls.Add(this.lblReassignTitle);
            this.pnlReassign.Location = new System.Drawing.Point(0, 195);
            this.pnlReassign.Name = "pnlReassign";
            this.pnlReassign.Size = new System.Drawing.Size(1340, 80);
            this.pnlReassign.TabIndex = 44;
            this.pnlReassign.Visible = false;
            // 
            // txtReassignReason
            // 
            this.txtReassignReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReassignReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReassignReason.Location = new System.Drawing.Point(563, 34);
            this.txtReassignReason.Name = "txtReassignReason";
            this.txtReassignReason.Size = new System.Drawing.Size(500, 31);
            this.txtReassignReason.TabIndex = 40;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.ForeColor = System.Drawing.Color.Black;
            this.lblReason.Location = new System.Drawing.Point(484, 38);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(79, 25);
            this.lblReason.TabIndex = 39;
            this.lblReason.Text = "Reason:";
            // 
            // cboReassignTo
            // 
            this.cboReassignTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReassignTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReassignTo.FormattingEnabled = true;
            this.cboReassignTo.Location = new System.Drawing.Point(131, 37);
            this.cboReassignTo.Name = "cboReassignTo";
            this.cboReassignTo.Size = new System.Drawing.Size(280, 33);
            this.cboReassignTo.TabIndex = 38;
            // 
            // lblReassignTo
            // 
            this.lblReassignTo.AutoSize = true;
            this.lblReassignTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReassignTo.ForeColor = System.Drawing.Color.Black;
            this.lblReassignTo.Location = new System.Drawing.Point(15, 39);
            this.lblReassignTo.Name = "lblReassignTo";
            this.lblReassignTo.Size = new System.Drawing.Size(117, 25);
            this.lblReassignTo.TabIndex = 4;
            this.lblReassignTo.Text = "Reassign To:";
            // 
            // lblReassignTitle
            // 
            this.lblReassignTitle.AutoSize = true;
            this.lblReassignTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReassignTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblReassignTitle.Location = new System.Drawing.Point(15, 3);
            this.lblReassignTitle.Name = "lblReassignTitle";
            this.lblReassignTitle.Size = new System.Drawing.Size(383, 25);
            this.lblReassignTitle.TabIndex = 1;
            this.lblReassignTitle.Text = "REASSIGN COURSE TO DIFFERENT FACULTY";
            // 
            // nudTotalHours
            // 
            this.nudTotalHours.DecimalPlaces = 2;
            this.nudTotalHours.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotalHours.Location = new System.Drawing.Point(753, 147);
            this.nudTotalHours.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudTotalHours.Name = "nudTotalHours";
            this.nudTotalHours.Size = new System.Drawing.Size(140, 34);
            this.nudTotalHours.TabIndex = 43;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.Color.Black;
            this.lblHours.Location = new System.Drawing.Point(748, 121);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(110, 25);
            this.lblHours.TabIndex = 42;
            this.lblHours.Text = "Total Hours";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnClear.Location = new System.Drawing.Point(434, 285);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 40);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(248, 285);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Active",
            "Dropped",
            "Substituted"});
            this.cboStatus.Location = new System.Drawing.Point(388, 147);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(300, 36);
            this.cboStatus.TabIndex = 41;
            // 
            // dtpAssignedDate
            // 
            this.dtpAssignedDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAssignedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAssignedDate.Location = new System.Drawing.Point(20, 149);
            this.dtpAssignedDate.Name = "dtpAssignedDate";
            this.dtpAssignedDate.Size = new System.Drawing.Size(300, 34);
            this.dtpAssignedDate.TabIndex = 40;
            // 
            // cboSemester
            // 
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(753, 73);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(300, 36);
            this.cboSemester.TabIndex = 39;
            // 
            // cboCourse
            // 
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(388, 73);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(300, 36);
            this.cboCourse.TabIndex = 38;
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            // 
            // cboFaculty
            // 
            this.cboFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaculty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFaculty.FormattingEnabled = true;
            this.cboFaculty.Location = new System.Drawing.Point(20, 73);
            this.cboFaculty.Name = "cboFaculty";
            this.cboFaculty.Size = new System.Drawing.Size(300, 36);
            this.cboFaculty.TabIndex = 37;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(386, 121);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 25);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(15, 121);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(134, 25);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "Assigned Date";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.ForeColor = System.Drawing.Color.Black;
            this.lblCourse.Location = new System.Drawing.Point(381, 45);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(70, 25);
            this.lblCourse.TabIndex = 6;
            this.lblCourse.Text = "Course";
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaculty.ForeColor = System.Drawing.Color.Black;
            this.lblFaculty.Location = new System.Drawing.Point(15, 45);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(72, 25);
            this.lblFaculty.TabIndex = 4;
            this.lblFaculty.Text = "Faculty";
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemester.ForeColor = System.Drawing.Color.Black;
            this.lblSemester.Location = new System.Drawing.Point(748, 45);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(90, 25);
            this.lblSemester.TabIndex = 3;
            this.lblSemester.Text = "Semester";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblFormTitle.Location = new System.Drawing.Point(15, 6);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(294, 28);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "ADD / REASSIGN WORKLOAD";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.cboFilterDept);
            this.pnlFilter.Controls.Add(this.lblDept);
            this.pnlFilter.Controls.Add(this.cboFilterSemester);
            this.pnlFilter.Controls.Add(this.btnShowAll);
            this.pnlFilter.Controls.Add(this.lblFilterSem);
            this.pnlFilter.Location = new System.Drawing.Point(0, 430);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1340, 45);
            this.pnlFilter.TabIndex = 9;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(720, 5);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 35);
            this.btnFilter.TabIndex = 40;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cboFilterDept
            // 
            this.cboFilterDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFilterDept.FormattingEnabled = true;
            this.cboFilterDept.Location = new System.Drawing.Point(469, 6);
            this.cboFilterDept.Name = "cboFilterDept";
            this.cboFilterDept.Size = new System.Drawing.Size(220, 33);
            this.cboFilterDept.TabIndex = 39;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDept.ForeColor = System.Drawing.Color.Black;
            this.lblDept.Location = new System.Drawing.Point(349, 9);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(120, 25);
            this.lblDept.TabIndex = 38;
            this.lblDept.Text = "Department:";
            // 
            // cboFilterSemester
            // 
            this.cboFilterSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterSemester.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFilterSemester.FormattingEnabled = true;
            this.cboFilterSemester.Location = new System.Drawing.Point(104, 6);
            this.cboFilterSemester.Name = "cboFilterSemester";
            this.cboFilterSemester.Size = new System.Drawing.Size(220, 33);
            this.cboFilterSemester.TabIndex = 37;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.White;
            this.btnShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnShowAll.Location = new System.Drawing.Point(834, 5);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 35);
            this.btnShowAll.TabIndex = 11;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblFilterSem
            // 
            this.lblFilterSem.AutoSize = true;
            this.lblFilterSem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterSem.ForeColor = System.Drawing.Color.Black;
            this.lblFilterSem.Location = new System.Drawing.Point(8, 9);
            this.lblFilterSem.Name = "lblFilterSem";
            this.lblFilterSem.Size = new System.Drawing.Size(96, 25);
            this.lblFilterSem.TabIndex = 4;
            this.lblFilterSem.Text = "Semester:";
            // 
            // dgvAssignments
            // 
            this.dgvAssignments.AllowUserToAddRows = false;
            this.dgvAssignments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvAssignments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAssignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAssignments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAssignments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignments.Location = new System.Drawing.Point(0, 477);
            this.dgvAssignments.MultiSelect = false;
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.ReadOnly = true;
            this.dgvAssignments.RowHeadersVisible = false;
            this.dgvAssignments.RowHeadersWidth = 62;
            this.dgvAssignments.RowTemplate.Height = 28;
            this.dgvAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignments.Size = new System.Drawing.Size(1340, 300);
            this.dgvAssignments.TabIndex = 10;
            this.dgvAssignments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssignments_CellClick);
            this.dgvAssignments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAssignments_CellFormatting);
            // 
            // WorkloadAssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1340, 763);
            this.Controls.Add(this.dgvAssignments);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorkloadAssignmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workload Assignment Management";
            this.Load += new System.EventHandler(this.WorkloadAssignmentForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlReassign.ResumeLayout(false);
            this.pnlReassign.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalHours)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuMaximize;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private Helpers.GradientPanel gradientPanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Button btnManageStandards;
        private System.Windows.Forms.Button btnReassign;
        private System.Windows.Forms.Panel pnlReassign;
        private System.Windows.Forms.TextBox txtReassignReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cboReassignTo;
        private System.Windows.Forms.Label lblReassignTo;
        private System.Windows.Forms.Label lblReassignTitle;
        private System.Windows.Forms.NumericUpDown nudTotalHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtpAssignedDate;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.ComboBox cboFaculty;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cboFilterDept;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.ComboBox cboFilterSemester;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblFilterSem;
        private System.Windows.Forms.DataGridView dgvAssignments;
    }
}