using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEasy.UI
{
    public partial class Admin
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Admin))]
        public virtual Users User { get; set; }
    }
}
