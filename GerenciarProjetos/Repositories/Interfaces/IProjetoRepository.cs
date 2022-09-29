using GerenciarProjetos.Models.Requests.Projeto;
using GerenciarProjetos.Models.Responses.Projeto;

namespace GerenciarProjetos.Repositories.Interfaces
{
    public interface IProjetoRepository
    {
        void Cadastrar(CadastrarProjetoRequest projeto);
        void Editar(EditarProjetoRequest projeto);
        void Excluir(int idProjeto);
        DetalhesProjetoResponse ObterDetalhes(int idProjeto);
        ProjetosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina);
    }
}
