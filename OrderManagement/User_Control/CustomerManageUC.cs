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
using MetroFramework;
using OrderManagement.Class;
using MetroFramework.Controls;

namespace OrderManagement.User_Control
{
    public partial class CustomerManageUC : UserControl
    {
        public CustomerManageUC()
        {
            InitializeComponent();
        }
        private void CustomerManageUC_Load(object sender, EventArgs e)
        {

        }

        #region BUTTON
        private void btnCloseDialog_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void btnCustomerClear_Click(object sender, EventArgs e)
        {
            txtbCustomerName.Text = "";
            txtbCustomerAbbr.Text = "";
            txtbCustomerAddress1.Text = "";
            txtbCustomerAddress2.Text = "";
            txtbCustomerCitizenID.Text = "";
            txtbCustomerDescription.Text = "";
            txtbCustomerPhone.Text = "";
            txtbCustomerZone.SelectedIndex = 0;
            chkCustomerShowPrice.Checked = false;
        }

        private void btnCustomerSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            //DialogResult confirm = MetroMessageBox.Show(this, "Do You Want to Delete Customer ?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //if (confirm == DialogResult.OK)
            //{
            //    int customerid = 0;
            //    int result = 0;
            //    using (var db = new DailyOrderEntities())
            //    {
            //        var ds = db.DeleteRecord("Customer", customerid, DateTime.Now, HelperCS.UserName).ToList();
            //        if (ds.Count() > 0)
            //        {
            //            result = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
            //        }
            //        else
            //        {
            //            result = 99;
            //        }
            //    }
            //    if (result != 0)
            //    {
            //        MetroMessageBox.Show(this, "Some Data has Problem Cannot Delete ", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        MetroMessageBox.Show(this, "Data has been Delete ", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //        ((Form)this.TopLevelControl).Close();
            //    }
            //}
            //else
            //{
            //    confirm = DialogResult.None;
            //    //((Form)this.TopLevelControl).Close();
            //}

            DialogResult result = MetroMessageBox.Show(this, "Do You Want to Delete Customer ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //DialogResult result = MessageBox.Show("Data has been Delete ", "Delete Record", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //MessageBox.hide();//Close();

            }
            else
            {
                result = DialogResult.None;
                // Do something
            }


        }
        #endregion BUTTON
    }
}
