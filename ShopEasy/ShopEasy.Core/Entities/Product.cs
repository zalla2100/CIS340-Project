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
        /*
         * TODO: add property for IsActive (bool) here, db schema (bit), and context
         * This way, no need to delete them which wouldn't do in real life due to auditing
         *  and so invoies referencing old product can be retained/viewed
         */
    }

    public class ProductCategory
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
    }
}
