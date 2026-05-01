
namespace ExcepcionesPropias.ExcepcionesEntidades
{
    public class TipoDeGastoException : Exception
    {
        public TipoDeGastoException()
        {
        }

        public TipoDeGastoException(string? message) : base(message)
        {
        }

        public TipoDeGastoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
