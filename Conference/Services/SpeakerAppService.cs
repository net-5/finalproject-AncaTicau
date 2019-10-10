using System.Collections.Generic;
using Conference.Constants;
using Conference.Domain.Constants;
using Conference.Domain.Entities;
using Conference.Interfaces;
using Conference.Models;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Services
{
    public class SpeakerAppService : ISpeakerAppService
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerAppService(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        public IList<SpeakerListItemViewModel> GetSpeakerListViewModel(IUrlHelper url)
        {
            IEnumerable<Speakers> allSpeakers = _speakerService.GetAllSpeakers();

            var result = new List<SpeakerListItemViewModel>();

            foreach (Speakers speaker in allSpeakers)
            {
                SpeakerListItemViewModel speakerViewModel = GetSpeakerListItemViewModel(url, speaker);

                result.Add(speakerViewModel);
            }

            return result;
        }

        public SpeakerListItemViewModel GetSpeakerListItemViewModel(IUrlHelper url, Speakers speaker)
        {
            var result = new SpeakerListItemViewModel
            {
                Name = speaker.Name,
                Position = speaker.Position,
                Description = speaker.Description,
                PhotoUrl = speaker.PageSlug,
                DetailsUrl = url.RouteUrl(RouteName.Details, new { controller = "Speakers", id = speaker.Id })
            };

            AddSocialLink(result, speaker.Website, SocialLinkType.Website);
            AddSocialLink(result, speaker.Facebook, SocialLinkType.Facebook);
            AddSocialLink(result, speaker.LinkedIn, SocialLinkType.LinkedIn);
            AddSocialLink(result, speaker.Skype, SocialLinkType.Skype);
            AddSocialLink(result, speaker.GitHub, SocialLinkType.GitHub);
            AddSocialLink(result, speaker.Twitter, SocialLinkType.Twitter);

            foreach (Workshops workshop in speaker.Workshops)
            {
                result.Workshops.Add(new SpeakerWorkshop
                {
                    Name = workshop.Name,
                    DetailsUrl = url.RouteUrl(RouteName.Details, new { controller = "Workshops", id = workshop.Id })
                });
            }

            return result;
        }

        private void AddSocialLink(SpeakerListItemViewModel speakerViewModel, string socialLink, string socialLinkType)
        {
            if (string.IsNullOrWhiteSpace(socialLink))
            {
                return;
            }

            string cssClass = null;

            switch (socialLinkType)
            {
                case SocialLinkType.Facebook:
                    cssClass = "fab fa-facebook";
                    break;
                case SocialLinkType.Twitter:
                    cssClass = "fab fa-twitter";
                    break;
                case SocialLinkType.Website:
                    cssClass = "fas fa-link";
                    break;
                case SocialLinkType.LinkedIn:
                    cssClass = "fab fa-linkedin";
                    break;
                case SocialLinkType.Skype:
                    cssClass = "fab fa-skype";
                    break;
                case SocialLinkType.GitHub:
                    cssClass = "fab fa-github";
                    break;
            }

            if (cssClass == null)
            {
                return;
            }

            speakerViewModel.SocialLinks.Add(new SocialLink
            {
                Type = socialLinkType,
                Url = socialLink,
                CssClass = cssClass
            });
        }
    }
}