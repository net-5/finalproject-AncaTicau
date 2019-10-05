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

namespace Conference.Admin.Controllers
{
    public class SponsorsController : Controller
    {
        private readonly ISponsorService sponsorService;
        public SponsorsController(ISponsorService sponsorService)
        {
            this.sponsorService = sponsorService;
        }

        [Area("Admin")]
        // GET: Sponsors
        public ActionResult Index()
        {
            var allSponsors = sponsorService.GetAllSponsors();
            return View(allSponsors);
        }

        [Area("Admin")]
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

        [Area("Admin")]
        // GET: Sponsors/Create
        public ActionResult Create()
        {
            var viewModel = new Sponsors();
            return View(viewModel);
        }

        [Area("Admin")]
        // POST: Sponsors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sponsors model)
        {
            if (ModelState.IsValid)
            {
                var addedSponsor = sponsorService.AddSponsor(model);
                if (addedSponsor == null)
                {
                    ModelState.AddModelError("Name", "Sponsor name must be unique!");
                    return View(model);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return View(model);
            }
        }

        [Area("Admin")]
        // GET: Sponsors/Edit/5
        public ActionResult Edit(int id)
        {
            var sponsor = sponsorService.GetSponsorById(id);

            return View(sponsor);
        }

        [Area("Admin")]
        // POST: Sponsors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Editions model)
        {
            if (ModelState.IsValid)
            {
                var existingSponsor = sponsorService.GetSponsorById(id);
                TryUpdateModelAsync(existingSponsor);
                sponsorService.UpdateSponsor(existingSponsor);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [Area("Admin")]
        // GET: Sponsors/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. try again, and if problem persists, contact your system administrator.";
            }
            Sponsors sponsorToDelete = sponsorService.GetSponsorById(id);
            if (sponsorToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(sponsorToDelete);
            }
        }

        [Area("Admin")]
        // POST: Sponsors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Sponsors sponsorToDelete = sponsorService.GetSponsorById(id);
                sponsorService.Delete(sponsorToDelete);
                sponsorService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}