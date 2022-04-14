using Microsoft.Data.SqlClient;
using ShopEasy.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class CustomerContext
    {
        public static Customer GetCustomer(int userId)
        {
            Customer customer = null;
            string selectStatement =
                "SELECT Id, FirstName, LastName, EmailAddress, PhoneNumber, IsVeteran, IsSenior " +
                "FROM Customers " +
                "WHERE Id = @UserId";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@UserId", userId);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                customer = new Customer
                {
                    Id = (int)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    EmailAddress = reader["EmailAddress"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    IsVeteran = (bool)reader["IsVeteran"],
                    IsSenior = (bool)reader["IsSenior"]
                };
            }
            return customer;
        }
    }
}
