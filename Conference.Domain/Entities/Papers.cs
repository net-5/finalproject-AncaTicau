using System;
using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public partial class Papers
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string FirstName { get; set; }
        public string GitHub { get; set; }
        public string LastName { get; set; }
        public string LinkedIn { get; set; }
        public string OtherMentions { get; set; }
        public int PaperStatusId { get; set; }
        public string Position { get; set; }
        public string PresentationDescription { get; set; }
        public string PresentationTitle { get; set; }
        public string Skype { get; set; }
        public string Tags { get; set; }
        public int TalkTypeId { get; set; }
        public string Twitter { get; set; }
        public string Website { get; set; }
        public string Edition { get; set; }

        public virtual PaperStatuses PaperStatus { get; set; }
        public virtual TalkTypes TalkType { get; set; }
    }
}
