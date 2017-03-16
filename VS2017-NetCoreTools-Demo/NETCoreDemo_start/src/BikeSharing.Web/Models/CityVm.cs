using BikeSharing.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing.Web.Models
{
    public class CityVm
    {
        private readonly City _city;

        public bool Initial => _city.Initial;
        public string Locale => _city.IsAvailable ? (_city.LocalizedName  ?? _city.Name) : "Coming Soon...";

        public string Name => _city.Name;

        public int Index { get; }

        public CityVm(City city, int idx)
        {
            _city = city;
            Index = idx;
        }

    }
}
