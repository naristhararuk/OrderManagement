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
    public partial class ReportServiceUC : UserControl
    {
        public DateTime date;
        public int customerid;
        public string reporttype;
        public ReportServiceUC()
        {
            InitializeComponent();
        }

        private void btnCloseDialog_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }
    }
}
