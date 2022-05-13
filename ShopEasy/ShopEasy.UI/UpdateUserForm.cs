using ShopEasy.Core;
using ShopEasy.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopEasy.UI
{
    public partial class UpdateUserForm : Form
    {
        private ShopEasyDBContext context;
        private Users user;

        public UpdateUserForm(Users user, ref ShopEasyDBContext context)
        {
            InitializeComponent();

            this.context = context;
            this.user = user;
            userUsernameTxtBx.Text = user.UserName;
            userPasswordTxtBx.Text = user.Password;
            userConfirmPasswordTxtBx.Text = user.Password;
        }

        private void userUpdateBtn_Click(object sender, EventArgs e)
        {
            Users existingUser = context.Users.FirstOrDefault(u => u.UserName == userUsernameTxtBx.Text.Trim());
            if (existingUser != null)
            {
                MessageBox.Show("Username has been taken.");
                return;
            }

            if(userPasswordTxtBx.Text != userConfirmPasswordTxtBx.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string errors = $"{Validator.ValidUsername(userUsernameTxtBx.Text)}{Validator.ValidPassword(userPasswordTxtBx.Text)}";
            if(errors != string.Empty)
            {
                MessageBox.Show(errors);
                return;
            }

            this.user.UserName = userUsernameTxtBx.Text.Trim();
            this.user.Password = userPasswordTxtBx.Text;

            try
            {
                context.Users.Update(user);
                context.SaveChanges();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Failed to update user.");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to cancel?\nYou have unsaved changes.",
                                    "Confirm Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
