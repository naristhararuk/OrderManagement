using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement.Class;
using OrderManagement.Entity;
using Microsoft.Reporting.WinForms;
using GreatFriends.ThaiBahtText;
using System.IO;

namespace OrderManagement.User_Control
{
    public partial class ReportViewerUC : UserControl
    {
        public DateTime datewhere;
        public int customerid;
        private List<GetOrderCustomer_Result> ds1;

        public ReportViewerUC()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ddlCustomer, "Customer");
            HelperCS.AutoCompleteLoadValues(ddlReportName, "Config-ReportName");
        }

        private void ReportViewerUC_Load(object sender, EventArgs e)
        {

        }

        #region GET REPORT DATA
        
        private void GetReceiveReportData(DateTime date, int customer)
        {
            string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;

            using (var dailydb = new OrderEntities())
            {
                //var ds1 = (from x in dailydb.vwCustomerDetail
                //           where x.CustomerID == customer
                //           select x).ToList();
                List<GetOrderCustomer_Result> ds1 = null;
                List<GetOrderbyDay_Result> ds2 = null;
                ds1 = dailydb.GetOrderCustomer(date, customer, "RCD").ToList();
                ds2 = dailydb.GetOrderbyDay(date, customer).ToList();
                
                if (ds1.Count() > 0 && ds2.Count() > 0)
                {
                    string datestring = HelperCS.DateTextThai(DateTime.Now, "TH", "dd MMM yyyy");
                    ReportParameter p1 = new ReportParameter("ReportType", ReportName);
                    //ReportParameter p2 = new ReportParameter("Date", RptDatePicker.Value.ToLongDateString());
                    ReportParameter p2 = new ReportParameter("Date", datestring);
                    ReportParameter p3 = new ReportParameter("BahtText", BahtToText(ds2.Sum(item => item.OrderTotal)));

                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

                    CustomerBindingSource.DataSource = HelperCS.ToDataTable(ds1);
                    OrderBindingSource.DataSource = HelperCS.ToDataTable(ds2);
                    ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", CustomerBindingSource);
                    ReportDataSource rtpsource2 = new ReportDataSource("DataSet2", OrderBindingSource);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource1);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource2);
                }
                else
                {
                    CustomerBindingSource.DataSource = null;
                    OrderBindingSource.DataSource = null;
                }
            }
        }
        private void GetReceiveWeeklyReportData(DateTime date, int customer,bool showprice)
        {
            string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;

            using (var dailydb = new OrderEntities())
            {
                List<GetOrderCustomer_Result> ds1 = null;
                List <GetReceiveWeeklyPrice_Result> ds2 = null;
                List<GetReceiveWeekly_Result> ds3 = null;
                ds1 = dailydb.GetOrderCustomer(date, customer,"RCD").ToList();
                bool rowno = false;
                string bahttext = "";
                DataTable dtorder;
                if (showprice)
                {
                    ds2 = dailydb.GetReceiveWeeklyPrice(date, customer).ToList();
                    rowno = ds2.Count() > 0 ? true : false;
                    bahttext = rowno ? BahtToText(ds2.Sum(item => item.total)) : "";
                    dtorder = HelperCS.ToDataTable(ds2);
                }
                else
                {
                    ds3 = dailydb.GetReceiveWeekly(date, customer).ToList();
                    rowno = ds3.Count() > 0 ? true : false;
                    bahttext = rowno ? BahtToText(ds3.Sum(item => item.total)) : "";
                    dtorder = HelperCS.ToDataTable(ds3);
                }
                //string datestring = HelperCS.DateTextThai(RptDatePicker.Value,"TH","dd MMM yyyy");
                string datestring = HelperCS.DateTextThai(DateTime.Now, "TH", "dd MMM yyyy");

                if (ds1.Count() > 0 && rowno)
                {
                    CustomerBindingSource.DataSource = HelperCS.ToDataTable(ds1);
                    OrderBindingSource.DataSource = dtorder;

                    //string sunday =  dt.Rows[i].Field<int>(j);
                    DateTime startdate = (from c in ds1 select  (DateTime)c.OrderStartDate ).FirstOrDefault();
                    string docid = (from c in ds1 select (string)c.DocumentID).FirstOrDefault();

                    ReportParameter p1 = new ReportParameter("ReportType", ReportName);
                    ReportParameter p2 = new ReportParameter("Date", datestring);
                    ReportParameter p3 = new ReportParameter("BahtText", bahttext);

                    ReportParameter p4 = new ReportParameter("suntext", HelperCS.DateTextThai(startdate,"TH","dd-MMM"));
                    ReportParameter p5 = new ReportParameter("montext", HelperCS.DateTextThai(startdate.AddDays(1), "TH", "dd-MMM"));
                    ReportParameter p6 = new ReportParameter("tuetext", HelperCS.DateTextThai(startdate.AddDays(2), "TH", "dd-MMM"));
                    ReportParameter p7 = new ReportParameter("wedtext", HelperCS.DateTextThai(startdate.AddDays(3), "TH", "dd-MMM"));
                    ReportParameter p8 = new ReportParameter("thrtext", HelperCS.DateTextThai(startdate.AddDays(4), "TH", "dd-MMM"));
                    ReportParameter p9 = new ReportParameter("fritext", HelperCS.DateTextThai(startdate.AddDays(5), "TH", "dd-MMM"));
                    ReportParameter p10 = new ReportParameter("sattext", HelperCS.DateTextThai(startdate.AddDays(6), "TH", "dd-MMM"));

                    ReportParameter p11 = new ReportParameter("DocumentID", docid);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,p11 });

                    
                    ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", CustomerBindingSource);
                    ReportDataSource rtpsource2 = new ReportDataSource("DataSet2", OrderBindingSource);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource1);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource2);
                }
                else
                {
                    CustomerBindingSource.DataSource = null;
                    OrderBindingSource.DataSource = null;
                }
            }
        }
        private void GetInvoiceReportData(DateTime date, int customer)
        {
            string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;

            using (var dailydb = new OrderEntities())
            {
                //var ds1 = (from x in dailydb.vwCustomerDetail
                //           where x.CustomerID == customer
                //           select x).ToList();
                List<GetOrderCustomer_Result> ds1 = null;
                List<GetOrderbyDay_Result> ds2 =  null;
                ds1 = dailydb.GetOrderCustomer(date, customer, "INV").ToList();
                ds2 = dailydb.GetOrderbyDay(date, customer).ToList();
                if (ds1.Count() > 0 && ds2.Count() > 0)
                {
                    string docid = (from c in ds1 select (string)c.DocumentID).FirstOrDefault();
                    string datestring = HelperCS.DateTextThai(date, "TH", "dd MMM yyyy");
                    ReportParameter p1 = new ReportParameter("ReportType", ReportName);
                    //ReportParameter p2 = new ReportParameter("Date", RptDatePicker.Value.ToLongDateString());
                    ReportParameter p2 = new ReportParameter("Date", datestring);
                    ReportParameter p3 = new ReportParameter("BahtText", BahtToText(ds2.Sum(item => item.OrderTotal)));
                    ReportParameter p4 = new ReportParameter("DocumentID", docid);

                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3,p4 });
                    CustomerBindingSource.DataSource = null;
                    OrderBindingSource.DataSource = null;
                    CustomerBindingSource.DataSource = HelperCS.ToDataTable(ds1);
                    OrderBindingSource.DataSource = HelperCS.ToDataTable(ds2);
                    ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", CustomerBindingSource);
                    ReportDataSource rtpsource2 = new ReportDataSource("DataSet2", OrderBindingSource);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource1);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource2);
                }
                else
                {
                    CustomerBindingSource.DataSource = null;
                    OrderBindingSource.DataSource = null;
                }
            }
        }
        //private string BahtToText(List<GetOrderbyDay_Result> dataset)
        //{
        //    string BahtText = "";
        //    if (dataset.Count > 0)
        //    {
        //        decimal? total = dataset.Sum(item => item.OrderTotal);
        //        if (total != null)
        //        {
        //            BahtText = total.ThaiBahtText(UsesEt.TensOnly);
        //        }
        //        else
        //        {
        //            BahtText = "";
        //        }
        //    }
        //    return BahtText;
        //}
        private string BahtToText(decimal? total)
        {
            string BahtText = "";
            if (total != null)
            {
                BahtText = total.ThaiBahtText(UsesEt.TensOnly);
            }
            else
            {
                BahtText = "";
            }
            return BahtText;
        }
        private void GetProductTransportReportData(DateTime date, int customerzone)
        {
            string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;
            string driver = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Value;
            using (var dailydb = new OrderEntities())
            {
                var ds = dailydb.GetProductTransport(date, customerzone).ToList();
                
                if (ds.Count() > 0 )
                {
                    string datestring = HelperCS.DateTextThai(date, "TH", "dd MMM yyyy");
                    string day = HelperCS.daythai[(int)date.DayOfWeek -1];
                    ReportParameter p1 = new ReportParameter("Date", datestring);
                    //ReportParameter p1 = new ReportParameter("Date", date.ToString("yyyy-MM-dd"));
                    ReportParameter p2 = new ReportParameter("Zone", driver);
                    ReportParameter p3 = new ReportParameter("ReportName", ReportName);
                    ReportParameter p4 = new ReportParameter("Day", day);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
                    OrderBindingSource.DataSource = HelperCS.ToDataTable(ds);
                    ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", OrderBindingSource);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource1);
                }
                else
                {
                    OrderBindingSource.DataSource = null;
                }
            }
        }
        private void GetCustomerTransportReportData(DateTime date, int customerzone)
        {
            string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;
            string driver = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Value;
            using (var dailydb = new OrderEntities())
            {
                List<GetCustomerTransport_Result> ds = null;
                ds = dailydb.GetCustomerTransport(date, customerzone).ToList();

                if (ds.Count() > 0 )
                {
                    string datestring = HelperCS.DateTextThai(date, "TH", "dd MMM yyyy");
                    string day = HelperCS.daythai[(int)date.DayOfWeek - 1];
                    ReportParameter p1 = new ReportParameter("Date", datestring);

                    //ReportParameter p1 = new ReportParameter("Date", date.ToString("yyyy-MM-dd"));
                    ReportParameter p2 = new ReportParameter("Driver", driver);
                    ReportParameter p3 = new ReportParameter("Zone", customerzone.ToString());
                    ReportParameter p4 = new ReportParameter("ReportName", ReportName);
                    ReportParameter p5 = new ReportParameter("Day", day);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5 });
                    OrderBindingSource.DataSource = HelperCS.ToDataTable(ds);
                    ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", OrderBindingSource);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource1);
                }
                else
                {
                    OrderBindingSource.DataSource = null;
                }
            }
        }

        private void GetCustomerTransportTofuReportData(DateTime date)
        {
            string ReportName = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Value;
            using (var dailydb = new OrderEntities())
            { 
                List<GetCustomerTransportTofu_Result> ds = null; 
                ds = dailydb.GetCustomerTransportTofu(date).ToList();

                if (ds.Count() > 0)
                {
                    string datestring = HelperCS.DateTextThai(date, "TH", "dd MMM yyyy");
                    string day = HelperCS.daythai[(int)date.DayOfWeek - 1];
                    ReportParameter p1 = new ReportParameter("Date", datestring);
                    ReportParameter p2 = new ReportParameter("ReportName", ReportName);
                    ReportParameter p3 = new ReportParameter("Day", day);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                    OrderBindingSource.DataSource = HelperCS.ToDataTable(ds);
                    ReportDataSource rtpsource1 = new ReportDataSource("DataSet1", OrderBindingSource);
                    reportViewer1.LocalReport.DataSources.Add(rtpsource1);
                }
                else
                {
                    OrderBindingSource.DataSource = null;
                }
            }
        }
        #endregion GET REPORT DATA

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            string Customerkey = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Key;
            string ReportNamekey = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Key;
            CustomerBindingSource.DataSource = null;
            OrderBindingSource.DataSource = null;
            //string value = ((KeyValuePair<string, string>)RptCustomer.SelectedItem).Value;
            if (Customerkey == "" && ddlReportName.SelectedIndex != 5)
            {
                    if (ddlReportName.SelectedIndex == 3 || ddlReportName.SelectedIndex == 4)
                        MessageBox.Show("กรุณาเลือกพื้นที่ส่งสินค้าก่อน", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
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
                //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                
                //DateTime currentdate = RptDatePicker.Value;
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                DateTime currentdate = Convert.ToDateTime(RptDatePicker.Value, culture);

                int cusid = ddlReportName.SelectedIndex != 0 && ddlReportName.SelectedIndex != 5 ? int.Parse(Customerkey) : 0;
                ChooseReport(int.Parse(ReportNamekey), currentdate, cusid);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.RefreshReport();
            }
        }

        private void ChooseReport(int reportid, DateTime date, int cid)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportEmbeddedResource = "";
            reportViewer1.LocalReport.DataSources.Clear();
            //string exeFolder = Application.StartupPath;
            //string reportPath;
            switch (reportid)
            {
                case 1:
                    {
                        //reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.Receive.rdlc";
                        //GetReceiveReportData(date, cid);
                        using (var dailydb = new OrderEntities())
                        {
                            bool showprice = (from c in dailydb.Customer
                                              where c.CustomerID == cid && c.ShowPrice == true
                                              select c).Any();
                            if (showprice)
                            {
                                reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.ReceiveWeeklyPrice.rdlc";
                                GetReceiveWeeklyReportData(date, cid, true);
                            }
                            else
                            {
                                reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.ReceiveWeekly.rdlc";
                                GetReceiveWeeklyReportData(date, cid, false);
                            }
                        }

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
                        reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.CustomerTransport.rdlc";
                        GetCustomerTransportReportData(date,cid);
                        break;
                    }
                case 4:
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.ProductTransport.rdlc";
                        GetProductTransportReportData(date, cid);
                        break;
                    }
                case 5:
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "OrderManagement.Report.CustomerTransportTofu.rdlc";
                        GetCustomerTransportTofuReportData(date);
                        break;
                    }
            }
        }

        private void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ReportNamekey = ((KeyValuePair<string, string>)ddlReportName.SelectedItem).Key;
            if(ReportNamekey != "")
            {
                if (ddlReportName.SelectedIndex == 1 || ddlReportName.SelectedIndex == 2 )
                {
                    lblCustomer.Visible = true;
                    ddlCustomer.Visible = true;
                    lblCustomer.Text = "รายชื่อลูกค้า";
                    HelperCS.AutoCompleteLoadValues(ddlCustomer, "Customer");
                }
                else if (ddlReportName.SelectedIndex == 3 || ddlReportName.SelectedIndex == 4)
                {
                    lblCustomer.Visible = true;
                    ddlCustomer.Visible = true;
                    lblCustomer.Text = "พื้นที่ส่งสินค้า";
                    HelperCS.AutoCompleteLoadValues(ddlCustomer, "Config-Zone");
                }
                else if (ddlReportName.SelectedIndex == 5 )
                {
                    lblCustomer.Visible = false;
                    ddlCustomer.Visible = false;
                    lblCustomer.Text = "";
                    //HelperCS.AutoCompleteLoadValues(ddlCustomer, "Config-Zone");
                }
                else{
                    lblCustomer.Visible = false;
                    ddlCustomer.Visible = false;
                    lblCustomer.Text = "";
                }
            }
            else
            {

            }
            
        }


    }
}
