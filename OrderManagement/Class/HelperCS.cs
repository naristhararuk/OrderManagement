using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement.Entity;
using System.Drawing;
using MetroFramework.Controls;
using MetroFramework;
using MetroFramework.Forms;
using OrderManagement.Model;

namespace OrderManagement.Class
{
    class HelperCS
    {
        public static Font SegoeUIFont12 = new Font("Segoe UI", 12, FontStyle.Regular);
        public static DataTable dt;
        public static DataTable dtSun,dtMon,dtTue,dtWed,dtThu,dtFri,dtSat;
        public static DateTime sundate, mondate, tuedate, weddate, thudate, fridate, satdate;
        private static Panel pnl = new Panel();
        private static MetroPanel metropanel;
        private static MetroPanel metroHeadpanel;
        private static string dayTab;
        private static int Customerid;
        private static string ProductTextSelect;
        private static string ProductIdSelect;
        private static ComboBox productNew;
        public static string UserName;
        public static string[] EditMode = { "", "", "", "", "", "", "" };
        public static string[] dayOrder = { "false", "false", "false", "false", "false", "false", "false" };

        #region DATATABLE
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private static DataTable QueryAllResult(string tableName)
        {
            OrderEntities db = new OrderEntities();

            if (tableName == "Product")
            {
                //Select only ID and Name
                var query = from x in db.Product select x;
                return HelperCS.ToDataTable(query.ToList());
            }
            else if (tableName == "Customer")
            {
                var query = from x in db.Customer select x;
                return HelperCS.ToDataTable(query.ToList());
            }
            else if (tableName == "Config")
            {
                var query = from x in db.Config select x;
                return HelperCS.ToDataTable(query.ToList());
            }
            else if (tableName == "Order")
            {
                var query = from x in db.vwOrder select x;
                return HelperCS.ToDataTable(query.ToList());
            }
            else if (tableName == "Login")
            {
                var query = from x in db.Login select x;
                return HelperCS.ToDataTable(query.ToList());
            }
            else
            {
                return new DataTable();
            }
        }

        private static DataTable QueryResult(string tableName)
        {
            OrderEntities db = new OrderEntities();

            if (tableName == "Product")
            {
                //Select only ID and Name
                var query = from x in db.Product select new { x.ProductID, x.ProductName };
                return HelperCS.ToDataTable(query.ToList());
            }
            else if (tableName == "Customer")
            {
                var query = from x in db.Customer select new { x.CustomerID, x.CustomerName };
                return HelperCS.ToDataTable(query.ToList());
            }
            else
            {
                return new DataTable();
            }
        }

        public static DataTable GetDailyOrderTable(string day, int customerid)
        {
            using (var dailydb = new DailyOrderEntities())
            {
                // Get result from Stored Procedure
                var ds = dailydb.GetDailyOrder(day, customerid).ToList();
                return HelperCS.ToDataTable(ds);
                // if found item rows
                //if (ds.Count() > 0)
                //{
                //    return HelperCS.ToDataTable(ds);
                //}
                //else
                //{
                //    return new DataTable();
                //}
            }
        }
        public static DataTable GetOrderbyDayTable(string day, int customerid)
        {
            int index = 0;
            DateTime datewhere;
            if (day == "Sunday")
            {
                datewhere = sundate;
                index = 0;
            }
            else if (day == "Monday")
            {
                datewhere = mondate;
                index = 1;
            }
            else if (day == "Tuesday")
            {
                datewhere = tuedate;
                index = 2;
            }
            else if (day == "Wednesday")
            {
                datewhere = weddate;
                index = 3;
            }
            else if (day == "Thursday")
            {
                datewhere = thudate;
                index = 4;
            }
            else if (day == "Friday")
            {
                datewhere = fridate;
                index = 5;
            }
            else if (day == "Saturday")
            {
                datewhere = satdate;
                index = 6;
            }
            else
            {
                datewhere = DateTime.Now;
            }
            using (var dailydb = new DailyOrderEntities())
            {
                // Get result from Stored Procedure
                var ds = dailydb.GetOrderbyDay(datewhere, customerid).ToList();

                if (ds.Count() > 0)
                {
                    EditMode[index] = "แก้ไขข้อมูล";
                    return HelperCS.ToDataTable(ds);
                }
                else
                {
                    EditMode[index] = "";
                    var ds2 = dailydb.GetDailyOrder(day, customerid).ToList();
                    return HelperCS.ToDataTable(ds2);
                    //return new DataTable();
                }
            }
        }
        #endregion DATATABLE

        #region DAILY PANEL TABLE
        public static void CreatePanelTable(MetroPanel MainHeadPanel, MetroPanel MainPanel, string day, int customerid)
        {
            Customerid = customerid;
            MainPanel.BackColor = Color.Transparent;
            metropanel = MainPanel;
            metroHeadpanel = MainHeadPanel;
            dayTab = day;
            TableLayoutPanel tableheadpanel = new TableLayoutPanel();
            tableheadpanel.ColumnCount = 7;
            tableheadpanel.RowCount = 1;
            tableheadpanel.Width = 1000;
            tableheadpanel.Dock = DockStyle.Fill;
            //set column width
            tableheadpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableheadpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableheadpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableheadpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableheadpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableheadpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableheadpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));

            //set Style
            tableheadpanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableheadpanel.Font = HelperCS.SegoeUIFont12;

            //set column Header
            tableheadpanel.Controls.Add(new Label() { Text = "ลบ" }, 0, 0);
            tableheadpanel.Controls.Add(new Label() { Text = "ProductID" }, 1, 0);
            tableheadpanel.Controls.Add(new Label() { Text = "ชื่อสินค้า" }, 2, 0);
            tableheadpanel.Controls.Add(new Label() { Text = "ราคา" }, 3, 0);
            tableheadpanel.Controls.Add(new Label() { Text = "หน่วยยก" }, 4, 0);
            tableheadpanel.Controls.Add(new Label() { Text = "จำนวน" }, 5, 0);
            tableheadpanel.Controls.Add(new Label() { Text = "ราคาทั้งหมด" }, 6, 0);

            MainHeadPanel.Controls.Clear();
            MainHeadPanel.Controls.Add(tableheadpanel);
            //add dynamic
            //Table.Controls.Add(new Label() { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            //Table.Controls.Add(new ComboBox() { Dock = DockStyle.Fill }, 0, 1);
            TableLayoutPanel tablepanel = new TableLayoutPanel();
            tablepanel.ColumnCount = 7;
            tablepanel.RowCount = 1;
            tablepanel.Width = 1200;
            tablepanel.Dock = DockStyle.Fill;
            //tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tablepanel.Font = HelperCS.SegoeUIFont12;

            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
           
            //DataTable dt = GetDailyOrderTable(day, customerid);
            if (dt == null)
            {
                //dt = 
                //if no result value from date get max by day
                dt = GetOrderbyDayTable(day, customerid);
            }


            if (dt.Rows.Count > 0)
            {
                //tablepanel.RowCount = dt.Rows.Count;
                //tablepanel.RowCount = tablepanel.RowCount + 1;
                for (int i = 0; i <= dt.Rows.Count; i++)
                {
                    // tablepanel.RowCount = tablepanel.RowCount + 1;
                    tablepanel.RowCount = i;
                    if (i != dt.Rows.Count)
                    {
                        DataRow dr = dt.Rows[i];
                        //Add Remove button
                        MetroTile bt = new MetroTile();
                        bt.UseCustomBackColor = true;
                        bt.BackColor = Color.Transparent;
                        bt.BackgroundImage = OrderManagement.Properties.Resources.remove2_16;
                        bt.Size = new Size(20, 20);
                        bt.Click += new System.EventHandler(ButtonTileRemove_Click);
                        bt.Name = dr["ProductID"].ToString();
                        bt.BackgroundImageLayout = ImageLayout.Center;


                        NumericTextBox txtprice = new NumericTextBox();
                        //MetroTextBox txtamount = new MetroTextBox();
                        txtprice.Name = dr["ProductID"].ToString();
                        txtprice.Text = dr["OrderPrice"].ToString();
                        txtprice.MaxLength = 12;
                        txtprice.Width = 60;
                        txtprice.Margin = new Padding(0);
                        txtprice.Height = 25;
                        txtprice.TextAlign = HorizontalAlignment.Center;
                        txtprice.BorderStyle = BorderStyle.None;
                        txtprice.Dock = DockStyle.Fill;
                        txtprice.Leave += new EventHandler(TextBoxPriceInput_Leave);
                        Panel pnlprice = new Panel();
                        pnlprice.BorderStyle = BorderStyle.Fixed3D;
                        pnlprice.Width = 120;
                        pnlprice.Height = 25;
                        pnlprice.Padding = new Padding(5, 0, 5, 0);
                        pnlprice.Controls.Add(txtprice);

                        NumericTextBox txtamount = new NumericTextBox();
                        //MetroTextBox txtamount = new MetroTextBox();
                        txtamount.Name = dr["ProductID"].ToString();
                        txtamount.Text = dr["OrderAmount"].ToString();
                        txtamount.MaxLength = 10;
                        txtamount.Width = 60;
                        txtamount.Margin = new Padding(0); 
                        txtamount.Height = 25;
                        txtamount.TextAlign = HorizontalAlignment.Center;
                        txtamount.BorderStyle = BorderStyle.None;
                        txtamount.Dock = DockStyle.Fill;
                        txtamount.Leave += new EventHandler(TextBoxInput_Leave);
                        
                        Panel pnl = new Panel();
                        pnl.BorderStyle = BorderStyle.Fixed3D;
                        pnl.Width = 60;
                        pnl.Height = 25;
                        pnl.Padding = new Padding(5,0,5,0);
                        //pnl.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                        //pnl.Dock = DockStyle.Fill;
                        pnl.Controls.Add(txtamount);
                        
                        //Add Control to cell table
                        tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
                        tablepanel.Controls.Add(bt, 0, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = dr["ProductID"].ToString() }, 1, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = dr["ProductName"].ToString() }, 2, tablepanel.RowCount - 1);
                        //tablepanel.Controls.Add(new Label() { Text = dr["OrderPrice"].ToString() }, 3, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(pnlprice, 3, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = dr["Unit"].ToString() }, 4, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(pnl, 5, tablepanel.RowCount - 1);
                        
                        decimal total = Convert.ToDecimal(dr["OrderPrice"].ToString()) * Convert.ToDecimal(dr["OrderAmount"].ToString());
                        dr["OrderTotal"] = total.ToString("0.00");
                        tablepanel.Controls.Add(new Label() { Text = total.ToString("0.00") }, 6, tablepanel.RowCount - 1);

                    }
                    else
                    {
                        tablepanel.RowCount = tablepanel.RowCount + 1;

                        productNew = AutoCompleteProductNotExist();
                        productNew.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                        productNew.SelectedIndexChanged += new EventHandler(ComboProductSelect_IndexChanged);
                        MetroTile btAdd = new MetroTile();
                        btAdd.UseCustomBackColor = true;
                       // btAdd.BackColor = Color.Honeydew;
                        btAdd.BackgroundImage = OrderManagement.Properties.Resources.add_22;
                        btAdd.Size = new Size(24, 24);
                        btAdd.BackgroundImageLayout = ImageLayout.Center;
                        btAdd.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                        btAdd.Click += new System.EventHandler(ButtonTileAdd_Click);

                        Panel pnl = new Panel();
                        pnl.Dock = DockStyle.Fill;
                        pnl.Height = 50;
                        pnl.Margin = new Padding(0);
                        pnl.Controls.Add(productNew);
                        pnl.Controls.Add(btAdd);

                        tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute,100F));

                        //tableheadpanel.BackColor = Color.LightGray;

                        tablepanel.Controls.Add(new Label() { Text = "" }, 0, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = "เพิ่มสินค้า" }, 1, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(pnl, 2, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = "" }, 3, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = "" }, 4, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = "" }, 5, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = "" }, 6, tablepanel.RowCount - 1);

                        tablepanel.GetControlFromPosition(1, (tablepanel.RowCount - 1)).BackColor = Color.WhiteSmoke;

                    }
                }

            }
            else
            {
                tablepanel.RowCount = tablepanel.RowCount + 1;

                productNew = AutoCompleteProductNotExist();
                productNew.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                productNew.SelectedIndexChanged += new EventHandler(ComboProductSelect_IndexChanged);
                MetroTile btAdd = new MetroTile();
                btAdd.UseCustomBackColor = true;
                // btAdd.BackColor = Color.Honeydew;
                btAdd.BackgroundImage = OrderManagement.Properties.Resources.add_22;
                btAdd.Size = new Size(24, 24);
                btAdd.BackgroundImageLayout = ImageLayout.Center;
                btAdd.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                btAdd.Click += new System.EventHandler(ButtonTileAdd_Click);

                Panel pnl = new Panel();
                pnl.Dock = DockStyle.Fill;
                pnl.Height = 50;
                pnl.Margin = new Padding(0);
                pnl.Controls.Add(productNew);
                pnl.Controls.Add(btAdd);

                tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                //tableheadpanel.BackColor = Color.LightGray;

                tablepanel.Controls.Add(new Label() { Text = "" }, 0, tablepanel.RowCount - 1);
                tablepanel.Controls.Add(new Label() { Text = "เพิ่มสินค้า" }, 1, tablepanel.RowCount - 1);
                tablepanel.Controls.Add(pnl, 2, tablepanel.RowCount - 1);
                tablepanel.Controls.Add(new Label() { Text = "" }, 3, tablepanel.RowCount - 1);
                tablepanel.Controls.Add(new Label() { Text = "" }, 4, tablepanel.RowCount - 1);
                tablepanel.Controls.Add(new Label() { Text = "" }, 5, tablepanel.RowCount - 1);
                tablepanel.Controls.Add(new Label() { Text = "" }, 6, tablepanel.RowCount - 1);

                tablepanel.GetControlFromPosition(1, (tablepanel.RowCount - 1)).BackColor = Color.WhiteSmoke;
            }


            MainPanel.Controls.Clear();
            MainPanel.AutoScroll = true;
            MainPanel.VerticalScrollbar = true;
            MainPanel.VerticalScroll.Visible = true;
            MainPanel.Controls.Add(tablepanel);
            AddToDataTable(dayTab, tablepanel);
        }

        private static void AutoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;
        }
        #endregion DAILY PANEL TABLE

        #region CUSTOM CONTROLS TEXTBOX
        
        private static void TextBoxPriceInput_Leave(object sender, EventArgs e)
        {
            //TextBox txt = (TextBox)sender;
            //int productid;
            //if (Int32.TryParse(txt.Name, out productid))
            //{
            //    if (!string.IsNullOrEmpty(txt.Text))
            //    {
            //        UpdatePrice(productid, txt.Text);
            //    }
            //}
        }
        private static void TextBoxInput_Leave(object sender, EventArgs e)
        {
            //TextBox txt = (TextBox)sender;
            //int productid;
            //if (Int32.TryParse(txt.Name, out productid))
            //{
            //    DataTable dtamount = QueryAllResult("Product");
            //    int amount = (from DataRow dr in dtamount.Rows
            //              where (int)dr["ProductID"] == productid
            //                  select (int)dr["Amount"]).FirstOrDefault();

            //    if (!string.IsNullOrEmpty(txt.Text))
            //    {
            //        if (Convert.ToDecimal(txt.Text) > amount)
            //        {
            //            Form frm = txt.FindForm();
            //            MetroMessageBox.Show(frm, "จำนวนสินค้าไม่พอ!! สินค้ามีจำนวน " + amount.ToString() + " ชิ้น", "จำนวนไม่พอ", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //            txt.Text = amount.ToString();
            //            txt.Focus();
            //        }
            //        else
            //        {
            //            //Update Total
            //            UpdatePriceTotal(productid,txt.Text);
            //        }
            //    }
            //}
        }
        private static void ComboProductSelect_IndexChanged(object sender,EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;
            if (key != "")
            {
                //ProductIdSelect = int.Parse(key);
                ProductIdSelect = key;
                ProductTextSelect = value;
            }
            else
            {
                //Form frm = combo.FindForm();
                //MetroMessageBox.Show(frm, "Please select Product Before", "Not Select Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private static void UpdatePriceTotal(int productid,string amount)
        {
            if (dt.Rows.Count > 0) {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ProductID"].ToString() == productid.ToString())
                    {
                        dr["OrderAmount"] = Convert.ToDecimal(amount);
                    }
                }
            }
            CreatePanelTable(metroHeadpanel, metropanel, dayTab, Customerid);
        }

        private static void UpdatePrice(int productid, string price)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ProductID"].ToString() == productid.ToString())
                    {
                        dr["OrderPrice"] = Convert.ToDecimal(price);
                    }
                }
            }
            CreatePanelTable(metroHeadpanel, metropanel, dayTab, Customerid);
        }

        class NumericTextBox : System.Windows.Forms.TextBox
        {
            protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
            {
                base.OnKeyPress(e);
                //e.KeyChar 8 = backspace, 40 = down arrow, 13 = enter, 110 = decimal point  Char.IsNumber(e.KeyChar) ||
                //if (!( e.KeyChar == 8 || e.KeyChar == 40 || e.KeyChar == 13 || Char.IsDigit(e.KeyChar) || (e.KeyChar == '.' && base.Text.IndexOf('.') != -1) ))
                //{
                //    //if (e.KeyChar == 40) { }
                //    e.Handled = true;
                    
                //}
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 40))
                {
                    e.Handled = true;
                    return;
                }

                // checks to make sure only 1 decimal is allowed
                if (e.KeyChar == 46)
                {
                    if (base.Text.IndexOf(e.KeyChar) != -1)
                        e.Handled = true;
                }
            }
        }
        #endregion CUSTOM CONTROLS TEXTBOX

        #region ComboBox
        public static void AutoCompleteLoadValues(ComboBox autoCompleteCombo, string TableName)
        {
            autoCompleteCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            autoCompleteCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //Query to Datatable
            DataTable dt = QueryResult(TableName);

            Dictionary<string, string> Source = new Dictionary<string, string>();
            AutoCompleteStringCollection comboSource = new AutoCompleteStringCollection();

            //Add First Row
            DataRow firstrow = dt.NewRow();
            firstrow[1] = "--Please select " + TableName + "--";
            dt.Rows.InsertAt(firstrow, 0);
            Source.Add(firstrow[0].ToString(), firstrow[1].ToString());

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                //For query Data and add to combobox
                DataRow dr = dt.Rows[i];
                /* 0 = ID, 1 = Name (From Select Query) */
                Source.Add(dr[0].ToString(), dr[1].ToString());
                comboSource.Add(dr[1].ToString());
            }

            autoCompleteCombo.DataSource = new BindingSource(Source, null);
            autoCompleteCombo.AutoCompleteCustomSource = comboSource;
            autoCompleteCombo.Font = SegoeUIFont12;
            autoCompleteCombo.Size = new System.Drawing.Size(250, 200);
            autoCompleteCombo.DisplayMember = "Value";
            autoCompleteCombo.ValueMember = "Key";
        }
        public static ComboBox AutoCompleteProductNotExist()
        {
            ComboBox autoCompleteCombo = new ComboBox();
            autoCompleteCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            autoCompleteCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            DataTable pdt = QueryResult("Product");
            DataTable dtresult = new DataTable();
            Dictionary<string, string> Source = new Dictionary<string, string>();
            AutoCompleteStringCollection comboSource = new AutoCompleteStringCollection();

            var compare = pdt.AsEnumerable().Select(r => r.Field<int>("ProductID"))
                     .Except(dt.AsEnumerable().Select(r => r.Field<int>("ProductID")));

            if (compare.Count() > 0)
            {
                dtresult = (from row in pdt.AsEnumerable()
                            join id in compare
                            on row.Field<int>("ProductID") equals id
                            select row).CopyToDataTable();

                //Add First Row
                DataRow firstrow = dtresult.NewRow();
                firstrow[1] = "--โปรดเลือกสินค้า--";
                dtresult.Rows.InsertAt(firstrow, 0);
                Source.Add(firstrow[0].ToString(), firstrow[1].ToString());

                for (int i = 1; i < dtresult.Rows.Count; i++)
                {
                    //For query Data and add to combobox
                    DataRow dr = dtresult.Rows[i];
                    /* 0 = ID, 1 = Name (From Select Query) */
                    Source.Add(dr[0].ToString(), dr[1].ToString());
                    comboSource.Add(dr[1].ToString());
                }
            }
            else
            {
                //Add First Row
                Source.Add("", "--ไม่มีสินค้า--");
                comboSource.Add("--ไม่มีสินค้า--");
            }
            autoCompleteCombo.DataSource = new BindingSource(Source, null);
            autoCompleteCombo.AutoCompleteCustomSource = comboSource;
            autoCompleteCombo.Font = SegoeUIFont12;
            autoCompleteCombo.Size = new System.Drawing.Size(250, 200);
            autoCompleteCombo.DisplayMember = "Value";
            autoCompleteCombo.ValueMember = "Key";
            //pnl.Controls.Add(autoCompleteCombo);
            return autoCompleteCombo;
        }
        #endregion ComboBox

        #region BUTTON 
        private static void ButtonTileRemove_Click(object sender, EventArgs e)
        {
            MetroTile btn = (MetroTile)sender;
            // MessageBox.Show(btn.Name.ToString());
            //MetroMessageBox.Show(this, "Your message here.", "Title Here", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
            Form frm = btn.FindForm();
            DialogResult result = MetroMessageBox.Show(frm, "Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result.Equals(DialogResult.OK))
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr["ProductID"].ToString() == btn.Name.ToString())
                        dr.Delete();
                }
                CreatePanelTable(metroHeadpanel, metropanel, dayTab, Customerid);
            }
            else
            {
            }


        }
        private static void ButtonTileAdd_Click(object sender, EventArgs e)
        {
            MetroTile btn = (MetroTile)sender;
            Form frm = btn.FindForm();
            //string key = ((KeyValuePair<string, string>)productNew.SelectedItem).Key;
            //string value = ((KeyValuePair<string, string>)productNew.SelectedItem).Value;
            if(!string.IsNullOrEmpty(ProductIdSelect))
            {
                NewrowProductOrder(int.Parse(ProductIdSelect), ProductTextSelect);
            }
            else
            {
                MetroMessageBox.Show(frm, "Please select Product Before", "Not Select Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //MetroMessageBox.Show(frm, "Please select Product Before" + ProductIdSelect + ProductTextSelect, "Not Select Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        public static void SaveAllOrder(MetroTile btn)
        {
            Form frm = btn.FindForm();
            DateTime updatedate = DateTime.Now;
            int[] allresult = { 0, 0, 0, 0, 0, 0, 0 };

            //[OrderID],[OrderDate],[CustomerID],[ProductID],[ProductPrice],[OrderPrice],[OrderAmount],[OrderTotal],[Description],[OrderStatus],UpdateDate,UpdateBy
            try
            {
                #region Save Sunday
                if (dayOrder[0] == "true")
                {
                    
                    foreach (DataRow dr in dtSun.Rows)
                    {
                        int pid = int.Parse(dr["ProductID"].ToString());
                        decimal pprice = Convert.ToDecimal(dr["ProductPrice"].ToString());
                        decimal oprice = Convert.ToDecimal(dr["OrderPrice"].ToString());
                        int oamount = int.Parse(dr["OrderAmount"].ToString());
                        decimal ototal = Convert.ToDecimal(dr["OrderTotal"].ToString());
                        string description = EditMode[0];
                        bool status = true;

                        allresult[0] = SaveOrderToDatabase(sundate, Customerid, pid, pprice, oprice, oamount, ototal, description, status, updatedate, UserName);
                    }
                }
                else
                {

                }
                #endregion Save Sunday

                #region Save Monday
                if (dayOrder[1] == "true")
                {
                    foreach (DataRow dr in dtMon.Rows)
                    {
                        int pid = int.Parse(dr["ProductID"].ToString());
                        decimal pprice = Convert.ToDecimal(dr["ProductPrice"].ToString());
                        decimal oprice = Convert.ToDecimal(dr["OrderPrice"].ToString());
                        int oamount = int.Parse(dr["OrderAmount"].ToString());
                        decimal ototal = Convert.ToDecimal(dr["OrderTotal"].ToString());
                        string description = EditMode[1];
                        bool status = true;
                        allresult[1] = SaveOrderToDatabase(mondate, Customerid, pid, pprice, oprice, oamount, ototal, description, status, updatedate, UserName);
                    }
                }
                else
                {

                }
                #endregion Save Monday

                #region Save Tuesday
                if (dayOrder[2] == "true")
                {
                    foreach (DataRow dr in dtTue.Rows)
                    {
                        int pid = int.Parse(dr["ProductID"].ToString());
                        decimal pprice = Convert.ToDecimal(dr["ProductPrice"].ToString());
                        decimal oprice = Convert.ToDecimal(dr["OrderPrice"].ToString());
                        int oamount = int.Parse(dr["OrderAmount"].ToString());
                        decimal ototal = Convert.ToDecimal(dr["OrderTotal"].ToString());
                        string description = EditMode[2];
                        bool status = true;
                        
                        allresult[2] = SaveOrderToDatabase(tuedate, Customerid, pid, pprice, oprice, oamount, ototal, description, status, updatedate, UserName);
                    }
                }
                else
                {

                }
                #endregion Save Tuesday

                #region Save Wednesday
                if (dayOrder[3] == "true")
                {
                    foreach (DataRow dr in dtWed.Rows)
                    {
                        int pid = int.Parse(dr["ProductID"].ToString());
                        decimal pprice = Convert.ToDecimal(dr["ProductPrice"].ToString());
                        decimal oprice = Convert.ToDecimal(dr["OrderPrice"].ToString());
                        int oamount = int.Parse(dr["OrderAmount"].ToString());
                        decimal ototal = Convert.ToDecimal(dr["OrderTotal"].ToString());
                        string description = EditMode[3];
                        bool status = true;
                        
                        allresult[3] = SaveOrderToDatabase(weddate, Customerid, pid, pprice, oprice, oamount, ototal, description, status, updatedate, UserName);
                    }
                }
                else
                {

                }
                #endregion Save Wednesday

                #region Save Thursday
                if (dayOrder[4] == "true")
                {
                    foreach (DataRow dr in dtThu.Rows)
                    {
                        int pid = int.Parse(dr["ProductID"].ToString());
                        decimal pprice = Convert.ToDecimal(dr["ProductPrice"].ToString());
                        decimal oprice = Convert.ToDecimal(dr["OrderPrice"].ToString());
                        int oamount = int.Parse(dr["OrderAmount"].ToString());
                        decimal ototal = Convert.ToDecimal(dr["OrderTotal"].ToString());
                        string description = EditMode[4];
                        bool status = true;
                        
                        allresult[4] = SaveOrderToDatabase(thudate, Customerid, pid, pprice, oprice, oamount, ototal, description, status, updatedate, UserName);
                    }
                }
                else
                {

                }
                #endregion Save Thursday

                #region Save Friday
                if (dayOrder[5] == "true")
                {
                    foreach (DataRow dr in dtFri.Rows)
                    {
                        int pid = int.Parse(dr["ProductID"].ToString());
                        decimal pprice = Convert.ToDecimal(dr["ProductPrice"].ToString());
                        decimal oprice = Convert.ToDecimal(dr["OrderPrice"].ToString());
                        int oamount = int.Parse(dr["OrderAmount"].ToString());
                        decimal ototal = Convert.ToDecimal(dr["OrderTotal"].ToString());
                        string description = EditMode[5];
                        bool status = true;
                        
                        allresult[5] = SaveOrderToDatabase(fridate, Customerid, pid, pprice, oprice, oamount, ototal, description, status, updatedate, UserName);
                    }
                }
                else
                {

                }
                #endregion Save Friday

                #region Save Saturday
                if (dayOrder[6] == "true")
                {
                    foreach (DataRow dr in dtSat.Rows)
                    {
                        int pid = int.Parse(dr["ProductID"].ToString());
                        decimal pprice = Convert.ToDecimal(dr["ProductPrice"].ToString());
                        decimal oprice = Convert.ToDecimal(dr["OrderPrice"].ToString());
                        int oamount = int.Parse(dr["OrderAmount"].ToString());
                        decimal ototal = Convert.ToDecimal(dr["OrderTotal"].ToString());
                        string description = EditMode[6];
                        bool status = true;
                        
                        allresult[6] = SaveOrderToDatabase(satdate, Customerid, pid, pprice, oprice, oamount, ototal, description, status, updatedate, UserName);
                    }
                }
                else
                {

                }
                #endregion Save Saturday
                int all = 0;
                string problem = "ข้อมูลมีปัญหา ";

                if (allresult[0] != 0)
                {
                    problem += "วันอาทิตย์ ";
                    all += allresult[0];
                }
                if (allresult[1] != 0)
                {
                    problem += "วันจันทร์ ";
                    all += allresult[1];
                }
                if (allresult[2] != 0)
                {
                    problem += "วันอังคาร ";
                    all += allresult[2];
                }
                if (allresult[3] != 0)
                {
                    problem += "วันพุธ ";
                    all += allresult[3];
                }
                if (allresult[4] != 0)
                {
                    problem += "วันพฤหัส ";
                    all += allresult[4];
                }
                if (allresult[5] != 0)
                {
                    problem += "วันศุกร์ ";
                    all += allresult[5];
                }
                if (allresult[6] != 0)
                {
                    problem += "วันเสาร์ ";
                    all += allresult[6];
                }

                if (all != 0)
                {
                    MetroMessageBox.Show(frm, "Some Data has Problem Cannot Save to Database ", "Save to Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MetroMessageBox.Show(frm, "Data has been Save to Database ", "Save to Database", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(frm, "Some Problem When Save to Database \r\n Message:"+ex.Message, "Save to Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static int SaveOrderToDatabase(DateTime orderdate, int customerid, int pid, decimal pprice, decimal oprice, int oamount, decimal ototal, string description, bool status, DateTime updatedate, string userName)
        {
            int result = 1;

            using (var db = new DailyOrderEntities())
            {
                if(EditMode[IndexDateofWeek(orderdate)] == "")
                {
                    //Insert
                    var ds = db.InsertOrder(orderdate, updatedate, customerid, pid,pprice,oprice,oamount,ototal,description,status,userName).ToList();
                    if (ds.Count() > 0)
                    {
                        result = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                    }
                    else
                    {
                        result = 99;
                    }
                }
                else
                {
                    //Update
                    //var ds = db.UpdateOrder(orderdate, updatedate, customerid, pid, pprice, oprice, oamount, ototal, description, status, userName).ToList();
                    //if (ds.Count() > 0)
                    //{
                    //    result = ds[0] != null ? int.Parse(ds[0].ToString()) : 99;
                    //}
                    //else
                    //{
                    //    result = 99;
                    //}
                }
                // Get result from Stored Procedure
                


            }
            //When Save Success must return 0
            return result;
        }

        private static int IndexDateofWeek(DateTime date)
        {
            int dw = (int)date.DayOfWeek; 
            return dw;
        }

        #endregion BUTTON 

        #region METHOD
        private static void AddToDataTable(string dayTab, TableLayoutPanel tablepanel)
        {
            if (dayTab == "Sunday")
            {
                dtSun = null;
                //for tablepanel to dtSun
                dtSun = dt;
                dayOrder[0] = "true";
            }
            else if (dayTab == "Monday")
            {
                dtMon = null;
                //for tablepanel to dtMon
                dtMon = dt;
                dayOrder[1] = "true";
            }
            else if (dayTab == "Tuesday")
            {
                dtTue = null;
                //for tablepanel to dtTue
                dayOrder[2] = "true";
            }
            else if (dayTab == "Wednesday")
            {
                dtWed = null;
                //for tablepanel to dtWed
                dayOrder[3] = "true";
            }
            else if (dayTab == "Thursday")
            {
                dtThu = null;
                //for tablepanel to dtThu
                dayOrder[4] = "true";
            }
            else if (dayTab == "Friday")
            {
                dtFri = null;
                //for tablepanel to dtFri
                dayOrder[5] = "true";
            }
            else if (dayTab == "Saturday")
            {
                dtSat = null;
                //for tablepanel to dtSat
                dayOrder[6] = "true";
            }
        }
        private static void NewrowProductOrder(int productid, string productname)
        {
            //where All product get price
            DataTable pd = QueryAllResult("Product");
            //DataInfo.ProductList model = new DataInfo.ProductList();
            decimal price = (from DataRow dr in pd.Rows
                             where (int)dr["ProductID"] == productid
                             select (decimal)dr["Price"]).FirstOrDefault();
            int unit = (from DataRow dr in pd.Rows
                        where (int)dr["ProductID"] == productid
                        select (int)dr["Unit"]).FirstOrDefault();
            int amount = (from DataRow dr in pd.Rows
                        where (int)dr["ProductID"] == productid
                        select (int)dr["Amount"]).FirstOrDefault();

            if (amount >= 1)
            {
                //add new row to display
                DataRow row = dt.NewRow();
                // OrderID OrderDate   CustomerID ProductID   ProductPrice OrderPrice  OrderAmount OrderTotal  Description OrderStatus WeekDay ProductName Unit Amount
                row["OrderID"] = 9;
                row["OrderDate"] = DateTime.Now.ToShortDateString();
                row["CustomerID"] = Customerid.ToString();
                row["ProductID"] = productid;
                row["ProductPrice"] = price.ToString("0.00");
                row["OrderPrice"] = price.ToString("0.00");
                row["OrderAmount"] = 1;
                row["OrderTotal"] = price.ToString("0.00");
                row["Description"] = null;
                row["OrderStatus"] = true;
                row["Weekday"] = dayTab;
                row["ProductName"] = productname;
                row["Unit"] = unit.ToString();
                row["Amount"] = amount;
                dt.Rows.Add(row);
                CreatePanelTable(metroHeadpanel, metropanel, dayTab, Customerid);
            }
            else
            {
                Form frm = metropanel.FindForm();
                MetroMessageBox.Show(frm, "จำนวนสินค้าไม่พอ!! สินค้ามีจำนวน " + amount.ToString() + " ชิ้น", "จำนวนไม่พอ", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

        }
        #endregion METHOD
    }
}
