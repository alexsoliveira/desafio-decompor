using Desafio.Decompor.Business.Interfaces;
using Desafio.Decompor.Business.Services;
using FluentAssertions;

namespace Desafio.Decompor.IntegrationTests.Services
{
    [Collection(nameof(DecomporServiceTestFixture))]
    public class DecomporServiceTest
    {
        private readonly DecomporServiceTestFixture _fixture;

        public DecomporServiceTest(DecomporServiceTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(CalcularNumerosDivisores))]
        [Trait("Service", "Decompor - Service")]        
        public void CalcularNumerosDivisores()
        {
            var decompor = _fixture.ObterValorDecomporValido();
            IDecomporService decomporService = new DecomporService();           

            var valorFinal = decomporService.ObterListaNumerosDivisores(decompor);

            valorFinal.Should().NotBeNull();            
        }

        [Fact(DisplayName = nameof(CalcularDivisoresPrimos))]
        [Trait("Service", "Decompor - Service")]        
        public void CalcularDivisoresPrimos()
        {
            var decompor = _fixture.ObterValorDecomporValido();
            IDecomporService decomporService = new DecomporService();

            var valorFinal = decomporService.ObterListaDivisoresPrimos(decompor);

            valorFinal.Should().NotBeNull();
        } 
    }
}
