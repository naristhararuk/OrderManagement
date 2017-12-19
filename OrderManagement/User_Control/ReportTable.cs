using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using OrderManagement.Class;
using MetroFramework.Controls;

namespace OrderManagement.User_Control
{
    public partial class ReportTable : UserControl
    {
        private int mintTotalRecords = 0;
        private int mintPageSize = 0;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;
        private string constring = ConfigurationManager.ConnectionStrings["OrderConnectionString"].ConnectionString;
        public ReportTable()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ddlCustomer, "Customer");
            HelperCS.AutoCompleteLoadValues(ddlCustomerZone, "Config-Zone");
            BindPageSize();
        }
        private void BindPageSize()
        {
            string[] sizevalue = { "5", "10", "15", "20", "25" };
            ddlPageSize.Items.AddRange(sizevalue);
            ddlPageSize.SelectedIndex = 3;
        }
        private void AddButtonGrid()
        {
            DataGridViewButtonColumn ReceiveColumn = new DataGridViewButtonColumn();
            ReceiveColumn.Name = "Receive";
            ReceiveColumn.Text = "พิมพ์";
            //ReceiveColumn.FlatStyle = FlatStyle.Standard;
            ReceiveColumn.CellTemplate.Style.BackColor = Color.AliceBlue;
            ReceiveColumn.UseColumnTextForButtonValue = true;
            int columnIndex = 6;
            if (ReportGrid.Columns["Receive"] == null)
            {
                ReportGrid.Columns.Insert(columnIndex, ReceiveColumn);
            }
            DataGridViewButtonColumn InvoiceColumn = new DataGridViewButtonColumn();
            InvoiceColumn.Name = "Invoice";
            InvoiceColumn.Text = "พิมพ์";
            InvoiceColumn.UseColumnTextForButtonValue = true;
            if (ReportGrid.Columns["Invoice"] == null)
            {
                ReportGrid.Columns.Insert(7, InvoiceColumn);
            }
            DataGridViewButtonColumn DeliveryColumn = new DataGridViewButtonColumn();
            DeliveryColumn.Name = "Delivery";
            DeliveryColumn.Text = "พิมพ์";
            DeliveryColumn.UseColumnTextForButtonValue = true;
            if (ReportGrid.Columns["Delivery"] == null)
            {
                ReportGrid.Columns.Insert(8, DeliveryColumn);
            }
            DataGridViewButtonColumn TransportColumn = new DataGridViewButtonColumn();
            TransportColumn.Name = "Transport";
            TransportColumn.Text = "พิมพ์";
            TransportColumn.UseColumnTextForButtonValue = true;
            if (ReportGrid.Columns["Transport"] == null)
            {
                ReportGrid.Columns.Insert(9, TransportColumn);
            }
            //create an event:
            //ReportGrid.CellClick += new DataGridViewCellEventHandler(ReportGrid_CellClick);
        }

        #region BIND GRID
        private void fillGrid()
        {
            // For Page view.
            string pagesize = (ddlPageSize.SelectedIndex > 0) ? ddlPageSize.SelectedItem.ToString() : "5";
            this.mintPageSize = int.Parse(pagesize);
            this.mintTotalRecords = getCount();
            this.mintPageCount = this.mintTotalRecords / this.mintPageSize;

            // Adjust page count if the last page contains partial page.
            if (this.mintTotalRecords % this.mintPageSize > 0)
                this.mintPageCount++;

            this.mintCurrentPage = 0;

            loadPage();
        }
        private int getCount()
        {
            string sql = "";
            int intCount = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                sql = "SELECT COUNT(*) Record FROM( SELECT o.[OrderDate], o.[CustomerID] FROM[Order].[dbo].[Order] o ";
                sql += " JOIN[Order].[dbo].[Customer] c ON c.CustomerID = o.CustomerID WHERE o.OrderStatus = 1 "; 
                if (ddlCustomerZone.SelectedIndex > 0)
                {
                    string cuszone = ((KeyValuePair<string, string>)ddlCustomerZone.SelectedItem).Key;
                    sql += " AND c.[Zone] = " + cuszone;
                }
                if (RptDatePicker.Text != "")
                {
                    //DateTime pickdate = RptDatePicker.Value;
                    sql += " AND CONVERT(DATE, o.[OrderDate]) = '" + RptDatePicker.Value.ToString("yyyy-MM-dd") +"'";
                }
                sql += " GROUP BY o.[OrderDate], o.[CustomerID]) t "; 
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    intCount = (int)cmd.ExecuteScalar();
                }
                con.Close();
            }
            lblRecordCount.Text = intCount.ToString() + " เรคอร์ด";
            return intCount;
        }
        private void loadPage()
        {
            string sql = "", sql1 = "", sql2 = "";
            int intSkip = 0;

            intSkip = (this.mintCurrentPage * this.mintPageSize);

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                sql = "SELECT TOP " + this.mintPageSize + " o.[CustomerID],c.[CustomerName],o.[OrderDate],COUNT(o.[ProductID]) TotalProduct,SUM(o.[OrderTotal]) TotalPrice ,c.[Zone] ";
                sql +=" FROM[Order].[dbo].[Order] o JOIN[Order].[dbo].[Customer] c ON c.CustomerID = o.CustomerID WHERE o.OrderStatus = 1";
                
                if (ddlCustomerZone.SelectedIndex > 0)
                {
                    string cuszone = ((KeyValuePair<string, string>)ddlCustomerZone.SelectedItem).Key;
                    sql1 = " AND c.[Zone] = " + cuszone;
                    sql += sql1;
                }
                else
                {
                    sql1 = "";
                }
                if (RptDatePicker.Text != "")
                {
                    //DateTime pickdate = RptDatePicker.Value;
                    sql2 = " AND CONVERT(DATE, o.[OrderDate]) = '" + RptDatePicker.Value.ToString("yyyy-MM-dd") + "'";
                    sql += sql2;
                }
                else
                {
                    sql2 = "";
                }
                sql += " AND o.[CustomerID] NOT IN " +
                "(SELECT TOP " + intSkip + " o.[CustomerID] FROM [Order].[dbo].[Order] o JOIN[Order].[dbo].[Customer] c ON c.CustomerID = o.CustomerID WHERE o.OrderStatus = 1 "+
                sql1 + sql2 + " GROUP BY o.[OrderDate],o.[CustomerID],c.[CustomerName],c.[Zone] )";

                sql += " GROUP BY o.[OrderDate],o.[CustomerID],c.[CustomerName],c.[Zone]";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    ReportGrid.DataSource = dt;
                    ReportGrid.AllowUserToAddRows = false;
                    AddButtonGrid();
                    // Show Status
                    txtPage.Text = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString() + "  หน้า";
                }
                con.Close();
            }
        }
        #endregion BIND GRID

        #region PAGING
        private void btnPageFirst_Click(object sender, EventArgs e)
        {
            this.mintCurrentPage = 0;
            loadPage();
        }
        private void btnPagePrevious_Click(object sender, EventArgs e)
        {
            if (this.mintCurrentPage == this.mintPageCount)
                this.mintCurrentPage = this.mintPageCount - 1;

            this.mintCurrentPage--;

            if (this.mintCurrentPage < 1)
                this.mintCurrentPage = 0;

            loadPage();
        }
        private void btnPageNext_Click(object sender, EventArgs e)
        {
            this.mintCurrentPage++;

            if (this.mintCurrentPage > (this.mintPageCount - 1))
                this.mintCurrentPage = this.mintPageCount - 1;

            loadPage();
        }
        private void btnPageLast_Click(object sender, EventArgs e)
        {
            this.mintCurrentPage = this.mintPageCount - 1;

            loadPage();
        }
        private void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }
        #endregion PAGING

        #region EVENT CLICK
        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            fillGrid();
        }
        private void ReportGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DateTime date = RptDatePicker.Value;
            if (dgv.CurrentRow.Selected)
            {
                int cusid = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value);
                if (e.ColumnIndex == dgv.Columns["Receive"].Index)
                {
                    MessageBox.Show("Do you want to print Receive the row?" + date.ToShortDateString() + cusid.ToString());
                }
                else if (e.ColumnIndex == dgv.Columns["Invoice"].Index)
                {
                    MessageBox.Show("Do you want to print Invoice the row?" + date.ToShortDateString() + cusid.ToString());
                }
                else if (e.ColumnIndex == dgv.Columns["Delivery"].Index)
                {
                    MessageBox.Show("Do you want to print Delivery the row?" + date.ToShortDateString() + cusid.ToString());
                }
                else if (e.ColumnIndex == dgv.Columns["Transport"].Index)
                {
                    MessageBox.Show("Do you want to print Transport the row?" + date.ToShortDateString() + cusid.ToString());
                }
            }
        }
        #endregion EVENT CLICK

        
    }
}
