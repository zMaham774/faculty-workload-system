namespace FacultyWorkloadSystem.Forms
{
    partial class DesignationForm
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
                .DataGridViewCellStyle hdrStyle =
                new System.Windows.Forms
                .DataGridViewCellStyle();
            System.Windows.Forms
                .DataGridViewCellStyle altStyle =
                new System.Windows.Forms
                .DataGridViewCellStyle();

            this.menuStrip1 =
                new System.Windows.Forms.MenuStrip();
            this.fileMenu =
                new System.Windows.Forms
                .ToolStripMenuItem();
            this.menuMaximize =
                new System.Windows.Forms
                .ToolStripMenuItem();
            this.menuMinimize =
                new System.Windows.Forms
                .ToolStripMenuItem();
            this.sep1 =
                new System.Windows.Forms
                .ToolStripSeparator();
            this.menuRefresh =
                new System.Windows.Forms
                .ToolStripMenuItem();
            this.sep2 =
                new System.Windows.Forms
                .ToolStripSeparator();
            this.menuClose =
                new System.Windows.Forms
                .ToolStripMenuItem();

            this.gradientPanel1 =
                new FacultyWorkloadSystem
                .Helpers.GradientPanel();
            this.lblTitle =
                new System.Windows.Forms.Label();

            this.pnlForm =
                new System.Windows.Forms.Panel();
            this.lblFormTitle =
                new System.Windows.Forms.Label();
            this.lblDesignationName =
                new System.Windows.Forms.Label();
            this.txtDesignationName =
                new System.Windows.Forms.TextBox();
            this.lblRankOrder =
                new System.Windows.Forms.Label();
            this.nudRankOrder =
                new System.Windows.Forms
                .NumericUpDown();
            this.lblHint =
                new System.Windows.Forms.Label();
            this.btnSave =
                new System.Windows.Forms.Button();
            this.btnClear =
                new System.Windows.Forms.Button();

            this.pnlSummary =
                new System.Windows.Forms.Panel();
            this.lblSummary =
                new System.Windows.Forms.Label();

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

            this.dgvDesignations =
                new System.Windows.Forms
                .DataGridView();

            this.menuStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel
                .ISupportInitialize)(
                this.nudRankOrder)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel
                .ISupportInitialize)(
                this.dgvDesignations)).BeginInit();
            this.SuspendLayout();

            // ── menuStrip1 ────────────────────────────
            this.menuStrip1.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.menuStrip1.Items.AddRange(
                new System.Windows.Forms
                .ToolStripItem[]
                { this.fileMenu });
            this.menuStrip1.Location =
                new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size =
                new System.Drawing.Size(1000, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.RenderMode =
                System.Windows.Forms
                .ToolStripRenderMode.Professional;

            // fileMenu
            this.fileMenu.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.fileMenu.ForeColor =
                System.Drawing.Color.White;
            this.fileMenu.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.fileMenu.Text = "File";
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size =
                new System.Drawing.Size(57, 30);
            this.fileMenu.DropDownItems.AddRange(
                new System.Windows.Forms
                .ToolStripItem[]
                {
                    this.menuMaximize,
                    this.menuMinimize,
                    this.sep1,
                    this.menuRefresh,
                    this.sep2,
                    this.menuClose
                });

            this.menuMaximize.Name =
                "menuMaximize";
            this.menuMaximize.Text = "Maximize";
            this.menuMaximize.Size =
                new System.Drawing.Size(200, 34);
            this.menuMaximize.Click +=
                new System.EventHandler(
                    this.menuMaximize_Click);

            this.menuMinimize.Name =
                "menuMinimize";
            this.menuMinimize.Text = "Minimize";
            this.menuMinimize.Size =
                new System.Drawing.Size(200, 34);
            this.menuMinimize.Click +=
                new System.EventHandler(
                    this.menuMinimize_Click);

            this.sep1.Name = "sep1";
            this.sep1.Size =
                new System.Drawing.Size(197, 6);

            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Text = "Refresh";
            this.menuRefresh.Size =
                new System.Drawing.Size(200, 34);
            this.menuRefresh.Click +=
                new System.EventHandler(
                    this.menuRefresh_Click);

            this.sep2.Name = "sep2";
            this.sep2.Size =
                new System.Drawing.Size(197, 6);

            this.menuClose.Name = "menuClose";
            this.menuClose.Text = "Close";
            this.menuClose.Size =
                new System.Drawing.Size(200, 34);
            this.menuClose.Click +=
                new System.EventHandler(
                    this.menuClose_Click);

            // ── gradientPanel1 (header) ───────────────
            this.gradientPanel1.gradientTop =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.gradientPanel1.gradientBottom =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            this.gradientPanel1.Dock =
                System.Windows.Forms
                .DockStyle.Top;
            this.gradientPanel1.Location =
                new System.Drawing.Point(0, 36);
            this.gradientPanel1.MaximumSize =
                new System.Drawing.Size(0, 60);
            this.gradientPanel1.Name =
                "gradientPanel1";
            this.gradientPanel1.Size =
                new System.Drawing.Size(1000, 60);
            this.gradientPanel1.TabIndex = 1;
            this.gradientPanel1.Controls.Add(
                this.lblTitle);
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

            // lblTitle
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
                new System.Drawing.Point(
                    340, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text =
                "DESIGNATION MANAGEMENT";

            // ── pnlForm ───────────────────────────────
            this.pnlForm.BackColor =
                System.Drawing.Color.White;
            this.pnlForm.Location =
                new System.Drawing.Point(0, 96);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size =
                new System.Drawing.Size(1000, 240);
            this.pnlForm.TabIndex = 2;
            this.pnlForm.Anchor =
                ((System.Windows.Forms
                .AnchorStyles)(
                (System.Windows.Forms
                .AnchorStyles.Top |
                System.Windows.Forms
                .AnchorStyles.Left |
                System.Windows.Forms
                .AnchorStyles.Right)));

            // left blue accent bar
            var accentBar =
                new System.Windows.Forms.Panel();
            accentBar.BackColor =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            accentBar.Location =
                new System.Drawing.Point(0, 0);
            accentBar.Size =
                new System.Drawing.Size(5, 240);
            this.pnlForm.Controls.Add(accentBar);

            // lblFormTitle
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 11F,
                    System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblFormTitle.Location =
                new System.Drawing.Point(20, 12);
            this.lblFormTitle.Name =
                "lblFormTitle";
            this.lblFormTitle.Text =
                "ADD / EDIT DESIGNATION";

            // lblDesignationName
            this.lblDesignationName.AutoSize =
                true;
            this.lblDesignationName.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblDesignationName.ForeColor =
                System.Drawing.Color.Black;
            this.lblDesignationName.Location =
                new System.Drawing.Point(20, 58);
            this.lblDesignationName.Text =
                "Designation Name:";

            // txtDesignationName
            this.txtDesignationName.BorderStyle =
                System.Windows.Forms
                .BorderStyle.FixedSingle;
            this.txtDesignationName.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F);
            this.txtDesignationName.Location =
                new System.Drawing.Point(
                    185, 55);
            this.txtDesignationName.Name =
                "txtDesignationName";
            this.txtDesignationName.Size =
                new System.Drawing.Size(450, 34);
            this.txtDesignationName.TabIndex = 1;

            // lblRankOrder
            this.lblRankOrder.AutoSize = true;
            this.lblRankOrder.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblRankOrder.ForeColor =
                System.Drawing.Color.Black;
            this.lblRankOrder.Location =
                new System.Drawing.Point(
                    20, 120);
            this.lblRankOrder.Text =
                "Rank Order:";

            // nudRankOrder
            this.nudRankOrder.Location =
                new System.Drawing.Point(
                    185, 116);
            this.nudRankOrder.Maximum = 100;
            this.nudRankOrder.Minimum = 1;
            this.nudRankOrder.Value = 1;
            this.nudRankOrder.Name =
                "nudRankOrder";
            this.nudRankOrder.Size =
                new System.Drawing.Size(100, 30);
            this.nudRankOrder.TabIndex = 2;
            this.nudRankOrder.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F);

            // lblHint
            this.lblHint.AutoSize = true;
            this.lblHint.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8.5F,
                    System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor =
                System.Drawing.Color.FromArgb(
                    100, 130, 170);
            this.lblHint.Location =
                new System.Drawing.Point(
                    300, 122);
            this.lblHint.Text =
                "Lower number = higher priority " +
                "(e.g. 1 = Lecturer, 4 = Professor)";

            // btnSave
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
                new System.Drawing.Point(20, 175);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size =
                new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor =
                false;
            this.btnSave.Click +=
                new System.EventHandler(
                    this.btnSave_Click);

            // btnClear
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
                    190, 175);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size =
                new System.Drawing.Size(150, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor =
                false;
            this.btnClear.Click +=
                new System.EventHandler(
                    this.btnClear_Click);

            // Add controls to pnlForm
            this.pnlForm.Controls.Add(
                this.lblFormTitle);
            this.pnlForm.Controls.Add(
                this.lblDesignationName);
            this.pnlForm.Controls.Add(
                this.txtDesignationName);
            this.pnlForm.Controls.Add(
                this.lblRankOrder);
            this.pnlForm.Controls.Add(
                this.nudRankOrder);
            this.pnlForm.Controls.Add(
                this.lblHint);
            this.pnlForm.Controls.Add(
                this.btnSave);
            this.pnlForm.Controls.Add(
                this.btnClear);

            // ── pnlSummary ────────────────────────────
            this.pnlSummary.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.pnlSummary.Location =
                new System.Drawing.Point(0, 336);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size =
                new System.Drawing.Size(1000, 38);
            this.pnlSummary.TabIndex = 3;
            this.pnlSummary.Anchor =
                ((System.Windows.Forms
                .AnchorStyles)(
                (System.Windows.Forms
                .AnchorStyles.Top |
                System.Windows.Forms
                .AnchorStyles.Left |
                System.Windows.Forms
                .AnchorStyles.Right)));

            this.lblSummary.AutoSize = true;
            this.lblSummary.BackColor =
                System.Drawing.Color.Transparent;
            this.lblSummary.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor =
                System.Drawing.Color.White;
            this.lblSummary.Location =
                new System.Drawing.Point(14, 10);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Text =
                "Total Designations: 0";
            this.pnlSummary.Controls.Add(
                this.lblSummary);

            // ── pnlSearch ─────────────────────────────
            this.pnlSearch.BackColor =
                System.Drawing.Color.FromArgb(
                    240, 240, 240);
            this.pnlSearch.Location =
                new System.Drawing.Point(0, 374);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size =
                new System.Drawing.Size(1000, 48);
            this.pnlSearch.TabIndex = 4;
            this.pnlSearch.Anchor =
                ((System.Windows.Forms
                .AnchorStyles)(
                (System.Windows.Forms
                .AnchorStyles.Top |
                System.Windows.Forms
                .AnchorStyles.Left |
                System.Windows.Forms
                .AnchorStyles.Right)));

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor =
                System.Drawing.Color.Black;
            this.lblSearch.Location =
                new System.Drawing.Point(12, 14);
            this.lblSearch.Text = "Search:";

            this.txtSearch.BorderStyle =
                System.Windows.Forms
                .BorderStyle.FixedSingle;
            this.txtSearch.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F);
            this.txtSearch.Location =
                new System.Drawing.Point(82, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size =
                new System.Drawing.Size(280, 34);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown +=
                new System.Windows.Forms
                .KeyEventHandler(
                    this.txtSearch_KeyDown);

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
                new System.Drawing.Point(
                    376, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size =
                new System.Drawing.Size(100, 34);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor =
                false;
            this.btnSearch.Click +=
                new System.EventHandler(
                    this.btnSearch_Click);

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
                new System.Drawing.Point(
                    490, 8);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size =
                new System.Drawing.Size(100, 34);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor =
                false;
            this.btnShowAll.Click +=
                new System.EventHandler(
                    this.btnShowAll_Click);

            this.pnlSearch.Controls.Add(
                this.lblSearch);
            this.pnlSearch.Controls.Add(
                this.txtSearch);
            this.pnlSearch.Controls.Add(
                this.btnSearch);
            this.pnlSearch.Controls.Add(
                this.btnShowAll);

            // ── dgvDesignations ───────────────────────
            altStyle.BackColor =
                System.Drawing.Color.AliceBlue;
            this.dgvDesignations
                .AlternatingRowsDefaultCellStyle =
                altStyle;

            hdrStyle.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            hdrStyle.ForeColor =
                System.Drawing.Color.White;
            hdrStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            hdrStyle.Alignment =
                System.Windows.Forms
                .DataGridViewContentAlignment
                .MiddleLeft;
            this.dgvDesignations
                .ColumnHeadersDefaultCellStyle =
                hdrStyle;

            this.dgvDesignations
                .AllowUserToAddRows = false;
            this.dgvDesignations
                .AllowUserToDeleteRows = false;
            this.dgvDesignations
                .AutoSizeColumnsMode =
                System.Windows.Forms
                .DataGridViewAutoSizeColumnsMode
                .Fill;
            this.dgvDesignations.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvDesignations
                .ColumnHeadersHeightSizeMode =
                System.Windows.Forms
                .DataGridViewColumnHeadersHeightSizeMode
                .AutoSize;
            this.dgvDesignations.Location =
                new System.Drawing.Point(0, 422);
            this.dgvDesignations.MultiSelect =
                false;
            this.dgvDesignations.Name =
                "dgvDesignations";
            this.dgvDesignations.ReadOnly = true;
            this.dgvDesignations
                .RowHeadersVisible = false;
            this.dgvDesignations.RowTemplate
                .Height = 28;
            this.dgvDesignations.SelectionMode =
                System.Windows.Forms
                .DataGridViewSelectionMode
                .FullRowSelect;
            this.dgvDesignations.Size =
                new System.Drawing.Size(
                    1000, 300);
            this.dgvDesignations.TabIndex = 5;
            this.dgvDesignations.Anchor =
                ((System.Windows.Forms
                .AnchorStyles)((
                System.Windows.Forms
                .AnchorStyles.Top |
                System.Windows.Forms
                .AnchorStyles.Bottom |
                System.Windows.Forms
                .AnchorStyles.Left |
                System.Windows.Forms
                .AnchorStyles.Right)));
            this.dgvDesignations.CellClick +=
                new System.Windows.Forms
                .DataGridViewCellEventHandler(
                    this.dgvDesignations_CellClick);

            // ── FORM ──────────────────────────────────
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode =
                System.Windows.Forms
                .AutoScaleMode.Font;
            this.BackColor =
                System.Drawing.Color.White;
            this.ClientSize =
                new System.Drawing.Size(
                    1000, 720);
            this.Controls.Add(
                this.dgvDesignations);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(
                this.gradientPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle =
                System.Windows.Forms
                .FormBorderStyle.None;
            this.Name = "DesignationForm";
            this.StartPosition =
                System.Windows.Forms
                .FormStartPosition.CenterScreen;
            this.Text = "DesignationForm";
            this.Load +=
                new System.EventHandler(
                    this.DesignationForm_Load);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(
                false);
            this.gradientPanel1.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel
                .ISupportInitialize)(
                this.nudRankOrder)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel
                .ISupportInitialize)(
                this.dgvDesignations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip
            menuStrip1;
        private System.Windows.Forms
            .ToolStripMenuItem fileMenu;
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
            .GradientPanel gradientPanel1;
        private System.Windows.Forms.Label
            lblTitle;
        private System.Windows.Forms.Panel
            pnlForm;
        private System.Windows.Forms.Label
            lblFormTitle;
        private System.Windows.Forms.Label
            lblDesignationName;
        private System.Windows.Forms.TextBox
            txtDesignationName;
        private System.Windows.Forms.Label
            lblRankOrder;
        private System.Windows.Forms
            .NumericUpDown nudRankOrder;
        private System.Windows.Forms.Label
            lblHint;
        private System.Windows.Forms.Button
            btnSave;
        private System.Windows.Forms.Button
            btnClear;
        private System.Windows.Forms.Panel
            pnlSummary;
        private System.Windows.Forms.Label
            lblSummary;
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
            dgvDesignations;
    }
}