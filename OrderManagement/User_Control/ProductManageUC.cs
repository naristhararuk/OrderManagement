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

namespace OrderManagement.User_Control
{
    public partial class ProductManageUC : UserControl
    {
        public ProductManageUC()
        {
            InitializeComponent();
        }
        #region BUTTON
        private void btnCloseDialog_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {

        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {

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
    }
}
