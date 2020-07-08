using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wr.entity;

namespace wr.repository.dbo
{

    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetUsers(int p_orgId);
        Task<User> GetUser(int id);
    }
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly DbContext _context;
        private readonly IDataProtectionProvider _protectionProvider;
        private IDataProtector _dataProtector;
        public UserRepository(DbContext context, IDataProtectionProvider p_protectionProvider) : base(context)
        {
            this._context = context;
            _protectionProvider = p_protectionProvider;
          
        }
        public async Task<IEnumerable<User>> GetUsers(int p_orgId)
        {
            var users = await this.Query().SelectAsync();
          
            return users;
        }
        public async Task<User> GetUser(int ids)
        {
            int id = ids;
            var user = await this.Query()
             
                .SingleOrDefaultAsync(x => x.Uid == id, System.Threading.CancellationToken.None);
           

            return user;
        }
    }


     
}
