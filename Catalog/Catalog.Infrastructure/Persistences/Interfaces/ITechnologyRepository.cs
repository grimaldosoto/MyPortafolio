using Catalog.Domain.Entities;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;

namespace Catalog.Infrastructure.Persistences.Interfaces
{
    public interface ITechnologyRepository : IGenericRepository<Technology>
    {
        Task<BaseEntityResponse<Technology>> ReadTechnologies(BaseFiltersRequest filters);   // R
    }
}
