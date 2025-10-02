using NaxcivanPOS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaxcivanPOS.Business.Interfaces
{
    /// <summary>
    /// Satış əməliyyatları interfeysi
    /// </summary>
    public interface ISatisEmeliyyatlari
    {
        Task<Satis> CreateSatisAsync(int mehsulId, int say, string? isciAdi = null);
        Task<Satis> GetSatisByIdAsync(int id);
        Task<IEnumerable<Satis>> GetAllSatislarAsync();
        Task<IEnumerable<Satis>> GetSatislarByTarixRangeAsync(DateTime baslangic, DateTime bitis);
        Task<IEnumerable<Satis>> GetSatislarByMehsulIdAsync(int mehsulId);
        Task<decimal> GetCemSatishMeblegiAsync(DateTime baslangic, DateTime bitis);
    }
}