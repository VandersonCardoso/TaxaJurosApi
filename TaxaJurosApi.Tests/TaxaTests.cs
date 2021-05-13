using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using TaxaJurosApi.Api.Controllers;
using TaxaJurosApi.Core.Interfaces;

namespace TaxaJurosApi.Tests
{
    [TestFixture]
    public class TaxaTests
    {
        private Mock<ITaxaService> mockTaxaService;

        #region Setup
        [SetUp]
        public void Setup()
        {
            mockTaxaService = new Mock<ITaxaService>();
        }
        #endregion

        #region GetTaxaJuros_ModelStateInvalid
        [Test]
        public async Task GetTaxaJuros_ModelStateInvalid()
        {
            TaxaController taxaController = new TaxaController(mockTaxaService.Object);
            taxaController.ModelState.AddModelError("Key", "errorMessage");
            var result = await taxaController.GetTaxaJuros();
            Assert.IsFalse(taxaController.ModelState.IsValid);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
        #endregion

        #region GetTaxaJuros_BadRequest
        [Test]
        public async Task GetTaxaJuros_BadRequest()
        {
            mockTaxaService.Setup(taxa => taxa.ObterTaxaJuros()).ReturnsAsync(decimal.Zero);
            TaxaController taxaController = new TaxaController(mockTaxaService.Object);
            var result = await taxaController.GetTaxaJuros();
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
        #endregion

        #region GetTaxaJuros_Accepted
        [Test]
        public async Task GetTaxaJuros_Accepted()
        {
            mockTaxaService.Setup(taxa => taxa.ObterTaxaJuros()).ReturnsAsync(new decimal(0.01));
            TaxaController taxaController = new TaxaController(mockTaxaService.Object);
            var result = await taxaController.GetTaxaJuros();
            Assert.IsInstanceOf<AcceptedResult>(result);
        }
        #endregion
    }
}