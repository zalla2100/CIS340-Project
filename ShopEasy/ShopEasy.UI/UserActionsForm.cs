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
        //private BindingSource productsSource = new BindingSource();
        //private BindingSource customersSource = new BindingSource();
        //private BindingSource usersSource = new BindingSource();
        //private BindingSource invoicesSource = new BindingSource();
        
        public UserActionsForm(Users user, ShopEasyDBContext context)
        {
            this.context = context;

            InitializeComponent();

            context.Products.Load();
            //productsSource.DataSource = context.Products.Local.ToBindingList();
            context.Customers.Load();
            //customersSource.DataSource = context.Customers.Local.ToBindingList();
            context.Users.Load();
            //usersSource.DataSource = context.Users.Local.ToBindingList();
            context.Invoices.Load();
            //invoicesSource.DataSource = context.Invoices.Local.ToBindingList();
            
            dataGridView.AutoGenerateColumns = true;
            tableViewCmboBx.Items.AddRange(new object[] { Tables.PRODUCTS, Tables.INVOICES });

            isAdmin = context.Admin.Find(user.Id) != null;
            if (isAdmin) {
                tableViewCmboBx.Items.AddRange(new string[] { Tables.CUSTOMERS, Tables.USERS });
            }
        }

        private void loadData(string table)
        {
            switch (table)
            {
                case Tables.PRODUCTS:
                    dataGridView.DataSource = context.Products.Local.ToBindingList();
                    dataGridView.Columns.RemoveAt(5); //don't show extra column
                    break;
                case Tables.CUSTOMERS:
                    dataGridView.DataSource = context.Customers.Local.ToBindingList();
                    dataGridView.Columns.RemoveAt(7);
                    dataGridView.Columns.RemoveAt(7);
                    break;
                case Tables.USERS:
                    dataGridView.DataSource = context.Users.Local.ToBindingList();
                    dataGridView.Columns.RemoveAt(3);
                    dataGridView.Columns.RemoveAt(3);
                    break;
                case Tables.INVOICES:
                    dataGridView.DataSource = context.Invoices.Local.ToBindingList();
                    dataGridView.Columns.RemoveAt(10);
                    dataGridView.Columns.RemoveAt(10);
                    break;
            }
        }

        private void tableViewCmboBx_SelectedIndexChanged(object sender, EventArgs e)
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
                dataGridView.DataSource = new BindingList<object>(query.ToList());
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
                        //MessageBox.Show("Successsfully deleted product.");
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
                        //MessageBox.Show("Successsfully deleted customer.");
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
