using System.Net;

namespace GerenciarProjetos.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(string message) : base(message) { }
        public override HttpStatusCode StatusCode { get => HttpStatusCode.Unauthorized; }
    }
}
