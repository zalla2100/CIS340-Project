using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopEasy.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}
