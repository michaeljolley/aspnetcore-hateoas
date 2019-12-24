using System;
using System.Collections.Generic;

namespace BaldBeardedBuilder.HATEOAS.Models
{
    public abstract class RestModelBase
    {
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
