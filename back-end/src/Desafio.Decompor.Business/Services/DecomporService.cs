using Desafio.Decompor.Business.Exceptions;
using Desafio.Decompor.Business.Interfaces;
using Desafio.Decompor.Business.Validations;

namespace Desafio.Decompor.Business.Services
{
    public class DecomporService : IDecomporService
    {
        public async Task<IEnumerable<int>> ObterListaDivisoresPrimos(int valorEntrada)
        {
            List<int> divisores = new List<int>();

            ValidarValorEntrada(valorEntrada);


            for (int i = 1; i <= valorEntrada; i++)
            {
                if (valorEntrada % i == 0)
                {
                    divisores.Add(i);
                }
            }

            return divisores;
        }

        public async Task<IEnumerable<int>> ObterListaNumerosDivisores(int valorEntrada)
        {
            List<int> divisoresPrimos = new List<int>();

            ValidarValorEntrada(valorEntrada);

            for (int i = 2; i <= valorEntrada; i++)
            {
                if (valorEntrada % i == 0 && EhNumeroPrimo(i))
                {
                    divisoresPrimos.Add(i);
                }
            }

            return divisoresPrimos;
        }

        private static void ValidarValorEntrada(int valorEntrada)
        {
            DomainValidation.ApenasNumerosInteirosPositivos(valorEntrada, nameof(valorEntrada));
            DomainValidation.ApenasNumerosInteirosEntre_1e100(valorEntrada, nameof(valorEntrada));
        }

        private static bool EhNumeroPrimo(int numero)
        {
            if (numero <= 1) return false;

            for (int i = 2; i * i <= numero; i++)
            {
                if (numero % i == 0)
                    return false;
            }

            return true;
        }
    }
}
