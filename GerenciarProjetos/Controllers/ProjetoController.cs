using Microsoft.AspNetCore.Mvc;
using GerenciarProjetos.Models.Requests.Projeto;
using GerenciarProjetos.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;
using GerenciarProjetos.Services.Interfaces;
using GerenciarProjetos.Models.Responses.Projeto;
using GerenciarProjetos.Models;

namespace GerenciarProjetos.Controllers
{
    [Route("api/[controller]")]
    [Attributes.Authorize]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpPost("CadastrarProjeto")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(400, "Uma ou mais propriedades são inválidas", Type = typeof(BadRequestResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public DefaultResultResponse CadastrarProjeto(CadastrarProjetoRequest request)
        {
            return _projetoService.Cadastrar(request);
        }

        [HttpPost("EditarProjeto")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(400, "Uma ou mais propriedades são inválidas", Type = typeof(BadRequestResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(404, "O projeto de Id igual a Request.IdProjeto informado não existe ou foi excluído", typeof(ErrorResponse))]
        public DefaultResultResponse EditarProjeto(EditarProjetoRequest request)
        {
            return _projetoService.Editar(request);
        }

        [HttpDelete("ExcluirProjeto")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public DefaultResultResponse ExcluirProjeto(int idProjeto)
        {
            return _projetoService.Excluir(idProjeto);
        }

        [HttpGet("ObterDetalhes")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public DetalhesProjetoResponse ObterDetalhes(int idProjeto)
        {
            return _projetoService.ObterDetalhes(idProjeto);
        }

        [HttpGet("ObterPaginados")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public ProjetosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina)
        {
            return _projetoService.ObterPaginados(pagina, tamanhoPagina);
        }
    }
}
