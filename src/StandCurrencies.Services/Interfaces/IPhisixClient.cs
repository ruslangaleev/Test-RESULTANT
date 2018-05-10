using StandCurrencies.Services.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StandCurrencies.Services.Interfaces
{
    public interface IPhisixClient
    {
        Task<IEnumerable<DataModel>> GetLastData();
    }
}
