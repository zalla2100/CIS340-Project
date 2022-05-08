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
                "SELECT Id, Name, Price, Category, SubCategory " +
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
                    Category = reader["Category"].ToString(),
                    SubCategory = reader["SubCategory"].ToString()
                };
            }
            return product;
        }


        //public static bool UpdateProduct()
        //{

        //}

        public static bool DeleteProduct(int id)
        {
            string deleteStatement = "DELETE FROM Products WHERE Id = @id";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(deleteStatement, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            int count = command.ExecuteNonQuery();
            connection.Close();
            return count == 1;
        }
    }
}
