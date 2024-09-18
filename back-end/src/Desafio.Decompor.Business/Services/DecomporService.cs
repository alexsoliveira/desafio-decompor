using Desafio.Decompor.Business.Interfaces;
using DomainObject = Desafio.Decompor.Business.Domain;

namespace Desafio.Decompor.Business.Services
{
    public class DecomporService : IDecomporService
    {
        public IEnumerable<int> ObterListaNumerosDivisores(DomainObject.Decompor decompor)
        {
            List<int> divisores = new List<int>();            

            for (int i = 1; i <= decompor.Entrada; i++)
            {
                if (decompor.Entrada % i == 0)
                {
                    divisores.Add(i);
                }
            }

            return divisores;
        }

        public IEnumerable<int> ObterListaDivisoresPrimos(DomainObject.Decompor decompor)
        {
            List<int> divisoresPrimos = new List<int>();

            divisoresPrimos.Add(1);

            for (int i = 2; i <= decompor.Entrada; i++)
            {
                if (decompor.Entrada % i == 0 && EhNumeroPrimo(i))
                {
                    divisoresPrimos.Add(i);
                }
            }

            return divisoresPrimos;
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
