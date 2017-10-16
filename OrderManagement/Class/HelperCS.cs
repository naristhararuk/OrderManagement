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

namespace OrderManagement.Class
{
    class HelperCS
    {
        public static Font SegoeUIFont12 = new Font("Segoe UI", 12, FontStyle.Regular);
        private static DataTable dt;
        private static Panel pnl = new Panel();
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
        public static void CreatePanelTable(MetroPanel MainPanel, string day, int customerid)
        {
            TableLayoutPanel tablepanel = new TableLayoutPanel();
            tablepanel.ColumnCount = 7;
            tablepanel.RowCount = 1;
            tablepanel.Width = 1000 ;
            //set column width
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));

            //set Style
            tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tablepanel.Font = HelperCS.SegoeUIFont12;

            //set column Header
            tablepanel.Controls.Add(new Label() { Text = "#" }, 0, 0);
            tablepanel.Controls.Add(new Label() { Text = "OrderID" }, 1, 0);
            tablepanel.Controls.Add(new Label() { Text = "ชื่อสินค้า" }, 2, 0);
            tablepanel.Controls.Add(new Label() { Text = "ราคา" }, 3, 0);
            tablepanel.Controls.Add(new Label() { Text = "หน่วยยก" }, 4, 0);
            tablepanel.Controls.Add(new Label() { Text = "จำนวน" }, 5, 0);
            tablepanel.Controls.Add(new Label() { Text = "ราคาทั้งหมด" }, 6, 0);

            //add dynamic
            //Table.Controls.Add(new Label() { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            //Table.Controls.Add(new ComboBox() { Dock = DockStyle.Fill }, 0, 1);

            int rowcount = 0;
            //DataTable dt = GetDailyOrderTable(day, customerid);
            dt = GetDailyOrderTable(day, customerid);
            if (dt.Rows.Count > 0)
            {
                //tablepanel.RowCount = dt.Rows.Count;
                //tablepanel.RowCount = tablepanel.RowCount + 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tablepanel.RowCount = tablepanel.RowCount + 1;
                    tablepanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
                    DataRow dr = dt.Rows[i];
                    
                    //Add Remove button
                    MetroTile bt = new MetroTile();
                    bt.UseCustomBackColor = true;
                    bt.BackColor = Color.Transparent;
                    bt.BackgroundImage = OrderManagement.Properties.Resources.remove2_16;
                    bt.Size = new Size(20, 20);
                    bt.Click += new System.EventHandler(ButtonTileRemove_Click);
                    bt.Name = dr["OrderID"].ToString();
                    bt.BackgroundImageLayout = ImageLayout.Center;


                    //Add Control to cell table
                    tablepanel.Controls.Add(bt, 0, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = dr["OrderID"].ToString() }, 1, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = dr["ProductName"].ToString() }, 2, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = dr["ProductPrice"].ToString() }, 3, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = dr["Unit"].ToString() }, 4, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = dr["ProductAmount"].ToString() }, 5, tablepanel.RowCount - 1);

                    decimal total = Convert.ToDecimal(dr["ProductPrice"].ToString()) * Convert.ToDecimal(dr["ProductAmount"].ToString());
                    tablepanel.Controls.Add(new Label() { Text = total.ToString("0.00") }, 6, tablepanel.RowCount - 1);
                }
                
            }
            else
            {
                for (int i = 0; i <= rowcount; i++)
                {
                    tablepanel.RowCount = rowcount + 1;
                    //tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                    ComboBox comboProduct = new ComboBox();

                    //Bind Combobox and Add Indexchanged Event
                    HelperCS.AutoCompleteLoadValues(comboProduct, "Product");
                    comboProduct.SelectedIndexChanged += new System.EventHandler(AutoComplete_SelectedIndexChanged);

                    tablepanel.Controls.Add(comboProduct);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 1, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "xxxxxxx@gmail.com" }, 2, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 3, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 4, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 5, tablepanel.RowCount - 1);
                    tablepanel.Controls.Add(new Label() { Text = "888888888888" }, 6, tablepanel.RowCount - 1);
                    
                }
            }
            tablepanel.RowCount = tablepanel.RowCount + 1;
            tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            MetroTile btAdd = new MetroTile();
            btAdd.UseCustomBackColor = true;
            btAdd.BackColor = Color.Transparent;
            btAdd.BackgroundImage = OrderManagement.Properties.Resources.add_16;
            btAdd.Size = new Size(20, 20);
            btAdd.Click += new System.EventHandler(ButtonTileAdd_Click);
            btAdd.BackgroundImageLayout = ImageLayout.Center;

            //tablepanel.Controls.Add(btAdd, 0, tablepanel.RowCount - 1);
            //tablepanel.Controls.Add(pnl, 1, tablepanel.RowCount - 1);
            tablepanel.Controls.Add(new Label() { Text = "dfs" }, 0, tablepanel.RowCount - 1);
            tablepanel.Controls.Add(new Label() { Text = "sdf" }, 1, tablepanel.RowCount - 1);
            tablepanel.Controls.Add(new Label() { Text = "sfad" }, 2, tablepanel.RowCount - 1);
            tablepanel.Controls.Add(new Label() { Text = "sf" }, 3, tablepanel.RowCount - 1);
            tablepanel.Controls.Add(new Label() { Text = "fs" }, 4, tablepanel.RowCount - 1);
            tablepanel.Controls.Add(new Label() { Text = "fsd" }, 5, tablepanel.RowCount - 1);
            tablepanel.Controls.Add(new Label() { Text = "sf" }, 6, tablepanel.RowCount - 1);


            MainPanel.Controls.Add(tablepanel);
        }
        private static void AutoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;
        }
        #endregion PanelTable

        #region ComboBox
        public static void AutoCompleteLoadValues(ComboBox autoCompleteCombo,string TableName)
        {
            autoCompleteCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            autoCompleteCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //Query to Datatable
            DataTable dt = QueryResult(TableName);

            Dictionary <string, string> Source = new Dictionary<string, string>();
            AutoCompleteStringCollection comboSource = new AutoCompleteStringCollection();

            //Add First Row
            DataRow firstrow = dt.NewRow();
            firstrow[1] = "--Please select "+ TableName + "--";
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
            autoCompleteCombo.Size = new System.Drawing.Size(250,200);
            autoCompleteCombo.DisplayMember = "Value";
            autoCompleteCombo.ValueMember = "Key";
        }
        public class Productobj
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
        }
        public static void AutoCompleteProductNotExist()
        {
            ComboBox autoCompleteCombo = new ComboBox();
            autoCompleteCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            autoCompleteCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Query to Datatable
            DataTable pdt = QueryResult("Product");
            var  query = from pd in pdt.AsEnumerable()
                        join ordr in dt.AsEnumerable()
                        on pd["ProductID"] equals ordr["ProductID"] into a
                        from b in a.DefaultIfEmpty()
                        select new
                        {
                            Id = pd.Field<int>("ProductID"),
                            Name = pd.Field<string>("ProductName"),
                        };
            
            DataTable dtresult = ToDataTable(query.ToList());
            Dictionary<string, string> Source = new Dictionary<string, string>();
            AutoCompleteStringCollection comboSource = new AutoCompleteStringCollection();

            //Add First Row
            DataRow firstrow = dtresult.NewRow();
            firstrow[1] = "--โปรดเลือกสินค้า--";
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
            pnl.Controls.Add(autoCompleteCombo);
        }
        #endregion ComboBox

        private static void ButtonTileRemove_Click(object sender, EventArgs e)
        {
            MetroTile btn = (MetroTile)sender;
               MessageBox.Show(btn.Name.ToString());
        }
        private static void ButtonTileAdd_Click(object sender, EventArgs e)
        {
            MetroTile btn = (MetroTile)sender;
            CheckProductIDCanOrder();
        }

        private static void CheckProductIDCanOrder()
        {
            AutoCompleteProductNotExist();
        }
    }
}
