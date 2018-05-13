using Microsoft.AspNetCore.Mvc;
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
        private readonly IPhisixClient _phisixClient;

        public HomeController(IPhisixClient phisixClient)
        {
            _phisixClient = phisixClient ?? throw new ArgumentNullException(nameof(IPhisixClient));
        }

        [HttpGet]
        public async Task<DataModel[]> GetData()
        {
            List<DataModel> dataModels = new List<DataModel>();

            var result = await _phisixClient.GetData();
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
