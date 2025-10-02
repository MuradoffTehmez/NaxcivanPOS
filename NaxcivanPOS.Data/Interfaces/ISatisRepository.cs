using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Entities.Models;

namespace NaxcivanPOS.Data.Interfaces
{
    /// <summary>
    /// Satış üçün xüsusi repository interfeysi
    /// </summary>
    public interface ISatisRepository : IRepository<Satis>
    {
        Task<IEnumerable<Satis>> GetByTarixRangeAsync(DateTime baslangic, DateTime bitis);
        Task<IEnumerable<Satis>> GetByMehsulIdAsync(int mehsulId);
        Task<decimal> GetCemSatishMeblegiAsync(DateTime baslangic, DateTime bitis);
    }
}