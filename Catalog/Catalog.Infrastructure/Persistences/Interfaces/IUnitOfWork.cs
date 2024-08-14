using Catalog.Infrastructure.FileStorage;

namespace Catalog.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //declaración o matricula de nuestra interfaces a nivel repositorio
        ITechnologyRepository Technology {  get; }
        IUserRepository User { get; }
        IAzureStorage Storage { get; }
        ITechStackAppRepository TechStackApp { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
