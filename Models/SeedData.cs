
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Clients_and_addresses.Models;

namespace Clients_and_addresses.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<CustomerContext>>()))
            {

                if (context.Customer.Any())
                {
                    return;   // DB has been seeded
                }
                var customers = new Customer[]
                {
                    new Customer
                    {
                        FullName = "Erik",
                        Email = "Joe@gmail.com",
                        BirthDate = DateTime.Parse("2010-09-01"),
                        Sex = Gender.Male
                    },

                    new Customer
                    {
                        FullName = "Adam",
                        Email = "Adam1234@inbox.com",
                        BirthDate = DateTime.Parse("2010-09-01"),
                        Sex = Gender.Male
                    },

                    new Customer
                    {
                        FullName = "Peter",
                        Email = "peter@gmail.com",
                        BirthDate = DateTime.Parse("2010-09-01"),
                        Sex = Gender.Male
                    },

                    new Customer
                    {
                        FullName = "James",
                        Email = "James.Wiseman@gmail.com",
                        BirthDate = DateTime.Parse("2010-09-01"),
                        Sex = Gender.Male
                    }
                };


                foreach (Customer c in customers)
                {
                    context.Customer.Add(c);
                }
                context.SaveChanges();


                var country = new Country[]
                {
                    new Country { Name = "Latvia"},

                    new Country{ Name = "Estonia"},

                    new Country { Name = "Lithuania"}

                };

                foreach (Country o in country)
                {
                    context.Country.Add(o);
                }
                context.SaveChanges();

                var addresses = new Address[]
                {
                    new Address
                    {
                        CustomerID = 1,
                        CountryID = 1,
                        StreetAddress = "Cat street",
                        City = "Rezekne",
                        Zip="4631",
                        Type= Status.Billing
                    },

                    new Address
                    {
                            CustomerID = 2,
                        CountryID =1,
                        StreetAddress = " Dog street ",
                        City = "Riga",
                        Zip="3631",
                        Type= Status.Billing
                    },

                    new Address
                    {
                        CustomerID = 3,
                        CountryID =3,
                        StreetAddress = "Horse street",
                        City = "Tallin",
                        Zip="9965",
                        Type= Status.Billing
                    },

                    new Address
                    {
                        CustomerID = 4,
                        CountryID =2,
                        StreetAddress = "Bear street",
                        City = "Vilnius",
                        Zip="4631",
                        Type= Status.Billing
                    }
                };

                foreach (Address a in addresses)
                {
                    context.Address.Add(a);
                }
                context.SaveChanges();
            }
        }
    }
}



