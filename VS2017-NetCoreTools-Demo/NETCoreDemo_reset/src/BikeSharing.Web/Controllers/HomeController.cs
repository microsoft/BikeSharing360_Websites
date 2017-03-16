using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using BikeSharing.Web.Configuration;
using BikeSharing.Web.Data;
using BikeSharing.Web.Models;

namespace BikeSharing.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<Links> _links;
        private readonly ICitiesService _citesSvc;

        public HomeController (IOptions<Links> links, ICitiesService citiesSvc)
        {
            _links = links;
            _citesSvc = citiesSvc;
        }
        public async Task<IActionResult> Index()
        {
            var cities = await _citesSvc.GetAllCities();
            
            var model = cities.Select((c, idx) => new CityVm(c, idx + 1)).ToList();
            ViewBag.PrivateWebsite = _links.Value.PrivateWebsite;
            return View(model);
        }
    }
}
