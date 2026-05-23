namespace FacultyWorkloadSystem.Forms
{
    partial class CourseForm
    {
        private System.ComponentModel.IContainer
            components = null;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMaximize = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader = new FacultyWorkloadSystem.Helpers.GradientPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblCourseCode = new System.Windows.Forms.Label();
            this.txtCourseCode = new System.Windows.Forms.TextBox();
            this.lblCourseTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblCreditHours = new System.Windows.Forms.Label();
            this.nudCreditHours = new System.Windows.Forms.NumericUpDown();
            this.lblCourseType = new System.Windows.Forms.Label();
            this.cboCourseType = new System.Windows.Forms.ComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlSearchBar = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCreditHours)).BeginInit();
            this.pnlSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMaximize,
            this.menuMinimize,
            this.sep1,
            this.menuRefresh,
            this.sep2,
            this.menuClose});
            this.mnuFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuFile.ForeColor = System.Drawing.Color.White;
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(38, 20);
            this.mnuFile.Text = "File";
            // 
            // menuMaximize
            // 
            this.menuMaximize.Name = "menuMaximize";
            this.menuMaximize.Size = new System.Drawing.Size(128, 22);
            this.menuMaximize.Text = "Maximize";
            this.menuMaximize.Click += new System.EventHandler(this.menuMaximize_Click);
            // 
            // menuMinimize
            // 
            this.menuMinimize.Name = "menuMinimize";
            this.menuMinimize.Size = new System.Drawing.Size(128, 22);
            this.menuMinimize.Text = "Minimize";
            this.menuMinimize.Click += new System.EventHandler(this.menuMinimize_Click);
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(125, 6);
            // 
            // menuRefresh
            // 
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size = new System.Drawing.Size(128, 22);
            this.menuRefresh.Text = "Refresh";
            this.menuRefresh.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(125, 6);
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(128, 22);
            this.menuClose.Text = "Close";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.gradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.pnlHeader.gradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 24);
            this.pnlHeader.MaximumSize = new System.Drawing.Size(0, 45);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 45);
            this.pnlHeader.TabIndex = 1;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseMove);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(884, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "COURSE MANAGEMENT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.lblFormTitle.Location = new System.Drawing.Point(10, 73);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(119, 15);
            this.lblFormTitle.TabIndex = 16;
            this.lblFormTitle.Text = "ADD / EDIT COURSE";
            // 
            // lblCourseCode
            // 
            this.lblCourseCode.AutoSize = true;
            this.lblCourseCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCourseCode.Location = new System.Drawing.Point(10, 94);
            this.lblCourseCode.Name = "lblCourseCode";
            this.lblCourseCode.Size = new System.Drawing.Size(79, 15);
            this.lblCourseCode.TabIndex = 15;
            this.lblCourseCode.Text = "Course Code:";
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCourseCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCourseCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCourseCode.Location = new System.Drawing.Point(94, 91);
            this.txtCourseCode.Name = "txtCourseCode";
            this.txtCourseCode.Size = new System.Drawing.Size(172, 23);
            this.txtCourseCode.TabIndex = 1;
            // 
            // lblCourseTitle
            // 
            this.lblCourseTitle.AutoSize = true;
            this.lblCourseTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCourseTitle.Location = new System.Drawing.Point(10, 120);
            this.lblCourseTitle.Name = "lblCourseTitle";
            this.lblCourseTitle.Size = new System.Drawing.Size(76, 15);
            this.lblCourseTitle.TabIndex = 14;
            this.lblCourseTitle.Text = "Course Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTitle.Location = new System.Drawing.Point(94, 117);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(532, 23);
            this.txtTitle.TabIndex = 2;
            // 
            // lblCreditHours
            // 
            this.lblCreditHours.AutoSize = true;
            this.lblCreditHours.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreditHours.Location = new System.Drawing.Point(10, 146);
            this.lblCreditHours.Name = "lblCreditHours";
            this.lblCreditHours.Size = new System.Drawing.Size(80, 15);
            this.lblCreditHours.TabIndex = 13;
            this.lblCreditHours.Text = "Credit Hours:";
            // 
            // nudCreditHours
            // 
            this.nudCreditHours.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudCreditHours.Location = new System.Drawing.Point(94, 143);
            this.nudCreditHours.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudCreditHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCreditHours.Name = "nudCreditHours";
            this.nudCreditHours.Size = new System.Drawing.Size(69, 23);
            this.nudCreditHours.TabIndex = 3;
            this.nudCreditHours.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblCourseType
            // 
            this.lblCourseType.AutoSize = true;
            this.lblCourseType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCourseType.Location = new System.Drawing.Point(180, 146);
            this.lblCourseType.Name = "lblCourseType";
            this.lblCourseType.Size = new System.Drawing.Size(77, 15);
            this.lblCourseType.TabIndex = 12;
            this.lblCourseType.Text = "Course Type:";
            // 
            // cboCourseType
            // 
            this.cboCourseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourseType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCourseType.Items.AddRange(new object[] {
            "Theory",
            "Lab",
            "Theory+Lab"});
            this.cboCourseType.Location = new System.Drawing.Point(257, 143);
            this.cboCourseType.Name = "cboCourseType";
            this.cboCourseType.Size = new System.Drawing.Size(138, 23);
            this.cboCourseType.TabIndex = 4;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDept.Location = new System.Drawing.Point(10, 172);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(79, 15);
            this.lblDept.TabIndex = 11;
            this.lblDept.Text = "Department:";
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDept.Location = new System.Drawing.Point(94, 169);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(455, 23);
            this.cboDept.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(10, 198);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbActive.Location = new System.Drawing.Point(94, 196);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(58, 19);
            this.rbActive.TabIndex = 6;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbInactive.Location = new System.Drawing.Point(154, 196);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(66, 19);
            this.rbInactive.TabIndex = 7;
            this.rbInactive.Text = "Inactive";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(10, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnClear.Location = new System.Drawing.Point(99, 224);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(77, 24);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlSearchBar
            // 
            this.pnlSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlSearchBar.Controls.Add(this.lblSummary);
            this.pnlSearchBar.Controls.Add(this.lblSearch);
            this.pnlSearchBar.Controls.Add(this.txtSearch);
            this.pnlSearchBar.Controls.Add(this.btnSearch);
            this.pnlSearchBar.Controls.Add(this.btnShowAll);
            this.pnlSearchBar.Location = new System.Drawing.Point(0, 257);
            this.pnlSearchBar.Name = "pnlSearchBar";
            this.pnlSearchBar.Size = new System.Drawing.Size(884, 31);
            this.pnlSearchBar.TabIndex = 3;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.BackColor = System.Drawing.Color.Transparent;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.lblSummary.Location = new System.Drawing.Point(7, 8);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(93, 15);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "Total Courses: 0";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.lblSearch.Location = new System.Drawing.Point(411, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(48, 15);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(459, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(197, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(664, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.White;
            this.btnShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnShowAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.btnShowAll.Location = new System.Drawing.Point(747, 4);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(77, 24);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvCourses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvCourses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new System.Drawing.Point(0, 294);
            this.dgvCourses.MultiSelect = false;
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.RowTemplate.Height = 28;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(884, 199);
            this.dgvCourses.TabIndex = 4;
            this.dgvCourses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellClick);
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 502);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.pnlSearchBar);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rbInactive);
            this.Controls.Add(this.rbActive);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboDept);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.cboCourseType);
            this.Controls.Add(this.lblCourseType);
            this.Controls.Add(this.nudCreditHours);
            this.Controls.Add(this.lblCreditHours);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblCourseTitle);
            this.Controls.Add(this.txtCourseCode);
            this.Controls.Add(this.lblCourseCode);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Course Management";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCreditHours)).EndInit();
            this.pnlSearchBar.ResumeLayout(false);
            this.pnlSearchBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // ── field declarations ────────────────────────
        private System.Windows.Forms.MenuStrip
            menuStrip1;
        private System.Windows.Forms
            .ToolStripMenuItem mnuFile;
        private System.Windows.Forms
            .ToolStripMenuItem menuMaximize;
        private System.Windows.Forms
            .ToolStripMenuItem menuMinimize;
        private System.Windows.Forms
            .ToolStripSeparator sep1;
        private System.Windows.Forms
            .ToolStripMenuItem menuRefresh;
        private System.Windows.Forms
            .ToolStripSeparator sep2;
        private System.Windows.Forms
            .ToolStripMenuItem menuClose;

        private FacultyWorkloadSystem.Helpers
            .GradientPanel pnlHeader;
        private System.Windows.Forms.Label
            lblTitle;

        private System.Windows.Forms.Label
            lblFormTitle;
        private System.Windows.Forms.Label
            lblCourseCode;
        private System.Windows.Forms.TextBox
            txtCourseCode;
        private System.Windows.Forms.Label
            lblCourseTitle;
        private System.Windows.Forms.TextBox
            txtTitle;
        private System.Windows.Forms.Label
            lblCreditHours;
        private System.Windows.Forms
            .NumericUpDown nudCreditHours;
        private System.Windows.Forms.Label
            lblCourseType;
        private System.Windows.Forms.ComboBox
            cboCourseType;
        private System.Windows.Forms.Label
            lblDept;
        private System.Windows.Forms.ComboBox
            cboDept;
        private System.Windows.Forms.Label
            lblStatus;
        private System.Windows.Forms.RadioButton
            rbActive;
        private System.Windows.Forms.RadioButton
            rbInactive;
        private System.Windows.Forms.Button
            btnSave;
        private System.Windows.Forms.Button
            btnClear;

        private System.Windows.Forms.Panel
            pnlSearchBar;
        private System.Windows.Forms.Label
            lblSummary;
        private System.Windows.Forms.Label
            lblSearch;
        private System.Windows.Forms.TextBox
            txtSearch;
        private System.Windows.Forms.Button
            btnSearch;
        private System.Windows.Forms.Button
            btnShowAll;

        private System.Windows.Forms.DataGridView
            dgvCourses;
    }
}