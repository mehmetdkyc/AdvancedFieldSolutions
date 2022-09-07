using AdvancedFieldSolutions.Models;
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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                //HTTP POST
                HttpResponseMessage Res = await client.GetAsync("?text=" + text);
                if (Res.IsSuccessStatusCode)
                {
                    var record = Res.Content.ReadAsStringAsync().Result;
                    var detailsReturn = JsonConvert.DeserializeObject<ReportsModel>(record);

                    CallReport callReport = new CallReport()
                    {
                        Text = detailsReturn.contents.text ?? "",
                        Translated = detailsReturn.contents.translated ?? "",
                        Translation = detailsReturn.contents.translation ?? "",
                        Total = detailsReturn.success.total
                    };
                    _recordsService.AddCallReport(callReport);
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }

            }

        }
    }
}