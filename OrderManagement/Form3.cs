using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using OrderManagement.Entity;
using OrderManagement.Class;

namespace OrderManagement
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
            loadAutoCompleteValues(comboBox1);
            Font Normal = new Font("Segoe UI", 12, FontStyle.Bold);
            //loadMetroAutoCompleteValues(metroComboBox1);

        }

        private void loadAutoCompleteValues(ComboBox autoCompleteCombo)
        {
            autoCompleteCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            autoCompleteCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            OrderEntities db = new OrderEntities();
            var query = from x in db.Product select x;
            DataTable products = HelperCS.ToDataTable(query.ToList());

            Dictionary<string, string> Source = new Dictionary<string, string>();
            AutoCompleteStringCollection comboSource = new AutoCompleteStringCollection();
            for (int i = 0; i < products.Rows.Count; i++)
            {
                DataRow dr = products.Rows[i];
                Source.Add(dr["ProductID"].ToString(), dr["ProductName"].ToString());
                comboSource.Add(dr["ProductName"].ToString());
            }

            autoCompleteCombo.DataSource = new BindingSource(Source, null);
            autoCompleteCombo.AutoCompleteCustomSource = comboSource;
            autoCompleteCombo.DisplayMember = "Value";
            autoCompleteCombo.ValueMember = "Key";
        }

        private void autoCompleteCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;

            MessageBox.Show(key + "   " + value);
        }
        private void loadMetroAutoCompleteValues(MetroComboBox autoCompleteCombo)
        {
            autoCompleteCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            autoCompleteCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            OrderEntities db = new OrderEntities();
            var query = from x in db.Product select x;
            DataTable products = HelperCS.ToDataTable(query.ToList());

            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            for (int i = 0; i < products.Rows.Count; i++)
            {
                DataRow dr = products.Rows[i];
                comboSource.Add(dr["ProductID"].ToString(), dr["ProductName"].ToString());
            }

            autoCompleteCombo.DataSource = new BindingSource(comboSource, null);
            autoCompleteCombo.DisplayMember = "Value";
            autoCompleteCombo.ValueMember = "Key";
        }

        private void MetroautoCompleteCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroComboBox combo = (MetroComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;

            MessageBox.Show(key + "   " + value);
        }
    }
}
