using System;

namespace ShopEasy.Infrastructure
{
    public static class Connection
    {
        public static string ConnectionString
            => @"Data Source=(LocalDB)\MSSQLLocalDB;
                AttachDbFilename='|DataDirectory|\ShopEasyDB.mdf';Integrated Security=True"; 
    }
}
