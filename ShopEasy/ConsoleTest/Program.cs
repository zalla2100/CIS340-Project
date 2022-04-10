using ShopEasy.Core;
using ShopEasy.Infrastructure;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isAdmin = AdminContext.IsUserAdmin(1);
            Console.WriteLine($"User 1 is an admin: {isAdmin}");
            isAdmin = AdminContext.IsUserAdmin(2); //user with id doesn't even exist yet
            Console.WriteLine($"User 2 is an admin: {isAdmin}");
            User user = UserContext.GetUser(1);
            Console.WriteLine($"User 1 username: {user.UserName}");
            Console.WriteLine("Press any key to end.");
            Console.ReadKey(); //keep console open until user presses a key
        }
    }
}
