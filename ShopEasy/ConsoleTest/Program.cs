﻿using ShopEasy.Core;
using ShopEasy.Infrastructure;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isAdmin = AdminContext.IsUserAdmin(1);
            Console.WriteLine($"User 1 is an admin: {isAdmin}");

            isAdmin = AdminContext.IsUserAdmin(2);
            Console.WriteLine($"User 2 is an admin: {isAdmin}");

            User user = UserContext.GetUser(1);
            Console.WriteLine($"User 1 username: {user.UserName}");

            user = UserContext.GetUser("ShopEasyAdmin", "Admin123");
            Console.WriteLine($"User id of \"ShopEasyAdmin\": {user.Id}");

            user = UserContext.GetUser(2);

            Customer customer = CustomerContext.GetCustomer(user.Id);
            Console.WriteLine($"Email of customer id {user.Id}: {customer.EmailAddress}");
            Console.WriteLine($"Is customer id {user.Id} senior: {customer.IsSenior}");

            customer.LastName = "Dunham";
            customer.EmailAddress = "tdunham@example.com";
            customer.IsSenior = false;
            user.UserName = "TyDunham";
            Console.WriteLine($"Successfully updated customer {customer.Id}: {CustomerContext.UpdateCustomer(customer)}");
            Console.WriteLine($"Successfully updated user {user.Id}: {UserContext.UpdateUser(user)}");

            Console.WriteLine($"User id {user.Id} new username: {UserContext.GetUser(2).UserName}");
            Console.WriteLine($"Customer id {customer.Id} new lastname: {CustomerContext.GetCustomer(2).LastName}");
            Console.WriteLine($"Customer id {customer.Id} new email: {CustomerContext.GetCustomer(2).EmailAddress}");
            Console.WriteLine($"Customer id {customer.Id} new senior status: {CustomerContext.GetCustomer(2).IsSenior}");

            Console.WriteLine($"setting values for user/customer {user.Id} back to original.");

            customer.LastName = "Dunn";
            customer.EmailAddress = "tdunn@example.com";
            user.UserName = "TyDunn";
            customer.IsSenior = true;
            Console.WriteLine($"Successfully updated customer {customer.Id}: {CustomerContext.UpdateCustomer(customer)}");
            Console.WriteLine($"Successfully updated user {user.Id}: {UserContext.UpdateUser(user)}");

            Console.WriteLine($"User id {user.Id} original username: {UserContext.GetUser(2).UserName}");
            Console.WriteLine($"Customer id {customer.Id} original lastname: {CustomerContext.GetCustomer(2).LastName}");
            Console.WriteLine($"Customer id {customer.Id} original email: {CustomerContext.GetCustomer(2).EmailAddress}");
            Console.WriteLine($"Customer id {customer.Id} old senior status: {CustomerContext.GetCustomer(2).IsSenior}");

            //Invoice newInvoice = new Invoice
            //{
            //    CustomerId = 2,
            //    ProductId = 1, //need to add product
            //    Quantity = 1,
            //    TotalValue = 0.00, //correct after adding product
            //    TimeStamp = DateTime.Now
            //};
            //Console.WriteLine($"successfully added invoice: {InvoiceContext.AddInvoice(newInvoice)}");

            List<Invoice> invoices = InvoiceContext.GetAllInvoices();
            Console.WriteLine($"There are {invoices.Count} invoices.");

            if(invoices.Count > 0)
            {
                Console.WriteLine($"Invoice 1 total value: {invoices[0].TotalValue}");
            }

            Console.WriteLine("\nPress any key to end.");
            Console.ReadKey(); //keep console open until user presses a key
        }
    }
}
