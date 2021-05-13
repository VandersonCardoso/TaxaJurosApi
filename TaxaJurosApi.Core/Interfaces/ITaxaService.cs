using System.Threading.Tasks;

namespace TaxaJurosApi.Core.Interfaces
{
    public interface ITaxaService
    {
        Task<decimal> ObterTaxaJuros();
    }
}
