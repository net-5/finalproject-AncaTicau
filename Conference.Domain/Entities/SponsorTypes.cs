using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public class SponsorTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Edition { get; set; }

        public virtual ICollection<Sponsors> Sponsors { get; set; }
    }
}