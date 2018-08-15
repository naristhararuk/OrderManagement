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
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("คุณต้องการออกจากโปรแกรม ใช่หรือไม่?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
           //this.WindowState = FormWindowState.Maximized;
            HelperCS.UserName = "";
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
            if (HelperCS.UserName != "")
            {
                CustomerUC cusUC = new CustomerUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(cusUC);
            }
            else
            {
                LoginUC login = new LoginUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(login);
            }
        }

        private void OrderMenuTile_Click(object sender, EventArgs e)
        {
            if (HelperCS.UserName != "")
            {
                OrderUC order = new OrderUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(order);
            }
            else
            {
                LoginUC login = new LoginUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(login);
            }
        }

        private void ProductMenuTile_Click(object sender, EventArgs e)
        {
            if (HelperCS.UserName != "")
            {
                ProductUC productUC = new ProductUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(productUC);
            }
            else
            {
                LoginUC login = new LoginUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(login);
            }
            //CustomerManageUC cusmanage = new CustomerManageUC();
            //MaskedDialog.ShowDialog(this, cusmanage);

        }
        private void SettingMenuTile_Click(object sender, EventArgs e)
        {
            if (HelperCS.UserName != "ADMIN")
            {
                DialogResult result = MessageBox.Show(this, "You Not have Permission Administrator can Access this Menu \r\n Login Menu Click OK ", "Access to Report", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
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
                SettingUC set = new SettingUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(set);
            }

        }
        #endregion MenuClick

        #region Method
        public void callControlPopup(string usercontrolname)
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
            else if (usercontrolname == "ProductManageUC")
            {
                uc = new ProductManageUC();
            }
            else if (usercontrolname == "ProductUC")
            {
                uc = new ProductUC();
            }
            else if (usercontrolname == "ReportServiceUC")
            {
                uc = new ReportServiceUC();
            }
            MaskedDialog.ShowDialog(this, uc);
        }
        public void CheckUserLogin()
        {
            /*dev test only*/
            HelperCS.UserName = "ADMIN";

            string username = HelperCS.UserName;
            if (username == "ADMIN")
            {
                ReportUC report = new ReportUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(report);
                UserTile.Text = username;
            }
            else if (username == "ACCOUNT")
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
            if (HelperCS.UserName != "")
            {
                DialogResult result = MessageBox.Show(this, "ต้องการออกจากระบบหรือไม่ ", "Sign out", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (result.Equals(DialogResult.OK))
                {
                    HelperCS.UserName = "";
                    UserTile.Text = "ไม่ล็อคอิน";
                    LoginUC login = new LoginUC();
                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(login);
                }
            }
            else
            {
                LoginUC login = new LoginUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(login);
            }
        }

        private void ReportMenuTile_Click(object sender, EventArgs e)
        {
            if (HelperCS.UserName != "ADMIN" && HelperCS.UserName != "ACCOUNT")
            {
                DialogResult result = MessageBox.Show(this, "You Not have Permission Administrator can Access this Menu \r\n Login Menu Click OK ", "Access to Report", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
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
