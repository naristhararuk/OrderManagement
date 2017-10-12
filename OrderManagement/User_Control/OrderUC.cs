﻿using System;
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
using OrderManagement.Class;

namespace OrderManagement.User_Control
{
    public partial class OrderUC : UserControl
    {
        private DataTable dt ;

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
            //CreateTemplateTable();
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
                BindGrid(MondayGrid,"Monday");
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

        private void BindGrid(DataGridView grid, string day)
        {
            try
            {
                if (ddlCustomerOrder.SelectedIndex >= 0)
                {
                    int customerid = ddlCustomerOrder.SelectedIndex;
                    using (var dailydb = new DailyOrderEntities())
                    {
                        // Get result from Stored Procedure

                        var ds = dailydb.GetDailyOrder(day, customerid).ToList();

                        // if found item rows
                        if (ds.Count() > 0)
                        {
                            grid.DataSource = ds;
                            CreateProductComboBox(grid);
                        }
                        else
                        {

                            //SetControlTemplateTable(Grid);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void CreateProductComboBox(DataGridView grid)
        {
            DataGridViewComboBoxColumn comboboxColumn = new DataGridViewComboBoxColumn();
            comboboxColumn = CreateProductComboBoxColumn();
            SetAlternateChoicesUsingDataSource(comboboxColumn);
            comboboxColumn.HeaderText = "Product Combo";
            grid.Columns.Insert(0, comboboxColumn);
        }


        enum ColumnName
        {
            OrderId,
            OrderDate,
            CustomerID,
            ProductID,
            ProductPrice,
            ProductAmount,
            Description,
            OrderStatus,
            WeekDay,
            ProductName
        };
        private void SetAlternateChoicesUsingDataSource(DataGridViewComboBoxColumn comboboxColumn)
        {
            {
                comboboxColumn.DataSource = DataEntityProduct();
                comboboxColumn.ValueMember = "Id";
                comboboxColumn.DisplayMember = "Text";
                //comboboxColumn.ValueMember = ColumnName.ProductName.ToString();
                //comboboxColumn.DisplayMember = comboboxColumn.ValueMember;
            }
        }

        private object DataEntityProduct()
        {
            using (var db = new OrderEntities())
            {
                var ds = db.Product.Select(x => new
                {
                    Id = x.ProductID,
                    Text = x.ProductName + " / " + x.ProductID
                }).ToList();

                // if found item rows
                if (ds.Count() > 0)
                {
                    return HelperCS.ToDataTable(ds);
                }
                else
                {
                    return new DataTable();
                }
                //var query = from x in db.Product select x;
                //// customerGroup is an IGrouping<string, Customer>
                //foreach (var item in query)
                //{
                //    string id = item.ProductID.ToString();
                //    string Name = item.ProductName.ToString();
                //}
            }
        }

        private DataGridViewComboBoxColumn CreateProductComboBoxColumn()
        {
            DataGridViewComboBoxColumn column =
                new DataGridViewComboBoxColumn();
            {
                
                column.DataPropertyName = ColumnName.ProductName.ToString();
                column.HeaderText = ColumnName.ProductName.ToString();
                column.DropDownWidth = 160;
                column.Width = 90;
                column.MaxDropDownItems = 3;
                column.FlatStyle = FlatStyle.Flat;
            }
            return column;
        }

        private void BindGrid(MetroGrid Grid,string day)
        {
            
            try {
                if (ddlCustomerOrder.SelectedIndex >= 0)
                {
                    int customerid = ddlCustomerOrder.SelectedIndex;
                    //using (OrderEntities db = new OrderEntities())
                    //{
                    //    var result_id = (from d in db.vwOrder
                    //                    where d.CustomerID == customerid
                    //                    select d);
                    //    var result = from x in result_id
                    //                 where x.OrderDay.Contains(day)
                    //                 select x;

                    //    Grid.DataSource = result.ToList();
                    //    Grid.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                    //}
                    //using (DailyOrderEntities store = new DailyOrderEntities()) { }
                    using (var dailydb = new DailyOrderEntities())
                    {
                        // Get result from Stored Procedure

                        var ds = dailydb.GetDailyOrder(day, customerid).ToList();

                        // if found item rows
                        if (ds.Count() > 0)
                        {
                            Grid.DataSource = ds;
                            Grid.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            DataGridTextBoxColumn txtPrice = new DataGridTextBoxColumn();
                        }
                        else
                        {
                            
                            SetControlTemplateTable(Grid);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void SetControlTemplateTable(MetroGrid Grid)
        {
            DataRow dr = dt.NewRow();
            dr["#"] = "";
            dr["run"] = 1;
            dr["ProductName"] = 1;
            DataGridTextBoxColumn txtPrice = new DataGridTextBoxColumn();
            DataGridTextBoxColumn txtAmount = new DataGridTextBoxColumn();
            
            dr["ProductUnit"] = "1";
            dr["Price"] = txtPrice;
            dr["ProductAmount"] = txtAmount;
            dr["SumPrice"] = "2221";
            
        }

        private void CreateTemplateTable()
        {
            dt = new DataTable();
            dt.Columns.Add("#", Type.GetType("System.String"));
            dt.Columns.Add("run", Type.GetType("Int32"));
            dt.Columns.Add("ProductName", Type.GetType("System.String"));
            dt.Columns.Add("ProductUnit", Type.GetType("System.String"));
            dt.Columns.Add("Price", Type.GetType("System.Decimal"));
            dt.Columns.Add("ProductAmount", Type.GetType("Int32"));
            dt.Columns.Add("SumPrice", Type.GetType("System.Decimal"));//String.Format("0.00", dtTable.Columns["TestQuantity"]);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["run"] };
        }

        private void OrderTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (OrderTab.SelectedTab == OrderTab.TabPages["SundayTab"]) 
            {
                //ActiveTab("Sunday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["MondayTab"]) 
            {
               // ActiveTab("Monday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["TuesdayTab"])
            {
                //ActiveTab("Tuesday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["WednesdayTab"])
            {
                //ActiveTab("Wednesday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["ThursdayTab"])
            {
                //ActiveTab("Thursday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["FridayTab"])
            {
                //ActiveTab("Friday");
            }
            else if (OrderTab.SelectedTab == OrderTab.TabPages["SaturdayTab"])
            {
                //ActiveTab("Saturday");
            }
        }

        //private void ActiveTab(string tab)
        //{
        //    if (tab == "Sunday")
        //    {
        //        //SundayGrid.ColumnCount = 3;
        //        //SundayGrid.Columns[0].Name = "Product ID";
        //        //SundayGrid.Columns[1].Name = "Product Name";
        //        //SundayGrid.Columns[2].Name = "Product Price";

        //        //string[] row = new string[] { "1", "Product 1", "1000" };
        //        //SundayGrid.Rows.Add(row);
        //        //row = new string[] { "2", "Product 2", "2000" };
        //        //SundayGrid.Rows.Add(row);
        //        //row = new string[] { "3", "Product 3", "3000" };
        //        //SundayGrid.Rows.Add(row);
        //        //row = new string[] { "4", "Product 4", "4000" };
        //        //SundayGrid.Rows.Add(row);

        //        //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
        //        //cmb.HeaderText = "Select Data";
        //        //cmb.Name = "cmb";
        //        //cmb.MaxDropDownItems = 4;
        //        //cmb.Items.Add("True");
        //        //cmb.Items.Add("False");
        //        //SundayGrid.Columns.Add(cmb);
        //    }
        //    else if (tab == "Monday")
        //    {

        //    }
        //    else if (tab == "Tuesday")
        //    {

        //    }
        //    else if (tab == "Wednesday")
        //    {

        //    }
        //    else if (tab == "Thursday")
        //    {

        //    }
        //    else if (tab == "Friday")
        //    {

        //    }
        //    else if (tab == "Saturday")
        //    {

        //    }
        //}
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

        private void ddlCustomerOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTabBindGrid();
        }

        private void MondayGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int LAST_COL = MondayGrid.Columns.Count;
            //int FIRST_COL = 0;
            //if (e.ColumnIndex >= FIRST_COL && e.ColumnIndex <= LAST_COL)
            //{
            //    object value = MondayGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //    MondayGrid.Columns[e.ColumnIndex].CellTemplate = new DataGridViewComboBoxCell();
            //    var cell = new DataGridViewComboBoxCell { Value = value };
            //    cell.Items.AddRange(_values);
            //    MondayGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] = cell;
            //}
        }

        private void MondayGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //int LAST_COL = MondayGrid.Columns.Count;
            //int FIRST_COL = 0;
            //if (e.ColumnIndex >= FIRST_COL && e.ColumnIndex <= LAST_COL )
            //{
            //    object value = MondayGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //    MondayGrid.Columns[e.ColumnIndex].CellTemplate = new DataGridViewTextBoxCell();
            //    var cell = new DataGridViewTextBoxCell { Value = value };
            //    MondayGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] = cell;
            //}
        }

        private void SetUpDataGridView(DataGridView grid)
        {
            grid.DataError += new
                DataGridViewDataErrorEventHandler(DataGridView_DataError);
            //grid.CellContentClick += new
            //    DataGridViewCellEventHandler(DataGridView_CellContentClick);
            //grid.CellValuePushed += new
            //    DataGridViewCellValueEventHandler(DataGridView_CellValuePushed);
            //grid.CellValueNeeded += new
            //    DataGridViewCellValueEventHandler(DataGridView_CellValueNeeded);
        }
        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (IsANonHeaderLinkCell(grid,e))
            {
                MoveToLinked(grid,e);
            }
            else if (IsANonHeaderButtonCell(grid, e))
            {
                //PopulateSales(grid,e);
            }
        }
        private void MoveToLinked(DataGridView grid, DataGridViewCellEventArgs e)
        {
            //string employeeId;
            //object value = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //if (value is DBNull) { return; }

            //employeeId = value.ToString();
            ////DataGridViewCell boss = RetrieveSuperiorsLastNameCell(employeeId);
            //if (boss != null)
            //{
            //    grid.CurrentCell = boss;
            //}
        }

        private bool IsANonHeaderLinkCell(DataGridView grid,DataGridViewCellEventArgs cellEvent)
        {
            if (grid.Columns[cellEvent.ColumnIndex] is DataGridViewLinkColumn && cellEvent.RowIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsANonHeaderButtonCell(DataGridView grid, DataGridViewCellEventArgs cellEvent)
        {
            if (grid.Columns[cellEvent.ColumnIndex] is
                DataGridViewButtonColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return (false); }
        }





        #region "checkbox state"


        Dictionary<string, bool> inOffice = new Dictionary<string, bool>();
        private void DataGridView_CellValuePushed(object sender,DataGridViewCellValueEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (IsCheckBoxColumn(grid,e.ColumnIndex))
            {
                string employeeId = GetKey(grid,e);
                if (!inOffice.ContainsKey(employeeId))
                {
                    inOffice.Add(employeeId, (Boolean)e.Value);
                }
                else
                {
                    inOffice[employeeId] = (Boolean)e.Value;
                }
            }
        }

        private string GetKey(DataGridView grid,DataGridViewCellValueEventArgs cell)
        {
            return grid.Rows[cell.RowIndex].Cells[ColumnName.ProductID.ToString()].Value.ToString();
        }

        private void DataGridView_CellValueNeeded(object sender,DataGridViewCellValueEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (IsCheckBoxColumn(grid, e.ColumnIndex))
            {
                string employeeId = GetKey(grid,e);
                if (!inOffice.ContainsKey(employeeId))
                {
                    bool defaultValue = false;
                    inOffice.Add(employeeId, defaultValue);
                }
                e.Value = inOffice[employeeId];
            }
        }

        private bool IsCheckBoxColumn(DataGridView grid,int columnIndex)
        {
            DataGridViewColumn outOfOfficeColumn =grid.Columns[ColumnName.OrderStatus.ToString()];

            return (grid.Columns[columnIndex] == outOfOfficeColumn);
        }
        #endregion
    }
}
