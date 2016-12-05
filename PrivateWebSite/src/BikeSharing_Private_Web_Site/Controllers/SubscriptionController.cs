using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeSharing_Private_Web_Site.Services;
using Microsoft.Extensions.Options;
using BikeSharing_Private_Web_Site.Configuration;
using BikeSharing_Private_Web_Site.Services.Pagination;
using Microsoft.AspNetCore.Authorization;

namespace BikeSharing_Private_Web_Site.Controllers
{
    [Authorize]
    public class SubscriptionController : Controller
    {

        public IActionResult Index(int page)
        {

            var vm = new Models.SubscriptionViewModels.IndexViewModel()
            {
                PaginationInfo = new PaginationInfo()
                {
                    ActualPage = page,
                    ItemsPerPage = 20
                }
            };

            return View(vm);
        }
    }
}