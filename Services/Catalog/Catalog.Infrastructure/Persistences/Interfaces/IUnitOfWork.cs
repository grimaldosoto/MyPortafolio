namespace Catalog.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //declaración o matricula de nuestra interfaces a nivel repositorio
        ITechnologyRepository Technology {  get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
