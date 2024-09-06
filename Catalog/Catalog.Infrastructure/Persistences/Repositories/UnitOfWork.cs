using Catalog.Domain.Entities;
using Catalog.Infrastructure.FileStorage;
using Catalog.Infrastructure.Persistences.Contexts;
using Catalog.Infrastructure.Persistences.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Catalog.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyPortaLiveContext _context;
        public IUserRepository _user = null!;
        public IGenericRepository<Technology> _technology => null!;
        public IGenericRepository<TechStackApp> _techStackApp => null!;

        public UnitOfWork(MyPortaLiveContext context, IConfiguration configuration)
        {
            _context = context;
        }

        public IGenericRepository<Technology> Technology => _technology ?? new GenericRepository<Technology>(_context);
        public IGenericRepository<TechStackApp> TechStackApp => _techStackApp ?? new GenericRepository<TechStackApp>(_context);

        public IUserRepository User => _user ?? new UserRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
