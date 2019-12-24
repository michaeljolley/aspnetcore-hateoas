using System;

namespace BaldBeardedBuilder.HATEOAS.Models
{
    public class ClientModel : RestModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
