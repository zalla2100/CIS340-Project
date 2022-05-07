using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ShopEasy.Infrastructure;

namespace ShopEasy.UI
{
    public partial class UserActionsForm : Form
    {
        public UserActionsForm()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = true;
        }

        private void tableViewCmboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = tableViewCmboBx.SelectedIndex;
            var value = tableViewCmboBx.Items[index];

            try
            {
                dataGridView.DataSource = new BindingSource().DataSource = GetData($"Select * from {value}");
            }
            catch (SqlException)
            {
                MessageBox.Show($"Failed to load data from table {value}");
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private static DataTable GetData(string sqlCommand)
        {
            SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
