using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Core
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
    }
}
