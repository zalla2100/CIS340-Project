using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class AdminContext
    {
        public static bool IsUserAdmin(int userId)
        {
            string selectStatement =
                "SELECT UserId " +
                "FROM Admin " +
                "WHERE UserId = @UserId";
            using SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            using SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@UserId", userId);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                return true;
            }
            return false;
        }
    }
}
