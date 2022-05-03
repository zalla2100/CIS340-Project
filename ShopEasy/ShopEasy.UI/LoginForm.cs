﻿using ShopEasy.Core;
using ShopEasy.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopEasy.UI
{
    public partial class LoginForm : Form
    {
        User user = null;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var username = usernameTxtBx.Text;
            var password = passwordTxtBx.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                user = UserService.GetUser(username, password);
                if (user != null)
                {
                    UserActionsForm userActionsForm = new UserActionsForm();
                    userActionsForm.Closed += (s, args) => this.Close();
                    var usernameLabel = userActionsForm.Controls.Find("usernameDisplayLbl", true)[0];
                    usernameLabel.Text = user.UserName;
                    userActionsForm.Show();

                    usernameTxtBx.Clear();
                    passwordTxtBx.Clear();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                    passwordTxtBx.Clear();
                }
            }
            else
            {
                MessageBox.Show("Username and password cannot be empty.");
            }
        }

        private void usernameTxtBx_KeyUp(object sender, KeyEventArgs e)
        {
            userActionsForm_KeyUp(e);
        }

        private void passwordTxtBx_KeyUp(object sender, KeyEventArgs e)
        {
            userActionsForm_KeyUp(e);
        }

        private void userActionsForm_KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn.Focus();
                loginBtn.PerformClick();
            }
        } 
    }
}
