using Catalog.Application.Commons.Bases;
using Catalog.Application.Dtos.TechStackApp;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;

namespace Catalog.Application.Interfaces
{
    public interface ITechStackAppApplication
    {
        Task<BaseResponse<BaseEntityResponse<TechStackAppResponseDto>>> ListTechStackApps(BaseFiltersRequest filters);
    }
}
