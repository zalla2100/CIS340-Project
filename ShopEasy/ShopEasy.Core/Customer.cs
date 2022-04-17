using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Core
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVeteran { get; set; }
        public bool IsSenior { get; set; }
    }

    //public static class Convert
    //{
    //    public static int BooleanToInt(bool b)
    //    {
    //        return b ? 1 : 0;
    //    }
    //}
}
