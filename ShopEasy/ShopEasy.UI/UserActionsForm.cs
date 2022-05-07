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
        private User user = null;
        private bool isAdmin = false;

        public UserActionsForm(User user)
        {
            InitializeComponent();
            this.user = user;
            dataGridView.AutoGenerateColumns = true;
            tableViewCmboBx.Items.AddRange(new object[] {"Products","Invoices"});
            if (user != null)
            {
                this.isAdmin = AdminService.IsAdmin(user.Id);
            }
            if (isAdmin) {
                tableViewCmboBx.Items.AddRange(new string[] { "Customers", "Users" });
            }
        }

        private void tableViewCmboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tableViewCmboBx.SelectedIndex;
            string value = (string) tableViewCmboBx.Items[index];
            string selectStatement = $"Select * from {value}";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            if(value == "Invoices" && !isAdmin)
            {
                selectStatement += " where CustomerId = @customerId";
                parameters.Add(new KeyValuePair<string, string>("@customerId", user.Id.ToString()));
            }

            try
            {
                dataGridView.DataSource = new BindingSource().DataSource = GetData(selectStatement, parameters);
            }
            catch (SqlException)
            {
                MessageBox.Show($"Failed to load data from table {value}");
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private static DataTable GetData(string sqlCommand, List<KeyValuePair<string, string>> parameters)
        {
            SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            foreach(var pair in parameters)
            {
                command.Parameters.AddWithValue(pair.Key, pair.Value);
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
