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

namespace Conference.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly ISpeakerService speakerService;
        public SpeakersController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }

        // GET: Speakers
        public ActionResult Index()
        {
            var allSpeakers = speakerService.GetAllSpeakers();
            return View(allSpeakers);
        }

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
    }
}