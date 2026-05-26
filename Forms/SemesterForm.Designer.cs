namespace FacultyWorkloadSystem.Forms
{
    partial class SemesterForm
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
            System.Windows.Forms
                .DataGridViewCellStyle dgs1 =
                new System.Windows.Forms
                .DataGridViewCellStyle();
            System.Windows.Forms
                .DataGridViewCellStyle dgs2 =
                new System.Windows.Forms
                .DataGridViewCellStyle();

            this.menuStrip1 =
                new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem =
                new System.Windows.Forms
                .ToolStripMenuItem();
            this.menuMaximize =
                new System.Windows.Forms
                .ToolStripMenuItem();
            this.minimizeToolStripMenuItem =
                new System.Windows.Forms
                .ToolStripMenuItem();
            this.toolStripSep1 =
                new System.Windows.Forms
                .ToolStripSeparator();
            this.refreshToolStripMenuItem =
                new System.Windows.Forms
                .ToolStripMenuItem();
            this.toolStripSep2 =
                new System.Windows.Forms
                .ToolStripSeparator();
            this.closeToolStripMenuItem =
                new System.Windows.Forms
                .ToolStripMenuItem();

            this.lblTitle =
                new System.Windows.Forms.Label();
            this.gradientPanel1 =
                new FacultyWorkloadSystem
                .Helpers.GradientPanel();

            this.pnlForm =
                new System.Windows.Forms.Panel();
            this.lblFormTitle =
                new System.Windows.Forms.Label();
            this.lblSemName =
                new System.Windows.Forms.Label();
            this.txtSemName =
                new System.Windows.Forms.TextBox();
            this.lblAcadYear =
                new System.Windows.Forms.Label();
            this.txtAcadYear =
                new System.Windows.Forms.TextBox();
            this.lblStartDate =
                new System.Windows.Forms.Label();
            this.dtpStartDate =
                new System.Windows.Forms
                .DateTimePicker();
            this.lblEndDate =
                new System.Windows.Forms.Label();
            this.dtpEndDate =
                new System.Windows.Forms
                .DateTimePicker();
            this.chkIsCurrent =
                new System.Windows.Forms.CheckBox();
            this.btnSave =
                new System.Windows.Forms.Button();
            this.btnClear =
                new System.Windows.Forms.Button();

            this.pnlSearch =
                new System.Windows.Forms.Panel();
            this.lblSearch =
                new System.Windows.Forms.Label();
            this.txtSearch =
                new System.Windows.Forms.TextBox();
            this.btnSearch =
                new System.Windows.Forms.Button();
            this.btnShowAll =
                new System.Windows.Forms.Button();

            this.dgvSemesters =
                new System.Windows.Forms
                .DataGridView();

            this.menuStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel
                .ISupportInitialize)(
                this.dgvSemesters)).BeginInit();
            this.SuspendLayout();

            // ── MENU STRIP ────────────────────────────
            this.menuStrip1.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.menuStrip1.GripMargin =
                new System.Windows.Forms.Padding(
                    2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize =
                new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(
                new System.Windows.Forms
                .ToolStripItem[]
                { this.fileToolStripMenuItem });
            this.menuStrip1.Location =
                new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode =
                System.Windows.Forms
                .ToolStripRenderMode.Professional;
            this.menuStrip1.Size =
                new System.Drawing.Size(1340, 36);
            this.menuStrip1.TabIndex = 1;

            // File menu item
            this.fileToolStripMenuItem.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.fileToolStripMenuItem
                .DropDownItems.AddRange(
                new System.Windows.Forms
                .ToolStripItem[]
                {
                    this.menuMaximize,
                    this.minimizeToolStripMenuItem,
                    this.toolStripSep1,
                    this.refreshToolStripMenuItem,
                    this.toolStripSep2,
                    this.closeToolStripMenuItem
                });
            this.fileToolStripMenuItem.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.fileToolStripMenuItem.ForeColor =
                System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name =
                "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size =
                new System.Drawing.Size(57, 30);
            this.fileToolStripMenuItem.Text =
                "File";

            this.menuMaximize.Name =
                "menuMaximize";
            this.menuMaximize.Size =
                new System.Drawing.Size(270, 34);
            this.menuMaximize.Text = "Maximize";
            this.menuMaximize.Click +=
                new System.EventHandler(
                    this.menuMaximize_Click);

            this.minimizeToolStripMenuItem.Name =
                "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size =
                new System.Drawing.Size(270, 34);
            this.minimizeToolStripMenuItem.Text =
                "Minimize";
            this.minimizeToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.menuMinimize_Click);

            this.toolStripSep1.Name =
                "toolStripSep1";
            this.toolStripSep1.Size =
                new System.Drawing.Size(267, 6);

            this.refreshToolStripMenuItem.Name =
                "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size =
                new System.Drawing.Size(270, 34);
            this.refreshToolStripMenuItem.Text =
                "Refresh";
            this.refreshToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.menuRefresh_Click);

            this.toolStripSep2.Name =
                "toolStripSep2";
            this.toolStripSep2.Size =
                new System.Drawing.Size(267, 6);

            this.closeToolStripMenuItem.Name =
                "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size =
                new System.Drawing.Size(270, 34);
            this.closeToolStripMenuItem.Text =
                "Close";
            this.closeToolStripMenuItem.Click +=
                new System.EventHandler(
                    this.menuClose_Click);

            // ── GRADIENT HEADER ───────────────────────
            this.gradientPanel1.Controls.Add(
                this.lblTitle);
            this.gradientPanel1.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.gradientBottom =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            this.gradientPanel1.gradientTop =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.gradientPanel1.Location =
                new System.Drawing.Point(0, 36);
            this.gradientPanel1.MaximumSize =
                new System.Drawing.Size(0, 60);
            this.gradientPanel1.Name =
                "gradientPanel1";
            this.gradientPanel1.Size =
                new System.Drawing.Size(1340, 60);
            this.gradientPanel1.TabIndex = 3;
            this.gradientPanel1.MouseDown +=
                new System.Windows.Forms
                .MouseEventHandler(
                    this.gradientPanel1_MouseDown);
            this.gradientPanel1.MouseMove +=
                new System.Windows.Forms
                .MouseEventHandler(
                    this.gradientPanel1_MouseMove);
            this.gradientPanel1.MouseUp +=
                new System.Windows.Forms
                .MouseEventHandler(
                    this.gradientPanel1_MouseUp);

            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor =
                System.Drawing.Color.Transparent;
            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 14F,
                    System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.White;
            this.lblTitle.Location =
                new System.Drawing.Point(455, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text =
                "SEMESTER MANAGEMENT";

            // ── FORM PANEL ────────────────────────────
            this.pnlForm.Anchor =
                ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.pnlForm.BackColor =
                System.Drawing.Color.White;
            this.pnlForm.Controls.Add(
                this.lblFormTitle);
            this.pnlForm.Controls.Add(
                this.lblSemName);
            this.pnlForm.Controls.Add(
                this.txtSemName);
            this.pnlForm.Controls.Add(
                this.lblAcadYear);
            this.pnlForm.Controls.Add(
                this.txtAcadYear);
            this.pnlForm.Controls.Add(
                this.lblStartDate);
            this.pnlForm.Controls.Add(
                this.dtpStartDate);
            this.pnlForm.Controls.Add(
                this.lblEndDate);
            this.pnlForm.Controls.Add(
                this.dtpEndDate);
            this.pnlForm.Controls.Add(
                this.chkIsCurrent);
            this.pnlForm.Controls.Add(
                this.btnSave);
            this.pnlForm.Controls.Add(
                this.btnClear);
            this.pnlForm.Location =
                new System.Drawing.Point(4, 95);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size =
                new System.Drawing.Size(1336, 319);
            this.pnlForm.TabIndex = 4;

            // lblFormTitle
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblFormTitle.Location =
                new System.Drawing.Point(15, 6);
            this.lblFormTitle.Name =
                "lblFormTitle";
            this.lblFormTitle.Text =
                "ADD / EDIT SEMESTER";

            // Row 1 — Sem Name
            this.lblSemName.AutoSize = true;
            this.lblSemName.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblSemName.ForeColor =
                System.Drawing.Color.Black;
            this.lblSemName.Location =
                new System.Drawing.Point(15, 44);
            this.lblSemName.Text =
                "Semester Name:";

            this.txtSemName.BorderStyle =
                System.Windows.Forms
                .BorderStyle.FixedSingle;
            this.txtSemName.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F);
            this.txtSemName.Location =
                new System.Drawing.Point(134, 42);
            this.txtSemName.Name = "txtSemName";
            this.txtSemName.Size =
     new System.Drawing.Size(400, 34);
            this.txtSemName.TabIndex = 1;

            // Acad Year — same row right side
            this.lblAcadYear.AutoSize = true;
            this.lblAcadYear.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblAcadYear.ForeColor =
                System.Drawing.Color.Black;
            this.lblAcadYear.Location =
     new System.Drawing.Point(560, 44);
            this.lblAcadYear.Text =
                "Academic Year:";

            this.txtAcadYear.BorderStyle =
                System.Windows.Forms
                .BorderStyle.FixedSingle;
            this.txtAcadYear.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F);
            this.txtAcadYear.Location =
         new System.Drawing.Point(680, 42);
            this.txtAcadYear.Size =
                new System.Drawing.Size(160, 34);
            this.txtAcadYear.TabIndex = 2;

            // Row 2 — Start Date + End Date
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblStartDate.ForeColor =
                System.Drawing.Color.Black;
            this.lblStartDate.Location =
                new System.Drawing.Point(26, 105);
            this.lblStartDate.Text =
                "Start Date:";

            this.dtpStartDate.Format =
                System.Windows.Forms
                .DateTimePickerFormat.Short;
            this.dtpStartDate.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F);
            this.dtpStartDate.Location =
                new System.Drawing.Point(
                    134, 102);
            this.dtpStartDate.Name =
                "dtpStartDate";
            this.dtpStartDate.Size =
                new System.Drawing.Size(200, 34);
            this.dtpStartDate.TabIndex = 3;
            this.dtpStartDate.Value =
                System.DateTime.Today;

            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblEndDate.ForeColor =
                System.Drawing.Color.Black;
            this.lblEndDate.Location =
                new System.Drawing.Point(
                    380, 105);
            this.lblEndDate.Text = "End Date:";

            this.dtpEndDate.Format =
                System.Windows.Forms
                .DateTimePickerFormat.Short;
            this.dtpEndDate.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F);
            this.dtpEndDate.Location =
                new System.Drawing.Point(
                    460, 102);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size =
                new System.Drawing.Size(200, 34);
            this.dtpEndDate.TabIndex = 4;
            this.dtpEndDate.Value =
                System.DateTime.Today
                .AddMonths(4);

            // Checkbox — Is Current Semester
            this.chkIsCurrent.AutoSize = true;
            this.chkIsCurrent.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.chkIsCurrent.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.chkIsCurrent.Location =
                new System.Drawing.Point(
                    134, 165);
            this.chkIsCurrent.Name =
                "chkIsCurrent";
            this.chkIsCurrent.Size =
                new System.Drawing.Size(
                    250, 29);
            this.chkIsCurrent.TabIndex = 5;
            this.chkIsCurrent.Text =
                "Mark as Current Semester";

            // Buttons — same position as Dept form
            this.btnSave.BackColor =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            this.btnSave.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance
                .BorderSize = 0;
            this.btnSave.FlatStyle =
                System.Windows.Forms
                .FlatStyle.Flat;
            this.btnSave.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor =
                System.Drawing.Color.White;
            this.btnSave.Location =
                new System.Drawing.Point(26, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size =
                new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor =
                false;
            this.btnSave.Click +=
                new System.EventHandler(
                    this.btnSave_Click);

            this.btnClear.BackColor =
                System.Drawing.Color.White;
            this.btnClear.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance
                .BorderColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.btnClear.FlatStyle =
                System.Windows.Forms
                .FlatStyle.Flat;
            this.btnClear.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.btnClear.Location =
                new System.Drawing.Point(
                    203, 269);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size =
                new System.Drawing.Size(150, 40);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor =
                false;
            this.btnClear.Click +=
                new System.EventHandler(
                    this.btnClear_Click);

            // ── SEARCH PANEL ──────────────────────────
            this.pnlSearch.Anchor =
                ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.pnlSearch.BackColor =
                System.Drawing.Color.FromArgb(
                    240, 240, 240);
            this.pnlSearch.Controls.Add(
                this.btnShowAll);
            this.pnlSearch.Controls.Add(
                this.btnSearch);
            this.pnlSearch.Controls.Add(
                this.txtSearch);
            this.pnlSearch.Controls.Add(
                this.lblSearch);
            this.pnlSearch.Location =
                new System.Drawing.Point(7, 424);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size =
                new System.Drawing.Size(1325, 45);
            this.pnlSearch.TabIndex = 5;

            this.btnShowAll.BackColor =
                System.Drawing.Color.White;
            this.btnShowAll.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnShowAll.FlatAppearance
                .BorderColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.btnShowAll.FlatStyle =
                System.Windows.Forms
                .FlatStyle.Flat;
            this.btnShowAll.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold", 8F,
                    System.Drawing.FontStyle.Bold);
            this.btnShowAll.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.btnShowAll.Location =
                new System.Drawing.Point(513, 6);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size =
                new System.Drawing.Size(100, 35);
            this.btnShowAll.TabIndex = 11;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor =
                false;
            this.btnShowAll.Click +=
                new System.EventHandler(
                    this.btnShowAll_Click);

            this.btnSearch.BackColor =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            this.btnSearch.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance
                .BorderSize = 0;
            this.btnSearch.FlatStyle =
                System.Windows.Forms
                .FlatStyle.Flat;
            this.btnSearch.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold", 8F,
                    System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor =
                System.Drawing.Color.White;
            this.btnSearch.Location =
                new System.Drawing.Point(400, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size =
                new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor =
                false;
            this.btnSearch.Click +=
                new System.EventHandler(
                    this.btnSearch_Click);

            this.txtSearch.BorderStyle =
                System.Windows.Forms
                .BorderStyle.FixedSingle;
            this.txtSearch.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F);
            this.txtSearch.Location =
                new System.Drawing.Point(82, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size =
                new System.Drawing.Size(300, 34);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.KeyDown +=
                new System.Windows.Forms
                .KeyEventHandler(
                    this.txtSearch_KeyDown);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor =
                System.Drawing.Color.Black;
            this.lblSearch.Location =
                new System.Drawing.Point(10, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Search:";

            // ── DATA GRID VIEW ────────────────────────
            this.dgvSemesters
                .AllowUserToAddRows = false;
            this.dgvSemesters
                .AllowUserToDeleteRows = false;

            dgs1.BackColor =
                System.Drawing.Color.AliceBlue;
            this.dgvSemesters
                .AlternatingRowsDefaultCellStyle =
                dgs1;

            this.dgvSemesters.Anchor =
                ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.dgvSemesters
                .AutoSizeColumnsMode =
                System.Windows.Forms
                .DataGridViewAutoSizeColumnsMode
                .Fill;
            this.dgvSemesters.BackgroundColor =
                System.Drawing.Color.White;

            dgs2.Alignment =
                System.Windows.Forms
                .DataGridViewContentAlignment
                .MiddleLeft;
            dgs2.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            dgs2.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            dgs2.ForeColor =
                System.Drawing.Color.White;
            dgs2.SelectionBackColor =
                System.Drawing.SystemColors
                .Highlight;
            dgs2.SelectionForeColor =
                System.Drawing.SystemColors
                .HighlightText;
            dgs2.WrapMode =
                System.Windows.Forms
                .DataGridViewTriState.True;
            this.dgvSemesters
                .ColumnHeadersDefaultCellStyle =
                dgs2;
            this.dgvSemesters
                .ColumnHeadersHeightSizeMode =
                System.Windows.Forms
                .DataGridViewColumnHeadersHeightSizeMode
                .AutoSize;
            this.dgvSemesters.Location =
                new System.Drawing.Point(0, 475);
            this.dgvSemesters.MultiSelect =
                false;
            this.dgvSemesters.Name =
                "dgvSemesters";
            this.dgvSemesters.ReadOnly = true;
            this.dgvSemesters
                .RowHeadersVisible = false;
            this.dgvSemesters.RowHeadersWidth =
                62;
            this.dgvSemesters.RowTemplate
                .Height = 28;
            this.dgvSemesters.SelectionMode =
                System.Windows.Forms
                .DataGridViewSelectionMode
                .FullRowSelect;
            this.dgvSemesters.Size =
                new System.Drawing.Size(1340, 290);
            this.dgvSemesters.TabIndex = 6;
            this.dgvSemesters.CellClick +=
                new System.Windows.Forms
                .DataGridViewCellEventHandler(
                    this.dgvSemesters_CellClick);

            // ── FORM SETUP ────────────────────────────
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode =
                System.Windows.Forms
                .AutoScaleMode.Font;
            this.BackColor =
                System.Drawing.Color.White;
            this.ClientSize =
                new System.Drawing.Size(1340, 763);
            this.Controls.Add(
                this.dgvSemesters);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(
                this.gradientPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle =
                System.Windows.Forms
                .FormBorderStyle.None;
            this.Name = "SemesterForm";
            this.StartPosition =
                System.Windows.Forms
                .FormStartPosition.CenterScreen;
            this.Text = "SemesterForm";
            this.Load +=
                new System.EventHandler(
                    this.SemesterForm_Load);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(
                false);
            this.gradientPanel1.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel
                .ISupportInitialize)(
                this.dgvSemesters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip
            menuStrip1;
        private System.Windows.Forms
            .ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms
            .ToolStripMenuItem menuMaximize;
        private System.Windows.Forms
            .ToolStripMenuItem
            minimizeToolStripMenuItem;
        private System.Windows.Forms
            .ToolStripSeparator toolStripSep1;
        private System.Windows.Forms
            .ToolStripMenuItem
            refreshToolStripMenuItem;
        private System.Windows.Forms
            .ToolStripSeparator toolStripSep2;
        private System.Windows.Forms
            .ToolStripMenuItem
            closeToolStripMenuItem;
        private System.Windows.Forms.Label
            lblTitle;
        private FacultyWorkloadSystem.Helpers
            .GradientPanel gradientPanel1;
        private System.Windows.Forms.Panel
            pnlForm;
        private System.Windows.Forms.Label
            lblFormTitle;
        private System.Windows.Forms.Label
            lblSemName;
        private System.Windows.Forms.TextBox
            txtSemName;
        private System.Windows.Forms.Label
            lblAcadYear;
        private System.Windows.Forms.TextBox
            txtAcadYear;
        private System.Windows.Forms.Label
            lblStartDate;
        private System.Windows.Forms
            .DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label
            lblEndDate;
        private System.Windows.Forms
            .DateTimePicker dtpEndDate;
        private System.Windows.Forms.CheckBox
            chkIsCurrent;
        private System.Windows.Forms.Button
            btnSave;
        private System.Windows.Forms.Button
            btnClear;
        private System.Windows.Forms.Panel
            pnlSearch;
        private System.Windows.Forms.Label
            lblSearch;
        private System.Windows.Forms.TextBox
            txtSearch;
        private System.Windows.Forms.Button
            btnSearch;
        private System.Windows.Forms.Button
            btnShowAll;
        private System.Windows.Forms.DataGridView
            dgvSemesters;
    }
}