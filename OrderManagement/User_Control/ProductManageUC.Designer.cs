namespace OrderManagement.User_Control
{
    partial class ProductManageUC
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.comboProductGroup = new System.Windows.Forms.ComboBox();
            this.btnProductDelete = new MetroFramework.Controls.MetroTile();
            this.txtbProductDescription = new MetroFramework.Controls.MetroTextBox();
            this.btnProductSave = new MetroFramework.Controls.MetroTile();
            this.btnProductClear = new MetroFramework.Controls.MetroButton();
            this.txtbProductAmount = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtbProductPrice = new MetroFramework.Controls.MetroTextBox();
            this.txtbProductUnit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtbProductAbbr = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtbProductName = new MetroFramework.Controls.MetroTextBox();
            this.btnCloseDialog = new MetroFramework.Controls.MetroTile();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(27, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(155, 25);
            this.metroLabel1.TabIndex = 50;
            this.metroLabel1.Text = "จัดการข้อมูลสินค้า";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.comboProductGroup);
            this.metroPanel2.Controls.Add(this.btnProductDelete);
            this.metroPanel2.Controls.Add(this.txtbProductDescription);
            this.metroPanel2.Controls.Add(this.btnProductSave);
            this.metroPanel2.Controls.Add(this.btnProductClear);
            this.metroPanel2.Controls.Add(this.txtbProductAmount);
            this.metroPanel2.Controls.Add(this.metroLabel9);
            this.metroPanel2.Controls.Add(this.txtbProductPrice);
            this.metroPanel2.Controls.Add(this.txtbProductUnit);
            this.metroPanel2.Controls.Add(this.metroLabel8);
            this.metroPanel2.Controls.Add(this.metroLabel7);
            this.metroPanel2.Controls.Add(this.metroLabel5);
            this.metroPanel2.Controls.Add(this.txtbProductAbbr);
            this.metroPanel2.Controls.Add(this.metroLabel4);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.txtbProductName);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(27, 72);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(860, 530);
            this.metroPanel2.TabIndex = 48;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // comboProductGroup
            // 
            this.comboProductGroup.FormattingEnabled = true;
            this.comboProductGroup.Location = new System.Drawing.Point(122, 167);
            this.comboProductGroup.Name = "comboProductGroup";
            this.comboProductGroup.Size = new System.Drawing.Size(300, 21);
            this.comboProductGroup.TabIndex = 55;
            // 
            // btnProductDelete
            // 
            this.btnProductDelete.ActiveControl = null;
            this.btnProductDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnProductDelete.Location = new System.Drawing.Point(709, 454);
            this.btnProductDelete.Name = "btnProductDelete";
            this.btnProductDelete.Size = new System.Drawing.Size(121, 47);
            this.btnProductDelete.TabIndex = 54;
            this.btnProductDelete.Text = "ลบข้อมูล";
            this.btnProductDelete.TileImage = global::OrderManagement.Properties.Resources.recycleBin48;
            this.btnProductDelete.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductDelete.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnProductDelete.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnProductDelete.UseCustomBackColor = true;
            this.btnProductDelete.UseSelectable = true;
            this.btnProductDelete.UseTileImage = true;
            this.btnProductDelete.Click += new System.EventHandler(this.btnProductDelete_Click);
            // 
            // txtbProductDescription
            // 
            // 
            // 
            // 
            this.txtbProductDescription.CustomButton.Image = null;
            this.txtbProductDescription.CustomButton.Location = new System.Drawing.Point(612, 2);
            this.txtbProductDescription.CustomButton.Name = "";
            this.txtbProductDescription.CustomButton.Size = new System.Drawing.Size(73, 73);
            this.txtbProductDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbProductDescription.CustomButton.TabIndex = 1;
            this.txtbProductDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbProductDescription.CustomButton.UseSelectable = true;
            this.txtbProductDescription.CustomButton.Visible = false;
            this.txtbProductDescription.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbProductDescription.Lines = new string[0];
            this.txtbProductDescription.Location = new System.Drawing.Point(122, 69);
            this.txtbProductDescription.MaxLength = 32767;
            this.txtbProductDescription.Multiline = true;
            this.txtbProductDescription.Name = "txtbProductDescription";
            this.txtbProductDescription.PasswordChar = '\0';
            this.txtbProductDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbProductDescription.SelectedText = "";
            this.txtbProductDescription.SelectionLength = 0;
            this.txtbProductDescription.SelectionStart = 0;
            this.txtbProductDescription.ShortcutsEnabled = true;
            this.txtbProductDescription.Size = new System.Drawing.Size(688, 78);
            this.txtbProductDescription.TabIndex = 52;
            this.txtbProductDescription.UseSelectable = true;
            this.txtbProductDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbProductDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnProductSave
            // 
            this.btnProductSave.ActiveControl = null;
            this.btnProductSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnProductSave.Location = new System.Drawing.Point(442, 454);
            this.btnProductSave.Name = "btnProductSave";
            this.btnProductSave.Size = new System.Drawing.Size(121, 47);
            this.btnProductSave.TabIndex = 53;
            this.btnProductSave.Text = "บันทึก";
            this.btnProductSave.TileImage = global::OrderManagement.Properties.Resources.save4_48;
            this.btnProductSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductSave.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnProductSave.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnProductSave.UseCustomBackColor = true;
            this.btnProductSave.UseSelectable = true;
            this.btnProductSave.UseTileImage = true;
            this.btnProductSave.Click += new System.EventHandler(this.btnProductSave_Click);
            // 
            // btnProductClear
            // 
            this.btnProductClear.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnProductClear.Location = new System.Drawing.Point(315, 454);
            this.btnProductClear.Name = "btnProductClear";
            this.btnProductClear.Size = new System.Drawing.Size(121, 47);
            this.btnProductClear.TabIndex = 52;
            this.btnProductClear.Text = "Clear";
            this.btnProductClear.UseSelectable = true;
            this.btnProductClear.Click += new System.EventHandler(this.btnProductClear_Click);
            // 
            // txtbProductAmount
            // 
            // 
            // 
            // 
            this.txtbProductAmount.CustomButton.Image = null;
            this.txtbProductAmount.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.txtbProductAmount.CustomButton.Name = "";
            this.txtbProductAmount.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbProductAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbProductAmount.CustomButton.TabIndex = 1;
            this.txtbProductAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbProductAmount.CustomButton.UseSelectable = true;
            this.txtbProductAmount.CustomButton.Visible = false;
            this.txtbProductAmount.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbProductAmount.Lines = new string[0];
            this.txtbProductAmount.Location = new System.Drawing.Point(122, 314);
            this.txtbProductAmount.MaxLength = 45;
            this.txtbProductAmount.Name = "txtbProductAmount";
            this.txtbProductAmount.PasswordChar = '\0';
            this.txtbProductAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbProductAmount.SelectedText = "";
            this.txtbProductAmount.SelectionLength = 0;
            this.txtbProductAmount.SelectionStart = 0;
            this.txtbProductAmount.ShortcutsEnabled = true;
            this.txtbProductAmount.Size = new System.Drawing.Size(300, 29);
            this.txtbProductAmount.TabIndex = 53;
            this.txtbProductAmount.UseSelectable = true;
            this.txtbProductAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbProductAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbProductAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumeric_KeyPress);
            this.txtbProductAmount.Leave += new System.EventHandler(this.TextBoxInput_Leave);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.Location = new System.Drawing.Point(59, 314);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(59, 25);
            this.metroLabel9.TabIndex = 52;
            this.metroLabel9.Text = "จำนวน";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtbProductPrice
            // 
            // 
            // 
            // 
            this.txtbProductPrice.CustomButton.Image = null;
            this.txtbProductPrice.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.txtbProductPrice.CustomButton.Name = "";
            this.txtbProductPrice.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbProductPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbProductPrice.CustomButton.TabIndex = 1;
            this.txtbProductPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbProductPrice.CustomButton.UseSelectable = true;
            this.txtbProductPrice.CustomButton.Visible = false;
            this.txtbProductPrice.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbProductPrice.Lines = new string[0];
            this.txtbProductPrice.Location = new System.Drawing.Point(122, 265);
            this.txtbProductPrice.MaxLength = 45;
            this.txtbProductPrice.Name = "txtbProductPrice";
            this.txtbProductPrice.PasswordChar = '\0';
            this.txtbProductPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbProductPrice.SelectedText = "";
            this.txtbProductPrice.SelectionLength = 0;
            this.txtbProductPrice.SelectionStart = 0;
            this.txtbProductPrice.ShortcutsEnabled = true;
            this.txtbProductPrice.Size = new System.Drawing.Size(300, 29);
            this.txtbProductPrice.TabIndex = 35;
            this.txtbProductPrice.UseSelectable = true;
            this.txtbProductPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbProductPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbProductPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumeric_KeyPress);
            this.txtbProductPrice.Leave += new System.EventHandler(this.TextBoxInput_Leave);
            // 
            // txtbProductUnit
            // 
            // 
            // 
            // 
            this.txtbProductUnit.CustomButton.Image = null;
            this.txtbProductUnit.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.txtbProductUnit.CustomButton.Name = "";
            this.txtbProductUnit.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbProductUnit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbProductUnit.CustomButton.TabIndex = 1;
            this.txtbProductUnit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbProductUnit.CustomButton.UseSelectable = true;
            this.txtbProductUnit.CustomButton.Visible = false;
            this.txtbProductUnit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbProductUnit.Lines = new string[0];
            this.txtbProductUnit.Location = new System.Drawing.Point(122, 216);
            this.txtbProductUnit.MaxLength = 45;
            this.txtbProductUnit.Name = "txtbProductUnit";
            this.txtbProductUnit.PasswordChar = '\0';
            this.txtbProductUnit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbProductUnit.SelectedText = "";
            this.txtbProductUnit.SelectionLength = 0;
            this.txtbProductUnit.SelectionStart = 0;
            this.txtbProductUnit.ShortcutsEnabled = true;
            this.txtbProductUnit.Size = new System.Drawing.Size(300, 29);
            this.txtbProductUnit.TabIndex = 34;
            this.txtbProductUnit.UseSelectable = true;
            this.txtbProductUnit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbProductUnit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbProductUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumeric_KeyPress);
            this.txtbProductUnit.Leave += new System.EventHandler(this.TextBoxInput_Leave);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel8.Location = new System.Drawing.Point(72, 265);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(46, 25);
            this.metroLabel8.TabIndex = 30;
            this.metroLabel8.Text = "ราคา";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(48, 216);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(70, 25);
            this.metroLabel7.TabIndex = 28;
            this.metroLabel7.Text = "หน่วยยก";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(18, 167);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(100, 25);
            this.metroLabel5.TabIndex = 24;
            this.metroLabel5.Text = "กลุ่ม/ประเภท";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtbProductAbbr
            // 
            // 
            // 
            // 
            this.txtbProductAbbr.CustomButton.Image = null;
            this.txtbProductAbbr.CustomButton.Location = new System.Drawing.Point(233, 1);
            this.txtbProductAbbr.CustomButton.Name = "";
            this.txtbProductAbbr.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbProductAbbr.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbProductAbbr.CustomButton.TabIndex = 1;
            this.txtbProductAbbr.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbProductAbbr.CustomButton.UseSelectable = true;
            this.txtbProductAbbr.CustomButton.Visible = false;
            this.txtbProductAbbr.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbProductAbbr.Lines = new string[0];
            this.txtbProductAbbr.Location = new System.Drawing.Point(549, 17);
            this.txtbProductAbbr.MaxLength = 250;
            this.txtbProductAbbr.Name = "txtbProductAbbr";
            this.txtbProductAbbr.PasswordChar = '\0';
            this.txtbProductAbbr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbProductAbbr.SelectedText = "";
            this.txtbProductAbbr.SelectionLength = 0;
            this.txtbProductAbbr.SelectionStart = 0;
            this.txtbProductAbbr.ShortcutsEnabled = true;
            this.txtbProductAbbr.Size = new System.Drawing.Size(261, 29);
            this.txtbProductAbbr.TabIndex = 23;
            this.txtbProductAbbr.UseSelectable = true;
            this.txtbProductAbbr.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtbProductAbbr.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(452, 21);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(91, 25);
            this.metroLabel4.TabIndex = 22;
            this.metroLabel4.Text = "ชื่อย่อสินค้า";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(31, 69);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(87, 25);
            this.metroLabel3.TabIndex = 20;
            this.metroLabel3.Text = "รายละเอียด";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(46, 21);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(72, 25);
            this.metroLabel2.TabIndex = 19;
            this.metroLabel2.Text = "ชื่อสินค้า";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtbProductName
            // 
            // 
            // 
            // 
            this.txtbProductName.CustomButton.Image = null;
            this.txtbProductName.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.txtbProductName.CustomButton.Name = "";
            this.txtbProductName.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbProductName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbProductName.CustomButton.TabIndex = 1;
            this.txtbProductName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbProductName.CustomButton.UseSelectable = true;
            this.txtbProductName.CustomButton.Visible = false;
            this.txtbProductName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbProductName.Lines = new string[0];
            this.txtbProductName.Location = new System.Drawing.Point(122, 21);
            this.txtbProductName.MaxLength = 250;
            this.txtbProductName.Name = "txtbProductName";
            this.txtbProductName.PasswordChar = '\0';
            this.txtbProductName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbProductName.SelectedText = "";
            this.txtbProductName.SelectionLength = 0;
            this.txtbProductName.SelectionStart = 0;
            this.txtbProductName.ShortcutsEnabled = true;
            this.txtbProductName.Size = new System.Drawing.Size(300, 29);
            this.txtbProductName.TabIndex = 18;
            this.txtbProductName.UseSelectable = true;
            this.txtbProductName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbProductName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnCloseDialog
            // 
            this.btnCloseDialog.ActiveControl = null;
            this.btnCloseDialog.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseDialog.Location = new System.Drawing.Point(867, 27);
            this.btnCloseDialog.Name = "btnCloseDialog";
            this.btnCloseDialog.Size = new System.Drawing.Size(20, 23);
            this.btnCloseDialog.TabIndex = 51;
            this.btnCloseDialog.TileImage = global::OrderManagement.Properties.Resources.close20;
            this.btnCloseDialog.UseCustomBackColor = true;
            this.btnCloseDialog.UseSelectable = true;
            this.btnCloseDialog.UseTileImage = true;
            this.btnCloseDialog.Click += new System.EventHandler(this.btnCloseDialog_Click);
            // 
            // ProductManageUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCloseDialog);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroPanel2);
            this.Name = "ProductManageUC";
            this.Size = new System.Drawing.Size(916, 632);
            this.Load += new System.EventHandler(this.ProductManageUC_Load);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtbProductAbbr;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtbProductName;
        private MetroFramework.Controls.MetroTile btnCloseDialog;
        private MetroFramework.Controls.MetroTextBox txtbProductAmount;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txtbProductPrice;
        private MetroFramework.Controls.MetroTextBox txtbProductUnit;
        private MetroFramework.Controls.MetroTile btnProductSave;
        private MetroFramework.Controls.MetroButton btnProductClear;
        private MetroFramework.Controls.MetroTile btnProductDelete;
        private MetroFramework.Controls.MetroTextBox txtbProductDescription;
        private System.Windows.Forms.ComboBox comboProductGroup;
    }
}
