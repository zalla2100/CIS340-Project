namespace ShopEasy.UI
{
    partial class UserActionsForm
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
            this.usernameLbl = new System.Windows.Forms.Label();
            this.tableViewCmboBx = new System.Windows.Forms.ComboBox();
            this.viewCmboBxLbl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(1157, 23);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(73, 20);
            this.usernameLbl.TabIndex = 0;
            this.usernameLbl.Text = "username";
            // 
            // tableViewCmboBx
            // 
            this.tableViewCmboBx.FormattingEnabled = true;
            this.tableViewCmboBx.Items.AddRange(new object[] {
            "-select view-",
            "Products",
            "Invoices",
            "Customers"});
            this.tableViewCmboBx.Location = new System.Drawing.Point(33, 92);
            this.tableViewCmboBx.Name = "tableViewCmboBx";
            this.tableViewCmboBx.Size = new System.Drawing.Size(151, 28);
            this.tableViewCmboBx.TabIndex = 2;
            // 
            // viewCmboBxLbl
            // 
            this.viewCmboBxLbl.AutoSize = true;
            this.viewCmboBxLbl.Location = new System.Drawing.Point(33, 57);
            this.viewCmboBxLbl.Name = "viewCmboBxLbl";
            this.viewCmboBxLbl.Size = new System.Drawing.Size(44, 20);
            this.viewCmboBxLbl.TabIndex = 3;
            this.viewCmboBxLbl.Text = "View:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(246, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1003, 407);
            this.dataGridView1.TabIndex = 4;
            // 
            // UserActionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 551);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.viewCmboBxLbl);
            this.Controls.Add(this.tableViewCmboBx);
            this.Controls.Add(this.usernameLbl);
            this.Name = "UserActionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.ComboBox tableViewCmboBx;
        private System.Windows.Forms.Label viewCmboBxLbl;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}