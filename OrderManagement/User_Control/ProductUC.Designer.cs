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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductUC));
            this.ProductGrid = new MetroFramework.Controls.MetroGrid();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnNewProduct = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnSearchCustomer = new MetroFramework.Controls.MetroTile();
            this.ddlCustomer = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ddlCustormerZone = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.btnNextPage = new MetroFramework.Controls.MetroTile();
            this.btnLastPage = new MetroFramework.Controls.MetroTile();
            this.btnBackPage = new MetroFramework.Controls.MetroTile();
            this.btnFirstPage = new MetroFramework.Controls.MetroTile();
            this.txtPageNo = new MetroFramework.Controls.MetroTextBox();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productAbbrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripitonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblValid = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).BeginInit();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductGrid
            // 
            this.ProductGrid.AllowUserToResizeRows = false;
            this.ProductGrid.AutoGenerateColumns = false;
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
            this.ProductGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.productAbbrDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.descripitonDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.updateDateDataGridViewTextBoxColumn,
            this.updateByDataGridViewTextBoxColumn});
            this.ProductGrid.DataSource = this.ProductBindingSource;
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
            this.ProductGrid.Size = new System.Drawing.Size(1170, 460);
            this.ProductGrid.TabIndex = 49;
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
            this.metroPanel1.TabIndex = 45;
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
            this.metroLabel1.Size = new System.Drawing.Size(72, 25);
            this.metroLabel1.TabIndex = 30;
            this.metroLabel1.Text = "ชื่อสินค้า";
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
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "ProductID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "ProductID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            // 
            // productAbbrDataGridViewTextBoxColumn
            // 
            this.productAbbrDataGridViewTextBoxColumn.DataPropertyName = "ProductAbbr";
            this.productAbbrDataGridViewTextBoxColumn.HeaderText = "ProductAbbr";
            this.productAbbrDataGridViewTextBoxColumn.Name = "productAbbrDataGridViewTextBoxColumn";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // descripitonDataGridViewTextBoxColumn
            // 
            this.descripitonDataGridViewTextBoxColumn.DataPropertyName = "Descripiton";
            this.descripitonDataGridViewTextBoxColumn.HeaderText = "Descripiton";
            this.descripitonDataGridViewTextBoxColumn.Name = "descripitonDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // updateDateDataGridViewTextBoxColumn
            // 
            this.updateDateDataGridViewTextBoxColumn.DataPropertyName = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.HeaderText = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.Name = "updateDateDataGridViewTextBoxColumn";
            // 
            // updateByDataGridViewTextBoxColumn
            // 
            this.updateByDataGridViewTextBoxColumn.DataPropertyName = "UpdateBy";
            this.updateByDataGridViewTextBoxColumn.HeaderText = "UpdateBy";
            this.updateByDataGridViewTextBoxColumn.Name = "updateByDataGridViewTextBoxColumn";
            // 
            // ProductBindingSource
            // 
            this.ProductBindingSource.DataSource = typeof(OrderManagement.Entity.Product);
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
            // ProductUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValid);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnBackPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.txtPageNo);
            this.Controls.Add(this.ProductGrid);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "ProductUC";
            this.Size = new System.Drawing.Size(1200, 785);
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid ProductGrid;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTile btnNewProduct;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile btnSearchCustomer;
        private MetroFramework.Controls.MetroComboBox ddlCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox ddlCustormerZone;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTile btnNextPage;
        private MetroFramework.Controls.MetroTile btnLastPage;
        private MetroFramework.Controls.MetroTile btnBackPage;
        private MetroFramework.Controls.MetroTile btnFirstPage;
        private MetroFramework.Controls.MetroTextBox txtPageNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productAbbrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripitonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateByDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ProductBindingSource;
        private MetroFramework.Controls.MetroLabel lblValid;
    }
}
