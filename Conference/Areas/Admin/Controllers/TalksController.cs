using System.Collections.Generic;
using System.Data;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Areas.Admin.Controllers
{
    public class TalksController : Controller
    {
        private readonly ITalkService _talkService;

        public TalksController(ITalkService talkService)
        {
            _talkService = talkService;
        }

        [Area("Admin")]
        // GET: Talks
        public ActionResult Index()
        {
            IEnumerable<Talks> allTalks = _talkService.GetAllTalks();
            return View(allTalks);
        }

        [Area("Admin")]
        // GET: Talks/Details/5
        public ActionResult Details(int id)
        {
            Talks talk = _talkService.GetTalkById(id);
            return View(talk);
        }

        [Area("Admin")]
        // GET: Talks/Create
        public ActionResult Create()
        {
            return View();
        }

        [Area("Admin")]
        // POST: Talks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Talks model)
        {
            if (ModelState.IsValid)
            {
                Talks addedTalk = _talkService.AddTalk(model);

                if (addedTalk == null)
                {
                    ModelState.AddModelError("Name", "Talks name must be unique!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: Talks/Edit/5
        public ActionResult Edit(int id)
        {
            Talks talk = _talkService.GetTalkById(id);

            return View(talk);
        }

        [Area("Admin")]
        // POST: Talks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Talks model)
        {
            if (ModelState.IsValid)
            {
                Talks existingTalk = _talkService.GetTalkById(id);

                TryUpdateModelAsync(existingTalk);
                _talkService.UpdateTalk(existingTalk);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Area("Admin")]
        // GET: Talks/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. try again, and if problem persists, contact your system administrator.";
            }

            Talks talkToDelete = _talkService.GetTalkById(id);

            if (talkToDelete == null)
            {
                return NotFound();

            }

            return View(talkToDelete);
        }

        [Area("Admin")]
        // POST: Talks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Talks talkToDelete = _talkService.GetTalkById(id);

                _talkService.Delete(talkToDelete);
                _talkService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}