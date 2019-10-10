using System.Collections.Generic;
using System.Data;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Areas.Admin.Controllers
{
    public class SponsorsController : Controller
    {
        private readonly ISponsorService _sponsorService;

        public SponsorsController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [Area("Admin")]
        // GET: Sponsors
        public ActionResult Index()
        {
            IEnumerable<Sponsors> allSponsors = _sponsorService.GetAllSponsors();

            return View(allSponsors);
        }

        [Area("Admin")]
        // GET: Sponsors/Details/5
        public ActionResult Details(int id)
        {
            Sponsors sponsors = _sponsorService.GetSponsorById(id);

            if (sponsors == null)
            {
                return RedirectToAction("NotFoundPage", "Home");
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
                Sponsors addedSponsor = _sponsorService.AddSponsor(model);

                if (addedSponsor == null)
                {
                    ModelState.AddModelError("Name", "Sponsor name must be unique!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: Sponsors/Edit/5
        public ActionResult Edit(int id)
        {
            Sponsors sponsor = _sponsorService.GetSponsorById(id);

            return View(sponsor);
        }

        [Area("Admin")]
        // POST: Sponsors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sponsors model)
        {
            if (ModelState.IsValid)
            {
                Sponsors existingSponsor = _sponsorService.GetSponsorById(id);

                TryUpdateModelAsync(existingSponsor);
                _sponsorService.UpdateSponsor(existingSponsor);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: Sponsors/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. try again, and if problem persists, contact your system administrator.";
            }

            Sponsors sponsorToDelete = _sponsorService.GetSponsorById(id);

            if (sponsorToDelete == null)
            {
                return NotFound();
            }

            return View(sponsorToDelete);
        }

        [Area("Admin")]
        // POST: Sponsors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Sponsors sponsorToDelete = _sponsorService.GetSponsorById(id);

                _sponsorService.Delete(sponsorToDelete);
                _sponsorService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}