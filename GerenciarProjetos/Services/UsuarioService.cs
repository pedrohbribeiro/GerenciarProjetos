using BCrypt.Net;
using FluentValidation;
using GerenciarProjetos.Exceptions;
using GerenciarProjetos.Helpers.Interface;
using GerenciarProjetos.Models.DbResults;
using GerenciarProjetos.Models.Requests.Usuario;
using GerenciarProjetos.Models.Responses;
using GerenciarProjetos.Models.Responses.Usuario;
using GerenciarProjetos.Repositories.Interfaces;
using GerenciarProjetos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciarUsuarios.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthHelper _authHelper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IAuthHelper jwtTokenHelper)
        {
            _usuarioRepository = usuarioRepository;
            _authHelper = jwtTokenHelper;
        }

        public DefaultResultResponse Cadastrar(CadastrarRequest request)
        {
            new CadastrarRequestValidator().ValidateAndThrow(request);
            request.Senha = BCrypt.Net.BCrypt.HashPassword(request.Senha);

            _usuarioRepository.Cadastrar(request);

            return new DefaultResultResponse()
            {
                Sucesso = true,
                TextoResposta = "Cadastro realizado com sucesso!"
            };
        }

        public AuthResponse Login(LoginRequest request)
        {
            UsuarioAuthResult user = _usuarioRepository.ObterUsuarioParaAutenticacaoPorEmail(request.Email);

            if (string.IsNullOrEmpty(user?.Senha) || !BCrypt.Net.BCrypt.Verify(request.Senha, user.Senha))
                throw new BadRequestException("E-mail e/ou senha incorretos");

            string token = _authHelper.CriarJwtToken(user);
            string refreshToken = _authHelper.CriarRefreshToken();
            _usuarioRepository.SalvarRefreshToken(user.ID, refreshToken);

            return new AuthResponse()
            {
                JwtToken = token,
                RefreshToken = refreshToken,
                Sucesso = true
            };
        }

        public AuthResponse GerarJwtTokenPorRefreshToken(string refreshToken)
        {
            UsuarioAuthResult user = _usuarioRepository.ObterUsuarioParaAutenticacaoPorRefreshToken(refreshToken);
            string token = _authHelper.CriarJwtToken(user);

            return new AuthResponse()
            {
                JwtToken = token,
                RefreshToken = refreshToken,
                Sucesso = true
            };
        }
    }
}
