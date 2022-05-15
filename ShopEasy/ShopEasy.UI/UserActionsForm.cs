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
    //TODO List: 
    //encryption
        //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.randomnumbergenerator.create?view=net-6.0
        //https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-services
    //comments
    //ensure DB has required data & categories (in bin of UI project)
        //Remove all data from local db except admin, admin user, and product categories
    //maunally test all cases

    public partial class UserActionsForm : Form
    {
        private const string PRODUCT_DELETE_BTN_COLUMN = "ProductDeleteBtn";
        private const string CUSTOMER_DELETE_BTN_COLUMN = "CustomerDeleteBtn";
        private const string PRODUCT_UPDATE_BTN_COLUMN = "ProductUpdateBtn";
        private const string CUSTOMER_UPDATE_BTN_COLUMN = "CustomerUpdateBtn";
        private const string USER_UPDATE_BTN_COLUMN = "UserUpdateBtn";
        private const string ORDER_BTN_COLUMN = "OrderBtn";

        private bool isAdmin = false;
        private ShopEasyDBContext context;
        private Users currentUser;
        
        public UserActionsForm(Users user, ref ShopEasyDBContext context)
        {
            InitializeComponent();

            this.context = context;
            usernameDisplayLbl.Text = user.UserName;
            this.currentUser = user;

            loadData();
            
            dataGridView.AutoGenerateColumns = true;
            tableViewCmboBx.Items.AddRange(new object[] { Tables.PRODUCTS, Tables.INVOICES });

            isAdmin = context.Admin.Find(user.Id) != null;
            if (isAdmin) {
                tableViewCmboBx.Items.AddRange(new string[] { Tables.CUSTOMERS, Tables.USERS });
                addBtn.Visible = true;
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

        private void populateDataGridView(string table)
        {
            switch (table)
            {
                case Tables.PRODUCTS:
                    dataGridView.DataSource = context.Products.ToList();
                    break;
                case Tables.CUSTOMERS:
                    dataGridView.DataSource = context.Customers.ToList();
                    break;
                case Tables.USERS:
                    dataGridView.DataSource = context.Users.ToList();
                    break;
                case Tables.INVOICES:
                    dataGridView.DataSource = isAdmin ? 
                        context.Invoices.ToList() : 
                        context.Invoices.Where(i => i.CustomerId == currentUser.Id).ToList();
                    break;
            }

            removeExtraColumns();
        }

        private void loadData()
        {
            context.Products.Load();
            context.Customers.Load();
            context.Users.Load();
            context.Invoices.Load();
        }

        private void removeButtons()
        {
            var deleteColumnProduct = dataGridView.Columns[PRODUCT_DELETE_BTN_COLUMN];
            var deleteColumnCustomer = dataGridView.Columns[CUSTOMER_DELETE_BTN_COLUMN];
            var updateColumnProduct = dataGridView.Columns[PRODUCT_UPDATE_BTN_COLUMN];
            var updateColumnCustomer = dataGridView.Columns[CUSTOMER_UPDATE_BTN_COLUMN];
            var updateColumnUser = dataGridView.Columns[USER_UPDATE_BTN_COLUMN];
            var orderColumn = dataGridView.Columns[ORDER_BTN_COLUMN];

            if (deleteColumnProduct != null)
            {
                dataGridView.Columns.Remove(deleteColumnProduct);
            }
            if (deleteColumnCustomer != null)
            {
                dataGridView.Columns.Remove(deleteColumnCustomer);
            }
            if (updateColumnProduct != null)
            {
                dataGridView.Columns.Remove(updateColumnProduct);
            }
            if (updateColumnCustomer != null)
            {
                dataGridView.Columns.Remove(updateColumnCustomer);
            }
            if (updateColumnUser != null)
            {
                dataGridView.Columns.Remove(updateColumnUser);
            }
            if (orderColumn != null)
            {
                dataGridView.Columns.Remove(orderColumn);
            }
        }

        private void addButtons(string table)
        {
            if (isAdmin && (table == Tables.PRODUCTS || table == Tables.CUSTOMERS))
            {
                var updateButton = new DataGridViewButtonColumn();
                updateButton.Name = table == Tables.PRODUCTS ? PRODUCT_UPDATE_BTN_COLUMN : CUSTOMER_UPDATE_BTN_COLUMN;
                updateButton.HeaderText = "";
                updateButton.Text = "Update";
                updateButton.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(updateButton);

                var deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = table == Tables.PRODUCTS ? PRODUCT_DELETE_BTN_COLUMN : CUSTOMER_DELETE_BTN_COLUMN;
                deleteButton.HeaderText = "";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(deleteButton);

            }
            else if (isAdmin && table == Tables.USERS)
            {
                var updateButton = new DataGridViewButtonColumn();
                updateButton.Name = USER_UPDATE_BTN_COLUMN;
                updateButton.HeaderText = "";
                updateButton.Text = "Update";
                updateButton.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(updateButton);
            }
            else if (!isAdmin && table == Tables.PRODUCTS)
            {
                var orderButton = new DataGridViewButtonColumn();
                orderButton.Name = ORDER_BTN_COLUMN;
                orderButton.HeaderText = "";
                orderButton.Text = "Order";
                orderButton.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(orderButton);
            }
        }

        private void tableViewCmboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeButtons();

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

            if(table == Tables.PRODUCTS || table == Tables.CUSTOMERS)
            {
                addBtn.Enabled = true;
            }
            else
            {
                addBtn.Enabled = false;
            }

            try
            {
                populateDataGridView(table);
                addButtons(table);
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
                populateDataGridView(table);
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
                removeButtons();
                dataGridView.DataSource = query.ToList();
                removeExtraColumns();
                addButtons(table);
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
            var deleteColumnCustomer = dataGridView.Columns[CUSTOMER_DELETE_BTN_COLUMN];
            var updateColumnProduct = dataGridView.Columns[PRODUCT_UPDATE_BTN_COLUMN];
            var updateColumnCustomer = dataGridView.Columns[CUSTOMER_UPDATE_BTN_COLUMN];
            var updateColumnUser = dataGridView.Columns[USER_UPDATE_BTN_COLUMN];
            var orderColumn = dataGridView.Columns[ORDER_BTN_COLUMN];
            var index = dataGridView.Columns["Id"].Index;
            var id = (int)dataGridView.Rows[e.RowIndex].Cells[index].Value;
            
            if (deleteColumnProduct != null && e.ColumnIndex == deleteColumnProduct.Index)
            {
                deleteProduct(id);
                populateDataGridView(Tables.PRODUCTS);
            }
            else if (deleteColumnCustomer != null && e.ColumnIndex == deleteColumnCustomer.Index)
            {
                deleteCustomer(id);
                populateDataGridView(Tables.CUSTOMERS);
            }
            else if (updateColumnProduct != null && e.ColumnIndex == updateColumnProduct.Index)
            {
                var product = context.Products.Find(id);
                Form addUpdateProductForm = new AddUpdateProductForm(product, ref context);
                this.ShowForm(ref addUpdateProductForm);
            }
            else if (updateColumnCustomer != null && e.ColumnIndex == updateColumnCustomer.Index)
            {
                var customer = context.Customers.Find(id);
                Form addUpdateCustomerForm = new AddUpdateCustomerForm(customer, ref context);
                this.ShowForm(ref addUpdateCustomerForm);
            }
            else if (updateColumnUser != null && e.ColumnIndex == updateColumnUser.Index)
            {
                var user = context.Users.Find(id);
                Form updateUserForm = new UpdateUserForm(user, ref context);
                this.ShowForm(ref updateUserForm);
            }
            else if (orderColumn != null && e.ColumnIndex == orderColumn.Index)
            {
                Form orderForm = new ProductOrderForm(context.Customers.Find(currentUser.Id), id, ref context);
                this.ShowForm(ref orderForm);
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            int index = tableViewCmboBx.SelectedIndex;
            string table = (string)tableViewCmboBx.Items[index];

            if (table == Tables.PRODUCTS)
            {
                AddUpdateProductForm addUpdateProductForm = new AddUpdateProductForm(null, ref context);
                addUpdateProductForm.FormClosed += new FormClosedEventHandler(Form_Closed);
                addUpdateProductForm.Show();
                this.Enabled = false;
            }
            else if (table == Tables.CUSTOMERS)
            {
                AddUpdateCustomerForm addUpdateCustomerForm = new AddUpdateCustomerForm(null, ref context);
                addUpdateCustomerForm.FormClosed += new FormClosedEventHandler(Form_Closed);
                addUpdateCustomerForm.Show();
                this.Enabled = false;
            }
        }

        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            int index = tableViewCmboBx.SelectedIndex;
            string table = (string)tableViewCmboBx.Items[index];
            populateDataGridView(table);
            this.Enabled = true;
        }

        private void signOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void UserActionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ShowForm(ref Form form)
        {
            form.FormClosed += new FormClosedEventHandler(Form_Closed);
            form.Show();
            this.Enabled = false;
        }
    }
}
