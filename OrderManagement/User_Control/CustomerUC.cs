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
using OrderManagement.Class;
using OrderManagement.Entity;

namespace OrderManagement
{
    public partial class CustomerUC :  UserControl
    {
        //private object result;

        public CustomerUC()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ddlCustomer, "Customer");
        }
        private void CustomerUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            lblValid.Text = "";
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            string Customerkey = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Key;
            string Zonekey = ((KeyValuePair<string, string>)ddlCustormerZone.SelectedItem).Key;
            List<Customer> result ;
            if (Zonekey != "" || Customerkey != "")
            {
                using (var db = new OrderEntities())
                {
                    if (Zonekey != "" && Customerkey != "")
                    {
                        int id = int.Parse(Customerkey);
                        int zone = int.Parse(Zonekey);
                        result = (from x in db.Customer
                                      where x.CustomerID == id && x.Zone == zone
                                      select x).ToList();
                    }else if (Zonekey != "" && Customerkey == "")
                    {
                        int zone = int.Parse(Zonekey);
                        result = (from x in db.Customer
                                      where x.Zone == zone
                                      select x).ToList();
                    }else if (Zonekey == "" && Customerkey != "")
                    {
                        int id = int.Parse(Customerkey);
                        result = (from x in db.Customer
                                  where x.CustomerID == id
                                  select x).ToList();
                    }
                    else
                    {
                        result = new List<Customer>();
                    }
                    
                    if (result.Count() > 0)
                    {
                        CustomerGrid.DataSource = HelperCS.ToDataTable(result);
                    }
                    else
                    {
                        lblValid.Text = "** ไม่พบข้อมูลที่ค้นหา";
                    }
                }
            }
            else
            {
                lblValid.Text = "** กรุณาเลือกเขต หรือเลือกชื่อลูกค้า ก่อนกดปุ่มค้นหา";
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            //call popup from parent Form
            Form1 frm = this.FindForm() as Form1;
            frm.callControlPopup("CustomerManageUC");

            //https://www.codeproject.com/Articles/16303/DataGrid-Paging-C-Windows-Forms link paging grid
            //https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-bind-data-to-the-windows-forms-datagridview-control
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            GridCS.goPrevious("Customer", CustomerGrid, lblStatusPage);
        }

        private void CustomerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                //get if from grid column
                int id = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value);
                //do you staff.
            }
            // get value customerid
            //CustomerManageUC.customerid = 
            Form1 frm = this.FindForm() as Form1;
            frm.callControlPopup("CustomerManageUC");
        }
    }
}
