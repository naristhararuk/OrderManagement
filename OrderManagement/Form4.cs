using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using OrderManagement.Class;
using OrderManagement.Entity;
namespace OrderManagement
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        private int customerid = 0;
        public Form4()
        {
            InitializeComponent();
            
            HelperCS.AutoCompleteLoadValues(MondayCustomerCombo, "Customer");
         
            //BindTable();
        }

        /*
        private void BindTable()
        {
            //int rowcount = 0;
            //TableLayoutPanel panel = new TableLayoutPanel();
            string key = ((KeyValuePair<string, string>)MondayCustomerCombo.SelectedItem).Key;
            if (key != "")
            {
                
                HelperCS.CreatePanelTable(SundaytbPanel, "Monday", cusid);

                
                DataTable dt = HelperCS.GetDailyOrderTable("Monday", 1);
                if (dt.Rows.Count > 0)
                {
                    panel.RowCount = panel.RowCount + 1;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        panel.RowCount = i + 1;
                        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                        DataRow dr = dt.Rows[i];
                        panel.Controls.Add(new Label() { Text = dr[0].ToString() }, 1, panel.RowCount - 1);
                        panel.Controls.Add(new Label() { Text = dr[1].ToString() }, 2, panel.RowCount - 1);
                        panel.Controls.Add(new Label() { Text = dr[2].ToString() }, 3, panel.RowCount - 1);
                        panel.Controls.Add(new Label() { Text = dr[3].ToString() }, 4, panel.RowCount - 1);
                        panel.Controls.Add(new Label() { Text = dr[4].ToString() }, 5, panel.RowCount - 1);
                        panel.Controls.Add(new Label() { Text = dr[5].ToString() }, 6, panel.RowCount - 1);

                    }
                }
                else
                {
                    for (int i = 0; i < rowcount; i++)
                    {
                        panel.RowCount = rowcount + 1;
                        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                        ComboBox comboProduct = new ComboBox();

                        //Bind Combobox and Add Indexchanged Event
                        HelperCS.AutoCompleteLoadValues(comboProduct, "Product");
                        comboProduct.SelectedIndexChanged += new System.EventHandler(AutoCompleteCombo_SelectedIndexChanged);

                        panel.Controls.Add(comboProduct);
                        panel.Controls.Add(new Label() { Text = "888888888888" }, 1, panel.RowCount - 1);
                        panel.Controls.Add(new Label() { Text = "xxxxxxx@gmail.com" }, 2, panel.RowCount - 1);
                    }
                }
                
            }
        }*/


        //private void AutoCompleteCombo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ComboBox combo = (ComboBox)sender;
        //    string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
        //    string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;
        //}

        private void MondayCustomerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;
            if(key != "")
            {
                customerid = int.Parse(key);
                BindTable(customerid);
            }
        }

        private void BindTable(int cusid)
        {
            HelperCS.dt = null;
            HelperCS.CreatePanelTable(SundaytbHeadPanel,SundaytbPanel, "Monday", cusid);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //MetroMessageBox.Show(this, "Your message here.", "Title Here", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }
    }
}
