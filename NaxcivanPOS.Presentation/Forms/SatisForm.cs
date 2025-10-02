using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaxcivanPOS.Presentation.Forms
{
    public partial class SatisForm : Form
    {
        // YENİ: Servislər artıq konstruktor vasitəsilə inject edilir
        private readonly ISatisEmeliyyatlari _satisEmeliyyatlari;
        private readonly IMehsulYonetimi _mehsulYonetimi;
        private List<Mehsul> _mehsullar = new List<Mehsul>();
        private List<Satis> _satislar = new List<Satis>();

        // REFAKTOR EDİLDİ: Konstruktor vasitəsilə asılılıqlar inject edilir
        public SatisForm(ISatisEmeliyyatlari satisEmeliyyatlari, IMehsulYonetimi mehsulYonetimi)
        {
            InitializeComponent();
            
            _satisEmeliyyatlari = satisEmeliyyatlari;
            _mehsulYonetimi = mehsulYonetimi;
            
            LoadMehsullar();
        }

        private async void LoadMehsullar()
        {
            try
            {
                _mehsullar = (await _mehsulYonetimi.GetAllMehsullarAsync()).ToList();
                cmbMehsullar.DataSource = _mehsullar;
                cmbMehsullar.DisplayMember = "Ad";
                cmbMehsullar.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsullar yüklənərkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElaveEt_Click(object sender, EventArgs e)
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
                var mehsul = _mehsullar.FirstOrDefault(m => m.Id == mehsulId);
                
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
                var row = new DataGridViewRow();
                row.CreateCells(dataGridViewSatis);
                row.Cells[0].Value = satilanMehsul.Id;
                row.Cells[1].Value = satilanMehsul.Ad;
                row.Cells[2].Value = satilanMehsul.Qiymet;
                row.Cells[3].Value = satilanMehsul.Say;
                row.Cells[4].Value = satilanMehsul.Toplam;

                dataGridViewSatis.Rows.Add(row);
                
                // Toplamı hesabla
                HesablaToplam();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul satış sətiri əlavə olunarkən səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HesablaToplam()
        {
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

        private async void btnSatisEt_Click(object sender, EventArgs e)
        {
            // REFAKTOR EDİLDİ: async/await ilə try-catch-finally bloku əlavə olunub
            btnSatisEt.Enabled = false; // Əməliyyat zamanı düyməni deaktiv et
            btnImtina.Enabled = false;
            
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
                    HesablaToplam();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış əməliyyatı zamanı səhv baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSatisEt.Enabled = true; // Həmişə düyməni aktiv et
                btnImtina.Enabled = true;
            }
        }

        private void btnImtina_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}