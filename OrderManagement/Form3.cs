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
            HelperCS.AutoCompleteLoadValues(comboBox1,"Product");
            HelperCS.AutoCompleteLoadValues(comboBox2, "Customer");
        }

        private void AutoCompleteCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string key = ((KeyValuePair<string, string>)combo.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)combo.SelectedItem).Value;
            //MessageBox.Show(key.ToString() + value.ToString());
        }
    }
}
