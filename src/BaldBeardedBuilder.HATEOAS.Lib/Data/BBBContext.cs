using System;
using Microsoft.EntityFrameworkCore;

using BaldBeardedBuilder.HATEOAS.Lib.Entities;

namespace BaldBeardedBuilder.HATEOAS.Lib.Data
{
    public class BBBContext: DbContext
    {
        public BBBContext()
        { }

        public BBBContext(DbContextOptions<BBBContext> options)
            : base(options)
        { }

        public void SeedData()
        {
            Client client1 = new Client()
            {
                Id = Guid.NewGuid(),
                Name = "Clause Inc."
            };
            Client client2 = new Client()
            {
                Id = Guid.NewGuid(),
                Name = "GrinchCo"
            };

            client1.Addresses.Add(new Address()
            {
                Id = Guid.NewGuid(),
                StreetAddress = "1 Candy Cane Lane",
                City = "North Pole",
                PostalCode = "NP1225"
            });

            client2.Addresses.Add(new Address()
            {
                Id = Guid.NewGuid(),
                StreetAddress = "543 Sad Sack Square",
                City = "Whoville",
                PostalCode = "IB1337"
            });

            this.Clients.AddRange(client1, client2);
            this.SaveChanges();
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}
