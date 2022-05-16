using System.Configuration;
using System;

namespace ShopEasy.Infrastructure
{
    /// <summary>
    /// ShopEasy database connection
    /// </summary>
    public static class Connection
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["ShopEasyDB"].ConnectionString;
    }
}
