using System.Net;

namespace GerenciarProjetos.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException(string message) : base(message) { }

        public abstract HttpStatusCode StatusCode { get; }
    }
}
