using BikeSharing_Private_Web_Site.Configuration;
using BikeSharing_Private_Web_Site.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private List<Subscription> _subscriptions;
        private HttpClient _apiClient;
        private readonly IOptions<ApiSettings> _apiSettings;
        private int _totalItems;
        private const int _defaultSize = 20;

        public int TotalItems
        {
            get { return _totalItems; }
        }

        public SubscriptionService(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public async Task<List<Subscription>> GetDataAsync(int from, int? size)
        {
            using (_apiClient = new HttpClient())
            {
                var uri = string.Format("{0}?from={1}&size={2}", _apiSettings.Value.SubscriptionApiUrl, from, size ?? _defaultSize);

                _apiClient.DefaultRequestHeaders.Accept.Clear();
                var response = await _apiClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    _subscriptions = JsonConvert.DeserializeObject<List<Subscription>>(responseJson);
                    IEnumerable<string> values;
                    if (response.Headers.TryGetValues("total", out values))
                    {
                        _totalItems = int.Parse(values.FirstOrDefault());
                    }
                }
            }
            return _subscriptions;
        }
    }
}
