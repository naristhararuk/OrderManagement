namespace OrderManagement.User_Control
{
    partial class OrderUC
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
<<<<<<< HEAD
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
=======
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
>>>>>>> bbc41e100339a78d7d77f4b75dbc16077926a5a0
            this.label1 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.DatePicker = new MetroFramework.Controls.MetroDateTime();
            this.ComboOrderCustomer = new System.Windows.Forms.ComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.OrderTab = new MetroFramework.Controls.MetroTabControl();
            this.SundayTab = new MetroFramework.Controls.MetroTabPage();
            this.txtbDateSunday = new MetroFramework.Controls.MetroTextBox();
            this.SundayToggle = new MetroFramework.Controls.MetroToggle();
            this.SundayGrid = new MetroFramework.Controls.MetroGrid();
            this.MondayTab = new MetroFramework.Controls.MetroTabPage();
            this.txtbDateMonday = new MetroFramework.Controls.MetroTextBox();
            this.pnlMainMondayBody = new MetroFramework.Controls.MetroPanel();
            this.pnlMondayBody = new MetroFramework.Controls.MetroPanel();
            this.MondayToggle = new MetroFramework.Controls.MetroToggle();
            this.pnlMondayHead = new MetroFramework.Controls.MetroPanel();
            this.TuesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.txtbDateTuesday = new MetroFramework.Controls.MetroTextBox();
            this.lbltest = new MetroFramework.Controls.MetroLabel();
            this.TuesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.WednesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.txtbDateWednesday = new MetroFramework.Controls.MetroTextBox();
            this.WednesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.ThursdayTab = new MetroFramework.Controls.MetroTabPage();
            this.txtbDateThursday = new MetroFramework.Controls.MetroTextBox();
            this.ThursdayToggle = new MetroFramework.Controls.MetroToggle();
            this.FridayTab = new MetroFramework.Controls.MetroTabPage();
            this.txtbDateFriday = new MetroFramework.Controls.MetroTextBox();
            this.FridayToggle = new MetroFramework.Controls.MetroToggle();
            this.SaturdayTab = new MetroFramework.Controls.MetroTabPage();
            this.txtbDateSaturday = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.SaturdayToggle = new MetroFramework.Controls.MetroToggle();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.metroPanel1.SuspendLayout();
            this.OrderTab.SuspendLayout();
            this.SundayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SundayGrid)).BeginInit();
            this.MondayTab.SuspendLayout();
            this.pnlMainMondayBody.SuspendLayout();
            this.TuesdayTab.SuspendLayout();
            this.WednesdayTab.SuspendLayout();
            this.ThursdayTab.SuspendLayout();
            this.FridayTab.SuspendLayout();
            this.SaturdayTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 44);
            this.label1.TabIndex = 7;
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroPanel1.Controls.Add(this.DatePicker);
            this.metroPanel1.Controls.Add(this.ComboOrderCustomer);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.OrderTab);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1457, 783);
            this.metroPanel1.TabIndex = 8;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(1239, 38);
            this.DatePicker.MinimumSize = new System.Drawing.Size(0, 29);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(200, 29);
            this.DatePicker.TabIndex = 12;
            this.DatePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
            // 
            // ComboOrderCustomer
            // 
            this.ComboOrderCustomer.FormattingEnabled = true;
            this.ComboOrderCustomer.Location = new System.Drawing.Point(20, 38);
            this.ComboOrderCustomer.Name = "ComboOrderCustomer";
            this.ComboOrderCustomer.Size = new System.Drawing.Size(253, 21);
            this.ComboOrderCustomer.TabIndex = 11;
            this.ComboOrderCustomer.SelectedIndexChanged += new System.EventHandler(this.ComboOrderCustomer_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(16, 10);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 25);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "ชื่อลูกค้า";
            // 
            // OrderTab
            // 
            this.OrderTab.Controls.Add(this.SundayTab);
            this.OrderTab.Controls.Add(this.MondayTab);
            this.OrderTab.Controls.Add(this.TuesdayTab);
            this.OrderTab.Controls.Add(this.WednesdayTab);
            this.OrderTab.Controls.Add(this.ThursdayTab);
            this.OrderTab.Controls.Add(this.FridayTab);
            this.OrderTab.Controls.Add(this.SaturdayTab);
            this.OrderTab.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.OrderTab.ItemSize = new System.Drawing.Size(100, 30);
            this.OrderTab.Location = new System.Drawing.Point(16, 87);
            this.OrderTab.Name = "OrderTab";
            this.OrderTab.SelectedIndex = 6;
            this.OrderTab.Size = new System.Drawing.Size(1438, 683);
            this.OrderTab.TabIndex = 8;
            this.OrderTab.UseSelectable = true;
            this.OrderTab.SelectedIndexChanged += new System.EventHandler(this.OrderTab_SelectedIndexChanged);
            // 
            // SundayTab
            // 
            this.SundayTab.Controls.Add(this.txtbDateSunday);
            this.SundayTab.Controls.Add(this.SundayToggle);
            this.SundayTab.Controls.Add(this.SundayGrid);
            this.SundayTab.HorizontalScrollbarBarColor = true;
            this.SundayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SundayTab.HorizontalScrollbarSize = 10;
            this.SundayTab.Location = new System.Drawing.Point(4, 34);
            this.SundayTab.Name = "SundayTab";
            this.SundayTab.Size = new System.Drawing.Size(1430, 645);
            this.SundayTab.TabIndex = 0;
            this.SundayTab.Text = "    Sunday    ";
            this.SundayTab.VerticalScrollbarBarColor = true;
            this.SundayTab.VerticalScrollbarHighlightOnWheel = false;
            this.SundayTab.VerticalScrollbarSize = 10;
            // 
            // txtbDateSunday
            // 
            // 
            // 
            // 
            this.txtbDateSunday.CustomButton.Image = null;
            this.txtbDateSunday.CustomButton.Location = new System.Drawing.Point(334, 1);
            this.txtbDateSunday.CustomButton.Name = "";
            this.txtbDateSunday.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbDateSunday.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbDateSunday.CustomButton.TabIndex = 1;
            this.txtbDateSunday.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbDateSunday.CustomButton.UseSelectable = true;
            this.txtbDateSunday.CustomButton.Visible = false;
            this.txtbDateSunday.Enabled = false;
            this.txtbDateSunday.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtbDateSunday.Lines = new string[] {
        "metroTextBox1"};
            this.txtbDateSunday.Location = new System.Drawing.Point(987, 4);
            this.txtbDateSunday.MaxLength = 32767;
            this.txtbDateSunday.Name = "txtbDateSunday";
            this.txtbDateSunday.PasswordChar = '\0';
            this.txtbDateSunday.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbDateSunday.SelectedText = "";
            this.txtbDateSunday.SelectionLength = 0;
            this.txtbDateSunday.SelectionStart = 0;
            this.txtbDateSunday.ShortcutsEnabled = true;
            this.txtbDateSunday.Size = new System.Drawing.Size(254, 23);
            this.txtbDateSunday.TabIndex = 15;
            this.txtbDateSunday.Text = "metroTextBox1";
            this.txtbDateSunday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbDateSunday.UseSelectable = true;
            this.txtbDateSunday.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbDateSunday.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SundayToggle
            // 
            this.SundayToggle.AutoSize = true;
            this.SundayToggle.Location = new System.Drawing.Point(1248, 12);
            this.SundayToggle.Name = "SundayToggle";
            this.SundayToggle.Size = new System.Drawing.Size(80, 17);
            this.SundayToggle.Style = MetroFramework.MetroColorStyle.White;
            this.SundayToggle.TabIndex = 4;
            this.SundayToggle.Text = "Off";
            this.SundayToggle.UseSelectable = true;
            this.SundayToggle.CheckedChanged += new System.EventHandler(this.SundayToggle_CheckedChanged);
            // 
            // SundayGrid
            // 
            this.SundayGrid.AllowUserToResizeRows = false;
            this.SundayGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SundayGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SundayGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.SundayGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
<<<<<<< HEAD
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.SundayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SundayGrid.DefaultCellStyle = dataGridViewCellStyle14;
=======
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.SundayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SundayGrid.DefaultCellStyle = dataGridViewCellStyle8;
>>>>>>> bbc41e100339a78d7d77f4b75dbc16077926a5a0
            this.SundayGrid.EnableHeadersVisualStyles = false;
            this.SundayGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SundayGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SundayGrid.Location = new System.Drawing.Point(-4, 60);
            this.SundayGrid.Name = "SundayGrid";
            this.SundayGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
<<<<<<< HEAD
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
=======
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
>>>>>>> bbc41e100339a78d7d77f4b75dbc16077926a5a0
            this.SundayGrid.RowHeadersVisible = false;
            this.SundayGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SundayGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SundayGrid.Size = new System.Drawing.Size(1332, 541);
            this.SundayGrid.TabIndex = 3;
            this.SundayGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SundayGrid_CellClick);
            // 
            // MondayTab
            // 
            this.MondayTab.AutoScroll = true;
            this.MondayTab.Controls.Add(this.txtbDateMonday);
            this.MondayTab.Controls.Add(this.pnlMainMondayBody);
            this.MondayTab.Controls.Add(this.MondayToggle);
            this.MondayTab.Controls.Add(this.pnlMondayHead);
            this.MondayTab.HorizontalScrollbar = true;
            this.MondayTab.HorizontalScrollbarBarColor = true;
            this.MondayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.MondayTab.HorizontalScrollbarSize = 10;
            this.MondayTab.Location = new System.Drawing.Point(4, 34);
            this.MondayTab.Name = "MondayTab";
            this.MondayTab.Size = new System.Drawing.Size(1430, 645);
            this.MondayTab.TabIndex = 1;
            this.MondayTab.Text = "    Monday    ";
            this.MondayTab.VerticalScrollbar = true;
            this.MondayTab.VerticalScrollbarBarColor = true;
            this.MondayTab.VerticalScrollbarHighlightOnWheel = false;
            this.MondayTab.VerticalScrollbarSize = 20;
            // 
            // txtbDateMonday
            // 
            // 
            // 
            // 
            this.txtbDateMonday.CustomButton.Image = null;
            this.txtbDateMonday.CustomButton.Location = new System.Drawing.Point(334, 1);
            this.txtbDateMonday.CustomButton.Name = "";
            this.txtbDateMonday.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbDateMonday.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbDateMonday.CustomButton.TabIndex = 1;
            this.txtbDateMonday.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbDateMonday.CustomButton.UseSelectable = true;
            this.txtbDateMonday.CustomButton.Visible = false;
            this.txtbDateMonday.Enabled = false;
            this.txtbDateMonday.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtbDateMonday.Lines = new string[] {
        "metroTextBox1"};
            this.txtbDateMonday.Location = new System.Drawing.Point(987, 4);
            this.txtbDateMonday.MaxLength = 32767;
            this.txtbDateMonday.Name = "txtbDateMonday";
            this.txtbDateMonday.PasswordChar = '\0';
            this.txtbDateMonday.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbDateMonday.SelectedText = "";
            this.txtbDateMonday.SelectionLength = 0;
            this.txtbDateMonday.SelectionStart = 0;
            this.txtbDateMonday.ShortcutsEnabled = true;
            this.txtbDateMonday.Size = new System.Drawing.Size(254, 23);
            this.txtbDateMonday.TabIndex = 14;
            this.txtbDateMonday.Text = "metroTextBox1";
            this.txtbDateMonday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbDateMonday.UseSelectable = true;
            this.txtbDateMonday.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbDateMonday.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pnlMainMondayBody
            // 
            this.pnlMainMondayBody.AutoScroll = true;
            this.pnlMainMondayBody.Controls.Add(this.pnlMondayBody);
            this.pnlMainMondayBody.HorizontalScrollbar = true;
            this.pnlMainMondayBody.HorizontalScrollbarBarColor = true;
            this.pnlMainMondayBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMainMondayBody.HorizontalScrollbarSize = 10;
            this.pnlMainMondayBody.Location = new System.Drawing.Point(8, 66);
            this.pnlMainMondayBody.Name = "pnlMainMondayBody";
            this.pnlMainMondayBody.Size = new System.Drawing.Size(1319, 652);
            this.pnlMainMondayBody.TabIndex = 13;
            this.pnlMainMondayBody.VerticalScrollbar = true;
            this.pnlMainMondayBody.VerticalScrollbarBarColor = true;
            this.pnlMainMondayBody.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMainMondayBody.VerticalScrollbarSize = 10;
            // 
            // pnlMondayBody
            // 
            this.pnlMondayBody.AutoScroll = true;
            this.pnlMondayBody.AutoSize = true;
            this.pnlMondayBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlMondayBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMondayBody.HorizontalScrollbar = true;
            this.pnlMondayBody.HorizontalScrollbarBarColor = true;
            this.pnlMondayBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMondayBody.HorizontalScrollbarSize = 10;
            this.pnlMondayBody.Location = new System.Drawing.Point(0, 0);
            this.pnlMondayBody.Name = "pnlMondayBody";
            this.pnlMondayBody.Size = new System.Drawing.Size(1319, 0);
            this.pnlMondayBody.TabIndex = 2;
            this.pnlMondayBody.UseCustomBackColor = true;
            this.pnlMondayBody.VerticalScrollbar = true;
            this.pnlMondayBody.VerticalScrollbarBarColor = true;
            this.pnlMondayBody.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMondayBody.VerticalScrollbarSize = 10;
            // 
            // MondayToggle
            // 
            this.MondayToggle.AutoSize = true;
            this.MondayToggle.Location = new System.Drawing.Point(1247, 11);
            this.MondayToggle.Name = "MondayToggle";
            this.MondayToggle.Size = new System.Drawing.Size(80, 17);
            this.MondayToggle.Style = MetroFramework.MetroColorStyle.White;
            this.MondayToggle.TabIndex = 3;
            this.MondayToggle.Text = "Off";
            this.MondayToggle.UseSelectable = true;
            // 
            // pnlMondayHead
            // 
            this.pnlMondayHead.HorizontalScrollbarBarColor = true;
            this.pnlMondayHead.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMondayHead.HorizontalScrollbarSize = 10;
            this.pnlMondayHead.Location = new System.Drawing.Point(8, 34);
            this.pnlMondayHead.Name = "pnlMondayHead";
            this.pnlMondayHead.Size = new System.Drawing.Size(1319, 33);
            this.pnlMondayHead.TabIndex = 12;
            this.pnlMondayHead.VerticalScrollbarBarColor = true;
            this.pnlMondayHead.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMondayHead.VerticalScrollbarSize = 10;
            // 
            // TuesdayTab
            // 
            this.TuesdayTab.AutoScroll = true;
            this.TuesdayTab.Controls.Add(this.txtbDateTuesday);
            this.TuesdayTab.Controls.Add(this.lbltest);
            this.TuesdayTab.Controls.Add(this.TuesdayToggle);
            this.TuesdayTab.HorizontalScrollbar = true;
            this.TuesdayTab.HorizontalScrollbarBarColor = true;
            this.TuesdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.TuesdayTab.HorizontalScrollbarSize = 10;
            this.TuesdayTab.Location = new System.Drawing.Point(4, 34);
            this.TuesdayTab.Name = "TuesdayTab";
            this.TuesdayTab.Size = new System.Drawing.Size(1430, 645);
            this.TuesdayTab.TabIndex = 2;
            this.TuesdayTab.Text = "    Tuesday   ";
            this.TuesdayTab.VerticalScrollbar = true;
            this.TuesdayTab.VerticalScrollbarBarColor = true;
            this.TuesdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.TuesdayTab.VerticalScrollbarSize = 40;
            this.TuesdayTab.Click += new System.EventHandler(this.TuesdayTab_Click);
            // 
            // txtbDateTuesday
            // 
            // 
            // 
            // 
            this.txtbDateTuesday.CustomButton.Image = null;
            this.txtbDateTuesday.CustomButton.Location = new System.Drawing.Point(334, 1);
            this.txtbDateTuesday.CustomButton.Name = "";
            this.txtbDateTuesday.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbDateTuesday.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbDateTuesday.CustomButton.TabIndex = 1;
            this.txtbDateTuesday.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbDateTuesday.CustomButton.UseSelectable = true;
            this.txtbDateTuesday.CustomButton.Visible = false;
            this.txtbDateTuesday.Enabled = false;
            this.txtbDateTuesday.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtbDateTuesday.Lines = new string[] {
        "metroTextBox1"};
            this.txtbDateTuesday.Location = new System.Drawing.Point(987, 4);
            this.txtbDateTuesday.MaxLength = 32767;
            this.txtbDateTuesday.Name = "txtbDateTuesday";
            this.txtbDateTuesday.PasswordChar = '\0';
            this.txtbDateTuesday.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbDateTuesday.SelectedText = "";
            this.txtbDateTuesday.SelectionLength = 0;
            this.txtbDateTuesday.SelectionStart = 0;
            this.txtbDateTuesday.ShortcutsEnabled = true;
            this.txtbDateTuesday.Size = new System.Drawing.Size(254, 23);
            this.txtbDateTuesday.TabIndex = 15;
            this.txtbDateTuesday.Text = "metroTextBox1";
            this.txtbDateTuesday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbDateTuesday.UseSelectable = true;
            this.txtbDateTuesday.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbDateTuesday.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbltest
            // 
            this.lbltest.AutoSize = true;
            this.lbltest.Location = new System.Drawing.Point(123, 152);
            this.lbltest.Name = "lbltest";
            this.lbltest.Size = new System.Drawing.Size(83, 19);
            this.lbltest.TabIndex = 5;
            this.lbltest.Text = "metroLabel2";
            // 
            // TuesdayToggle
            // 
            this.TuesdayToggle.AutoSize = true;
            this.TuesdayToggle.Location = new System.Drawing.Point(1248, 12);
            this.TuesdayToggle.Name = "TuesdayToggle";
            this.TuesdayToggle.Size = new System.Drawing.Size(80, 17);
            this.TuesdayToggle.Style = MetroFramework.MetroColorStyle.White;
            this.TuesdayToggle.TabIndex = 4;
            this.TuesdayToggle.Text = "Off";
            this.TuesdayToggle.UseSelectable = true;
            // 
            // WednesdayTab
            // 
            this.WednesdayTab.Controls.Add(this.txtbDateWednesday);
            this.WednesdayTab.Controls.Add(this.WednesdayToggle);
            this.WednesdayTab.HorizontalScrollbarBarColor = true;
            this.WednesdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.WednesdayTab.HorizontalScrollbarSize = 10;
            this.WednesdayTab.Location = new System.Drawing.Point(4, 34);
            this.WednesdayTab.Name = "WednesdayTab";
            this.WednesdayTab.Size = new System.Drawing.Size(1430, 645);
            this.WednesdayTab.TabIndex = 3;
            this.WednesdayTab.Text = "   Wednesday    ";
            this.WednesdayTab.VerticalScrollbarBarColor = true;
            this.WednesdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.WednesdayTab.VerticalScrollbarSize = 10;
            // 
            // txtbDateWednesday
            // 
            // 
            // 
            // 
            this.txtbDateWednesday.CustomButton.Image = null;
            this.txtbDateWednesday.CustomButton.Location = new System.Drawing.Point(334, 1);
            this.txtbDateWednesday.CustomButton.Name = "";
            this.txtbDateWednesday.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbDateWednesday.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbDateWednesday.CustomButton.TabIndex = 1;
            this.txtbDateWednesday.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbDateWednesday.CustomButton.UseSelectable = true;
            this.txtbDateWednesday.CustomButton.Visible = false;
            this.txtbDateWednesday.Enabled = false;
            this.txtbDateWednesday.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtbDateWednesday.Lines = new string[] {
        "metroTextBox1"};
            this.txtbDateWednesday.Location = new System.Drawing.Point(987, 4);
            this.txtbDateWednesday.MaxLength = 32767;
            this.txtbDateWednesday.Name = "txtbDateWednesday";
            this.txtbDateWednesday.PasswordChar = '\0';
            this.txtbDateWednesday.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbDateWednesday.SelectedText = "";
            this.txtbDateWednesday.SelectionLength = 0;
            this.txtbDateWednesday.SelectionStart = 0;
            this.txtbDateWednesday.ShortcutsEnabled = true;
            this.txtbDateWednesday.Size = new System.Drawing.Size(254, 23);
            this.txtbDateWednesday.TabIndex = 16;
            this.txtbDateWednesday.Text = "metroTextBox1";
            this.txtbDateWednesday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbDateWednesday.UseSelectable = true;
            this.txtbDateWednesday.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbDateWednesday.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // WednesdayToggle
            // 
            this.WednesdayToggle.AutoSize = true;
            this.WednesdayToggle.Location = new System.Drawing.Point(1248, 12);
            this.WednesdayToggle.Name = "WednesdayToggle";
            this.WednesdayToggle.Size = new System.Drawing.Size(80, 17);
            this.WednesdayToggle.Style = MetroFramework.MetroColorStyle.White;
            this.WednesdayToggle.TabIndex = 4;
            this.WednesdayToggle.Text = "Off";
            this.WednesdayToggle.UseSelectable = true;
            // 
            // ThursdayTab
            // 
            this.ThursdayTab.Controls.Add(this.txtbDateThursday);
            this.ThursdayTab.Controls.Add(this.ThursdayToggle);
            this.ThursdayTab.HorizontalScrollbarBarColor = true;
            this.ThursdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.ThursdayTab.HorizontalScrollbarSize = 10;
            this.ThursdayTab.Location = new System.Drawing.Point(4, 34);
            this.ThursdayTab.Name = "ThursdayTab";
            this.ThursdayTab.Size = new System.Drawing.Size(1430, 645);
            this.ThursdayTab.TabIndex = 4;
            this.ThursdayTab.Text = "   Thursday   ";
            this.ThursdayTab.VerticalScrollbarBarColor = true;
            this.ThursdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.ThursdayTab.VerticalScrollbarSize = 10;
            // 
            // txtbDateThursday
            // 
            // 
            // 
            // 
            this.txtbDateThursday.CustomButton.Image = null;
            this.txtbDateThursday.CustomButton.Location = new System.Drawing.Point(334, 1);
            this.txtbDateThursday.CustomButton.Name = "";
            this.txtbDateThursday.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbDateThursday.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbDateThursday.CustomButton.TabIndex = 1;
            this.txtbDateThursday.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbDateThursday.CustomButton.UseSelectable = true;
            this.txtbDateThursday.CustomButton.Visible = false;
            this.txtbDateThursday.Enabled = false;
            this.txtbDateThursday.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtbDateThursday.Lines = new string[] {
        "metroTextBox1"};
            this.txtbDateThursday.Location = new System.Drawing.Point(987, 4);
            this.txtbDateThursday.MaxLength = 32767;
            this.txtbDateThursday.Name = "txtbDateThursday";
            this.txtbDateThursday.PasswordChar = '\0';
            this.txtbDateThursday.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbDateThursday.SelectedText = "";
            this.txtbDateThursday.SelectionLength = 0;
            this.txtbDateThursday.SelectionStart = 0;
            this.txtbDateThursday.ShortcutsEnabled = true;
            this.txtbDateThursday.Size = new System.Drawing.Size(254, 23);
            this.txtbDateThursday.TabIndex = 16;
            this.txtbDateThursday.Text = "metroTextBox1";
            this.txtbDateThursday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbDateThursday.UseSelectable = true;
            this.txtbDateThursday.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbDateThursday.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ThursdayToggle
            // 
            this.ThursdayToggle.AutoSize = true;
            this.ThursdayToggle.Location = new System.Drawing.Point(1248, 12);
            this.ThursdayToggle.Name = "ThursdayToggle";
            this.ThursdayToggle.Size = new System.Drawing.Size(80, 17);
            this.ThursdayToggle.Style = MetroFramework.MetroColorStyle.White;
            this.ThursdayToggle.TabIndex = 4;
            this.ThursdayToggle.Text = "Off";
            this.ThursdayToggle.UseSelectable = true;
            // 
            // FridayTab
            // 
            this.FridayTab.Controls.Add(this.txtbDateFriday);
            this.FridayTab.Controls.Add(this.FridayToggle);
            this.FridayTab.HorizontalScrollbarBarColor = true;
            this.FridayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.FridayTab.HorizontalScrollbarSize = 10;
            this.FridayTab.Location = new System.Drawing.Point(4, 34);
            this.FridayTab.Name = "FridayTab";
            this.FridayTab.Size = new System.Drawing.Size(1430, 645);
            this.FridayTab.TabIndex = 5;
            this.FridayTab.Text = "    Friday    ";
            this.FridayTab.VerticalScrollbarBarColor = true;
            this.FridayTab.VerticalScrollbarHighlightOnWheel = false;
            this.FridayTab.VerticalScrollbarSize = 10;
            // 
            // txtbDateFriday
            // 
            // 
            // 
            // 
            this.txtbDateFriday.CustomButton.Image = null;
            this.txtbDateFriday.CustomButton.Location = new System.Drawing.Point(334, 1);
            this.txtbDateFriday.CustomButton.Name = "";
            this.txtbDateFriday.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbDateFriday.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbDateFriday.CustomButton.TabIndex = 1;
            this.txtbDateFriday.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbDateFriday.CustomButton.UseSelectable = true;
            this.txtbDateFriday.CustomButton.Visible = false;
            this.txtbDateFriday.Enabled = false;
            this.txtbDateFriday.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtbDateFriday.Lines = new string[] {
        "metroTextBox1"};
            this.txtbDateFriday.Location = new System.Drawing.Point(987, 4);
            this.txtbDateFriday.MaxLength = 32767;
            this.txtbDateFriday.Name = "txtbDateFriday";
            this.txtbDateFriday.PasswordChar = '\0';
            this.txtbDateFriday.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbDateFriday.SelectedText = "";
            this.txtbDateFriday.SelectionLength = 0;
            this.txtbDateFriday.SelectionStart = 0;
            this.txtbDateFriday.ShortcutsEnabled = true;
            this.txtbDateFriday.Size = new System.Drawing.Size(254, 23);
            this.txtbDateFriday.TabIndex = 16;
            this.txtbDateFriday.Text = "metroTextBox1";
            this.txtbDateFriday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbDateFriday.UseSelectable = true;
            this.txtbDateFriday.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbDateFriday.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // FridayToggle
            // 
            this.FridayToggle.AutoSize = true;
            this.FridayToggle.Location = new System.Drawing.Point(1248, 12);
            this.FridayToggle.Name = "FridayToggle";
            this.FridayToggle.Size = new System.Drawing.Size(80, 17);
            this.FridayToggle.Style = MetroFramework.MetroColorStyle.White;
            this.FridayToggle.TabIndex = 4;
            this.FridayToggle.Text = "Off";
            this.FridayToggle.UseSelectable = true;
            // 
            // SaturdayTab
            // 
            this.SaturdayTab.Controls.Add(this.txtbDateSaturday);
            this.SaturdayTab.Controls.Add(this.metroPanel3);
            this.SaturdayTab.Controls.Add(this.metroPanel2);
            this.SaturdayTab.Controls.Add(this.SaturdayToggle);
            this.SaturdayTab.HorizontalScrollbarBarColor = true;
            this.SaturdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SaturdayTab.HorizontalScrollbarSize = 10;
            this.SaturdayTab.Location = new System.Drawing.Point(4, 34);
            this.SaturdayTab.Name = "SaturdayTab";
            this.SaturdayTab.Size = new System.Drawing.Size(1430, 645);
            this.SaturdayTab.TabIndex = 6;
            this.SaturdayTab.Text = "   Saturday  ";
            this.SaturdayTab.VerticalScrollbarBarColor = true;
            this.SaturdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.SaturdayTab.VerticalScrollbarSize = 10;
            // 
            // txtbDateSaturday
            // 
            // 
            // 
            // 
            this.txtbDateSaturday.CustomButton.Image = null;
            this.txtbDateSaturday.CustomButton.Location = new System.Drawing.Point(334, 1);
            this.txtbDateSaturday.CustomButton.Name = "";
            this.txtbDateSaturday.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbDateSaturday.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbDateSaturday.CustomButton.TabIndex = 1;
            this.txtbDateSaturday.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbDateSaturday.CustomButton.UseSelectable = true;
            this.txtbDateSaturday.CustomButton.Visible = false;
            this.txtbDateSaturday.Enabled = false;
            this.txtbDateSaturday.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtbDateSaturday.Lines = new string[] {
        "metroTextBox1"};
            this.txtbDateSaturday.Location = new System.Drawing.Point(987, 4);
            this.txtbDateSaturday.MaxLength = 32767;
            this.txtbDateSaturday.Name = "txtbDateSaturday";
            this.txtbDateSaturday.PasswordChar = '\0';
            this.txtbDateSaturday.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbDateSaturday.SelectedText = "";
            this.txtbDateSaturday.SelectionLength = 0;
            this.txtbDateSaturday.SelectionStart = 0;
            this.txtbDateSaturday.ShortcutsEnabled = true;
            this.txtbDateSaturday.Size = new System.Drawing.Size(254, 23);
            this.txtbDateSaturday.TabIndex = 16;
            this.txtbDateSaturday.Text = "metroTextBox1";
            this.txtbDateSaturday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbDateSaturday.UseSelectable = true;
            this.txtbDateSaturday.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbDateSaturday.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel3
            // 
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(8, 66);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(1319, 652);
            this.metroPanel3.TabIndex = 6;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(8, 34);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1319, 33);
            this.metroPanel2.TabIndex = 5;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // SaturdayToggle
            // 
            this.SaturdayToggle.AutoSize = true;
            this.SaturdayToggle.Location = new System.Drawing.Point(1248, 12);
            this.SaturdayToggle.Name = "SaturdayToggle";
            this.SaturdayToggle.Size = new System.Drawing.Size(80, 17);
            this.SaturdayToggle.Style = MetroFramework.MetroColorStyle.White;
            this.SaturdayToggle.TabIndex = 4;
            this.SaturdayToggle.Text = "Off";
            this.SaturdayToggle.UseSelectable = true;
            // 
            // OrderUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel1);
            this.Name = "OrderUC";
            this.Size = new System.Drawing.Size(1460, 792);
            this.Load += new System.EventHandler(this.OrderUC_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.OrderTab.ResumeLayout(false);
            this.SundayTab.ResumeLayout(false);
            this.SundayTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SundayGrid)).EndInit();
            this.MondayTab.ResumeLayout(false);
            this.MondayTab.PerformLayout();
            this.pnlMainMondayBody.ResumeLayout(false);
            this.pnlMainMondayBody.PerformLayout();
            this.TuesdayTab.ResumeLayout(false);
            this.TuesdayTab.PerformLayout();
            this.WednesdayTab.ResumeLayout(false);
            this.WednesdayTab.PerformLayout();
            this.ThursdayTab.ResumeLayout(false);
            this.ThursdayTab.PerformLayout();
            this.FridayTab.ResumeLayout(false);
            this.FridayTab.PerformLayout();
            this.SaturdayTab.ResumeLayout(false);
            this.SaturdayTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl OrderTab;
        private MetroFramework.Controls.MetroTabPage SundayTab;
        private MetroFramework.Controls.MetroTabPage MondayTab;
        private MetroFramework.Controls.MetroToggle MondayToggle;
        private MetroFramework.Controls.MetroTabPage TuesdayTab;
        private MetroFramework.Controls.MetroTabPage WednesdayTab;
        private MetroFramework.Controls.MetroTabPage ThursdayTab;
        private MetroFramework.Controls.MetroTabPage FridayTab;
        private MetroFramework.Controls.MetroTabPage SaturdayTab;
        private MetroFramework.Controls.MetroToggle SundayToggle;
        private MetroFramework.Controls.MetroToggle TuesdayToggle;
        private MetroFramework.Controls.MetroToggle WednesdayToggle;
        private MetroFramework.Controls.MetroToggle ThursdayToggle;
        private MetroFramework.Controls.MetroToggle FridayToggle;
        private MetroFramework.Controls.MetroToggle SaturdayToggle;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private MetroFramework.Controls.MetroGrid SundayGrid;
        private System.Windows.Forms.ComboBox ComboOrderCustomer;
        private MetroFramework.Controls.MetroPanel pnlMainMondayBody;
        private MetroFramework.Controls.MetroPanel pnlMondayHead;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel pnlMondayBody;
        private MetroFramework.Controls.MetroLabel lbltest;
        private MetroFramework.Controls.MetroDateTime DatePicker;
        private MetroFramework.Controls.MetroTextBox txtbDateMonday;
        private MetroFramework.Controls.MetroTextBox txtbDateSunday;
        private MetroFramework.Controls.MetroTextBox txtbDateTuesday;
        private MetroFramework.Controls.MetroTextBox txtbDateWednesday;
        private MetroFramework.Controls.MetroTextBox txtbDateThursday;
        private MetroFramework.Controls.MetroTextBox txtbDateFriday;
        private MetroFramework.Controls.MetroTextBox txtbDateSaturday;
    }
}
