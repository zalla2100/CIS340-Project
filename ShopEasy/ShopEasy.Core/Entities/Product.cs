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
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }

    public static class ProductCategories
    {
        public class ProductCategory
        {
            public string Name { get; set; }
            public List<string> SubCategories { get; set; } = new List<string>();
        }

        //Normally this would be in DB but CRUD functionality doesn't exist on categories for this application.
        public static readonly List<ProductCategory> Categories = new List<ProductCategory>
        {
            new ProductCategory
            {
                Name = "Grocery"
            },
            new ProductCategory
            {
                Name = "Music Instruments"
            },
            new ProductCategory
            {
                Name = "Books"
            },
            new ProductCategory
            {
                Name = "Electronics"
            },
            new ProductCategory 
            {
                Name = "Clothing",
                SubCategories = new List<string>
                {
                    "Men", "Women", "Kids"
                }
            }
        };
    }
}
