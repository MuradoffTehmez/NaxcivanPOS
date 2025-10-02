using Microsoft.EntityFrameworkCore;
using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Data.Repositories;
using NaxcivanPOS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaxcivanPOS.Data.Repositories
{
    /// <summary>
    /// Satış üçün xüsusi repository sinfi
    /// </summary>
    public class SatisRepository : Repository<Satis>, ISatisRepository
    {
        public SatisRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Satis>> GetByTarixRangeAsync(DateTime baslangic, DateTime bitis)
        {
            return await _dbSet
                .Where(s => s.Tarix >= baslangic && s.Tarix <= bitis)
                .Include(s => s.Mehsul)
                .ToListAsync();
        }

        public async Task<IEnumerable<Satis>> GetByMehsulIdAsync(int mehsulId)
        {
            return await _dbSet
                .Where(s => s.MehsulId == mehsulId)
                .Include(s => s.Mehsul)
                .ToListAsync();
        }

        public async Task<decimal> GetCemSatishMeblegiAsync(DateTime baslangic, DateTime bitis)
        {
            return await _dbSet
                .Where(s => s.Tarix >= baslangic && s.Tarix <= bitis)
                .SumAsync(s => s.ToplamQiymet);
        }
    }
}