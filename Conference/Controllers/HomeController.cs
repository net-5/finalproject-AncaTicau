using System.Collections.Generic;
using System.Diagnostics;
using Conference.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Conference.Models;

namespace Conference.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpeakerAppService _speakerAppService;

        public HomeController(ISpeakerAppService speakerAppService)
        {
            _speakerAppService = speakerAppService;
        }

        public IActionResult Index()
        {
            IList<SpeakerListItemViewModel> viewModel = _speakerAppService.GetSpeakerListViewModel(Url);

            return View(viewModel);
        }

        public IActionResult NotFoundPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}