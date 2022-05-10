using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEasy.UI
{
    public partial class Customers
    {
        public Customers()
        {
            Invoices = new HashSet<Invoices>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public bool IsVeteran { get; set; }

        public bool IsSenior { get; set; }


        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Users.Customers))]
        public virtual Users IdNavigation { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
