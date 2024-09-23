using Catalog.Application.Commons.Bases.Request;
using Catalog.Application.Commons.Bases.Response;
using Catalog.Application.Dtos.TechStackApp.Request;
using Catalog.Application.Dtos.TechStackApp.Response;

namespace Catalog.Application.Interfaces
{
    public interface ITechStackAppApplication
    {
        Task<BaseResponse<IEnumerable<TechStackAppResponseDto>>> ListTechStackApps(BaseFiltersRequest filters);
        Task<BaseResponse<TechStackAppResponseDto>> TechStackAppById(int techStackAppId);
        Task<BaseResponse<bool>> CreateTechStachApp(TechStackAppRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateTechStackApp(int techStackAppId, TechStackAppRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteTechStackApp(int techStackAppId);

    }
}
