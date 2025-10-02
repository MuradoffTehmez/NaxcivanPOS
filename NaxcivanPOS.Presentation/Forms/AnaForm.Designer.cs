namespace NaxcivanPOS.Presentation.Forms
{
    partial class AnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            dataGridViewMehsullar.Location = new Point(3, 3);
            dataGridViewMehsullar.Name = "dataGridViewMehsullar";
            dataGridViewMehsullar.ReadOnly = true;
            dataGridViewMehsullar.RowHeadersVisible = false;
            dataGridViewMehsullar.RowHeadersWidth = 51;
            dataGridViewMehsullar.Size = new Size(794, 503);
            dataGridViewMehsullar.TabIndex = 1;
            // 
            // tabPageMehsullar
            // 
            tabPageMehsullar.Controls.Add(dataGridViewMehsullar);
            tabPageMehsullar.Location = new Point(4, 24);
            tabPageMehsullar.Name = "tabPageMehsullar";
            tabPageMehsullar.Padding = new Padding(3);
            tabPageMehsullar.Size = new Size(800, 509);
            tabPageMehsullar.TabIndex = 0;
            tabPageMehsullar.Text = "Məhsullar";
            tabPageMehsullar.UseVisualStyleBackColor = true;
            // 
            // tabPageSatis
            // 
            tabPageSatis.Location = new Point(4, 24);
            tabPageSatis.Name = "tabPageSatis";
            tabPageSatis.Padding = new Padding(3);
            tabPageSatis.Size = new Size(800, 509);
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
            materialTabControl1.Size = new Size(808, 537);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPageRaporlar
            // 
            tabPageRaporlar.Location = new Point(4, 24);
            tabPageRaporlar.Name = "tabPageRaporlar";
            tabPageRaporlar.Size = new Size(800, 509);
            tabPageRaporlar.TabIndex = 2;
            tabPageRaporlar.Text = "Raporlar";
            tabPageRaporlar.UseVisualStyleBackColor = true;
            // 
            // tabPageAyarlar
            // 
            tabPageAyarlar.Location = new Point(4, 24);
            tabPageAyarlar.Name = "tabPageAyarlar";
            tabPageAyarlar.Size = new Size(800, 509);
            tabPageAyarlar.TabIndex = 3;
            tabPageAyarlar.Text = "Ayarlar";
            tabPageAyarlar.UseVisualStyleBackColor = true;
            // 
            // AnaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 604);
            Controls.Add(materialTabControl1);
            Name = "AnaForm";
            Text = "NaxcivanPOS";
            Load += AnaForm_Load;
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
    }
}