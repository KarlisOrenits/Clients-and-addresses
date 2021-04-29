using Clients_and_addresses.Models;
using Microsoft.EntityFrameworkCore;



namespace Clients_and_addresses.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Country> Country { get; set; }
    }
}
