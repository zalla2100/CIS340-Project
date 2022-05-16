using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEasy.Core
{
    /// <summary>
    /// Class for Users table
    /// </summary>
    public partial class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string UserName { get; set; }

        [Required]
        [StringLength(24)]
        public string Password { get; set; }

        [InverseProperty("User")]
        public virtual Admin Admin { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual Customers Customers { get; set; }
    }
}
