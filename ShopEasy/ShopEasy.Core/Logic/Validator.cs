using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ShopEasy.Core
{
    /// <summary>
    /// Validate user input from various forms
    /// </summary>
    public static class Validator
    {
        static readonly Regex PasswordRegex = new Regex("^[a-zA-Z0-9 " + Regex.Escape("!@#$%^&*-?") + "]{8,24}$");
        static readonly Regex UsernameRegex = new Regex("^[a-zA-Z0-9]{6,16}$");

        /// <summary>
        /// Validates user password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>A string describing errors, if any</returns>
        public static string ValidPassword(string password)
        {
            StringBuilder builder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(password))
            {
                builder.AppendLine("Password cannot be empty.");
            }
            else
            {
                if (!ValidUserCredential(password, PasswordRegex))
                {
                    builder.AppendLine("Password can only contain letters, numbers, spaces, and the following special characters: !@#$%^&*-?");
                }
                if (password.Length < 8 || password.Length > 24)
                {
                    builder.AppendLine("Password must be between 8 and 24 characters.");
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Validates username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A string describing errors, if any</returns>
        public static string ValidUsername(string username)
        {
            StringBuilder builder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(username))
            {
                builder.AppendLine("Username cannot be empty.");
            }
            else
            {
                if (!ValidUserCredential(username, UsernameRegex))
                {
                    builder.AppendLine("Username can only contain letters and numbers.");
                }
                if (username.Length < 6 || username.Length > 16)
                {
                    builder.AppendLine("Username must be between 6 and 16 characters.");
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Validates user credential against given regex
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regex"></param>
        /// <returns>A boolean indicating if regex matches</returns>
        private static bool ValidUserCredential(string value, Regex regex)
        {
            if (value != null)
            {
                try
                {
                    return regex.IsMatch(value);
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates product
        /// </summary>
        /// <param name="name"></param>
        /// <param name="categoryIndex"></param>
        /// <param name="subCategoryEnabled"></param>
        /// <param name="subCategoryIndex"></param>
        /// <returns>A string describing errors, if any</returns>
        public static string ValidProduct(string name, int categoryIndex, bool subCategoryEnabled, int subCategoryIndex)
        {
            StringBuilder builder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(name))
            {
                builder.AppendLine("Product name cannot be empty.");
            }
            else if (name.Length > 40)
            {
                builder.AppendLine("Product name cannot be greater than 40 characters.");
            }

            if (categoryIndex == -1)
            {
                builder.AppendLine("Category is required.");
            }
            if (subCategoryEnabled && subCategoryIndex == -1)
            {
                builder.AppendLine("Subcategory is required.");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Validates customer
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <returns>A string describing errors, if any</returns>
        public static string ValidCustomer(string firstname, string lastname, string email, string phone)
        {
            StringBuilder builder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(firstname))
            {
                builder.AppendLine("First name cannot be empty.");
            }
            else if (firstname.Length > 30)
            {
                builder.AppendLine("First name cannot be greater than 30 characters.");
            }

            if (string.IsNullOrWhiteSpace(lastname))
            {
                builder.AppendLine("Last name cannot be empty.");
            }
            else if (lastname.Length > 30) 
            {
                builder.AppendLine("Last name cannot be greater than 30 characters.");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                builder.AppendLine("Email cannot be empty.");
            }
            else if (email.Length > 50)
            {
                builder.AppendLine("Email cannot be greater than 50 characters.");
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                builder.AppendLine("Phone number cannot be empty.");
            }

            Regex nameRegex = new Regex("^[a-zA-Z ]{1,30}$");
            if (!nameRegex.IsMatch(firstname))
            {
                builder.AppendLine("First name can only contain letters and spaces.");
            }
            if (!nameRegex.IsMatch(lastname))
            {
                builder.AppendLine("Last name can only contain letters and spaces.");
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                builder.AppendLine("Invalid email address.");
            }
            if (!Regex.IsMatch(phone, "^[0-9]{10}$"))
            {
                builder.AppendLine("Phone number must be 10 consecutive digits.");
            }

            return builder.ToString();
        }
    }
}
