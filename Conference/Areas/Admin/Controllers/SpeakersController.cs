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
    public class SpeakersController : Controller
    {
        private readonly ISpeakerService speakerService;
        public SpeakersController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }

        [Area("Admin")]
        // GET: Speakers
        public ActionResult Index()
        {
            var allSpeakers = speakerService.GetAllSpeakers();
            return View(allSpeakers);
        }

        [Area("Admin")]
        // GET: Speakers/Details/5
        public ActionResult Details(int id)
        {
            Speakers speakers = speakerService.GetSpeakerById(id);
            if (speakers == null)
            {
                return RedirectToAction("NotFound", "Home" );
            }
            return View(speakers);
        }

        [Area("Admin")]
        // GET: Speakers/Create
        public ActionResult Create()
        {
            var viewModel = new Speakers();
            return View(viewModel);
        }

        [Area("Admin")]
        // POST: Speakers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Speakers model)
        {
            if (ModelState.IsValid)
            {
                var addedSpeaker = speakerService.AddSpeaker(model);
                if (addedSpeaker == null)
                {
                    ModelState.AddModelError("Name", "Speaker name must be unique!");
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
        // GET: Speakers/Edit/5
        public ActionResult Edit(int id)
        {
            var speaker = speakerService.GetSpeakerById(id);

            return View(speaker);
        }

        [Area("Admin")]
        // POST: Speakers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Editions model)
        {
            if (ModelState.IsValid)
            {
                var existingSpeaker = speakerService.GetSpeakerById(id);
                TryUpdateModelAsync(existingSpeaker);
                speakerService.UpdateSpeaker(existingSpeaker);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [Area("Admin")]
        // GET: Speakers/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. try again, and if problem persists, contact your system administrator.";
            }
            Speakers speakerToDelete = speakerService.GetSpeakerById(id);
            if (speakerToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(speakerToDelete);
            }
        }

        [Area("Admin")]
        // POST: Speakers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Speakers speakerToDelete = speakerService.GetSpeakerById(id);
                speakerService.Delete(speakerToDelete);
                speakerService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}