using System;
using System.Threading.Tasks;

namespace NaxcivanPOS.Data.Interfaces
{
    /// <summary>
    /// Unit of Work interfeysi
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IMehsulRepository MehsulRepository { get; }
        ISatisRepository SatisRepository { get; }
        Task<int> SaveChangesAsync();
    }
}