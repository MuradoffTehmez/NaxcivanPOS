using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaxcivanPOS.Business.Services
{
    /// <summary>
    /// Satış əməliyyatları tətbiqi
    /// </summary>
    public class SatisEmeliyyatlari : ISatisEmeliyyatlari
    {
        private readonly IUnitOfWork _unitOfWork;

        public SatisEmeliyyatlari(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Satis> CreateSatisAsync(int mehsulId, int say, string? isciAdi = null)
        {
            if (say <= 0)
                throw new ArgumentException("Satış sayı 0-dan böyük olmalıdır");

            // Məhsulu tap
            var mehsul = await _unitOfWork.MehsulRepository.GetByIdAsync(mehsulId);
            if (mehsul == null)
                throw new ArgumentException("Məhsul tapılmadı");

            // Kifayət qədər məhsul varmı yoxla
            if (mehsul.Miqdar < say)
                throw new InvalidOperationException("Kifayət qədər məhsul yoxdur");

            // Toplam qiyməti hesapla
            decimal toplamQiymet = mehsul.Qiymet * say;

            // Məhsulun sayını azalt
            mehsul.Miqdar -= say;
            mehsul.SonGuncellemeTarixi = DateTime.Now;
            _unitOfWork.MehsulRepository.Update(mehsul);

            // Yeni satış yarat
            var satis = new Satis
            {
                MehsulId = mehsulId,
                Mehsul = mehsul, // Required member
                Say = say,
                ToplamQiymet = toplamQiymet,
                Tarix = DateTime.Now,
                IsciAdi = isciAdi
            };

            // Satışı əlavə et
            await _unitOfWork.SatisRepository.AddAsync(satis);
            await _unitOfWork.SaveChangesAsync();

            return satis;
        }

        public async Task<Satis> GetSatisByIdAsync(int id)
        {
            return await _unitOfWork.SatisRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Satis>> GetAllSatislarAsync()
        {
            return await _unitOfWork.SatisRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Satis>> GetSatislarByTarixRangeAsync(DateTime baslangic, DateTime bitis)
        {
            return await _unitOfWork.SatisRepository.GetByTarixRangeAsync(baslangic, bitis);
        }

        public async Task<IEnumerable<Satis>> GetSatislarByMehsulIdAsync(int mehsulId)
        {
            return await _unitOfWork.SatisRepository.GetByMehsulIdAsync(mehsulId);
        }

        public async Task<decimal> GetCemSatishMeblegiAsync(DateTime baslangic, DateTime bitis)
        {
            return await _unitOfWork.SatisRepository.GetCemSatishMeblegiAsync(baslangic, bitis);
        }
    }
}