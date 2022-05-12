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
            this.searchTxtBx = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.signOutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameDisplayLbl
            // 
            this.usernameDisplayLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameDisplayLbl.AutoSize = true;
            this.usernameDisplayLbl.Location = new System.Drawing.Point(1213, 23);
            this.usernameDisplayLbl.Name = "usernameDisplayLbl";
            this.usernameDisplayLbl.Size = new System.Drawing.Size(73, 20);
            this.usernameDisplayLbl.TabIndex = 0;
            this.usernameDisplayLbl.Text = "username";
            // 
            // tableViewCmboBx
            // 
            this.tableViewCmboBx.FormattingEnabled = true;
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
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // searchTxtBx
            // 
            this.searchTxtBx.Enabled = false;
            this.searchTxtBx.Location = new System.Drawing.Point(246, 37);
            this.searchTxtBx.Name = "searchTxtBx";
            this.searchTxtBx.Size = new System.Drawing.Size(311, 27);
            this.searchTxtBx.TabIndex = 6;
            this.searchTxtBx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyUp);
            // 
            // searchBtn
            // 
            this.searchBtn.Enabled = false;
            this.searchBtn.Location = new System.Drawing.Point(602, 37);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(94, 29);
            this.searchBtn.TabIndex = 7;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Enabled = false;
            this.addBtn.Location = new System.Drawing.Point(33, 200);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(94, 29);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Add Item";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // signOutBtn
            // 
            this.signOutBtn.Location = new System.Drawing.Point(1213, 57);
            this.signOutBtn.Name = "signOutBtn";
            this.signOutBtn.Size = new System.Drawing.Size(95, 29);
            this.signOutBtn.TabIndex = 9;
            this.signOutBtn.Text = "Sign Out";
            this.signOutBtn.UseVisualStyleBackColor = true;
            this.signOutBtn.Click += new System.EventHandler(this.signOutBtn_Click);
            // 
            // UserActionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 594);
            this.Controls.Add(this.signOutBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchTxtBx);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.viewCmboBxLbl);
            this.Controls.Add(this.tableViewCmboBx);
            this.Controls.Add(this.usernameDisplayLbl);
            this.Name = "UserActionsForm";
            this.Text = "ShopEasy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserActionsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameDisplayLbl;
        private System.Windows.Forms.ComboBox tableViewCmboBx;
        private System.Windows.Forms.Label viewCmboBxLbl;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox searchTxtBx;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button signOutBtn;
    }
}