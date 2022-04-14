using Microsoft.Data.SqlClient;
using ShopEasy.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class ProductContext
    {
        public static Product GetProduct(int productId)
        {
            Product product = null;
            string selectStatement =
                "SELECT Id, Name, Price, Category " +
                "FROM Products " +
                "WHERE Id = @ProductId";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@ProductId", productId);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                product = new Product
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Price = (double)reader["Price"],
                    CategoryId = (int)reader["Category"]
                };
            }
            return product;
        }

        public static Product GetProduct(string productName)
        {
            Product product = null;
            string selectStatement =
                "SELECT Id, Name, Price, Category " +
                "FROM Products " +
                "WHERE Name = @ProductName";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@ProductName", productName);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                product = new Product
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Price = (double)reader["Price"],
                    CategoryId = (int)reader["Category"]
                };
            }
            return product;
        }
    }
}
