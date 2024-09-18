using DomainObject = Desafio.Decompor.Business.Domain;

namespace Desafio.Decompor.Business.Interfaces
{
    public interface IDecomporService
    {
        IEnumerable<int> ObterListaNumerosDivisores(DomainObject.Decompor valorEntrada);
        IEnumerable<int> ObterListaDivisoresPrimos(DomainObject.Decompor valorEntrada);        
    }
}
