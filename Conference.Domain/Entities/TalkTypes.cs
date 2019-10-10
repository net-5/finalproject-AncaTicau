using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public class TalkTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Edition { get; set; }

        public virtual ICollection<Papers> Papers { get; set; }
    }
}