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
            this.btnSearchCustomer = new MetroFramework.Controls.MetroTile();
            this.ddlCustomer = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ddlCustormerZone = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.CustomerGrid = new MetroFramework.Controls.MetroGrid();
            this.btnFirstPage = new MetroFramework.Controls.MetroTile();
            this.btnNewCustomer = new MetroFramework.Controls.MetroTile();
            this.btnBackPage = new MetroFramework.Controls.MetroTile();
            this.btnLastPage = new MetroFramework.Controls.MetroTile();
            this.btnNextPage = new MetroFramework.Controls.MetroTile();
            this.lblStatusPage = new MetroFramework.Controls.MetroLabel();
            this.lblValid = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(16, 23);
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
            this.metroPanel1.Controls.Add(this.btnSearchCustomer);
            this.metroPanel1.Controls.Add(this.ddlCustomer);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.ddlCustormerZone);
            this.metroPanel1.Controls.Add(this.metroLabel7);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(44, 68);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(759, 82);
            this.metroPanel1.TabIndex = 39;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.ActiveControl = null;
            this.btnSearchCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchCustomer.Location = new System.Drawing.Point(686, 15);
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
            // ddlCustomer
            // 
            this.ddlCustomer.FormattingEnabled = true;
            this.ddlCustomer.ItemHeight = 23;
            this.ddlCustomer.Location = new System.Drawing.Point(377, 25);
            this.ddlCustomer.Name = "ddlCustomer";
            this.ddlCustomer.Size = new System.Drawing.Size(289, 29);
            this.ddlCustomer.TabIndex = 31;
            this.ddlCustomer.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(300, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(71, 25);
            this.metroLabel1.TabIndex = 30;
            this.metroLabel1.Text = "ชื่อลูกค้า";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddlCustormerZone
            // 
            this.ddlCustormerZone.FormattingEnabled = true;
            this.ddlCustormerZone.ItemHeight = 23;
            this.ddlCustormerZone.Location = new System.Drawing.Point(65, 25);
            this.ddlCustormerZone.Name = "ddlCustormerZone";
            this.ddlCustormerZone.Size = new System.Drawing.Size(209, 29);
            this.ddlCustormerZone.TabIndex = 31;
            this.ddlCustormerZone.UseSelectable = true;
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
            this.metroLabel2.Location = new System.Drawing.Point(15, 198);
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
            this.CustomerGrid.Location = new System.Drawing.Point(16, 237);
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
            this.CustomerGrid.Size = new System.Drawing.Size(1170, 460);
            this.CustomerGrid.TabIndex = 44;
            this.CustomerGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerGrid_CellClick);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.ActiveControl = null;
            this.btnFirstPage.BackColor = System.Drawing.Color.Transparent;
            this.btnFirstPage.Location = new System.Drawing.Point(480, 727);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(24, 24);
            this.btnFirstPage.TabIndex = 50;
            this.btnFirstPage.TileImage = global::OrderManagement.Properties.Resources.first_record;
            this.btnFirstPage.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFirstPage.UseCustomBackColor = true;
            this.btnFirstPage.UseSelectable = true;
            this.btnFirstPage.UseTileImage = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.ActiveControl = null;
            this.btnNewCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNewCustomer.Location = new System.Drawing.Point(166, 185);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(49, 54);
            this.btnNewCustomer.TabIndex = 42;
            this.btnNewCustomer.TileImage = global::OrderManagement.Properties.Resources.addUser48;
            this.btnNewCustomer.UseCustomBackColor = true;
            this.btnNewCustomer.UseCustomForeColor = true;
            this.btnNewCustomer.UseSelectable = true;
            this.btnNewCustomer.UseTileImage = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // btnBackPage
            // 
            this.btnBackPage.ActiveControl = null;
            this.btnBackPage.BackColor = System.Drawing.Color.Transparent;
            this.btnBackPage.Location = new System.Drawing.Point(510, 727);
            this.btnBackPage.Name = "btnBackPage";
            this.btnBackPage.Size = new System.Drawing.Size(24, 24);
            this.btnBackPage.TabIndex = 51;
            this.btnBackPage.TileImage = global::OrderManagement.Properties.Resources.playback;
            this.btnBackPage.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBackPage.UseCustomBackColor = true;
            this.btnBackPage.UseSelectable = true;
            this.btnBackPage.UseTileImage = true;
            // 
            // btnLastPage
            // 
            this.btnLastPage.ActiveControl = null;
            this.btnLastPage.BackColor = System.Drawing.Color.Transparent;
            this.btnLastPage.Location = new System.Drawing.Point(660, 727);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(24, 24);
            this.btnLastPage.TabIndex = 52;
            this.btnLastPage.TileImage = global::OrderManagement.Properties.Resources.last_recor;
            this.btnLastPage.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLastPage.UseCustomBackColor = true;
            this.btnLastPage.UseSelectable = true;
            this.btnLastPage.UseTileImage = true;
            // 
            // btnNextPage
            // 
            this.btnNextPage.ActiveControl = null;
            this.btnNextPage.BackColor = System.Drawing.Color.Transparent;
            this.btnNextPage.Location = new System.Drawing.Point(630, 727);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(24, 24);
            this.btnNextPage.TabIndex = 53;
            this.btnNextPage.TileImage = global::OrderManagement.Properties.Resources.play;
            this.btnNextPage.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNextPage.UseCustomBackColor = true;
            this.btnNextPage.UseSelectable = true;
            this.btnNextPage.UseTileImage = true;
            // 
            // lblStatusPage
            // 
            this.lblStatusPage.AutoSize = true;
            this.lblStatusPage.Location = new System.Drawing.Point(541, 727);
            this.lblStatusPage.Name = "lblStatusPage";
            this.lblStatusPage.Size = new System.Drawing.Size(83, 19);
            this.lblStatusPage.TabIndex = 54;
            this.lblStatusPage.Text = "metroLabel4";
            // 
            // lblValid
            // 
            this.lblValid.AutoSize = true;
            this.lblValid.BackColor = System.Drawing.Color.Transparent;
            this.lblValid.ForeColor = System.Drawing.Color.Red;
            this.lblValid.Location = new System.Drawing.Point(16, 713);
            this.lblValid.Name = "lblValid";
            this.lblValid.Size = new System.Drawing.Size(0, 0);
            this.lblValid.TabIndex = 60;
            this.lblValid.UseCustomBackColor = true;
            this.lblValid.UseCustomForeColor = true;
            // 
            // CustomerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValid);
            this.Controls.Add(this.lblStatusPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnBackPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.CustomerGrid);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "CustomerUC";
            this.Size = new System.Drawing.Size(1200, 785);
            this.Load += new System.EventHandler(this.CustomerUC_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile btnSearchCustomer;
        private MetroFramework.Controls.MetroComboBox ddlCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox ddlCustormerZone;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTile btnNewCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroGrid CustomerGrid;
        private MetroFramework.Controls.MetroTile btnFirstPage;
        private MetroFramework.Controls.MetroTile btnBackPage;
        private MetroFramework.Controls.MetroTile btnLastPage;
        private MetroFramework.Controls.MetroTile btnNextPage;
        private MetroFramework.Controls.MetroLabel lblStatusPage;
        private MetroFramework.Controls.MetroLabel lblValid;
    }
}
