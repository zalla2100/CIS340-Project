using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ShopEasy.Core;
using ShopEasy.Infrastructure;

namespace ShopEasy.UI
{
    public partial class UserActionsForm : Form
    {
        private User user;
        private bool isAdmin = false;

        public UserActionsForm(User user)
        {
            InitializeComponent();
            this.user = user;
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
            string selectStatement = $"SELECT * FROM {table} ";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

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

            if(table == "Invoices" && !isAdmin)
            {
                selectStatement += "WHERE CustomerId = @customerId ";
                parameters.Add(new KeyValuePair<string, string>("@customerId", user.Id.ToString()));
            }

            try
            {
                dataGridView.DataSource = new BindingSource().DataSource = GetData(selectStatement, parameters);
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
                MessageBox.Show($"Clicked on customer with id {id}");
            }
        }
    }
}
