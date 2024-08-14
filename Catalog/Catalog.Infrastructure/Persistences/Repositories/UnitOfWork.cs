using Catalog.Infrastructure.FileStorage;
using Catalog.Infrastructure.Persistences.Contexts;
using Catalog.Infrastructure.Persistences.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Catalog.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyPortaLiveContext _context;
        public ITechnologyRepository Technology { get; private set; }
        public IUserRepository User { get; private set; }
        public IAzureStorage Storage { get; private set; }
        public ITechStackAppRepository TechStackApp { get; private set; }

        public UnitOfWork(MyPortaLiveContext context, IConfiguration configuration)
        {
            _context = context;
            Technology = new TechnologyRepository(_context);
            User = new UserRepository(_context);
            Storage = new AzureStorage(configuration);
            TechStackApp = new TechStackAppReporitory(_context);
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
