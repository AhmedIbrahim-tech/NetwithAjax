using Core.Interface;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModel;

namespace Web.Controllers
{
    public class PostCityController : Controller
    {
        private readonly IBaseRepository<Country> _country;
        private readonly IBaseRepository<City> _city;
        private readonly IBaseRepository<User> _user;

        public PostCityController(IBaseRepository<Country> country, IBaseRepository<City> city, IBaseRepository<User> user)
        {
            _country = country;
            _city = city;
            _user = user;
        }

        public IActionResult Index()
        {
            CountryCityVM vM = new CountryCityVM
            {
                Countries = _country.List()
            };
            return View(vM);
        }

        [HttpGet]
        public JsonResult GetCities(int CountryId)
        {
            var c = _country.Find(CountryId);
            var cit = _city.ListByFilter(cc => cc.Country == c);
            return Json(new SelectList(cit, "Id", "Name"));
        }

        [HttpPost]
        public JsonResult AddUser(string username, int cid)
        {
            var cityid = _city.Find(cid);
            var usname = new User
            {
                City = cityid,
                Name = username,
            };
            _user.Add(usname);
            return Json(username);
        }
    }
}