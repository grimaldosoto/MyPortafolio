using Catalog.Domain.Entities;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;
using Catalog.Infrastructure.Persistences.Contexts;
using Catalog.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistences.Repositories
{
    public class TechStackAppReporitory : GenericRepository<TechStackApp>, ITechStackAppRepository
    {
        public TechStackAppReporitory(MyPortaLiveContext context) : base(context)
        {
        }

        public async Task<BaseEntityResponse<TechStackApp>> ListTechStackApps(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<TechStackApp>();
            var techStackApps = GetEntityQuery()
                .Include(x => x.App)
                .Include(x => x.Technology)
                .AsNoTracking();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    // Filtro por nombre de la aplicación
                    case 1:
                        techStackApps = techStackApps.Where(x => x.App.Name.Contains(filters.TextFilter));
                        break;
                }
            }
            
            //filtro por rango de fechas del campo ReleaseDate
            if(filters.StartDate is not null && filters.EndDate is not null)
            {
                techStackApps = techStackApps.Where(x => 
                x.App.ReleaseDate >= Convert.ToDateTime(filters.StartDate) && x.App.ReleaseDate <= Convert.ToDateTime(filters.EndDate)
                .AddDays(1));
            }

            //Ordenamiento por Id por defecto
            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await techStackApps.CountAsync();
            response.Items = await Ordering(filters, techStackApps, !(bool)filters.Download!).ToListAsync();

            return response;
        }
    }
}
