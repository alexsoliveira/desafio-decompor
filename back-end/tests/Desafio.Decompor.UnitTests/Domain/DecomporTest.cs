using Desafio.Decompor.Business.Exceptions;
using FluentAssertions;
using DomainObject = Desafio.Decompor.Business.Domain;

namespace Desafio.Decompor.UnitTests.Domain
{
    [Collection(nameof(DecomporTestFixture))]
    public class DecomporTest
    {
        private readonly DecomporTestFixture _fixture;

        public DecomporTest(DecomporTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(Instancia_ValorParaDecompor))]
        [Trait("Domain", "Decompor - Aggregates")]
        public void Instancia_ValorParaDecompor()
        {
            var decomporValido = _fixture.ObterValorDecomporValido();

            var decompor = new DomainObject.Decompor(decomporValido.Entrada);

            decompor.Should().NotBeNull();
            decompor.Entrada.Should().Be(decomporValido.Entrada);
        }

        [Fact(DisplayName = nameof(Instancia_ValorParaDecompor_Positivo))]
        [Trait("Domain", "Decompor - Aggregates")]
        public void Instancia_ValorParaDecompor_Positivo()
        {            
            var valorEntrada = _fixture.ObterValorParaDecompor();

            var decompor = new DomainObject.Decompor(valorEntrada);

            decompor.Should().NotBeNull();
            decompor.Entrada.Should().Be(valorEntrada);
        }

        [Fact(DisplayName = nameof(EhPositivo_DeveRetornarVerdadeiro_QuandoValorForPositivo))]
        [Trait("Domain", "Decompor - Aggregates")]
        public void EhPositivo_DeveRetornarVerdadeiro_QuandoValorForPositivo()
        {            
            var valorEntrada = _fixture.ObterValorParaDecompor();
            
            var resultado = _fixture.ValorEhPositivo(valorEntrada);

            resultado.Should().BeTrue();            
        }

        [Theory(DisplayName = nameof(ValidarError_QuandoValorDeEntrada_ForNegativoOuZero))]
        [Trait("Domain", "Decompor - Aggregates")]
        [InlineData(-1)]
        [InlineData(-100)]       
        [InlineData(0)]
        public void ValidarError_QuandoValorDeEntrada_ForNegativoOuZero(int valorDeEntrada)
        {
            Action action = () => new DomainObject.Decompor(valorDeEntrada);

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("O campo Entrada, só aceita números inteiros positivos.");
        }

        [Theory(DisplayName = nameof(ValidarError_QuandoValorDeEntrada_ForNegativoOuZero))]
        [Trait("Domain", "Decompor - Aggregates")]
        [InlineData(101)]
        [InlineData(1000)]
        [InlineData(200)]
        public void ValidarError_QuandoValorDeEntrada_ForMaiorQue100(int valorDeEntrada)
        {
            Action action = () => new DomainObject.Decompor(valorDeEntrada);

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("O campo Entrada, só aceita números entre (1 e 100).");
        }
    }
}
