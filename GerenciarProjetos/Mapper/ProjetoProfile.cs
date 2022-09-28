using AutoMapper;
using GerenciarProjetos.Database.Entities;
using GerenciarProjetos.Models.Requests.Projeto;
using GerenciarProjetos.Models.Responses.Projeto;

namespace GerenciarProjetos.Mapper
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<CadastrarProjetoRequest, ProjetoEntity>()
                .ForMember(entity => entity.DataTermino, opt => opt.MapFrom(request => request.DataTermino))
                .ForMember(entity => entity.DataCriacao, opt => opt.MapFrom(request => request.DataCriacao))
                .ForMember(entity => entity.IdGerente, opt => opt.MapFrom(request => request.IdGerente))
                .ForMember(entity => entity.Nome, opt => opt.MapFrom(request => request.Nome))
                .ForMember(entity => entity.Membro, opt => opt.MapFrom(src => src.IdsMembros.Select(m => new MembrosEntity() { IdEmpregado = m})))
                .ForMember(entity => entity.Excluido, opt => opt.Ignore())
                .ForMember(entity => entity.IdProjeto, opt => opt.Ignore())
                .ForMember(entity => entity.Empregado, opt => opt.Ignore());

            CreateMap<EditarProjetoRequest, ProjetoEntity>()
                .ForMember(entity => entity.DataTermino, opt => opt.MapFrom(request => request.DataTermino))
                .ForMember(entity => entity.DataCriacao, opt => opt.MapFrom(request => request.DataCriacao))
                .ForMember(entity => entity.IdGerente, opt => opt.MapFrom(request => request.IdGerente))
                .ForMember(entity => entity.Nome, opt => opt.MapFrom(request => request.Nome))
                .ForMember(entity => entity.Membro, opt => opt.MapFrom(src => src.IdsMembros.Select(m => new MembrosEntity() { IdEmpregado = m })))
                .ForMember(entity => entity.Excluido, opt => opt.Ignore())
                .ForMember(entity => entity.IdProjeto, opt => opt.Ignore())
                .ForMember(entity => entity.Empregado, opt => opt.Ignore());

            CreateMap<ProjetoEntity, ItemProjetosPaginadosResponse>()
                .ForMember(response => response.IdProjeto, opt => opt.MapFrom(entity => entity.IdProjeto))
                .ForMember(response => response.Nome, opt => opt.MapFrom(entity => entity.Nome))
                .ForMember(response => response.DataCriacao, opt => opt.MapFrom(entity => entity.DataCriacao))
                .ForMember(response => response.DataTermino, opt => opt.MapFrom(entity => entity.DataTermino));

            CreateMap<ProjetoEntity, DetalhesProjetoResponse>()
                .ForMember(response => response.IdProjeto, opt => opt.MapFrom(entity => entity.IdProjeto))
                .ForMember(response => response.Nome, opt => opt.MapFrom(entity => entity.Nome))
                .ForMember(response => response.DataCriacao, opt => opt.MapFrom(entity => entity.DataCriacao))
                .ForMember(response => response.DataTermino, opt => opt.MapFrom(entity => entity.DataTermino))
                .ForMember(response => response.IdGerente, opt => opt.MapFrom(entity => entity.IdGerente))
                .ForMember(response => response.NomeGerente, opt => opt.MapFrom(entity => entity.Empregado.PrimeiroNome))
                .ForMember(response => response.MembrosProjeto, opt => opt.MapFrom(entity => entity.Membro));

            CreateMap<MembrosEntity, MembrosProjetoResponse>()
                .ForMember(response => response.NomeEmpregado, opt => opt.MapFrom(src => src.Empregado.PrimeiroNome))
                .ForMember(response => response.IdEmpregado, opt => opt.MapFrom(src => src.IdEmpregado));
        }
    }
}
