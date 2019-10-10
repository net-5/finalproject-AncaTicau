using System.Collections.Generic;
using System.Data;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Areas.Admin.Controllers
{
    public class SponsorTypesController : Controller
    {
        private readonly ISponsorTypeService _sponsorTypeService;

        public SponsorTypesController(ISponsorTypeService sponsorTypeService)
        {
            _sponsorTypeService = sponsorTypeService;
        }

        [Area("Admin")]
        // GET: SponsorTypes
        public ActionResult Index()
        {
            IEnumerable<SponsorTypes> allSponsorTypes = _sponsorTypeService.GetAllSponsorTypes();

            return View(allSponsorTypes);
        }

        [Area("Admin")]
        // GET: SponsorTypes/Details/5
        public ActionResult Details(int id)
        {
            SponsorTypes sponsorTypes = _sponsorTypeService.GetSponsorTypeById(id);

            return View(sponsorTypes);
        }

        [Area("Admin")]
        // GET: SponsorTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        [Area("Admin")]
        // POST: SponsorTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SponsorTypes model)
        {
            if (ModelState.IsValid)
            {
                SponsorTypes addedSponsorType = _sponsorTypeService.AddSponsorType(model);

                if (addedSponsorType == null)
                {
                    ModelState.AddModelError("Name", "SponsorType name must be unique!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: SponsorTypes/Edit/5
        public ActionResult Edit(int id)
        {
            SponsorTypes sponsorType = _sponsorTypeService.GetSponsorTypeById(id);

            return View(sponsorType);
        }

        [Area("Admin")]
        // POST: SponsorTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Editions model)
        {
            if (ModelState.IsValid)
            {
                SponsorTypes existingSponsorType = _sponsorTypeService.GetSponsorTypeById(id);

                TryUpdateModelAsync(existingSponsorType);
                _sponsorTypeService.UpdateSponsorType(existingSponsorType);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: SponsorTypes/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. try again, and if problem persists, contact your system administrator.";
            }

            SponsorTypes sponsorTypeToDelete = _sponsorTypeService.GetSponsorTypeById(id);

            if (sponsorTypeToDelete == null)
            {
                return NotFound();
            }

            return View(sponsorTypeToDelete);
        }

        [Area("Admin")]
        // POST: SponsorTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                SponsorTypes sponsorTypeToDelete = _sponsorTypeService.GetSponsorTypeById(id);

                _sponsorTypeService.Delete(sponsorTypeToDelete);
                _sponsorTypeService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}