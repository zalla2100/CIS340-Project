using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Core
{
    class Invoice
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double TotalValue { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
