using Catalog.Domain.Entities;
using Catalog.Infrastructure.FileStorage;

namespace Catalog.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //declaración o matricula de nuestra interfaces a nivel repositorio
        IGenericRepository<Technology> Technology { get; }
        IGenericRepository<TechStackApp> TechStackApp { get; }
        IUserRepository User { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

