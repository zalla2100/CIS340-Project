using Microsoft.Data.SqlClient;
using ShopEasy.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class UserContext
    {
        public static User GetUser(int userId)
        {
            User user = null;
            string selectStatement =
                "SELECT Id, UserName, Password " +
                "FROM Users " +
                "WHERE Id = @UserId";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@UserId", userId);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                user = new User
                {
                    Id = (int)reader["Id"],
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString()
                };
            }
            return user;
        }

        public static User GetUser(string userName)
        {
            User user = null;
            string selectStatement =
                "SELECT Id, UserName, Password " +
                "FROM Users " +
                "WHERE UserName = @UserName";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@UserName", userName);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                user = new User
                {
                    Id = (int)reader["Id"],
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString()
                };
            }
            return user;
        }

        public static User GetUser(string userName, string password)
        {
            User user = null;
            string selectStatement =
                "SELECT Id, UserName, Password " +
                "FROM Users " +
                "WHERE UserName = @UserName " +
                "AND Password = @Password";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                user = new User
                {
                    Id = (int)reader["Id"],
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString()
                };
            }
            return user;
        }

        public static bool UpdateUser(User user)
        {
            int numUpdated = 0;

            string updateStatment = "UPDATE Users " +
                "SET UserName = @UserName, " +
                    "Password = @Password " +
                "WHERE Id = @UserId";

            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(updateStatment, connection);
            command.Parameters.AddWithValue("@UserId", user.Id);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            connection.Open();

            try
            {
                numUpdated = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update user {user.Id}:\n\t{ex.Message}");
            }

            connection.Close();
            return numUpdated == 1;
        }

        public static bool AddUser(User user)
        {
            int numInserted = 0;

            string insertStatement =
                "INSERT INTO Customers (UserName, Password) " +
                "VALUES (@UserName, @Password)";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(insertStatement, connection);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);

            connection.Open();

            try
            {
                numInserted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to insert user:\n\t{ex.Message}");
            }

            connection.Close();
            return numInserted == 1;
        }

        public static int GetHighestId()
        {
            string selectStatement =
                "SELECT MAX(Id) " +
                "FROM Users ";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(selectStatement, connection);
            connection.Open();

            try
            {
                return (int)command.ExecuteScalar();
            }
            catch
            {
                return 0;
            }
        }
    }
}
