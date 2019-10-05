using System;
using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public partial class TalkTypes
    {
        public TalkTypes()
        {
            Papers = new HashSet<Papers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Edition { get; set; }

        public virtual ICollection<Papers> Papers { get; set; }
    }
}
