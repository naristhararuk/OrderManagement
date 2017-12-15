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

namespace OrderManagement
{
    public partial class CustomerUC :  UserControl
    {
        //private object result;
        private int pagesize = 2;
        public CustomerUC()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ddlCustomer, "Customer");
            HelperCS.AutoCompleteLoadValues(ddlCustomerZone, "Config-Zone");
            BindProductData(1);
        }
        private void CustomerUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            //lblValid.Text = "";
            
        }
       
        #region BIND DATA
        //private void BindAllCustomerData()
        //{
        //    using (var db = new OrderEntities())
        //    {
        //        List<Customer> result = (from x in db.Customer where x.Status == true select x).ToList();
        //        if (result.Count() > 0)
        //        {
        //            CustomerGrid.DataSource = HelperCS.ToDataTable(result);
        //            CustomerGrid.AllowUserToAddRows = false;
        //            //lblValid.Text = "";
        //        }
        //        else
        //        {
        //            //lblValid.Text = "** ไม่พบข้อมูลที่ค้นหา";
        //        }
        //    }
        //}

        private void BindProductData(int pageindex)
        {
            string Customerkey = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Key;
            string Zonekey = ((KeyValuePair<string, string>)ddlCustomerZone.SelectedItem).Key;
            List<GetCustomerSearch_Result> result;
            using (var db = new OrderEntities())
            {
                if (Zonekey != "" && Customerkey != "")
                {
                    int id = int.Parse(Customerkey);
                    int zone = int.Parse(Zonekey);
                    result = db.GetCustomerSearch(id, zone, pageindex, pagesize).ToList();
                }
                else if (Zonekey != "" && Customerkey == "")
                {
                    int zone = int.Parse(Zonekey);
                    result = db.GetCustomerSearch(null, zone, pageindex, pagesize).ToList();
                }
                else if (Zonekey == "" && Customerkey != "")
                {
                    int id = int.Parse(Customerkey);
                    result = db.GetCustomerSearch(id, null, pageindex, pagesize).ToList();
                }
                else
                {
                    //search all
                    result = db.GetCustomerSearch(null, null, pageindex, pagesize).ToList();
                }

                if (result.Count() > 0)
                {
                    CustomerGrid.DataSource = HelperCS.ToDataTable(result);
                    CustomerGrid.AllowUserToAddRows = false;
                    this.PopulatePager(result.Count(), pageindex);
                }
                else
                {
                    //lblValid.Text = "** ไม่พบข้อมูลที่ค้นหา";
                    MessageBox.Show("ไม่พบข้อมูลลูกค้าที่ค้นหา", "ค้นหาข้อมูลลูกค้า", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion BIND DATA

        #region EVENT CLICK
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            BindProductData(1);
        }
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            //call popup from parent Form
            Form1 frm = this.FindForm() as Form1;
            frm.callControlPopup("CustomerManageUC");
            BindProductData(1);
            //https://www.codeproject.com/Articles/16303/DataGrid-Paging-C-Windows-Forms link paging grid
            //https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-bind-data-to-the-windows-forms-datagridview-control
        }
        private void CustomerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                //get if from grid column
                //int id = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value);
                CustomerManageUC.customerid = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value);
                //do you staff.
            }
            // get value customerid
            //CustomerManageUC.customerid = 
            Form1 frm = this.FindForm() as Form1;
            frm.callControlPopup("CustomerManageUC");
            BindProductData(1);
        }
        #endregion EVENT CLICK

        #region PAGING
        private void PopulatePager(int recordCount, int currentPage)
        {
            List<Page> pages = new List<Page>();
            int startIndex, endIndex;
            int pagerSpan = 5;

            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pagesize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "First", Value = "1" });
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
            }

            //Add Page Number
            //for (int i = startIndex; i <= endIndex; i++)
            //{
            //    pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage });
            //}

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new Page { Text = "Last", Value = pageCount.ToString() });
            }

            //Clear existing Pager Buttons.
            pnlPager.Controls.Clear();

            //Loop and add Buttons for Pager.
            int count = 0;
            foreach (Page page in pages)
            {
                Button btnPage = new Button();
                btnPage.Location = new System.Drawing.Point(38 * count, 5);
                btnPage.Size = new System.Drawing.Size(35, 20);
                btnPage.Name = page.Value;
                btnPage.Text = page.Text;
                btnPage.Enabled = !page.Selected;
                btnPage.Click += new System.EventHandler(this.Page_Click);
                pnlPager.Controls.Add(btnPage);
                count++;
            }
        }
        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            this.BindProductData(int.Parse(btnPager.Name));
        }
        public class Page
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }
        #endregion PAGING
    }
}
