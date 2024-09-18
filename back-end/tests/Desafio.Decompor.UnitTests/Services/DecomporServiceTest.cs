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
        public async void CalcularNumerosDivisores()
        {
            var decompor = _fixture.ObterValorDecomporValido();
            IDecomporService decomporService = new DecomporService();           

            var valorFinal = await decomporService.ObterListaNumerosDivisores(decompor.ValorDeEntrada);

            valorFinal.Should().NotBeNull();            
        }

        [Fact(DisplayName = nameof(CalcularDivisoresPrimos))]
        [Trait("Service", "Decompor - Service")]        
        public async void CalcularDivisoresPrimos()
        {
            var decompor = _fixture.ObterValorDecomporValido();
            IDecomporService decomporService = new DecomporService();

            var valorFinal = await decomporService.ObterListaDivisoresPrimos(decompor.ValorDeEntrada);

            valorFinal.Should().NotBeNull();
        } 
    }
}
