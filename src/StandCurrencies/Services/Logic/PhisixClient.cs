using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StandCurrencies.ResourceModels;
using StandCurrencies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StandCurrencies.Services.Logic
{
    /// <summary>
    /// Клиент сервера http://phisix-api3.appspot.com
    /// </summary>
    public class PhisixClient : IPhisixClient
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public PhisixClient()
        {
            _httpClient.BaseAddress = new Uri("http://phisix-api3.appspot.com");
        }

        public const string _url = "http://phisix-api3.appspot.com/stocks.json";

        public async Task<ResponseModel> GetData()
        {
            var response = await _httpClient.GetStringAsync("stocks.json");
            return JsonConvert.DeserializeObject<ResponseModel>(response);
        }
    }
}
