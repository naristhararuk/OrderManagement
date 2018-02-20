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
using OrderManagement.Class;
using System.Security.Cryptography;
using System.IO;

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
                string passwd = txtPassword.Text != "" ? Encrypt(txtPassword.Text) : "";
                string usr = txtUserName.Text != "" ? txtUserName.Text.ToUpper() : "";
                
                rownum = db.Login.Where(a => a.UserName == usr && a.Password == passwd).Count();
                if(rownum > 0)
                {
                    //DataInfo.UserLoginName = txtUserName.Text;
                    HelperCS.UserName = usr;
                    Form1 frm = this.FindForm() as Form1;
                    //frm.CheckUserLogin(txtUserName.Text);
                    //frm.pa
                    frm.CheckUserLogin();
                    //password anan126,ac2018
                }
                else
                {
                    lblLoginValidate.Text = "";
                    lblLoginValidate.Text = "** InValid Username or Password ";
                    lblLoginValidate.Visible = true;
                }
            }
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        //private string Decrypt(string cipherText)
        //{
        //    string EncryptionKey = "MAKV2SPBNI99212";
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}

    }
}
