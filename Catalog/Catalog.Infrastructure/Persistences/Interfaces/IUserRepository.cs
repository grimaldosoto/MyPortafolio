using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Persistences.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AccountByUserName(string username);

    }
}
 