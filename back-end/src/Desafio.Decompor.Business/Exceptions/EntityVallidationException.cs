namespace Desafio.Decompor.Business.Exceptions
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException(string? message) : base(message)
        {
        }
    }
}
