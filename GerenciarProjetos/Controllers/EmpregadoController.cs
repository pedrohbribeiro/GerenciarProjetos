using Microsoft.AspNetCore.Mvc;
using GerenciarProjetos.Models.Requests.Empregado;
using GerenciarProjetos.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;
using GerenciarProjetos.Services.Interfaces;
using GerenciarProjetos.Models.Responses.Empregado;
using GerenciarProjetos.Models;

namespace GerenciarProjetos.Controllers
{
    [Route("api/[controller]")]
    [Attributes.Authorize]
    [ApiController]
    public class EmpregadoController : ControllerBase
    {
        private readonly IEmpregadoService _empregadoService;
        public EmpregadoController(IEmpregadoService empregadoService)
        {
            _empregadoService = empregadoService;
        }

        [HttpPost("CadastrarEmpregado")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(400, "Uma ou mais propriedades são inválidas", Type = typeof(BadRequestResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public DefaultResultResponse CadastrarEmpregado(CadastrarEmpregadoRequest request)
        {
            return _empregadoService.Cadastrar(request);
        }

        [HttpPost("EditarEmpregado")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(400, "Uma ou mais propriedades são inválidas", Type = typeof(BadRequestResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(404, "O empregado informado não existe ou foi excluído", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public DefaultResultResponse EditarEmpregado(EditarEmpregadoRequest request)
        {
            return _empregadoService.Editar(request);
        }

        [HttpDelete("ExcluirEmpregado")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(404, "O empregado informado não existe ou foi excluído", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public DefaultResultResponse ExcluirEmpregado(int idEmpregado)
        {
            return _empregadoService.Excluir(idEmpregado);
        }

        [HttpGet("ObterDetalhes")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(404, "O empregado informado não existe ou foi excluído", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public DetalhesProjetoResponse ObterDetalhes(int idEmpregado)
        {
            return _empregadoService.ObterDetalhes(idEmpregado);
        }

        [HttpGet("ObterPaginados")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(401, "Token não informado ou inválido", Type = typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public EmpregadosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina)
        {
            return _empregadoService.ObterPaginados(pagina, tamanhoPagina);
        }

    }
}
