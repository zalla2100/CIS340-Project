using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Core
{
    public static class ProductCategories
    {
        public class ProductCategory
        {
            public string Name { get; set; }
            public List<string> SubCategories { get; set; } = new List<string>();
        }

        //move into a DB table
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
