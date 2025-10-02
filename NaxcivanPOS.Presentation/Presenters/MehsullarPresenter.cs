using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Entities.Models;
using NaxcivanPOS.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaxcivanPOS.Presentation.Presenters
{
    /// <summary>
    /// Məhsullar presenter sinifi (MVP nümunəsi üçün)
    /// </summary>
    public class MehsullarPresenter
    {
        private readonly IMehsullarView _view;
        private readonly IMehsulYonetimi _mehsulYonetimi;

        public MehsullarPresenter(IMehsullarView view, IMehsulYonetimi mehsulYonetimi)
        {
            _view = view;
            _mehsulYonetimi = mehsulYonetimi;
            
            _view.LoadMehsullar += OnLoadMehsullar;
            _view.MehsulElaveEt += OnMehsulElaveEt;
            _view.MehsulDuzelt += OnMehsulDuzelt;
            _view.MehsulSil += OnMehsulSil;
            _view.MehsulAxtar += OnMehsulAxtar;
        }

        private async void OnLoadMehsullar()
        {
            try
            {
                var mehsullar = await _mehsulYonetimi.GetAllMehsullarAsync();
                _view.Mehsullar = mehsullar.ToList();
            }
            catch (Exception ex)
            {
                _view.MesajGoster?.Invoke($"Məhsullar yüklənərkən səhv baş verdi: {ex.Message}");
            }
        }

        private async void OnMehsulElaveEt(Mehsul mehsul)
        {
            try
            {
                var yeniMehsul = await _mehsulYonetimi.CreateMehsulAsync(
                    mehsul.Ad,
                    mehsul.Qiymet,
                    mehsul.Miqdar,
                    mehsul.KateqoriyaId
                );
                
                OnLoadMehsullar(); // Yeni məhsulları yüklə
                _view.MesajGoster?.Invoke("Məhsul uğurla əlavə olundu!");
            }
            catch (Exception ex)
            {
                _view.MesajGoster?.Invoke($"Məhsul əlavə olunarkən səhv baş verdi: {ex.Message}");
            }
        }

        private async void OnMehsulDuzelt(Mehsul mehsul)
        {
            try
            {
                var yenilenmisMehsul = await _mehsulYonetimi.UpdateMehsulAsync(
                    mehsul.Id,
                    mehsul.Ad,
                    mehsul.Qiymet,
                    mehsul.Miqdar,
                    mehsul.KateqoriyaId
                );
                
                if (yenilenmisMehsul != null)
                {
                    OnLoadMehsullar(); // Yenilənmiş məhsulları yüklə
                    _view.MesajGoster?.Invoke("Məhsul uğurla yeniləndi!");
                }
                else
                {
                    _view.MesajGoster?.Invoke("Məhsul tapılmadı!");
                }
            }
            catch (Exception ex)
            {
                _view.MesajGoster?.Invoke($"Məhsul yenilənərkən səhv baş verdi: {ex.Message}");
            }
        }

        private async void OnMehsulSil(int mehsulId)
        {
            try
            {
                bool netice = await _mehsulYonetimi.DeleteMehsulAsync(mehsulId);
                
                if (netice)
                {
                    OnLoadMehsullar(); // Silinmiş məhsulları yüklə
                    _view.MesajGoster?.Invoke("Məhsul uğurla silindi!");
                }
                else
                {
                    _view.MesajGoster?.Invoke("Məhsul tapılmadı!");
                }
            }
            catch (Exception ex)
            {
                _view.MesajGoster?.Invoke($"Məhsul silinərkən səhv baş verdi: {ex.Message}");
            }
        }

        private async void OnMehsulAxtar(string axtarisSozu)
        {
            try
            {
                var mehsullar = await _mehsulYonetimi.SearchMehsullarAsync(axtarisSozu);
                _view.Mehsullar = mehsullar.ToList();
            }
            catch (Exception ex)
            {
                _view.MesajGoster?.Invoke($"Məhsullar axtarılırarkən səhv baş verdi: {ex.Message}");
            }
        }
    }
}