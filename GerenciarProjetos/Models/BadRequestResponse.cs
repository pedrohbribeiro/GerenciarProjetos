using GerenciarProjetos.Models.Responses;

namespace GerenciarProjetos.Models
{
    public class BadRequestResponse : ErrorResponse
    {
        public BadRequestResponse()
        {
            Sucesso = false;
        }

        public List<ErrorsValidation> Errors { get; set; }
    }

    public class ErrorsValidation
    {
        public string Property { get; set; }
        public string Erro { get; set; }
    }
}
