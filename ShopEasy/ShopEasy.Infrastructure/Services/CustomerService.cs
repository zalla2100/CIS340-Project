using ShopEasy.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class CustomerService
    {
        public static void AddCustomer(Customer customer)
        {
            //check that email and phone number are unique and valid
            int id = UserService.AddUser(customer);

            if (id != -1)
            {
                customer.Id = id;
                CustomerContext.AddCustomer(customer);
                return;
            }

            Console.WriteLine("Failed adding new customer");
        }

        public static void UpdateCustomer(Customer customer)
        {
            //validate fields
        }
    }
}
