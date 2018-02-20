namespace OrderManagement
{
    partial class CustomerUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.ddlCustomer = new System.Windows.Forms.ComboBox();
            this.ddlCustomerZone = new System.Windows.Forms.ComboBox();
            this.btnSearchCustomer = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.CustomerGrid = new MetroFramework.Controls.MetroGrid();
            this.btnNewCustomer = new MetroFramework.Controls.MetroTile();
            this.pnlPager = new MetroFramework.Controls.MetroPanel();
            this.lblRecordCount = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.ddlPageSize = new System.Windows.Forms.ComboBox();
            this.txtPage = new MetroFramework.Controls.MetroTextBox();
            this.btnPageLast = new MetroFramework.Controls.MetroTile();
            this.btnPagePrevious = new MetroFramework.Controls.MetroTile();
            this.btnPageNext = new MetroFramework.Controls.MetroTile();
            this.btnPageFirst = new MetroFramework.Controls.MetroTile();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGrid)).BeginInit();
            this.pnlPager.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(16, 2);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(105, 25);
            this.metroLabel3.TabIndex = 43;
            this.metroLabel3.Text = "ค้นหาข้อมูล";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.ddlCustomer);
            this.metroPanel1.Controls.Add(this.ddlCustomerZone);
            this.metroPanel1.Controls.Add(this.btnSearchCustomer);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.metroLabel7);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(44, 47);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(858, 78);
            this.metroPanel1.TabIndex = 39;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // ddlCustomer
            // 
            this.ddlCustomer.FormattingEnabled = true;
            this.ddlCustomer.Location = new System.Drawing.Point(433, 25);
            this.ddlCustomer.Name = "ddlCustomer";
            this.ddlCustomer.Size = new System.Drawing.Size(261, 21);
            this.ddlCustomer.TabIndex = 34;
            // 
            // ddlCustomerZone
            // 
            this.ddlCustomerZone.FormattingEnabled = true;
            this.ddlCustomerZone.Location = new System.Drawing.Point(65, 25);
            this.ddlCustomerZone.Name = "ddlCustomerZone";
            this.ddlCustomerZone.Size = new System.Drawing.Size(229, 21);
            this.ddlCustomerZone.TabIndex = 33;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.ActiveControl = null;
            this.btnSearchCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchCustomer.Location = new System.Drawing.Point(769, 15);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(49, 50);
            this.btnSearchCustomer.TabIndex = 32;
            this.btnSearchCustomer.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSearchCustomer.TileImage")));
            this.btnSearchCustomer.UseCustomBackColor = true;
            this.btnSearchCustomer.UseSelectable = true;
            this.btnSearchCustomer.UseStyleColors = true;
            this.btnSearchCustomer.UseTileImage = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(355, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(71, 25);
            this.metroLabel1.TabIndex = 30;
            this.metroLabel1.Text = "ชื่อลูกค้า";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(21, 25);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(38, 25);
            this.metroLabel7.TabIndex = 30;
            this.metroLabel7.Text = "เขต";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(16, 141);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 25);
            this.metroLabel2.TabIndex = 41;
            this.metroLabel2.Text = "รายชื่อลูกค้า";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // CustomerGrid
            // 
            this.CustomerGrid.AllowUserToResizeRows = false;
            this.CustomerGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CustomerGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.CustomerGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CustomerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.CustomerGrid.EnableHeadersVisualStyles = false;
            this.CustomerGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CustomerGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CustomerGrid.Location = new System.Drawing.Point(16, 180);
            this.CustomerGrid.Name = "CustomerGrid";
            this.CustomerGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CustomerGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.CustomerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerGrid.Size = new System.Drawing.Size(1351, 500);
            this.CustomerGrid.TabIndex = 44;
            this.CustomerGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerGrid_CellClick);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.ActiveControl = null;
            this.btnNewCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNewCustomer.Location = new System.Drawing.Point(166, 128);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(49, 47);
            this.btnNewCustomer.TabIndex = 42;
            this.btnNewCustomer.TileImage = global::OrderManagement.Properties.Resources.addUser48;
            this.btnNewCustomer.UseCustomBackColor = true;
            this.btnNewCustomer.UseCustomForeColor = true;
            this.btnNewCustomer.UseSelectable = true;
            this.btnNewCustomer.UseTileImage = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // pnlPager
            // 
            this.pnlPager.Controls.Add(this.lblRecordCount);
            this.pnlPager.Controls.Add(this.metroLabel5);
            this.pnlPager.Controls.Add(this.metroLabel4);
            this.pnlPager.Controls.Add(this.ddlPageSize);
            this.pnlPager.Controls.Add(this.txtPage);
            this.pnlPager.Controls.Add(this.btnPageLast);
            this.pnlPager.Controls.Add(this.btnPagePrevious);
            this.pnlPager.Controls.Add(this.btnPageNext);
            this.pnlPager.Controls.Add(this.btnPageFirst);
            this.pnlPager.HorizontalScrollbarBarColor = true;
            this.pnlPager.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlPager.HorizontalScrollbarSize = 10;
            this.pnlPager.Location = new System.Drawing.Point(16, 686);
            this.pnlPager.Name = "pnlPager";
            this.pnlPager.Size = new System.Drawing.Size(1334, 40);
            this.pnlPager.TabIndex = 63;
            this.pnlPager.VerticalScrollbarBarColor = true;
            this.pnlPager.VerticalScrollbarHighlightOnWheel = false;
            this.pnlPager.VerticalScrollbarSize = 10;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(122, 14);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(25, 19);
            this.lblRecordCount.TabIndex = 70;
            this.lblRecordCount.Text = "คน";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(10, 14);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(112, 19);
            this.metroLabel5.TabIndex = 69;
            this.metroLabel5.Text = "จำนวนข้อมูลทั้งหมด";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(774, 14);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(68, 19);
            this.metroLabel4.TabIndex = 68;
            this.metroLabel4.Text = "แสดงข้อมูล";
            // 
            // ddlPageSize
            // 
            this.ddlPageSize.FormattingEnabled = true;
            this.ddlPageSize.Location = new System.Drawing.Point(842, 14);
            this.ddlPageSize.Name = "ddlPageSize";
            this.ddlPageSize.Size = new System.Drawing.Size(44, 21);
            this.ddlPageSize.TabIndex = 63;
            this.ddlPageSize.SelectedIndexChanged += new System.EventHandler(this.ddlPageSize_SelectedIndexChanged);
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
            // CustomerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPager);
            this.Controls.Add(this.CustomerGrid);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "CustomerUC";
            this.Size = new System.Drawing.Size(1370, 731);
            this.Load += new System.EventHandler(this.CustomerUC_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGrid)).EndInit();
            this.pnlPager.ResumeLayout(false);
            this.pnlPager.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile btnSearchCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTile btnNewCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroGrid CustomerGrid;
        private System.Windows.Forms.ComboBox ddlCustomerZone;
        private System.Windows.Forms.ComboBox ddlCustomer;
        private MetroFramework.Controls.MetroPanel pnlPager;
        private System.Windows.Forms.ComboBox ddlPageSize;
        private MetroFramework.Controls.MetroTextBox txtPage;
        private MetroFramework.Controls.MetroTile btnPageLast;
        private MetroFramework.Controls.MetroTile btnPagePrevious;
        private MetroFramework.Controls.MetroTile btnPageNext;
        private MetroFramework.Controls.MetroTile btnPageFirst;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel lblRecordCount;
    }
}
