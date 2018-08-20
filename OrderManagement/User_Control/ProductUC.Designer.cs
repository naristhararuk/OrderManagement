namespace OrderManagement.User_Control
{
    partial class ProductUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnNewProduct = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.ddlProduct = new System.Windows.Forms.ComboBox();
            this.ddlProductCategory = new System.Windows.Forms.ComboBox();
            this.btnSearchCustomer = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.ProductGrid = new MetroFramework.Controls.MetroGrid();
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
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).BeginInit();
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
            this.metroLabel3.Size = new System.Drawing.Size(99, 25);
            this.metroLabel3.TabIndex = 48;
            this.metroLabel3.Text = "ค้นหาข้อมูล";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.ActiveControl = null;
            this.btnNewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNewProduct.Location = new System.Drawing.Point(166, 128);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(49, 47);
            this.btnNewProduct.TabIndex = 47;
            this.btnNewProduct.TileImage = global::OrderManagement.Properties.Resources.addUser48;
            this.btnNewProduct.UseCustomBackColor = true;
            this.btnNewProduct.UseCustomForeColor = true;
            this.btnNewProduct.UseSelectable = true;
            this.btnNewProduct.UseTileImage = true;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(16, 141);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(97, 25);
            this.metroLabel2.TabIndex = 46;
            this.metroLabel2.Text = "ข้อมูลสินค้า";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.ddlProduct);
            this.metroPanel1.Controls.Add(this.ddlProductCategory);
            this.metroPanel1.Controls.Add(this.btnSearchCustomer);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.metroLabel7);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(44, 47);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(883, 79);
            this.metroPanel1.TabIndex = 45;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // ddlProduct
            // 
            this.ddlProduct.FormattingEnabled = true;
            this.ddlProduct.Location = new System.Drawing.Point(477, 29);
            this.ddlProduct.Name = "ddlProduct";
            this.ddlProduct.Size = new System.Drawing.Size(229, 21);
            this.ddlProduct.TabIndex = 61;
            // 
            // ddlProductCategory
            // 
            this.ddlProductCategory.FormattingEnabled = true;
            this.ddlProductCategory.Location = new System.Drawing.Point(65, 29);
            this.ddlProductCategory.Name = "ddlProductCategory";
            this.ddlProductCategory.Size = new System.Drawing.Size(229, 21);
            this.ddlProductCategory.TabIndex = 61;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.ActiveControl = null;
            this.btnSearchCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchCustomer.Location = new System.Drawing.Point(804, 15);
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
            this.metroLabel1.Location = new System.Drawing.Point(399, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(69, 25);
            this.metroLabel1.TabIndex = 30;
            this.metroLabel1.Text = "ชื่อสินค้า";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(21, 25);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(42, 25);
            this.metroLabel7.TabIndex = 30;
            this.metroLabel7.Text = "กลุ่ม";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProductGrid
            // 
            this.ProductGrid.AllowUserToResizeRows = false;
            this.ProductGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ProductGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ProductGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ProductGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.ProductGrid.EnableHeadersVisualStyles = false;
            this.ProductGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ProductGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ProductGrid.Location = new System.Drawing.Point(16, 180);
            this.ProductGrid.Name = "ProductGrid";
            this.ProductGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ProductGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ProductGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductGrid.Size = new System.Drawing.Size(1300, 350);
            this.ProductGrid.TabIndex = 60;
            this.ProductGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductGrid_CellClick);
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
            this.pnlPager.Location = new System.Drawing.Point(16, 536);
            this.pnlPager.Name = "pnlPager";
            this.pnlPager.Size = new System.Drawing.Size(1300, 53);
            this.pnlPager.TabIndex = 62;
            this.pnlPager.VerticalScrollbarBarColor = true;
            this.pnlPager.VerticalScrollbarHighlightOnWheel = false;
            this.pnlPager.VerticalScrollbarSize = 10;
            this.pnlPager.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPager_Paint);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRecordCount.Location = new System.Drawing.Point(176, 14);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(33, 25);
            this.lblRecordCount.TabIndex = 72;
            this.lblRecordCount.Text = "ชิ้น";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(760, 14);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(88, 25);
            this.metroLabel4.TabIndex = 66;
            this.metroLabel4.Text = "แสดงข้อมูล";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(3, 14);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(149, 25);
            this.metroLabel5.TabIndex = 71;
            this.metroLabel5.Text = "จำนวนข้อมูลทั้งหมด";
            // 
            // ddlPageSize
            // 
            this.ddlPageSize.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ddlPageSize.FormattingEnabled = true;
            this.ddlPageSize.Location = new System.Drawing.Point(866, 14);
            this.ddlPageSize.Name = "ddlPageSize";
            this.ddlPageSize.Size = new System.Drawing.Size(45, 29);
            this.ddlPageSize.TabIndex = 63;
            this.ddlPageSize.SelectedIndexChanged += new System.EventHandler(this.ddlPageSize_SelectedIndexChanged);
            // 
            // txtPage
            // 
            // 
            // 
            // 
            this.txtPage.CustomButton.Image = null;
            this.txtPage.CustomButton.Location = new System.Drawing.Point(91, 2);
            this.txtPage.CustomButton.Name = "";
            this.txtPage.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPage.CustomButton.TabIndex = 1;
            this.txtPage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPage.CustomButton.UseSelectable = true;
            this.txtPage.CustomButton.Visible = false;
            this.txtPage.Enabled = false;
            this.txtPage.FontSize = MetroFramework.MetroTextBoxSize.Tall;
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
            this.txtPage.Size = new System.Drawing.Size(119, 30);
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
            // ProductUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPager);
            this.Controls.Add(this.ProductGrid);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "ProductUC";
            this.Size = new System.Drawing.Size(1350, 731);
            this.Load += new System.EventHandler(this.ProductUC_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).EndInit();
            this.pnlPager.ResumeLayout(false);
            this.pnlPager.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTile btnNewProduct;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile btnSearchCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroGrid ProductGrid;
        private System.Windows.Forms.ComboBox ddlProduct;
        private System.Windows.Forms.ComboBox ddlProductCategory;
        private MetroFramework.Controls.MetroPanel pnlPager;
        private System.Windows.Forms.ComboBox ddlPageSize;
        private MetroFramework.Controls.MetroTextBox txtPage;
        private MetroFramework.Controls.MetroTile btnPageLast;
        private MetroFramework.Controls.MetroTile btnPagePrevious;
        private MetroFramework.Controls.MetroTile btnPageNext;
        private MetroFramework.Controls.MetroTile btnPageFirst;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel lblRecordCount;
        private MetroFramework.Controls.MetroLabel metroLabel5;
    }
}
