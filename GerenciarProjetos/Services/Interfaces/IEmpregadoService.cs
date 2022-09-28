using GerenciarProjetos.Models.Requests.Empregado;
using GerenciarProjetos.Models.Responses;
using GerenciarProjetos.Models.Responses.Empregado;

namespace GerenciarProjetos.Services.Interfaces
{
    public interface IEmpregadoService
    {
        DefaultResultResponse Cadastrar(CadastrarEmpregadoRequest empregado);
        DefaultResultResponse Editar(EditarEmpregadoRequest empregado);
        DefaultResultResponse Excluir(int idEmpregado);
        DetalhesProjetoResponse ObterDetalhes(int idEmpregado);
        EmpregadosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina);
    }
}
