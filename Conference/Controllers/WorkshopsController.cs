using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Areas.Admin.Controllers
{
    public class WorkshopsController : Controller
    {
        private readonly IWorkshopService workshopService;
        public WorkshopsController(IWorkshopService workshopService)
        {
            this.workshopService = workshopService;
        }

        // GET: Workshops
        public ActionResult Index()
        {
            var allWorkshops = workshopService.GetAllWorkshops();
            return View(allWorkshops);
        }

        // GET: Workshops/Details/5
        public ActionResult Details(int id)
        {
            Workshops workshops = workshopService.GetWorkshopById(id);
            return View(workshops);
        }
    }
}