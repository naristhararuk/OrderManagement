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

        }

        private void btnCustomerSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {

        }
        #endregion BUTTON
    }
}
