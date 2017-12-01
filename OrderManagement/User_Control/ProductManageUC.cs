using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement.Entity;
using OrderManagement.Class;
using MetroFramework;
using MetroFramework.Controls;

namespace OrderManagement.User_Control
{
    public partial class ProductManageUC : UserControl
    {
        public static int productid = 0;
        public ProductManageUC()
        {
            InitializeComponent();
        }
        private void ProductManageUC_Load(object sender, EventArgs e)
        {
            HelperCS.AutoCompleteLoadValues(comboProductGroup, "Config-ProductCategory");
            if (productid > 0)
            {
                btnProductDelete.Visible = true;
                BindProductData();
            }
            else
            {
                txtbProductName.Text = "";
                txtbProductAbbr.Text = "";
                comboProductGroup.SelectedIndex = 0;
                txtbProductPrice.Text = "";
                txtbProductUnit.Text = "";
                txtbProductAmount.Text = "";
                txtbProductDescription.Text = "";
                btnProductDelete.Visible = false;
            }
        }

        private void BindProductData()
        {
            using (var db = new OrderEntities())
            {
                var ds = (from x in db.Product
                          where x.ProductID == productid
                          select x).ToList();
                if (ds.Count > 0)
                {
                    txtbProductName.Text = ds[0].ProductName;
                    txtbProductAbbr.Text = ds[0].ProductAbbr;
                    comboProductGroup.SelectedIndex = int.Parse(ds[0].Category.ToString());
                    txtbProductPrice.Text = ds[0].Price.ToString();
                    txtbProductUnit.Text = ds[0].Unit.ToString();
                    txtbProductAmount.Text = ds[0].Amount.ToString();
                    txtbProductDescription.Text = ds[0].Descripiton;
                    //bind to control
                }
            }
        }
        private void SaveProductData()
        {
            int result = 0;
            string Category = ((KeyValuePair<string, string>)comboProductGroup.SelectedItem).Key;
            int group = Category != "" ? int.Parse(Category) : 0;
            try
            {
                if (productid > 0)
                {
                    //edit product
                    using (var db = new OrderEntities())
                    {
                        var ds = db.UpdateProduct(productid, txtbProductName.Text, txtbProductAbbr.Text, group, Convert.ToDecimal(txtbProductPrice.Text), int.Parse(txtbProductUnit.Text), int.Parse(txtbProductAmount.Text), txtbProductDescription.Text, true, DateTime.Now, HelperCS.UserName).ToList();
                        if (ds.Count() > 0)
                        {
                            result = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                        }
                        else
                        {
                            result = 99;
                        }
                    }
                    if (result == 0)
                    {
                        MessageBox.Show("บันทึกการแก้ไขข้อมูลสินค้า " + txtbProductName.Text + " เรียบร้อยแล้ว ", "แก้ไขข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        MessageBox.Show("มีปัญหาในการบันทึกการแก้ไขข้อมูล", "บันทึกการแก้ไขไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //add new product
                    using (var db = new OrderEntities())
                    {
                        var ds = db.InsertProduct(txtbProductName.Text, txtbProductAbbr.Text, group, Convert.ToDecimal(txtbProductPrice.Text), int.Parse(txtbProductUnit.Text), int.Parse(txtbProductAmount.Text), txtbProductDescription.Text, true, DateTime.Now, HelperCS.UserName).ToList();
                        if (ds.Count() > 0)
                        {
                            result = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                        }
                        else
                        {
                            result = 99;
                        }
                    }
                    if (result == 0)
                    {
                        MessageBox.Show("บันทึกข้อมูลสินค้า " + txtbProductName.Text + " เรียบร้อยแล้ว ", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else if (result == 11)
                    {
                        MessageBox.Show("มีชื่อสินค้า " + txtbProductName.Text + " นี้อยู่แล้ว \r\n กรุณาตั้งชื่อให้แตกต่างกัน ", "บันทึกข้อมูลไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("มีปัญหาในการบันทึกข้อมูล", "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("มีปัญหาในการบันทึกข้อมูล \r\n" + ex.Message, "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                productid = 0;
                if (result == 0)
                    ((Form)this.TopLevelControl).Close();
            }
        }
        private void DeleteProductData()
        {
            try
            {
                if (productid > 0)
                {
                    //delete customer set status = 0 (false)
                    int queryresult = 0;
                    using (var db = new OrderEntities())
                    {
                        var ds = db.DeleteRecord("Product", productid, DateTime.Now, HelperCS.UserName).ToList();
                        if (ds.Count() > 0)
                        {
                            queryresult = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                        }
                        else
                        {
                            queryresult = 99;
                        }
                    }
                    if (queryresult != 0)
                    {
                        MessageBox.Show("มีปัญหาในการลบข้อมูล", "ลบข้อมูลไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("ลบข้อมูลสินค้า " + txtbProductName.Text + " เรียบร้อย", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.None);
                        ((Form)this.TopLevelControl).Close();
                    }
                }
                else
                {
                    MessageBox.Show("มีปัญหาในการลบข้อมูล \r\n ไม่มีข้อมูลสินค้า", "ลบข้อมูลไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("มีปัญหาในการลบข้อมูล \r\n" + ex.Message, "ลบข้อมูลไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                productid = 0;
                ((Form)this.TopLevelControl).Close();
            }
        }


        #region BUTTON
        private void btnCloseDialog_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            txtbProductName.Text = "";
            txtbProductAbbr.Text = "";
            txtbProductAmount.Text = "";
            txtbProductDescription.Text = "";
            txtbProductPrice.Text = "";
            txtbProductUnit.Text = "";
            comboProductGroup.SelectedIndex = 0;
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            if (txtbProductName.Text == "")
            {
                MessageBox.Show("ชื่อสินค้าไม่สามารเป็นค่าว่างได้ ", "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtbProductAmount.Text == "")
            {
                MessageBox.Show("จำนวนสินค้าไม่สามารเป็นค่าว่างได้ ", "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtbProductPrice.Text == "")
            {
                MessageBox.Show("ราคาสินค้าไม่สามารเป็นค่าว่างได้ ", "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboProductGroup.SelectedIndex == 0)
            {
                MessageBox.Show("กรุณาเลือกกลุ่มของสินค้า ", "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //save to database
                SaveProductData();
            }
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการลบข้อมูลสินค้าใช่หรือไม่ ?", "ยืนยันลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //DialogResult result = MessageBox.Show("Data has been Delete ", "Delete Record", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteProductData();
            }
        }
        #endregion BUTTON


        #region INDEX CHANGED
        private void CheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroTextBox txt = (MetroTextBox)sender;
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 40))
            {
                e.Handled = true;
                return;
            }
            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if (txt.Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
        private void TextBoxInput_Leave(object sender, EventArgs e)
        {
            MetroTextBox txt = (MetroTextBox)sender;
            if (!string.IsNullOrEmpty(txt.Text))
            {
                if (Convert.ToDecimal(txt.Text) <= 0)
                {
                    Form frm = txt.FindForm();
                    MessageBox.Show("จำนวนต้องไม่ว่าง และ มากกว่า 0", "จำนวนตัวเลข", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt.Text = "1";
                    txt.Focus();
                }
                else
                {
                    //MessageBox.Show("จำนวนสินค้าต้องมากกว่า 0", "จำนวนสินค้า", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("จำนวนต้องไม่ว่าง", "จำนวนตัวเลข", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        #endregion INDEX CHANGED
    }
}
