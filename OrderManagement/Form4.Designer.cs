namespace OrderManagement
{
    partial class Form4
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
            this.SundaytbPanel = new MetroFramework.Controls.MetroPanel();
            this.MondayCustomerCombo = new System.Windows.Forms.ComboBox();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // SundaytbPanel
            // 
            this.SundaytbPanel.HorizontalScrollbarBarColor = true;
            this.SundaytbPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.SundaytbPanel.HorizontalScrollbarSize = 10;
            this.SundaytbPanel.Location = new System.Drawing.Point(12, 89);
            this.SundaytbPanel.Name = "SundaytbPanel";
            this.SundaytbPanel.Size = new System.Drawing.Size(1335, 193);
            this.SundaytbPanel.TabIndex = 0;
            this.SundaytbPanel.VerticalScrollbarBarColor = true;
            this.SundaytbPanel.VerticalScrollbarHighlightOnWheel = false;
            this.SundaytbPanel.VerticalScrollbarSize = 10;
            // 
            // MondayCustomerCombo
            // 
            this.MondayCustomerCombo.FormattingEnabled = true;
            this.MondayCustomerCombo.Location = new System.Drawing.Point(13, 13);
            this.MondayCustomerCombo.Name = "MondayCustomerCombo";
            this.MondayCustomerCombo.Size = new System.Drawing.Size(223, 21);
            this.MondayCustomerCombo.TabIndex = 1;
            this.MondayCustomerCombo.SelectedIndexChanged += new System.EventHandler(this.MondayCustomerCombo_SelectedIndexChanged);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(450, 13);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(21, 23);
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "metroTile1";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileImage = global::OrderManagement.Properties.Resources.remove2_161;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 790);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.MondayCustomerCombo);
            this.Controls.Add(this.SundaytbPanel);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel SundaytbPanel;
        private System.Windows.Forms.ComboBox MondayCustomerCombo;
        private MetroFramework.Controls.MetroTile metroTile1;
    }
}