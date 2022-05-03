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
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double SubTotal { get; set; }
        public double TotalValue { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
