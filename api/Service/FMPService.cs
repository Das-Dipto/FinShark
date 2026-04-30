using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using api.Interfaces;
using api.Models;
using Newtonsoft.Json;

namespace api.Services
{
    public class FMPService : IFMPService
    {
        private readonly HttpClient _httpClient;

        public FMPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Stock?> FindStockBySymbolAsync(string symbol)
        {
            var url = $"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey=YOUR_API_KEY";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();

            var stocks = JsonConvert.DeserializeObject<List<Stock>>(content);

            return stocks?.FirstOrDefault();
        }
    }
}