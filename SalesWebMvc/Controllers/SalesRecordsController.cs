using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using SalesWebMvc.Services;


namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecodService _salesRecodService;

        public SalesRecordsController(SalesRecodService salesRecodService)
        {
            _salesRecodService = salesRecodService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate,DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecodService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecodService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
