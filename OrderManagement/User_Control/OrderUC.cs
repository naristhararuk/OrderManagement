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
    public partial class OrderUC : UserControl
    {
        public OrderUC()
        {
            InitializeComponent();
        }

        private void OrderTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveTab("Sunday");
        }

        private void ActiveTab(string tab)
        {
            if(tab == "Sunday")
            {
                SundayGrid.ColumnCount = 3;
                SundayGrid.Columns[0].Name = "Product ID";
                SundayGrid.Columns[1].Name = "Product Name";
                SundayGrid.Columns[2].Name = "Product Price";

                string[] row = new string[] { "1", "Product 1", "1000" };
                SundayGrid.Rows.Add(row);
                row = new string[] { "2", "Product 2", "2000" };
                SundayGrid.Rows.Add(row);
                row = new string[] { "3", "Product 3", "3000" };
                SundayGrid.Rows.Add(row);
                row = new string[] { "4", "Product 4", "4000" };
                SundayGrid.Rows.Add(row);

                DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                cmb.HeaderText = "Select Data";
                cmb.Name = "cmb";
                cmb.MaxDropDownItems = 4;
                cmb.Items.Add("True");
                cmb.Items.Add("False");
                SundayGrid.Columns.Add(cmb);
            }
        }
    }
}
