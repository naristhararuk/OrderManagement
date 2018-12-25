namespace OrderManagement.User_Control
{
    partial class SettingUC
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
            this.SettingMenuTile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // SettingMenuTile
            // 
            this.SettingMenuTile.ActiveControl = null;
            this.SettingMenuTile.AutoSize = true;
            this.SettingMenuTile.BackColor = System.Drawing.Color.DarkOrchid;
            this.SettingMenuTile.Location = new System.Drawing.Point(17, 18);
            this.SettingMenuTile.Name = "SettingMenuTile";
            this.SettingMenuTile.Size = new System.Drawing.Size(220, 44);
            this.SettingMenuTile.TabIndex = 41;
            this.SettingMenuTile.Text = "Setting";
            this.SettingMenuTile.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SettingMenuTile.TileImage = global::OrderManagement.Properties.Resources.setting_481;
            this.SettingMenuTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SettingMenuTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.SettingMenuTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.SettingMenuTile.UseCustomBackColor = true;
            this.SettingMenuTile.UseSelectable = true;
            this.SettingMenuTile.UseTileImage = true;
            // 
            // SettingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SettingMenuTile);
            this.Name = "SettingUC";
            this.Size = new System.Drawing.Size(887, 502);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile SettingMenuTile;
    }
}
