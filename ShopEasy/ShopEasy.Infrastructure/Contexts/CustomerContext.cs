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

        public static bool UpdateCustomer(Customer customer)
        {
            int numUpdated = 0;

            string updateStatment = "UPDATE Customers " +
                "SET FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "EmailAddress = @EmailAddress, " +
                    "PhoneNumber = @PhoneNumber, " +
                    "IsVeteran = @IsVeteran, " +
                    "IsSenior = @IsSenior " +
                "WHERE Id = @UserId";

            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(updateStatment, connection);
            command.Parameters.AddWithValue("@UserId", customer.Id);
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
            command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            command.Parameters.AddWithValue("@IsVeteran", Convert.ToByte(customer.IsVeteran));
            command.Parameters.AddWithValue("@IsSenior", Convert.ToByte(customer.IsSenior));
            connection.Open();

            try
            {
                numUpdated = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update customer {customer.Id}:\n\t{ex.Message}");
            }

            connection.Close();
            return numUpdated == 1;
        }

        public static bool AddCustomer(Customer customer)
        {
            int numInserted = 0;

            string insertStatement =
                "INSERT INTO Customers (Id, FirstName, LastName, EmailAddress, PhoneNumber, IsVeteran, IsSenior) " +
                "VALUES (@UserId, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @IsVeteran, @IsSenior)";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(insertStatement, connection);
            command.Parameters.AddWithValue("@UserId", customer.Id);
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
            command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            command.Parameters.AddWithValue("@IsVeteran", Convert.ToByte(customer.IsVeteran));
            command.Parameters.AddWithValue("@IsSenior", Convert.ToByte(customer.IsSenior));
            connection.Open();

            try
            {
                numInserted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to insert customer:\n\t{ex.Message}");
            }

            connection.Close();
            return numInserted == 1;
        }
    }
}
