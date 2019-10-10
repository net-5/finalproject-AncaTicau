using System.Collections.Generic;
using System.Data;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Areas.Admin.Controllers
{
    public class EditionsController : Controller
    {
        private readonly IEditionService _editionService;

        public EditionsController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        [Area("Admin")]
        // GET: Editions
        public ActionResult Index()
        {
            IEnumerable<Editions> allEditions = _editionService.GetAllEditions();

            return View(allEditions);
        }

        [Area("Admin")]
        // GET: Editions/Details/5
        public ActionResult Details(int id)
        {
            Editions editions = _editionService.GetEditionById(id);

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
                Editions addedEdition = _editionService.AddEdition(model);
                if (addedEdition == null)
                {
                    ModelState.AddModelError("Name", "Edition name nust be unique!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: Editions/Edit/5
        public ActionResult Edit(int id)
        {
            Editions edition = _editionService.GetEditionById(id);

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
                Editions existingEdition = _editionService.GetEditionById(id);

                TryUpdateModelAsync(existingEdition);
                _editionService.UpdateEdition(existingEdition);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: Editions/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if problem persists, contact your system administrator.";
            }

            Editions editionToDelete = _editionService.GetEditionById(id);

            if (editionToDelete == null)
            {
                return NotFound();
            }

            return View(editionToDelete);
        }

        [Area("Admin")]
        // POST: Editions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Editions editionToDelete = _editionService.GetEditionById(id);

                _editionService.Delete(editionToDelete);
                _editionService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}