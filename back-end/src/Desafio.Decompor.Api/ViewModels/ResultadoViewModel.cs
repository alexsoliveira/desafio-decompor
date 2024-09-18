namespace Desafio.Decompor.Api.ViewModels
{
    public class ResultadoViewModel
    {
        public IEnumerable<int> NumerosDivisores { get; private set; }
        public IEnumerable<int> DivisoresPrimos { get; private set; }

        public ResultadoViewModel(IEnumerable<int> numerosDivisores, IEnumerable<int> divisoresPrimos)
        {
            NumerosDivisores = numerosDivisores;
            DivisoresPrimos = divisoresPrimos;
        }
    }
}
