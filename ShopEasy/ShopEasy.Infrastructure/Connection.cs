using System.Configuration;
using System;

namespace ShopEasy.Infrastructure
{
    public static class Connection
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["ShopEasyDB"].ConnectionString;

        /*
          Scaffold-DbContext –Connection "Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename='|DataDirectory|\ShopEasyDB.mdf'; Integrated Security=True" -Provider  Microsoft.EntityFrameworkCore.SqlServer  -OutputDir Models\DataLayer -Context ShopEasyDBContext -DataAnnotations –Force
         */
    }
}
