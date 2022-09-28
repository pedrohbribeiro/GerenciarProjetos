using GerenciarProjetos.Models.DbResults;

namespace GerenciarProjetos.Helpers.Interface
{
    public interface IAuthHelper
    {
        string CriarJwtToken(UsuarioAuthResult user);
        string CriarRefreshToken();
    }
}
