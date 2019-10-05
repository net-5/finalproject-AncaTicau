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
    public class SponsorsController : Controller
    {
        private readonly ISponsorService sponsorService;
        public SponsorsController(ISponsorService sponsorService)
        {
            this.sponsorService = sponsorService;
        }

        // GET: Sponsors
        public ActionResult Index()
        {
            var allSponsors = sponsorService.GetAllSponsors();
            return View(allSponsors);
        }

        // GET: Sponsors/Details/5
        public ActionResult Details(int id)
        {
            Sponsors sponsors = sponsorService.GetSponsorById(id);
            if (sponsors == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            return View(sponsors);
        }
    }
}