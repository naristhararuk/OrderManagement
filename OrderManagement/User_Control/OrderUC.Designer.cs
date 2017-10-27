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
            this.label1 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnOrderSave = new MetroFramework.Controls.MetroTile();
            this.DatePicker = new MetroFramework.Controls.MetroDateTime();
            this.ComboOrderCustomer = new System.Windows.Forms.ComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.OrderTab = new MetroFramework.Controls.MetroTabControl();
            this.SundayTab = new MetroFramework.Controls.MetroTabPage();
            this.lblDateSunday = new MetroFramework.Controls.MetroLabel();
            this.SundayToggle = new MetroFramework.Controls.MetroToggle();
            this.MondayTab = new MetroFramework.Controls.MetroTabPage();
            this.pnlMainMondayBody = new MetroFramework.Controls.MetroPanel();
            this.pnlMondayBody = new MetroFramework.Controls.MetroPanel();
            this.lblDateMonday = new MetroFramework.Controls.MetroLabel();
            this.MondayToggle = new MetroFramework.Controls.MetroToggle();
            this.pnlMondayHead = new MetroFramework.Controls.MetroPanel();
            this.TuesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.lblDateTuesday = new MetroFramework.Controls.MetroLabel();
            this.TuesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.WednesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.lblDateWednesday = new MetroFramework.Controls.MetroLabel();
            this.WednesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.ThursdayTab = new MetroFramework.Controls.MetroTabPage();
            this.lblDateThursday = new MetroFramework.Controls.MetroLabel();
            this.ThursdayToggle = new MetroFramework.Controls.MetroToggle();
            this.FridayTab = new MetroFramework.Controls.MetroTabPage();
            this.lblDateFriday = new MetroFramework.Controls.MetroLabel();
            this.FridayToggle = new MetroFramework.Controls.MetroToggle();
            this.SaturdayTab = new MetroFramework.Controls.MetroTabPage();
            this.lblDateSaturday = new MetroFramework.Controls.MetroLabel();
            this.SaturdayToggle = new MetroFramework.Controls.MetroToggle();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.metroPanel1.SuspendLayout();
            this.OrderTab.SuspendLayout();
            this.SundayTab.SuspendLayout();
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
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.btnOrderSave);
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
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(367, 10);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(106, 25);
            this.metroLabel2.TabIndex = 14;
            this.metroLabel2.Text = "เลือกสัปดาห์";
            // 
            // btnOrderSave
            // 
            this.btnOrderSave.ActiveControl = null;
            this.btnOrderSave.BackColor = System.Drawing.Color.Transparent;
            this.btnOrderSave.Location = new System.Drawing.Point(1293, 28);
            this.btnOrderSave.Name = "btnOrderSave";
            this.btnOrderSave.Size = new System.Drawing.Size(55, 53);
            this.btnOrderSave.TabIndex = 13;
            this.btnOrderSave.TileImage = global::OrderManagement.Properties.Resources.save4_48;
            this.btnOrderSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderSave.UseCustomBackColor = true;
            this.btnOrderSave.UseSelectable = true;
            this.btnOrderSave.UseTileImage = true;
            this.btnOrderSave.Click += new System.EventHandler(this.btnOrderSave_Click);
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(367, 38);
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
            this.metroLabel1.Size = new System.Drawing.Size(80, 25);
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
            this.SundayTab.Controls.Add(this.lblDateSunday);
            this.SundayTab.Controls.Add(this.SundayToggle);
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
            // lblDateSunday
            // 
            this.lblDateSunday.AutoSize = true;
            this.lblDateSunday.Location = new System.Drawing.Point(1000, 10);
            this.lblDateSunday.Name = "lblDateSunday";
            this.lblDateSunday.Size = new System.Drawing.Size(83, 19);
            this.lblDateSunday.TabIndex = 20;
            this.lblDateSunday.Text = "metroLabel2";
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
            this.SundayToggle.CheckedChanged += new System.EventHandler(this.DayToggle_CheckedChanged);
            // 
            // MondayTab
            // 
            this.MondayTab.AutoScroll = true;
            this.MondayTab.Controls.Add(this.pnlMainMondayBody);
            this.MondayTab.Controls.Add(this.lblDateMonday);
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
            // pnlMainMondayBody
            // 
            this.pnlMainMondayBody.AutoScroll = true;
            this.pnlMainMondayBody.Controls.Add(this.pnlMondayBody);
            this.pnlMainMondayBody.HorizontalScrollbar = true;
            this.pnlMainMondayBody.HorizontalScrollbarBarColor = true;
            this.pnlMainMondayBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMainMondayBody.HorizontalScrollbarSize = 10;
            this.pnlMainMondayBody.Location = new System.Drawing.Point(9, 83);
            this.pnlMainMondayBody.Name = "pnlMainMondayBody";
            this.pnlMainMondayBody.Size = new System.Drawing.Size(1319, 588);
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
            // lblDateMonday
            // 
            this.lblDateMonday.AutoSize = true;
            this.lblDateMonday.Location = new System.Drawing.Point(1000, 10);
            this.lblDateMonday.Name = "lblDateMonday";
            this.lblDateMonday.Size = new System.Drawing.Size(83, 19);
            this.lblDateMonday.TabIndex = 20;
            this.lblDateMonday.Text = "metroLabel2";
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
            this.MondayToggle.CheckedChanged += new System.EventHandler(this.DayToggle_CheckedChanged);
            // 
            // pnlMondayHead
            // 
            this.pnlMondayHead.HorizontalScrollbarBarColor = true;
            this.pnlMondayHead.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMondayHead.HorizontalScrollbarSize = 10;
            this.pnlMondayHead.Location = new System.Drawing.Point(9, 50);
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
            this.TuesdayTab.Controls.Add(this.lblDateTuesday);
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
            // 
            // lblDateTuesday
            // 
            this.lblDateTuesday.AutoSize = true;
            this.lblDateTuesday.Location = new System.Drawing.Point(1000, 10);
            this.lblDateTuesday.Name = "lblDateTuesday";
            this.lblDateTuesday.Size = new System.Drawing.Size(83, 19);
            this.lblDateTuesday.TabIndex = 20;
            this.lblDateTuesday.Text = "metroLabel2";
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
            this.TuesdayToggle.CheckedChanged += new System.EventHandler(this.DayToggle_CheckedChanged);
            // 
            // WednesdayTab
            // 
            this.WednesdayTab.Controls.Add(this.lblDateWednesday);
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
            // lblDateWednesday
            // 
            this.lblDateWednesday.AutoSize = true;
            this.lblDateWednesday.Location = new System.Drawing.Point(1000, 10);
            this.lblDateWednesday.Name = "lblDateWednesday";
            this.lblDateWednesday.Size = new System.Drawing.Size(83, 19);
            this.lblDateWednesday.TabIndex = 19;
            this.lblDateWednesday.Text = "metroLabel2";
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
            this.WednesdayToggle.CheckedChanged += new System.EventHandler(this.DayToggle_CheckedChanged);
            // 
            // ThursdayTab
            // 
            this.ThursdayTab.Controls.Add(this.lblDateThursday);
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
            // lblDateThursday
            // 
            this.lblDateThursday.AutoSize = true;
            this.lblDateThursday.Location = new System.Drawing.Point(1000, 10);
            this.lblDateThursday.Name = "lblDateThursday";
            this.lblDateThursday.Size = new System.Drawing.Size(83, 19);
            this.lblDateThursday.TabIndex = 20;
            this.lblDateThursday.Text = "metroLabel2";
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
            this.ThursdayToggle.CheckedChanged += new System.EventHandler(this.DayToggle_CheckedChanged);
            // 
            // FridayTab
            // 
            this.FridayTab.Controls.Add(this.lblDateFriday);
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
            // lblDateFriday
            // 
            this.lblDateFriday.AutoSize = true;
            this.lblDateFriday.Location = new System.Drawing.Point(1000, 10);
            this.lblDateFriday.Name = "lblDateFriday";
            this.lblDateFriday.Size = new System.Drawing.Size(83, 19);
            this.lblDateFriday.TabIndex = 20;
            this.lblDateFriday.Text = "metroLabel2";
            this.lblDateFriday.Click += new System.EventHandler(this.metroLabel6_Click);
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
            this.FridayToggle.CheckedChanged += new System.EventHandler(this.DayToggle_CheckedChanged);
            // 
            // SaturdayTab
            // 
            this.SaturdayTab.Controls.Add(this.lblDateSaturday);
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
            // lblDateSaturday
            // 
            this.lblDateSaturday.AutoSize = true;
            this.lblDateSaturday.Location = new System.Drawing.Point(1000, 10);
            this.lblDateSaturday.Name = "lblDateSaturday";
            this.lblDateSaturday.Size = new System.Drawing.Size(83, 19);
            this.lblDateSaturday.TabIndex = 20;
            this.lblDateSaturday.Text = "metroLabel2";
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
            this.SaturdayToggle.CheckedChanged += new System.EventHandler(this.DayToggle_CheckedChanged);
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
        private System.Windows.Forms.ComboBox ComboOrderCustomer;
        private MetroFramework.Controls.MetroPanel pnlMainMondayBody;
        private MetroFramework.Controls.MetroPanel pnlMondayHead;
        private MetroFramework.Controls.MetroPanel pnlMondayBody;
        private MetroFramework.Controls.MetroDateTime DatePicker;
        private MetroFramework.Controls.MetroLabel lblDateWednesday;
        private MetroFramework.Controls.MetroLabel lblDateSunday;
        private MetroFramework.Controls.MetroLabel lblDateMonday;
        private MetroFramework.Controls.MetroLabel lblDateTuesday;
        private MetroFramework.Controls.MetroLabel lblDateThursday;
        private MetroFramework.Controls.MetroLabel lblDateFriday;
        private MetroFramework.Controls.MetroLabel lblDateSaturday;
        private MetroFramework.Controls.MetroTile btnOrderSave;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}
