using NaxcivanPOS.Entities.Models;

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
        Task<Mehsul> CreateMehsulAsync(string ad, decimal qiymet, int miqdar);
        Task<Mehsul> UpdateMehsulAsync(int id, string ad, decimal qiymet, int miqdar);
        Task<bool> DeleteMehsulAsync(int id);
        Task<IEnumerable<Mehsul>> GetMehsullarByQiymetRangeAsync(decimal minQiymet, decimal maxQiymet);
    }
}