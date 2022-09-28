using GerenciarProjetos.Models.Requests.Projeto;
using GerenciarProjetos.Models.Responses;
using GerenciarProjetos.Models.Responses.Projeto;

namespace GerenciarProjetos.Services.Interfaces
{
    public interface IProjetoService
    {
        DefaultResultResponse Cadastrar(CadastrarProjetoRequest projeto);
        DefaultResultResponse Editar(EditarProjetoRequest projeto);
        DefaultResultResponse Excluir(int idProjeto);
        DetalhesProjetoResponse ObterDetalhes(int idProjeto);
        ProjetosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina);
    }
}
