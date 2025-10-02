using MaterialSkin;
using MaterialSkin.Controls;
using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Entities.Models;
using NaxcivanPOS.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaxcivanPOS.Presentation.Forms
{
    public partial class AnaForm : MaterialForm, IMehsullarView
    {
        // YENİ: Servislər artıq konstruktor vasitəsilə inject edilir
        private readonly IMehsulYonetimi _mehsulYonetimi;
        private readonly ISatisEmeliyyatlari _satisEmeliyyatlari;
        private readonly Func<SatisForm> _satisFormFactory;
        private readonly Func<MehsulForm> _mehsulFormFactory;
        private readonly Func<AxtarisForm> _axtarisFormFactory;

        // REFAKTOR EDİLDİ: Konstruktor vasitəsilə asılılıqlar inject edilir
        public AnaForm(IMehsulYonetimi mehsulYonetimi, ISatisEmeliyyatlari satisEmeliyyatlari,
                      Func<SatisForm> satisFormFactory,
                      Func<MehsulForm> mehsulFormFactory,
                      Func<AxtarisForm> axtarisFormFactory)
        {
            InitializeComponent();
            
            _mehsulYonetimi = mehsulYonetimi;
            _satisEmeliyyatlari = satisEmeliyyatlari;
            _satisFormFactory = satisFormFactory;
            _mehsulFormFactory = mehsulFormFactory;
            _axtarisFormFactory = axtarisFormFactory;
            
            // MaterialSkin manager konfiqurasiyası
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private async void AnaForm_Load(object sender, EventArgs e)
        {
            await LoadMehsullar();
            await SetupSatisTab();
        }

        private async Task LoadMehsullar()
        {
            try
            {
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
            // REFAKTOR EDİLDİ: async/await ilə try-catch-finally bloku əlavə olunub
            btnMehsulElaveEt.Enabled = false; // Əməliyyat zamanı düyməni deaktiv et
            try
            {
                // Məhsul əlavə etmə dialoqu
                using (var dialog = _mehsulFormFactory())
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
                        var yeniMehsul = await _mehsulYonetimi.CreateMehsulAsync(
                            dialog.Mehsul.Ad,
                            dialog.Mehsul.Qiymet,
                            dialog.Mehsul.Miqdar,
                            dialog.Mehsul.KateqoriyaId
                        );
                        
                        await LoadMehsullar();
                        MessageBox.Show("Məhsul uğurla əlavə olundu!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul əlavə olunarkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnMehsulElaveEt.Enabled = true; // Həmişə düyməni aktiv et
            }
        }

        private async void btnMehsulDuzelt_Click(object sender, EventArgs e)
        {
            // REFAKTOR EDİLDİ: async/await ilə try-catch-finally bloku əlavə olunub
            btnMehsulDuzelt.Enabled = false; // Əməliyyat zamanı düyməni deaktiv et
            try
            {
                if (dataGridViewMehsullar.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa redaktə etmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var seciliMehsul = (Mehsul)dataGridViewMehsullar.SelectedRows[0].DataBoundItem;
                using (var dialog = _mehsulFormFactory())
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul yenilənərkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnMehsulDuzelt.Enabled = true; // Həmişə düyməni aktiv et
            }
        }

        private async void btnMehsulSil_Click(object sender, EventArgs e)
        {
            // REFAKTOR EDİLDİ: async/await ilə try-catch-finally bloku əlavə olunub
            btnMehsulSil.Enabled = false; // Əməliyyat zamanı düyməni deaktiv et
            try
            {
                if (dataGridViewMehsullar.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa silmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var seciliMehsul = (Mehsul)dataGridViewMehsullar.SelectedRows[0].DataBoundItem;
                var cavab = MessageBox.Show($"'{seciliMehsul.Ad}' adlı məhsulu silmək istədiyinizə əminsiniz?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cavab == DialogResult.Yes)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul silinərkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnMehsulSil.Enabled = true; // Həmişə düyməni aktiv et
            }
        }

        private async void btnAxtar_Click(object sender, EventArgs e)
        {
            // REFAKTOR EDİLDİ: async/await ilə try-catch-finally bloku əlavə olunub
            btnAxtar.Enabled = false; // Əməliyyat zamanı düyməni deaktiv et
            try
            {
                using (var axtarisDialog = _axtarisFormFactory())
                {
                    if (axtarisDialog.ShowDialog() == DialogResult.OK)
                    {
                        var mehsullar = await _mehsulYonetimi.SearchMehsullarAsync(axtarisDialog.AxtarisSozu);
                        dataGridViewMehsullar.DataSource = mehsullar.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsullar axtarılırarkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAxtar.Enabled = true; // Həmişə düyməni aktiv et
            }
        }

        private async Task SetupSatisTab()
        {
            // Satış tabında satış funksionallığını əlavə et
            tabPageSatis.Controls.Clear();
            
            // REFAKTOR EDİLDİ: Satış formunu factory ilə yarat
            var satisForm = _satisFormFactory();
            satisForm.TopLevel = false;
            satisForm.FormBorderStyle = FormBorderStyle.None;
            satisForm.Dock = DockStyle.Fill;
            tabPageSatis.Controls.Add(satisForm);
            satisForm.Show();
        }

        // MVP interfeys implementasiyası - Açıq interface implementasiyası
        IList<Mehsul> IMehsullarView.Mehsullar 
        { 
            get => (IList<Mehsul>)dataGridViewMehsullar.DataSource; 
            set => dataGridViewMehsullar.DataSource = value; 
        }

        event Action IMehsullarView.LoadMehsullar
        {
            add { }
            remove { }
        }

        event Action<Mehsul> IMehsullarView.MehsulElaveEt
        {
            add { }
            remove { }
        }

        event Action<Mehsul> IMehsullarView.MehsulDuzelt
        {
            add { }
            remove { }
        }

        event Action<int> IMehsullarView.MehsulSil
        {
            add { }
            remove { }
        }

        event Action<string> IMehsullarView.MehsulAxtar
        {
            add { }
            remove { }
        }
        
        Action<string> IMehsullarView.MesajGoster
        {
            get => (msg) => MessageBox.Show(msg, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            set { }
        }
    }
}