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
namespace OrderManagement.User_Control
{
    public partial class OrderMondayUC : UserControl
    {
        private int customer;
        public OrderMondayUC()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ComboMondayCustomer, "Customer");
        }
        private void BindTable(int cusid)
        {
            HelperCS.dt = null;
            HelperCS.CreatePanelTable(pnlMondayGridHead, pnlMondayGridBody, "Monday", cusid);
        }
        private void ComboMondayCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;
            if (key != "")
            {
                customer = int.Parse(key);
                BindTable(customer);
            }
        }
    }
}
