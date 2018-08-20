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
            this.pnlMainReport = new MetroFramework.Controls.MetroPanel();
            this.ReportSummaryTile = new MetroFramework.Controls.MetroTile();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.ReportTableTile = new MetroFramework.Controls.MetroTile();
            this.pnlMainReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainReport
            // 
            this.pnlMainReport.Controls.Add(this.metroPanel1);
            this.pnlMainReport.HorizontalScrollbarBarColor = false;
            this.pnlMainReport.HorizontalScrollbarHighlightOnWheel = true;
            this.pnlMainReport.HorizontalScrollbarSize = 10;
            this.pnlMainReport.Location = new System.Drawing.Point(112, 3);
            this.pnlMainReport.Name = "pnlMainReport";
            this.pnlMainReport.Size = new System.Drawing.Size(1227, 706);
            this.pnlMainReport.TabIndex = 1;
            this.pnlMainReport.VerticalScrollbarBarColor = false;
            this.pnlMainReport.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMainReport.VerticalScrollbarSize = 10;
            this.pnlMainReport.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainReport_Paint);
            // 
            // ReportSummaryTile
            // 
            this.ReportSummaryTile.ActiveControl = null;
            this.ReportSummaryTile.BackColor = System.Drawing.Color.MediumPurple;
            this.ReportSummaryTile.Location = new System.Drawing.Point(62, 25);
            this.ReportSummaryTile.Name = "ReportSummaryTile";
            this.ReportSummaryTile.Size = new System.Drawing.Size(44, 107);
            this.ReportSummaryTile.TabIndex = 0;
            this.ReportSummaryTile.Text = "Summary Report";
            this.ReportSummaryTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ReportSummaryTile.TileImage = global::OrderManagement.Properties.Resources.chart_481;
            this.ReportSummaryTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ReportSummaryTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ReportSummaryTile.UseCustomBackColor = true;
            this.ReportSummaryTile.UseCustomForeColor = true;
            this.ReportSummaryTile.UseSelectable = true;
            this.ReportSummaryTile.UseTileImage = true;
            this.ReportSummaryTile.Visible = false;
            this.ReportSummaryTile.Click += new System.EventHandler(this.ReportSummaryTile_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = true;
            this.metroPanel1.HorizontalScrollbarSize = 15;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1227, 731);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = true;
            this.metroPanel1.VerticalScrollbarSize = 15;
            // 
            // ReportTableTile
            // 
            this.ReportTableTile.ActiveControl = null;
            this.ReportTableTile.BackColor = System.Drawing.Color.RoyalBlue;
            this.ReportTableTile.Location = new System.Drawing.Point(62, 159);
            this.ReportTableTile.Name = "ReportTableTile";
            this.ReportTableTile.Size = new System.Drawing.Size(44, 107);
            this.ReportTableTile.TabIndex = 3;
            this.ReportTableTile.Text = "Table Report";
            this.ReportTableTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ReportTableTile.TileImage = global::OrderManagement.Properties.Resources.chart3_48;
            this.ReportTableTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ReportTableTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ReportTableTile.UseCustomBackColor = true;
            this.ReportTableTile.UseCustomForeColor = true;
            this.ReportTableTile.UseSelectable = true;
            this.ReportTableTile.UseTileImage = true;
            this.ReportTableTile.Visible = false;
            this.ReportTableTile.Click += new System.EventHandler(this.ReportTableTile_Click);
            // 
            // ReportUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReportTableTile);
            this.Controls.Add(this.pnlMainReport);
            this.Controls.Add(this.ReportSummaryTile);
            this.Name = "ReportUC";
            this.Size = new System.Drawing.Size(1354, 737);
            this.Load += new System.EventHandler(this.ReportUC_Load);
            this.pnlMainReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile ReportSummaryTile;
        private MetroFramework.Controls.MetroPanel pnlMainReport;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile ReportTableTile;
    }
}
