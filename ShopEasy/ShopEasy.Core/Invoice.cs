using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Core
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TotalValue { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
