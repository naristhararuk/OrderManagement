
namespace OrderManagement.User_Control
{
    partial class CustomerManageUC
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
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.btnCustomerSave = new MetroFramework.Controls.MetroTile();
            this.btnCustomerClear = new MetroFramework.Controls.MetroButton();
            this.txtbCustomerZone = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtbCustomerCitizenID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtbCustomerAbbr = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtbCustomerName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnCloseDialog = new MetroFramework.Controls.MetroTile();
            this.txtbCustomerAddress1 = new MetroFramework.Controls.MetroTextBox();
            this.txtbCustomerAddress2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtbCustomerDescription = new MetroFramework.Controls.MetroTextBox();
            this.txtbCustomerPhone = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.chkCustomerShowPrice = new MetroFramework.Controls.MetroCheckBox();
            this.btnCustomerDelete = new MetroFramework.Controls.MetroTile();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel8.Location = new System.Drawing.Point(57, 317);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(76, 25);
            this.metroLabel8.TabIndex = 30;
            this.metroLabel8.Text = "หมายเหตุ";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.btnCustomerDelete);
            this.metroPanel2.Controls.Add(this.chkCustomerShowPrice);
            this.metroPanel2.Controls.Add(this.txtbCustomerPhone);
            this.metroPanel2.Controls.Add(this.metroLabel9);
            this.metroPanel2.Controls.Add(this.txtbCustomerDescription);
            this.metroPanel2.Controls.Add(this.txtbCustomerAddress2);
            this.metroPanel2.Controls.Add(this.metroLabel6);
            this.metroPanel2.Controls.Add(this.txtbCustomerAddress1);
            this.metroPanel2.Controls.Add(this.btnCustomerSave);
            this.metroPanel2.Controls.Add(this.btnCustomerClear);
            this.metroPanel2.Controls.Add(this.metroLabel8);
            this.metroPanel2.Controls.Add(this.txtbCustomerZone);
            this.metroPanel2.Controls.Add(this.metroLabel7);
            this.metroPanel2.Controls.Add(this.txtbCustomerCitizenID);
            this.metroPanel2.Controls.Add(this.metroLabel5);
            this.metroPanel2.Controls.Add(this.txtbCustomerAbbr);
            this.metroPanel2.Controls.Add(this.metroLabel4);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.txtbCustomerName);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(27, 72);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(859, 529);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // btnCustomerSave
            // 
            this.btnCustomerSave.ActiveControl = null;
            this.btnCustomerSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCustomerSave.Location = new System.Drawing.Point(456, 457);
            this.btnCustomerSave.Name = "btnCustomerSave";
            this.btnCustomerSave.Size = new System.Drawing.Size(121, 47);
            this.btnCustomerSave.TabIndex = 34;
            this.btnCustomerSave.Text = "บันทึก";
            this.btnCustomerSave.TileImage = global::OrderManagement.Properties.Resources.save4_48;
            this.btnCustomerSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomerSave.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnCustomerSave.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnCustomerSave.UseCustomBackColor = true;
            this.btnCustomerSave.UseSelectable = true;
            this.btnCustomerSave.UseTileImage = true;
            this.btnCustomerSave.Click += new System.EventHandler(this.btnCustomerSave_Click);
            // 
            // btnCustomerClear
            // 
            this.btnCustomerClear.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnCustomerClear.Location = new System.Drawing.Point(329, 457);
            this.btnCustomerClear.Name = "btnCustomerClear";
            this.btnCustomerClear.Size = new System.Drawing.Size(121, 47);
            this.btnCustomerClear.TabIndex = 33;
            this.btnCustomerClear.Text = "Clear";
            this.btnCustomerClear.UseSelectable = true;
            this.btnCustomerClear.Click += new System.EventHandler(this.btnCustomerClear_Click);
            // 
            // txtbCustomerZone
            // 
            this.txtbCustomerZone.FormattingEnabled = true;
            this.txtbCustomerZone.ItemHeight = 23;
            this.txtbCustomerZone.Location = new System.Drawing.Point(139, 268);
            this.txtbCustomerZone.Name = "txtbCustomerZone";
            this.txtbCustomerZone.Size = new System.Drawing.Size(300, 29);
            this.txtbCustomerZone.TabIndex = 29;
            this.txtbCustomerZone.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(95, 268);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(38, 25);
            this.metroLabel7.TabIndex = 28;
            this.metroLabel7.Text = "เขต";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtbCustomerCitizenID
            // 
            // 
            // 
            // 
            this.txtbCustomerCitizenID.CustomButton.Image = null;
            this.txtbCustomerCitizenID.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.txtbCustomerCitizenID.CustomButton.Name = "";
            this.txtbCustomerCitizenID.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbCustomerCitizenID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbCustomerCitizenID.CustomButton.TabIndex = 1;
            this.txtbCustomerCitizenID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbCustomerCitizenID.CustomButton.UseSelectable = true;
            this.txtbCustomerCitizenID.CustomButton.Visible = false;
            this.txtbCustomerCitizenID.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbCustomerCitizenID.Lines = new string[0];
            this.txtbCustomerCitizenID.Location = new System.Drawing.Point(139, 168);
            this.txtbCustomerCitizenID.MaxLength = 45;
            this.txtbCustomerCitizenID.Name = "txtbCustomerCitizenID";
            this.txtbCustomerCitizenID.PasswordChar = '\0';
            this.txtbCustomerCitizenID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbCustomerCitizenID.SelectedText = "";
            this.txtbCustomerCitizenID.SelectionLength = 0;
            this.txtbCustomerCitizenID.SelectionStart = 0;
            this.txtbCustomerCitizenID.ShortcutsEnabled = true;
            this.txtbCustomerCitizenID.Size = new System.Drawing.Size(300, 29);
            this.txtbCustomerCitizenID.TabIndex = 25;
            this.txtbCustomerCitizenID.UseSelectable = true;
            this.txtbCustomerCitizenID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbCustomerCitizenID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(3, 168);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(131, 25);
            this.metroLabel5.TabIndex = 24;
            this.metroLabel5.Text = "เลขบัตรประชาชน";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtbCustomerAbbr
            // 
            // 
            // 
            // 
            this.txtbCustomerAbbr.CustomButton.Image = null;
            this.txtbCustomerAbbr.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.txtbCustomerAbbr.CustomButton.Name = "";
            this.txtbCustomerAbbr.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbCustomerAbbr.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbCustomerAbbr.CustomButton.TabIndex = 1;
            this.txtbCustomerAbbr.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbCustomerAbbr.CustomButton.UseSelectable = true;
            this.txtbCustomerAbbr.CustomButton.Visible = false;
            this.txtbCustomerAbbr.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbCustomerAbbr.Lines = new string[0];
            this.txtbCustomerAbbr.Location = new System.Drawing.Point(527, 21);
            this.txtbCustomerAbbr.MaxLength = 250;
            this.txtbCustomerAbbr.Name = "txtbCustomerAbbr";
            this.txtbCustomerAbbr.PasswordChar = '\0';
            this.txtbCustomerAbbr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbCustomerAbbr.SelectedText = "";
            this.txtbCustomerAbbr.SelectionLength = 0;
            this.txtbCustomerAbbr.SelectionStart = 0;
            this.txtbCustomerAbbr.ShortcutsEnabled = true;
            this.txtbCustomerAbbr.Size = new System.Drawing.Size(300, 29);
            this.txtbCustomerAbbr.TabIndex = 23;
            this.txtbCustomerAbbr.UseSelectable = true;
            this.txtbCustomerAbbr.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtbCustomerAbbr.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(469, 21);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(52, 25);
            this.metroLabel4.TabIndex = 22;
            this.metroLabel4.Text = "ชื่อย่อ";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(80, 69);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(53, 25);
            this.metroLabel3.TabIndex = 20;
            this.metroLabel3.Text = "ที่อยู่ 1";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(62, 21);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(71, 25);
            this.metroLabel2.TabIndex = 19;
            this.metroLabel2.Text = "ชื่อลูกค้า";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtbCustomerName
            // 
            // 
            // 
            // 
            this.txtbCustomerName.CustomButton.Image = null;
            this.txtbCustomerName.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.txtbCustomerName.CustomButton.Name = "";
            this.txtbCustomerName.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbCustomerName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbCustomerName.CustomButton.TabIndex = 1;
            this.txtbCustomerName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbCustomerName.CustomButton.UseSelectable = true;
            this.txtbCustomerName.CustomButton.Visible = false;
            this.txtbCustomerName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbCustomerName.Lines = new string[0];
            this.txtbCustomerName.Location = new System.Drawing.Point(139, 21);
            this.txtbCustomerName.MaxLength = 250;
            this.txtbCustomerName.Name = "txtbCustomerName";
            this.txtbCustomerName.PasswordChar = '\0';
            this.txtbCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbCustomerName.SelectedText = "";
            this.txtbCustomerName.SelectionLength = 0;
            this.txtbCustomerName.SelectionStart = 0;
            this.txtbCustomerName.ShortcutsEnabled = true;
            this.txtbCustomerName.Size = new System.Drawing.Size(300, 29);
            this.txtbCustomerName.TabIndex = 18;
            this.txtbCustomerName.UseSelectable = true;
            this.txtbCustomerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbCustomerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(27, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(153, 25);
            this.metroLabel1.TabIndex = 47;
            this.metroLabel1.Text = "จัดการข้อมูลลูกค้า";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // btnCloseDialog
            // 
            this.btnCloseDialog.ActiveControl = null;
            this.btnCloseDialog.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseDialog.Location = new System.Drawing.Point(866, 27);
            this.btnCloseDialog.Name = "btnCloseDialog";
            this.btnCloseDialog.Size = new System.Drawing.Size(20, 23);
            this.btnCloseDialog.TabIndex = 46;
            this.btnCloseDialog.TileImage = global::OrderManagement.Properties.Resources.close20;
            this.btnCloseDialog.UseCustomBackColor = true;
            this.btnCloseDialog.UseSelectable = true;
            this.btnCloseDialog.UseTileImage = true;
            this.btnCloseDialog.Click += new System.EventHandler(this.btnCloseDialog_Click);
            // 
            // txtbCustomerAddress1
            // 
            // 
            // 
            // 
            this.txtbCustomerAddress1.CustomButton.Image = null;
            this.txtbCustomerAddress1.CustomButton.Location = new System.Drawing.Point(660, 1);
            this.txtbCustomerAddress1.CustomButton.Name = "";
            this.txtbCustomerAddress1.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbCustomerAddress1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbCustomerAddress1.CustomButton.TabIndex = 1;
            this.txtbCustomerAddress1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbCustomerAddress1.CustomButton.UseSelectable = true;
            this.txtbCustomerAddress1.CustomButton.Visible = false;
            this.txtbCustomerAddress1.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbCustomerAddress1.Lines = new string[0];
            this.txtbCustomerAddress1.Location = new System.Drawing.Point(139, 69);
            this.txtbCustomerAddress1.MaxLength = 45;
            this.txtbCustomerAddress1.Name = "txtbCustomerAddress1";
            this.txtbCustomerAddress1.PasswordChar = '\0';
            this.txtbCustomerAddress1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbCustomerAddress1.SelectedText = "";
            this.txtbCustomerAddress1.SelectionLength = 0;
            this.txtbCustomerAddress1.SelectionStart = 0;
            this.txtbCustomerAddress1.ShortcutsEnabled = true;
            this.txtbCustomerAddress1.Size = new System.Drawing.Size(688, 29);
            this.txtbCustomerAddress1.TabIndex = 35;
            this.txtbCustomerAddress1.UseSelectable = true;
            this.txtbCustomerAddress1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbCustomerAddress1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtbCustomerAddress2
            // 
            // 
            // 
            // 
            this.txtbCustomerAddress2.CustomButton.Image = null;
            this.txtbCustomerAddress2.CustomButton.Location = new System.Drawing.Point(660, 1);
            this.txtbCustomerAddress2.CustomButton.Name = "";
            this.txtbCustomerAddress2.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbCustomerAddress2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbCustomerAddress2.CustomButton.TabIndex = 1;
            this.txtbCustomerAddress2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbCustomerAddress2.CustomButton.UseSelectable = true;
            this.txtbCustomerAddress2.CustomButton.Visible = false;
            this.txtbCustomerAddress2.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbCustomerAddress2.Lines = new string[0];
            this.txtbCustomerAddress2.Location = new System.Drawing.Point(139, 118);
            this.txtbCustomerAddress2.MaxLength = 45;
            this.txtbCustomerAddress2.Name = "txtbCustomerAddress2";
            this.txtbCustomerAddress2.PasswordChar = '\0';
            this.txtbCustomerAddress2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbCustomerAddress2.SelectedText = "";
            this.txtbCustomerAddress2.SelectionLength = 0;
            this.txtbCustomerAddress2.SelectionStart = 0;
            this.txtbCustomerAddress2.ShortcutsEnabled = true;
            this.txtbCustomerAddress2.Size = new System.Drawing.Size(688, 29);
            this.txtbCustomerAddress2.TabIndex = 37;
            this.txtbCustomerAddress2.UseSelectable = true;
            this.txtbCustomerAddress2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbCustomerAddress2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(77, 118);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(56, 25);
            this.metroLabel6.TabIndex = 36;
            this.metroLabel6.Text = "ที่อยู่ 2";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtbCustomerDescription
            // 
            // 
            // 
            // 
            this.txtbCustomerDescription.CustomButton.Image = null;
            this.txtbCustomerDescription.CustomButton.Location = new System.Drawing.Point(660, 1);
            this.txtbCustomerDescription.CustomButton.Name = "";
            this.txtbCustomerDescription.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbCustomerDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbCustomerDescription.CustomButton.TabIndex = 1;
            this.txtbCustomerDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbCustomerDescription.CustomButton.UseSelectable = true;
            this.txtbCustomerDescription.CustomButton.Visible = false;
            this.txtbCustomerDescription.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbCustomerDescription.Lines = new string[0];
            this.txtbCustomerDescription.Location = new System.Drawing.Point(139, 317);
            this.txtbCustomerDescription.MaxLength = 45;
            this.txtbCustomerDescription.Name = "txtbCustomerDescription";
            this.txtbCustomerDescription.PasswordChar = '\0';
            this.txtbCustomerDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbCustomerDescription.SelectedText = "";
            this.txtbCustomerDescription.SelectionLength = 0;
            this.txtbCustomerDescription.SelectionStart = 0;
            this.txtbCustomerDescription.ShortcutsEnabled = true;
            this.txtbCustomerDescription.Size = new System.Drawing.Size(688, 29);
            this.txtbCustomerDescription.TabIndex = 38;
            this.txtbCustomerDescription.UseSelectable = true;
            this.txtbCustomerDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbCustomerDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtbCustomerPhone
            // 
            // 
            // 
            // 
            this.txtbCustomerPhone.CustomButton.Image = null;
            this.txtbCustomerPhone.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.txtbCustomerPhone.CustomButton.Name = "";
            this.txtbCustomerPhone.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtbCustomerPhone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbCustomerPhone.CustomButton.TabIndex = 1;
            this.txtbCustomerPhone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbCustomerPhone.CustomButton.UseSelectable = true;
            this.txtbCustomerPhone.CustomButton.Visible = false;
            this.txtbCustomerPhone.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtbCustomerPhone.Lines = new string[0];
            this.txtbCustomerPhone.Location = new System.Drawing.Point(139, 217);
            this.txtbCustomerPhone.MaxLength = 45;
            this.txtbCustomerPhone.Name = "txtbCustomerPhone";
            this.txtbCustomerPhone.PasswordChar = '\0';
            this.txtbCustomerPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbCustomerPhone.SelectedText = "";
            this.txtbCustomerPhone.SelectionLength = 0;
            this.txtbCustomerPhone.SelectionStart = 0;
            this.txtbCustomerPhone.ShortcutsEnabled = true;
            this.txtbCustomerPhone.Size = new System.Drawing.Size(300, 29);
            this.txtbCustomerPhone.TabIndex = 40;
            this.txtbCustomerPhone.UseSelectable = true;
            this.txtbCustomerPhone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbCustomerPhone.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.Location = new System.Drawing.Point(29, 217);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(104, 25);
            this.metroLabel9.TabIndex = 39;
            this.metroLabel9.Text = "เบอร์โทรศัพท์";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCustomerShowPrice
            // 
            this.chkCustomerShowPrice.AutoSize = true;
            this.chkCustomerShowPrice.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkCustomerShowPrice.Location = new System.Drawing.Point(139, 376);
            this.chkCustomerShowPrice.Name = "chkCustomerShowPrice";
            this.chkCustomerShowPrice.Size = new System.Drawing.Size(137, 25);
            this.chkCustomerShowPrice.TabIndex = 42;
            this.chkCustomerShowPrice.Text = "แสดงราคาสินค้า";
            this.chkCustomerShowPrice.UseSelectable = true;
            // 
            // btnCustomerDelete
            // 
            this.btnCustomerDelete.ActiveControl = null;
            this.btnCustomerDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnCustomerDelete.Location = new System.Drawing.Point(706, 457);
            this.btnCustomerDelete.Name = "btnCustomerDelete";
            this.btnCustomerDelete.Size = new System.Drawing.Size(121, 47);
            this.btnCustomerDelete.TabIndex = 55;
            this.btnCustomerDelete.Text = "ลบข้อมูล";
            this.btnCustomerDelete.TileImage = global::OrderManagement.Properties.Resources.recycleBin48;
            this.btnCustomerDelete.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomerDelete.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnCustomerDelete.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnCustomerDelete.UseCustomBackColor = true;
            this.btnCustomerDelete.UseSelectable = true;
            this.btnCustomerDelete.UseTileImage = true;
            this.btnCustomerDelete.Click += new System.EventHandler(this.btnCustomerDelete_Click);
            // 
            // CustomerManageUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.btnCloseDialog);
            this.Name = "CustomerManageUC";
            this.Size = new System.Drawing.Size(916, 632);
            this.Load += new System.EventHandler(this.CustomerManageUC_Load);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnCloseDialog;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroButton btnCustomerClear;
        private MetroFramework.Controls.MetroComboBox txtbCustomerZone;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtbCustomerCitizenID;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtbCustomerAbbr;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtbCustomerName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile btnCustomerSave;
        private MetroFramework.Controls.MetroTextBox txtbCustomerAddress2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtbCustomerAddress1;
        private MetroFramework.Controls.MetroCheckBox chkCustomerShowPrice;
        private MetroFramework.Controls.MetroTextBox txtbCustomerPhone;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txtbCustomerDescription;
        private MetroFramework.Controls.MetroTile btnCustomerDelete;
    }
}
