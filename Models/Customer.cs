using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clients_and_addresses.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Customer
    {

        public int CustomerID { get; set; }
        [Required]
        [StringLength(60)]

        public string FullName { get; set; }
        [Required]
        [StringLength(60)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required]
        public Gender Sex { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}