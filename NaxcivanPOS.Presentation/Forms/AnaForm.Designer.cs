namespace NaxcivanPOS.Presentation.Forms
{
    partial class AnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewMehsullar = new DataGridView();
            tabPageMehsullar = new TabPage();
            tabPageSatis = new TabPage();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPageRaporlar = new TabPage();
            tabPageAyarlar = new TabPage();
            btnMehsulElaveEt = new MaterialSkin.Controls.MaterialButton();
            btnMehsulDuzelt = new MaterialSkin.Controls.MaterialButton();
            btnMehsulSil = new MaterialSkin.Controls.MaterialButton();
            btnAxtar = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMehsullar).BeginInit();
            materialTabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewMehsullar
            // 
            dataGridViewMehsullar.AllowUserToAddRows = false;
            dataGridViewMehsullar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewMehsullar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewMehsullar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMehsullar.BackgroundColor = Color.White;
            dataGridViewMehsullar.BorderStyle = BorderStyle.None;
            dataGridViewMehsullar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewMehsullar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewMehsullar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewMehsullar.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewMehsullar.Dock = DockStyle.Fill;
            dataGridViewMehsullar.GridColor = Color.FromArgb(224, 224, 224);
            dataGridViewMehsullar.Location = new Point(3, 83);
            dataGridViewMehsullar.Name = "dataGridViewMehsullar";
            dataGridViewMehsullar.ReadOnly = true;
            dataGridViewMehsullar.RowHeadersVisible = false;
            dataGridViewMehsullar.RowHeadersWidth = 51;
            dataGridViewMehsullar.Size = new Size(794, 433);
            dataGridViewMehsullar.TabIndex = 1;
            // 
            // tabPageMehsullar
            // 
            tabPageMehsullar.Controls.Add(btnAxtar);
            tabPageMehsullar.Controls.Add(btnMehsulSil);
            tabPageMehsullar.Controls.Add(btnMehsulDuzelt);
            tabPageMehsullar.Controls.Add(btnMehsulElaveEt);
            tabPageMehsullar.Controls.Add(dataGridViewMehsullar);
            tabPageMehsullar.Location = new Point(4, 24);
            tabPageMehsullar.Name = "tabPageMehsullar";
            tabPageMehsullar.Padding = new Padding(3);
            tabPageMehsullar.Size = new Size(800, 519);
            tabPageMehsullar.TabIndex = 0;
            tabPageMehsullar.Text = "Məhsullar";
            tabPageMehsullar.UseVisualStyleBackColor = true;
            // 
            // tabPageSatis
            // 
            tabPageSatis.Location = new Point(4, 24);
            tabPageSatis.Name = "tabPageSatis";
            tabPageSatis.Padding = new Padding(3);
            tabPageSatis.Size = new Size(800, 519);
            tabPageSatis.TabIndex = 1;
            tabPageSatis.Text = "Satış";
            tabPageSatis.UseVisualStyleBackColor = true;
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPageMehsullar);
            materialTabControl1.Controls.Add(tabPageSatis);
            materialTabControl1.Controls.Add(tabPageRaporlar);
            materialTabControl1.Controls.Add(tabPageAyarlar);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(808, 547);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPageRaporlar
            // 
            tabPageRaporlar.Location = new Point(4, 24);
            tabPageRaporlar.Name = "tabPageRaporlar";
            tabPageRaporlar.Size = new Size(800, 519);
            tabPageRaporlar.TabIndex = 2;
            tabPageRaporlar.Text = "Raporlar";
            tabPageRaporlar.UseVisualStyleBackColor = true;
            // 
            // tabPageAyarlar
            // 
            tabPageAyarlar.Location = new Point(4, 24);
            tabPageAyarlar.Name = "tabPageAyarlar";
            tabPageAyarlar.Size = new Size(800, 519);
            tabPageAyarlar.TabIndex = 3;
            tabPageAyarlar.Text = "Ayarlar";
            tabPageAyarlar.UseVisualStyleBackColor = true;
            // 
            // btnMehsulElaveEt
            // 
            btnMehsulElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMehsulElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMehsulElaveEt.Depth = 0;
            btnMehsulElaveEt.HighEmphasis = true;
            btnMehsulElaveEt.Icon = null;
            btnMehsulElaveEt.Location = new Point(6, 6);
            btnMehsulElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnMehsulElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulElaveEt.Name = "btnMehsulElaveEt";
            btnMehsulElaveEt.NoAccentTextColor = Color.Empty;
            btnMehsulElaveEt.Size = new Size(101, 36);
            btnMehsulElaveEt.TabIndex = 2;
            btnMehsulElaveEt.Text = "Əlavə Et";
            btnMehsulElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMehsulElaveEt.UseCompatibleTextRendering = true;
            btnMehsulElaveEt.UseVisualStyleBackColor = true;
            // 
            // btnMehsulDuzelt
            // 
            btnMehsulDuzelt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMehsulDuzelt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMehsulDuzelt.Depth = 0;
            btnMehsulDuzelt.HighEmphasis = true;
            btnMehsulDuzelt.Icon = null;
            btnMehsulDuzelt.Location = new Point(112, 6);
            btnMehsulDuzelt.Margin = new Padding(4, 6, 4, 6);
            btnMehsulDuzelt.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulDuzelt.Name = "btnMehsulDuzelt";
            btnMehsulDuzelt.NoAccentTextColor = Color.Empty;
            btnMehsulDuzelt.Size = new Size(101, 36);
            btnMehsulDuzelt.TabIndex = 3;
            btnMehsulDuzelt.Text = "Düzəlt";
            btnMehsulDuzelt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMehsulDuzelt.UseCompatibleTextRendering = true;
            btnMehsulDuzelt.UseVisualStyleBackColor = true;
            // 
            // btnMehsulSil
            // 
            btnMehsulSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMehsulSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMehsulSil.Depth = 0;
            btnMehsulSil.HighEmphasis = true;
            btnMehsulSil.Icon = null;
            btnMehsulSil.Location = new Point(218, 6);
            btnMehsulSil.Margin = new Padding(4, 6, 4, 6);
            btnMehsulSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulSil.Name = "btnMehsulSil";
            btnMehsulSil.NoAccentTextColor = Color.Empty;
            btnMehsulSil.Size = new Size(101, 36);
            btnMehsulSil.TabIndex = 4;
            btnMehsulSil.Text = "Sil";
            btnMehsulSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMehsulSil.UseCompatibleTextRendering = true;
            btnMehsulSil.UseVisualStyleBackColor = true;
            // 
            // btnAxtar
            // 
            btnAxtar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAxtar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAxtar.Depth = 0;
            btnAxtar.HighEmphasis = true;
            btnAxtar.Icon = null;
            btnAxtar.Location = new Point(324, 6);
            btnAxtar.Margin = new Padding(4, 6, 4, 6);
            btnAxtar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAxtar.Name = "btnAxtar";
            btnAxtar.NoAccentTextColor = Color.Empty;
            btnAxtar.Size = new Size(101, 36);
            btnAxtar.TabIndex = 5;
            btnAxtar.Text = "Axtar";
            btnAxtar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAxtar.UseCompatibleTextRendering = true;
            btnAxtar.UseVisualStyleBackColor = true;
            // 
            // AnaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 614);
            Controls.Add(materialTabControl1);
            Name = "AnaForm";
            Text = "NaxcivanPOS";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMehsullar).EndInit();
            materialTabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMehsullar;
        private TabPage tabPageMehsullar;
        private TabPage tabPageSatis;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPageRaporlar;
        private TabPage tabPageAyarlar;
        private MaterialSkin.Controls.MaterialButton btnMehsulElaveEt;
        private MaterialSkin.Controls.MaterialButton btnMehsulDuzelt;
        private MaterialSkin.Controls.MaterialButton btnMehsulSil;
        private MaterialSkin.Controls.MaterialButton btnAxtar;
    }
}