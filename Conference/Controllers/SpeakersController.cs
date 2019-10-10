using System.Collections.Generic;
using Conference.Domain.Entities;
using Conference.Interfaces;
using Conference.Models;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly ISpeakerService _speakerService;
        private readonly ISpeakerAppService _speakerAppService;

        public SpeakersController(ISpeakerService speakerService, ISpeakerAppService speakerAppService)
        {
            _speakerService = speakerService;
            _speakerAppService = speakerAppService;
        }

        public ActionResult Index()
        {
            IList<SpeakerListItemViewModel> viewModel = _speakerAppService.GetSpeakerListViewModel(Url);

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            Speakers speaker = _speakerService.GetSpeakerById(id);

            if (speaker == null)
            {
                return RedirectToAction("NotFoundPage", "Home" );
            }

            SpeakerListItemViewModel viewModel = _speakerAppService.GetSpeakerListItemViewModel(Url, speaker);

            return View(viewModel);
        }
    }
}