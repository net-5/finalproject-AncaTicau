using System;
using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public partial class Editions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TagLine { get; set; }
        public int Year { get; set; }
        public bool Active { get; set; }
    }
}
