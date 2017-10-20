﻿using System;
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
        private static Panel pnl = new Panel();
        private static MetroPanel metropanel;
        private static MetroPanel metroHeadpanel;
        private static string dayTab;
        private static int Customerid;
        private static ComboBox productNew;

        class ProductModel
        {
            private int ProductID;
            private string ProductName;
            private string ProductAbbr;
            private decimal Price;
            private int Unit;
        }

        #region DataTable
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
        #endregion Datatable

        #region PanelTable   
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

            int rowcount = 20;
            //DataTable dt = GetDailyOrderTable(day, customerid);
            if (dt == null)
            {
                dt = GetDailyOrderTable(day, customerid);
            }


            if (dt.Rows.Count > 0)
            {
                //tablepanel.RowCount = dt.Rows.Count;
                //tablepanel.RowCount = tablepanel.RowCount + 1;
                for (int i = 0; i <= dt.Rows.Count; i++)
                {
                    tablepanel.RowCount = tablepanel.RowCount + 1;
<<<<<<< HEAD
                    
=======

>>>>>>> bbc41e100339a78d7d77f4b75dbc16077926a5a0

                    if (i != dt.Rows.Count)
                    {
                        tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
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
                        NumericTextBox txtamount = new NumericTextBox();
                        //MetroTextBox txtamount = new MetroTextBox();
                        txtamount.Text = dr["ProductAmount"].ToString();
                        txtamount.Width = 50;
                        txtamount.Height = 20;
                        
                        
                        //Add Control to cell table
                        tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
                        tablepanel.Controls.Add(bt, 0, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = dr["ProductID"].ToString() }, 1, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = dr["ProductName"].ToString() }, 2, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = dr["ProductPrice"].ToString() }, 3, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(new Label() { Text = dr["Unit"].ToString() }, 4, tablepanel.RowCount - 1);
                        tablepanel.Controls.Add(txtamount, 5, tablepanel.RowCount - 1);

                        decimal total = Convert.ToDecimal(dr["ProductPrice"].ToString()) * Convert.ToDecimal(dr["ProductAmount"].ToString());
                        tablepanel.Controls.Add(new Label() { Text = total.ToString("0.00") }, 6, tablepanel.RowCount - 1);

                    }
                    else
                    {
                        //tablepanel.RowCount = tablepanel.RowCount + 1;
                        MetroTile btAdd = new MetroTile();
                        btAdd.UseCustomBackColor = true;
                       // btAdd.BackColor = Color.Honeydew;
                        btAdd.BackgroundImage = OrderManagement.Properties.Resources.add_22;
                        btAdd.Size = new Size(24, 24);
                        btAdd.BackgroundImageLayout = ImageLayout.Center;
                        btAdd.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                        btAdd.Click += new System.EventHandler(ButtonTileAdd_Click);

                        productNew = AutoCompleteProductNotExist();
                        productNew.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                        Panel pnl = new Panel();
                        pnl.Dock = DockStyle.Fill;
                        pnl.Height = 50;
                        pnl.Margin = new Padding(0);
                        pnl.Controls.Add(productNew);
                        pnl.Controls.Add(btAdd);
<<<<<<< HEAD
                        tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
=======
                        //tableheadpanel.BackColor = Color.LightGray;


                        tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
>>>>>>> bbc41e100339a78d7d77f4b75dbc16077926a5a0
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
                for (int i = 0; i <= rowcount; i++)
                {
                    tablepanel.RowCount = tablepanel.RowCount + 1;
                    tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
                    //tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                    ComboBox comboProduct = new ComboBox();

                    //Bind Combobox and Add Indexchanged Event
                    HelperCS.AutoCompleteLoadValues(comboProduct, "Product");
                    comboProduct.SelectedIndexChanged += new System.EventHandler(AutoComplete_SelectedIndexChanged);

                    //tablepanel.Controls.Add(comboProduct);
                    tablepanel.Controls.Add(new Label() { Text = "888" }, 0, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 1, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "xxxxxxx@gmail.com" }, 2, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 3, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 4, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 5, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 6, tablepanel.RowCount - 1);

                }
            }


            MainPanel.Controls.Clear();
            MainPanel.AutoScroll = true;
            MainPanel.VerticalScrollbar = true;
            MainPanel.VerticalScroll.Visible = true;
            MainPanel.Controls.Add(tablepanel);
        }
        class NumericTextBox : System.Windows.Forms.TextBox
        {
            protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
            {
                base.OnKeyPress(e);

                //if ((e.KeyChar < '0' || e.KeyChar > '9' || e.KeyChar == '\b') && e.KeyChar != '.' )
                if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 11 || e.KeyChar == 40))
                {
                    if (e.KeyChar == 40) { }
                        //System.Windows.Forms.Control.SelectNextControl(NumericTextBox, true,true,true);
                    e.Handled = true;
                }
                   
            }
            //protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
            //{
            //    // Determine whether the key entered is the F1 key. If it is, display Help.
            //    if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Tab)
            //    {
            //        e.Handled = false;

            //    }
            //}
        }

        private static void AutoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;
        }
        #endregion PanelTable

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
        //public class Productobj
        //{
        //    public int ProductID { get; set; }
        //    public string ProductName { get; set; }
        //}
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
            CheckProductIDCanOrder();
            string key = ((KeyValuePair<string, string>)productNew.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)productNew.SelectedItem).Value;
            Form frm = btn.FindForm();
            if (key != "")
            {
                NewrowProductOrder(int.Parse(key), value);
                //MetroMessageBox.Show(frm, "select :" + value);
                //Hand = red, Exclamation = yellow, (Asterisk,Information = blue)
                //MetroMessageBox.Show(frm, "Please select Product:" + value, "Add New Product", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                MetroMessageBox.Show(frm, "Please select Product Before", "Not Select Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private static void CheckProductIDCanOrder()
        {

        }

        private static void NewrowProductOrder(int productid, string productname)
        {
            //where All product get price
            DataTable pd = QueryAllResult("Product");
            DataInfo.ProductList model = new DataInfo.ProductList();
            decimal price = (from DataRow dr in pd.Rows
                             where (int)dr["ProductID"] == productid
                             select (decimal)dr["Price"]).FirstOrDefault();
            int unit = (from DataRow dr in pd.Rows
                        where (int)dr["ProductID"] == productid
                        select (int)dr["Unit"]).FirstOrDefault();
            //add new row to display
            DataRow row = dt.NewRow();
            row["ProductID"] = productid;
            row["ProductName"] = productname;
            row["Unit"] = unit.ToString();
            row["ProductPrice"] = price.ToString("0.00");
            row["ProductAmount"] = 1;
            dt.Rows.Add(row);
            CreatePanelTable(metroHeadpanel, metropanel, dayTab, Customerid);

        }

    }
}