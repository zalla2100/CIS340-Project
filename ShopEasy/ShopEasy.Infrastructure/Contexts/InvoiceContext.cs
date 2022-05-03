using Microsoft.Data.SqlClient;
using ShopEasy.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class InvoiceContext
    {
        public static List<Invoice> GetAllInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            string selectStatement =
                "SELECT Id, CustomerId, ProductId, ItemPrice, Quantity, Discount, Tax, SubTotal, TotalValue, TimeStamp " +
                "FROM Invoices ";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(selectStatement, connection);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                invoices.Add(
                    new Invoice
                    {
                        Id = (int)reader["Id"],
                        CustomerId = (int)reader["CustomerId"],
                        ProductId = (int)reader["ProductId"],
                        ItemPrice = (int)reader["ItemPrice"],
                        Quantity = (int)reader["Quantity"],
                        Discount = (int)reader["Discount"],
                        Tax = (int)reader["Tax"],
                        SubTotal = (int)reader["SubTotal"],
                        TotalValue = (double)reader["TotalValue"],
                        TimeStamp = (DateTime)reader["TimeStamp"]
                    }
                );
            }

            return invoices;
        }

        public static bool AddInvoice(Invoice invoice)
        {
            int numInserted = 0;

            string insertStatement =
                "INSERT INTO Invoices (CustomerId, ProductId, ItemPrice, Quantity, Discount, Tax, SubTotal, TotalValue, TimeStamp) " +
                "VALUES (@CustomerId, @ProductId, @ItemPrice, @Quantity, @Discount, @Tax, @SubTotal, @TotalValue, @TimeStamp)";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(insertStatement, connection);
            command.Parameters.AddWithValue("@CustomerId", invoice.CustomerId);
            command.Parameters.AddWithValue("@ProductId", invoice.ProductId);
            command.Parameters.AddWithValue("@ItemPrice", invoice.ItemPrice);
            command.Parameters.AddWithValue("@Quantity", invoice.Quantity);
            command.Parameters.AddWithValue("@Discount", invoice.Discount);
            command.Parameters.AddWithValue("@Tax", invoice.Tax);
            command.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
            command.Parameters.AddWithValue("@TotalValue", invoice.TotalValue);
            command.Parameters.AddWithValue("@TimeStamp", invoice.TimeStamp);
            connection.Open();

            try
            {
                numInserted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to insert invoice:\n\t{ex.Message}");
            }

            connection.Close();
            return numInserted == 1;
        }
    }
}
