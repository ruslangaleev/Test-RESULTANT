using Microsoft.AspNetCore.SignalR;
using StandCurrencies.Services.Infrastructure;
using StandCurrencies.Services.Interfaces;
using StandCurrencies.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StandCurrencies.Services.Logic
{
    public class Reminder
    {
        
        private readonly IHubContext<SignalServer> _hubContext;

        public Reminder(
            IHubContext<SignalServer> hubContext)
        {
            
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(IHubContext<SignalServer>));
        }

        public async Task Start()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    _hubContext.Clients.All.SendAsync("displayNotification");

                    Thread.Sleep(15000);
                }
            });
        }
    }
}
