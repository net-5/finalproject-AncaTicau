using System;
using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public partial class Schedules
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int TalkId { get; set; }
        public int StartHour { get; set; }
        public int? BreakAfter { get; set; }
        public int? EndHour { get; set; }
        public string Edition { get; set; }

        public virtual Rooms Room { get; set; }
        public virtual Talks Talk { get; set; }
    }
}
