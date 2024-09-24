using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Technology> Technology { get; }
        IGenericRepository<TechStackApp> TechStackApp { get; }
        IUserRepository User { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

