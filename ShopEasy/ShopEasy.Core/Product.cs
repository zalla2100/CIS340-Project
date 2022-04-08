using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopEasy.Core
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public ProductCategory Category { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public ProductSubCategory? SubCategory { get; set; } = null;
    }

    public enum ProductCategory
    {
        Grocery, 
        MusicInstruments, 
        Books,
        Clothing
    }

    public enum ProductSubCategory
    {
        Men,
        Women,
        Kids,
        Winter
    }
}
