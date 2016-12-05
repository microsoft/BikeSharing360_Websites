using BikeSharing_Private_Web_Site.Configuration;
using BikeSharing_Private_Web_Site.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.Services
{
    public class RideService : IRideService
    {
        private List<Ride> _rides;
        private HttpClient _apiClient;
        private readonly IOptions<ApiSettings> _apiSettings;
        private int _totalItems;
        private const int _defaultSize = 20;

        public int TotalItems {
            get { return _totalItems; }
        }

        public RideService(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public async Task<List<Ride>> GetDataAsync(int from, int? size)
        {
            using (_apiClient = new HttpClient())
            {
                var uri = string.Format("{0}?from={1}&size={2}", _apiSettings.Value.RidesApiUrl, from, size ?? _defaultSize);

                _apiClient.DefaultRequestHeaders.Accept.Clear();
                var response = await _apiClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    _rides = JsonConvert.DeserializeObject<List<Ride>>(responseJson);
                    IEnumerable<string> values;
                    if (response.Headers.TryGetValues("total", out values))
                    {
                        _totalItems = int.Parse(values.FirstOrDefault());
                    }
                }
            }
            return _rides;
        }
    }
}
