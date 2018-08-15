namespace OrderManagement
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMenu = new MetroFramework.Controls.MetroPanel();
            this.UserTile = new MetroFramework.Controls.MetroTile();
            this.SettingMenuTile = new MetroFramework.Controls.MetroTile();
            this.OrderMenuTile = new MetroFramework.Controls.MetroTile();
            this.ProductMenuTile = new MetroFramework.Controls.MetroTile();
            this.ReportMenuTile = new MetroFramework.Controls.MetroTile();
            this.CustomerMenuTile = new MetroFramework.Controls.MetroTile();
            this.pnlMain = new MetroFramework.Controls.MetroPanel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.UserTile);
            this.pnlMenu.Controls.Add(this.SettingMenuTile);
            this.pnlMenu.Controls.Add(this.OrderMenuTile);
            this.pnlMenu.Controls.Add(this.ProductMenuTile);
            this.pnlMenu.Controls.Add(this.ReportMenuTile);
            this.pnlMenu.Controls.Add(this.CustomerMenuTile);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.HorizontalScrollbarBarColor = true;
            this.pnlMenu.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMenu.HorizontalScrollbarSize = 10;
            this.pnlMenu.Location = new System.Drawing.Point(20, 60);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1338, 53);
            this.pnlMenu.TabIndex = 40;
            this.pnlMenu.VerticalScrollbarBarColor = true;
            this.pnlMenu.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMenu.VerticalScrollbarSize = 10;
            // 
            // UserTile
            // 
            this.UserTile.ActiveControl = null;
            this.UserTile.BackColor = System.Drawing.Color.Transparent;
            this.UserTile.Location = new System.Drawing.Point(1133, 3);
            this.UserTile.Name = "UserTile";
            this.UserTile.Size = new System.Drawing.Size(220, 44);
            this.UserTile.TabIndex = 42;
            this.UserTile.Text = "ไม่ล็อคอิน";
            this.UserTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UserTile.TileImage = global::OrderManagement.Properties.Resources.Female_Face_FA_5_icon__1_;
            this.UserTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UserTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.UserTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.UserTile.UseCustomBackColor = true;
            this.UserTile.UseCustomForeColor = true;
            this.UserTile.UseSelectable = true;
            this.UserTile.UseTileImage = true;
            this.UserTile.Click += new System.EventHandler(this.UserTile_Click);
            // 
            // SettingMenuTile
            // 
            this.SettingMenuTile.ActiveControl = null;
            this.SettingMenuTile.AutoSize = true;
            this.SettingMenuTile.BackColor = System.Drawing.Color.DarkOrchid;
            this.SettingMenuTile.Location = new System.Drawing.Point(907, 3);
            this.SettingMenuTile.Name = "SettingMenuTile";
            this.SettingMenuTile.Size = new System.Drawing.Size(220, 44);
            this.SettingMenuTile.TabIndex = 40;
            this.SettingMenuTile.Text = "Setting";
            this.SettingMenuTile.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SettingMenuTile.TileImage = global::OrderManagement.Properties.Resources.setting_481;
            this.SettingMenuTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SettingMenuTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.SettingMenuTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.SettingMenuTile.UseCustomBackColor = true;
            this.SettingMenuTile.UseSelectable = true;
            this.SettingMenuTile.UseTileImage = true;
            this.SettingMenuTile.Click += new System.EventHandler(this.SettingMenuTile_Click);
            // 
            // OrderMenuTile
            // 
            this.OrderMenuTile.ActiveControl = null;
            this.OrderMenuTile.BackColor = System.Drawing.Color.Tomato;
            this.OrderMenuTile.Location = new System.Drawing.Point(3, 3);
            this.OrderMenuTile.Name = "OrderMenuTile";
            this.OrderMenuTile.Size = new System.Drawing.Size(220, 44);
            this.OrderMenuTile.TabIndex = 1;
            this.OrderMenuTile.Text = "Order";
            this.OrderMenuTile.TileImage = global::OrderManagement.Properties.Resources.invoice_48;
            this.OrderMenuTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OrderMenuTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.OrderMenuTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.OrderMenuTile.UseCustomBackColor = true;
            this.OrderMenuTile.UseSelectable = true;
            this.OrderMenuTile.UseTileImage = true;
            this.OrderMenuTile.Click += new System.EventHandler(this.OrderMenuTile_Click);
            // 
            // ProductMenuTile
            // 
            this.ProductMenuTile.ActiveControl = null;
            this.ProductMenuTile.AutoSize = true;
            this.ProductMenuTile.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ProductMenuTile.Location = new System.Drawing.Point(455, 3);
            this.ProductMenuTile.Name = "ProductMenuTile";
            this.ProductMenuTile.Size = new System.Drawing.Size(220, 44);
            this.ProductMenuTile.TabIndex = 2;
            this.ProductMenuTile.Text = "Product";
            this.ProductMenuTile.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ProductMenuTile.TileImage = global::OrderManagement.Properties.Resources.cart2_48;
            this.ProductMenuTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ProductMenuTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ProductMenuTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.ProductMenuTile.UseCustomBackColor = true;
            this.ProductMenuTile.UseSelectable = true;
            this.ProductMenuTile.UseTileImage = true;
            this.ProductMenuTile.Click += new System.EventHandler(this.ProductMenuTile_Click);
            // 
            // ReportMenuTile
            // 
            this.ReportMenuTile.ActiveControl = null;
            this.ReportMenuTile.AutoSize = true;
            this.ReportMenuTile.BackColor = System.Drawing.Color.DodgerBlue;
            this.ReportMenuTile.Location = new System.Drawing.Point(681, 3);
            this.ReportMenuTile.Name = "ReportMenuTile";
            this.ReportMenuTile.Size = new System.Drawing.Size(220, 44);
            this.ReportMenuTile.TabIndex = 5;
            this.ReportMenuTile.Text = "Report";
            this.ReportMenuTile.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ReportMenuTile.TileImage = global::OrderManagement.Properties.Resources.chart3_48;
            this.ReportMenuTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ReportMenuTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ReportMenuTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.ReportMenuTile.UseCustomBackColor = true;
            this.ReportMenuTile.UseSelectable = true;
            this.ReportMenuTile.UseTileImage = true;
            this.ReportMenuTile.Click += new System.EventHandler(this.ReportMenuTile_Click);
            // 
            // CustomerMenuTile
            // 
            this.CustomerMenuTile.ActiveControl = null;
            this.CustomerMenuTile.Location = new System.Drawing.Point(229, 3);
            this.CustomerMenuTile.Name = "CustomerMenuTile";
            this.CustomerMenuTile.Size = new System.Drawing.Size(220, 44);
            this.CustomerMenuTile.TabIndex = 0;
            this.CustomerMenuTile.Text = "Customer";
            this.CustomerMenuTile.TileImage = global::OrderManagement.Properties.Resources.group_48;
            this.CustomerMenuTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CustomerMenuTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.CustomerMenuTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.CustomerMenuTile.UseSelectable = true;
            this.CustomerMenuTile.UseTileImage = true;
            this.CustomerMenuTile.Click += new System.EventHandler(this.CustomerMenuTile_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSize = true;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.HorizontalScrollbarBarColor = false;
            this.pnlMain.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMain.HorizontalScrollbarSize = 10;
            this.pnlMain.Location = new System.Drawing.Point(20, 113);
            this.pnlMain.MaximumSize = new System.Drawing.Size(1900, 795);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1338, 647);
            this.pnlMain.TabIndex = 41;
            this.pnlMain.VerticalScrollbarBarColor = false;
            this.pnlMain.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMain.VerticalScrollbarSize = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.MaximumSize = new System.Drawing.Size(2400, 1200);
            this.Name = "Form1";
            this.Text = "Order Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile CustomerMenuTile;
        private MetroFramework.Controls.MetroTile OrderMenuTile;
        private MetroFramework.Controls.MetroTile ProductMenuTile;
        private MetroFramework.Controls.MetroTile ReportMenuTile;
        private MetroFramework.Controls.MetroPanel pnlMenu;
        private MetroFramework.Controls.MetroPanel pnlMain;
        private MetroFramework.Controls.MetroTile SettingMenuTile;
        private MetroFramework.Controls.MetroTile UserTile;
    }
}

