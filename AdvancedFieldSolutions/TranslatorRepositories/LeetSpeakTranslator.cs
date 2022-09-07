using AdvancedFieldSolutions.Models;
using Data.Business.Abstract;
using Data.Business.Concrete;
using Data.Entities;
using Newtonsoft.Json;

namespace AdvancedFieldSolutions.TranslatorRepositories
{
    public class LeetSpeakTranslator : TranslatorProvider

    {
        private string url = "https://api.funtranslations.com/translate/brooklyn.json";
        private readonly IRecordsService _recordsService = new RecordManager();

        public override async Task<bool> CallClientAsync(string text)
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
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
