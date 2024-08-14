using AutoMapper;
using Catalog.Application.Dtos.TechStackApp;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .ForMember(x => x.VersionTechnology, x => x.MapFrom(y => y.Technology.Version));

            CreateMap<BaseEntityResponse<TechStackApp>, BaseEntityResponse<TechStackAppResponseDto>>()
                .ReverseMap();
        }
    }
}
