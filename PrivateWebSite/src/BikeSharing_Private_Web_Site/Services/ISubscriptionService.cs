using BikeSharing_Private_Web_Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.Services
{
    public interface ISubscriptionService
    {
        int TotalItems { get; }
        Task<List<Subscription>> GetDataAsync(int from, int? size);
    }
}
