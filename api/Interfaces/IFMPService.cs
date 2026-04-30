using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IFMPService
    {
        Task<Stock?> FindStockBySymbolAsync(string symbol);
    }
}