using System.Collections.Generic;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Controllers
{
    public class EditionsController : Controller
    {
        private readonly IEditionService _editionService;

        public EditionsController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        public ActionResult Index()
        {
            IEnumerable<Editions> allEditions = _editionService.GetAllEditions();

            return View(allEditions);
        }

        public ActionResult Details(int id)
        {
            Editions editions = _editionService.GetEditionById(id);

            return View(editions);
        }
    }
}