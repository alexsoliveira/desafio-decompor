using DomainObject = Desafio.Decompor.Business.Domain;

namespace Desafio.Decompor.IntegrationTests.Services
{
    [CollectionDefinition(nameof(DecomporServiceTestFixture))]
    public class DecomporServiceTestFixtureCollection
       : ICollectionFixture<DecomporServiceTestFixture>
    { }

    public class DecomporServiceTestFixture
    {
        public bool ValorEhPositivo(int valor)
        {
            if (valor <= 0)
                return false;

            return true;
        }

        public int ObterValorParaDecompor()
        {
            var valor = 0;

            // valor de 1 a 100 positivos.
            valor = new Random().Next(1, 100);

            return valor;
        }

        public DomainObject.Decompor ObterValorDecomporValido()
            => new(
                ObterValorParaDecompor()
            );
    }
}
