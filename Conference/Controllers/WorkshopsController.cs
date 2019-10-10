using System.Collections.Generic;
using Conference.Domain.Entities;
using Conference.Interfaces;
using Conference.Models;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Controllers
{
    public class WorkshopsController : Controller
    {
        private readonly IWorkshopService _workshopService;
        private readonly IWorkshopAppService _workshopAppService;

        public WorkshopsController(IWorkshopService workshopService, IWorkshopAppService workshopAppService)
        {
            _workshopService = workshopService;
            _workshopAppService = workshopAppService;
        }

        public ActionResult Index()
        {
            IList<WorkshopListItemViewModel> viewModel = _workshopAppService.GetWorkshopListViewModel(Url);

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            Workshops workshop = _workshopService.GetWorkshopById(id);

            if (workshop == null)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }

            WorkshopListItemViewModel viewModel = _workshopAppService.GetWorkshopListItemViewModel(Url, workshop);

            return View(viewModel);
        }
    }
}