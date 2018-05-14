using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StandCurrencies.ResourceModels;
using StandCurrencies.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StandCurrencies.Services.Logic
{
    /// <summary>
    /// Клиент сервера http://phisix-api3.appspot.com
    /// </summary>
    public class PhisixClient : IPhisixClient
    {
        /// <summary>
        /// HTTP клиент сервера http://phisix-api3.appspot.com
        /// </summary>
        private readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Конструктор
        /// </summary>
        public PhisixClient(IConfiguration configuration)
        {
            var baseUrl = configuration["Phisix:BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("Ошибка чтение конфига Phisix:Url");
            }
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        /// <summary>
        /// Возвращает список валют
        /// </summary>
        public async Task<ResponseModel> GetData()
        {
            var response = await _httpClient.GetStringAsync("stocks.json");
            return JsonConvert.DeserializeObject<ResponseModel>(response);
        }
    }
}
