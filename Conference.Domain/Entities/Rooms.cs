﻿using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public class Rooms
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? Seats { get; set; }
        public string Edition { get; set; }

        public virtual ICollection<Schedules> Schedules { get; set; }
    }
}