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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.ComboOrderCustomer = new System.Windows.Forms.ComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.OrderTab = new MetroFramework.Controls.MetroTabControl();
            this.SundayTab = new MetroFramework.Controls.MetroTabPage();
            this.SundayToggle = new MetroFramework.Controls.MetroToggle();
            this.SundayGrid = new MetroFramework.Controls.MetroGrid();
            this.MondayTab = new MetroFramework.Controls.MetroTabPage();
            this.pnlMainMondayBody = new MetroFramework.Controls.MetroPanel();
            this.pnlMondayBody = new MetroFramework.Controls.MetroPanel();
            this.pnlMondayHead = new MetroFramework.Controls.MetroPanel();
            this.MondayToggle = new MetroFramework.Controls.MetroToggle();
            this.TuesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.lbltest = new MetroFramework.Controls.MetroLabel();
            this.TuesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.WednesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.WednesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.ThursdayTab = new MetroFramework.Controls.MetroTabPage();
            this.ThursdayToggle = new MetroFramework.Controls.MetroToggle();
            this.FridayTab = new MetroFramework.Controls.MetroTabPage();
            this.FridayToggle = new MetroFramework.Controls.MetroToggle();
            this.SaturdayTab = new MetroFramework.Controls.MetroTabPage();
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
            this.OrderTab.SelectedIndex = 1;
            this.OrderTab.Size = new System.Drawing.Size(1438, 683);
            this.OrderTab.TabIndex = 8;
            this.OrderTab.UseSelectable = true;
            this.OrderTab.SelectedIndexChanged += new System.EventHandler(this.OrderTab_SelectedIndexChanged);
            // 
            // SundayTab
            // 
            this.SundayTab.Controls.Add(this.SundayToggle);
            this.SundayTab.Controls.Add(this.SundayGrid);
            this.SundayTab.HorizontalScrollbarBarColor = true;
            this.SundayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SundayTab.HorizontalScrollbarSize = 10;
            this.SundayTab.Location = new System.Drawing.Point(4, 34);
            this.SundayTab.Name = "SundayTab";
            this.SundayTab.Size = new System.Drawing.Size(1331, 671);
            this.SundayTab.TabIndex = 0;
            this.SundayTab.Text = "    Sunday    ";
            this.SundayTab.VerticalScrollbarBarColor = true;
            this.SundayTab.VerticalScrollbarHighlightOnWheel = false;
            this.SundayTab.VerticalScrollbarSize = 10;
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
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.SundayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SundayGrid.DefaultCellStyle = dataGridViewCellStyle35;
            this.SundayGrid.EnableHeadersVisualStyles = false;
            this.SundayGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SundayGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SundayGrid.Location = new System.Drawing.Point(-4, 60);
            this.SundayGrid.Name = "SundayGrid";
            this.SundayGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
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
            // TuesdayTab
            // 
            this.TuesdayTab.AutoScroll = true;
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
            this.WednesdayTab.Controls.Add(this.WednesdayToggle);
            this.WednesdayTab.HorizontalScrollbarBarColor = true;
            this.WednesdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.WednesdayTab.HorizontalScrollbarSize = 10;
            this.WednesdayTab.Location = new System.Drawing.Point(4, 34);
            this.WednesdayTab.Name = "WednesdayTab";
            this.WednesdayTab.Size = new System.Drawing.Size(1331, 671);
            this.WednesdayTab.TabIndex = 3;
            this.WednesdayTab.Text = "   Wednesday  ";
            this.WednesdayTab.VerticalScrollbarBarColor = true;
            this.WednesdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.WednesdayTab.VerticalScrollbarSize = 10;
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
            this.ThursdayTab.Controls.Add(this.ThursdayToggle);
            this.ThursdayTab.HorizontalScrollbarBarColor = true;
            this.ThursdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.ThursdayTab.HorizontalScrollbarSize = 10;
            this.ThursdayTab.Location = new System.Drawing.Point(4, 34);
            this.ThursdayTab.Name = "ThursdayTab";
            this.ThursdayTab.Size = new System.Drawing.Size(1331, 671);
            this.ThursdayTab.TabIndex = 4;
            this.ThursdayTab.Text = "   Thursday  ";
            this.ThursdayTab.VerticalScrollbarBarColor = true;
            this.ThursdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.ThursdayTab.VerticalScrollbarSize = 10;
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
            this.FridayTab.Controls.Add(this.FridayToggle);
            this.FridayTab.HorizontalScrollbarBarColor = true;
            this.FridayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.FridayTab.HorizontalScrollbarSize = 10;
            this.FridayTab.Location = new System.Drawing.Point(4, 34);
            this.FridayTab.Name = "FridayTab";
            this.FridayTab.Size = new System.Drawing.Size(1331, 671);
            this.FridayTab.TabIndex = 5;
            this.FridayTab.Text = "    Friday    ";
            this.FridayTab.VerticalScrollbarBarColor = true;
            this.FridayTab.VerticalScrollbarHighlightOnWheel = false;
            this.FridayTab.VerticalScrollbarSize = 10;
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
            this.SaturdayTab.Controls.Add(this.metroPanel3);
            this.SaturdayTab.Controls.Add(this.metroPanel2);
            this.SaturdayTab.Controls.Add(this.SaturdayToggle);
            this.SaturdayTab.HorizontalScrollbarBarColor = true;
            this.SaturdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SaturdayTab.HorizontalScrollbarSize = 10;
            this.SaturdayTab.Location = new System.Drawing.Point(4, 34);
            this.SaturdayTab.Name = "SaturdayTab";
            this.SaturdayTab.Size = new System.Drawing.Size(1331, 671);
            this.SaturdayTab.TabIndex = 6;
            this.SaturdayTab.Text = "   Saturday   ";
            this.SaturdayTab.VerticalScrollbarBarColor = true;
            this.SaturdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.SaturdayTab.VerticalScrollbarSize = 10;
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
    }
}
