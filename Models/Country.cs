using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clients_and_addresses.Models
{
    public class Country
    {
        public int CountryID { get; set; }

        public string  Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
