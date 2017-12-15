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
using System.Data.Entity.Core.Objects;
using MetroFramework.Controls;

namespace OrderManagement.User_Control
{
    public partial class ProductUC : UserControl
    {
        private object aa;
        private int pagesize = 10;
        public ProductUC()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ddlProduct, "Product");
            HelperCS.AutoCompleteLoadValues(ddlProductCategory, "Config-ProductCategory");
        }
        private void ProductUC_Load(object sender, EventArgs e)
        {
            //lblValid.Text = "";
            BindProductData(1);
        }
        
        //private void BindAllProductData()
        //{
        //    using (var db = new OrderEntities())
        //    {
        //        List<Product> result = (from x in db.Product where x.Status == true select x).ToList();
        //        if (result.Count() > 0)
        //        {
        //            //ProductGrid.DataSource = HelperCS.ToDataTable(result);
        //            //ProductGrid.AllowUserToAddRows = false;
        //            lblValid.Text = "";
        //            //int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
        //            //this.PopulatePager(recordCount, pageIndex);
        //            BindGridPaging(HelperCS.ToDataTable(result), 10,false);
        //        }
        //        else
        //        {
        //            lblValid.Text = "** ไม่พบข้อมูลที่ค้นหา";
        //        }
        //    }
        //}
        #region BIND DATA
        private void BindProductData(int pageindex)
        {
            string Productkey = ((KeyValuePair<string, string>)ddlProduct.SelectedItem).Key;
            string Categorykey = ((KeyValuePair<string, string>)ddlProductCategory.SelectedItem).Key;
            List<GetProductSearch_Result> result;
            using (var db = new OrderEntities())
            {
                if (Categorykey != "" && Productkey != "")
                {
                    int id = int.Parse(Productkey);
                    int group = int.Parse(Categorykey);
                    result = db.GetProductSearch(id, group, pageindex, pagesize).ToList();
                }
                else if (Categorykey != "" && Productkey == "")
                {
                    int group = int.Parse(Categorykey);
                    result = db.GetProductSearch(null, group, pageindex, pagesize).ToList();
                }
                else if (Categorykey == "" && Productkey != "")
                {
                    int id = int.Parse(Productkey);
                    result = db.GetProductSearch(id, null, pageindex, pagesize).ToList();
                }
                else
                {
                    //find all record
                    result = db.GetProductSearch(null, null, pageindex, pagesize).ToList();
                }

                if (result.Count() > 0)
                {
                    ProductGrid.DataSource = HelperCS.ToDataTable(result);
                    ProductGrid.AllowUserToAddRows = false;
                    this.PopulatePager(result.Count(), pageindex);
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลสินค้าที่ค้นหา", "ค้นหาข้อมูลสินค้า", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion BIND DATA

        #region EVENT CLICK
        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            Form1 frm = this.FindForm() as Form1;
            frm.callControlPopup("ProductManageUC");
            BindProductData(1);
        }
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            BindProductData(1);
        }
        private void ProductGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                //get value grid columnproductid
                ProductManageUC.productid = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value);
            }

            Form1 frm = this.FindForm() as Form1;
            frm.callControlPopup("ProductManageUC");
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
                    MetroButton btnPage = new MetroButton();
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
