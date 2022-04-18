using ShopEasy.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class UserOperations
    {
        public static int AddUser(Customer customer)
        {
            string username = $"User{UserContext.GetHighestId()+1}";
            string password = GuidBase();

            User currentUser = UserContext.GetUser(username);

            while (currentUser != null)
            {
                username = $"{customer.FirstName[0]}{customer.LastName[..6]}{GuidBase()[..9]}";
                currentUser = UserContext.GetUser(username);
            }
            
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

        public static void UpdateUser(User user)
        {
            //validate username and password
        }

        private static string GuidBase()
        {
            return Guid.NewGuid().ToString().Substring(0, 13);
        }
    }
}
