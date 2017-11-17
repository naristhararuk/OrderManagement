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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnNewProduct = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnSearchCustomer = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.btnNextPage = new MetroFramework.Controls.MetroTile();
            this.btnLastPage = new MetroFramework.Controls.MetroTile();
            this.btnBackPage = new MetroFramework.Controls.MetroTile();
            this.btnFirstPage = new MetroFramework.Controls.MetroTile();
            this.txtPageNo = new MetroFramework.Controls.MetroTextBox();
            this.lblValid = new MetroFramework.Controls.MetroLabel();
            this.ProductGrid = new MetroFramework.Controls.MetroGrid();
            this.ddlProductCategory = new System.Windows.Forms.ComboBox();
            this.ddlProduct = new System.Windows.Forms.ComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).BeginInit();
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
            this.metroLabel3.TabIndex = 48;
            this.metroLabel3.Text = "ค้นหาข้อมูล";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.ActiveControl = null;
            this.btnNewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNewProduct.Location = new System.Drawing.Point(166, 185);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(49, 54);
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
            this.metroLabel2.Location = new System.Drawing.Point(16, 198);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(104, 25);
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
            this.metroPanel1.Location = new System.Drawing.Point(44, 68);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(883, 82);
            this.metroPanel1.TabIndex = 45;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
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
            this.metroLabel1.Size = new System.Drawing.Size(72, 25);
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
            // btnNextPage
            // 
            this.btnNextPage.ActiveControl = null;
            this.btnNextPage.BackColor = System.Drawing.Color.Transparent;
            this.btnNextPage.Location = new System.Drawing.Point(621, 727);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(24, 24);
            this.btnNextPage.TabIndex = 58;
            this.btnNextPage.TileImage = global::OrderManagement.Properties.Resources.play;
            this.btnNextPage.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNextPage.UseCustomBackColor = true;
            this.btnNextPage.UseSelectable = true;
            this.btnNextPage.UseTileImage = true;
            // 
            // btnLastPage
            // 
            this.btnLastPage.ActiveControl = null;
            this.btnLastPage.BackColor = System.Drawing.Color.Transparent;
            this.btnLastPage.Location = new System.Drawing.Point(651, 727);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(24, 24);
            this.btnLastPage.TabIndex = 57;
            this.btnLastPage.TileImage = global::OrderManagement.Properties.Resources.last_recor;
            this.btnLastPage.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLastPage.UseCustomBackColor = true;
            this.btnLastPage.UseSelectable = true;
            this.btnLastPage.UseTileImage = true;
            // 
            // btnBackPage
            // 
            this.btnBackPage.ActiveControl = null;
            this.btnBackPage.BackColor = System.Drawing.Color.Transparent;
            this.btnBackPage.Location = new System.Drawing.Point(510, 727);
            this.btnBackPage.Name = "btnBackPage";
            this.btnBackPage.Size = new System.Drawing.Size(24, 24);
            this.btnBackPage.TabIndex = 56;
            this.btnBackPage.TileImage = global::OrderManagement.Properties.Resources.playback;
            this.btnBackPage.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBackPage.UseCustomBackColor = true;
            this.btnBackPage.UseSelectable = true;
            this.btnBackPage.UseTileImage = true;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.ActiveControl = null;
            this.btnFirstPage.BackColor = System.Drawing.Color.Transparent;
            this.btnFirstPage.Location = new System.Drawing.Point(480, 727);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(24, 24);
            this.btnFirstPage.TabIndex = 55;
            this.btnFirstPage.TileImage = global::OrderManagement.Properties.Resources.first_record;
            this.btnFirstPage.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFirstPage.UseCustomBackColor = true;
            this.btnFirstPage.UseSelectable = true;
            this.btnFirstPage.UseTileImage = true;
            // 
            // txtPageNo
            // 
            // 
            // 
            // 
            this.txtPageNo.CustomButton.Image = null;
            this.txtPageNo.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtPageNo.CustomButton.Name = "";
            this.txtPageNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPageNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPageNo.CustomButton.TabIndex = 1;
            this.txtPageNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPageNo.CustomButton.UseSelectable = true;
            this.txtPageNo.CustomButton.Visible = false;
            this.txtPageNo.Lines = new string[] {
        "metroTextBox1"};
            this.txtPageNo.Location = new System.Drawing.Point(540, 727);
            this.txtPageNo.MaxLength = 32767;
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.PasswordChar = '\0';
            this.txtPageNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPageNo.SelectedText = "";
            this.txtPageNo.SelectionLength = 0;
            this.txtPageNo.SelectionStart = 0;
            this.txtPageNo.ShortcutsEnabled = true;
            this.txtPageNo.Size = new System.Drawing.Size(75, 23);
            this.txtPageNo.TabIndex = 54;
            this.txtPageNo.Text = "metroTextBox1";
            this.txtPageNo.UseSelectable = true;
            this.txtPageNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPageNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblValid
            // 
            this.lblValid.AutoSize = true;
            this.lblValid.BackColor = System.Drawing.Color.Transparent;
            this.lblValid.ForeColor = System.Drawing.Color.Red;
            this.lblValid.Location = new System.Drawing.Point(16, 713);
            this.lblValid.Name = "lblValid";
            this.lblValid.Size = new System.Drawing.Size(0, 0);
            this.lblValid.TabIndex = 59;
            this.lblValid.UseCustomBackColor = true;
            this.lblValid.UseCustomForeColor = true;
            // 
            // ProductGrid
            // 
            this.ProductGrid.AllowUserToResizeRows = false;
            this.ProductGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ProductGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ProductGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProductGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProductGrid.EnableHeadersVisualStyles = false;
            this.ProductGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ProductGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ProductGrid.Location = new System.Drawing.Point(16, 237);
            this.ProductGrid.Name = "ProductGrid";
            this.ProductGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProductGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ProductGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductGrid.Size = new System.Drawing.Size(1334, 460);
            this.ProductGrid.TabIndex = 60;
            this.ProductGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductGrid_CellClick);
            // 
            // ddlProductCategory
            // 
            this.ddlProductCategory.FormattingEnabled = true;
            this.ddlProductCategory.Location = new System.Drawing.Point(65, 29);
            this.ddlProductCategory.Name = "ddlProductCategory";
            this.ddlProductCategory.Size = new System.Drawing.Size(229, 21);
            this.ddlProductCategory.TabIndex = 61;
            // 
            // ddlProduct
            // 
            this.ddlProduct.FormattingEnabled = true;
            this.ddlProduct.Location = new System.Drawing.Point(477, 29);
            this.ddlProduct.Name = "ddlProduct";
            this.ddlProduct.Size = new System.Drawing.Size(229, 21);
            this.ddlProduct.TabIndex = 61;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel4.ForeColor = System.Drawing.Color.Red;
            this.metroLabel4.Location = new System.Drawing.Point(16, 713);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(0, 0);
            this.metroLabel4.TabIndex = 61;
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            // 
            // ProductUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.ProductGrid);
            this.Controls.Add(this.lblValid);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnBackPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.txtPageNo);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "ProductUC";
            this.Size = new System.Drawing.Size(1370, 785);
            this.Load += new System.EventHandler(this.ProductUC_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).EndInit();
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
        private MetroFramework.Controls.MetroTile btnNextPage;
        private MetroFramework.Controls.MetroTile btnLastPage;
        private MetroFramework.Controls.MetroTile btnBackPage;
        private MetroFramework.Controls.MetroTile btnFirstPage;
        private MetroFramework.Controls.MetroTextBox txtPageNo;
        private MetroFramework.Controls.MetroLabel lblValid;
        private MetroFramework.Controls.MetroGrid ProductGrid;
        private System.Windows.Forms.ComboBox ddlProduct;
        private System.Windows.Forms.ComboBox ddlProductCategory;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}
