using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wr.repository;
using wr.entity;

namespace wr.repository.dbo
{

    public interface IBranchRepository : IRepositoryBase<Branch>
    {
        Task<IEnumerable<Branch>> GetUsers(int p_orgId);
        Task<Branch> GetUser(int id);
    }
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        private readonly DbContext _context;
        private readonly IDataProtectionProvider _protectionProvider;
        private IDataProtector _dataProtector;
        public BranchRepository(DbContext context, IDataProtectionProvider p_protectionProvider) : base(context)
        {
            this._context = context;
            _protectionProvider = p_protectionProvider;
        }
        public async Task<IEnumerable<Branch>> GetUsers(int p_orgId)
        {
            var users = await this.Query().SelectAsync();
          
            return users;
        }
        public async Task<Branch> GetUser(int ids)
        {
            int id = ids;
            var user = await this.Query().SingleOrDefaultAsync(x => x.BranchId == id, System.Threading.CancellationToken.None);
           

            return user;
        }
    }


     
}
