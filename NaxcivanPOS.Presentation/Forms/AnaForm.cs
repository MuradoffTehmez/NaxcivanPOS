using MaterialSkin;
using MaterialSkin.Controls;
using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Business.Services;
using NaxcivanPOS.Data;
using NaxcivanPOS.Data.Contexts;
using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Data.Repositories;
using NaxcivanPOS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaxcivanPOS.Presentation.Forms
{
    public partial class AnaForm : MaterialForm
    {
        private IMehsulYonetimi? _mehsulYonetimi;
        private ISatisEmeliyyatlari? _satisEmeliyyatlari;

        public AnaForm()
        {
            InitializeComponent();
            
            // MaterialSkin manager konfiqurasiyası
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            
            // Servisləri başlat
            InitializeServices();
        }

        private void InitializeServices()
        {
            // DbContext yarat
            var context = new NaxcivanPOSContext();
            
            // Unit of Work yarat
            var unitOfWork = new UnitOfWork(context);
            
            // İş məntiqi siniflərini yarat
            _mehsulYonetimi = new MehsulYonetimi(unitOfWork);
            _satisEmeliyyatlari = new SatisEmeliyyatlari(unitOfWork);
        }

        private async void AnaForm_Load(object sender, EventArgs e)
        {
            await LoadMehsullar();
            SetupSatisTab();
        }

        private async Task LoadMehsullar()
        {
            try
            {
                if (_mehsulYonetimi == null)
                {
                    MessageBox.Show("Xəta: Məhsul idarəetmə sistemi işə salınmayıb.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                var mehsullar = await _mehsulYonetimi.GetAllMehsullarAsync();
                dataGridViewMehsullar.DataSource = mehsullar.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsullar yüklənərkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnMehsulElaveEt_Click(object sender, EventArgs e)
        {
            if (_mehsulYonetimi == null)
            {
                MessageBox.Show("Xəta: Məhsul idarəetmə sistemi işə salınmayıb.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Məhsul əlavə etmə dialoqu
            using (var dialog = new MehsulForm())
            {
                dialog.Text = "Yeni Məhsul Əlavə Et";
                dialog.Mehsul = new Mehsul
                {
                    Ad = "",
                    Qiymet = 0,
                    Miqdar = 0
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var yeniMehsul = await _mehsulYonetimi.CreateMehsulAsync(
                            dialog.Mehsul.Ad,
                            dialog.Mehsul.Qiymet,
                            dialog.Mehsul.Miqdar,
                            dialog.Mehsul.KateqoriyaId
                        );
                        
                        await LoadMehsullar();
                        MessageBox.Show("Məhsul uğurla əlavə olundu!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Məhsul əlavə olunarkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnMehsulDuzelt_Click(object sender, EventArgs e)
        {
            if (_mehsulYonetimi == null)
            {
                MessageBox.Show("Xəta: Məhsul idarəetmə sistemi işə salınmayıb.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridViewMehsullar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa redaktə etmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var seciliMehsul = (Mehsul)dataGridViewMehsullar.SelectedRows[0].DataBoundItem;
            using (var dialog = new MehsulForm())
            {
                dialog.Text = "Məhsulu Redaktə Et";
                dialog.Mehsul = new Mehsul
                {
                    Id = seciliMehsul.Id,
                    Ad = seciliMehsul.Ad,
                    Qiymet = seciliMehsul.Qiymet,
                    Miqdar = seciliMehsul.Miqdar,
                    KateqoriyaId = seciliMehsul.KateqoriyaId
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var yenilenmisMehsul = await _mehsulYonetimi.UpdateMehsulAsync(
                            dialog.Mehsul.Id,
                            dialog.Mehsul.Ad,
                            dialog.Mehsul.Qiymet,
                            dialog.Mehsul.Miqdar,
                            dialog.Mehsul.KateqoriyaId
                        );
                        
                        if (yenilenmisMehsul != null)
                        {
                            await LoadMehsullar();
                            MessageBox.Show("Məhsul uğurla yeniləndi!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Məhsul tapılmadı!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Məhsul yenilənərkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnMehsulSil_Click(object sender, EventArgs e)
        {
            if (_mehsulYonetimi == null)
            {
                MessageBox.Show("Xəta: Məhsul idarəetmə sistemi işə salınmayıb.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridViewMehsullar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa silmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var seciliMehsul = (Mehsul)dataGridViewMehsullar.SelectedRows[0].DataBoundItem;
            var cavab = MessageBox.Show($"'{seciliMehsul.Ad}' adlı məhsulu silmək istədiyinizə əminsiniz?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cavab == DialogResult.Yes)
            {
                try
                {
                    bool netice = await _mehsulYonetimi.DeleteMehsulAsync(seciliMehsul.Id);
                    if (netice)
                    {
                        await LoadMehsullar();
                        MessageBox.Show("Məhsul uğurla silindi!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Məhsul tapılmadı!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Məhsul silinərkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnAxtar_Click(object sender, EventArgs e)
        {
            if (_mehsulYonetimi == null)
            {
                MessageBox.Show("Xəta: Məhsul idarəetmə sistemi işə salınmayıb.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var axtarisDialog = new AxtarisForm())
            {
                if (axtarisDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var mehsullar = await _mehsulYonetimi.SearchMehsullarAsync(axtarisDialog.AxtarisSozu);
                        dataGridViewMehsullar.DataSource = mehsullar.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Məhsullar axtarılırarkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SetupSatisTab()
        {
            // Satış tabında satış formunu əlavə et
            tabPageSatis.Controls.Clear();
            
            var satisForm = new SatisForm();
            satisForm.Top = 0;
            satisForm.Left = 0;
            satisForm.Dock = DockStyle.Fill;
            satisForm.FormBorderStyle = FormBorderStyle.None;
            satisForm.Visible = true;
            
            tabPageSatis.Controls.Add(satisForm);
            satisForm.Show();
        }
    }
}