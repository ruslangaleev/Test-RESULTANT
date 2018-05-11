using Microsoft.AspNetCore.Mvc;
using StandCurrencies.Services.Interfaces;
using System;
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
        public async Task<object> GetLastData(int count = 50)
        {
            return await _phisixClient.GetLastData();
        }
    }
}
