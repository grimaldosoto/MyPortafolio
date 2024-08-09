using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistences.Contexts;
using Catalog.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly MyPortaLiveContext _context;

        public UserRepository(MyPortaLiveContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> AccountByUserName(string userName)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName!.Equals(userName) );
        }
    }
}
