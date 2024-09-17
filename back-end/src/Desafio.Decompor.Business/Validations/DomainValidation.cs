using Desafio.Decompor.Business.Exceptions;

namespace Desafio.Decompor.Business.Validations
{
    public static class DomainValidation
    {
        public static void ApenasNumerosInteirosPositivos(int target, string fieldName)
        {
            if (target <= 0)
                throw new EntityValidationException(
                    $"O campo {fieldName}, só aceita números inteiros positivos.");
        }

        public static void ApenasNumerosInteirosEntre_1e100(int target, string fieldName)
        {
            ApenasNumerosInteirosPositivos(target, fieldName);

            if (target > 100)            
                throw new EntityValidationException(
                    $"O campo {fieldName}, só aceita números entre (1 e 100).");
        }
    }
}
