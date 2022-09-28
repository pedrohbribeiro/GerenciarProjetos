namespace GerenciarProjetos.Models.Responses.Usuario
{
    public class AuthResponse : DefaultResultResponse
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
