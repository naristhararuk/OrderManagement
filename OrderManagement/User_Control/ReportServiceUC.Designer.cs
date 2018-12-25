namespace OrderManagement.User_Control
{
    partial class ReportServiceUC
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
            this.btnCloseDialog = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // btnCloseDialog
            // 
            this.btnCloseDialog.ActiveControl = null;
            this.btnCloseDialog.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseDialog.Location = new System.Drawing.Point(862, 13);
            this.btnCloseDialog.Name = "btnCloseDialog";
            this.btnCloseDialog.Size = new System.Drawing.Size(20, 23);
            this.btnCloseDialog.TabIndex = 47;
            this.btnCloseDialog.TileImage = global::OrderManagement.Properties.Resources.close20;
            this.btnCloseDialog.UseCustomBackColor = true;
            this.btnCloseDialog.UseSelectable = true;
            this.btnCloseDialog.UseTileImage = true;
            this.btnCloseDialog.Click += new System.EventHandler(this.btnCloseDialog_Click);
            // 
            // ReportServiceUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCloseDialog);
            this.Name = "ReportServiceUC";
            this.Size = new System.Drawing.Size(902, 480);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnCloseDialog;
    }
}
