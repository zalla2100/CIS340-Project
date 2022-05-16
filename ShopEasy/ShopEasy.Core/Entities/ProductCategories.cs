using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEasy.Core
{
    /// <summary>
    /// Class for ProductCategories table
    /// </summary>
    public partial class ProductCategories
    {
        public ProductCategories()
        {
            InverseParent = new HashSet<ProductCategories>();
        }

        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty(nameof(ProductCategories.InverseParent))]
        public virtual ProductCategories Parent { get; set; }
        [InverseProperty(nameof(ProductCategories.Parent))]
        public virtual ICollection<ProductCategories> InverseParent { get; set; }
    }
}
