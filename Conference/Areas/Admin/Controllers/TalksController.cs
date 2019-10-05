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

namespace Conference.Areas.Admin.Controllers
{
    public class TalksController : Controller
    {
        private readonly ITalkService talkService;
        public TalksController(ITalkService talkService)
        {
            this.talkService = talkService;
        }

        [Area("Admin")]
        // GET: Talks
        public ActionResult Index()
        {
            var allTalks = talkService.GetAllTalks();
            return View(allTalks);
        }

        [Area("Admin")]
        // GET: Talks/Details/5
        public ActionResult Details(int id)
        {
            Talks talk = talkService.GetTalkById(id);
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
                var addedTalk = talkService.AddTalk(model);
                if (addedTalk == null)
                {
                    ModelState.AddModelError("Name", "Talks name must be unique!");
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
        // GET: Talks/Edit/5
        public ActionResult Edit(int id)
        {
            var talk = talkService.GetTalkById(id);
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
                var existingTalk = talkService.GetTalkById(id);
                TryUpdateModelAsync(existingTalk);
                talkService.UpdateTalk(existingTalk);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [Area("Admin")]
        // GET: Talks/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. try again, and if problem persists, contact your system administrator.";
            }
            Talks talkToDelete = talkService.GetTalkById(id);
            if (talkToDelete == null)
            {
                return NotFound();

            }
            else
            {
                return View(talkToDelete);
            }
        }

        [Area("Admin")]
        // POST: Talks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Talks talkToDelete = talkService.GetTalkById(id);
                talkService.Delete(talkToDelete);
                talkService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}