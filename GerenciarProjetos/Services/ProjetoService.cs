using GerenciarProjetos.Models.Requests.Projeto;
using GerenciarProjetos.Models.Responses.Projeto;
using GerenciarProjetos.Models.Responses;
using GerenciarProjetos.Repositories;
using GerenciarProjetos.Repositories.Interfaces;
using GerenciarProjetos.Services.Interfaces;
using FluentValidation;

namespace GerenciarProjetos.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public DefaultResultResponse Cadastrar(CadastrarProjetoRequest projeto)
        {
            new CadastrarProjetoRequestValidator().ValidateAndThrow(projeto);
            _projetoRepository.Cadastrar(projeto);
            return new DefaultResultResponse()
            {
                Sucesso = true,
                TextoResposta = "Projeto cadastrado com sucesso."
            };
        }

        public DefaultResultResponse Editar(EditarProjetoRequest projeto)
        {
            new EditarProjetoRequestValidator().ValidateAndThrow(projeto);
            _projetoRepository.Editar(projeto);
            return new DefaultResultResponse()
            {
                Sucesso = true,
                TextoResposta = "Projeto editado com sucesso."
            };
        }
        public DefaultResultResponse Excluir(int idProjeto)
        {
            _projetoRepository.Excluir(idProjeto);
            return new DefaultResultResponse()
            {
                Sucesso = true,
                TextoResposta = "Projeto excluído com sucesso."
            };
        }

        public DetalhesProjetoResponse ObterDetalhes(int idProjeto)
        {
            return _projetoRepository.ObterDetalhes(idProjeto);
        }

        public ProjetosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina)
        {
            return _projetoRepository.ObterPaginados(pagina, tamanhoPagina);
        }
    }
}
