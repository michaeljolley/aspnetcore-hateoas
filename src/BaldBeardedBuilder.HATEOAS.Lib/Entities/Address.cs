using System;
using System.ComponentModel.DataAnnotations;

namespace BaldBeardedBuilder.HATEOAS.Lib.Entities
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
