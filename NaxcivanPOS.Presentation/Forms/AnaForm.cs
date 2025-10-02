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

        // REFAKTOR EDİLDİ: Konstruktor vasitəsilə asılılıqlar inject edilir
        public AnaForm(IMehsulYonetimi mehsulYonetimi, ISatisEmeliyyatlari satisEmeliyyatlari)
        {
            InitializeComponent();
            
            _mehsulYonetimi = mehsulYonetimi;
            _satisEmeliyyatlari = satisEmeliyyatlari;
            
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
                using (var axtarisDialog = new AxtarisForm())
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
            
            // Satış üçün kontrollər əlavə edirik
            var cmbMehsullar = new ComboBox()
            {
                Location = new System.Drawing.Point(12, 25),
                Size = new System.Drawing.Size(250, 23),
                Name = "cmbMehsullar"
            };
            
            var label1 = new Label()
            {
                Text = "Məhsul:",
                Location = new System.Drawing.Point(12, 7),
                Size = new System.Drawing.Size(49, 15)
            };
            
            var label2 = new Label()
            {
                Text = "Sayı:",
                Location = new System.Drawing.Point(268, 7),
                Size = new System.Drawing.Size(32, 15)
            };
            
            var txtSay = new TextBox()
            {
                Location = new System.Drawing.Point(268, 25),
                Size = new System.Drawing.Size(100, 23),
                Text = "1",
                Name = "txtSay"
            };
            
            var btnElaveEt = new Button()
            {
                Text = "Əlavə Et",
                Location = new System.Drawing.Point(374, 24),
                Size = new System.Drawing.Size(75, 23),
                Name = "btnElaveEt"
            };
            
            var dataGridViewSatis = new DataGridView()
            {
                Location = new System.Drawing.Point(12, 54),
                Size = new System.Drawing.Size(776, 315),
                Name = "dataGridViewSatis"
            };
            
            var btnSatisEt = new Button()
            {
                Text = "Sat",
                Location = new System.Drawing.Point(632, 375),
                Size = new System.Drawing.Size(75, 23),
                Name = "btnSatisEt"
            };
            
            var btnImtina = new Button()
            {
                Text = "İmtina",
                Location = new System.Drawing.Point(713, 375),
                Size = new System.Drawing.Size(75, 23),
                Name = "btnImtina"
            };
            
            var lblToplam = new Label()
            {
                Text = "Toplam: 0 AZN",
                Location = new System.Drawing.Point(12, 375),
                Size = new System.Drawing.Size(76, 20),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold),
                Name = "lblToplam"
            };
            
            // Əlavə et düyməsinə hadisə əlavə edirik
            btnElaveEt.Click += async (sender, e) => await SatisFormBtnElaveEt_Click(cmbMehsullar, txtSay, dataGridViewSatis, lblToplam);
            btnSatisEt.Click += async (sender, e) => await SatisFormBtnSatisEt_Click(dataGridViewSatis);
            btnImtina.Click += (sender, e) => tabPageSatis.Controls.Clear(); // or any reset logic
            
            tabPageSatis.Controls.Add(cmbMehsullar);
            tabPageSatis.Controls.Add(label1);
            tabPageSatis.Controls.Add(label2);
            tabPageSatis.Controls.Add(txtSay);
            tabPageSatis.Controls.Add(btnElaveEt);
            tabPageSatis.Controls.Add(dataGridViewSatis);
            tabPageSatis.Controls.Add(btnSatisEt);
            tabPageSatis.Controls.Add(btnImtina);
            tabPageSatis.Controls.Add(lblToplam);
            
            // Məhsulları yüklə
            await LoadMehsullarForSatis(cmbMehsullar);
        }

        private async Task LoadMehsullarForSatis(ComboBox cmbMehsullar)
        {
            try
            {
                var mehsullar = await _mehsulYonetimi.GetAllMehsullarAsync();
                cmbMehsullar.DataSource = mehsullar.ToList();
                cmbMehsullar.DisplayMember = "Ad";
                cmbMehsullar.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsullar yüklənərkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SatisFormBtnElaveEt_Click(ComboBox cmbMehsullar, TextBox txtSay, DataGridView dataGridViewSatis, Label lblToplam)
        {
            try
            {
                if (cmbMehsullar.SelectedValue == null)
                {
                    MessageBox.Show("Zəhmət olmasa məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtSay.Text, out int say) || say <= 0)
                {
                    MessageBox.Show("Ədəd müsbət olmalıdır.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var mehsulId = (int)cmbMehsullar.SelectedValue;
                var mehsullar = (await _mehsulYonetimi.GetAllMehsullarAsync()).ToList();
                var mehsul = mehsullar.FirstOrDefault(m => m.Id == mehsulId);
                
                if (mehsul == null)
                {
                    MessageBox.Show("Məhsul tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (mehsul.Miqdar < say)
                {
                    MessageBox.Show("Kifayət qədər məhsul yoxdur.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Yeni sətir yarat
                var satilanMehsul = new
                {
                    Id = mehsul.Id,
                    Ad = mehsul.Ad,
                    Qiymet = mehsul.Qiymet,
                    Say = say,
                    Toplam = mehsul.Qiymet * say
                };

                // DataGridView-ə əlavə et
                var yeniRow = new DataGridViewRow();
                yeniRow.CreateCells(dataGridViewSatis);
                yeniRow.Cells[0].Value = satilanMehsul.Id;
                yeniRow.Cells[1].Value = satilanMehsul.Ad;
                yeniRow.Cells[2].Value = satilanMehsul.Qiymet;
                yeniRow.Cells[3].Value = satilanMehsul.Say;
                yeniRow.Cells[4].Value = satilanMehsul.Toplam;

                dataGridViewSatis.Rows.Add(yeniRow);
                
                // Toplamı hesabla
                decimal cem = 0;
                foreach (DataGridViewRow row in dataGridViewSatis.Rows)
                {
                    if (row.Cells[4].Value != null)
                    {
                        cem += Convert.ToDecimal(row.Cells[4].Value);
                    }
                }
                lblToplam.Text = $"Toplam: {cem} AZN";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul satış sətiri əlavə olunarkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SatisFormBtnSatisEt_Click(DataGridView dataGridViewSatis)
        {
            // REFAKTOR EDİLDİ: async/await ilə try-catch-finally bloku əlavə olunub
            var btnSatisEt = tabPageSatis.Controls.Find("btnSatisEt", true).FirstOrDefault() as Button;
            if (btnSatisEt != null) btnSatisEt.Enabled = false;
            
            var btnImtina = tabPageSatis.Controls.Find("btnImtina", true).FirstOrDefault() as Button;
            if (btnImtina != null) btnImtina.Enabled = false;
            
            try
            {
                if (dataGridViewSatis.Rows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa ən azı bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cavab = MessageBox.Show("Satışı təsdiq edirsiniz?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cavab == DialogResult.Yes)
                {
                    // Hər bir sətir üçün satış əməliyyatı et
                    foreach (DataGridViewRow row in dataGridViewSatis.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            var mehsulId = Convert.ToInt32(row.Cells[0].Value);
                            var say = Convert.ToInt32(row.Cells[3].Value);
                            
                            await _satisEmeliyyatlari.CreateSatisAsync(mehsulId, say);
                        }
                    }
                    
                    MessageBox.Show("Satış uğurla həyata keçirildi!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // DataGridView-i təmizlə
                    dataGridViewSatis.Rows.Clear();
                    
                    // Toplam etiketini sıfırla
                    var lblToplam = tabPageSatis.Controls.Find("lblToplam", true).FirstOrDefault() as Label;
                    if (lblToplam != null)
                        lblToplam.Text = "Toplam: 0 AZN";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış əməliyyatı zamanı səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Həmişə düymələri aktiv et
                if (btnSatisEt != null) btnSatisEt.Enabled = true;
                if (btnImtina != null) btnImtina.Enabled = true;
            }
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