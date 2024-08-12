using Catalog.Infrastructure.Commons.Bases.Request;
using System.Linq.Dynamic.Core;

namespace Catalog.Infrastructure.Helpers
{
    public static class QueryableHelpers
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, BasePaginationRequest request)
        {
            return queryable.Skip((request.NumPage - 1) * request.Records).Take(request.Records);
        }
    }
}
