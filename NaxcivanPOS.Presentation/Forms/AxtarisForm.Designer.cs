namespace NaxcivanPOS.Presentation.Forms
{
    partial class AxtarisForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAxtaris = new System.Windows.Forms.TextBox();
            this.btnAxtar = new System.Windows.Forms.Button();
            this.btnImtina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Axtarış sözü:";
            // 
            // txtAxtaris
            // 
            this.txtAxtaris.Location = new System.Drawing.Point(12, 39);
            this.txtAxtaris.Name = "txtAxtaris";
            this.txtAxtaris.Size = new System.Drawing.Size(260, 23);
            this.txtAxtaris.TabIndex = 1;
            // 
            // btnAxtar
            // 
            this.btnAxtar.Location = new System.Drawing.Point(116, 68);
            this.btnAxtar.Name = "btnAxtar";
            this.btnAxtar.Size = new System.Drawing.Size(75, 23);
            this.btnAxtar.TabIndex = 2;
            this.btnAxtar.Text = "Axtar";
            this.btnAxtar.UseVisualStyleBackColor = true;
            this.btnAxtar.Click += new System.EventHandler(this.btnAxtar_Click);
            // 
            // btnImtina
            // 
            this.btnImtina.Location = new System.Drawing.Point(197, 68);
            this.btnImtina.Name = "btnImtina";
            this.btnImtina.Size = new System.Drawing.Size(75, 23);
            this.btnImtina.TabIndex = 3;
            this.btnImtina.Text = "İmtina";
            this.btnImtina.UseVisualStyleBackColor = true;
            this.btnImtina.Click += new System.EventHandler(this.btnImtina_Click);
            // 
            // AxtarisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 103);
            this.Controls.Add(this.btnImtina);
            this.Controls.Add(this.btnAxtar);
            this.Controls.Add(this.txtAxtaris);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AxtarisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Məhsul Axtarışı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtAxtaris;
        private Button btnAxtar;
        private Button btnImtina;
    }
}