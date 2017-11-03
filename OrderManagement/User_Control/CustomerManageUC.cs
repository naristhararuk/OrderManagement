using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement.Entity;
using MetroFramework;
using OrderManagement.Class;
using MetroFramework.Controls;

namespace OrderManagement.User_Control
{
    public partial class CustomerManageUC : UserControl
    {
        public static int customerid = 0;
        public CustomerManageUC()
        {
            InitializeComponent();
        }
        private void CustomerManageUC_Load(object sender, EventArgs e)
        {
            HelperCS.AutoCompleteLoadValues(comboCustomerZone, "Config-Zone");
            if (customerid > 0)
            {
                btnCustomerDelete.Visible = true;
                BindCustomerData();
            }
            else
            {
                txtbCustomerName.Text = "";
                txtbCustomerAbbr.Text = "";
                txtbCustomerAddress1.Text = "";
                txtbCustomerAddress2.Text = "";
                txtbCustomerCitizenID.Text = "";
                txtbCustomerDescription.Text = "";
                txtbCustomerPhone.Text = "";
                comboCustomerZone.SelectedIndex = 0;
                chkCustomerShowPrice.Checked = false;
                btnCustomerDelete.Visible = false;
            }
        }

        private void BindCustomerData()
        {
            using(var db = new OrderEntities())
            {
                var ds = (from x in db.Customer
                              where x.CustomerID == customerid
                              select x).ToList();
                if(ds.Count > 0)
                {

                    txtbCustomerCitizenID.Text = ds[0].CitizenID.ToString();
                    txtbCustomerName.Text = ds[0].CustomerName;
                    txtbCustomerAbbr.Text = ds[0].CustomerAbbr;
                    comboCustomerZone.SelectedIndex = int.Parse(ds[0].Zone.ToString());
                    txtbCustomerAddress1.Text = ds[0].Address1;
                    txtbCustomerAddress2.Text = ds[0].Address2;
                    txtbCustomerPhone.Text = ds[0].Phone;
                    txtbCustomerDescription.Text = ds[0].Description;
                    chkCustomerShowPrice.Checked = ds[0].ShowPrice == true ?true :false;
                    
                    //bind to control
                }
            }
        }
        private void SaveCustomerData()
        {
            int result = 0;
            string Zonekey = ((KeyValuePair<string, string>)comboCustomerZone.SelectedItem).Key;
            int zone = Zonekey != "" ? int.Parse(Zonekey) : 0;
            try {
                if (customerid > 0)
                {
                    //edit customer
                    using (var db = new DailyOrderEntities())
                    {
                        var ds = db.UpdateCustomer(customerid,txtbCustomerCitizenID.Text, txtbCustomerName.Text, txtbCustomerAbbr.Text, zone, txtbCustomerAddress1.Text, txtbCustomerAddress2.Text, txtbCustomerPhone.Text, txtbCustomerDescription.Text, chkCustomerShowPrice.Checked, true, DateTime.Now, HelperCS.UserName).ToList();
                        if (ds.Count() > 0)
                        {
                            result = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                        }
                        else
                        {
                            result = 99;
                        }
                    }
                    if (result == 0)
                    {
                        MessageBox.Show("บันทึกการแก้ไขข้อมูลลูกค้า " + txtbCustomerName.Text + " เรียบร้อยแล้ว ", "แก้ไขข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        MessageBox.Show("มีปัญหาในการบันทึกการแก้ไขข้อมูล", "บันทึกการแก้ไขไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //add new customer
                    using (var db = new DailyOrderEntities())
                    {
                        var ds = db.InsertCustomer(txtbCustomerCitizenID.Text,txtbCustomerName.Text,txtbCustomerAbbr.Text, zone, txtbCustomerAddress1.Text,txtbCustomerAddress2.Text,txtbCustomerPhone.Text,txtbCustomerDescription.Text,chkCustomerShowPrice.Checked,true,DateTime.Now,HelperCS.UserName).ToList();
                        if (ds.Count() > 0)
                        {
                            result = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                        }
                        else
                        {
                            result = 99;
                        }
                    }
                    if(result == 0)
                    {
                        MessageBox.Show("บันทึกข้อมูลลูกค้า " + txtbCustomerName.Text + " เรียบร้อยแล้ว ", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else if (result == 11)
                    {
                        MessageBox.Show("มีชื่อนี้ลูกค้า" + txtbCustomerName.Text + " อยู่แล้ว \r\n กรุณาตั้งชื่อให้แตกต่างกัน ", "บันทึกข้อมูลไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("มีปัญหาในการบันทึกข้อมูล", "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("มีปัญหาในการบันทึกข้อมูล \r\n"+ ex.Message, "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                customerid = 0;
                if(result == 0)
                ((Form)this.TopLevelControl).Close();
            }
        }
        private void DeleteCustomerData()
        {
            try
            {
                if (customerid > 0)
                {
                    //delete customer set status = 0 (false)
                    int queryresult = 0;
                    using (var db = new DailyOrderEntities())
                    {
                        var ds = db.DeleteRecord("Customer", customerid, DateTime.Now, HelperCS.UserName).ToList();
                        if (ds.Count() > 0)
                        {
                            queryresult = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                        }
                        else
                        {
                            queryresult = 99;
                        }
                    }
                    if (queryresult != 0)
                    {
                        MessageBox.Show("มีปัญหาในการลบข้อมูล", "ลบข้อมูลไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("ลบข้อมูลลูกค้า " + txtbCustomerName.Text + " เรียบร้อย", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.None);
                        ((Form)this.TopLevelControl).Close();
                    }
                }
                else
                {
                    MessageBox.Show("มีปัญหาในการลบข้อมูล \r\n ไม่มีข้อมูลลูกค้า" , "ลบข้อมูลไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("มีปัญหาในการลบข้อมูล \r\n" + ex.Message, "ลบข้อมูลไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                customerid = 0;
                ((Form)this.TopLevelControl).Close();
            }
        }

        #region BUTTON
        private void btnCloseDialog_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void btnCustomerClear_Click(object sender, EventArgs e)
        {
            txtbCustomerName.Text = "";
            txtbCustomerAbbr.Text = "";
            txtbCustomerAddress1.Text = "";
            txtbCustomerAddress2.Text = "";
            txtbCustomerCitizenID.Text = "";
            txtbCustomerDescription.Text = "";
            txtbCustomerPhone.Text = "";
            comboCustomerZone.SelectedIndex = 0;
            chkCustomerShowPrice.Checked = false;
        }

        private void btnCustomerSave_Click(object sender, EventArgs e)
        {
            if(txtbCustomerName.Text == "")
            {
                MessageBox.Show("ชื่อลูกค้าไม่สามารเป็นค่าว่างได้ ", "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtbCustomerAddress1.Text == "" )
            {
                MessageBox.Show("ที่อยู่ลูกค้าไม่สามารเป็นค่าว่างได้ ", "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboCustomerZone.SelectedIndex == 0)
            {
                MessageBox.Show("กรุณาเลือกเขตของลูกค้า ", "บันทึกไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                //save to database
                SaveCustomerData();
            }
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการลบข้อมูลลูกค้าใช่หรือไม่ ?", "ยืนยันลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //DialogResult result = MessageBox.Show("Data has been Delete ", "Delete Record", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteCustomerData();
            }
            else
            {
            }
        }


        #endregion BUTTON
    }
}
