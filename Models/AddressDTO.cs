using System;
using System.ComponentModel.DataAnnotations;

namespace Clients_and_addresses.Models
{
    public class AddressDTO
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }

        public int CountryID { get; set; }
        [Required]
        [StringLength(60)]

        public string FullName { get; set; }
        [Required]
        [StringLength(60)]

        public string StreetAddress { get; set; }
        [Required]
        [StringLength(60)]
        public string City { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(60)]
        public string Zip { get; set; }

        public Status Type { get; set; }

    public virtual Customer Customer { get; set; }
        public virtual Country Country { get; set; }
    }
}
