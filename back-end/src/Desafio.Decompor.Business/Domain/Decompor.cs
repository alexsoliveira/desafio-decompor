using Desafio.Decompor.Business.Validations;

namespace Desafio.Decompor.Business.Domain
{
    public class Decompor
    {
        public int ValorDeEntrada { get; private set; }

        public Decompor(int valorDeEntrada) 
        {
            ValorDeEntrada = valorDeEntrada;

            Validar();
        }

        private void Validar()
        {
            DomainValidation.ApenasNumerosInteirosPositivos(ValorDeEntrada, nameof(ValorDeEntrada));
            DomainValidation.ApenasNumerosInteirosEntre_1e100(ValorDeEntrada, nameof(ValorDeEntrada));
            DomainValidation.NotNullOuZero(ValorDeEntrada, nameof(ValorDeEntrada));
        }
    }
}
