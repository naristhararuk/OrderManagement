using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Class
{
    class MappingDAL
    {
        public static void SaveOrder()
        {

            //using (var db = new myDatabaseEntities())
            //{
            //    // Get Param
            //    string strCustomerID = this.txtCustomerID.Text;
            //    string strName = this.txtName.Text;
            //    string strEmail = this.txtEmail.Text;
            //    string strCountryCode = this.txtCountryCode.Text;
            //    decimal strBudget = Convert.ToDecimal(this.txtBudget.Text);
            //    decimal strUsed = Convert.ToDecimal(this.txtUsed.Text);

            //    // Insert data to CUSTOMER
            //    var ds = (from c in db.CUSTOMER
            //              where c.CUSTOMER_ID == strCustomerID
            //              select c).FirstOrDefault();
            //    // Insert
            //    if (ds != null)
            //    {
            //        MessageBox.Show(string.Format("Customer {0} Exists in table.", strCustomerID));
            //    }
            //    else
            //    {
            //        db.CUSTOMER.Add(new CUSTOMER()
            //        {
            //            CUSTOMER_ID = strCustomerID,
            //            NAME = strName,
            //            EMAIL = strEmail,
            //            COUNTRY_CODE = strCountryCode,
            //            BUDGET = strBudget,
            //            USED = strUsed,
            //        });
            //        db.SaveChanges();
            //        this.Close();
            //    }
            //}
        }
    }
}
