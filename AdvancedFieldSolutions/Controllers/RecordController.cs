using Data.Business.Abstract;
using Data.Business.Concrete;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedFieldSolutions.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordsService _recordsService;
        public RecordController()
        {
            _recordsService = new RecordManager();
        }
        public IActionResult Index()
        {
            var list = _recordsService.GetCallReports();
            return View(list ?? new List<CallReport>());
        }
    }
}
