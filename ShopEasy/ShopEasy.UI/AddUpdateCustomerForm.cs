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

            if (customerFirstnameTxtBx.Text.Length > 30)
            {
                MessageBox.Show("First name cannot be greater than 30 characters.");
                return;
            }
            if (customerLastnameTxtBx.Text.Length > 30)
            {
                MessageBox.Show("Last name cannot be greater than 30 characters.");
                return;
            }
            if (customerEmailTxtBx.Text.Length > 50) //change db to be max
            {
                MessageBox.Show("Email cannot be greater than 50 characters.");
                return;
            }

            Regex nameRegex = new Regex("/[a-zA-Z ]{1,30}/g");
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
            if(!Regex.IsMatch(customerEmailTxtBx.Text, @"/^[^@\s]+@[^@\s]+\.[^@\s]+$/g"))
            {
                MessageBox.Show("Invalid email address.");
                return;
            }
            if (customerPhoneTxtBx.Text.Length != 10 || !Regex.IsMatch(customerPhoneTxtBx.Text, "/[0-9]{10}/g"))
            {
                MessageBox.Show("Phone number must be 10 consecutive digits.");
                return;
            }

            Customers existingEmail = context.Customers.Where(c => c.EmailAddress == customer.EmailAddress).FirstOrDefault();
            if(existingEmail != null)
            {
                MessageBox.Show("Email is already in use!");
                return;
            }

            Customers existingPhone = context.Customers.Where(c => c.PhoneNumber == customer.PhoneNumber).FirstOrDefault();
            if (existingPhone != null)
            {
                MessageBox.Show("Phone number is already in use!");
                return;
            }

            customer.FirstName = customerFirstnameTxtBx.Text;
            customer.LastName = customerLastnameTxtBx.Text;
            customer.EmailAddress = customerEmailTxtBx.Text;
            customer.PhoneNumber = customerPhoneTxtBx.Text;
            customer.IsVeteran = veteranChkBx.Checked;
            customer.IsSenior = seniorChkBx.Checked;

            if (isAdd)
            {
                try
                {
                    context.Customers.Add(customer);

                    var newCustomer = context.Customers.Where(c => c.PhoneNumber == customer.PhoneNumber).First();

                    Users user = new Users();
                    user.Id = newCustomer.Id;
                    var username = $"{customer.FirstName[0]}{customer.LastName[..6]}";
                    var counter = 2;
                    Users existingUser = context.Users.Where(u => u.UserName == username).FirstOrDefault();
                    while (existingUser != null)
                    {
                        username = $"{customer.FirstName[0]}{customer.LastName[..6]}{counter}";
                        existingUser = context.Users.Where(u => u.UserName == username).FirstOrDefault();
                        counter++;
                    }
                    user.UserName = username;
                    user.Password = Guid.NewGuid().ToString()[..8];
                    context.Users.Add(user);

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
    }
}
