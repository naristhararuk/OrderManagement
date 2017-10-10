namespace OrderManagement.User_Control
{
    partial class ReportUC
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
            this.ReportSummaryTile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // ReportSummaryTile
            // 
            this.ReportSummaryTile.ActiveControl = null;
            this.ReportSummaryTile.BackColor = System.Drawing.Color.MediumPurple;
            this.ReportSummaryTile.Location = new System.Drawing.Point(91, 81);
            this.ReportSummaryTile.Name = "ReportSummaryTile";
            this.ReportSummaryTile.Size = new System.Drawing.Size(222, 138);
            this.ReportSummaryTile.TabIndex = 0;
            this.ReportSummaryTile.Text = "Summary Report";
            this.ReportSummaryTile.TileImage = global::OrderManagement.Properties.Resources.chart_481;
            this.ReportSummaryTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ReportSummaryTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ReportSummaryTile.UseCustomBackColor = true;
            this.ReportSummaryTile.UseCustomForeColor = true;
            this.ReportSummaryTile.UseSelectable = true;
            this.ReportSummaryTile.UseTileImage = true;
            this.ReportSummaryTile.Click += new System.EventHandler(this.ReportSummaryTile_Click);
            // 
            // ReportUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReportSummaryTile);
            this.Name = "ReportUC";
            this.Size = new System.Drawing.Size(1039, 691);
            this.Load += new System.EventHandler(this.ReportUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile ReportSummaryTile;
    }
}
