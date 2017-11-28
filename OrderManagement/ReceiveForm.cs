using Microsoft.Reporting.WinForms;
using OrderManagement.Class;
using OrderManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagement
{
    public partial class ReceiveForm : Form
    {
        public DateTime datewhere;
        public int customerid;
        public ReceiveForm()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ddlCustomer, "Customer");
            HelperCS.AutoCompleteLoadValues(ddlReportName, "Config-ReportName");
        }

        private void ReceiveForm_Load(object sender, EventArgs e)
        {
            LoadReport();
            this.reportViewer1.RefreshReport();
        }

        private void LoadReport()
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            
            //string date = "16/11/2017";
            //DateTime dt = Convert.ToDateTime(date);

            //GetSalesOrderData(dt,  3);



            //ReportDataSource dsSalesOrderDetail =
            //    new ReportDataSource();
            //dsSalesOrderDetail.Name = "SalesOrderDetail";
            //dsSalesOrderDetail.Value =
            //    dataset.Tables["SalesOrderDetail"];

            //localReport.DataSources.Add(dsSalesOrderDetail);

            //// Create a report parameter for the sales order number   
            //ReportParameter rpSalesOrderNumber = new ReportParameter();
            //rpSalesOrderNumber.Name = "SalesOrderNumber";
            //rpSalesOrderNumber.Values.Add("SO43661");

            //// Set the report parameters for the report  
            //localReport.SetParameters(
            //    new ReportParameter[] { rpSalesOrderNumber });

            // Refresh the report  
        }

        private void GetSalesOrderDetailData(string salesOrderNumber, ref DataSet dataset)
        {
            throw new NotImplementedException();
        }

        private void GetSalesOrderData(DateTime date, int customer)
        {
            using (var dailydb = new DailyOrderEntities())
            {
                // Get result from Stored Procedure
                var ds = dailydb.GetOrderbyDay(date, customer).ToList();
                //OrderUC orderUC = new OrderUC();
                if (ds.Count() > 0)
                {
                    OrderBindingSource.DataSource = HelperCS.ToDataTable(ds);
                    ReportDataSource rtpsource = new ReportDataSource("DataSet1",OrderBindingSource);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource);
                }
                else
                {
                    OrderBindingSource.DataSource = null;
                }
                    //reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
            }
        }

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            string Customerkey = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Key;
            string ReportNamekey = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Key;
            //string value = ((KeyValuePair<string, string>)RptCustomer.SelectedItem).Value;
            if (Customerkey == "")
            {
                MessageBox.Show("กรุณาเลือกลูกค้าก่อน", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (RptDatePicker.Text == "")
            {
                MessageBox.Show("กรุณาเลือกวันที่ก่อน", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (ddlReportName.SelectedIndex == 0)
            {
                MessageBox.Show("กรุณาเลือกรายงานก่อน", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DateTime currentdate = RptDatePicker.Value;
                int cusid = int.Parse(Customerkey);
                string reportname = ChooseReport(int.Parse(ReportNamekey));
                reportViewer1.LocalReport.ReportEmbeddedResource = reportname;
                GetSalesOrderData(currentdate, cusid);
            }
        }

        private string ChooseReport(int reportid)
        {
            string name = "";
            switch (reportid)
            {
                case 1:
                    {
                        name = "OrderManagement.ReceiveRpt.rdlc";
                        break;
                    }
                case 2:
                    {
                        name = "";
                        break;
                    }
            }
            return name;
        }
    }
}
