using ShopEasy.Core;
using ShopEasy.Core.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class UserService
    {
        public static int AddUser(Customer customer)
        {
            string username;
            string password = GuidBase();
            User currentUser;
            int counter = 1;

            do
            {
                username = $"{customer.FirstName[0]}{customer.LastName[..6]}{counter}";
                currentUser = UserContext.GetUser(username);
                counter++;
            }
            while (currentUser != null);
            
            User newUser = new User
            {
                UserName = username,
                Password = password
            };

            if (UserContext.AddUser(newUser)) {
                return UserContext.GetUser(username).Id;
            }

            Console.WriteLine("failed to add new user");
            return -1;
        }

        public static bool UpdateUser(User user)
        {
            if (Validator.ValidUsername(user.UserName) && Validator.ValidPassword(user.Password)) {
                return UserContext.UpdateUser(user);
            }

            return false;
        }

        private static string GuidBase()
        {
            return Guid.NewGuid().ToString()[..8];
        }
    }
}
