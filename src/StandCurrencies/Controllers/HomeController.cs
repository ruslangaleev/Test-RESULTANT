using Microsoft.AspNetCore.Mvc;
using StandCurrencies.ResourceModels;
using StandCurrencies.Services.Interfaces;
using StandCurrencies.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<object> GetData()
        {
            List<DataModel> dataModels = new List<DataModel>();

            ResponseModel result = null;

            try
            {
                result = await _phisixClient.GetData();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Не удалось получить данные с сервера");
            }

            foreach (var entry in result.stock)
            {
                dataModels.Add(new DataModel
                {
                    Name = entry.name,
                    Amount = entry.price.amount,
                    Volume = entry.volume
                });
            }

            return dataModels.ToArray();
        }
    }
}
