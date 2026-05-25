namespace FacultyWorkloadSystem.Forms
{
    partial class FacultyForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMaximize = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gradientPanel1 = new FacultyWorkloadSystem.Helpers.GradientPanel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.grpEmpType = new System.Windows.Forms.GroupBox();
            this.rbContractual = new System.Windows.Forms.RadioButton();
            this.rbVisiting = new System.Windows.Forms.RadioButton();
            this.rbPermanent = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtQualification = new System.Windows.Forms.TextBox();
            this.lblQualification = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnManageDesig = new System.Windows.Forms.Button();
            this.cboDesignation = new System.Windows.Forms.ComboBox();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvFaculty = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.grpEmpType.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).BeginInit();
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
            this.menuStrip1.TabIndex = 2;
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(455, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(345, 38);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "FACULTY MANAGEMENT";
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
            this.gradientPanel1.TabIndex = 4;
            this.gradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseDown);
            this.gradientPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseMove);
            this.gradientPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseUp);
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.Controls.Add(this.grpStatus);
            this.pnlForm.Controls.Add(this.grpEmpType);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.txtQualification);
            this.pnlForm.Controls.Add(this.lblQualification);
            this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.lblPhone);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.btnManageDesig);
            this.pnlForm.Controls.Add(this.cboDesignation);
            this.pnlForm.Controls.Add(this.lblDesignation);
            this.pnlForm.Controls.Add(this.cboDepartment);
            this.pnlForm.Controls.Add(this.lblDepartment);
            this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.lblName);
            this.pnlForm.Controls.Add(this.lblFormTitle);
            this.pnlForm.Location = new System.Drawing.Point(4, 95);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1336, 319);
            this.pnlForm.TabIndex = 5;
            // 
            // grpStatus
            // 
            this.grpStatus.BackColor = System.Drawing.Color.Transparent;
            this.grpStatus.Controls.Add(this.rbInactive);
            this.grpStatus.Controls.Add(this.rbActive);
            this.grpStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatus.ForeColor = System.Drawing.Color.Black;
            this.grpStatus.Location = new System.Drawing.Point(418, 202);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(180, 104);
            this.grpStatus.TabIndex = 28;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInactive.Location = new System.Drawing.Point(10, 60);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(97, 29);
            this.rbInactive.TabIndex = 21;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(10, 28);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(85, 29);
            this.rbActive.TabIndex = 20;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            // 
            // grpEmpType
            // 
            this.grpEmpType.BackColor = System.Drawing.Color.Transparent;
            this.grpEmpType.Controls.Add(this.rbContractual);
            this.grpEmpType.Controls.Add(this.rbVisiting);
            this.grpEmpType.Controls.Add(this.rbPermanent);
            this.grpEmpType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpEmpType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEmpType.ForeColor = System.Drawing.Color.Black;
            this.grpEmpType.Location = new System.Drawing.Point(418, 54);
            this.grpEmpType.Name = "grpEmpType";
            this.grpEmpType.Size = new System.Drawing.Size(180, 115);
            this.grpEmpType.TabIndex = 27;
            this.grpEmpType.TabStop = false;
            this.grpEmpType.Text = "Employee Type";
            // 
            // rbContractual
            // 
            this.rbContractual.AutoSize = true;
            this.rbContractual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContractual.Location = new System.Drawing.Point(10, 80);
            this.rbContractual.Name = "rbContractual";
            this.rbContractual.Size = new System.Drawing.Size(127, 29);
            this.rbContractual.TabIndex = 19;
            this.rbContractual.Text = "Contractual";
            this.rbContractual.UseVisualStyleBackColor = true;
            // 
            // rbVisiting
            // 
            this.rbVisiting.AutoSize = true;
            this.rbVisiting.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVisiting.Location = new System.Drawing.Point(10, 53);
            this.rbVisiting.Name = "rbVisiting";
            this.rbVisiting.Size = new System.Drawing.Size(95, 29);
            this.rbVisiting.TabIndex = 18;
            this.rbVisiting.Text = "Visiting";
            this.rbVisiting.UseVisualStyleBackColor = true;
            // 
            // rbPermanent
            // 
            this.rbPermanent.AutoSize = true;
            this.rbPermanent.Checked = true;
            this.rbPermanent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPermanent.Location = new System.Drawing.Point(10, 26);
            this.rbPermanent.Name = "rbPermanent";
            this.rbPermanent.Size = new System.Drawing.Size(121, 29);
            this.rbPermanent.TabIndex = 17;
            this.rbPermanent.TabStop = true;
            this.rbPermanent.Text = "Permanent";
            this.rbPermanent.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnClear.Location = new System.Drawing.Point(822, 268);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 38);
            this.btnClear.TabIndex = 26;
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
            this.btnSave.Location = new System.Drawing.Point(643, 268);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 38);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtQualification
            // 
            this.txtQualification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQualification.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQualification.Location = new System.Drawing.Point(643, 172);
            this.txtQualification.Multiline = true;
            this.txtQualification.Name = "txtQualification";
            this.txtQualification.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQualification.Size = new System.Drawing.Size(540, 80);
            this.txtQualification.TabIndex = 24;
            // 
            // lblQualification
            // 
            this.lblQualification.AutoSize = true;
            this.lblQualification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualification.ForeColor = System.Drawing.Color.Black;
            this.lblQualification.Location = new System.Drawing.Point(638, 140);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(127, 25);
            this.lblQualification.TabIndex = 23;
            this.lblQualification.Text = "Qualification:";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(940, 83);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(243, 34);
            this.txtPhone.TabIndex = 22;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(934, 50);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(71, 25);
            this.lblPhone.TabIndex = 21;
            this.lblPhone.Text = "Phone:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(643, 84);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(243, 34);
            this.txtEmail.TabIndex = 20;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(638, 51);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(63, 25);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "Email:";
            // 
            // btnManageDesig
            // 
            this.btnManageDesig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageDesig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnManageDesig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageDesig.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageDesig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnManageDesig.Location = new System.Drawing.Point(18, 267);
            this.btnManageDesig.Name = "btnManageDesig";
            this.btnManageDesig.Size = new System.Drawing.Size(217, 40);
            this.btnManageDesig.TabIndex = 11;
            this.btnManageDesig.Text = "Manage Designations";
            this.btnManageDesig.UseVisualStyleBackColor = true;
            this.btnManageDesig.Click += new System.EventHandler(this.btnManageDesig_Click);
            // 
            // cboDesignation
            // 
            this.cboDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDesignation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDesignation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDesignation.FormattingEnabled = true;
            this.cboDesignation.Location = new System.Drawing.Point(12, 215);
            this.cboDesignation.Name = "cboDesignation";
            this.cboDesignation.Size = new System.Drawing.Size(340, 36);
            this.cboDesignation.TabIndex = 10;
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignation.ForeColor = System.Drawing.Color.Black;
            this.lblDesignation.Location = new System.Drawing.Point(12, 190);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(119, 25);
            this.lblDesignation.TabIndex = 9;
            this.lblDesignation.Text = "Designation:";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDepartment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(12, 145);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(340, 36);
            this.cboDepartment.TabIndex = 8;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(12, 118);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(120, 25);
            this.lblDepartment.TabIndex = 7;
            this.lblDepartment.Text = "Department:";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(16, 72);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(336, 34);
            this.txtName.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(15, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 25);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblFormTitle.Location = new System.Drawing.Point(14, 3);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(209, 28);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.Text = "ADD / EDIT FACULTY";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlSearch.Controls.Add(this.btnShowAll);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(4, 418);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1336, 45);
            this.pnlSearch.TabIndex = 6;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.White;
            this.btnShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnShowAll.Location = new System.Drawing.Point(513, 6);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 35);
            this.btnShowAll.TabIndex = 11;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(400, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(82, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 34);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.Black;
            this.lblSearch.Location = new System.Drawing.Point(10, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(74, 25);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search:";
            // 
            // dgvFaculty
            // 
            this.dgvFaculty.AllowUserToAddRows = false;
            this.dgvFaculty.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvFaculty.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFaculty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFaculty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFaculty.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFaculty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFaculty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaculty.Location = new System.Drawing.Point(0, 469);
            this.dgvFaculty.MultiSelect = false;
            this.dgvFaculty.Name = "dgvFaculty";
            this.dgvFaculty.ReadOnly = true;
            this.dgvFaculty.RowHeadersVisible = false;
            this.dgvFaculty.RowHeadersWidth = 62;
            this.dgvFaculty.RowTemplate.Height = 28;
            this.dgvFaculty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaculty.Size = new System.Drawing.Size(1340, 296);
            this.dgvFaculty.TabIndex = 7;
            this.dgvFaculty.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellClick);
            // 
            // FacultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1340, 763);
            this.Controls.Add(this.dgvFaculty);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FacultyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faculty Management";
            this.Load += new System.EventHandler(this.FacultyForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.grpEmpType.ResumeLayout(false);
            this.grpEmpType.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).EndInit();
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
        private System.Windows.Forms.Label lblTitle;
        private Helpers.GradientPanel gradientPanel1;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.GroupBox grpEmpType;
        private System.Windows.Forms.RadioButton rbContractual;
        private System.Windows.Forms.RadioButton rbVisiting;
        private System.Windows.Forms.RadioButton rbPermanent;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtQualification;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnManageDesig;
        private System.Windows.Forms.ComboBox cboDesignation;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvFaculty;
    }
}