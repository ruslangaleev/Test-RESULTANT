using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using StandCurrencies.Services.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StandCurrencies.Services.Logic
{
    /// <summary>
    /// Напоминание
    /// </summary>
    public class Reminder
    {
        private readonly IHubContext<SignalServer> _hubContext;

        /// <summary>
        /// Время опроса
        /// </summary>
        private readonly int _pollingTime;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Reminder(IHubContext<SignalServer> hubContext,
            IConfiguration configuration)
        {
            var pollingTime = configuration["Phisix:PollingTime"];
            if (!int.TryParse(pollingTime, out _pollingTime))
            {
                throw new ArgumentNullException("Ошибка чтение конфига Phisix:PollingTime");
            }

            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(IHubContext<SignalServer>));
        }

        /// <summary>
        /// Запуск напоминания
        /// </summary>
        public async Task Start()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    _hubContext.Clients.All.SendAsync("displayNotification");

                    Thread.Sleep(_pollingTime);
                }
            });
        }
    }
}
