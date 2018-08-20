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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private DateTime sundate, mondate, tuedate, weddate, thudate, fridate, satdate;
        public OrderUC()
        {
            InitializeComponent();
            HelperCS.AutoCompleteLoadValues(ComboOrderCustomer, "Customer");
            CheckDate();
            lblEditmode.Text = "";
        }
        /*
        public void ToggleOrder(string name, bool status)
        {
            if (name == "Sunday")
            {
                this.SundayToggle.Checked = status;
                this.SundayToggle.Invalidate();
                this.SundayToggle.Update();
            }
            else if (name == "Monday")
            {
                MondayToggle.Checked = status;
                this.MondayToggle.Invalidate();
                this.MondayToggle.Update();
            }
            else if (name == "Tueday")
            {
                TuesdayToggle.Checked = status;
                this.TuesdayToggle.Invalidate();
                this.TuesdayToggle.Update();
            }
            else if (name == "Wednesday")
            {
                WednesdayToggle.Checked = status;
                this.WednesdayToggle.Invalidate();
                this.WednesdayToggle.Update();
            }
            else if (name == "Thursday")
            {
                ThursdayToggle.Checked = status;
                this.ThursdayToggle.Invalidate();
                this.ThursdayToggle.Update();
            }
            else if (name == "Friday")
            {
                FridayToggle.Checked = status;
                this.FridayToggle.Invalidate();
                this.FridayToggle.Update();
            }
            else if (name == "Saturday")
            {
                SaturdayToggle.Checked = status;
                this.SaturdayToggle.Invalidate();
                this.SaturdayToggle.Update();
            }
            
        }
        public void ShowHideEditButton(string name,bool status)
        {
            if(name == "Sunday")
            {
                this.btnOrderEdit.Visible = status;
            }
            else if (name == "Monday")
            {
                this.btnOrderEdit.Visible = status;
            }
            else if (name == "Tueday")
            {
                this.btnOrderEdit.Visible = status;
            }
            else if (name == "Wednesday")
            {
                this.btnOrderEdit.Visible = status;
            }
            else if (name == "Thursday")
            {
                this.btnOrderEdit.Visible = status;
            }
            else if (name == "Friday")
            {
                this.btnOrderEdit.Visible = status;
            }
            else if (name == "Saturday")
            {
                this.btnOrderEdit.Visible = status;
            }
            this.btnOrderEdit.Invalidate();
            this.btnOrderEdit.Update();
        }
        */
        private void OrderUC_Load(object sender, EventArgs e)
        {
            btnOrderEdit.Visible = false;
            HelperCS.editmode = false;
            HelperCS.editprice = false;
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

        #region Method
        private void CheckTabActive()
        {
            OrderTab.AutoSize = true;
            //OrderTab.MaximumSize = //new (1800, 900);

            //check select customer beform bind data
            if (ComboOrderCustomer.SelectedIndex > 0)
            {
                HelperCS.editlabel = lblEditmode;
                HelperCS.editbtn = btnOrderEdit;
                if (OrderTab.SelectedTab == OrderTab.TabPages["SundayTab"])
                {
                    //if (chkbOrderSunday.Checked == true)
                    //{
                    //    HelperCS.WeekOrder[0] = true;
                    //    HelperCS.CreatePanelTable(pnlSundayHead, pnlMainSundayBody, "Sunday", customerid);
                    //}
                    //else
                    //{
                    //    HelperCS.WeekOrder[0] = false;
                    //    //ClearPanel("Sunday");
                    //}
                    chkbOrderSunday.Checked = HelperCS.editmode ? true : chkbOrderSunday.Checked;
                    HelperCS.WeekOrder[0] = chkbOrderSunday.Checked ? true : false;
                    HelperCS.daycheckbox = chkbOrderSunday;
                    HelperCS.CreatePanelTable(pnlSundayHead, pnlMainSundayBody, "Sunday", customerid);
                }
                else if (OrderTab.SelectedTab == OrderTab.TabPages["MondayTab"])
                {
                    //if (chkbOrderMonday.Checked == true)
                    //{
                    //    HelperCS.WeekOrder[1] = true;
                    //    HelperCS.CreatePanelTable(pnlMondayHead, pnlMainMondayBody, "Monday", customerid);
                    //}
                    //else
                    //{
                    //    HelperCS.WeekOrder[1] = false;
                    //    //ClearPanel("Monday");
                    //}
                    chkbOrderMonday.Checked = HelperCS.editmode ? true : chkbOrderMonday.Checked;
                    HelperCS.WeekOrder[1] = chkbOrderMonday.Checked ? true : false;
                    HelperCS.daycheckbox = chkbOrderMonday;
                    HelperCS.CreatePanelTable(pnlMondayHead, pnlMainMondayBody, "Monday", customerid);
                }
                else if (OrderTab.SelectedTab == OrderTab.TabPages["TuesdayTab"])
                {
                    //if (chkbOrderTuesday.Checked == true)
                    //{
                    //    HelperCS.WeekOrder[2] = true;
                    //    HelperCS.CreatePanelTable(pnlTuesdayHead, pnlMainTuesdayBody, "Tuesday", customerid);
                    //}
                    //else
                    //{
                    //    HelperCS.WeekOrder[2] = false;
                    //    //ClearPanel("Tuesday");
                    //}
                    chkbOrderTuesday.Checked = HelperCS.editmode ? true : chkbOrderTuesday.Checked;
                    HelperCS.WeekOrder[2] = chkbOrderTuesday.Checked ? true : false;
                    HelperCS.daycheckbox = chkbOrderTuesday;
                    HelperCS.CreatePanelTable(pnlTuesdayHead, pnlMainTuesdayBody, "Tuesday", customerid);
                }
                else if (OrderTab.SelectedTab == OrderTab.TabPages["WednesdayTab"])
                {
                    //if (chkbOrderWednesday.Checked == true)
                    //{
                    //    HelperCS.WeekOrder[3] = true;
                    //    HelperCS.CreatePanelTable(pnlWednesdayHead, pnlMainWednesdayBody, "Wednesday", customerid);
                    //}
                    //else
                    //{
                    //    HelperCS.WeekOrder[3] = false;
                    //    //ClearPanel("Wednesday");
                    //}
                    chkbOrderWednesday.Checked = HelperCS.editmode ? true : chkbOrderWednesday.Checked;
                    HelperCS.WeekOrder[3] = chkbOrderWednesday.Checked ? true : false;
                    HelperCS.daycheckbox = chkbOrderWednesday;
                    HelperCS.CreatePanelTable(pnlWednesdayHead, pnlMainWednesdayBody, "Wednesday", customerid);
                }
                else if (OrderTab.SelectedTab == OrderTab.TabPages["ThursdayTab"])
                {
                    //if (chkbOrderThursday.Checked == true)
                    //{
                    //    HelperCS.WeekOrder[4] = true;
                    //    HelperCS.CreatePanelTable(pnlThursdayHead, pnlMainThursdayBody, "Thursday", customerid);
                    //}
                    //else
                    //{
                    //    HelperCS.WeekOrder[4] = false;
                    //    //ClearPanel("Thursday");
                    //}
                    chkbOrderThursday.Checked = HelperCS.editmode ? true : chkbOrderThursday.Checked;
                    HelperCS.WeekOrder[4] = chkbOrderThursday.Checked ? true : false;
                    HelperCS.daycheckbox = chkbOrderThursday;
                    HelperCS.CreatePanelTable(pnlThursdayHead, pnlMainThursdayBody, "Thursday", customerid);
                }
                else if (OrderTab.SelectedTab == OrderTab.TabPages["FridayTab"])
                {
                    //if (chkbOrderFriday.Checked == true)
                    //{
                    //    HelperCS.WeekOrder[5] = true;
                    //    HelperCS.CreatePanelTable(pnlFridayHead, pnlMainFridayBody, "Friday", customerid);
                    //}
                    //else
                    //{
                    //    HelperCS.WeekOrder[5] = false;
                    //    //ClearPanel("Friday");
                    //}
                    chkbOrderFriday.Checked = HelperCS.editmode ? true : chkbOrderFriday.Checked;
                    HelperCS.WeekOrder[5] = chkbOrderFriday.Checked ? true : false;
                    HelperCS.daycheckbox = chkbOrderFriday;
                    HelperCS.CreatePanelTable(pnlFridayHead, pnlMainFridayBody, "Friday", customerid);
                }
                else if (OrderTab.SelectedTab == OrderTab.TabPages["SaturdayTab"])
                {
                    //if (chkbOrderSaturday.Checked == true)
                    //{
                    //    HelperCS.WeekOrder[6] = true;
                    //    HelperCS.CreatePanelTable(pnlSaturdayHead, pnlMainSaturdayBody, "Saturday", customerid);
                    //}
                    //else
                    //{
                    //    HelperCS.WeekOrder[6] = false;
                    //    //ClearPanel("Saturday");
                    //}
                    chkbOrderSaturday.Checked = HelperCS.editmode ? true : chkbOrderSaturday.Checked;
                    HelperCS.WeekOrder[6] = chkbOrderSaturday.Checked ? true : false;
                    HelperCS.daycheckbox = chkbOrderSaturday;
                    HelperCS.CreatePanelTable(pnlSaturdayHead, pnlMainSaturdayBody, "Saturday", customerid);
                }
            }
            else
            {
                //MetroMessageBox.Show(this, "Please Select Customer Before");
            }
        }

        private void ClearPanel(string day)
        {
            if (day == "Sunday")
            {
                HelperCS.dtSun = null;
                HelperCS.dayOrder[0] = "false";
                pnlSundayHead.Controls.Clear();
                pnlMainSundayBody.Controls.Clear();
            }
            else if (day == "Monday")
            {
                HelperCS.dtMon = null;
                HelperCS.dayOrder[1] = "false";
                pnlMondayHead.Controls.Clear();
                pnlMainMondayBody.Controls.Clear();
            }
            else if (day == "Tuesday")
            {
                HelperCS.dtTue = null;
                HelperCS.dayOrder[2] = "false";
                pnlTuesdayHead.Controls.Clear();
                pnlMainTuesdayBody.Controls.Clear();
            }
            else if (day == "Wednesday")
            {
                HelperCS.dtWed = null;
                HelperCS.dayOrder[3] = "false";
                pnlWednesdayHead.Controls.Clear();
                pnlMainWednesdayBody.Controls.Clear();
            }
            else if (day == "Thursday")
            {
                HelperCS.dtThu = null;
                HelperCS.dayOrder[4] = "false";
                pnlThursdayHead.Controls.Clear();
                pnlMainThursdayBody.Controls.Clear();
            }
            else if (day == "Friday")
            {
                HelperCS.dtFri = null;
                HelperCS.dayOrder[5] = "false";
                pnlFridayHead.Controls.Clear();
                pnlMainFridayBody.Controls.Clear();
            }
            else if (day == "Saturday")
            {
                HelperCS.dtSat = null;
                HelperCS.dayOrder[6] = "false";
                pnlSaturdayHead.Controls.Clear();
                pnlMainSaturdayBody.Controls.Clear();
            }
            else
            {
                HelperCS.dtSun = null;
                HelperCS.dtMon = null;
                HelperCS.dtTue = null;
                HelperCS.dtWed = null;
                HelperCS.dtThu = null;
                HelperCS.dtFri = null;
                HelperCS.dtSat = null;

                pnlSundayHead.Controls.Clear();
                pnlMondayHead.Controls.Clear();
                pnlTuesdayHead.Controls.Clear();
                pnlWednesdayHead.Controls.Clear();
                pnlThursdayHead.Controls.Clear();
                pnlFridayHead.Controls.Clear();
                pnlSaturdayHead.Controls.Clear();

                pnlMainSundayBody.Controls.Clear();
                pnlMainMondayBody.Controls.Clear();
                pnlMainTuesdayBody.Controls.Clear();
                pnlMainWednesdayBody.Controls.Clear();
                pnlMainThursdayBody.Controls.Clear();
                pnlMainFridayBody.Controls.Clear();
                pnlMainSaturdayBody.Controls.Clear();

                HelperCS.dayOrder = new string[7] { "false", "false", "false", "false", "false", "false", "false" };
            }
        }

        private void CheckDate()
        {
            DateTime date;
            string formatdate = "dddd dd MMMM yyyy"; ;
            if (HelperCS.currentdate != null)
            {
                date = HelperCS.currentdate;
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        {
                            HelperCS.sundate = date;
                            HelperCS.mondate = date.AddDays(1);
                            HelperCS.tuedate = date.AddDays(2);
                            HelperCS.weddate = date.AddDays(3);
                            HelperCS.thudate = date.AddDays(4);
                            HelperCS.fridate = date.AddDays(5);
                            HelperCS.satdate = date.AddDays(6);
                            OrderTab.SelectedTab = SundayTab;
                            break;
                        }
                    case DayOfWeek.Monday:
                        {
                            HelperCS.sundate = date.AddDays(-1);
                            HelperCS.mondate = date;
                            HelperCS.tuedate = date.AddDays(1);
                            HelperCS.weddate = date.AddDays(2);
                            HelperCS.thudate = date.AddDays(3);
                            HelperCS.fridate = date.AddDays(4);
                            HelperCS.satdate = date.AddDays(5);
                            OrderTab.SelectedTab = MondayTab;
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            HelperCS.sundate = date.AddDays(-2);
                            HelperCS.mondate = date.AddDays(-1);
                            HelperCS.tuedate = date;
                            HelperCS.weddate = date.AddDays(1);
                            HelperCS.thudate = date.AddDays(2);
                            HelperCS.fridate = date.AddDays(3);
                            HelperCS.satdate = date.AddDays(4);
                            OrderTab.SelectedTab = TuesdayTab;
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            HelperCS.sundate = date.AddDays(-3);
                            HelperCS.mondate = date.AddDays(-2);
                            HelperCS.tuedate = date.AddDays(-1);
                            HelperCS.weddate = date;
                            HelperCS.thudate = date.AddDays(1);
                            HelperCS.fridate = date.AddDays(2);
                            HelperCS.satdate = date.AddDays(3);
                            OrderTab.SelectedTab = WednesdayTab;
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            HelperCS.sundate = date.AddDays(-4);
                            HelperCS.mondate = date.AddDays(-3);
                            HelperCS.tuedate = date.AddDays(-2);
                            HelperCS.weddate = date.AddDays(-1);
                            HelperCS.thudate = date;
                            HelperCS.fridate = date.AddDays(1);
                            HelperCS.satdate = date.AddDays(2);
                            OrderTab.SelectedTab = ThursdayTab;
                            break;
                        }
                    case DayOfWeek.Friday:
                        {
                            HelperCS.sundate = date.AddDays(-5);
                            HelperCS.mondate = date.AddDays(-4);
                            HelperCS.tuedate = date.AddDays(-3);
                            HelperCS.weddate = date.AddDays(-2);
                            HelperCS.thudate = date.AddDays(-1);
                            HelperCS.fridate = date;
                            HelperCS.satdate = date.AddDays(1);
                            OrderTab.SelectedTab = FridayTab;
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            HelperCS.sundate = date.AddDays(-6);
                            HelperCS.mondate = date.AddDays(-5);
                            HelperCS.tuedate = date.AddDays(-4);
                            HelperCS.weddate = date.AddDays(-3);
                            HelperCS.thudate = date.AddDays(-2);
                            HelperCS.fridate = date.AddDays(-1);
                            HelperCS.satdate = date;
                            OrderTab.SelectedTab = SaturdayTab;
                            break;
                        }
                }
            }
            else // if(DatePicker.Value != null)
            {
                date = DatePicker.Value;
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        {
                            HelperCS.sundate = date;
                            HelperCS.mondate = date.AddDays(1);
                            HelperCS.tuedate = date.AddDays(2);
                            HelperCS.weddate = date.AddDays(3);
                            HelperCS.thudate = date.AddDays(4);
                            HelperCS.fridate = date.AddDays(5);
                            HelperCS.satdate = date.AddDays(6);
                            OrderTab.SelectedTab = SundayTab;
                            break;
                        }
                    case DayOfWeek.Monday:
                        {
                            HelperCS.sundate = date.AddDays(-1);
                            HelperCS.mondate = date;
                            HelperCS.tuedate = date.AddDays(1);
                            HelperCS.weddate = date.AddDays(2);
                            HelperCS.thudate = date.AddDays(3);
                            HelperCS.fridate = date.AddDays(4);
                            HelperCS.satdate = date.AddDays(5);
                            OrderTab.SelectedTab = MondayTab;
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            HelperCS.sundate = date.AddDays(-2);
                            HelperCS.mondate = date.AddDays(-1);
                            HelperCS.tuedate = date;
                            HelperCS.weddate = date.AddDays(1);
                            HelperCS.thudate = date.AddDays(2);
                            HelperCS.fridate = date.AddDays(3);
                            HelperCS.satdate = date.AddDays(4);
                            OrderTab.SelectedTab = TuesdayTab;
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            HelperCS.sundate = date.AddDays(-3);
                            HelperCS.mondate = date.AddDays(-2);
                            HelperCS.tuedate = date.AddDays(-1);
                            HelperCS.weddate = date;
                            HelperCS.thudate = date.AddDays(1);
                            HelperCS.fridate = date.AddDays(2);
                            HelperCS.satdate = date.AddDays(3);
                            OrderTab.SelectedTab = WednesdayTab;
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            HelperCS.sundate = date.AddDays(-4);
                            HelperCS.mondate = date.AddDays(-3);
                            HelperCS.tuedate = date.AddDays(-2);
                            HelperCS.weddate = date.AddDays(-1);
                            HelperCS.thudate = date;
                            HelperCS.fridate = date.AddDays(1);
                            HelperCS.satdate = date.AddDays(2);
                            OrderTab.SelectedTab = ThursdayTab;
                            break;
                        }
                    case DayOfWeek.Friday:
                        {
                            HelperCS.sundate = date.AddDays(-5);
                            HelperCS.mondate = date.AddDays(-4);
                            HelperCS.tuedate = date.AddDays(-3);
                            HelperCS.weddate = date.AddDays(-2);
                            HelperCS.thudate = date.AddDays(-1);
                            HelperCS.fridate = date;
                            HelperCS.satdate = date.AddDays(1);
                            OrderTab.SelectedTab = FridayTab;
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            HelperCS.sundate = date.AddDays(-6);
                            HelperCS.mondate = date.AddDays(-5);
                            HelperCS.tuedate = date.AddDays(-4);
                            HelperCS.weddate = date.AddDays(-3);
                            HelperCS.thudate = date.AddDays(-2);
                            HelperCS.fridate = date.AddDays(-1);
                            HelperCS.satdate = date;
                            OrderTab.SelectedTab = SaturdayTab;
                            break;
                        }
                }
            }
            lblDateSunday.Text = HelperCS.sundate.ToString(formatdate);
            lblDateMonday.Text = HelperCS.mondate.ToString(formatdate);
            lblDateTuesday.Text = HelperCS.tuedate.ToString(formatdate);
            lblDateWednesday.Text = HelperCS.weddate.ToString(formatdate);
            lblDateThursday.Text = HelperCS.thudate.ToString(formatdate);
            lblDateFriday.Text = HelperCS.fridate.ToString(formatdate);
            lblDateSaturday.Text = HelperCS.satdate.ToString(formatdate);
        }
        #endregion Method

        #region Event Click  
        private void btnOrderEdit_Click(object sender, EventArgs e)
        {

            //log.Info("Helper:UpdateOrder user:" + userName + " customerid:" + customerid.ToString() + " productid:" + pid.ToString() + " price:" + pprice.ToString() + " orderprice:" + oprice.ToString() + " amount:" + oamount.ToString());
            lblEditmode.Text = "แก้ไขข้อมูล";
            HelperCS.editmode = true;
            CheckTabActive();
        }

        private void btnOrderCalculate_Click(object sender, EventArgs e)
        {
            //CheckDate();
            CheckTabActive();
        }
        private void btnEditPrice_Click(object sender, EventArgs e)
        {
            DialogResult res = InputBox.ShowDialog("กรุณาใส่รหัสเพื่อแก้ไขราคาสินค้า:",
            "Authentication",   //Text message (mandatory), Title (optional)
                InputBox.Icon.Exclamation, //Set icon type (default info)
                InputBox.Buttons.OkCancel, //Set buttons (default ok)
                InputBox.Type.TextBoxPassword, //Set type (default nothing)
                new string[] { "Item1", "Item2", "Item3" }, //String field as ComboBox items (default null)
                true, //Set visible in taskbar (default false)
                new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold)); //Set font (default by system)

            if (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)
            {
                using (OrderEntities db = new OrderEntities())
                {
                    string passwd = InputBox.ResultValue != "" ? HelperCS.Encrypt(InputBox.ResultValue) : ""; //InputBox.ResultValue = textbox form dialogresult
                    int rownum = db.Login.Where(a => a.UserName == "PRICE" && a.Password == passwd).Count();
                    if (rownum > 0)
                    {
                        log.Info("OrderUC:Edit Price user:" + HelperCS.UserName + " customerid:" + ComboOrderCustomer.SelectedItem.ToString() + " day:" + HelperCS.daycheckbox.ToString());
                        HelperCS.editprice = true;
                        CheckTabActive();
                    }
                    else
                    {
                        log.Error("OrderUC:Edit Price Error user:" + HelperCS.UserName + " customerid:" + ComboOrderCustomer.SelectedItem.ToString() + " day:" + HelperCS.daycheckbox.ToString());
                        Form frm = btnEditPrice.FindForm();
                        MessageBox.Show(frm, "คุณไม่มีสิทธิ์แก้ไขข้อมูล ", "Authorization Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnOrderSave_Click(object sender, EventArgs e)
        {
            MetroTile btn = (MetroTile)sender;
            HelperCS.SaveAllOrder(btn);
            lblEditmode.Text = "";
            CheckTabActive();
        }

        #endregion Event Click   

        #region IndexChanged  
        //TAB      
        private void OrderTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form frm = OrderTab.FindForm();
            if (ComboOrderCustomer.SelectedIndex > 0)
            {
                HelperCS.dt = null;
                lblEditmode.Text = "";
                CheckTabActive();
            }
            else
            {
                //MessageBox.Show("Please Select Customer Before" ,"Select Customer",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                //MetroMessageBox.Show(frm, "Please Select Customer Before");
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
            else
            {
                ClearPanel("ALL");
            }
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            HelperCS.currentdate = DatePicker.Value;
            CheckDate();
            HelperCS.dt = null;
            CheckTabActive();
        }
        //TOGGLE DAY 'Not Use' change to checkbox *******************************************************
        private void DayToggle_CheckedChanged(object sender, EventArgs e)
        {
            CheckTabActive();
            //if (ComboOrderCustomer.SelectedIndex > 0)
            //{
            //    CheckTabActive();
            //}
            //else
            //{
            //    MessageBox.Show("Please Select Customer Before", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }
        //Check Order
        private void chkbOrderDay_CheckedChanged(object sender, EventArgs e)
        {
            MetroCheckBox chk = (MetroCheckBox)sender;
            if (chk.Checked)
            {
                chk.ForeColor = Color.Green;
            }
            else
            {
                chk.ForeColor = Color.Gray;
            }
            CheckTabActive();
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
