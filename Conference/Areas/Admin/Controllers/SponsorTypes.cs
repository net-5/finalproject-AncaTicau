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
    public class SponsorTypesController : Controller
    {
        private readonly ISponsorTypeService sponsorTypeService;
        public SponsorTypesController(ISponsorTypeService sponsorTypeService)
        {
            this.sponsorTypeService = sponsorTypeService;
        }

        [Area("Admin")]
        // GET: SponsorTypes
        public ActionResult Index()
        {
            var allSponsorTypes = sponsorTypeService.GetAllSponsorTypes();
            return View(allSponsorTypes);
        }

        [Area("Admin")]
        // GET: SponsorTypes/Details/5
        public ActionResult Details(int id)
        {
            SponsorTypes sponsorTypes = sponsorTypeService.GetSponsorTypeById(id);
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
                var addedSponsorType = sponsorTypeService.AddSponsorType(model);
                if (addedSponsorType == null)
                {
                    ModelState.AddModelError("Name", "SponsorType name must be unique!");
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
        // GET: SponsorTypes/Edit/5
        public ActionResult Edit(int id)
        {
            var sponsorType = sponsorTypeService.GetSponsorTypeById(id);

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
                var existingSponsorType = sponsorTypeService.GetSponsorTypeById(id);
                TryUpdateModelAsync(existingSponsorType);
                sponsorTypeService.UpdateSponsorType(existingSponsorType);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [Area("Admin")]
        // GET: SponsorTypes/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. try again, and if problem persists, contact your system administrator.";
            }
            SponsorTypes sponsorTypeToDelete = sponsorTypeService.GetSponsorTypeById(id);
            if (sponsorTypeToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(sponsorTypeToDelete);
            }
        }

        [Area("Admin")]
        // POST: SponsorTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                SponsorTypes sponsorTypeToDelete = sponsorTypeService.GetSponsorTypeById(id);
                sponsorTypeService.Delete(sponsorTypeToDelete);
                sponsorTypeService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}