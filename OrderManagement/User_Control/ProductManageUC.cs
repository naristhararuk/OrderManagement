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
            if(productid > 0)
            {
                btnProductDelete.Visible = true;
            }
            else
            {
                btnProductDelete.Visible = false;
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
            try {
                int result = 1;

                string productgroup = ((KeyValuePair<string, string>)comboProductGroup.SelectedItem).Key;
                if (txtbProductName.Text == "" || txtbProductAmount.Text == "" || txtbProductPrice.Text == "" || txtbProductUnit.Text == "" || productgroup == "")
                {
                    MessageBox.Show("กรุณาไม่ครบถ้วน " +
                        txtbProductName.Text == "" ? "\r\n ชื่อสินค้า" : "" + productgroup == "" ? "\r\n กลุ่ม/ประเภทสินค้า" : "" + txtbProductUnit.Text == "" ? "\r\n หน่วยยก" : ""
                        + txtbProductPrice.Text == "" ? "\r\n ราคาสินค้า" : "" + txtbProductAmount.Text == "" ? "\r\n จำนวนสินค้า" : ""
                        , "ข้อมูลไม่มี", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else {
                    //has value and save to database
                    using (var db = new DailyOrderEntities())
                    {
                        var ds = db.InsertProduct(txtbProductName.Text, txtbProductAbbr.Text, 1, Convert.ToDecimal(txtbProductPrice.Text), int.Parse(txtbProductUnit.Text), int.Parse(txtbProductAmount.Text), txtbProductDescription.Text, true, DateTime.Now, HelperCS.UserName).ToList();
                        if (ds.Count() > 0)
                        {
                            result = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                        }
                        else
                        {
                            result = 99;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something Problem !!" + ex.Message,"Save Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MetroMessageBox.Show(this, "Do You Want to Delete Customer ?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (confirm.Equals(DialogResult.OK))
            {
                int productid = 0;
                int result = 0;
                using (var db = new DailyOrderEntities())
                {
                    var ds = db.DeleteRecord("Product", productid, DateTime.Now, HelperCS.UserName).ToList();
                    if (ds.Count() > 0)
                    {
                        result = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                    }
                    else
                    {
                        result = 99;
                    }
                }
                if (result != 0)
                {
                    MetroMessageBox.Show(this, "Some Data has Problem Cannot Delete ", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MetroMessageBox.Show(this, "Data has been Delete ", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    ((Form)this.TopLevelControl).Close();
                }
            }
            else
            {
                ((Form)this.TopLevelControl).Close();
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
                if (Convert.ToDecimal(txt.Text) <= 0 )
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
