using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using wr.entity;

namespace wr.repository.dbo
{
    public interface IThemeRepository : IRepositoryBase<Theme>
    {
        Task<IEnumerable<Theme>> GetAll();
        Task<Theme> GetById(int id);
    }
    public class ThemeRepository : RepositoryBase<Theme>, IThemeRepository
    {
        private readonly DbContext _context;
        private readonly IDataProtectionProvider _protectionProvider;
        private IDataProtector _dataProtector;
        public ThemeRepository(DbContext context, IDataProtectionProvider p_protectionProvider) : base(context)
        {
            this._context = context;
            _protectionProvider = p_protectionProvider;
        }
        public async Task<IEnumerable<Theme>> GetAll()
        {
            var Themes = await this.Query().SelectAsync();

            return Themes;
        }

        public async Task<Theme> GetById(int id)
        {

            var Themes = await this.Query().SingleOrDefaultAsync(c=>c.ThemeId==id,CancellationToken.None);

            return Themes;
        }
    }
}
