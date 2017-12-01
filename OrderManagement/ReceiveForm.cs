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
using GreatFriends.ThaiBahtText;

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
        }

        //private void LoadReport()
        //{
        //    reportViewer1.ProcessingMode = ProcessingMode.Local;

        //    //string date = "16/11/2017";
        //    //DateTime dt = Convert.ToDateTime(date);

        //    //GetSalesOrderData(dt,  3);
        //}

        #region GET REPORT DATA
        private void GetSalesOrderData(DateTime date, int customer)
        {
            using (var dailydb = new OrderEntities())
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
            }
        }

        private void GetReceiveReportData(DateTime date, int customer)
        {
            //string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;

            //using (var dailydb = new OrderEntities())
            //{
            //    var ds1 = (from x in dailydb.vwCustomerDetail
            //               where x.CustomerID == customer
            //               select x).ToList();
            //    var ds2 = dailydb.GetOrderbyDay(date, customer).ToList();
            //    if (ds1.Count() > 0 && ds2.Count() > 0)
            //    {
            //        ReportParameter p1 = new ReportParameter("ReportType", ReportName);
            //        ReportParameter p2 = new ReportParameter("Date", RptDatePicker.Value.ToLongDateString());
            //        ReportParameter p3 = new ReportParameter("DocumentNo", "INV");


            //        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

            //        CustomerBindingSource.DataSource = HelperCS.ToDataTable(ds1);
            //        OrderBindingSource.DataSource = HelperCS.ToDataTable(ds2);
            //        ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", CustomerBindingSource);
            //        ReportDataSource rtpsource2 = new ReportDataSource("DataSet2", OrderBindingSource);
            //        reportViewer1.LocalReport.DataSources.Add(rtpsource1);
            //        reportViewer1.LocalReport.DataSources.Add(rtpsource2);
            //    }
            //    else
            //    {
            //        OrderBindingSource.DataSource = null;
            //    }
            //}
        }
        private void GetInvoiceReportData(DateTime date, int customer)
        {
            string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;
            
            using (var dailydb = new OrderEntities())
            {
                var ds1 = (from x in dailydb.vwCustomerDetail
                              where x.CustomerID == customer
                              select x).ToList();
                var ds2 = dailydb.GetOrderbyDay(date, customer).ToList();
                if (ds1.Count() > 0 && ds2.Count() > 0)
                {

                    ReportParameter p1 = new ReportParameter("ReportType", ReportName);
                    ReportParameter p2 = new ReportParameter("Date", RptDatePicker.Value.ToLongDateString());
                    ReportParameter p3 = new ReportParameter("DocumentNo", "INV");
                    ReportParameter p4 = new ReportParameter("BahtText", BahtToText(ds2));

                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });

                    CustomerBindingSource.DataSource = HelperCS.ToDataTable(ds1);
                    OrderBindingSource.DataSource = HelperCS.ToDataTable(ds2);
                    ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", CustomerBindingSource);
                    ReportDataSource rtpsource2 = new ReportDataSource("DataSet2", OrderBindingSource);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource1);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource2);
                }
                else
                {
                    OrderBindingSource.DataSource = null;
                }
            }
        }

        private string BahtToText(List<GetOrderbyDay_Result> dataset)
        {
            string BahtText = "";
            if(dataset.Count > 0)
            {
                decimal? total = dataset.Sum(item => item.OrderTotal);
                if(total != null)
                {
                    BahtText = total.ThaiBahtText(UsesEt.TensOnly);
                }
                else
                {
                    BahtText = "";
                }
            }
            return BahtText;
        }

        private void GetInvoiceTransportReportData(DateTime date, int customer)
        {
            //string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;

            //using (var dailydb = new OrderEntities())
            //{
            //    var ds1 = (from x in dailydb.vwCustomerDetail
            //               where x.CustomerID == customer
            //               select x).ToList();
            //    var ds2 = dailydb.GetOrderbyDay(date, customer).ToList();
            //    if (ds1.Count() > 0 && ds2.Count() > 0)
            //    {
            //        ReportParameter p1 = new ReportParameter("ReportType", ReportName);
            //        ReportParameter p2 = new ReportParameter("Date", RptDatePicker.Value.ToLongDateString());
            //        ReportParameter p3 = new ReportParameter("DocumentNo", "INV");


            //        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

            //        CustomerBindingSource.DataSource = HelperCS.ToDataTable(ds1);
            //        OrderBindingSource.DataSource = HelperCS.ToDataTable(ds2);
            //        ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", CustomerBindingSource);
            //        ReportDataSource rtpsource2 = new ReportDataSource("DataSet2", OrderBindingSource);
            //        reportViewer1.LocalReport.DataSources.Add(rtpsource1);
            //        reportViewer1.LocalReport.DataSources.Add(rtpsource2);
            //    }
            //    else
            //    {
            //        OrderBindingSource.DataSource = null;
            //    }
            //}
        }
        private void GetInvoiceTruckReportData(DateTime date, int customer)
        {
            //string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;

            //using (var dailydb = new OrderEntities())
            //{
            //    var ds1 = (from x in dailydb.vwCustomerDetail
            //               where x.CustomerID == customer
            //               select x).ToList();
            //    var ds2 = dailydb.GetOrderbyDay(date, customer).ToList();
            //    if (ds1.Count() > 0 && ds2.Count() > 0)
            //    {
            //        ReportParameter p1 = new ReportParameter("ReportType", ReportName);
            //        ReportParameter p2 = new ReportParameter("Date", RptDatePicker.Value.ToLongDateString());
            //        ReportParameter p3 = new ReportParameter("DocumentNo", "INV");


            //        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

            //        CustomerBindingSource.DataSource = HelperCS.ToDataTable(ds1);
            //        OrderBindingSource.DataSource = HelperCS.ToDataTable(ds2);
            //        ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", CustomerBindingSource);
            //        ReportDataSource rtpsource2 = new ReportDataSource("DataSet2", OrderBindingSource);
            //        reportViewer1.LocalReport.DataSources.Add(rtpsource1);
            //        reportViewer1.LocalReport.DataSources.Add(rtpsource2);
            //    }
            //    else
            //    {
            //        OrderBindingSource.DataSource = null;
            //    }
            //}
        }
        #endregion GET REPORT DATA

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
                ChooseReport(int.Parse(ReportNamekey), currentdate, cusid);
            }
        }

        private void ChooseReport(int reportid, DateTime date, int cid)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            switch (reportid)
            {
                case 1:
                    {
                        //reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.Receive.rdlc";
                        //GetReceiveReportData(date, cid);
                        break;
                    }
                case 2:
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.Invoice.rdlc";
                        GetInvoiceReportData(date, cid);
                        break;
                    }
                case 3:
                    {
                        //reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.InvoiceTransport.rdlc";
                        //GetInvoiceTransportReportData(date, cid);
                        break;
                    }
                case 4:
                    {
                        //reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.InvoiceTruck.rdlc";
                        //GetInvoiceTruckReportData(date, cid);
                        break;
                    }
            }
            reportViewer1.RefreshReport();
        }
    }
}
