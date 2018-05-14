using StandCurrencies.ResourceModels;
using System.Threading.Tasks;

namespace StandCurrencies.Services.Interfaces
{
    /// <summary>
    /// Клиент сервера http://phisix-api3.appspot.com
    /// </summary>
    public interface IPhisixClient
    {
        /// <summary>
        /// Возвращает список валют
        /// </summary>
        Task<ResponseModel> GetData();
    }
}
