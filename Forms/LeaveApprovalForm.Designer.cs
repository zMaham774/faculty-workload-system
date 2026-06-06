namespace FacultyWorkloadSystem.Forms
{
    partial class LeaveApprovalForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMaximize = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientPanel1 = new FacultyWorkloadSystem.Helpers.GradientPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvApproval = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproval)).BeginInit();
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
            this.menuStrip1.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMaximize,
            this.minimizeToolStripMenuItem,
            this.toolStripSep1,
            this.refreshToolStripMenuItem,
            this.toolStripSep2,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuMaximize
            // 
            this.menuMaximize.Name = "menuMaximize";
            this.menuMaximize.Size = new System.Drawing.Size(196, 34);
            this.menuMaximize.Text = "Maximize";
            this.menuMaximize.Click += new System.EventHandler(this.menuMaximize_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(196, 34);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.menuMinimize_Click);
            // 
            // toolStripSep1
            // 
            this.toolStripSep1.Name = "toolStripSep1";
            this.toolStripSep1.Size = new System.Drawing.Size(193, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(196, 34);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // toolStripSep2
            // 
            this.toolStripSep2.Name = "toolStripSep2";
            this.toolStripSep2.Size = new System.Drawing.Size(193, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(196, 34);
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
            this.gradientPanel1.TabIndex = 1;
            this.gradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseDown);
            this.gradientPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseMove);
            this.gradientPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(420, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(463, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LEAVE APPROVAL MANAGEMENT";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlSearch.Controls.Add(this.lblFilterBy);
            this.pnlSearch.Controls.Add(this.cboFilter);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnShowAll);
            this.pnlSearch.Controls.Add(this.lblCount);
            this.pnlSearch.Location = new System.Drawing.Point(0, 96);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1340, 52);
            this.pnlSearch.TabIndex = 2;
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterBy.ForeColor = System.Drawing.Color.Black;
            this.lblFilterBy.Location = new System.Drawing.Point(16, 16);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(70, 25);
            this.lblFilterBy.TabIndex = 0;
            this.lblFilterBy.Text = "Status:";
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilter.Location = new System.Drawing.Point(87, 12);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(150, 33);
            this.cboFilter.TabIndex = 1;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.Black;
            this.lblSearch.Location = new System.Drawing.Point(250, 16);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(74, 25);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(326, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 34);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(145)))), ((int)(((byte)(245)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(650, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 34);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.White;
            this.btnShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.btnShowAll.Location = new System.Drawing.Point(780, 10);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(110, 34);
            this.btnShowAll.TabIndex = 4;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
            this.lblCount.Location = new System.Drawing.Point(886, 16);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(300, 22);
            this.lblCount.TabIndex = 5;
            // 
            // dgvApproval
            // 
            this.dgvApproval.AllowUserToAddRows = false;
            this.dgvApproval.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvApproval.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApproval.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApproval.BackgroundColor = System.Drawing.Color.White;
            this.dgvApproval.ColumnHeadersHeight = 34;
            this.dgvApproval.Location = new System.Drawing.Point(0, 148);
            this.dgvApproval.MultiSelect = false;
            this.dgvApproval.Name = "dgvApproval";
            this.dgvApproval.RowHeadersVisible = false;
            this.dgvApproval.RowHeadersWidth = 62;
            this.dgvApproval.RowTemplate.Height = 32;
            this.dgvApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApproval.Size = new System.Drawing.Size(1340, 615);
            this.dgvApproval.TabIndex = 3;
            this.dgvApproval.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApproval_CellClick);
            this.dgvApproval.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLeaveApprovals_CellFormatting);
            // 
            // LeaveApprovalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1340, 763);
            this.Controls.Add(this.dgvApproval);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LeaveApprovalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave Approval";
            this.Load += new System.EventHandler(this.LeaveApprovalForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproval)).EndInit();
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
            .ToolStripMenuItem closeToolStripMenuItem;
        private FacultyWorkloadSystem.Helpers
            .GradientPanel gradientPanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel
            pnlSearch;
        private System.Windows.Forms.Label
            lblFilterBy;
        private System.Windows.Forms.ComboBox
            cboFilter;
        private System.Windows.Forms.Label
            lblSearch;
        private System.Windows.Forms.TextBox
            txtSearch;
        private System.Windows.Forms.Button
            btnSearch;
        private System.Windows.Forms.Button
            btnShowAll;
        private System.Windows.Forms.Label
            lblCount;
        private System.Windows.Forms.DataGridView
            dgvApproval;
    }
}