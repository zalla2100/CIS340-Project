namespace ShopEasy.UI
{
    partial class UpdateUserForm
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
            this.userUsernameLbl = new System.Windows.Forms.Label();
            this.userUsernameTxtBx = new System.Windows.Forms.TextBox();
            this.userPasswordLbl = new System.Windows.Forms.Label();
            this.userPasswordTxtBx = new System.Windows.Forms.TextBox();
            this.userUpdateBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.userConfirmPasswordLbl = new System.Windows.Forms.Label();
            this.userConfirmPasswordTxtBx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userUsernameLbl
            // 
            this.userUsernameLbl.AutoSize = true;
            this.userUsernameLbl.Location = new System.Drawing.Point(89, 52);
            this.userUsernameLbl.Name = "userUsernameLbl";
            this.userUsernameLbl.Size = new System.Drawing.Size(75, 20);
            this.userUsernameLbl.TabIndex = 0;
            this.userUsernameLbl.Text = "Username";
            // 
            // userUsernameTxtBx
            // 
            this.userUsernameTxtBx.Location = new System.Drawing.Point(241, 52);
            this.userUsernameTxtBx.Name = "userUsernameTxtBx";
            this.userUsernameTxtBx.Size = new System.Drawing.Size(258, 27);
            this.userUsernameTxtBx.TabIndex = 1;
            // 
            // userPasswordLbl
            // 
            this.userPasswordLbl.AutoSize = true;
            this.userPasswordLbl.Location = new System.Drawing.Point(89, 133);
            this.userPasswordLbl.Name = "userPasswordLbl";
            this.userPasswordLbl.Size = new System.Drawing.Size(70, 20);
            this.userPasswordLbl.TabIndex = 2;
            this.userPasswordLbl.Text = "Password";
            // 
            // userPasswordTxtBx
            // 
            this.userPasswordTxtBx.Location = new System.Drawing.Point(241, 133);
            this.userPasswordTxtBx.Name = "userPasswordTxtBx";
            this.userPasswordTxtBx.PasswordChar = '*';
            this.userPasswordTxtBx.Size = new System.Drawing.Size(258, 27);
            this.userPasswordTxtBx.TabIndex = 3;
            // 
            // userUpdateBtn
            // 
            this.userUpdateBtn.Location = new System.Drawing.Point(162, 304);
            this.userUpdateBtn.Name = "userUpdateBtn";
            this.userUpdateBtn.Size = new System.Drawing.Size(94, 29);
            this.userUpdateBtn.TabIndex = 4;
            this.userUpdateBtn.Text = "Update";
            this.userUpdateBtn.UseVisualStyleBackColor = true;
            this.userUpdateBtn.Click += new System.EventHandler(this.userUpdateBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(393, 304);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 29);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // userConfirmPasswordLbl
            // 
            this.userConfirmPasswordLbl.AutoSize = true;
            this.userConfirmPasswordLbl.Location = new System.Drawing.Point(89, 212);
            this.userConfirmPasswordLbl.Name = "userConfirmPasswordLbl";
            this.userConfirmPasswordLbl.Size = new System.Drawing.Size(127, 20);
            this.userConfirmPasswordLbl.TabIndex = 6;
            this.userConfirmPasswordLbl.Text = "Confirm Password";
            // 
            // userConfirmPasswordTxtBx
            // 
            this.userConfirmPasswordTxtBx.Location = new System.Drawing.Point(241, 212);
            this.userConfirmPasswordTxtBx.Name = "userConfirmPasswordTxtBx";
            this.userConfirmPasswordTxtBx.PasswordChar = '*';
            this.userConfirmPasswordTxtBx.Size = new System.Drawing.Size(258, 27);
            this.userConfirmPasswordTxtBx.TabIndex = 7;
            // 
            // UpdateUserForm
            // 
            this.AcceptButton = this.userUpdateBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(694, 402);
            this.ControlBox = false;
            this.Controls.Add(this.userConfirmPasswordTxtBx);
            this.Controls.Add(this.userConfirmPasswordLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.userUpdateBtn);
            this.Controls.Add(this.userPasswordTxtBx);
            this.Controls.Add(this.userPasswordLbl);
            this.Controls.Add(this.userUsernameTxtBx);
            this.Controls.Add(this.userUsernameLbl);
            this.Name = "UpdateUserForm";
            this.Text = "Update User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userUsernameLbl;
        private System.Windows.Forms.TextBox userUsernameTxtBx;
        private System.Windows.Forms.Label userPasswordLbl;
        private System.Windows.Forms.TextBox userPasswordTxtBx;
        private System.Windows.Forms.Button userUpdateBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label userConfirmPasswordLbl;
        private System.Windows.Forms.TextBox userConfirmPasswordTxtBx;
    }
}