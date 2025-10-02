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
    /// Məhsul Kateqoriyası üçün xüsusi repository sinfi
    /// </summary>
    public class MehsulKateqoriyasiRepository : Repository<MehsulKateqoriyasi>, IMehsulKateqoriyasiRepository
    {
        public MehsulKateqoriyasiRepository(DbContext context) : base(context) { }

        public async Task<MehsulKateqoriyasi> GetByAdAsync(string ad)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Ad.ToLower() == ad.ToLower());
        }
    }
}