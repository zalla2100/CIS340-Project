using System.Configuration;
using System;

namespace ShopEasy.Infrastructure
{
    public static class Connection
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["ShopEasyDB"].ConnectionString;    }
}
