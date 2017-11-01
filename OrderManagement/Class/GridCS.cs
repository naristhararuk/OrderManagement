using MetroFramework.Controls;
using OrderManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagement.Class
{
    class GridCS
    {
        private static int mintTotalRecords = 0;
        private static int mintPageSize = 0;
        private static int mintPageCount = 0;
        private static int mintCurrentPage = 1;


        public static void BindGrid(string tablename,MetroGrid grid,string pagesize,MetroLabel lblStatus )
        {
            lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblStatus.Enabled = false;
            lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            lblStatus.Location = new System.Drawing.Point(541, 727);
            lblStatus.Size = new System.Drawing.Size(83, 20);
            //lblStatus.TabIndex = 7;
            lblStatus.Text = "0 / 0";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //For Page view. send page display size
            mintPageSize = int.Parse(pagesize);
            mintTotalRecords = getCount(tablename);
            mintPageCount = mintTotalRecords / mintPageSize;

            // Adjust page count if the last page contains partial page.
            if (mintTotalRecords % mintPageSize > 0)
                mintPageCount++;

            mintCurrentPage = 0;

            loadGrid(tablename, grid, lblStatus);
        }
        private static int getCount(string tablename)
        {
            using (var db = new OrderEntities())
            {
                if (tablename == "Product")
                {
                    // Get result from Stored Procedure
                    var query = (from x in db.Product
                                 where x.Status == true
                                 select x).Count();
                    return query;
                }
                else if (tablename == "Customer")
                {
                    // Get result from Stored Procedure
                    var query = (from x in db.Product
                                 where x.Status == true
                                 select x).Count();
                    return query;
                }
                else
                {
                    return 0;
                }
            }
        }
        public static void loadGrid(string tablename, MetroGrid grid, MetroLabel txt)
        {
            string strSql = "";
            int intSkip = 0;

            intSkip = (mintCurrentPage * mintPageSize);

            // Select only the n records.
            //ds = //storeprocedure SelectGridPaging



            //// Populate Data Grid
            //grid.DataSource = ds.Tables["tblEmp"].DefaultView;

            // Show Status
            txt.Text = (mintCurrentPage + 1).ToString() +" / " + mintPageCount.ToString();

            //ds.Dispose();
        }
        public static void goFirst(string tablename, MetroGrid grid, MetroLabel lblStatus)
        {
            mintCurrentPage = 0;

            loadGrid(tablename, grid, lblStatus);
        }

        public static void goPrevious(string tablename, MetroGrid grid, MetroLabel lblStatus)
        {
            if (mintCurrentPage == mintPageCount)
                mintCurrentPage = mintPageCount - 1;

            mintCurrentPage--;

            if (mintCurrentPage < 1)
                mintCurrentPage = 0;

            loadGrid(tablename, grid, lblStatus);
        }

        public static void goNext(string tablename, MetroGrid grid, MetroLabel lblStatus)
        {
            mintCurrentPage++;

            if (mintCurrentPage > (mintPageCount - 1))
                mintCurrentPage = mintPageCount - 1;

            loadGrid(tablename, grid, lblStatus);
        }

        public static void goLast(string tablename, MetroGrid grid, MetroLabel lblStatus)
        {
            mintCurrentPage = mintPageCount - 1;

            loadGrid(tablename, grid, lblStatus);
        }
    }
}
