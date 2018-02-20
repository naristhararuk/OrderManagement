using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement.User_Control;
using OrderManagement.Class;
using OrderManagement.Entity;
using MetroFramework.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace OrderManagement
{
    public partial class CustomerUC :  UserControl
    {
        private int mintTotalRecords = 0;
        private int mintPageSize = 0;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;
        private string constring = ConfigurationManager.ConnectionStrings["OrderConnectionString"].ConnectionString;
        public CustomerUC()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ddlCustomer, "Customer");
            HelperCS.AutoCompleteLoadValues(ddlCustomerZone, "Config-Zone");
            BindPageSize();
            fillGrid();
        }

        private void CustomerUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
        private void BindPageSize()
        {
            string[] sizevalue = { "10", "15", "20", "30", "50" };
            ddlPageSize.Items.AddRange(sizevalue);
            ddlPageSize.SelectedIndex = 0;
        }
        #region BIND DATA
        private void fillGrid()
        {
            // For Page view.
            string pagesize = (ddlPageSize.SelectedIndex > 0) ? ddlPageSize.SelectedItem.ToString() : "10";
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
                sql = "SELECT COUNT(*)  FROM Customer WHERE Status = 1";
                if (ddlCustomer.SelectedIndex > 0)
                {
                    string cusid = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Key;
                    sql += " AND CustomerID = " + int.Parse(cusid);
                }
                if (ddlCustomerZone.SelectedIndex > 0)
                {
                    string zone = ((KeyValuePair<string, string>)ddlCustomerZone.SelectedItem).Key;
                    sql += " AND Zone = " + int.Parse(zone);
                }
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    intCount = (int)cmd.ExecuteScalar();
                }
                con.Close();
            }
            lblRecordCount.Text = intCount.ToString() + " คน";
            return intCount;
        }
        private void loadPage()
        {
            string sql = "";
            int intSkip = 0;

            intSkip = (this.mintCurrentPage * this.mintPageSize);

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                sql = "SELECT TOP " + this.mintPageSize + " * FROM Customer WHERE Status = 1";
                if (ddlCustomer.SelectedIndex > 0)
                {
                    string cusid = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Key;
                    sql += " AND CustomerID = " + int.Parse(cusid);
                }
                if (ddlCustomerZone.SelectedIndex > 0)
                {
                    string zone = ((KeyValuePair<string, string>)ddlCustomerZone.SelectedItem).Key;
                    sql += " AND Zone = " + int.Parse(zone);
                }
                sql += " AND CustomerID NOT IN " +
                "(SELECT TOP " + intSkip + " CustomerID FROM Customer)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    CustomerGrid.DataSource = dt;
                    CustomerGrid.AllowUserToAddRows = false;
                    // Show Status
                    txtPage.Text = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString() + "  หน้า";
                }
                con.Close();
            }
        }
        #endregion BIND DATA

        #region EVENT CLICK
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            fillGrid();
        }
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            //call popup from parent Form
            Form1 frm = this.FindForm() as Form1;
            frm.callControlPopup("CustomerManageUC");
            fillGrid();
            //https://www.codeproject.com/Articles/16303/DataGrid-Paging-C-Windows-Forms link paging grid
        }
        private void CustomerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                //set customerid in user control from grid column click
                CustomerManageUC.customerid = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value);
            }

            Form1 frm = this.FindForm() as Form1;
            frm.callControlPopup("CustomerManageUC");
            fillGrid();
        }
        #endregion EVENT CLICK

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
    }
}
