using System.Collections.Generic;
using System.ComponentModel;

namespace Conference.Domain.Entities
{
    public class Talks
    {
        public int Id { get; set; }
        [DisplayName("Speaker")]
        public int SpeakerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Edition { get; set; }

        public virtual Speakers Speaker { get; set; }
        public virtual ICollection<Schedules> Schedules { get; set; }
    }
}