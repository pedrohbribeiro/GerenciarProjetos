using AutoMapper;
using GerenciarProjetos.Database.Entities;
using GerenciarProjetos.Models.Requests.Empregado;
using GerenciarProjetos.Models.Responses.Empregado;

namespace GerenciarProjetos.Mapper
{
    public class EmpregadoProfile : Profile
    {
        public EmpregadoProfile()
        {
            CreateMap<CadastrarEmpregadoRequest, EmpregadoEntity>()
                .ForMember(entity => entity.PrimeiroNome, opt => opt.MapFrom(request => request.PrimeiroNome))
                .ForMember(entity => entity.UltimoNome, opt => opt.MapFrom(request => request.UltimoNome))
                .ForMember(entity => entity.Telefone, opt => opt.MapFrom(request => request.Telefone))
                .ForMember(entity => entity.Endereco, opt => opt.MapFrom(request => request.Endereco))
                .ForMember(entity => entity.Membro, opt => opt.Ignore())
                .ForMember(entity => entity.Excluido, opt => opt.Ignore())
                .ForMember(entity => entity.IdEmpregado, opt => opt.Ignore())
                .ForMember(entity => entity.Projeto, opt => opt.Ignore());

            CreateMap<EditarEmpregadoRequest, EmpregadoEntity>()
                .ForMember(entity => entity.PrimeiroNome, opt => opt.MapFrom(request => request.PrimeiroNome))
                .ForMember(entity => entity.UltimoNome, opt => opt.MapFrom(request => request.UltimoNome))
                .ForMember(entity => entity.Telefone, opt => opt.MapFrom(request => request.Telefone))
                .ForMember(entity => entity.Endereco, opt => opt.MapFrom(request => request.Endereco))
                .ForMember(entity => entity.Membro, opt => opt.Ignore())
                .ForMember(entity => entity.Excluido, opt => opt.Ignore())
                .ForMember(entity => entity.IdEmpregado, opt => opt.Ignore())
                .ForMember(entity => entity.Projeto, opt => opt.Ignore());

            CreateMap<EmpregadoEntity, ItemEmpregadosPaginadosResponse>()
                .ForMember(response => response.IdEmpregado, opt => opt.MapFrom(entity => entity.IdEmpregado))
                .ForMember(response => response.PrimeiroNome, opt => opt.MapFrom(entity => entity.PrimeiroNome))
                .ForMember(response => response.UltimoNome, opt => opt.MapFrom(entity => entity.UltimoNome));

            CreateMap<EmpregadoEntity, DetalhesProjetoResponse>()
                .ForMember(response => response.IdEmpregado, opt => opt.MapFrom(entity => entity.IdEmpregado))
                .ForMember(response => response.PrimeiroNome, opt => opt.MapFrom(entity => entity.PrimeiroNome))
                .ForMember(response => response.UltimoNome, opt => opt.MapFrom(entity => entity.UltimoNome))
                .ForMember(response => response.Telefone, opt => opt.MapFrom(entity => entity.Telefone))
                .ForMember(response => response.Endereco, opt => opt.MapFrom(entity => entity.Endereco));
        }
    }
}
