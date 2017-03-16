using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing.Web.Data
{
    public class CitiesService : ICitiesService
    {
        private readonly BikeSharingContext _db;
        public CitiesService(BikeSharingContext ctx)
        {
            _db = ctx;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _db.Cities.ToListAsync();
        }
    }
}
