using GerenciarProjetos.Models;
using GerenciarProjetos.Models.Requests.Usuario;
using GerenciarProjetos.Models.Responses;
using GerenciarProjetos.Models.Responses.Usuario;
using GerenciarProjetos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GerenciarProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Login")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(400, "Dados de login inválidos", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public AuthResponse Login(LoginRequest request)
        {
            return _usuarioService.Login(request);
        }

        [HttpPost("Cadastrar")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(400, "Uma ou mais propriedades são inválidas", Type = typeof(BadRequestResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public DefaultResultResponse Cadastrar(CadastrarRequest request)
        {
            return _usuarioService.Cadastrar(request);
        }

        [HttpPost("RefreshToken")]
        [SwaggerResponse(200, Type = typeof(DefaultResultResponse))]
        [SwaggerResponse(500, "Erro interno", typeof(ErrorResponse))]
        public AuthResponse RefreshToken(RefreshTokenRequest request)
        {
            return _usuarioService.GerarJwtTokenPorRefreshToken(request.Token);
        }
    }
}
