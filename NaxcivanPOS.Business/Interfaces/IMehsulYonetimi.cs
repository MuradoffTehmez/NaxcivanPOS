using NaxcivanPOS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaxcivanPOS.Business.Interfaces
{
    /// <summary>
    /// Məhsul idarəetmə interfeysi
    /// </summary>
    public interface IMehsulYonetimi
    {
        Task<IEnumerable<Mehsul>> GetAllMehsullarAsync();
        Task<Mehsul> GetMehsulByIdAsync(int id);
        Task<Mehsul> GetMehsulByAdAsync(string ad);
        Task<Mehsul> CreateMehsulAsync(string ad, decimal qiymet, int miqdar, int? kateqoriyaId = null);
        Task<Mehsul> UpdateMehsulAsync(int id, string ad, decimal qiymet, int miqdar, int? kateqoriyaId = null);
        Task<bool> DeleteMehsulAsync(int id);
        Task<IEnumerable<Mehsul>> GetMehsullarByQiymetRangeAsync(decimal minQiymet, decimal maxQiymet);
        Task<IEnumerable<Mehsul>> SearchMehsullarAsync(string axtarisSozu);
    }
}