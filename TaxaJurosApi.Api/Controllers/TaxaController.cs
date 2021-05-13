using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TaxaJurosApi.Core.Interfaces;

namespace TaxaJurosApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaController : ControllerBase
    {
        private readonly ITaxaService _taxaService;

        #region TaxaController
        public TaxaController(ITaxaService taxaService)
        {
            _taxaService = taxaService;
        }
        #endregion

        #region GetTaxaJuros
        /// <summary alignment="right">
        /// Endpoint da taxa de juros
        /// </summary>
        /// <remarks>
        /// Este endpoint tem como objetivo retornar a taxa de juros.
        /// </remarks>
        /// <returns>Códigos de retorno para o endpoint taxaJuros</returns>
        /// <response code="202">Código de retorno caso o endpoint obtenha a taxa de juros corretamente.</response>
        /// <response code="400">Código de retorno caso o conteúdo da requisição esteja divergente da especificação ou em caso de erro ao obter a taxa de juros.</response>
        [HttpGet("/taxaJuros")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTaxaJuros()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _taxaService.ObterTaxaJuros();

            if (response > 0)
            {
                return Accepted(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        #endregion
    }
}
