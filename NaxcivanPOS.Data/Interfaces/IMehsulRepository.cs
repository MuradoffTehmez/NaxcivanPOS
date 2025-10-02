using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Entities.Models;

namespace NaxcivanPOS.Data.Interfaces
{
    /// <summary>
    /// Məhsul üçün xüsusi repository interfeysi
    /// </summary>
    public interface IMehsulRepository : IRepository<Mehsul>
    {
        Task<Mehsul> GetByAdAsync(string ad);
        Task<IEnumerable<Mehsul>> GetByQiymetRangeAsync(decimal minQiymet, decimal maxQiymet);
    }
}