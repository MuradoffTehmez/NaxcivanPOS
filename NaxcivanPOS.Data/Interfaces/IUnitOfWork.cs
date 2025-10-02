namespace NaxcivanPOS.Data.Interfaces
{
    /// <summary>
    /// Unit of Work interfeysi
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IMehsulRepository MehsulRepository { get; }
        ISatisRepository SatisRepository { get; }
        IMehsulKateqoriyasiRepository MehsulKateqoriyasiRepository { get; }
        Task<int> SaveChangesAsync();
    }
}