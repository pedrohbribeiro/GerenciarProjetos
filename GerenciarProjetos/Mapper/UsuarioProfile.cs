using AutoMapper;
using GerenciarProjetos.Database.Entities;
using GerenciarProjetos.Models.DbResults;
using GerenciarProjetos.Models.Requests.Usuario;

namespace GerenciarProjetos.Mapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CadastrarRequest, UsuarioEntity>()
                .ForMember(u => u.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(u => u.SenhaHash, opt => opt.MapFrom(src => src.Senha))
                .ForMember(u => u.ID, opt => opt.Ignore())
                .ForMember(u => u.RefreshToken, opt => opt.Ignore());

            CreateMap<UsuarioEntity, UsuarioAuthResult>()
                .ForMember(u => u.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(u => u.Senha, opt => opt.MapFrom(src => src.SenhaHash))
                .ForMember(u => u.ID, opt => opt.MapFrom(src => src.ID));
        }
    }
}
