using GerenciarProjetos.Models.Requests.Usuario;
using GerenciarProjetos.Models.Responses;
using GerenciarProjetos.Models.Responses.Usuario;

namespace GerenciarProjetos.Services.Interfaces
{
    public interface IUsuarioService
    {
        DefaultResultResponse Cadastrar(CadastrarRequest request);
        AuthResponse GerarJwtTokenPorRefreshToken(string refreshToken);
        AuthResponse Login(LoginRequest request);
    }
}
