using ShopEasy.Core;
using ShopEasy.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ShopEasy.UI
{
    /// <summary>
    /// Form for adding and updating customers
    /// </summary>
    public partial class AddUpdateCustomerForm : Form
    {
        //Fields
        private ShopEasyDBContext context;
        private Customers customer;
        private bool isAdd;

        /// <summary>
        /// Constructor. Initializes form based on desired action and if applicable, prepopulates controls using the selected customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="context"></param>
        public AddUpdateCustomerForm(Customers customer, ref ShopEasyDBContext context)
        {
            InitializeComponent();

            this.context = context;
            this.isAdd = customer == null;
            this.customer = customer == null ? new Customers() : customer;

            if (!isAdd)
            {
                this.Text = "Update Customer";
                customerAddUpdateBtn.Text = "Update";
                customerFirstnameTxtBx.Text = customer.FirstName;
                customerLastnameTxtBx.Text = customer.LastName;
                customerEmailTxtBx.Text = customer.EmailAddress;
                customerPhoneTxtBx.Text = customer.PhoneNumber;
                veteranChkBx.Checked = customer.IsVeteran;
                seniorChkBx.Checked = customer.IsSenior;
            }
            else
            {
                this.Text = "Add Customer";
                customerAddUpdateBtn.Text = "Add";
            }
        }

        /// <summary>
        /// Validates customer, displaying any errors. If valid, generates a new user and associates new customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customerAddUpdateBtn_Click(object sender, EventArgs e)
        {
            string errors = Validator.ValidCustomer(customerFirstnameTxtBx.Text.Trim(), customerLastnameTxtBx.Text.Trim(),
                customerEmailTxtBx.Text.Trim(), customerPhoneTxtBx.Text.Trim());

            if (errors != string.Empty)
            {
                MessageBox.Show(errors);
                return;
            }

            Customers existingEmail = isAdd ?
                context.Customers.FirstOrDefault(c => c.EmailAddress.ToLower() == customerEmailTxtBx.Text.Trim().ToLower()) :
                context.Customers.FirstOrDefault(c => c.EmailAddress.ToLower() == customerEmailTxtBx.Text.Trim().ToLower()
                    && c.Id != customer.Id);

            if (existingEmail != null)
            {
                MessageBox.Show("Email is already in use!");
                return;
            }

            Customers existingPhone = isAdd ?
                context.Customers.FirstOrDefault(c => c.PhoneNumber == customerPhoneTxtBx.Text) :
                context.Customers.FirstOrDefault(c => c.PhoneNumber == customerPhoneTxtBx.Text
                    && c.Id != customer.Id);

            if (existingPhone != null)
            {
                MessageBox.Show("Phone number is already in use!");
                return;
            }

            customer.FirstName = capitalizeName(customerFirstnameTxtBx.Text.Trim());
            customer.LastName = capitalizeName(customerLastnameTxtBx.Text.Trim());
            customer.EmailAddress = customerEmailTxtBx.Text.Trim().ToLower();
            customer.PhoneNumber = customerPhoneTxtBx.Text.Trim();
            customer.IsVeteran = veteranChkBx.Checked;
            customer.IsSenior = seniorChkBx.Checked;

            if (isAdd)
            {
                try
                {
                    Users user = new Users();
                    var usernameBase = $"{customer.FirstName.Replace(" ", "")}{customer.LastName[0]}";
                    if (usernameBase.Length < 6)
                    {
                        //ensure username is at least 6 characters
                        string ticks = DateTime.Now.Ticks.ToString();
                        //substring starting at the end with however many additional characters is neccesary
                        usernameBase += ticks[^(6-usernameBase.Length)..^0];
                    }
                    var username = usernameBase;
                    var counter = 2;
                    Users existingUser = context.Users.Where(u => u.UserName == username).FirstOrDefault();
                    while (existingUser != null) //loop until find an unused username
                    {
                        username = $"{usernameBase}{counter}";
                        existingUser = context.Users.Where(u => u.UserName == username).FirstOrDefault();
                        counter++;
                    }
                    user.UserName = username;
                    user.Password = Guid.NewGuid().ToString()[..8]; //substring of 8 chars
                    context.Users.Add(user);
                    context.SaveChanges();

                    customer.Id = user.Id; //use new user id to associate new customer object
                    context.Customers.Add(customer);

                    context.SaveChanges();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Failed to add customer.");
                }
            }
            else
            {
                try
                {
                    context.Customers.Update(customer);
                    context.SaveChanges();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Failed to update customer.");
                }
            }
        }

        /// <summary>
        /// Displays confirmation. If confirmed, closes the form and all modifications are lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to cancel?\nYou have unsaved changes.",
                                    "Confirm Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Capitalizes all words in space delimited string
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A string</returns>
        private string capitalizeName(string name)
        {
            name = name.ToLower();
            var parts = name.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                var chars = parts[i].ToCharArray();
                chars[0] = chars[0].ToString().ToUpper()[0];
                parts[i] = string.Join("", chars);
            }
            return string.Join(" ", parts);
        }
    }
}
