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
    public partial class AddUpdateCustomerForm : Form
    {
        private ShopEasyDBContext context;
        private Customers customer;
        private bool isAdd;

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

        private void customerAddUpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customerFirstnameTxtBx.Text))
            {
                MessageBox.Show("First name cannot be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(customerLastnameTxtBx.Text))
            {
                MessageBox.Show("Last name cannot be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(customerEmailTxtBx.Text))
            {
                MessageBox.Show("Email cannot be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(customerPhoneTxtBx.Text))
            {
                MessageBox.Show("Phone number cannot be empty.");
                return;
            }

            if (customerFirstnameTxtBx.Text.Trim().Length > 30) //change field in db to be nvarchar(max)
            {
                MessageBox.Show("First name cannot be greater than 30 characters.");
                return;
            }
            if (customerLastnameTxtBx.Text.Trim().Length > 30) //change field in db to be nvarchar(max)
            {
                MessageBox.Show("Last name cannot be greater than 30 characters.");
                return;
            }
            if (customerEmailTxtBx.Text.Trim().Length > 50) //change field in db to be nvarchar(max)
            {
                MessageBox.Show("Email cannot be greater than 50 characters.");
                return;
            }

            Regex nameRegex = new Regex("^[a-zA-Z ]{1,30}$"); //change to be one or more after remove limit in db
            if (!nameRegex.IsMatch(customerFirstnameTxtBx.Text))
            {
                MessageBox.Show("First name can only contain letters and spaces.");
                return;
            }
            if (!nameRegex.IsMatch(customerLastnameTxtBx.Text))
            {
                MessageBox.Show("Last name can only contain letters and spaces.");
                return;
            }
            if(!Regex.IsMatch(customerEmailTxtBx.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email address.");
                return;
            }
            if (!Regex.IsMatch(customerPhoneTxtBx.Text, "^[0-9]{10}$"))
            {
                MessageBox.Show("Phone number must be 10 consecutive digits.");
                return;
            }

            if (isAdd)
            {
                Customers existingEmail = context.Customers.Where(c => c.EmailAddress.ToLower() == customerEmailTxtBx.Text.Trim().ToLower()).FirstOrDefault();
                if (existingEmail != null)
                {
                    MessageBox.Show("Email is already in use!");
                    return;
                }

                Customers existingPhone = context.Customers.Where(c => c.PhoneNumber == customerPhoneTxtBx.Text).FirstOrDefault();
                if (existingPhone != null)
                {
                    MessageBox.Show("Phone number is already in use!");
                    return;
                }
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
                    var username = usernameBase;
                    var counter = 2;
                    Users existingUser = context.Users.Where(u => u.UserName == username).FirstOrDefault();
                    while (existingUser != null)
                    {
                        username = $"{usernameBase}{counter}";
                        existingUser = context.Users.Where(u => u.UserName == username).FirstOrDefault();
                        counter++;
                    }
                    user.UserName = username;
                    user.Password = Guid.NewGuid().ToString()[..8];
                    context.Users.Add(user);
                    context.SaveChanges();

                    customer.Id = user.Id;
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

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to cancel?\nYou have unsaved changes.",
                                    "Confirm Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

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
