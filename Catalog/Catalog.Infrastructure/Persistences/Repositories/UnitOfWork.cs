using Catalog.Infrastructure.Persistences.Contexts;
using Catalog.Infrastructure.Persistences.Interfaces;

namespace Catalog.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyPortaLiveContext _context;
        public ITechnologyRepository Technology { get; private set; }
        public IUserRepository User { get; private set; }

        public UnitOfWork(MyPortaLiveContext context)
        {
            _context = context;
            Technology = new TechnologyRepository(_context);
            User = new UserRepository(_context);
        }

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
