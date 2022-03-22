using Core.Interface;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Web.Models;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBaseRepository<Country> country;
        private readonly IBaseRepository<City> city;

        public HomeController(ILogger<HomeController> logger, IBaseRepository<Country> country, IBaseRepository<City> city)
        {
            _logger = logger;
            this.country = country;
            this.city = city;
        }

        public IActionResult Index()
        {
            CountryCityVM vM = new CountryCityVM
            {
                Countries = country.List(),
            };
            return View(vM);
        }

        [HttpGet]
        public JsonResult GetCities(int CountryId)
        {
            var c = country.Find(CountryId);
            var cit = city.ListByFilter(cc => cc.Country == c);
            return Json(new SelectList(cit, "Id", "Name"));
        }

        public IActionResult Privacy()
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