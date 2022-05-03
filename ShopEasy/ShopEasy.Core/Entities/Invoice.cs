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
        //TODO: add property for ItemPrice (double) here, db schema, and context. Product price may change after invoice.
        public int Quantity { get; set; }
        //TODO: add property for Discount (double) here, db schema, and context
        //TODO: add property for Tax (double) here, db schema, and context
        public double TotalValue { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
