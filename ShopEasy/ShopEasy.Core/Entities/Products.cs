using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEasy.Core
{
    public partial class Products
    {
        public Products()
        {
            Invoices = new HashSet<Invoices>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(24)]
        public string Category { get; set; }

        [Required]
        [StringLength(24)]
        public string SubCategory { get; set; }


        [InverseProperty("Product")]
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
