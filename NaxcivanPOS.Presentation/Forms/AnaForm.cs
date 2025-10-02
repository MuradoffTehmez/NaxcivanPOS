using MaterialSkin;
using MaterialSkin.Controls;
using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Business.Services;
using NaxcivanPOS.Data;
using NaxcivanPOS.Data.Contexts;

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
    }
}