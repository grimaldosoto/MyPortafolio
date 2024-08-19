using Catalog.Application.Commons.Bases;
using Catalog.Application.Dtos.TechStackApp.Request;
using Catalog.Application.Dtos.TechStackApp.Response;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;

namespace Catalog.Application.Interfaces
{
    public interface ITechStackAppApplication
    {
        Task<BaseResponse<BaseEntityResponse<TechStackAppResponseDto>>> ListTechStackApps(BaseFiltersRequest filters);
        Task<BaseResponse<TechStackAppResponseDto>> TechStackAppById(int techStackAppId);
        Task<BaseResponse<bool>> CreateTechStachApp(TechStackAppRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateTechStackApp(int techStackAppId, TechStackAppRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteTechStackApp(int techStackAppId);

    }
}
