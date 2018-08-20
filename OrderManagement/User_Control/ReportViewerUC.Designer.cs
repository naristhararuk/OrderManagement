namespace OrderManagement.User_Control
{
    partial class ReportViewerUC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewerUC));
            this.ddlReportName = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnSearchReport = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.RptDatePicker = new MetroFramework.Controls.MetroDateTime();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCustomer = new MetroFramework.Controls.MetroLabel();
            this.ddlCustomer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlReportName
            // 
            this.ddlReportName.FormattingEnabled = true;
            this.ddlReportName.Items.AddRange(new object[] {
            "ใบเสร็จ",
            "ใบอินวอยซ์",
            "ใบส่งของ",
            "ใบขึ้นรถ"});
            this.ddlReportName.Location = new System.Drawing.Point(20, 32);
            this.ddlReportName.Name = "ddlReportName";
            this.ddlReportName.Size = new System.Drawing.Size(253, 21);
            this.ddlReportName.TabIndex = 42;
            this.ddlReportName.SelectedIndexChanged += new System.EventHandler(this.ddlReportName_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(16, 4);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(71, 25);
            this.metroLabel3.TabIndex = 41;
            this.metroLabel3.Text = "รายงาน";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // btnSearchReport
            // 
            this.btnSearchReport.ActiveControl = null;
            this.btnSearchReport.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchReport.Location = new System.Drawing.Point(883, 4);
            this.btnSearchReport.Name = "btnSearchReport";
            this.btnSearchReport.Size = new System.Drawing.Size(49, 50);
            this.btnSearchReport.TabIndex = 40;
            this.btnSearchReport.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSearchReport.TileImage")));
            this.btnSearchReport.UseCustomBackColor = true;
            this.btnSearchReport.UseSelectable = true;
            this.btnSearchReport.UseStyleColors = true;
            this.btnSearchReport.UseTileImage = true;
            this.btnSearchReport.Click += new System.EventHandler(this.btnSearchReport_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(299, 4);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(82, 25);
            this.metroLabel2.TabIndex = 39;
            this.metroLabel2.Text = "เลือกวันที่";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // RptDatePicker
            // 
            this.RptDatePicker.Location = new System.Drawing.Point(299, 32);
            this.RptDatePicker.MinimumSize = new System.Drawing.Size(0, 29);
            this.RptDatePicker.Name = "RptDatePicker";
            this.RptDatePicker.Size = new System.Drawing.Size(268, 29);
            this.RptDatePicker.TabIndex = 38;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(5, 67);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1190, 647);
            this.reportViewer1.TabIndex = 43;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCustomer.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCustomer.Location = new System.Drawing.Point(592, 4);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(74, 25);
            this.lblCustomer.TabIndex = 36;
            this.lblCustomer.Text = "ชื่อลูกค้า";
            this.lblCustomer.UseCustomBackColor = true;
            // 
            // ddlCustomer
            // 
            this.ddlCustomer.FormattingEnabled = true;
            this.ddlCustomer.Location = new System.Drawing.Point(596, 32);
            this.ddlCustomer.Name = "ddlCustomer";
            this.ddlCustomer.Size = new System.Drawing.Size(237, 21);
            this.ddlCustomer.TabIndex = 37;
            // 
            // ReportViewerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.ddlReportName);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnSearchReport);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.RptDatePicker);
            this.Controls.Add(this.ddlCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Name = "ReportViewerUC";
            this.Size = new System.Drawing.Size(1198, 725);
            this.Load += new System.EventHandler(this.ReportViewerUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlReportName;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTile btnSearchReport;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime RptDatePicker;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CustomerBindingSource;
        private System.Windows.Forms.BindingSource OrderBindingSource;
        private MetroFramework.Controls.MetroLabel lblCustomer;
        private System.Windows.Forms.ComboBox ddlCustomer;
    }
}
