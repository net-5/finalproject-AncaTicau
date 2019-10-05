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
    public class WorkshopsController : Controller
    {
        private readonly IWorkshopService workshopService;
        public WorkshopsController(IWorkshopService workshopService)
        {
            this.workshopService = workshopService;
        }

        [Area("Admin")]
        // GET: Workshops
        public ActionResult Index()
        {
            var allWorkshops = workshopService.GetAllWorkshops();
            return View(allWorkshops);
        }

        [Area("Admin")]
        // GET: Workshops/Details/5
        public ActionResult Details(int id)
        {
            Workshops workshops = workshopService.GetWorkshopById(id);
            return View(workshops);
        }

        [Area("Admin")]
        // GET: Workshops/Create
        public ActionResult Create()
        {
            return View();
        }

        [Area("Admin")]
        // POST: Workshops/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workshops model)
        {
            if (ModelState.IsValid)
            {
                var addedWorkshop = workshopService.AddWorkshop(model);
                if (addedWorkshop == null)
                {
                    ModelState.AddModelError("Name", "Workshop name nust be unique!");
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
        // GET: Workshops/Edit/5
        public ActionResult Edit(int id)
        {
            var workshop = workshopService.GetWorkshopById(id);
            return View(workshop);
        }


        [Area("Admin")]
        // POST: Workshops/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Workshops model)
        {
            if (ModelState.IsValid)
            {
                var existingWorkshop = workshopService.GetWorkshopById(id);
                TryUpdateModelAsync(existingWorkshop);
                workshopService.UpdateWorkshop(existingWorkshop);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [Area("Admin")]
        // GET: Workshops/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if problem persists, contact your system administrator.";
            }

            Workshops workshopToDelete = workshopService.GetWorkshopById(id);
            if (workshopToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(workshopToDelete);
            }
        }

        [Area("Admin")]
        // POST: Workshops/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Workshops workshopToDelete = workshopService.GetWorkshopById(id);
                workshopService.Delete(workshopToDelete);
                workshopService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}