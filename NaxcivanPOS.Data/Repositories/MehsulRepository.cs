using Microsoft.EntityFrameworkCore;
using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Entities.Models;

namespace NaxcivanPOS.Data.Repositories
{
    /// <summary>
    /// Məhsul üçün xüsusi repository sinfi
    /// </summary>
    public class MehsulRepository : Repository<Mehsul>, IMehsulRepository
    {
        public MehsulRepository(DbContext context) : base(context) { }

        public async Task<Mehsul> GetByAdAsync(string ad)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Ad.ToLower() == ad.ToLower());
        }

        public async Task<IEnumerable<Mehsul>> GetByQiymetRangeAsync(decimal minQiymet, decimal maxQiymet)
        {
            return await _dbSet.Where(m => m.Qiymet >= minQiymet && m.Qiymet <= maxQiymet).ToListAsync();
        }
    }
}