using System.Configuration;
using System;

namespace ShopEasy.Infrastructure
{
    public static class Connection
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["ShopEasyDB"].ConnectionString;

        //Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB; AttachDBFilename='|DataDirectory|\ShopEasyDB.mdf'; Integrated security=True" -Provider Microsoft.EntityFrameworkCore.SqlServer -Outputdir Contexts -Context ShopEasyDBContext -DataAnnotations -Force
    }
}
