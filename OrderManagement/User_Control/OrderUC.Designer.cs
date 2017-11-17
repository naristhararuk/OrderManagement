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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.OrderTab = new MetroFramework.Controls.MetroTabControl();
            this.SundayTab = new MetroFramework.Controls.MetroTabPage();
            this.pnlMainSundayBody = new MetroFramework.Controls.MetroPanel();
            this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
            this.pnlSundayHead = new MetroFramework.Controls.MetroPanel();
            this.lblDateSunday = new MetroFramework.Controls.MetroLabel();
            this.SundayToggle = new MetroFramework.Controls.MetroToggle();
            this.MondayTab = new MetroFramework.Controls.MetroTabPage();
            this.pnlMainMondayBody = new MetroFramework.Controls.MetroPanel();
            this.pnlMondayBody = new MetroFramework.Controls.MetroPanel();
            this.lblDateMonday = new MetroFramework.Controls.MetroLabel();
            this.MondayToggle = new MetroFramework.Controls.MetroToggle();
            this.pnlMondayHead = new MetroFramework.Controls.MetroPanel();
            this.TuesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.pnlMainTuesdayBody = new MetroFramework.Controls.MetroPanel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.pnlTuesdayHead = new MetroFramework.Controls.MetroPanel();
            this.lblDateTuesday = new MetroFramework.Controls.MetroLabel();
            this.TuesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.WednesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.pnlMainWednesdayBody = new MetroFramework.Controls.MetroPanel();
            this.metroPanel9 = new MetroFramework.Controls.MetroPanel();
            this.pnlWednesdayHead = new MetroFramework.Controls.MetroPanel();
            this.lblDateWednesday = new MetroFramework.Controls.MetroLabel();
            this.WednesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.ThursdayTab = new MetroFramework.Controls.MetroTabPage();
            this.pnlMainThursdayBody = new MetroFramework.Controls.MetroPanel();
            this.metroPanel12 = new MetroFramework.Controls.MetroPanel();
            this.pnlThursdayHead = new MetroFramework.Controls.MetroPanel();
            this.lblDateThursday = new MetroFramework.Controls.MetroLabel();
            this.ThursdayToggle = new MetroFramework.Controls.MetroToggle();
            this.FridayTab = new MetroFramework.Controls.MetroTabPage();
            this.pnlMainFridayBody = new MetroFramework.Controls.MetroPanel();
            this.metroPanel15 = new MetroFramework.Controls.MetroPanel();
            this.pnlFridayHead = new MetroFramework.Controls.MetroPanel();
            this.lblDateFriday = new MetroFramework.Controls.MetroLabel();
            this.FridayToggle = new MetroFramework.Controls.MetroToggle();
            this.SaturdayTab = new MetroFramework.Controls.MetroTabPage();
            this.pnlMainSaturdayBody = new MetroFramework.Controls.MetroPanel();
            this.metroPanel18 = new MetroFramework.Controls.MetroPanel();
            this.pnlSaturdayHead = new MetroFramework.Controls.MetroPanel();
            this.lblDateSaturday = new MetroFramework.Controls.MetroLabel();
            this.SaturdayToggle = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ComboOrderCustomer = new System.Windows.Forms.ComboBox();
            this.DatePicker = new MetroFramework.Controls.MetroDateTime();
            this.btnOrderSave = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnOrderCalculate = new MetroFramework.Controls.MetroTile();
            this.pnl = new MetroFramework.Controls.MetroPanel();
            this.PnlEditOrder = new MetroFramework.Controls.MetroPanel();
            this.btnEditOrderThursday = new MetroFramework.Controls.MetroTile();
            this.btnEditOrderSunday = new MetroFramework.Controls.MetroTile();
            this.OrderTab.SuspendLayout();
            this.SundayTab.SuspendLayout();
            this.pnlMainSundayBody.SuspendLayout();
            this.MondayTab.SuspendLayout();
            this.pnlMainMondayBody.SuspendLayout();
            this.TuesdayTab.SuspendLayout();
            this.pnlMainTuesdayBody.SuspendLayout();
            this.WednesdayTab.SuspendLayout();
            this.pnlMainWednesdayBody.SuspendLayout();
            this.ThursdayTab.SuspendLayout();
            this.pnlMainThursdayBody.SuspendLayout();
            this.FridayTab.SuspendLayout();
            this.pnlMainFridayBody.SuspendLayout();
            this.SaturdayTab.SuspendLayout();
            this.pnlMainSaturdayBody.SuspendLayout();
            this.pnl.SuspendLayout();
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
            this.OrderTab.SelectedIndex = 0;
            this.OrderTab.Size = new System.Drawing.Size(1420, 683);
            this.OrderTab.TabIndex = 8;
            this.OrderTab.UseSelectable = true;
            this.OrderTab.SelectedIndexChanged += new System.EventHandler(this.OrderTab_SelectedIndexChanged);
            // 
            // SundayTab
            // 
            this.SundayTab.AutoScroll = true;
            this.SundayTab.Controls.Add(this.btnEditOrderSunday);
            this.SundayTab.Controls.Add(this.pnlMainSundayBody);
            this.SundayTab.Controls.Add(this.pnlSundayHead);
            this.SundayTab.Controls.Add(this.lblDateSunday);
            this.SundayTab.Controls.Add(this.SundayToggle);
            this.SundayTab.HorizontalScrollbar = true;
            this.SundayTab.HorizontalScrollbarBarColor = true;
            this.SundayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SundayTab.HorizontalScrollbarSize = 10;
            this.SundayTab.Location = new System.Drawing.Point(4, 34);
            this.SundayTab.Name = "SundayTab";
            this.SundayTab.Size = new System.Drawing.Size(1412, 645);
            this.SundayTab.TabIndex = 0;
            this.SundayTab.Text = "    Sunday    ";
            this.SundayTab.VerticalScrollbar = true;
            this.SundayTab.VerticalScrollbarBarColor = true;
            this.SundayTab.VerticalScrollbarHighlightOnWheel = false;
            this.SundayTab.VerticalScrollbarSize = 20;
            // 
            // pnlMainSundayBody
            // 
            this.pnlMainSundayBody.AutoScroll = true;
            this.pnlMainSundayBody.Controls.Add(this.metroPanel6);
            this.pnlMainSundayBody.HorizontalScrollbar = true;
            this.pnlMainSundayBody.HorizontalScrollbarBarColor = true;
            this.pnlMainSundayBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMainSundayBody.HorizontalScrollbarSize = 10;
            this.pnlMainSundayBody.Location = new System.Drawing.Point(9, 83);
            this.pnlMainSundayBody.Name = "pnlMainSundayBody";
            this.pnlMainSundayBody.Size = new System.Drawing.Size(1319, 1988);
            this.pnlMainSundayBody.TabIndex = 22;
            this.pnlMainSundayBody.VerticalScrollbar = true;
            this.pnlMainSundayBody.VerticalScrollbarBarColor = true;
            this.pnlMainSundayBody.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMainSundayBody.VerticalScrollbarSize = 10;
            // 
            // metroPanel6
            // 
            this.metroPanel6.AutoScroll = true;
            this.metroPanel6.AutoSize = true;
            this.metroPanel6.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel6.HorizontalScrollbar = true;
            this.metroPanel6.HorizontalScrollbarBarColor = true;
            this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel6.HorizontalScrollbarSize = 10;
            this.metroPanel6.Location = new System.Drawing.Point(0, 0);
            this.metroPanel6.Name = "metroPanel6";
            this.metroPanel6.Size = new System.Drawing.Size(1319, 0);
            this.metroPanel6.TabIndex = 2;
            this.metroPanel6.UseCustomBackColor = true;
            this.metroPanel6.VerticalScrollbar = true;
            this.metroPanel6.VerticalScrollbarBarColor = true;
            this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel6.VerticalScrollbarSize = 10;
            // 
            // pnlSundayHead
            // 
            this.pnlSundayHead.HorizontalScrollbarBarColor = true;
            this.pnlSundayHead.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlSundayHead.HorizontalScrollbarSize = 10;
            this.pnlSundayHead.Location = new System.Drawing.Point(9, 50);
            this.pnlSundayHead.Name = "pnlSundayHead";
            this.pnlSundayHead.Size = new System.Drawing.Size(1319, 33);
            this.pnlSundayHead.TabIndex = 21;
            this.pnlSundayHead.VerticalScrollbarBarColor = true;
            this.pnlSundayHead.VerticalScrollbarHighlightOnWheel = false;
            this.pnlSundayHead.VerticalScrollbarSize = 10;
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
            this.MondayTab.Size = new System.Drawing.Size(1412, 645);
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
            this.pnlMainMondayBody.Size = new System.Drawing.Size(1319, 1988);
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
            this.TuesdayTab.Controls.Add(this.pnlMainTuesdayBody);
            this.TuesdayTab.Controls.Add(this.pnlTuesdayHead);
            this.TuesdayTab.Controls.Add(this.lblDateTuesday);
            this.TuesdayTab.Controls.Add(this.TuesdayToggle);
            this.TuesdayTab.HorizontalScrollbar = true;
            this.TuesdayTab.HorizontalScrollbarBarColor = true;
            this.TuesdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.TuesdayTab.HorizontalScrollbarSize = 10;
            this.TuesdayTab.Location = new System.Drawing.Point(4, 34);
            this.TuesdayTab.Name = "TuesdayTab";
            this.TuesdayTab.Size = new System.Drawing.Size(1412, 645);
            this.TuesdayTab.TabIndex = 2;
            this.TuesdayTab.Text = "    Tuesday   ";
            this.TuesdayTab.VerticalScrollbar = true;
            this.TuesdayTab.VerticalScrollbarBarColor = true;
            this.TuesdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.TuesdayTab.VerticalScrollbarSize = 20;
            // 
            // pnlMainTuesdayBody
            // 
            this.pnlMainTuesdayBody.AutoScroll = true;
            this.pnlMainTuesdayBody.Controls.Add(this.metroPanel3);
            this.pnlMainTuesdayBody.HorizontalScrollbar = true;
            this.pnlMainTuesdayBody.HorizontalScrollbarBarColor = true;
            this.pnlMainTuesdayBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMainTuesdayBody.HorizontalScrollbarSize = 10;
            this.pnlMainTuesdayBody.Location = new System.Drawing.Point(9, 83);
            this.pnlMainTuesdayBody.Name = "pnlMainTuesdayBody";
            this.pnlMainTuesdayBody.Size = new System.Drawing.Size(1319, 1988);
            this.pnlMainTuesdayBody.TabIndex = 22;
            this.pnlMainTuesdayBody.VerticalScrollbar = true;
            this.pnlMainTuesdayBody.VerticalScrollbarBarColor = true;
            this.pnlMainTuesdayBody.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMainTuesdayBody.VerticalScrollbarSize = 10;
            // 
            // metroPanel3
            // 
            this.metroPanel3.AutoScroll = true;
            this.metroPanel3.AutoSize = true;
            this.metroPanel3.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel3.HorizontalScrollbar = true;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(1319, 0);
            this.metroPanel3.TabIndex = 2;
            this.metroPanel3.UseCustomBackColor = true;
            this.metroPanel3.VerticalScrollbar = true;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // pnlTuesdayHead
            // 
            this.pnlTuesdayHead.HorizontalScrollbarBarColor = true;
            this.pnlTuesdayHead.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlTuesdayHead.HorizontalScrollbarSize = 10;
            this.pnlTuesdayHead.Location = new System.Drawing.Point(9, 50);
            this.pnlTuesdayHead.Name = "pnlTuesdayHead";
            this.pnlTuesdayHead.Size = new System.Drawing.Size(1319, 33);
            this.pnlTuesdayHead.TabIndex = 21;
            this.pnlTuesdayHead.VerticalScrollbarBarColor = true;
            this.pnlTuesdayHead.VerticalScrollbarHighlightOnWheel = false;
            this.pnlTuesdayHead.VerticalScrollbarSize = 10;
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
            this.WednesdayTab.AutoScroll = true;
            this.WednesdayTab.Controls.Add(this.pnlMainWednesdayBody);
            this.WednesdayTab.Controls.Add(this.pnlWednesdayHead);
            this.WednesdayTab.Controls.Add(this.lblDateWednesday);
            this.WednesdayTab.Controls.Add(this.WednesdayToggle);
            this.WednesdayTab.HorizontalScrollbar = true;
            this.WednesdayTab.HorizontalScrollbarBarColor = true;
            this.WednesdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.WednesdayTab.HorizontalScrollbarSize = 10;
            this.WednesdayTab.Location = new System.Drawing.Point(4, 34);
            this.WednesdayTab.Name = "WednesdayTab";
            this.WednesdayTab.Size = new System.Drawing.Size(1412, 645);
            this.WednesdayTab.TabIndex = 3;
            this.WednesdayTab.Text = "   Wednesday    ";
            this.WednesdayTab.VerticalScrollbar = true;
            this.WednesdayTab.VerticalScrollbarBarColor = true;
            this.WednesdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.WednesdayTab.VerticalScrollbarSize = 20;
            // 
            // pnlMainWednesdayBody
            // 
            this.pnlMainWednesdayBody.AutoScroll = true;
            this.pnlMainWednesdayBody.Controls.Add(this.metroPanel9);
            this.pnlMainWednesdayBody.HorizontalScrollbar = true;
            this.pnlMainWednesdayBody.HorizontalScrollbarBarColor = true;
            this.pnlMainWednesdayBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMainWednesdayBody.HorizontalScrollbarSize = 10;
            this.pnlMainWednesdayBody.Location = new System.Drawing.Point(9, 83);
            this.pnlMainWednesdayBody.Name = "pnlMainWednesdayBody";
            this.pnlMainWednesdayBody.Size = new System.Drawing.Size(1319, 1988);
            this.pnlMainWednesdayBody.TabIndex = 21;
            this.pnlMainWednesdayBody.VerticalScrollbar = true;
            this.pnlMainWednesdayBody.VerticalScrollbarBarColor = true;
            this.pnlMainWednesdayBody.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMainWednesdayBody.VerticalScrollbarSize = 10;
            // 
            // metroPanel9
            // 
            this.metroPanel9.AutoScroll = true;
            this.metroPanel9.AutoSize = true;
            this.metroPanel9.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel9.HorizontalScrollbar = true;
            this.metroPanel9.HorizontalScrollbarBarColor = true;
            this.metroPanel9.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel9.HorizontalScrollbarSize = 10;
            this.metroPanel9.Location = new System.Drawing.Point(0, 0);
            this.metroPanel9.Name = "metroPanel9";
            this.metroPanel9.Size = new System.Drawing.Size(1319, 0);
            this.metroPanel9.TabIndex = 2;
            this.metroPanel9.UseCustomBackColor = true;
            this.metroPanel9.VerticalScrollbar = true;
            this.metroPanel9.VerticalScrollbarBarColor = true;
            this.metroPanel9.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel9.VerticalScrollbarSize = 10;
            // 
            // pnlWednesdayHead
            // 
            this.pnlWednesdayHead.HorizontalScrollbarBarColor = true;
            this.pnlWednesdayHead.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlWednesdayHead.HorizontalScrollbarSize = 10;
            this.pnlWednesdayHead.Location = new System.Drawing.Point(9, 50);
            this.pnlWednesdayHead.Name = "pnlWednesdayHead";
            this.pnlWednesdayHead.Size = new System.Drawing.Size(1319, 33);
            this.pnlWednesdayHead.TabIndex = 20;
            this.pnlWednesdayHead.VerticalScrollbarBarColor = true;
            this.pnlWednesdayHead.VerticalScrollbarHighlightOnWheel = false;
            this.pnlWednesdayHead.VerticalScrollbarSize = 10;
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
            this.ThursdayTab.AutoScroll = true;
            this.ThursdayTab.Controls.Add(this.btnEditOrderThursday);
            this.ThursdayTab.Controls.Add(this.pnlMainThursdayBody);
            this.ThursdayTab.Controls.Add(this.pnlThursdayHead);
            this.ThursdayTab.Controls.Add(this.lblDateThursday);
            this.ThursdayTab.Controls.Add(this.ThursdayToggle);
            this.ThursdayTab.HorizontalScrollbar = true;
            this.ThursdayTab.HorizontalScrollbarBarColor = true;
            this.ThursdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.ThursdayTab.HorizontalScrollbarSize = 10;
            this.ThursdayTab.Location = new System.Drawing.Point(4, 34);
            this.ThursdayTab.Name = "ThursdayTab";
            this.ThursdayTab.Size = new System.Drawing.Size(1412, 645);
            this.ThursdayTab.TabIndex = 4;
            this.ThursdayTab.Text = "   Thursday   ";
            this.ThursdayTab.VerticalScrollbar = true;
            this.ThursdayTab.VerticalScrollbarBarColor = true;
            this.ThursdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.ThursdayTab.VerticalScrollbarSize = 20;
            // 
            // pnlMainThursdayBody
            // 
            this.pnlMainThursdayBody.AutoScroll = true;
            this.pnlMainThursdayBody.Controls.Add(this.metroPanel12);
            this.pnlMainThursdayBody.HorizontalScrollbar = true;
            this.pnlMainThursdayBody.HorizontalScrollbarBarColor = true;
            this.pnlMainThursdayBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMainThursdayBody.HorizontalScrollbarSize = 10;
            this.pnlMainThursdayBody.Location = new System.Drawing.Point(9, 83);
            this.pnlMainThursdayBody.Name = "pnlMainThursdayBody";
            this.pnlMainThursdayBody.Size = new System.Drawing.Size(1319, 1988);
            this.pnlMainThursdayBody.TabIndex = 22;
            this.pnlMainThursdayBody.VerticalScrollbar = true;
            this.pnlMainThursdayBody.VerticalScrollbarBarColor = true;
            this.pnlMainThursdayBody.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMainThursdayBody.VerticalScrollbarSize = 10;
            // 
            // metroPanel12
            // 
            this.metroPanel12.AutoScroll = true;
            this.metroPanel12.AutoSize = true;
            this.metroPanel12.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel12.HorizontalScrollbar = true;
            this.metroPanel12.HorizontalScrollbarBarColor = true;
            this.metroPanel12.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel12.HorizontalScrollbarSize = 10;
            this.metroPanel12.Location = new System.Drawing.Point(0, 0);
            this.metroPanel12.Name = "metroPanel12";
            this.metroPanel12.Size = new System.Drawing.Size(1319, 0);
            this.metroPanel12.TabIndex = 2;
            this.metroPanel12.UseCustomBackColor = true;
            this.metroPanel12.VerticalScrollbar = true;
            this.metroPanel12.VerticalScrollbarBarColor = true;
            this.metroPanel12.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel12.VerticalScrollbarSize = 10;
            // 
            // pnlThursdayHead
            // 
            this.pnlThursdayHead.HorizontalScrollbarBarColor = true;
            this.pnlThursdayHead.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlThursdayHead.HorizontalScrollbarSize = 10;
            this.pnlThursdayHead.Location = new System.Drawing.Point(9, 50);
            this.pnlThursdayHead.Name = "pnlThursdayHead";
            this.pnlThursdayHead.Size = new System.Drawing.Size(1319, 33);
            this.pnlThursdayHead.TabIndex = 21;
            this.pnlThursdayHead.VerticalScrollbarBarColor = true;
            this.pnlThursdayHead.VerticalScrollbarHighlightOnWheel = false;
            this.pnlThursdayHead.VerticalScrollbarSize = 10;
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
            this.FridayTab.AutoScroll = true;
            this.FridayTab.Controls.Add(this.pnlMainFridayBody);
            this.FridayTab.Controls.Add(this.pnlFridayHead);
            this.FridayTab.Controls.Add(this.lblDateFriday);
            this.FridayTab.Controls.Add(this.FridayToggle);
            this.FridayTab.HorizontalScrollbar = true;
            this.FridayTab.HorizontalScrollbarBarColor = true;
            this.FridayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.FridayTab.HorizontalScrollbarSize = 10;
            this.FridayTab.Location = new System.Drawing.Point(4, 34);
            this.FridayTab.Name = "FridayTab";
            this.FridayTab.Size = new System.Drawing.Size(1412, 645);
            this.FridayTab.TabIndex = 5;
            this.FridayTab.Text = "    Friday    ";
            this.FridayTab.VerticalScrollbar = true;
            this.FridayTab.VerticalScrollbarBarColor = true;
            this.FridayTab.VerticalScrollbarHighlightOnWheel = false;
            this.FridayTab.VerticalScrollbarSize = 20;
            // 
            // pnlMainFridayBody
            // 
            this.pnlMainFridayBody.AutoScroll = true;
            this.pnlMainFridayBody.Controls.Add(this.metroPanel15);
            this.pnlMainFridayBody.HorizontalScrollbar = true;
            this.pnlMainFridayBody.HorizontalScrollbarBarColor = true;
            this.pnlMainFridayBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMainFridayBody.HorizontalScrollbarSize = 10;
            this.pnlMainFridayBody.Location = new System.Drawing.Point(9, 83);
            this.pnlMainFridayBody.Name = "pnlMainFridayBody";
            this.pnlMainFridayBody.Size = new System.Drawing.Size(1319, 1988);
            this.pnlMainFridayBody.TabIndex = 22;
            this.pnlMainFridayBody.VerticalScrollbar = true;
            this.pnlMainFridayBody.VerticalScrollbarBarColor = true;
            this.pnlMainFridayBody.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMainFridayBody.VerticalScrollbarSize = 10;
            // 
            // metroPanel15
            // 
            this.metroPanel15.AutoScroll = true;
            this.metroPanel15.AutoSize = true;
            this.metroPanel15.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel15.HorizontalScrollbar = true;
            this.metroPanel15.HorizontalScrollbarBarColor = true;
            this.metroPanel15.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel15.HorizontalScrollbarSize = 10;
            this.metroPanel15.Location = new System.Drawing.Point(0, 0);
            this.metroPanel15.Name = "metroPanel15";
            this.metroPanel15.Size = new System.Drawing.Size(1319, 0);
            this.metroPanel15.TabIndex = 2;
            this.metroPanel15.UseCustomBackColor = true;
            this.metroPanel15.VerticalScrollbar = true;
            this.metroPanel15.VerticalScrollbarBarColor = true;
            this.metroPanel15.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel15.VerticalScrollbarSize = 10;
            // 
            // pnlFridayHead
            // 
            this.pnlFridayHead.HorizontalScrollbarBarColor = true;
            this.pnlFridayHead.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlFridayHead.HorizontalScrollbarSize = 10;
            this.pnlFridayHead.Location = new System.Drawing.Point(9, 50);
            this.pnlFridayHead.Name = "pnlFridayHead";
            this.pnlFridayHead.Size = new System.Drawing.Size(1319, 33);
            this.pnlFridayHead.TabIndex = 21;
            this.pnlFridayHead.VerticalScrollbarBarColor = true;
            this.pnlFridayHead.VerticalScrollbarHighlightOnWheel = false;
            this.pnlFridayHead.VerticalScrollbarSize = 10;
            // 
            // lblDateFriday
            // 
            this.lblDateFriday.AutoSize = true;
            this.lblDateFriday.Location = new System.Drawing.Point(1000, 10);
            this.lblDateFriday.Name = "lblDateFriday";
            this.lblDateFriday.Size = new System.Drawing.Size(83, 19);
            this.lblDateFriday.TabIndex = 20;
            this.lblDateFriday.Text = "metroLabel2";
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
            this.SaturdayTab.AutoScroll = true;
            this.SaturdayTab.Controls.Add(this.pnlMainSaturdayBody);
            this.SaturdayTab.Controls.Add(this.pnlSaturdayHead);
            this.SaturdayTab.Controls.Add(this.lblDateSaturday);
            this.SaturdayTab.Controls.Add(this.SaturdayToggle);
            this.SaturdayTab.HorizontalScrollbar = true;
            this.SaturdayTab.HorizontalScrollbarBarColor = true;
            this.SaturdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SaturdayTab.HorizontalScrollbarSize = 10;
            this.SaturdayTab.Location = new System.Drawing.Point(4, 34);
            this.SaturdayTab.Name = "SaturdayTab";
            this.SaturdayTab.Size = new System.Drawing.Size(1412, 645);
            this.SaturdayTab.TabIndex = 6;
            this.SaturdayTab.Text = "   Saturday  ";
            this.SaturdayTab.VerticalScrollbar = true;
            this.SaturdayTab.VerticalScrollbarBarColor = true;
            this.SaturdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.SaturdayTab.VerticalScrollbarSize = 20;
            // 
            // pnlMainSaturdayBody
            // 
            this.pnlMainSaturdayBody.AutoScroll = true;
            this.pnlMainSaturdayBody.Controls.Add(this.metroPanel18);
            this.pnlMainSaturdayBody.HorizontalScrollbar = true;
            this.pnlMainSaturdayBody.HorizontalScrollbarBarColor = true;
            this.pnlMainSaturdayBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMainSaturdayBody.HorizontalScrollbarSize = 10;
            this.pnlMainSaturdayBody.Location = new System.Drawing.Point(9, 83);
            this.pnlMainSaturdayBody.Name = "pnlMainSaturdayBody";
            this.pnlMainSaturdayBody.Size = new System.Drawing.Size(1319, 1988);
            this.pnlMainSaturdayBody.TabIndex = 22;
            this.pnlMainSaturdayBody.VerticalScrollbar = true;
            this.pnlMainSaturdayBody.VerticalScrollbarBarColor = true;
            this.pnlMainSaturdayBody.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMainSaturdayBody.VerticalScrollbarSize = 10;
            // 
            // metroPanel18
            // 
            this.metroPanel18.AutoScroll = true;
            this.metroPanel18.AutoSize = true;
            this.metroPanel18.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel18.HorizontalScrollbar = true;
            this.metroPanel18.HorizontalScrollbarBarColor = true;
            this.metroPanel18.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel18.HorizontalScrollbarSize = 10;
            this.metroPanel18.Location = new System.Drawing.Point(0, 0);
            this.metroPanel18.Name = "metroPanel18";
            this.metroPanel18.Size = new System.Drawing.Size(1319, 0);
            this.metroPanel18.TabIndex = 2;
            this.metroPanel18.UseCustomBackColor = true;
            this.metroPanel18.VerticalScrollbar = true;
            this.metroPanel18.VerticalScrollbarBarColor = true;
            this.metroPanel18.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel18.VerticalScrollbarSize = 10;
            // 
            // pnlSaturdayHead
            // 
            this.pnlSaturdayHead.HorizontalScrollbarBarColor = true;
            this.pnlSaturdayHead.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlSaturdayHead.HorizontalScrollbarSize = 10;
            this.pnlSaturdayHead.Location = new System.Drawing.Point(9, 50);
            this.pnlSaturdayHead.Name = "pnlSaturdayHead";
            this.pnlSaturdayHead.Size = new System.Drawing.Size(1319, 33);
            this.pnlSaturdayHead.TabIndex = 21;
            this.pnlSaturdayHead.VerticalScrollbarBarColor = true;
            this.pnlSaturdayHead.VerticalScrollbarHighlightOnWheel = false;
            this.pnlSaturdayHead.VerticalScrollbarSize = 10;
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
            // ComboOrderCustomer
            // 
            this.ComboOrderCustomer.FormattingEnabled = true;
            this.ComboOrderCustomer.Location = new System.Drawing.Point(20, 38);
            this.ComboOrderCustomer.Name = "ComboOrderCustomer";
            this.ComboOrderCustomer.Size = new System.Drawing.Size(253, 21);
            this.ComboOrderCustomer.TabIndex = 11;
            this.ComboOrderCustomer.SelectedIndexChanged += new System.EventHandler(this.ComboOrderCustomer_SelectedIndexChanged);
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(367, 38);
            this.DatePicker.MinimumSize = new System.Drawing.Size(0, 29);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(268, 29);
            this.DatePicker.TabIndex = 12;
            this.DatePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
            // 
            // btnOrderSave
            // 
            this.btnOrderSave.ActiveControl = null;
            this.btnOrderSave.BackColor = System.Drawing.Color.Transparent;
            this.btnOrderSave.Location = new System.Drawing.Point(1293, 28);
            this.btnOrderSave.Name = "btnOrderSave";
            this.btnOrderSave.Size = new System.Drawing.Size(48, 48);
            this.btnOrderSave.TabIndex = 13;
            this.btnOrderSave.TileImage = global::OrderManagement.Properties.Resources.save4_48;
            this.btnOrderSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderSave.UseCustomBackColor = true;
            this.btnOrderSave.UseSelectable = true;
            this.btnOrderSave.UseTileImage = true;
            this.btnOrderSave.Click += new System.EventHandler(this.btnOrderSave_Click);
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
            // btnOrderCalculate
            // 
            this.btnOrderCalculate.ActiveControl = null;
            this.btnOrderCalculate.BackColor = System.Drawing.Color.Transparent;
            this.btnOrderCalculate.Location = new System.Drawing.Point(1239, 28);
            this.btnOrderCalculate.Name = "btnOrderCalculate";
            this.btnOrderCalculate.Size = new System.Drawing.Size(48, 48);
            this.btnOrderCalculate.TabIndex = 15;
            this.btnOrderCalculate.TileImage = global::OrderManagement.Properties.Resources.accessories_calculator_icon;
            this.btnOrderCalculate.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderCalculate.UseCustomBackColor = true;
            this.btnOrderCalculate.UseSelectable = true;
            this.btnOrderCalculate.UseTileImage = true;
            this.btnOrderCalculate.Click += new System.EventHandler(this.btnOrderCalculate_Click);
            // 
            // pnl
            // 
            this.pnl.AutoScroll = true;
            this.pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnl.Controls.Add(this.PnlEditOrder);
            this.pnl.Controls.Add(this.btnOrderCalculate);
            this.pnl.Controls.Add(this.metroLabel2);
            this.pnl.Controls.Add(this.btnOrderSave);
            this.pnl.Controls.Add(this.DatePicker);
            this.pnl.Controls.Add(this.ComboOrderCustomer);
            this.pnl.Controls.Add(this.metroLabel1);
            this.pnl.Controls.Add(this.OrderTab);
            this.pnl.Controls.Add(this.label1);
            this.pnl.HorizontalScrollbar = true;
            this.pnl.HorizontalScrollbarBarColor = true;
            this.pnl.HorizontalScrollbarHighlightOnWheel = false;
            this.pnl.HorizontalScrollbarSize = 10;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(1457, 792);
            this.pnl.TabIndex = 8;
            this.pnl.VerticalScrollbar = true;
            this.pnl.VerticalScrollbarBarColor = true;
            this.pnl.VerticalScrollbarHighlightOnWheel = false;
            this.pnl.VerticalScrollbarSize = 10;
            // 
            // PnlEditOrder
            // 
            this.PnlEditOrder.HorizontalScrollbarBarColor = true;
            this.PnlEditOrder.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlEditOrder.HorizontalScrollbarSize = 10;
            this.PnlEditOrder.Location = new System.Drawing.Point(1185, 28);
            this.PnlEditOrder.Name = "PnlEditOrder";
            this.PnlEditOrder.Size = new System.Drawing.Size(48, 48);
            this.PnlEditOrder.TabIndex = 16;
            this.PnlEditOrder.VerticalScrollbarBarColor = true;
            this.PnlEditOrder.VerticalScrollbarHighlightOnWheel = false;
            this.PnlEditOrder.VerticalScrollbarSize = 10;
            // 
            // btnEditOrderThursday
            // 
            this.btnEditOrderThursday.ActiveControl = null;
            this.btnEditOrderThursday.BackColor = System.Drawing.Color.Transparent;
            this.btnEditOrderThursday.Location = new System.Drawing.Point(1200, 10);
            this.btnEditOrderThursday.Name = "btnEditOrderThursday";
            this.btnEditOrderThursday.Size = new System.Drawing.Size(32, 32);
            this.btnEditOrderThursday.TabIndex = 17;
            this.btnEditOrderThursday.TileImage = global::OrderManagement.Properties.Resources.Pencil_icon;
            this.btnEditOrderThursday.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditOrderThursday.UseCustomBackColor = true;
            this.btnEditOrderThursday.UseSelectable = true;
            this.btnEditOrderThursday.UseTileImage = true;
            this.btnEditOrderThursday.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnEditOrderSunday
            // 
            this.btnEditOrderSunday.ActiveControl = null;
            this.btnEditOrderSunday.BackColor = System.Drawing.Color.Transparent;
            this.btnEditOrderSunday.Location = new System.Drawing.Point(1199, 10);
            this.btnEditOrderSunday.Name = "btnEditOrderSunday";
            this.btnEditOrderSunday.Size = new System.Drawing.Size(32, 32);
            this.btnEditOrderSunday.TabIndex = 18;
            this.btnEditOrderSunday.TileImage = global::OrderManagement.Properties.Resources.Pencil_icon;
            this.btnEditOrderSunday.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditOrderSunday.UseCustomBackColor = true;
            this.btnEditOrderSunday.UseSelectable = true;
            this.btnEditOrderSunday.UseTileImage = true;
            this.btnEditOrderSunday.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // OrderUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl);
            this.Name = "OrderUC";
            this.Size = new System.Drawing.Size(1460, 792);
            this.Load += new System.EventHandler(this.OrderUC_Load);
            this.OrderTab.ResumeLayout(false);
            this.SundayTab.ResumeLayout(false);
            this.SundayTab.PerformLayout();
            this.pnlMainSundayBody.ResumeLayout(false);
            this.pnlMainSundayBody.PerformLayout();
            this.MondayTab.ResumeLayout(false);
            this.MondayTab.PerformLayout();
            this.pnlMainMondayBody.ResumeLayout(false);
            this.pnlMainMondayBody.PerformLayout();
            this.TuesdayTab.ResumeLayout(false);
            this.TuesdayTab.PerformLayout();
            this.pnlMainTuesdayBody.ResumeLayout(false);
            this.pnlMainTuesdayBody.PerformLayout();
            this.WednesdayTab.ResumeLayout(false);
            this.WednesdayTab.PerformLayout();
            this.pnlMainWednesdayBody.ResumeLayout(false);
            this.pnlMainWednesdayBody.PerformLayout();
            this.ThursdayTab.ResumeLayout(false);
            this.ThursdayTab.PerformLayout();
            this.pnlMainThursdayBody.ResumeLayout(false);
            this.pnlMainThursdayBody.PerformLayout();
            this.FridayTab.ResumeLayout(false);
            this.FridayTab.PerformLayout();
            this.pnlMainFridayBody.ResumeLayout(false);
            this.pnlMainFridayBody.PerformLayout();
            this.SaturdayTab.ResumeLayout(false);
            this.SaturdayTab.PerformLayout();
            this.pnlMainSaturdayBody.ResumeLayout(false);
            this.pnlMainSaturdayBody.PerformLayout();
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTabControl OrderTab;
        private MetroFramework.Controls.MetroTabPage SundayTab;
        private MetroFramework.Controls.MetroPanel pnlMainSundayBody;
        private MetroFramework.Controls.MetroPanel metroPanel6;
        private MetroFramework.Controls.MetroPanel pnlSundayHead;
        private MetroFramework.Controls.MetroLabel lblDateSunday;
        private MetroFramework.Controls.MetroToggle SundayToggle;
        private MetroFramework.Controls.MetroTabPage MondayTab;
        private MetroFramework.Controls.MetroPanel pnlMainMondayBody;
        private MetroFramework.Controls.MetroPanel pnlMondayBody;
        private MetroFramework.Controls.MetroLabel lblDateMonday;
        private MetroFramework.Controls.MetroToggle MondayToggle;
        private MetroFramework.Controls.MetroPanel pnlMondayHead;
        private MetroFramework.Controls.MetroTabPage TuesdayTab;
        private MetroFramework.Controls.MetroPanel pnlMainTuesdayBody;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroPanel pnlTuesdayHead;
        private MetroFramework.Controls.MetroLabel lblDateTuesday;
        private MetroFramework.Controls.MetroToggle TuesdayToggle;
        private MetroFramework.Controls.MetroTabPage WednesdayTab;
        private MetroFramework.Controls.MetroPanel pnlMainWednesdayBody;
        private MetroFramework.Controls.MetroPanel metroPanel9;
        private MetroFramework.Controls.MetroPanel pnlWednesdayHead;
        private MetroFramework.Controls.MetroLabel lblDateWednesday;
        private MetroFramework.Controls.MetroToggle WednesdayToggle;
        private MetroFramework.Controls.MetroTabPage ThursdayTab;
        private MetroFramework.Controls.MetroPanel pnlMainThursdayBody;
        private MetroFramework.Controls.MetroPanel metroPanel12;
        private MetroFramework.Controls.MetroPanel pnlThursdayHead;
        private MetroFramework.Controls.MetroLabel lblDateThursday;
        private MetroFramework.Controls.MetroToggle ThursdayToggle;
        private MetroFramework.Controls.MetroTabPage FridayTab;
        private MetroFramework.Controls.MetroPanel pnlMainFridayBody;
        private MetroFramework.Controls.MetroPanel metroPanel15;
        private MetroFramework.Controls.MetroPanel pnlFridayHead;
        private MetroFramework.Controls.MetroLabel lblDateFriday;
        private MetroFramework.Controls.MetroToggle FridayToggle;
        private MetroFramework.Controls.MetroTabPage SaturdayTab;
        private MetroFramework.Controls.MetroPanel pnlMainSaturdayBody;
        private MetroFramework.Controls.MetroPanel metroPanel18;
        private MetroFramework.Controls.MetroPanel pnlSaturdayHead;
        private MetroFramework.Controls.MetroLabel lblDateSaturday;
        private MetroFramework.Controls.MetroToggle SaturdayToggle;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ComboBox ComboOrderCustomer;
        private MetroFramework.Controls.MetroDateTime DatePicker;
        private MetroFramework.Controls.MetroTile btnOrderSave;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile btnOrderCalculate;
        private MetroFramework.Controls.MetroPanel pnl;
        private MetroFramework.Controls.MetroPanel PnlEditOrder;
        private MetroFramework.Controls.MetroTile btnEditOrderThursday;
        private MetroFramework.Controls.MetroTile btnEditOrderSunday;
    }
}
