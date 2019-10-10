using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public class PaperStatuses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Papers> Papers { get; set; }
    }
}