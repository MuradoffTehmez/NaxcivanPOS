using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaxcivanPOS.Business.Services
{
    /// <summary>
    /// Məhsul idarəetmə tətbiqi
    /// </summary>
    public class MehsulYonetimi : IMehsulYonetimi
    {
        private readonly IUnitOfWork _unitOfWork;

        public MehsulYonetimi(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Mehsul>> GetAllMehsullarAsync()
        {
            return await _unitOfWork.MehsulRepository.GetAllAsync();
        }

        public async Task<Mehsul> GetMehsulByIdAsync(int id)
        {
            return await _unitOfWork.MehsulRepository.GetByIdAsync(id);
        }

        public async Task<Mehsul> GetMehsulByAdAsync(string ad)
        {
            return await _unitOfWork.MehsulRepository.GetByAdAsync(ad);
        }

        public async Task<Mehsul> CreateMehsulAsync(string ad, decimal qiymet, int miqdar, int? kateqoriyaId = null)
        {
            // Təhlükəsizlik yoxlaması - giriş yoxlaması
            if (string.IsNullOrWhiteSpace(ad))
                throw new ArgumentException("Məhsul adı boş ola bilməz");
            
            if (qiymet < 0)
                throw new ArgumentException("Qiymət mənfi ola bilməz");
            
            if (miqdar < 0)
                throw new ArgumentException("Miqdar mənfi ola bilməz");

            // Kateqoriya yoxla
            if (kateqoriyaId.HasValue)
            {
                var kateqoriya = await _unitOfWork.MehsulKateqoriyasiRepository.GetByIdAsync(kateqoriyaId.Value);
                if (kateqoriya == null)
                    throw new ArgumentException("Göstərilən kateqoriya mövcud deyil");
            }

            // Yeni məhsul yarat
            var mehsul = new Mehsul
            {
                Ad = ad.Trim(),
                Qiymet = qiymet,
                Miqdar = miqdar,
                KateqoriyaId = kateqoriyaId,
                YaradilmaTarixi = DateTime.Now,
                SonGuncellemeTarixi = DateTime.Now
            };

            // Məhsulu əlavə et
            await _unitOfWork.MehsulRepository.AddAsync(mehsul);
            await _unitOfWork.SaveChangesAsync();

            return mehsul;
        }

        public async Task<Mehsul> UpdateMehsulAsync(int id, string ad, decimal qiymet, int miqdar, int? kateqoriyaId = null)
        {
            // Təhlükəsizlik yoxlaması
            if (string.IsNullOrWhiteSpace(ad))
                throw new ArgumentException("Məhsul adı boş ola bilməz");
            
            if (qiymet < 0)
                throw new ArgumentException("Qiymət mənfi ola bilməz");
            
            if (miqdar < 0)
                throw new ArgumentException("Miqdar mənfi ola bilməz");

            // Kateqoriya yoxla
            if (kateqoriyaId.HasValue)
            {
                var kateqoriya = await _unitOfWork.MehsulKateqoriyasiRepository.GetByIdAsync(kateqoriyaId.Value);
                if (kateqoriya == null)
                    throw new ArgumentException("Göstərilən kateqoriya mövcud deyil");
            }

            // Mövcud məhsulu tap
            var mehsul = await _unitOfWork.MehsulRepository.GetByIdAsync(id);
            if (mehsul == null)
                return null;

            // Məlumatları yenilə
            mehsul.Ad = ad.Trim();
            mehsul.Qiymet = qiymet;
            mehsul.Miqdar = miqdar;
            mehsul.KateqoriyaId = kateqoriyaId;
            mehsul.SonGuncellemeTarixi = DateTime.Now;

            // Yeniləməni tətbiq et
            _unitOfWork.MehsulRepository.Update(mehsul);
            await _unitOfWork.SaveChangesAsync();

            return mehsul;
        }

        public async Task<bool> DeleteMehsulAsync(int id)
        {
            // Məhsulu tap
            var mehsul = await _unitOfWork.MehsulRepository.GetByIdAsync(id);
            if (mehsul == null)
                return false;

            // Məhsulu sil
            _unitOfWork.MehsulRepository.Remove(mehsul);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Mehsul>> GetMehsullarByQiymetRangeAsync(decimal minQiymet, decimal maxQiymet)
        {
            return await _unitOfWork.MehsulRepository.GetByQiymetRangeAsync(minQiymet, maxQiymet);
        }

        public async Task<IEnumerable<Mehsul>> SearchMehsullarAsync(string axtarisSozu)
        {
            if (string.IsNullOrWhiteSpace(axtarisSozu))
                return await _unitOfWork.MehsulRepository.GetAllAsync();

            var searchLower = axtarisSozu.ToLower();
            var mehsullar = await _unitOfWork.MehsulRepository.GetAllAsync();
            
            return mehsullar.Where(m => 
                m.Ad.ToLower().Contains(searchLower) || 
                (m.Kateqoriya != null && m.Kateqoriya.Ad.ToLower().Contains(searchLower))
            ).ToList();
        }
    }
}