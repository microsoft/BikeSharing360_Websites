using BikeSharing_Private_Web_Site.Models;
using BikeSharing_Private_Web_Site.Models.RideViewModels;
using BikeSharing_Private_Web_Site.Services;
using BikeSharing_Private_Web_Site.Services.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.Views.Shared.Components
{
    public class RideList:ViewComponent
    {
        private readonly IRideService _svc;

        public RideList(IRideService svc)
        {
            _svc = svc;
        }

        public async Task<IViewComponentResult> InvokeAsync(IndexViewModel vm)
        {
            var data = await _svc.GetDataAsync(vm.PaginationInfo.ActualPage, vm.PaginationInfo.ItemsPerPage);
            vm.Rides = data ?? new List<Ride>();
            vm.PaginationInfo.TotalItems = _svc.TotalItems;
            decimal d = ((decimal)_svc.TotalItems / vm.PaginationInfo.ItemsPerPage);
            vm.PaginationInfo.TotalPages = d > (int)d ? (int)d + 1 : (int)d;
            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";
            vm.PaginationInfo.ItemsPerPage = vm.Rides.Count();

            return View(vm);
        }
    }
}
