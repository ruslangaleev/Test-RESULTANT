using StandCurrencies.ResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandCurrencies.Services.Interfaces
{
    /// <summary>
    /// Клиент сервера http://phisix-api3.appspot.com
    /// </summary>
    public interface IPhisixClient
    {
        Task<ResponseModel> GetData();
    }
}
