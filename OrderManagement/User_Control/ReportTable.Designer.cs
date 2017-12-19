namespace OrderManagement.User_Control
{
    partial class ReportTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportTable));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearchReport = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.RptDatePicker = new MetroFramework.Controls.MetroDateTime();
            this.ddlCustomerZone = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new MetroFramework.Controls.MetroLabel();
            this.ReportGrid = new MetroFramework.Controls.MetroGrid();
            this.pnlPager = new MetroFramework.Controls.MetroPanel();
            this.lblRecordCount = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.ddlPageSize = new System.Windows.Forms.ComboBox();
            this.txtPage = new MetroFramework.Controls.MetroTextBox();
            this.btnPageLast = new MetroFramework.Controls.MetroTile();
            this.btnPagePrevious = new MetroFramework.Controls.MetroTile();
            this.btnPageNext = new MetroFramework.Controls.MetroTile();
            this.btnPageFirst = new MetroFramework.Controls.MetroTile();
            this.ddlCustomer = new System.Windows.Forms.ComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ReportGrid)).BeginInit();
            this.pnlPager.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchReport
            // 
            this.btnSearchReport.ActiveControl = null;
            this.btnSearchReport.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchReport.Location = new System.Drawing.Point(976, 14);
            this.btnSearchReport.Name = "btnSearchReport";
            this.btnSearchReport.Size = new System.Drawing.Size(49, 50);
            this.btnSearchReport.TabIndex = 47;
            this.btnSearchReport.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSearchReport.TileImage")));
            this.btnSearchReport.UseCustomBackColor = true;
            this.btnSearchReport.UseSelectable = true;
            this.btnSearchReport.UseStyleColors = true;
            this.btnSearchReport.UseTileImage = true;
            this.btnSearchReport.Click += new System.EventHandler(this.btnSearchReport_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(7, 7);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(87, 25);
            this.metroLabel2.TabIndex = 46;
            this.metroLabel2.Text = "เลือกวันที่";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // RptDatePicker
            // 
            this.RptDatePicker.Location = new System.Drawing.Point(7, 35);
            this.RptDatePicker.MinimumSize = new System.Drawing.Size(0, 29);
            this.RptDatePicker.Name = "RptDatePicker";
            this.RptDatePicker.Size = new System.Drawing.Size(268, 29);
            this.RptDatePicker.TabIndex = 45;
            // 
            // ddlCustomerZone
            // 
            this.ddlCustomerZone.FormattingEnabled = true;
            this.ddlCustomerZone.Location = new System.Drawing.Point(281, 35);
            this.ddlCustomerZone.Name = "ddlCustomerZone";
            this.ddlCustomerZone.Size = new System.Drawing.Size(257, 21);
            this.ddlCustomerZone.TabIndex = 44;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCustomer.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCustomer.Location = new System.Drawing.Point(281, 7);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(116, 25);
            this.lblCustomer.TabIndex = 43;
            this.lblCustomer.Text = "พื้นที่ส่งสินค้า";
            this.lblCustomer.UseCustomBackColor = true;
            // 
            // ReportGrid
            // 
            this.ReportGrid.AllowUserToResizeRows = false;
            this.ReportGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ReportGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReportGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ReportGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReportGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ReportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ReportGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReportGrid.EnableHeadersVisualStyles = false;
            this.ReportGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ReportGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ReportGrid.Location = new System.Drawing.Point(0, 95);
            this.ReportGrid.Name = "ReportGrid";
            this.ReportGrid.ReadOnly = true;
            this.ReportGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReportGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ReportGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ReportGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReportGrid.Size = new System.Drawing.Size(1042, 559);
            this.ReportGrid.TabIndex = 48;
            this.ReportGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReportGrid_CellClick);
            // 
            // pnlPager
            // 
            this.pnlPager.Controls.Add(this.lblRecordCount);
            this.pnlPager.Controls.Add(this.metroLabel4);
            this.pnlPager.Controls.Add(this.metroLabel5);
            this.pnlPager.Controls.Add(this.ddlPageSize);
            this.pnlPager.Controls.Add(this.txtPage);
            this.pnlPager.Controls.Add(this.btnPageLast);
            this.pnlPager.Controls.Add(this.btnPagePrevious);
            this.pnlPager.Controls.Add(this.btnPageNext);
            this.pnlPager.Controls.Add(this.btnPageFirst);
            this.pnlPager.HorizontalScrollbarBarColor = true;
            this.pnlPager.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlPager.HorizontalScrollbarSize = 10;
            this.pnlPager.Location = new System.Drawing.Point(0, 660);
            this.pnlPager.Name = "pnlPager";
            this.pnlPager.Size = new System.Drawing.Size(1045, 40);
            this.pnlPager.TabIndex = 63;
            this.pnlPager.VerticalScrollbarBarColor = true;
            this.pnlPager.VerticalScrollbarHighlightOnWheel = false;
            this.pnlPager.VerticalScrollbarSize = 10;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(115, 14);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(25, 19);
            this.lblRecordCount.TabIndex = 72;
            this.lblRecordCount.Text = "คน";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(783, 14);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(68, 19);
            this.metroLabel4.TabIndex = 66;
            this.metroLabel4.Text = "แสดงข้อมูล";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(3, 14);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(112, 19);
            this.metroLabel5.TabIndex = 71;
            this.metroLabel5.Text = "จำนวนข้อมูลทั้งหมด";
            // 
            // ddlPageSize
            // 
            this.ddlPageSize.FormattingEnabled = true;
            this.ddlPageSize.Location = new System.Drawing.Point(866, 14);
            this.ddlPageSize.Name = "ddlPageSize";
            this.ddlPageSize.Size = new System.Drawing.Size(45, 21);
            this.ddlPageSize.TabIndex = 63;
            this.ddlPageSize.Click += new System.EventHandler(this.ddlPageSize_SelectedIndexChanged);
            // 
            // txtPage
            // 
            // 
            // 
            // 
            this.txtPage.CustomButton.Image = null;
            this.txtPage.CustomButton.Location = new System.Drawing.Point(97, 1);
            this.txtPage.CustomButton.Name = "";
            this.txtPage.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPage.CustomButton.TabIndex = 1;
            this.txtPage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPage.CustomButton.UseSelectable = true;
            this.txtPage.CustomButton.Visible = false;
            this.txtPage.Enabled = false;
            this.txtPage.Lines = new string[] {
        "metroTextBox1"};
            this.txtPage.Location = new System.Drawing.Point(487, 14);
            this.txtPage.MaxLength = 32767;
            this.txtPage.Name = "txtPage";
            this.txtPage.PasswordChar = '\0';
            this.txtPage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPage.SelectedText = "";
            this.txtPage.SelectionLength = 0;
            this.txtPage.SelectionStart = 0;
            this.txtPage.ShortcutsEnabled = true;
            this.txtPage.Size = new System.Drawing.Size(119, 23);
            this.txtPage.TabIndex = 65;
            this.txtPage.Text = "metroTextBox1";
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPage.UseSelectable = true;
            this.txtPage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnPageLast
            // 
            this.btnPageLast.ActiveControl = null;
            this.btnPageLast.BackColor = System.Drawing.Color.Transparent;
            this.btnPageLast.Location = new System.Drawing.Point(648, 14);
            this.btnPageLast.Name = "btnPageLast";
            this.btnPageLast.Size = new System.Drawing.Size(28, 25);
            this.btnPageLast.TabIndex = 64;
            this.btnPageLast.TileImage = global::OrderManagement.Properties.Resources.last_recor;
            this.btnPageLast.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPageLast.UseCustomBackColor = true;
            this.btnPageLast.UseSelectable = true;
            this.btnPageLast.UseTileImage = true;
            this.btnPageLast.Click += new System.EventHandler(this.btnPageLast_Click);
            // 
            // btnPagePrevious
            // 
            this.btnPagePrevious.ActiveControl = null;
            this.btnPagePrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPagePrevious.Location = new System.Drawing.Point(453, 14);
            this.btnPagePrevious.Name = "btnPagePrevious";
            this.btnPagePrevious.Size = new System.Drawing.Size(28, 25);
            this.btnPagePrevious.TabIndex = 3;
            this.btnPagePrevious.TileImage = global::OrderManagement.Properties.Resources.playback;
            this.btnPagePrevious.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPagePrevious.UseCustomBackColor = true;
            this.btnPagePrevious.UseSelectable = true;
            this.btnPagePrevious.UseTileImage = true;
            this.btnPagePrevious.Click += new System.EventHandler(this.btnPagePrevious_Click);
            // 
            // btnPageNext
            // 
            this.btnPageNext.ActiveControl = null;
            this.btnPageNext.BackColor = System.Drawing.Color.Transparent;
            this.btnPageNext.Location = new System.Drawing.Point(612, 14);
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Size = new System.Drawing.Size(28, 25);
            this.btnPageNext.TabIndex = 63;
            this.btnPageNext.TileImage = global::OrderManagement.Properties.Resources.play;
            this.btnPageNext.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPageNext.UseCustomBackColor = true;
            this.btnPageNext.UseSelectable = true;
            this.btnPageNext.UseTileImage = true;
            this.btnPageNext.Click += new System.EventHandler(this.btnPageNext_Click);
            // 
            // btnPageFirst
            // 
            this.btnPageFirst.ActiveControl = null;
            this.btnPageFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnPageFirst.Location = new System.Drawing.Point(417, 14);
            this.btnPageFirst.Name = "btnPageFirst";
            this.btnPageFirst.Size = new System.Drawing.Size(28, 25);
            this.btnPageFirst.TabIndex = 2;
            this.btnPageFirst.TileImage = global::OrderManagement.Properties.Resources.first_record;
            this.btnPageFirst.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPageFirst.UseCustomBackColor = true;
            this.btnPageFirst.UseSelectable = true;
            this.btnPageFirst.UseTileImage = true;
            this.btnPageFirst.Click += new System.EventHandler(this.btnPageFirst_Click);
            // 
            // ddlCustomer
            // 
            this.ddlCustomer.FormattingEnabled = true;
            this.ddlCustomer.Location = new System.Drawing.Point(544, 35);
            this.ddlCustomer.Name = "ddlCustomer";
            this.ddlCustomer.Size = new System.Drawing.Size(405, 21);
            this.ddlCustomer.TabIndex = 65;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(544, 7);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(80, 25);
            this.metroLabel1.TabIndex = 64;
            this.metroLabel1.Text = "ชื่อลูกค้า";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // ReportTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlCustomer);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pnlPager);
            this.Controls.Add(this.ReportGrid);
            this.Controls.Add(this.btnSearchReport);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.RptDatePicker);
            this.Controls.Add(this.ddlCustomerZone);
            this.Controls.Add(this.lblCustomer);
            this.Name = "ReportTable";
            this.Size = new System.Drawing.Size(1045, 708);
            ((System.ComponentModel.ISupportInitialize)(this.ReportGrid)).EndInit();
            this.pnlPager.ResumeLayout(false);
            this.pnlPager.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile btnSearchReport;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime RptDatePicker;
        private System.Windows.Forms.ComboBox ddlCustomerZone;
        private MetroFramework.Controls.MetroLabel lblCustomer;
        private MetroFramework.Controls.MetroGrid ReportGrid;
        private MetroFramework.Controls.MetroPanel pnlPager;
        private MetroFramework.Controls.MetroLabel lblRecordCount;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.ComboBox ddlPageSize;
        private MetroFramework.Controls.MetroTextBox txtPage;
        private MetroFramework.Controls.MetroTile btnPageLast;
        private MetroFramework.Controls.MetroTile btnPagePrevious;
        private MetroFramework.Controls.MetroTile btnPageNext;
        private MetroFramework.Controls.MetroTile btnPageFirst;
        private System.Windows.Forms.ComboBox ddlCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
