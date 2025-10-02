using NaxcivanPOS.Entities.Models;
using System;
using System.Windows.Forms;

namespace NaxcivanPOS.Presentation.Forms
{
    public partial class MehsulForm : Form
    {
        public Mehsul Mehsul { get; set; } = new Mehsul { Ad = "" };

        public MehsulForm()
        {
            InitializeComponent();
        }

        private void MehsulForm_Load(object sender, EventArgs e)
        {
            txtAd.Text = Mehsul.Ad;
            txtQiymet.Text = Mehsul.Qiymet.ToString();
            txtMiqdar.Text = Mehsul.Miqdar.ToString();
            // Kateqoriya seçimi üçün ComboBox əlavə olunacaq
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Mehsul.Ad = txtAd.Text.Trim();
                Mehsul.Qiymet = decimal.Parse(txtQiymet.Text);
                Mehsul.Miqdar = int.Parse(txtMiqdar.Text);
                
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImtina_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}