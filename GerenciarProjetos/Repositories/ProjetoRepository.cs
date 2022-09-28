using AutoMapper;
using AutoMapper.QueryableExtensions;
using GerenciarProjetos.Database;
using GerenciarProjetos.Database.Entities;
using GerenciarProjetos.Exceptions;
using GerenciarProjetos.Extensions;
using GerenciarProjetos.Models.Requests.Projeto;
using GerenciarProjetos.Models.Responses.Projeto;
using GerenciarProjetos.Repositories.Interfaces;

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

        public void Cadastrar(CadastrarProjetoRequest Projeto)
        {
            _context.Projeto.Add(_mapper.Map<ProjetoEntity>(Projeto));
            _context.SaveChanges();
        }

        public void Editar(EditarProjetoRequest Projeto)
        {
            var ProjetoDb = _context.Projeto.FirstOrDefault(e => e.IdProjeto == Projeto.IdProjeto && !e.Excluido);

            if (ProjetoDb == null)
                throw new EntityNotFoundException("O projeto informado não existe.");

            _mapper.Map(Projeto, ProjetoDb);
            _context.SaveChanges();
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
