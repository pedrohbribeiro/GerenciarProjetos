using System.Net;

namespace GerenciarProjetos.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message) { }
        public override HttpStatusCode StatusCode { get => HttpStatusCode.BadRequest; }
    }
}
