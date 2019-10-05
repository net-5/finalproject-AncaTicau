using System.Collections.Generic;

namespace Conference.Models
{
    public class SpeakerListItemViewModel
    {
        public SpeakerListItemViewModel()
        {
            SocialLinks = new List<SocialLink>();
        }

        public string PhotoUrl { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public ICollection<SocialLink> SocialLinks { get; set; }
    }

    public class SocialLink
    {
        public string Url { get; set; }

        public string Type { get; set; }
    }
}