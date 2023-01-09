using Application.Models.Departman;
using Application.Models.Personel;
using Application.Models.Sube;
using Application.Models.User;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Authentication;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Personel
            CreateMap<Personel, PersonelModel>().ReverseMap()
                .ForMember(d => d.Id, opt => opt.MapFrom(srt => srt.id));

            CreateMap<PersonelSigorta,PersonelSigortaModel>().ReverseMap();
            CreateMap<PersonelIzinModel, PersonelIzin>().ReverseMap();

            //Departman Liste
            CreateMap<Departman, DepartmanModel>().ReverseMap();

            //Sube Liste
            CreateMap<Sube, SubeModel>().ReverseMap();

            //DepartmanRol
            CreateMap<DepartmanRol, DepartmanRolModel>().ReverseMap();

            //Identity
            CreateMap<AppUser, UserCreateModel>().ReverseMap();
            //CreateMap<UserCreateModel, AppUser>();

        }
    }
}
