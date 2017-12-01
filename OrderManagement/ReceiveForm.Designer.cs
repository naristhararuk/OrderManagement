namespace OrderManagement
{
    partial class ReceiveForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiveForm));
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.RptDatePicker = new MetroFramework.Controls.MetroDateTime();
            this.ddlCustomer = new System.Windows.Forms.ComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchReport = new MetroFramework.Controls.MetroTile();
            this.ddlReportName = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(314, 27);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(87, 25);
            this.metroLabel2.TabIndex = 19;
            this.metroLabel2.Text = "เลือกวันที่";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // RptDatePicker
            // 
            this.RptDatePicker.Location = new System.Drawing.Point(314, 55);
            this.RptDatePicker.MinimumSize = new System.Drawing.Size(0, 29);
            this.RptDatePicker.Name = "RptDatePicker";
            this.RptDatePicker.Size = new System.Drawing.Size(268, 29);
            this.RptDatePicker.TabIndex = 18;
            // 
            // ddlCustomer
            // 
            this.ddlCustomer.FormattingEnabled = true;
            this.ddlCustomer.Location = new System.Drawing.Point(17, 55);
            this.ddlCustomer.Name = "ddlCustomer";
            this.ddlCustomer.Size = new System.Drawing.Size(253, 21);
            this.ddlCustomer.TabIndex = 17;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(13, 27);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(80, 25);
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "ชื่อลูกค้า";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 20;
            // 
            // btnSearchReport
            // 
            this.btnSearchReport.ActiveControl = null;
            this.btnSearchReport.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchReport.Location = new System.Drawing.Point(1076, 46);
            this.btnSearchReport.Name = "btnSearchReport";
            this.btnSearchReport.Size = new System.Drawing.Size(49, 50);
            this.btnSearchReport.TabIndex = 33;
            this.btnSearchReport.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSearchReport.TileImage")));
            this.btnSearchReport.UseCustomBackColor = true;
            this.btnSearchReport.UseSelectable = true;
            this.btnSearchReport.UseStyleColors = true;
            this.btnSearchReport.UseTileImage = true;
            this.btnSearchReport.Click += new System.EventHandler(this.btnSearchReport_Click);
            // 
            // ddlReportName
            // 
            this.ddlReportName.FormattingEnabled = true;
            this.ddlReportName.Items.AddRange(new object[] {
            "ใบเสร็จ",
            "ใบอินวอยซ์",
            "ใบส่งของ",
            "ใบขึ้นรถ"});
            this.ddlReportName.Location = new System.Drawing.Point(633, 55);
            this.ddlReportName.Name = "ddlReportName";
            this.ddlReportName.Size = new System.Drawing.Size(253, 21);
            this.ddlReportName.TabIndex = 35;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(629, 27);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(73, 25);
            this.metroLabel3.TabIndex = 34;
            this.metroLabel3.Text = "รายงาน";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(17, 104);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1264, 718);
            this.reportViewer1.TabIndex = 36;
            // 
            // OrderBindingSource
            // 
            this.OrderBindingSource.DataSource = typeof(OrderManagement.Entity.Order);
            // 
            // ReceiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 834);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.ddlReportName);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnSearchReport);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.RptDatePicker);
            this.Controls.Add(this.ddlCustomer);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.label1);
            this.Name = "ReceiveForm";
            this.Text = "ReceiveForm";
            this.Load += new System.EventHandler(this.ReceiveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource OrderBindingSource;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime RptDatePicker;
        private System.Windows.Forms.ComboBox ddlCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTile btnSearchReport;
        private System.Windows.Forms.ComboBox ddlReportName;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CustomerBindingSource;
    }
}