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
using OrderManagement.Class;
using MetroFramework;
namespace OrderManagement.User_Control
{
    public partial class OrderUC : UserControl
    {
        private int customerid = 0;
        private DateTime sundate, mondate, tuedate, weddate, thrdate, fridate, satdate;
        public OrderUC()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ComboOrderCustomer, "Customer");
            CheckDate();
        }

      

        private void OrderUC_Load(object sender, EventArgs e)
        {
            //CreateTemplateTable();
            //CheckTabBindGrid();
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
 /*       
        private void BindGrid(DataGridView grid, string day)
        {
            try
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    //int customerid = ddlCustomerOrder.SelectedIndex;
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

*/

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

        #region Method
        private void CheckTabActive()
        {
            OrderTab.AutoSize = true;

            //check select customer beform bind data
            if (ComboOrderCustomer.SelectedIndex > 0)
            {
                if (OrderTab.SelectedTab == OrderTab.TabPages["SundayTab"])
                {   OrderTab.TabPages[0].AutoSize = true;
                    //TabActive(SundayGrid, "Sunday");
                }
                else if (OrderTab.SelectedTab == OrderTab.TabPages["MondayTab"])
                {
                    //OrderTab.TabPages[1].AutoSize = true;
                    //pnlMainMondayBody.AutoScroll = true;
                    DateTime dt = DatePicker.Value;
                    txtbDateMonday.Text = dt.DayOfWeek.ToString() + dt.ToString("dd MM yyyy");
                    HelperCS.CreatePanelTable(pnlMondayHead, pnlMainMondayBody, "Monday", customerid);
                }
                else if (OrderTab.SelectedTab == OrderTab.TabPages["TuesdayTab"])
                {
                    //BindGrid(TuesdayGrid);
                    OrderTab.TabPages[2].AutoSize = true;
                    for (int i=0; i < 45; i++)
                    {
                        lbltest.Text += "\r\n sfdsafdfaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaf";
                    }

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
            else
            {
                MetroMessageBox.Show(this, "Please Select Customer Before");
            }
        }
        private void CheckDate()
        {
            if (DatePicker.Value != null)
            {
                DateTime date = DatePicker.Value;
                string formatdate = "dddd dd MMMM yyyy";
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        {
                            sundate = date;
                            mondate = date.AddDays(1);
                            tuedate = date.AddDays(2);
                            weddate = date.AddDays(3);
                            thrdate = date.AddDays(4);
                            fridate = date.AddDays(5);
                            satdate = date.AddDays(6);
                            break;
                        }
                    case DayOfWeek.Monday:
                        {
                            sundate = date.AddDays(-1);
                            mondate = date;
                            tuedate = date.AddDays(1);
                            weddate = date.AddDays(2);
                            thrdate = date.AddDays(3);
                            fridate = date.AddDays(4);
                            satdate = date.AddDays(5);
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            sundate = date.AddDays(-2);
                            mondate = date.AddDays(-1);
                            tuedate = date;
                            weddate = date.AddDays(1);
                            thrdate = date.AddDays(2);
                            fridate = date.AddDays(3);
                            satdate = date.AddDays(4);
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            sundate = date.AddDays(-3);
                            mondate = date.AddDays(-2);
                            tuedate = date.AddDays(-1);
                            weddate = date;
                            thrdate = date.AddDays(1);
                            fridate = date.AddDays(2);
                            satdate = date.AddDays(3);
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            sundate = date.AddDays(-4);
                            mondate = date.AddDays(-3);
                            tuedate = date.AddDays(-2);
                            weddate = date.AddDays(-1);
                            thrdate = date;
                            fridate = date.AddDays(1);
                            satdate = date.AddDays(2);
                            break;
                        }
                    case DayOfWeek.Friday:
                        {
                            sundate = date.AddDays(-5);
                            mondate = date.AddDays(-4);
                            tuedate = date.AddDays(-3);
                            weddate = date.AddDays(-2);
                            thrdate = date.AddDays(-1);
                            fridate = date;
                            satdate = date.AddDays(1);
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            sundate = date.AddDays(-6);
                            mondate = date.AddDays(-5);
                            tuedate = date.AddDays(-4);
                            weddate = date.AddDays(-3);
                            thrdate = date.AddDays(-2);
                            fridate = date.AddDays(-1);
                            satdate = date;
                            break;
                        }
                }

                txtbDateSunday.Text = sundate.ToString(formatdate);
                txtbDateMonday.Text = mondate.ToString(formatdate);
                txtbDateTuesday.Text = tuedate.ToString(formatdate);
                txtbDateWednesday.Text = weddate.ToString(formatdate);
                txtbDateThursday.Text = thrdate.ToString(formatdate);
                txtbDateFriday.Text = fridate.ToString(formatdate);
                txtbDateSaturday.Text = satdate.ToString(formatdate);

            }
        }
        #endregion Method

        #region IndexChanged  
        //TAB      
        private void OrderTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboOrderCustomer.SelectedIndex > 0)
            {
                CheckTabActive();
            }
            else
            {
                MetroMessageBox.Show(this, "Please Select Customer Before");
            }
        }

        //COMBO
        private void ComboOrderCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;
            if (key != "")
            {
                customerid = int.Parse(key);
                HelperCS.dt = null;
                CheckTabActive();
            }
        }

        private void TuesdayTab_Click(object sender, EventArgs e)
        {

        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            CheckDate();
        }

        #endregion IndexChanged

        /*
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


        */

        /*
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

                private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
                {

                }

                private void ddlCustomerOrder_SelectedIndexChanged(object sender, EventArgs e)
                {

                }
                */
    }
}
