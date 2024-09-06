using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistences.Contexts;
using Catalog.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MyPortaLiveContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(MyPortaLiveContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
        {
           await _context.AddAsync(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            _context.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

            return response!;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;

            if(filter != null) query = query.Where(filter);

            return query;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<T> GetAllQueryable()
        {
            var getAllQuery = GetEntityQuery();
            return getAllQuery;
        }

        public async Task<IEnumerable<T>> GetSelectAllASync()
        {
            var getAll = await _entity.AsNoTracking().ToListAsync();
            return getAll;
        }
    }
}
