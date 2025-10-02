using NaxcivanPOS.Data.Contexts;
using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Data.Repositories;

namespace NaxcivanPOS.Data
{
    /// <summary>
    /// Unit of Work sinfi
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NaxcivanPOSContext _context;
        private IMehsulRepository? _mehsulRepository;
        private ISatisRepository? _satisRepository;

        public UnitOfWork(NaxcivanPOSContext context)
        {
            _context = context;
        }

        public IMehsulRepository MehsulRepository
        {
            get
            {
                if (_mehsulRepository == null)
                {
                    _mehsulRepository = new MehsulRepository(_context);
                }
                return _mehsulRepository;
            }
        }

        public ISatisRepository SatisRepository
        {
            get
            {
                if (_satisRepository == null)
                {
                    _satisRepository = new SatisRepository(_context);
                }
                return _satisRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}