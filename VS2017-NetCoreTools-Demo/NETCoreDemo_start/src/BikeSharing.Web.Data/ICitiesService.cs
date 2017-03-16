using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeSharing.Web.Data
{
    public interface ICitiesService
    {
        Task<IEnumerable<City>> GetAllCities();
    }
}