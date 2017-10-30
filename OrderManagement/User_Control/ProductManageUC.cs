using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
        #endregion BUTTON
    }
}
