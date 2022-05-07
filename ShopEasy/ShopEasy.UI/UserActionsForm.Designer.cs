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
            this.usernameDisplayLbl = new System.Windows.Forms.Label();
            this.tableViewCmboBx = new System.Windows.Forms.ComboBox();
            this.viewCmboBxLbl = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameDisplayLbl
            // 
            this.usernameDisplayLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameDisplayLbl.AutoSize = true;
            this.usernameDisplayLbl.Location = new System.Drawing.Point(1157, 23);
            this.usernameDisplayLbl.Name = "usernameDisplayLbl";
            this.usernameDisplayLbl.Size = new System.Drawing.Size(73, 20);
            this.usernameDisplayLbl.TabIndex = 0;
            this.usernameDisplayLbl.Text = "username";
            // 
            // tableViewCmboBx
            // 
            this.tableViewCmboBx.FormattingEnabled = true;
            this.tableViewCmboBx.Items.AddRange(new object[] {
            "Products",
            "Invoices",
            "Customers"});
            this.tableViewCmboBx.Location = new System.Drawing.Point(33, 92);
            this.tableViewCmboBx.Name = "tableViewCmboBx";
            this.tableViewCmboBx.Size = new System.Drawing.Size(151, 28);
            this.tableViewCmboBx.TabIndex = 2;
            this.tableViewCmboBx.SelectedIndexChanged += new System.EventHandler(this.tableViewCmboBx_SelectedIndexChanged);
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
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(246, 92);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1078, 465);
            this.dataGridView.TabIndex = 4;
            // 
            // UserActionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 594);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.viewCmboBxLbl);
            this.Controls.Add(this.tableViewCmboBx);
            this.Controls.Add(this.usernameDisplayLbl);
            this.Name = "UserActionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameDisplayLbl;
        private System.Windows.Forms.ComboBox tableViewCmboBx;
        private System.Windows.Forms.Label viewCmboBxLbl;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}