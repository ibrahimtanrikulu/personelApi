using Application.Models.Personel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public static class MapperConfigurations<TProfile> where TProfile : Profile , new()
    {
        private static readonly Lazy<IMapper> MapperFactory = new Lazy<IMapper>(() =>
        {
            var mapperConfig = new MapperConfiguration(config => config.AddProfile<TProfile>());
            return new Mapper(mapperConfig, ServiceCtor);
        });

        public static IMapper Mapper => MapperFactory.Value;

        public static Func<Type, object> ServiceCtor { get; set; }

        public static TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
