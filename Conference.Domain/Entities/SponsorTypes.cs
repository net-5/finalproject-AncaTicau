using System;
using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public partial class SponsorTypes
    {
        public SponsorTypes()
        {
            Sponsors = new HashSet<Sponsors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Edition { get; set; }

        public virtual ICollection<Sponsors> Sponsors { get; set; }
    }
}
