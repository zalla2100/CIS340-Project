﻿using System;
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
        public string PhoneNumber { get; set; } //change db schema to be nvarchar(10)
        public bool IsVeteran { get; set; }
        public bool IsSenior { get; set; }
        //TODO: add property for IsTeacher (bool) here, db schema (bit), and context
    }
}
