using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            //validate fields

            //if (string.IsNullOrWhiteSpace(productNameTxtBx.Text))
            //{
            //    MessageBox.Show("Product name cannot be empty.");
            //    return;
            //}
            //if (productNameTxtBx.Text.Length > 40)
            //{
            //    MessageBox.Show("Product name cannot be greater than 40 characters.");
            //    return;
            //}
            //if (productCategoryList.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Category is required.");
            //    return;
            //}
            //if (productSubcategoryList.Enabled && productSubcategoryList.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Subcategory is required.");
            //    return;
            //}

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
