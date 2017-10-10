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
using OrderManagement.Entity;
using OrderManagement.Model;

namespace OrderManagement.User_Control
{
    public partial class LoginUC : UserControl
    {
        private int rownum;
        public string Username { get; set; }
        public string Userpassword { get; set; }

        public LoginUC()
        {
            InitializeComponent();
        }

        private void LoginUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            using (OrderEntities db = new OrderEntities())
            {          
                rownum = db.Login.Where(a => a.UserName == txtUserName.Text && a.Password == txtPassword.Text).Count();
                if(rownum > 0)
                {
                    DataInfo.UserLoginName = txtUserName.Text;
                    Form1 frm = this.FindForm() as Form1;
                    frm.CheckUserLogin(txtUserName.Text);
                }
                else
                {
                    lblLoginValidate.Text = "";
                    lblLoginValidate.Text = "** InValid Username or Password ";
                    lblLoginValidate.Visible = true;
                }
            }
        }
    }
}
