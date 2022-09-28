using AutoMapper;
using AutoMapper.QueryableExtensions;
using GerenciarProjetos.Database;
using GerenciarProjetos.Database.Entities;
using GerenciarProjetos.Exceptions;
using GerenciarProjetos.Extensions;
using GerenciarProjetos.Models.Requests.Empregado;
using GerenciarProjetos.Models.Responses.Empregado;
using GerenciarProjetos.Repositories.Interfaces;

namespace GerenciarProjetos.Repositories
{
    public class EmpregadoRepository : IEmpregadoRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EmpregadoRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Cadastrar(CadastrarEmpregadoRequest empregado)
        {
            if (_context.Empregado.Any(k => k.Endereco == empregado.Endereco))
                throw new BadRequestException("Endereço informado já cadastrado");
            _context.Empregado.Add(_mapper.Map<EmpregadoEntity>(empregado));
            _context.SaveChanges();
        }

        public void Editar(EditarEmpregadoRequest empregado)
        {
            if (_context.Empregado.Any(k => k.Endereco == empregado.Endereco && k.IdEmpregado != empregado.IdEmpregado))
                throw new BadRequestException("Endereço informado já cadastrado");
            var empregadoDb = _context.Empregado.FirstOrDefault(e => e.IdEmpregado == empregado.IdEmpregado && !e.Excluido);

            if(empregadoDb == null)
                throw new EntityNotFoundException("O empregado informado não existe.");

            _mapper.Map(empregado, empregadoDb);
            _context.SaveChanges();
        }

        public void Excluir(int idEmpregado)
        {
            var empregadoDb = _context.Empregado.FirstOrDefault(e => e.IdEmpregado == idEmpregado && !e.Excluido);

            if (empregadoDb == null)
                throw new EntityNotFoundException("O empregado informado não existe.");

            empregadoDb.Excluido = true;
            _context.SaveChanges();
        }

        public EmpregadosPaginadosResponse ObterPaginados(int pagina, int tamanhoPagina)
        {
            var query = _context.Empregado
                .Where(e => !e.Excluido);

            return new EmpregadosPaginadosResponse()
            {
                TotalItens = query.Count(),
                Empregados = query
                    .Paginate(pagina, tamanhoPagina)
                    .OrderBy(k => k.IdEmpregado)
                    .ProjectTo<ItemEmpregadosPaginadosResponse>(_mapper.ConfigurationProvider)
                    .ToList()
            };
        }

        public DetalhesProjetoResponse ObterDetalhes(int idEmpregado)
        {
            var result = _context.Empregado
                .Where(e => !e.Excluido && e.IdEmpregado == idEmpregado)
                .ProjectTo<DetalhesProjetoResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            if (result == null)
                throw new EntityNotFoundException("O empregado informado não existe.");

            return result;
        }
    }
}
