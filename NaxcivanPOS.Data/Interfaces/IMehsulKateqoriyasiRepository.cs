using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Entities.Models;

namespace NaxcivanPOS.Data.Interfaces
{
    /// <summary>
    /// Məhsul Kateqoriyası üçün xüsusi repository interfeysi
    /// </summary>
    public interface IMehsulKateqoriyasiRepository : IRepository<MehsulKateqoriyasi>
    {
        Task<MehsulKateqoriyasi> GetByAdAsync(string ad);
    }
}