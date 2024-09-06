using Catalog.Application.Commons.Bases.Request;

namespace Catalog.Application.Commons.Ordering
{
    public interface IOrderingQuery
    {
        IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class;

    }
}
