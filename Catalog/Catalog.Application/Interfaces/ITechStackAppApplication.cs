using Catalog.Application.Commons.Bases;
using Catalog.Application.Dtos.TechStackApp.Request;
using Catalog.Application.Dtos.TechStackApp.Response;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;

namespace Catalog.Application.Interfaces
{
    public interface ITechStackAppApplication
    {
        Task<Commons.Bases.BaseEntityResponse<Infrastructure.Commons.Bases.Response.BaseEntityResponse<TechStackAppResponseDto>>> ListTechStackApps(BaseFiltersRequest filters);
        Task<Commons.Bases.BaseEntityResponse<TechStackAppResponseDto>> TechStackAppById(int techStackAppId);
        Task<Commons.Bases.BaseEntityResponse<bool>> CreateTechStachApp(TechStackAppRequestDto requestDto);
        Task<Commons.Bases.BaseEntityResponse<bool>> UpdateTechStackApp(int techStackAppId, TechStackAppRequestDto requestDto);
        Task<Commons.Bases.BaseEntityResponse<bool>> DeleteTechStackApp(int techStackAppId);

    }
}
