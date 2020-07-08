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
    public interface IColorRepository : IRepositoryBase<Color>
    {
        Task<IEnumerable<Color>> GetAll();
        Task<Color> GetById(int id);
    }
    public class ColorRepository : RepositoryBase<Color>, IColorRepository
    {
        private readonly DbContext _context;
        private readonly IDataProtectionProvider _protectionProvider;
        private IDataProtector _dataProtector;
        public ColorRepository(DbContext context, IDataProtectionProvider p_protectionProvider) : base(context)
        {
            this._context = context;
            _protectionProvider = p_protectionProvider;
        }
        public async Task<IEnumerable<Color>> GetAll()
        {
            var Colors = await this.Query().SelectAsync();

            return Colors;
        }

        public async Task<Color> GetById(int id)
        {

            var Colors = await this.Query().SingleOrDefaultAsync(c=>c.ColorId==id,CancellationToken.None);

            return Colors;
        }
    }
}
