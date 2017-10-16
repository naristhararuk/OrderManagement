namespace OrderManagement
{
    partial class Form4
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SundaytbPanel = new MetroFramework.Controls.MetroPanel();
            this.MondayCustomerCombo = new System.Windows.Forms.ComboBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.SundaytbHeadPanel = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SundaytbPanel
            // 
            this.SundaytbPanel.AutoScroll = true;
            this.SundaytbPanel.AutoScrollMinSize = new System.Drawing.Size(20, 20);
            this.SundaytbPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SundaytbPanel.HorizontalScrollbar = true;
            this.SundaytbPanel.HorizontalScrollbarBarColor = true;
            this.SundaytbPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.SundaytbPanel.HorizontalScrollbarSize = 10;
            this.SundaytbPanel.Location = new System.Drawing.Point(11, 75);
            this.SundaytbPanel.Name = "SundaytbPanel";
            this.SundaytbPanel.Size = new System.Drawing.Size(1400, 527);
            this.SundaytbPanel.TabIndex = 0;
            this.SundaytbPanel.VerticalScrollbar = true;
            this.SundaytbPanel.VerticalScrollbarBarColor = true;
            this.SundaytbPanel.VerticalScrollbarHighlightOnWheel = false;
            this.SundaytbPanel.VerticalScrollbarSize = 20;
            // 
            // MondayCustomerCombo
            // 
            this.MondayCustomerCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MondayCustomerCombo.FormattingEnabled = true;
            this.MondayCustomerCombo.Location = new System.Drawing.Point(107, 33);
            this.MondayCustomerCombo.Name = "MondayCustomerCombo";
            this.MondayCustomerCombo.Size = new System.Drawing.Size(234, 21);
            this.MondayCustomerCombo.TabIndex = 1;
            this.MondayCustomerCombo.SelectedIndexChanged += new System.EventHandler(this.MondayCustomerCombo_SelectedIndexChanged);
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.Controls.Add(this.SundaytbHeadPanel);
            this.metroPanel1.Controls.Add(this.SundaytbPanel);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1411, 606);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // SundaytbHeadPanel
            // 
            this.SundaytbHeadPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SundaytbHeadPanel.HorizontalScrollbarBarColor = true;
            this.SundaytbHeadPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.SundaytbHeadPanel.HorizontalScrollbarSize = 10;
            this.SundaytbHeadPanel.Location = new System.Drawing.Point(11, 21);
            this.SundaytbHeadPanel.Name = "SundaytbHeadPanel";
            this.SundaytbHeadPanel.Size = new System.Drawing.Size(1400, 48);
            this.SundaytbHeadPanel.TabIndex = 2;
            this.SundaytbHeadPanel.VerticalScrollbarBarColor = true;
            this.SundaytbHeadPanel.VerticalScrollbarHighlightOnWheel = false;
            this.SundaytbHeadPanel.VerticalScrollbarSize = 10;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 686);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.MondayCustomerCombo);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel SundaytbPanel;
        private System.Windows.Forms.ComboBox MondayCustomerCombo;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel SundaytbHeadPanel;
    }
}