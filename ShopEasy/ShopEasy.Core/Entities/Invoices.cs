using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEasy.Core
{
    /// <summary>
    /// Class for the Invoices tables
    /// </summary>
    public partial class Invoices
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        [Column(TypeName = "decimal(24, 2)")]
        public decimal ItemPrice { get; set; } //current price could be different from price paid at the time of sale

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(24, 2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(24, 2)")]
        public decimal Tax { get; set; }

        [Column(TypeName = "decimal(24, 2)")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "decimal(24, 2)")]
        public decimal TotalValue { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TimeStamp { get; set; }


        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Invoices))]
        public virtual Customers Customer { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Products.Invoices))]
        public virtual Products Product { get; set; }
    }
}
