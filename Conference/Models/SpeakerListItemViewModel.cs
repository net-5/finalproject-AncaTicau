using System.Collections.Generic;

namespace Conference.Models
{
    public class SpeakerListItemViewModel
    {
        public SpeakerListItemViewModel()
        {
            SocialLinks = new List<SocialLink>();
            Workshops = new List<SpeakerWorkshop>();
        }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public string DetailsUrl { get; set; }

        public ICollection<SocialLink> SocialLinks { get; set; }

        public ICollection<SpeakerWorkshop> Workshops { get; set; }
    }

    public class SocialLink
    {
        public string Url { get; set; }

        public string Type { get; set; }

        public string CssClass { get; set; }
    }

    public class SpeakerWorkshop
    {
        public string Name { get; set; }

        public string DetailsUrl { get; set; }
    }
}