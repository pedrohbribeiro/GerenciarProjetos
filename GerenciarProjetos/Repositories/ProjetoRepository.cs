using AutoMapper;
using AutoMapper.QueryableExtensions;
using GerenciarProjetos.Database;
using GerenciarProjetos.Database.Entities;
using GerenciarProjetos.Exceptions;
using GerenciarProjetos.Extensions;
using GerenciarProjetos.Models.Requests.Projeto;
using GerenciarProjetos.Models.Responses.Projeto;
using GerenciarProjetos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciarProjetos.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ProjetoRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Cadastrar(CadastrarProjetoRequest projeto)
        {
            projeto.IdsMembros ??= new List<int>();
            ValidarGerenteEMembrosProjeto(projeto.IdGerente, projeto.IdsMembros);

            _context.Projeto.Add(_mapper.Map<ProjetoEntity>(projeto));
            _context.SaveChanges();
        }

        public void Editar(EditarProjetoRequest projeto)
        {
            projeto.IdsMembros ??= new List<int>();
            ValidarGerenteEMembrosProjeto(projeto.IdGerente, projeto.IdsMembros);
            var projetoDb = _context.Projeto
                .Include(k => k.Membro)
                .FirstOrDefault(e => e.IdProjeto == projeto.IdProjeto && !e.Excluido);

            if (projetoDb == null)
                throw new EntityNotFoundException("O projeto informado não existe.");

            _mapper.Map(projeto, projetoDb);
            _context.SaveChanges();
        }

        private void ValidarGerenteEMembrosProjeto(int idGerente, List<int> idsMembros)
        {
            if (!_context.Empregado.Any(k => k.IdEmpregado == idGerente && !k.Excluido))
                throw new EntityNotFoundException("O gerente informado não existe.");

            if (idsMembros.Count != idsMembros.Distinct().Count())
                throw new BadRequestException("Um projeto não pode ter membros repetidos.");

            if (_context.Empregado.Count(k => idsMembros.Contains(k.IdEmpregado) && !k.Excluido) != idsMembros.Count)
                throw new EntityNotFoundException("Um ou mais membros informados não existem.");
        }

        public void Excluir(int idProjeto)
        {
            var ProjetoDb = _context.Projeto.FirstOrDefault(e => e.IdProjeto == idProjeto && !e.Excluido);

            if (ProjetoDb == null)
                throw new EntityNotFoundException("O projeto informado não existe.");

            ProjetoDb.Excluido = true;
            _context.SaveChanges();
        }

        public ProjetosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina)
        {
            var query = _context.Projeto
                .Where(e => !e.Excluido);

            return new ProjetosPaginadosResponse()
            {
                TotalItens = query.Count(),
                Projetos = query
                    .Paginate(pagina, tamanhoPagina)
                    .OrderBy(k => k.IdProjeto)
                    .ProjectTo<ItemProjetosPaginadosResponse>(_mapper.ConfigurationProvider)
                    .ToList()
            };
        }

        public DetalhesProjetoResponse ObterDetalhes(int idProjeto)
        {
            var result = _context.Projeto
                .Where(e => !e.Excluido && e.IdProjeto == idProjeto)
                .ProjectTo<DetalhesProjetoResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            if (result == null)
                throw new EntityNotFoundException("O projeto informado não existe.");

            return result;
        }
    }
}
