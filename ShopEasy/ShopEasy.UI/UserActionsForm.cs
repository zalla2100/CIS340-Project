using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopEasy.Core;
using ShopEasy.Infrastructure;

namespace ShopEasy.UI
{
    public partial class UserActionsForm : Form
    {
        private const string PRODUCT_DELETE_BTN_COLUMN = "ProductDeleteBtn";
        private const string CONSUMER_DELETE_BTN_COLUMN = "ConsumerDeleteBtn";

        private bool isAdmin = false;
        private ShopEasyDBContext context;
        
        public UserActionsForm(Users user, ShopEasyDBContext context)
        {
            this.context = context;

            InitializeComponent();

            context.Products.Load();
            context.Customers.Load();
            context.Users.Load();
            context.Invoices.Load();
            
            dataGridView.AutoGenerateColumns = true;
            tableViewCmboBx.Items.AddRange(new object[] { Tables.PRODUCTS, Tables.INVOICES });

            isAdmin = context.Admin.Find(user.Id) != null;
            if (isAdmin) {
                tableViewCmboBx.Items.AddRange(new string[] { Tables.CUSTOMERS, Tables.USERS });
            }
        }

        private void removeExtraColumns()
        {
            var admin = dataGridView.Columns["Admin"];
            if (admin != null)
            {
                dataGridView.Columns.Remove(admin);
            }

            var customers = dataGridView.Columns["Customers"];
            if (customers != null)
            {
                dataGridView.Columns.Remove(customers);
            }

            var invoices = dataGridView.Columns["Invoices"];
            if (invoices != null)
            {
                dataGridView.Columns.Remove(invoices);
            }

            var customer = dataGridView.Columns["Customer"];
            if (customer != null)
            {
                dataGridView.Columns.Remove(customer);
            }

            var product = dataGridView.Columns["Product"];
            if (product != null)
            {
                dataGridView.Columns.Remove(product);
            }

            var user = dataGridView.Columns["User"];
            if (user != null)
            {
                dataGridView.Columns.Remove(user);
            }

            var idNavigation = dataGridView.Columns["IdNavigation"];
            if (idNavigation != null)
            {
                dataGridView.Columns.Remove(idNavigation);
            }
        }

        private void loadData(string table)
        {
            switch (table)
            {
                case Tables.PRODUCTS:
                    context.Products.Load();
                    dataGridView.DataSource = context.Products.Local.ToBindingList();
                    break;
                case Tables.CUSTOMERS:
                    context.Customers.Load();
                    dataGridView.DataSource = context.Customers.Local.ToBindingList();
                    break;
                case Tables.USERS:
                    context.Users.Load();
                    dataGridView.DataSource = context.Users.Local.ToBindingList();
                    break;
                case Tables.INVOICES:
                    context.Invoices.Load();
                    dataGridView.DataSource = context.Invoices.Local.ToBindingList();
                    break;
            }

            removeExtraColumns();
        }

        private void removeDeleteButtons()
        {
            var deleteColumnProduct = dataGridView.Columns[PRODUCT_DELETE_BTN_COLUMN];
            var deleteColumnCustomer = dataGridView.Columns[CONSUMER_DELETE_BTN_COLUMN];

            if (deleteColumnProduct != null)
            {
                dataGridView.Columns.Remove(deleteColumnProduct);
            }
            if (deleteColumnCustomer != null)
            {
                dataGridView.Columns.Remove(deleteColumnCustomer);
            }
        }

        private void addDeleteButtons(string table)
        {
            if (isAdmin && (table == Tables.PRODUCTS || table == Tables.CUSTOMERS))
            {
                var deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = table == Tables.PRODUCTS ? PRODUCT_DELETE_BTN_COLUMN : CONSUMER_DELETE_BTN_COLUMN;
                deleteButton.HeaderText = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(deleteButton);
            }
        }

        private void tableViewCmboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeDeleteButtons();

            searchTxtBx.Text = "";
            int index = tableViewCmboBx.SelectedIndex;
            string table = (string) tableViewCmboBx.Items[index];

            if(table == Tables.INVOICES)
            {
                searchTxtBx.Enabled = false;
                searchBtn.Enabled = false;
            }
            else
            {
                searchTxtBx.Enabled = true;
                searchBtn.Enabled = true;
            }

            try
            {
                loadData(table);
                addDeleteButtons(table);
            }
            catch
            {
                MessageBox.Show($"Failed to load data from table {table}");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string term = searchTxtBx.Text.Trim().ToLower();
            int index = tableViewCmboBx.SelectedIndex;
            string table = (string)tableViewCmboBx.Items[index];
            IQueryable<object> query = new List<object>().AsQueryable();

            if (string.IsNullOrWhiteSpace(term))
            {
                //do no filtering, retrieve all rows
                loadData(table);
                return;
            }
            else if (table == Tables.PRODUCTS)
            {
                query = context.Products.Where(p => p.Name.ToLower().Contains(term) ||
                    p.Category.ToLower().Contains(term) ||
                    p.SubCategory.ToLower().Contains(term) ||
                    p.Price.ToString().StartsWith(term));
            }
            else if (table == Tables.CUSTOMERS)
            {
                query = context.Customers.Where(c => c.FirstName.ToLower().Contains(term) ||
                    c.LastName.ToLower().Contains(term) ||
                    c.EmailAddress.ToLower().Contains(term) ||
                    c.PhoneNumber.ToLower().Contains(term));
            }
            else if (table == Tables.USERS)
            {
                query = context.Users.Where(u => u.UserName.ToLower().Contains(term));
            }

            try
            {
                removeDeleteButtons();
                dataGridView.DataSource = new BindingList<object>(query.ToList());
                removeExtraColumns();
                addDeleteButtons(table);
            }
            catch
            {
                MessageBox.Show($"Failed to search data from table {table}");
            }
        }

        private void searchTxtBx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchBtn.Focus();
                searchBtn.PerformClick();
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dataGridView.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }

            //Check if click is on specific column 
            var deleteColumnProduct = dataGridView.Columns[PRODUCT_DELETE_BTN_COLUMN];
            var deleteColumnCustomer = dataGridView.Columns[CONSUMER_DELETE_BTN_COLUMN];
            var index = dataGridView.Columns["Id"].Index;
            var id = (int)dataGridView.Rows[e.RowIndex].Cells[index].Value;
            
            if (deleteColumnProduct != null && e.ColumnIndex == deleteColumnProduct.Index)
            {
                deleteProduct(id);
            }
            else if (deleteColumnCustomer != null && e.ColumnIndex == deleteColumnCustomer.Index)
            {
                deleteCustomer(id);
            }
        }

        private void deleteProduct(int id)
        {
            var product = context.Products.Find(id);
            if (product != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete product \"{product.Name}\"?\nThis will delete associated invoices as well.",
                                    "Confirm Product Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        context.Invoices.RemoveRange(context.Invoices.Where(i => i.ProductId == id));
                        context.Products.Remove(product);
                        context.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Failed to delete product.");
                    }
                }
            }
        }

        private void deleteCustomer(int id)
        {
            var customer = context.Customers.Find(id);
            if (customer != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete customer \"{customer.FirstName} {customer.LastName}\"?\nThis will delete associated invoices and user as well.",
                "Confirm Customer Deletion", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        context.Invoices.RemoveRange(context.Invoices.Where(i => i.CustomerId == id));
                        context.Customers.Remove(customer);
                        context.Users.RemoveRange(context.Users.Where(u => u.Id == id));
                        context.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Failed to delete customer.");
                    }
                }
            }
        }
    }
}
