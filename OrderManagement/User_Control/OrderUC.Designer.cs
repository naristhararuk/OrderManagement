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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ddlCustomerOrder = new MetroFramework.Controls.MetroComboBox();
            this.OrderTab = new MetroFramework.Controls.MetroTabControl();
            this.SundayTab = new MetroFramework.Controls.MetroTabPage();
            this.SundayToggle = new MetroFramework.Controls.MetroToggle();
            this.SundayGrid = new MetroFramework.Controls.MetroGrid();
            this.MondayTab = new MetroFramework.Controls.MetroTabPage();
            this.MondayToggle = new MetroFramework.Controls.MetroToggle();
            this.TuesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.TuesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.WednesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.WednesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.ThursdayTab = new MetroFramework.Controls.MetroTabPage();
            this.ThursdayToggle = new MetroFramework.Controls.MetroToggle();
            this.FridayTab = new MetroFramework.Controls.MetroTabPage();
            this.FridayToggle = new MetroFramework.Controls.MetroToggle();
            this.SaturdayTab = new MetroFramework.Controls.MetroTabPage();
            this.SaturdayToggle = new MetroFramework.Controls.MetroToggle();
            this.MondayGrid = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.metroPanel1.SuspendLayout();
            this.OrderTab.SuspendLayout();
            this.SundayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SundayGrid)).BeginInit();
            this.MondayTab.SuspendLayout();
            this.TuesdayTab.SuspendLayout();
            this.WednesdayTab.SuspendLayout();
            this.ThursdayTab.SuspendLayout();
            this.FridayTab.SuspendLayout();
            this.SaturdayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MondayGrid)).BeginInit();
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
            this.metroPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.ddlCustomerOrder);
            this.metroPanel1.Controls.Add(this.OrderTab);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1369, 849);
            this.metroPanel1.TabIndex = 8;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
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
            this.metroLabel1.Text = "ชือลูกค้า";
            // 
            // ddlCustomerOrder
            // 
            this.ddlCustomerOrder.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.ddlCustomerOrder.FormattingEnabled = true;
            this.ddlCustomerOrder.ItemHeight = 29;
            this.ddlCustomerOrder.Items.AddRange(new object[] {
            "Peter",
            "Alex",
            "Stefany"});
            this.ddlCustomerOrder.Location = new System.Drawing.Point(16, 38);
            this.ddlCustomerOrder.Name = "ddlCustomerOrder";
            this.ddlCustomerOrder.Size = new System.Drawing.Size(253, 35);
            this.ddlCustomerOrder.TabIndex = 9;
            this.ddlCustomerOrder.UseSelectable = true;
            this.ddlCustomerOrder.SelectedIndexChanged += new System.EventHandler(this.ddlCustomerOrder_SelectedIndexChanged);
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
            this.OrderTab.Size = new System.Drawing.Size(1339, 759);
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
            this.SundayTab.Size = new System.Drawing.Size(1331, 721);
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.SundayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SundayGrid.DefaultCellStyle = dataGridViewCellStyle20;
            this.SundayGrid.EnableHeadersVisualStyles = false;
            this.SundayGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SundayGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SundayGrid.Location = new System.Drawing.Point(-4, 60);
            this.SundayGrid.Name = "SundayGrid";
            this.SundayGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.SundayGrid.RowHeadersVisible = false;
            this.SundayGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SundayGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SundayGrid.Size = new System.Drawing.Size(1332, 541);
            this.SundayGrid.TabIndex = 3;
            this.SundayGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SundayGrid_CellClick);
            // 
            // MondayTab
            // 
            this.MondayTab.Controls.Add(this.MondayGrid);
            this.MondayTab.Controls.Add(this.MondayToggle);
            this.MondayTab.HorizontalScrollbarBarColor = true;
            this.MondayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.MondayTab.HorizontalScrollbarSize = 10;
            this.MondayTab.Location = new System.Drawing.Point(4, 34);
            this.MondayTab.Name = "MondayTab";
            this.MondayTab.Size = new System.Drawing.Size(1331, 721);
            this.MondayTab.TabIndex = 1;
            this.MondayTab.Text = "    Monday    ";
            this.MondayTab.VerticalScrollbarBarColor = true;
            this.MondayTab.VerticalScrollbarHighlightOnWheel = false;
            this.MondayTab.VerticalScrollbarSize = 10;
            // 
            // MondayToggle
            // 
            this.MondayToggle.AutoSize = true;
            this.MondayToggle.Location = new System.Drawing.Point(1248, 12);
            this.MondayToggle.Name = "MondayToggle";
            this.MondayToggle.Size = new System.Drawing.Size(80, 17);
            this.MondayToggle.Style = MetroFramework.MetroColorStyle.White;
            this.MondayToggle.TabIndex = 3;
            this.MondayToggle.Text = "Off";
            this.MondayToggle.UseSelectable = true;
            // 
            // TuesdayTab
            // 
            this.TuesdayTab.Controls.Add(this.TuesdayToggle);
            this.TuesdayTab.HorizontalScrollbarBarColor = true;
            this.TuesdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.TuesdayTab.HorizontalScrollbarSize = 10;
            this.TuesdayTab.Location = new System.Drawing.Point(4, 34);
            this.TuesdayTab.Name = "TuesdayTab";
            this.TuesdayTab.Size = new System.Drawing.Size(1331, 721);
            this.TuesdayTab.TabIndex = 2;
            this.TuesdayTab.Text = "    Tuesday   ";
            this.TuesdayTab.VerticalScrollbarBarColor = true;
            this.TuesdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.TuesdayTab.VerticalScrollbarSize = 10;
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
            this.WednesdayTab.Size = new System.Drawing.Size(1331, 721);
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
            this.ThursdayTab.Size = new System.Drawing.Size(1331, 721);
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
            this.FridayTab.Size = new System.Drawing.Size(1331, 721);
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
            this.SaturdayTab.Controls.Add(this.SaturdayToggle);
            this.SaturdayTab.HorizontalScrollbarBarColor = true;
            this.SaturdayTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SaturdayTab.HorizontalScrollbarSize = 10;
            this.SaturdayTab.Location = new System.Drawing.Point(4, 34);
            this.SaturdayTab.Name = "SaturdayTab";
            this.SaturdayTab.Size = new System.Drawing.Size(1331, 721);
            this.SaturdayTab.TabIndex = 6;
            this.SaturdayTab.Text = "   Saturday   ";
            this.SaturdayTab.VerticalScrollbarBarColor = true;
            this.SaturdayTab.VerticalScrollbarHighlightOnWheel = false;
            this.SaturdayTab.VerticalScrollbarSize = 10;
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
            // MondayGrid
            // 
            this.MondayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MondayGrid.Location = new System.Drawing.Point(9, 33);
            this.MondayGrid.Name = "MondayGrid";
            this.MondayGrid.Size = new System.Drawing.Size(1343, 410);
            this.MondayGrid.TabIndex = 4;
            this.MondayGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MondayGrid_CellClick);
            this.MondayGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.MondayGrid_CellLeave);
            // 
            // OrderUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel1);
            this.Name = "OrderUC";
            this.Size = new System.Drawing.Size(1375, 855);
            this.Load += new System.EventHandler(this.OrderUC_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.OrderTab.ResumeLayout(false);
            this.SundayTab.ResumeLayout(false);
            this.SundayTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SundayGrid)).EndInit();
            this.MondayTab.ResumeLayout(false);
            this.MondayTab.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.MondayGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl OrderTab;
        private MetroFramework.Controls.MetroTabPage SundayTab;
        private MetroFramework.Controls.MetroTabPage MondayTab;
        private MetroFramework.Controls.MetroToggle MondayToggle;
        private MetroFramework.Controls.MetroGrid SundayGrid;
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
        private MetroFramework.Controls.MetroComboBox ddlCustomerOrder;
        private System.Windows.Forms.DataGridView MondayGrid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
