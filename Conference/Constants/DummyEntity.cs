using System.Collections.Generic;
using Conference.Models;

namespace Conference.Constants
{
    public static class DummyEntity
    {
        public static readonly List<SpeakerListItemViewModel> Speakers = new List<SpeakerListItemViewModel>
        {
            new SpeakerListItemViewModel
            {
                Name = "Aaron Stannard",
                Position = "Co-founder of Petabridge",
                PhotoUrl = "/img/Aaron_Stannard.png",
                SocialLinks = new List<SocialLink>
                {
                    new SocialLink
                    {
                        Url = "http://facebook.com/dotnetdays.ro",
                        CssClass = "fab fa-facebook"
                    },
                    new SocialLink
                    {
                        Url = "https://twitter.com/dotnetdaysro",
                        CssClass = "fab fa-twitter"
                    }
                }
            },
            new SpeakerListItemViewModel
            {
                Name = "Irina Scurtu",
                Position = "Software Architect Endava",
                PhotoUrl = "/img/irina-scurtu-small.png",
                SocialLinks = new List<SocialLink>
                {
                    new SocialLink
                    {
                        Url = "https://twitter.com/irina_scurtu",
                        CssClass = "fab fa-twitter"
                    },
                    new SocialLink
                    {
                        Url = "https://www.linkedin.com/in/irinascurtu/",
                        CssClass = "fab fa-linkedin"
                    }
                }
            },
            new SpeakerListItemViewModel
            {
                Name = "Michael Kaufmann",
                Position = "Software Arhitect Microsoft",
                PhotoUrl = "/img/Michael_Kaufman.png",
                SocialLinks = new List<SocialLink>
                {
                    new SocialLink
                    {
                        Url = "http://facebook.com/dotnetdays.ro",
                        CssClass = "fab fa-facebook"
                    },
                    new SocialLink
                    {
                        Url = "https://twitter.com/dotnetdaysro",
                        CssClass = "fab fa-twitter"
                    }
                }

            },
            new SpeakerListItemViewModel
            {
                Name = "Jon Galloway",
                Position = "Executive director .NET Foundation",
                PhotoUrl = "/img/Jon-Galloway.jpeg",
                SocialLinks = new List<SocialLink>
                {
                    new SocialLink
                    {
                        Url = "http://facebook.com/dotnetdays.ro",
                        CssClass = "fab fa-facebook"
                    },
                    new SocialLink
                    {
                        Url = "https://twitter.com/dotnetdaysro",
                        CssClass = "fab fa-twitter"
                    }
                }
        }};

        public static readonly List<WorkshopListItemViewModel> Workshops = new List<WorkshopListItemViewModel>
        {
            new WorkshopListItemViewModel
            {
                Prerequisites = "22/02, 14:00 - 18:00",
                Name = "Deep-Dive in Asp Core",
                Speakers = new List<SpeakerListItemViewModel>
                {
                    new SpeakerListItemViewModel
                    {
                        Name = "Irina Scurtu"
                    }
                }
            },
            new WorkshopListItemViewModel
            {
                Prerequisites = "22/02, 14:00 - 18:00",
                Name = "dotnet with Docker on Linux",
                Speakers = new List<SpeakerListItemViewModel>
                {
                    new SpeakerListItemViewModel
                    {
                        Name = "Andrei Mustata"
                    }
                }
            },
            new WorkshopListItemViewModel
            {
                Prerequisites = "22/02, 9:00 - 13:00",
                Name = "Clean Code: Dive beyond the theory",
                Speakers = new List<SpeakerListItemViewModel>
                {
                    new SpeakerListItemViewModel
                    {
                        Name = "Mihaela Ghidersa"
                    }
                }
            },
            new WorkshopListItemViewModel
            {
                Prerequisites = "22/02, 9:00 - 13:00",
                Name = "Applied serverless: event-driven processing in Azure",
                Speakers = new List<SpeakerListItemViewModel>
                {
                    new SpeakerListItemViewModel
                    {
                        Name = "Andrei Scutariu"
                    }
                }
            }
        };
    }
}