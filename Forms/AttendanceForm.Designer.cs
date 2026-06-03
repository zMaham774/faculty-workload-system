namespace FacultyWorkloadSystem.Forms
{
    partial class AttendanceForm
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
            this.fileMenuItem =
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

            this.pnlControls =
                new System.Windows.Forms.Panel();
            this.lblSelectDate =
                new System.Windows.Forms.Label();
            this.dtpDate =
                new System.Windows.Forms
                .DateTimePicker();
            this.lblDateDisplay =
                new System.Windows.Forms.Label();
            this.btnMarkAll =
                new System.Windows.Forms.Button();
            this.btnSaveAll =
                new System.Windows.Forms.Button();

            this.pnlWarning =
                new System.Windows.Forms.Panel();
            this.lblWarning =
                new System.Windows.Forms.Label();

            this.pnlStats =
                new System.Windows.Forms.Panel();
            this.lblPresent =
                new System.Windows.Forms.Label();
            this.lblAbsent =
                new System.Windows.Forms.Label();
            this.lblLate =
                new System.Windows.Forms.Label();
            this.lblLeave =
                new System.Windows.Forms.Label();
            this.lblPending =
                new System.Windows.Forms.Label();

            this.dgvAttendance =
                new System.Windows.Forms
                .DataGridView();

            this.menuStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel
                .ISupportInitialize)(
                this.dgvAttendance)).BeginInit();
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
                { this.fileMenuItem });
            this.menuStrip1.Location =
                new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode =
                System.Windows.Forms
                .ToolStripRenderMode.Professional;
            this.menuStrip1.Size =
                new System.Drawing.Size(1340, 36);
            this.menuStrip1.TabIndex = 0;

            this.fileMenuItem.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.fileMenuItem
                .DropDownItems.AddRange(
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
            this.fileMenuItem.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.fileMenuItem.ForeColor =
                System.Drawing.Color.White;
            this.fileMenuItem.Name =
                "fileMenuItem";
            this.fileMenuItem.Size =
                new System.Drawing.Size(57, 30);
            this.fileMenuItem.Text = "File";

            this.menuMaximize.Name =
                "menuMaximize";
            this.menuMaximize.Size =
                new System.Drawing.Size(270, 34);
            this.menuMaximize.Text = "Maximize";
            this.menuMaximize.Click +=
                new System.EventHandler(
                    this.menuMaximize_Click);

            this.menuMinimize.Name =
                "menuMinimize";
            this.menuMinimize.Size =
                new System.Drawing.Size(270, 34);
            this.menuMinimize.Text = "Minimize";
            this.menuMinimize.Click +=
                new System.EventHandler(
                    this.menuMinimize_Click);

            this.sep1.Name = "sep1";
            this.sep1.Size =
                new System.Drawing.Size(267, 6);

            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size =
                new System.Drawing.Size(270, 34);
            this.menuRefresh.Text = "Refresh";
            this.menuRefresh.Click +=
                new System.EventHandler(
                    this.menuRefresh_Click);

            this.sep2.Name = "sep2";
            this.sep2.Size =
                new System.Drawing.Size(267, 6);

            this.menuClose.Name = "menuClose";
            this.menuClose.Size =
                new System.Drawing.Size(270, 34);
            this.menuClose.Text = "Close";
            this.menuClose.Click +=
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
            this.gradientPanel1.TabIndex = 1;
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
                new System.Drawing.Point(430, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text =
                "ATTENDANCE MANAGEMENT";

            // ── CONTROLS PANEL ────────────────────────
            this.pnlControls.BackColor =
                System.Drawing.Color.White;
            this.pnlControls.Controls.Add(
                this.lblSelectDate);
            this.pnlControls.Controls.Add(
                this.dtpDate);
            this.pnlControls.Controls.Add(
                this.lblDateDisplay);
            this.pnlControls.Controls.Add(
                this.btnMarkAll);
            this.pnlControls.Controls.Add(
                this.btnSaveAll);
            this.pnlControls.Location =
                new System.Drawing.Point(0, 96);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size =
                new System.Drawing.Size(1340, 66);
            this.pnlControls.TabIndex = 2;
            this.pnlControls.Anchor =
                ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));

            this.lblSelectDate.AutoSize = true;
            this.lblSelectDate.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblSelectDate.ForeColor =
                System.Drawing.Color.Black;
            this.lblSelectDate.Location =
                new System.Drawing.Point(16, 22);
            this.lblSelectDate.Text =
                "Date:";

            this.dtpDate.Format =
                System.Windows.Forms
                .DateTimePickerFormat.Long;
            this.dtpDate.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F);
            this.dtpDate.Location =
                new System.Drawing.Point(70, 18);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size =
                new System.Drawing.Size(260, 34);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.Value = System.DateTime.Today;
            this.dtpDate.ValueChanged +=
                new System.EventHandler(
                    this.dtpDate_ValueChanged);

            this.lblDateDisplay.AutoSize = false;
            this.lblDateDisplay.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.lblDateDisplay.ForeColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.lblDateDisplay.BackColor =
                System.Drawing.Color.Transparent;
            this.lblDateDisplay.Location =
                new System.Drawing.Point(350, 22);
            this.lblDateDisplay.Size =
                new System.Drawing.Size(440, 24);
            this.lblDateDisplay.Text = "";

            this.btnMarkAll.BackColor =
                System.Drawing.Color.FromArgb(
                    13, 140, 106);
            this.btnMarkAll.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnMarkAll.FlatAppearance
                .BorderSize = 0;
            this.btnMarkAll.FlatStyle =
                System.Windows.Forms
                .FlatStyle.Flat;
            this.btnMarkAll.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.btnMarkAll.ForeColor =
                System.Drawing.Color.White;
            this.btnMarkAll.Location =
                new System.Drawing.Point(870, 16);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size =
                new System.Drawing.Size(200, 36);
            this.btnMarkAll.Text =
                "Mark All Present";
            this.btnMarkAll.UseVisualStyleBackColor =
                false;
            this.btnMarkAll.Click +=
                new System.EventHandler(
                    this.btnMarkAll_Click);

            this.btnSaveAll.BackColor =
                System.Drawing.Color.FromArgb(
                    33, 145, 245);
            this.btnSaveAll.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnSaveAll.FlatAppearance
                .BorderSize = 0;
            this.btnSaveAll.FlatStyle =
                System.Windows.Forms
                .FlatStyle.Flat;
            this.btnSaveAll.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.btnSaveAll.ForeColor =
                System.Drawing.Color.White;
            this.btnSaveAll.Location =
                new System.Drawing.Point(
                    1086, 16);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size =
                new System.Drawing.Size(200, 36);
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor =
                false;
            this.btnSaveAll.Click +=
                new System.EventHandler(
                    this.btnSaveAll_Click);

            // ── WARNING PANEL ─────────────────────────
            this.pnlWarning.BackColor =
                System.Drawing.Color.FromArgb(
                    255, 243, 205);
            this.pnlWarning.Controls.Add(
                this.lblWarning);
            this.pnlWarning.Location =
                new System.Drawing.Point(0, 162);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size =
                new System.Drawing.Size(1340, 40);
            this.pnlWarning.TabIndex = 3;
            this.pnlWarning.Visible = false;
            this.pnlWarning.Anchor =
                ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));

            this.lblWarning.AutoSize = false;
            this.lblWarning.BackColor =
                System.Drawing.Color.Transparent;
            this.lblWarning.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9.5F,
                    System.Drawing.FontStyle.Bold);
            this.lblWarning.ForeColor =
                System.Drawing.Color.FromArgb(
                    150, 80, 0);
            this.lblWarning.Location =
                new System.Drawing.Point(14, 10);
            this.lblWarning.Size =
                new System.Drawing.Size(1310, 22);
            this.lblWarning.Text = "";

            // ── STATS PANEL ───────────────────────────
            this.pnlStats.BackColor =
                System.Drawing.Color.FromArgb(
                    9, 74, 158);
            this.pnlStats.Controls.Add(
                this.lblPresent);
            this.pnlStats.Controls.Add(
                this.lblAbsent);
            this.pnlStats.Controls.Add(
                this.lblLate);
            this.pnlStats.Controls.Add(
                this.lblLeave);
            this.pnlStats.Controls.Add(
                this.lblPending);
            this.pnlStats.Location =
                new System.Drawing.Point(0, 202);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size =
                new System.Drawing.Size(1340, 38);
            this.pnlStats.TabIndex = 4;
            this.pnlStats.Anchor =
                ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));

            System.Drawing.Font sf =
                new System.Drawing.Font(
                    "Segoe UI", 9.5F,
                    System.Drawing.FontStyle.Bold);

            this.lblPresent.AutoSize = true;
            this.lblPresent.Font = sf;
            this.lblPresent.BackColor =
                System.Drawing.Color.Transparent;
            this.lblPresent.ForeColor =
                System.Drawing.Color.FromArgb(
                    150, 255, 150);
            this.lblPresent.Location =
                new System.Drawing.Point(20, 10);
            this.lblPresent.Text = "Present: 0";

            this.lblAbsent.AutoSize = true;
            this.lblAbsent.Font = sf;
            this.lblAbsent.BackColor =
                System.Drawing.Color.Transparent;
            this.lblAbsent.ForeColor =
                System.Drawing.Color.FromArgb(
                    255, 150, 150);
            this.lblAbsent.Location =
                new System.Drawing.Point(160, 10);
            this.lblAbsent.Text = "Absent: 0";

            this.lblLate.AutoSize = true;
            this.lblLate.Font = sf;
            this.lblLate.BackColor =
                System.Drawing.Color.Transparent;
            this.lblLate.ForeColor =
                System.Drawing.Color.FromArgb(
                    200, 200, 255);
            this.lblLate.Location =
                new System.Drawing.Point(300, 10);
            this.lblLate.Text = "Late: 0";

            this.lblLeave.AutoSize = true;
            this.lblLeave.Font = sf;
            this.lblLeave.BackColor =
                System.Drawing.Color.Transparent;
            this.lblLeave.ForeColor =
                System.Drawing.Color.FromArgb(
                    255, 230, 150);
            this.lblLeave.Location =
                new System.Drawing.Point(420, 10);
            this.lblLeave.Text = "Leave: 0";

            this.lblPending.AutoSize = true;
            this.lblPending.Font = sf;
            this.lblPending.BackColor =
                System.Drawing.Color.Transparent;
            this.lblPending.ForeColor =
                System.Drawing.Color.White;
            this.lblPending.Location =
                new System.Drawing.Point(560, 10);
            this.lblPending.Text = "Pending: 0";

            // ── DATA GRID VIEW ────────────────────────
            dgs1.BackColor =
                System.Drawing.Color.AliceBlue;
            this.dgvAttendance
                .AlternatingRowsDefaultCellStyle =
                dgs1;

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
                System.Drawing.SystemColors.Highlight;
            dgs2.SelectionForeColor =
                System.Drawing.SystemColors
                .HighlightText;
            dgs2.WrapMode =
                System.Windows.Forms
                .DataGridViewTriState.True;

            this.dgvAttendance
                .ColumnHeadersDefaultCellStyle =
                dgs2;
            this.dgvAttendance
                .EnableHeadersVisualStyles = false;
            this.dgvAttendance
                .AllowUserToAddRows = false;
            this.dgvAttendance
                .AllowUserToDeleteRows = false;
            this.dgvAttendance
                .AutoSizeColumnsMode =
                System.Windows.Forms
                .DataGridViewAutoSizeColumnsMode
                .Fill;
            this.dgvAttendance.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvAttendance
                .ColumnHeadersHeightSizeMode =
                System.Windows.Forms
                .DataGridViewColumnHeadersHeightSizeMode
                .AutoSize;
            this.dgvAttendance.Location =
                new System.Drawing.Point(0, 240);
            this.dgvAttendance.MultiSelect = false;
            this.dgvAttendance.Name =
                "dgvAttendance";
            this.dgvAttendance.ReadOnly = false;
            this.dgvAttendance
                .RowHeadersVisible = false;
            this.dgvAttendance.RowHeadersWidth =
                62;
            this.dgvAttendance.RowTemplate
                .Height = 34;
            this.dgvAttendance.SelectionMode =
                System.Windows.Forms
                .DataGridViewSelectionMode
                .FullRowSelect;
            this.dgvAttendance.Size =
                new System.Drawing.Size(1340, 523);
            this.dgvAttendance.TabIndex = 5;
            this.dgvAttendance.Anchor =
                ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.dgvAttendance.CellClick +=
                new System.Windows.Forms
                .DataGridViewCellEventHandler(
                    this.dgvAttendance_CellClick);
            this.dgvAttendance.CellFormatting +=
                new System.Windows.Forms
                .DataGridViewCellFormattingEventHandler(
                    this.dgvAttendance_CellFormatting);

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
                this.dgvAttendance);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlWarning);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(
                this.gradientPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle =
                System.Windows.Forms
                .FormBorderStyle.None;
            this.Name = "AttendanceForm";
            this.StartPosition =
                System.Windows.Forms
                .FormStartPosition.CenterScreen;
            this.Text = "AttendanceForm";
            this.Load +=
                new System.EventHandler(
                    this.AttendanceForm_Load);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(
                false);
            this.gradientPanel1.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.pnlWarning.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            ((System.ComponentModel
                .ISupportInitialize)(
                this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip
            menuStrip1;
        private System.Windows.Forms
            .ToolStripMenuItem fileMenuItem;
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
            pnlControls;
        private System.Windows.Forms.Label
            lblSelectDate;
        private System.Windows.Forms
            .DateTimePicker dtpDate;
        private System.Windows.Forms.Label
            lblDateDisplay;
        private System.Windows.Forms.Button
            btnMarkAll;
        private System.Windows.Forms.Button
            btnSaveAll;
        private System.Windows.Forms.Panel
            pnlWarning;
        private System.Windows.Forms.Label
            lblWarning;
        private System.Windows.Forms.Panel
            pnlStats;
        private System.Windows.Forms.Label
            lblPresent;
        private System.Windows.Forms.Label
            lblAbsent;
        private System.Windows.Forms.Label
            lblLate;
        private System.Windows.Forms.Label
            lblLeave;
        private System.Windows.Forms.Label
            lblPending;
        private System.Windows.Forms.DataGridView
            dgvAttendance;
    }
}