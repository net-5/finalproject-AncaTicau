using System.Collections.Generic;
using Conference.Constants;
using Conference.Domain.Entities;
using Conference.Interfaces;
using Conference.Models;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Services
{
    public class WorkshopAppService : IWorkshopAppService
    {
        private readonly IWorkshopService _workshopService;
        private readonly ISpeakerAppService _speakerAppService;

        public WorkshopAppService(IWorkshopService workshopService, ISpeakerAppService speakerAppService)
        {
            _workshopService = workshopService;
            _speakerAppService = speakerAppService;
        }

        public IList<WorkshopListItemViewModel> GetWorkshopListViewModel(IUrlHelper url)
        {
            IEnumerable<Workshops> allWorkshops = _workshopService.GetAllWorkshops();

            var result = new List<WorkshopListItemViewModel>();

            foreach (Workshops workshop in allWorkshops)
            {
                WorkshopListItemViewModel workshopViewModel = GetWorkshopListItemViewModel(url, workshop);

                result.Add(workshopViewModel);
            }

            return result;
        }

        public WorkshopListItemViewModel GetWorkshopListItemViewModel(IUrlHelper url, Workshops workshop)
        {
            var result = new WorkshopListItemViewModel
            {
                Name = workshop.Name,
                Description = workshop.Description,
                Prerequisites = workshop.Prerequisites,
                Requirements = workshop.Requirements,
                PlacesAvailable = workshop.PlacesAvailable,
                DetailsUrl = url.RouteUrl(RouteName.Details, new { controller = "Workshops", id = workshop.Id })
            };

            if (workshop.Speaker != null)
            {
                result.Speakers = new List<SpeakerListItemViewModel>
                {
                    _speakerAppService.GetSpeakerListItemViewModel(url, workshop.Speaker)
                };
            }

            return result;
        }
    }
}