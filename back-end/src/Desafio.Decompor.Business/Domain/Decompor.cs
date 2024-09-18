using Desafio.Decompor.Business.Validations;

namespace Desafio.Decompor.Business.Domain
{
    public class Decompor
    {
        public int Entrada { get; private set; }

        public Decompor(int entrada) 
        {
            Entrada = entrada;

            Validar();
        }        

        private void Validar()
        {
            DomainValidation.ApenasNumerosInteirosPositivos(Entrada, nameof(Entrada));
            DomainValidation.ApenasNumerosInteirosEntre_1e100(Entrada, nameof(Entrada));
            DomainValidation.NotNullOuZero(Entrada, nameof(Entrada));
        }
    }
}
