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

namespace OrderManagement
{
    public partial class CustomerUC :  UserControl
    {
        public CustomerUC()
        {
            InitializeComponent();
        }
        private void CustomerUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            //call popup from parent Form
            Form1 frm = this.FindForm() as Form1;
            frm.callCustomerManageUC("CustomerManageUC");

            //https://www.codeproject.com/Articles/16303/DataGrid-Paging-C-Windows-Forms link paging grid
            //https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-bind-data-to-the-windows-forms-datagridview-control
        }

    }
}
