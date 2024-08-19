using Catalog.Domain.Entities;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;

namespace Catalog.Infrastructure.Persistences.Interfaces
{
    public interface ITechStackAppRepository : IGenericRepository<TechStackApp>
    {
        Task<BaseEntityResponse<TechStackApp>> ListTechStackApps(BaseFiltersRequest filters);
    }
}
