using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ShopEasy.Core.Logic
{
    public static class Validator
    {
        static readonly Regex PasswordRegex = new Regex("[a-zA-Z0-9" + Regex.Escape("!@#$%^&*-?") + "]{8,24}");
        static readonly Regex UsernameRegex = new Regex("[a-zA-Z0-9]{6,16}");

        public static bool ValidPassword(string password)
        {
            return ValidUserCredential(password, PasswordRegex);
        }

        public static bool ValidUsername(string username)
        {
            return ValidUserCredential(username, UsernameRegex);
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
