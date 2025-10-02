using System;
using System.Windows.Forms;

namespace NaxcivanPOS.Presentation.Forms
{
    public partial class AxtarisForm : Form
    {
        public string AxtarisSozu { get; private set; } = "";

        public AxtarisForm()
        {
            InitializeComponent();
        }

        private void btnAxtar_Click(object sender, EventArgs e)
        {
            AxtarisSozu = txtAxtaris.Text.Trim();
            if (string.IsNullOrEmpty(AxtarisSozu))
            {
                MessageBox.Show("Zəhmət olmasa axtarış sözünü daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnImtina_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}