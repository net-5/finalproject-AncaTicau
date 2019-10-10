using System.Collections.Generic;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Controllers
{
    public class SponsorsController : Controller
    {
        private readonly ISponsorService _sponsorService;

        public SponsorsController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        public ActionResult Index()
        {
            IEnumerable<Sponsors> allSponsors = _sponsorService.GetAllSponsors();

            return View(allSponsors);
        }

        public ActionResult Details(int id)
        {
            Sponsors sponsors = _sponsorService.GetSponsorById(id);

            if (sponsors == null)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }

            return View(sponsors);
        }
    }
}