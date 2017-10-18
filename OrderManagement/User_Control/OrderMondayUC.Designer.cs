namespace OrderManagement.User_Control
{
    partial class OrderMondayUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboMondayCustomer = new System.Windows.Forms.ComboBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pnlMondayGridHead = new MetroFramework.Controls.MetroPanel();
            this.pnlMondayGridBody = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboMondayCustomer
            // 
            this.ComboMondayCustomer.FormattingEnabled = true;
            this.ComboMondayCustomer.Location = new System.Drawing.Point(3, 34);
            this.ComboMondayCustomer.Name = "ComboMondayCustomer";
            this.ComboMondayCustomer.Size = new System.Drawing.Size(391, 21);
            this.ComboMondayCustomer.TabIndex = 0;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel1.Controls.Add(this.ComboMondayCustomer);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(403, 63);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 12);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(81, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "metroLabel1";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // pnlMondayGridHead
            // 
            this.pnlMondayGridHead.BackColor = System.Drawing.Color.Transparent;
            this.pnlMondayGridHead.HorizontalScrollbarBarColor = true;
            this.pnlMondayGridHead.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMondayGridHead.HorizontalScrollbarSize = 10;
            this.pnlMondayGridHead.Location = new System.Drawing.Point(3, 73);
            this.pnlMondayGridHead.Name = "pnlMondayGridHead";
            this.pnlMondayGridHead.Size = new System.Drawing.Size(1273, 42);
            this.pnlMondayGridHead.TabIndex = 1;
            this.pnlMondayGridHead.UseCustomBackColor = true;
            this.pnlMondayGridHead.VerticalScrollbarBarColor = true;
            this.pnlMondayGridHead.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMondayGridHead.VerticalScrollbarSize = 10;
            // 
            // pnlMondayGridBody
            // 
            this.pnlMondayGridBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlMondayGridBody.HorizontalScrollbarBarColor = true;
            this.pnlMondayGridBody.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMondayGridBody.HorizontalScrollbarSize = 10;
            this.pnlMondayGridBody.Location = new System.Drawing.Point(3, 114);
            this.pnlMondayGridBody.Name = "pnlMondayGridBody";
            this.pnlMondayGridBody.Size = new System.Drawing.Size(1273, 733);
            this.pnlMondayGridBody.TabIndex = 2;
            this.pnlMondayGridBody.UseCustomBackColor = true;
            this.pnlMondayGridBody.VerticalScrollbarBarColor = true;
            this.pnlMondayGridBody.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMondayGridBody.VerticalScrollbarSize = 10;
            // 
            // OrderMondayUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMondayGridBody);
            this.Controls.Add(this.pnlMondayGridHead);
            this.Controls.Add(this.metroPanel1);
            this.Name = "OrderMondayUC";
            this.Size = new System.Drawing.Size(1279, 857);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox ComboMondayCustomer;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel pnlMondayGridHead;
        private MetroFramework.Controls.MetroPanel pnlMondayGridBody;
    }
}
