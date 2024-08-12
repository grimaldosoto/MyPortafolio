using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Commons.Bases.Response;
using Catalog.Application.Dtos.Category.Request;
using Catalog.Application.Dtos.Category.Response;

namespace Catalog.Application.Mappers
{
    public class TechnologyMappingProfile : Profile
    {
        public TechnologyMappingProfile()
        {
            CreateMap<Technology, TechnologyResponseDto>()
                .ForMember(x => x.TechnologyId, x => x.MapFrom(y => y.Id))
                .ReverseMap(); 

            CreateMap<BaseEntityResponse<Technology>, BaseEntityResponse<TechnologyResponseDto>>()
                .ReverseMap();

            CreateMap<TechnologyRequestDto, Technology>();

            CreateMap<Technology, TechnologySelectResponseDto>()
                .ForMember(x => x.TechnologyId, x => x.MapFrom(y => y.Id))
                .ReverseMap();



        }
    }
}
