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
using MetroFramework.Controls;

namespace OrderManagement.User_Control
{
    public partial class OrderUC : UserControl
    {
        public OrderUC()
        {
            InitializeComponent();
            //if (SundayToggle.Checked == true)
            //{
            //    SundayToggle.Text = "Yes";
            //}
            //else
            //{
            //    SundayToggle.Text = "No";
            //}
        }

        private void OrderUC_Load(object sender, EventArgs e)
        {
            CheckTabBindGrid();
        }

        //private void BindGrid()
        //{
        //    using(OrderEntities db = new OrderEntities())
        //    {
        //        var query = from x in db.Order
        //        select x;
        //        SetGridData(OrderTab.SelectedTab, query.ToList());
        //        //SundayGrid.DataSource = query.ToList();
        //        //SundayGrid.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
                
        //    }
        //}

        private void CheckTabBindGrid()
        {
            if (OrderTab.SelectedTab == OrderTab.TabPages["SundayTab"])
            {
                BindGrid(SundayGrid,"Sunday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["MondayTab"])
            {
                //BindGrid(MondayGrid);
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["TuesdayTab"])
            {
                //BindGrid(TuesdayGrid);
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["WednesdayTab"])
            {
                //BindGrid(WednesdayGrid);
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["ThursdayTab"])
            {
                //BindGrid(ThursdayGrid);
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["FridayTab"])
            {
                //BindGrid(FridayGrid);
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["SaturdayTab"])
            {
                //BindGrid(SaturdayGrid);
            }
        }

        private void BindGrid(MetroGrid Grid,string day)
        {
            int customerid = 1;
            try {
                using (OrderEntities db = new OrderEntities())
                {
                    var query = from x in db.Order
                                where (x.OrderDay.Contains(day)) && (x.CustomerID.Equals(customerid))
                                select x;
                    Grid.DataSource = query.ToList();
                    Grid.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);

                }
                //using (DailyOrderEntities store = new DailyOrderEntities()) { }
            }
            catch(Exception ex)
            {

            }
        }

        private void OrderTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (OrderTab.SelectedTab == OrderTab.TabPages["SundayTab"]) 
            {
                ActiveTab("Sunday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["MondayTab"]) 
            {
                ActiveTab("Monday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["TuesdayTab"])
            {
                ActiveTab("Tuesday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["WednesdayTab"])
            {
                ActiveTab("Wednesday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["ThursdayTab"])
            {
                ActiveTab("Thursday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["FridayTab"])
            {
                ActiveTab("Friday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["SaturdayTab"])
            {
                ActiveTab("Saturday");
            }
        }

        private void ActiveTab(string tab)
        {
            if (tab == "Sunday")
            {
                //SundayGrid.ColumnCount = 3;
                //SundayGrid.Columns[0].Name = "Product ID";
                //SundayGrid.Columns[1].Name = "Product Name";
                //SundayGrid.Columns[2].Name = "Product Price";

                //string[] row = new string[] { "1", "Product 1", "1000" };
                //SundayGrid.Rows.Add(row);
                //row = new string[] { "2", "Product 2", "2000" };
                //SundayGrid.Rows.Add(row);
                //row = new string[] { "3", "Product 3", "3000" };
                //SundayGrid.Rows.Add(row);
                //row = new string[] { "4", "Product 4", "4000" };
                //SundayGrid.Rows.Add(row);

                //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                //cmb.HeaderText = "Select Data";
                //cmb.Name = "cmb";
                //cmb.MaxDropDownItems = 4;
                //cmb.Items.Add("True");
                //cmb.Items.Add("False");
                //SundayGrid.Columns.Add(cmb);
            }
            else if (tab == "Monday")
            {

            }
            else if (tab == "Tuesday")
            {

            }
            else if (tab == "Wednesday")
            {

            }
            else if (tab == "Thursday")
            {

            }
            else if (tab == "Friday")
            {

            }
            else if (tab == "Saturday")
            {

            }
        }
        #region Sunday

        private void SundayToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (SundayToggle.Checked == true)
            {
                SundayToggle.Text = "สั่ง";

            }
            else
            {
                SundayToggle.Text = "ไม่สั่ง";
            }
        }

        private void SundayGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion Sunday

        #region Monday
        #endregion Monday
        #region Tuesday
        #endregion Tuesday
        #region Wednesday
        #endregion Wednesday
        #region Thursday
        #endregion Thursday
        #region Friday
        #endregion Friday
        #region Saturday
        #endregion Saturday
    }
}
