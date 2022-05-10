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
        private bool isAdmin = false;
        private ShopEasyDBContext context = new ShopEasyDBContext();
        private BindingSource productsSource = new BindingSource();
        private BindingSource customersSource = new BindingSource();
        private BindingSource usersSource = new BindingSource();
        private BindingSource invoicesSource = new BindingSource();

        public UserActionsForm(User user)
        {
            InitializeComponent();

            context.Products.Load();
            productsSource.DataSource = context.Products.Local.ToBindingList();
            context.Customers.Load();
            customersSource.DataSource = context.Customers.Local.ToBindingList();
            context.Users.Load();
            usersSource.DataSource = context.Users.Local.ToBindingList();
            context.Invoices.Load();
            invoicesSource.DataSource = context.Invoices.Local.ToBindingList();
            
            dataGridView.AutoGenerateColumns = true;
            tableViewCmboBx.Items.AddRange(new object[] {"Products","Invoices"});

            this.isAdmin = AdminService.IsAdmin(user.Id);
            if (isAdmin) {
                tableViewCmboBx.Items.AddRange(new string[] { "Customers", "Users" });
            }
        }

        private void tableViewCmboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deleteColumnProduct = dataGridView.Columns["dataGridViewProductDeleteBtn"];
            var deleteColumnCustomer = dataGridView.Columns["dataGridViewCustomerDeleteBtn"];
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
            //string selectStatement = $"SELECT * FROM {table} ";
            //List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            switch (table)
            {
                case "Products":
                case "Customers":
                case "Users":
                {
                    searchTxtBx.Enabled = true;
                    searchBtn.Enabled = true;
                    break;
                }
                default:
                {
                    searchTxtBx.Enabled = false;
                    searchBtn.Enabled = false;
                    break;
                }
            }

            //if(table == "Invoices" && !isAdmin)
            //{
            //    selectStatement += "WHERE CustomerId = @customerId ";
            //    parameters.Add(new KeyValuePair<string, string>("@customerId", user.Id.ToString()));
            //}

            try
            {
                switch (table)
                {
                    case "Products":
                        dataGridView.DataSource = productsSource;
                        dataGridView.Columns.RemoveAt(5); //don't show extra column
                        break;
                    case "Customers":
                        dataGridView.DataSource = customersSource;
                        dataGridView.Columns.RemoveAt(7);
                        dataGridView.Columns.RemoveAt(7);
                        break;
                    case "Users":
                        dataGridView.DataSource = usersSource;
                        dataGridView.Columns.RemoveAt(3);
                        dataGridView.Columns.RemoveAt(3);
                        break;
                    case "Invoices":
                        dataGridView.DataSource = invoicesSource;
                        dataGridView.Columns.RemoveAt(10);
                        dataGridView.Columns.RemoveAt(10);
                        break;
                }
                

                if (isAdmin && (table == "Products" || table == "Customers"))
                {
                    var deleteButton = new DataGridViewButtonColumn();
                    deleteButton.Name = table == "Products" ? "dataGridViewProductDeleteBtn" : "dataGridViewCustomerDeleteBtn";
                    deleteButton.HeaderText = "Delete";
                    deleteButton.Text = "Delete";
                    deleteButton.UseColumnTextForButtonValue = true;
                    this.dataGridView.Columns.Add(deleteButton);
                }
            }
            catch
            {
                MessageBox.Show($"Failed to load data from table {table}");
            }
        }

        private static DataTable GetData(string sqlCommand, List<KeyValuePair<string, string>> parameters)
        {
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(sqlCommand, connection);
            foreach (var pair in parameters)
            {
                command.Parameters.AddWithValue(pair.Key, pair.Value);
            }
            using SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string term = searchTxtBx.Text.Trim();
            int index = tableViewCmboBx.SelectedIndex;
            string table = (string)tableViewCmboBx.Items[index];
            string selectStatement = $"SELECT * FROM {table} ";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            if (string.IsNullOrWhiteSpace(term))
            {
                //do no filtering, retieve all rows
            }
            else if (table == "Products")
            {
                selectStatement = $"DECLARE @termVar AS VARCHAR(MAX)=@term {selectStatement} ";
                selectStatement += "WHERE Name LIKE @termVar " +
                    "OR Price LIKE @term2 " +
                    "OR Category LIKE @termVar " +
                    "OR SubCategory LIKE @termVar ";
                parameters.Add(new KeyValuePair<string, string>("@term", $"%{term}%"));
                parameters.Add(new KeyValuePair<string, string>("@term2", $"%{term}"));
            }
            else if (table == "Customers")
            {
                selectStatement = $"DECLARE @termVar AS VARCHAR(MAX)=@term {selectStatement} ";
                selectStatement += "WHERE FirstName LIKE @termVar " +
                    "OR LastName LIKE @termVar " +
                    "OR EmailAddress LIKE @termVar " +
                    "OR PhoneNumber LIKE @termVar ";
                parameters.Add(new KeyValuePair<string, string>("@term", $"%{term}%"));
            }
            else if (table == "Users")
            {
                selectStatement += "WHERE UserName LIKE @term ";
                parameters.Add(new KeyValuePair<string, string>("@term", $"%{term}%"));
            }

            try
            {
                dataGridView.DataSource = new BindingSource().DataSource = GetData(selectStatement, parameters);
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

        void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dataGridView.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }

            //Check if click is on specific column 
            var deleteColumnProduct = dataGridView.Columns["dataGridViewProductDeleteBtn"];
            var deleteColumnCustomer = dataGridView.Columns["dataGridViewCustomerDeleteBtn"];
            var id = dataGridView.Rows[e.RowIndex].Cells[0].Value;
            
            if (deleteColumnProduct != null && e.ColumnIndex == deleteColumnProduct.Index)
            {
                var name = dataGridView.Rows[e.RowIndex].Cells[1].Value;
                var result = MessageBox.Show($"Are you sure you want to delete product \"{name}\"?\nThis will delete associated invoices as well.",
                    "Confirm Product Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var success = ProductService.DeleteProduct((int)id);
                    if (success)
                    {
                        MessageBox.Show("Successsfully deleted product.");
                        var parameters = new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("@id", (int)id) };
                        this.DeleteData("DELETE FROM Invoices WHERE ProductId = @id", parameters, "Invoices");
                        this.DeleteData("DELETE FROM Products WHERE Id = @id", parameters, "Products");
                        this.tableViewCmboBx_SelectedIndexChanged(null, null);//reload data view
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product.");
                    }
                }

            }
            else if (deleteColumnCustomer != null && e.ColumnIndex == deleteColumnCustomer.Index)
            {
                var fname = dataGridView.Rows[e.RowIndex].Cells[1].Value;
                var lname = dataGridView.Rows[e.RowIndex].Cells[2].Value;
                var result = MessageBox.Show($"Are you sure you want to delete customer \"{fname} {lname}\"?\nThis will delete associated invoices and user as well.",
                    "Confirm Customer Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var success = UserService.DeleteUser((int)id);
                    if (success)
                    {
                        MessageBox.Show("Successsfully deleted customer.");
                        this.tableViewCmboBx_SelectedIndexChanged(null, null);//reload data view
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete customer.");
                    }
                }
            }
        }

        private void DeleteData(string sqlCommand, List<KeyValuePair<string, int>> parameters, string table)
        {
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(sqlCommand, connection);
            foreach (var pair in parameters)
            {
                command.Parameters.AddWithValue(pair.Key, pair.Value);
            }
            using SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = command;

            try
            {
                adapter.Update(GetData($"SELECT * FROM {table}", new List<KeyValuePair<string, string>>()));
            }
            catch
            {
                //should work in local db if worked in project db. 
            }
        }
    }
}
