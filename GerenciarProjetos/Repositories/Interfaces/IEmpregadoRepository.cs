using GerenciarProjetos.Models.Requests.Empregado;
using GerenciarProjetos.Models.Responses.Empregado;

namespace GerenciarProjetos.Repositories.Interfaces
{
    public interface IEmpregadoRepository
    {
        void Cadastrar(CadastrarEmpregadoRequest empregado);
        void Editar(EditarEmpregadoRequest empregado);
        void Excluir(int idEmpregado);
        DetalhesProjetoResponse ObterDetalhes(int idEmpregado);
        EmpregadosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina);
    }
}
