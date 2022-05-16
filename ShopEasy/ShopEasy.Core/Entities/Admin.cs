using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEasy.Core
{
    /// <summary>
    /// Class for Admin table, used to provision admin access and mimic AD groups
    /// </summary>
    public partial class Admin
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Admin))]
        public virtual Users User { get; set; }
    }
}
