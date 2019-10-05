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
    public class EditionsController : Controller
    {
        private readonly IEditionService editionService;
        public EditionsController(IEditionService editionService)
        {
            this.editionService = editionService;
        }



        [Area("Admin")]
        // GET: Editions
        public ActionResult Index()
        {
            var allEditions = editionService.GetAllEditions();
            return View(allEditions);
        }

        [Area("Admin")]
        // GET: Editions/Details/5
        public ActionResult Details(int id)
        {
            Editions editions = editionService.GetEditionById(id);
            return View(editions);
        }

        [Area("Admin")]
        // GET: Editions/Create
        public ActionResult Create()
        {
            return View();
        }

        [Area("Admin")]
        // POST: Editions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Editions model)
        {
            if (ModelState.IsValid)
            {
                var addedEdition = editionService.AddEdition(model);
                if (addedEdition == null)
                {
                    ModelState.AddModelError("Name", "Edition name nust be unique!");
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
        // GET: Editions/Edit/5
        public ActionResult Edit(int id)
        {
            var edition = editionService.GetEditionById(id);
            return View(edition);
        }

        [Area("Admin")]
        // POST: Editions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Editions model)
        {
            if (ModelState.IsValid)
            {
                var existingEdition = editionService.GetEditionById(id);
                TryUpdateModelAsync(existingEdition);
                editionService.UpdateEdition(existingEdition);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [Area("Admin")]
        // GET: Editions/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {


            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if problem persists, contact your system administrator.";
            }

            Editions editionToDelete = editionService.GetEditionById(id);
            if (editionToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(editionToDelete);
            }
        }

        [Area("Admin")]
        // POST: Editions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Editions editionToDelete = editionService.GetEditionById(id);
                editionService.Delete(editionToDelete);
                editionService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}