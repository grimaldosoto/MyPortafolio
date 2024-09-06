using AutoMapper;
using Catalog.Application.Commons.Bases.Response;
using Catalog.Application.Dtos.TechStackApp.Request;
using Catalog.Application.Dtos.TechStackApp.Response;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappers
{
    internal class TechStackAppMappingsProfile : Profile
    {
        public TechStackAppMappingsProfile()
        {
            CreateMap<TechStackApp, TechStackAppResponseDto>()
                .ForMember(x => x.TechStackAppId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.NameApp, x => x.MapFrom(y => y.App.Name))
                .ForMember(x => x.ReleaseDateApp, x => x.MapFrom(y => y.App.ReleaseDate))
                .ForMember(x => x.VersionApp, x => x.MapFrom(y => y.App.Version))
                .ForMember(x => x.RepositoryLinkApp, x => x.MapFrom(y => y.App.RepositoryLink))
                .ForMember(x => x.VersionApp, x => x.MapFrom(y => y.App.RepositoryLink))
                .ForMember(x => x.NameTechnology, x => x.MapFrom(y => y.Technology.Name))
                .ForMember(x => x.VersionTechnology, x => x.MapFrom(y => y.Technology.Version))
                .ReverseMap();


            CreateMap<TechStackAppRequestDto, TechStackApp>();
        }
    }
}
