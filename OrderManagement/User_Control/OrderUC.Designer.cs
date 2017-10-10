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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.OrderTab = new MetroFramework.Controls.MetroTabControl();
            this.SundayTab = new MetroFramework.Controls.MetroTabPage();
            this.SundayGrid = new MetroFramework.Controls.MetroGrid();
            this.MondayTab = new MetroFramework.Controls.MetroTabPage();
            this.MondayToggle = new MetroFramework.Controls.MetroToggle();
            this.TuesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.WednesdayTab = new MetroFramework.Controls.MetroTabPage();
            this.ThursdayTab = new MetroFramework.Controls.MetroTabPage();
            this.FridayTab = new MetroFramework.Controls.MetroTabPage();
            this.SaturdayTab = new MetroFramework.Controls.MetroTabPage();
            this.SundayToggle = new MetroFramework.Controls.MetroToggle();
            this.TuesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.WednesdayToggle = new MetroFramework.Controls.MetroToggle();
            this.ThursdayToggle = new MetroFramework.Controls.MetroToggle();
            this.FridayToggle = new MetroFramework.Controls.MetroToggle();
            this.SaturdayToggle = new MetroFramework.Controls.MetroToggle();
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
            // SundayGrid
            // 
            this.SundayGrid.AllowUserToResizeRows = false;
            this.SundayGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SundayGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SundayGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.SundayGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SundayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SundayGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.SundayGrid.EnableHeadersVisualStyles = false;
            this.SundayGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SundayGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SundayGrid.Location = new System.Drawing.Point(20, 60);
            this.SundayGrid.Name = "SundayGrid";
            this.SundayGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SundayGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SundayGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SundayGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SundayGrid.Size = new System.Drawing.Size(1290, 391);
            this.SundayGrid.TabIndex = 3;
            this.SundayGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SundayGrid_CellClick);
            // 
            // MondayTab
            // 
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
    }
}
