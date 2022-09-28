using AutoMapper;
using AutoMapper.QueryableExtensions;
using GerenciarProjetos.Database;
using GerenciarProjetos.Database.Entities;
using GerenciarProjetos.Exceptions;
using GerenciarProjetos.Models.DbResults;
using GerenciarProjetos.Models.Requests.Usuario;
using GerenciarProjetos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciarProjetos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Cadastrar(CadastrarRequest request)
        {
            if (_context.Usuario.Any(k => k.Email == request.Email))
                throw new BadRequestException("E-mail informado já cadastrado");

            _context.Usuario.Add(_mapper.Map<UsuarioEntity>(request));
            _context.SaveChanges();
        }

        public UsuarioAuthResult ObterUsuarioParaAutenticacaoPorEmail(string email)
        {
            return _context.Usuario
                .Where(u => u.Email == email)
                .ProjectTo<UsuarioAuthResult>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public UsuarioAuthResult ObterUsuarioParaAutenticacaoPorRefreshToken(string refreshToken)
        {
            return _context.RefreshToken
                .Include(u => u.Usuario)
                .Where(u => u.Token == refreshToken)
                .Select(k => k.Usuario)
                .ProjectTo<UsuarioAuthResult>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public void SalvarRefreshToken(int idUsuario, string refreshToken)
        {
            _context.RefreshToken.Add(new RefreshTokenEntity()
            {
                IdUsuario = idUsuario,
                Token = refreshToken
            });

            _context.SaveChanges();
        }
    }
}
