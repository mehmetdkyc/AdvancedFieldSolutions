using AdvancedFieldSolutions.Models;
using AdvancedFieldSolutions.TranslatorRepositories;
using Data.Business.Abstract;
using Data.Business.Concrete;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdvancedFieldSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecordsService _recordsService;
        private readonly ILogger<HomeController> _logger;
        private string url = "https://api.funtranslations.com/translate/brooklyn.json";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _recordsService = new RecordManager();
        }

        public IActionResult Index()
        {
            return View();
        }
 
        [HttpPost]
        public async Task<JsonResult> CallTranslatedAPI(string text)
        {
            TranslatorProvider translatorProvider = new LeetSpeakTranslator(); // when we add new translator we just change the new ...Translator() and also add override the method.
            var boolReturn = await translatorProvider.CallClientAsync(text);
            return Json(boolReturn);

        }
    }
}