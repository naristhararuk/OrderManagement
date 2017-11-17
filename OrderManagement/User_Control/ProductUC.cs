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

namespace OrderManagement.User_Control
{
    public partial class ProductUC : UserControl
    {
        public ProductUC()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ddlProduct, "Product");
            HelperCS.AutoCompleteLoadValues(ddlProductCategory, "Config-ProductCategory");
        }
        private void ProductUC_Load(object sender, EventArgs e)
        {
            lblValid.Text = "";
            BindAllProductData();
        }
        #region BIND DATA
        private void BindAllProductData()
        {
            using (var db = new OrderEntities())
            {
                List<Product> result = (from x in db.Product where x.Status == true select x).ToList();
                if (result.Count() > 0)
                {
                    ProductGrid.DataSource = HelperCS.ToDataTable(result);
                    ProductGrid.AllowUserToAddRows = false;
                    lblValid.Text = "";
                }
                else
                {
                    lblValid.Text = "** ไม่พบข้อมูลที่ค้นหา";
                }
            }
        }
        private void BindProductData()
        {
            string Productkey = ((KeyValuePair<string, string>)ddlProduct.SelectedItem).Key;
            string Categorykey = ((KeyValuePair<string, string>)ddlProductCategory.SelectedItem).Key;
            List<Product> result;
            using (var db = new OrderEntities())
            {
                if (Categorykey != "" && Productkey != "")
                {
                    int id = int.Parse(Productkey);
                    int zone = int.Parse(Categorykey);
                    result = (from x in db.Product
                              where x.ProductID == id && x.Category == zone && x.Status == true
                              select x).ToList();
                }
                else if (Categorykey != "" && Productkey == "")
                {
                    int zone = int.Parse(Categorykey);
                    result = (from x in db.Product
                              where x.Category == zone && x.Status == true
                              select x).ToList();
                }
                else if (Categorykey == "" && Productkey != "")
                {
                    int id = int.Parse(Productkey);
                    result = (from x in db.Product
                              where x.ProductID == id && x.Status == true
                              select x).ToList();
                }
                else
                {
                    //int id = int.Parse(Productkey);
                    result = (from x in db.Product where x.Status == true select x).ToList();
                }

                if (result.Count() > 0)
                {
                    ProductGrid.DataSource = HelperCS.ToDataTable(result);
                    ProductGrid.AllowUserToAddRows = false;
                    lblValid.Text = "";
                }
                else
                {
                    lblValid.Text = "** ไม่พบข้อมูลที่ค้นหา";
                }
            }
        }
        #endregion BIND DATA

        #region EVENT CLICK
        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            Form1 frm = this.FindForm() as Form1;
            frm.callControlPopup("ProductManageUC");
        }
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            BindProductData();
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
            BindAllProductData();
        }

        #endregion EVENT CLICK


    }
}
