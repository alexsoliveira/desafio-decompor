using Desafio.Decompor.Business.Exceptions;
using Desafio.Decompor.Business.Validations;
using FluentAssertions;

namespace Desafio.Decompor.UnitTests.Validations
{
    public class DomainValidationTest
    {        

        [Theory(DisplayName = nameof(ApenasNumerosInteirosPositivos))]
        [Trait("Domain", "DomainValidation - Validation")]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(0)]
        public void ApenasNumerosInteirosPositivos(int valorDeEntrada)
        {
            Action action =
                () => DomainValidation.ApenasNumerosInteirosPositivos(valorDeEntrada, "ValorDeEntrada");

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("O campo ValorDeEntrada, só aceita números inteiros positivos.");
        }

        [Theory(DisplayName = nameof(ApenasNumerosInteirosEntre_1e100))]
        [Trait("Domain", "DomainValidation - Validation")]
        [InlineData(101)]
        [InlineData(1000)]
        [InlineData(200)]
        public void ApenasNumerosInteirosEntre_1e100(int valorDeEntrada)
        {
            Action action =
                () => DomainValidation.ApenasNumerosInteirosEntre_1e100(valorDeEntrada, "ValorDeEntrada");

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("O campo ValorDeEntrada, só aceita números entre (1 e 100).");
        }      

        [Theory(DisplayName = nameof(ErrorQuandoFor_NotNuloOuZero))]
        [Trait("Domain", "DomainValidation - Validation")]
        [InlineData(0)]        
        [InlineData(null)]
        public void ErrorQuandoFor_NotNuloOuZero(int? valorDeEntrada)
        {            
            Action action =
                () => DomainValidation.NotNullOuZero(valorDeEntrada,"ValorDeEntrada");

            action
                .Should()
                .Throw<EntityValidationException>()
                .WithMessage("O campo ValorDeEntrada, não pode ser zero ou nulo.");
        }
    }
}