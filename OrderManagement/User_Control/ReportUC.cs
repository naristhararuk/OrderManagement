using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement.Class;
using MetroFramework;
namespace OrderManagement.User_Control
{
    public partial class ReportUC : UserControl
    {
        public ReportUC()
        {
            InitializeComponent();
        }
        private void ReportUC_Load(object sender, EventArgs e)
        {

        }
        private void ReportSummaryTile_Click(object sender, EventArgs e)
        {

            //  var listOfUser = loginModel.Login.Select(r => r.UserName);
            //var query = from a in db.Login
            //                   where a.UserName.Contains(txtUserName.Text)
            //                   select a;
            //foreach (var item in query)
            //{
            //    if (txtUserName.Text == item.UserName)
            //        validuser = true;
            //}

            //ReceiveForm reportreceive = new ReceiveForm();
            //reportreceive.ShowDialog();

            ReportViewerUC report = new ReportViewerUC();
            pnlMainReport.Controls.Clear();
            pnlMainReport.Controls.Add(report);
        }
    }
}
