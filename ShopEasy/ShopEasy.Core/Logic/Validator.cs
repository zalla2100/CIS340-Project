using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ShopEasy.Core
{
    public static class Validator
    {
        static readonly Regex PasswordRegex = new Regex("^[a-zA-Z0-9 " + Regex.Escape("!@#$%^&*-?") + "]{8,24}$");
        static readonly Regex UsernameRegex = new Regex("^[a-zA-Z0-9]{6,16}$");

        public static string ValidPassword(string password)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(password))
            {
                error = "Password cannot be empty.\n";
            }
            else
            {
                if (!ValidUserCredential(password, PasswordRegex))
                {
                    error += "Password can only contain letters, numbers, spaces, and the following special characters: !@#$%^&*-?\n";
                }
                if (password.Length < 8 || password.Length > 24)
                {
                    error += "Password must be between 8 and 24 characters.\n";
                }
            }

            return error;
        }

        public static string ValidUsername(string username)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(username))
            {
                error = "Username cannot be empty.\n";
            }
            else
            {
                if (!ValidUserCredential(username, UsernameRegex))
                {
                    error += "Username can only contain letters and numbers.\n";
                }
                if (username.Length < 6 || username.Length > 16)
                {
                    error += "Username must be between 6 and 16 characters.\n";
                }
            }

            return error;
        }

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
    }
}
