using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using OrderManagement.Class;
using OrderManagement.User_Control;
namespace OrderManagement
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private static Font fontstyle;
        #region Inititial
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            HelperCS.UserName = "Admin";
            CheckUserLogin();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }
        #endregion Inititial

        #region MenuClick
        private void CustomerMenuTile_Click(object sender, EventArgs e)
        {
            CustomerUC cusUC = new CustomerUC();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(cusUC);
        }

        private void OrderMenuTile_Click(object sender, EventArgs e)
        {
            OrderUC order = new OrderUC();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(order);
        }

        private void ProductMenuTile_Click(object sender, EventArgs e)
        {
            ProductUC productUC = new ProductUC();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(productUC);
            //CustomerManageUC cusmanage = new CustomerManageUC();
            //MaskedDialog.ShowDialog(this, cusmanage);

        }
        private void SettingMenuTile_Click(object sender, EventArgs e)
        {

          
        }
        #endregion MenuClick

        #region Method
        public void callCustomerManageUC(string usercontrolname)
        {
            UserControl uc = null;
            if (usercontrolname == "CustomerManageUC")
            {
                uc = new CustomerManageUC();
            }
            else if (usercontrolname == "CustomerUC")
            {
                uc = new CustomerUC();
            }
            MaskedDialog.ShowDialog(this, uc);
        }
        public void CheckUserLogin()
        {
            string username = HelperCS.UserName;
            if (username == "Admin")
            {
                ReportUC report = new ReportUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(report);
                UserTile.Text = username;
            }
            else if (username == "Account")
            {
                OrderUC order = new OrderUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(order);
                UserTile.Text = username;
            }
            else
            {
                LoginUC login = new LoginUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(login);
            }
            
        }
        public void ChangeFont()
        {
            fontstyle = new Font("Tahoma", 12, FontStyle.Bold);
            foreach (Control c in this.Controls)
            {
                c.Font = fontstyle;
            }
        }

        #endregion Method

        private void UserTile_Click(object sender, EventArgs e)
        {
            //logout and login different accoun
            LoginUC login = new LoginUC();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(login);
        }

        private void ReportMenuTile_Click(object sender, EventArgs e)
        {
            if (HelperCS.UserName != "Admin")
            {
                DialogResult result = MetroMessageBox.Show(this, "You Not have Permission Administrator can Access this Menu \r\n Login Menu Click OK ", "Access to Report", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (result.Equals(DialogResult.OK))
                {
                    LoginUC login = new LoginUC();
                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(login);
                }
                else
                {
                    pnlMain.Controls.Clear();
                }

            }
            else
            {
                ReportUC report = new ReportUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(report);
            }
        }
    }
}
