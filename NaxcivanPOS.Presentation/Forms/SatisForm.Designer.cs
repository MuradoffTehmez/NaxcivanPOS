namespace NaxcivanPOS.Presentation.Forms
{
    partial class SatisForm
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
            cmbMehsullar = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtSay = new TextBox();
            btnElaveEt = new Button();
            dataGridViewSatis = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            btnSatisEt = new Button();
            btnImtina = new Button();
            lblToplam = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatis).BeginInit();
            SuspendLayout();
            // 
            // cmbMehsullar
            // 
            cmbMehsullar.FormattingEnabled = true;
            cmbMehsullar.Location = new Point(12, 25);
            cmbMehsullar.Name = "cmbMehsullar";
            cmbMehsullar.Size = new Size(250, 23);
            cmbMehsullar.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 1;
            label1.Text = "Məhsul:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 7);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "Sayı:";
            // 
            // txtSay
            // 
            txtSay.Location = new Point(268, 25);
            txtSay.Name = "txtSay";
            txtSay.Size = new Size(100, 23);
            txtSay.TabIndex = 3;
            txtSay.Text = "1";
            // 
            // btnElaveEt
            // 
            btnElaveEt.Location = new Point(374, 24);
            btnElaveEt.Name = "btnElaveEt";
            btnElaveEt.Size = new Size(75, 23);
            btnElaveEt.TabIndex = 4;
            btnElaveEt.Text = "Əlavə Et";
            btnElaveEt.UseVisualStyleBackColor = true;
            btnElaveEt.Click += btnElaveEt_Click;
            // 
            // dataGridViewSatis
            // 
            dataGridViewSatis.AllowUserToAddRows = false;
            dataGridViewSatis.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewSatis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewSatis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSatis.BackgroundColor = Color.White;
            dataGridViewSatis.BorderStyle = BorderStyle.None;
            dataGridViewSatis.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewSatis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewSatis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSatis.Columns.AddRange(dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5);
            dataGridViewSatis.Location = new Point(12, 54);
            dataGridViewSatis.Name = "dataGridViewSatis";
            dataGridViewSatis.RowHeadersVisible = false;
            dataGridViewSatis.Size = new Size(776, 315);
            dataGridViewSatis.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Ad";
            dataGridViewTextBoxColumn2.HeaderText = "Məhsul";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Qiymet";
            dataGridViewTextBoxColumn3.HeaderText = "Qiymət";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Say";
            dataGridViewTextBoxColumn4.HeaderText = "Say";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "Toplam";
            dataGridViewTextBoxColumn5.HeaderText = "Toplam";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // btnSatisEt
            // 
            btnSatisEt.Location = new Point(632, 375);
            btnSatisEt.Name = "btnSatisEt";
            btnSatisEt.Size = new Size(75, 23);
            btnSatisEt.TabIndex = 6;
            btnSatisEt.Text = "Sat";
            btnSatisEt.UseVisualStyleBackColor = true;
            btnSatisEt.Click += btnSatisEt_Click;
            // 
            // btnImtina
            // 
            btnImtina.Location = new Point(713, 375);
            btnImtina.Name = "btnImtina";
            btnImtina.Size = new Size(75, 23);
            btnImtina.TabIndex = 7;
            btnImtina.Text = "İmtina";
            btnImtina.UseVisualStyleBackColor = true;
            btnImtina.Click += btnImtina_Click;
            // 
            // lblToplam
            // 
            lblToplam.AutoSize = true;
            lblToplam.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblToplam.Location = new Point(12, 375);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(76, 20);
            lblToplam.TabIndex = 8;
            lblToplam.Text = "Toplam: ";
            // 
            // SatisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 410);
            Controls.Add(lblToplam);
            Controls.Add(btnImtina);
            Controls.Add(btnSatisEt);
            Controls.Add(dataGridViewSatis);
            Controls.Add(btnElaveEt);
            Controls.Add(txtSay);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbMehsullar);
            Name = "SatisForm";
            Text = "Satış";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatis).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMehsullar;
        private Label label1;
        private Label label2;
        private TextBox txtSay;
        private Button btnElaveEt;
        private DataGridView dataGridViewSatis;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Button btnSatisEt;
        private Button btnImtina;
        private Label lblToplam;
    }
}