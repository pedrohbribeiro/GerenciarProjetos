using GerenciarProjetos.Models.DbResults;
using GerenciarProjetos.Models.Requests.Usuario;

namespace GerenciarProjetos.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(CadastrarRequest request);
        UsuarioAuthResult ObterUsuarioParaAutenticacaoPorEmail(string email);
        UsuarioAuthResult ObterUsuarioParaAutenticacaoPorRefreshToken(string refreshToken);
        void SalvarRefreshToken(int idUsuario, string refreshToken);
    }
}
