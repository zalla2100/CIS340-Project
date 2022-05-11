namespace ShopEasy.UI
{
    partial class AddUpdateCustomerForm
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
            this.customerNameLbl = new System.Windows.Forms.Label();
            this.customerFirstnameTxtBx = new System.Windows.Forms.TextBox();
            this.customerLastnameTxtBx = new System.Windows.Forms.TextBox();
            this.customerEmailLbl = new System.Windows.Forms.Label();
            this.customerEmailTxtBx = new System.Windows.Forms.TextBox();
            this.customerPhoneLbl = new System.Windows.Forms.Label();
            this.customerPhoneTxtBx = new System.Windows.Forms.TextBox();
            this.statusLbl = new System.Windows.Forms.Label();
            this.veteranChkBx = new System.Windows.Forms.CheckBox();
            this.seniorChkBx = new System.Windows.Forms.CheckBox();
            this.customerAddUpdateBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customerNameLbl
            // 
            this.customerNameLbl.AutoSize = true;
            this.customerNameLbl.Location = new System.Drawing.Point(38, 38);
            this.customerNameLbl.Name = "customerNameLbl";
            this.customerNameLbl.Size = new System.Drawing.Size(49, 20);
            this.customerNameLbl.TabIndex = 0;
            this.customerNameLbl.Text = "Name";
            // 
            // customerFirstnameTxtBx
            // 
            this.customerFirstnameTxtBx.Location = new System.Drawing.Point(122, 38);
            this.customerFirstnameTxtBx.Name = "customerFirstnameTxtBx";
            this.customerFirstnameTxtBx.PlaceholderText = "First";
            this.customerFirstnameTxtBx.Size = new System.Drawing.Size(279, 27);
            this.customerFirstnameTxtBx.TabIndex = 1;
            // 
            // customerLastnameTxtBx
            // 
            this.customerLastnameTxtBx.Location = new System.Drawing.Point(422, 38);
            this.customerLastnameTxtBx.Name = "customerLastnameTxtBx";
            this.customerLastnameTxtBx.PlaceholderText = "Last";
            this.customerLastnameTxtBx.Size = new System.Drawing.Size(279, 27);
            this.customerLastnameTxtBx.TabIndex = 2;
            // 
            // customerEmailLbl
            // 
            this.customerEmailLbl.AutoSize = true;
            this.customerEmailLbl.Location = new System.Drawing.Point(38, 109);
            this.customerEmailLbl.Name = "customerEmailLbl";
            this.customerEmailLbl.Size = new System.Drawing.Size(46, 20);
            this.customerEmailLbl.TabIndex = 3;
            this.customerEmailLbl.Text = "Email";
            // 
            // customerEmailTxtBx
            // 
            this.customerEmailTxtBx.Location = new System.Drawing.Point(122, 109);
            this.customerEmailTxtBx.Name = "customerEmailTxtBx";
            this.customerEmailTxtBx.PlaceholderText = "user@example.com";
            this.customerEmailTxtBx.Size = new System.Drawing.Size(279, 27);
            this.customerEmailTxtBx.TabIndex = 4;
            // 
            // customerPhoneLbl
            // 
            this.customerPhoneLbl.AutoSize = true;
            this.customerPhoneLbl.Location = new System.Drawing.Point(38, 173);
            this.customerPhoneLbl.Name = "customerPhoneLbl";
            this.customerPhoneLbl.Size = new System.Drawing.Size(50, 20);
            this.customerPhoneLbl.TabIndex = 5;
            this.customerPhoneLbl.Text = "Phone";
            // 
            // customerPhoneTxtBx
            // 
            this.customerPhoneTxtBx.Location = new System.Drawing.Point(122, 173);
            this.customerPhoneTxtBx.Name = "customerPhoneTxtBx";
            this.customerPhoneTxtBx.PlaceholderText = "xxxxxxxxxx";
            this.customerPhoneTxtBx.Size = new System.Drawing.Size(279, 27);
            this.customerPhoneTxtBx.TabIndex = 6;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(39, 244);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(49, 20);
            this.statusLbl.TabIndex = 7;
            this.statusLbl.Text = "Status";
            // 
            // veteranChkBx
            // 
            this.veteranChkBx.AutoSize = true;
            this.veteranChkBx.Location = new System.Drawing.Point(122, 244);
            this.veteranChkBx.Name = "veteranChkBx";
            this.veteranChkBx.Size = new System.Drawing.Size(81, 24);
            this.veteranChkBx.TabIndex = 9;
            this.veteranChkBx.Text = "Veteran";
            this.veteranChkBx.UseVisualStyleBackColor = true;
            // 
            // seniorChkBx
            // 
            this.seniorChkBx.AutoSize = true;
            this.seniorChkBx.Location = new System.Drawing.Point(242, 244);
            this.seniorChkBx.Name = "seniorChkBx";
            this.seniorChkBx.Size = new System.Drawing.Size(73, 24);
            this.seniorChkBx.TabIndex = 10;
            this.seniorChkBx.Text = "Senior";
            this.seniorChkBx.UseVisualStyleBackColor = true;
            // 
            // customerAddUpdateBtn
            // 
            this.customerAddUpdateBtn.Location = new System.Drawing.Point(168, 361);
            this.customerAddUpdateBtn.Name = "customerAddUpdateBtn";
            this.customerAddUpdateBtn.Size = new System.Drawing.Size(94, 29);
            this.customerAddUpdateBtn.TabIndex = 11;
            this.customerAddUpdateBtn.Text = "AddUpdate";
            this.customerAddUpdateBtn.UseVisualStyleBackColor = true;
            this.customerAddUpdateBtn.Click += new System.EventHandler(this.customerAddUpdateBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(449, 361);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 29);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // AddUpdateCustomerForm
            // 
            this.AcceptButton = this.customerAddUpdateBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.customerAddUpdateBtn);
            this.Controls.Add(this.seniorChkBx);
            this.Controls.Add(this.veteranChkBx);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.customerPhoneTxtBx);
            this.Controls.Add(this.customerPhoneLbl);
            this.Controls.Add(this.customerEmailTxtBx);
            this.Controls.Add(this.customerEmailLbl);
            this.Controls.Add(this.customerLastnameTxtBx);
            this.Controls.Add(this.customerFirstnameTxtBx);
            this.Controls.Add(this.customerNameLbl);
            this.Name = "AddUpdateCustomerForm";
            this.Text = "AddUpdateCustomerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label customerNameLbl;
        private System.Windows.Forms.TextBox customerFirstnameTxtBx;
        private System.Windows.Forms.TextBox customerLastnameTxtBx;
        private System.Windows.Forms.Label customerEmailLbl;
        private System.Windows.Forms.TextBox customerEmailTxtBx;
        private System.Windows.Forms.Label customerPhoneLbl;
        private System.Windows.Forms.TextBox customerPhoneTxtBx;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.CheckBox veteranChkBx;
        private System.Windows.Forms.CheckBox seniorChkBx;
        private System.Windows.Forms.Button customerAddUpdateBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}