using System.Collections.Generic;
using System.Data;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Areas.Admin.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly ISpeakerService _speakerService;

        public SpeakersController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [Area("Admin")]
        // GET: Speakers
        public ActionResult Index()
        {
            IEnumerable<Speakers> allSpeakers = _speakerService.GetAllSpeakers();

            return View(allSpeakers);
        }

        [Area("Admin")]
        // GET: Speakers/Details/5
        public ActionResult Details(int id)
        {
            Speakers speakers = _speakerService.GetSpeakerById(id);

            if (speakers == null)
            {
                return RedirectToAction("NotFoundPage", "Home" );
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
                Speakers addedSpeaker = _speakerService.AddSpeaker(model);

                if (addedSpeaker == null)
                {
                    ModelState.AddModelError("Name", "Speaker name must be unique!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: Speakers/Edit/5
        public ActionResult Edit(int id)
        {
            Speakers speaker = _speakerService.GetSpeakerById(id);

            return View(speaker);
        }

        [Area("Admin")]
        // POST: Speakers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Speakers model)
        {
            if (ModelState.IsValid)
            {
                Speakers existingSpeaker = _speakerService.GetSpeakerById(id);

                TryUpdateModelAsync(existingSpeaker);
                _speakerService.UpdateSpeaker(existingSpeaker);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: Speakers/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. try again, and if problem persists, contact your system administrator.";
            }

            Speakers speakerToDelete = _speakerService.GetSpeakerById(id);

            if (speakerToDelete == null)
            {
                return NotFound();
            }

            return View(speakerToDelete);
        }

        [Area("Admin")]
        // POST: Speakers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Speakers speakerToDelete = _speakerService.GetSpeakerById(id);

                _speakerService.Delete(speakerToDelete);
                _speakerService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}