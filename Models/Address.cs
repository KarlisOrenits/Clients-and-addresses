using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clients_and_addresses.Models
{
    public enum Status
    {
        Billing,
        Delivery
    }

    public class Address
    {

        public int ID { get; set; }
        public int CustomerID { get; set; }

        public int CountryID { get; set; }
        [Required]
        [StringLength(60)]
        public string StreetAddress { get; set; }
        [Required]
        [StringLength(60)]
        public string City { get; set; }
        [Required]
        [StringLength(60)]
        public string Zip { get; set; }

        public Status Type { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Country Country { get; set; }

    }
}

