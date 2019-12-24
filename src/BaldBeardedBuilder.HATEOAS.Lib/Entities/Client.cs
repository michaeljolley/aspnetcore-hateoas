using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaldBeardedBuilder.HATEOAS.Lib.Entities
{
    public class Client
    {
        public Client()
        {
            this.Addresses = new HashSet<Address>();
        }
        
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
