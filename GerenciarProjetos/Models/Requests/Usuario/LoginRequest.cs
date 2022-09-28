using FluentValidation;

namespace GerenciarProjetos.Models.Requests.Usuario
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
