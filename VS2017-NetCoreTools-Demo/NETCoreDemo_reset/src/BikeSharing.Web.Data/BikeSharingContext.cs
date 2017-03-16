using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing.Web.Data
{
    public class BikeSharingContext : DbContext
    {
        public BikeSharingContext(DbContextOptions<BikeSharingContext> options) : base(options)
        {    
        }
        

        public DbSet<City> Cities { get; set; }
    }
}
