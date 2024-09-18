namespace Desafio.Decompor.Business.Interfaces
{
    public interface IDecomporService
    {
        Task<IEnumerable<int>> ObterListaNumerosDivisores(int valorEntrada);
        Task<IEnumerable<int>> ObterListaDivisoresPrimos(int valorEntrada);
    }
}
