using System.Threading.Tasks;

namespace StandCurrencies.Services.Interfaces
{
    /// <summary>
    /// Напоминание
    /// </summary>
    public interface IReminder
    {
        /// <summary>
        /// Запуск напоминания
        /// </summary>
        Task Start();
    }
}
