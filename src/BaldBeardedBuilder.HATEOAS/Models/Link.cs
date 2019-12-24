using System;

namespace BaldBeardedBuilder.HATEOAS.Models
{
    public class Link
    {
        public Link(string href, string rel, string type)
        {
            Href = href;
            Rel = rel;
            Type = type;
        }

        public string Href { get; private set; }
        public string Rel { get; private set; }
        public string Type { get; private set; }
    }
}
