using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StandCurrencies.ResourceModels;
using StandCurrencies.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandCurrencies.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        private readonly IHubContext<SignalServer> _hubContext;

        public HomeController(IHubContext<SignalServer> hubContext)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(IHubContext<SignalServer>));
        }

        [HttpGet]
        public PhisixEntry[] GetData()
        {
            var list = new List<PhisixEntry>
            {
                new PhisixEntry
                {
                    name = "Первая запись",
                    amount = 10,
                    valume = 10
                },
                new PhisixEntry
                {
                    name = "Вторая запись",
                    amount = 20,
                    valume = 20
                }
            };

            return list.ToArray();
        }

        [HttpPost]
        public void Start()
        {
            _hubContext.Clients.All.SendAsync("displayNotification");
        }
    }
}
