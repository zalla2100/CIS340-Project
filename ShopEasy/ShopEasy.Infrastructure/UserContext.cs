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
                "WHERE ID = @UserId";
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
    }
}
