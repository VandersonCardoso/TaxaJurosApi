using System.Threading.Tasks;
using TaxaJurosApi.Core.Interfaces;

namespace TaxaJurosApi.Services
{
    public class TaxaService : ITaxaService
    {
        #region ObterTaxaJuros
        public async Task<decimal> ObterTaxaJuros()
        {
            return new decimal(0.01);
        }
        #endregion
    }
}
