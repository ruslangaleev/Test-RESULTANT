using Microsoft.AspNetCore.Mvc;
using StandCurrencies.Services.Interfaces;
using StandCurrencies.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace StandCurrencies.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Клиент сервера phisix
        /// </summary>
        private readonly IPhisixClient _phisixClient;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="phisixClient"></param>
        public HomeController(IPhisixClient phisixClient)
        {
            _phisixClient = phisixClient ?? throw new ArgumentNullException(nameof(IPhisixClient));
        }

        /// <summary>
        /// Возвращает список валют
        /// </summary>
        [HttpGet]
        public async Task<DataModel[]> GetData()
        {
            List<DataModel> dataModels = new List<DataModel>();

            var result = await _phisixClient.GetData();

            // TODO: will add pagination?
            foreach (var entry in result.stock.Take(50))
            {
                dataModels.Add(new DataModel
                {
                    Name = entry.name,
                    Amount = entry.price.amount.ToString("0.00"),
                    Volume = entry.volume
                });
            }

            return dataModels.ToArray();
        }
    }
}
