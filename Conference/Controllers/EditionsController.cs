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

namespace Conference.Controllers
{
    public class EditionsController : Controller
    {
        private readonly IEditionService editionService;
        public EditionsController(IEditionService editionService)
        {
            this.editionService = editionService;
        }

        // GET: Editions
        public ActionResult Index()
        {
            var allEditions = editionService.GetAllEditions();
            return View(allEditions);
        }

        // GET: Editions/Details/5
        public ActionResult Details(int id)
        {
            Editions editions = editionService.GetEditionById(id);
            return View(editions);
        }
    }
}