namespace GerenciarProjetos.Models.Responses
{
    public class ErrorResponse : DefaultResultResponse
    {
        public ErrorResponse()
        {
            Sucesso = false;
        }
    }
}
