using FluentValidation;
using GerenciarProjetos.Models.Requests.Empregado;
using GerenciarProjetos.Models.Responses;
using GerenciarProjetos.Models.Responses.Empregado;
using GerenciarProjetos.Repositories.Interfaces;
using GerenciarProjetos.Services.Interfaces;

namespace GerenciarProjetos.Services
{
    public class EmpregadoService : IEmpregadoService
    {
        private readonly IEmpregadoRepository _empregadoRepository;
        public EmpregadoService(IEmpregadoRepository empregadoRepository)
        {
            _empregadoRepository = empregadoRepository;
        }

        public DefaultResultResponse Cadastrar(CadastrarEmpregadoRequest empregado)
        {
            new CadastrarEmpregadoRequestValidator().ValidateAndThrow(empregado);
            _empregadoRepository.Cadastrar(empregado);
            return new DefaultResultResponse()
            {
                Sucesso = true,
                TextoResposta = "Empregado cadastrado com sucesso."
            };
        }

        public DefaultResultResponse Editar(EditarEmpregadoRequest empregado)
        {
            new EditarEmpregadoRequestValidator().ValidateAndThrow(empregado);
            _empregadoRepository.Editar(empregado);
            return new DefaultResultResponse()
            {
                Sucesso = true,
                TextoResposta = "Empregado editado com sucesso."
            };
        }
        public DefaultResultResponse Excluir(int idEmpregado)
        {
            _empregadoRepository.Excluir(idEmpregado);
            return new DefaultResultResponse()
            {
                Sucesso = true,
                TextoResposta = "Empregado excluído com sucesso."
            };
        }

        public DetalhesProjetoResponse ObterDetalhes(int idEmpregado)
        {
            return _empregadoRepository.ObterDetalhes(idEmpregado);
        }

        public EmpregadosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina)
        {
            return _empregadoRepository.ObterPaginados(pagina, tamanhoPagina);
        }
    }
}
