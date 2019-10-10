using System.Collections.Generic;

namespace Conference.Models
{
    public class WorkshopListItemViewModel
    {
        public WorkshopListItemViewModel()
        {
            Speakers = new List<SpeakerListItemViewModel>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Prerequisites { get; set; }

        public string Requirements { get; set; }

        public int? PlacesAvailable { get; set; }

        public string Edition { get; set; }

        public string RegistrationLink { get; set; }

        public string DetailsUrl { get; set; }


        public ICollection<SpeakerListItemViewModel> Speakers { get; set; }
    }
}