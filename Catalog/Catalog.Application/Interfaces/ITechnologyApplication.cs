using Catalog.Application.Commons.Bases;
using Catalog.Application.Dtos.Category.Request;
using Catalog.Application.Dtos.Category.Response;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;

namespace Catalog.Application.Interfaces
{
    public interface ITechnologyApplication
    {
        Task<Commons.Bases.BaseEntityResponse<bool>> CreateTechnology(TechnologyRequestDto requestDto);
        Task<Commons.Bases.BaseEntityResponse<Infrastructure.Commons.Bases.Response.BaseEntityResponse<TechnologyResponseDto>>> ReadTechnologies(BaseFiltersRequest filters);
        Task<Commons.Bases.BaseEntityResponse<bool>> UpdateTechnology(int technologyId, TechnologyRequestDto requestDto); 
        Task<Commons.Bases.BaseEntityResponse<bool>> DeleteTechnology(int technologyId);

        Task<Commons.Bases.BaseEntityResponse<IEnumerable<TechnologySelectResponseDto>>> ListSelectTechnologies();
        Task<Commons.Bases.BaseEntityResponse<TechnologyResponseDto>> TechnologyById(int technologyId);
    }

}
