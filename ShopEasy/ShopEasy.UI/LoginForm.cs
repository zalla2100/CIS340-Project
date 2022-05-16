using ShopEasy.Core;
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
    /// <summary>
    /// Form for logging in to the application.
    /// </summary>
    public partial class LoginForm : Form
    {
        private ShopEasyDBContext context = new ShopEasyDBContext();
        private Users user = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Processes user login attempt and opens main form if sucessful
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            var username = usernameTxtBx.Text;
            var password = passwordTxtBx.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    user = context.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();

                    if (user != null)
                    {
                        usernameTxtBx.Clear();
                        passwordTxtBx.Clear();
                        this.Hide();

                        UserActionsForm userActionsForm = new UserActionsForm(user, ref context);
                        userActionsForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect.");
                        passwordTxtBx.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("An error has occured.");
                }
            }
            else
            {
                MessageBox.Show("Username and password cannot be empty.");
            }
        }

        /// <summary>
        /// Closes the entire application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
