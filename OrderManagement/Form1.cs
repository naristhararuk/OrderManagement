using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement.User_Control;
namespace OrderManagement
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private static Font fontstyle;

        public static string UserLoginName { get; set; }
        #region Inititial
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
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
            LoginUC login = new LoginUC();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(login);
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
        public void CheckUserLogin(string username)
        {
            if (username == "Admin")
            {
                ReportUC report = new ReportUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(report);
            }
            else if (username == "Account")
            {
                ProductUC product = new ProductUC();
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(product);
            }
            else
            {

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


    }
}
