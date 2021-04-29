using System;
using System.ComponentModel.DataAnnotations;


namespace Clients_and_addresses.Models
{ 
    public class CustomerDTO
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
        [Required]
        public int DeliveryAdresses { get; set; }
    }
}
