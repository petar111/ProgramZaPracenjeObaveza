namespace Klijent
{
    partial class FormaPrijaviSe
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
            this.btnOtkrij = new System.Windows.Forms.Button();
            this.btnPrijaviSe = new System.Windows.Forms.Button();
            this.btnNapraviNalog = new System.Windows.Forms.Button();
            this.pnlPrijavaVrednost = new Klijent.PnlLogin();
            this.SuspendLayout();
            // 
            // btnOtkrij
            // 
            this.btnOtkrij.Location = new System.Drawing.Point(469, 85);
            this.btnOtkrij.Name = "btnOtkrij";
            this.btnOtkrij.Size = new System.Drawing.Size(96, 23);
            this.btnOtkrij.TabIndex = 5;
            this.btnOtkrij.Text = "Otkrij";
            this.btnOtkrij.UseVisualStyleBackColor = true;
            this.btnOtkrij.Click += new System.EventHandler(this.btnOtkrij_Click);
            // 
            // btnPrijaviSe
            // 
            this.btnPrijaviSe.Location = new System.Drawing.Point(469, 114);
            this.btnPrijaviSe.Name = "btnPrijaviSe";
            this.btnPrijaviSe.Size = new System.Drawing.Size(96, 23);
            this.btnPrijaviSe.TabIndex = 4;
            this.btnPrijaviSe.Text = "Prijavi se";
            this.btnPrijaviSe.UseVisualStyleBackColor = true;
            this.btnPrijaviSe.Click += new System.EventHandler(this.btnPrijaviSe_Click);
            // 
            // btnNapraviNalog
            // 
            this.btnNapraviNalog.Location = new System.Drawing.Point(436, 12);
            this.btnNapraviNalog.Name = "btnNapraviNalog";
            this.btnNapraviNalog.Size = new System.Drawing.Size(129, 23);
            this.btnNapraviNalog.TabIndex = 6;
            this.btnNapraviNalog.Text = "Napravi nalog";
            this.btnNapraviNalog.UseVisualStyleBackColor = true;
            this.btnNapraviNalog.Click += new System.EventHandler(this.btnNapraviNalog_Click);
            // 
            // pnlPrijavaVrednost
            // 
            this.pnlPrijavaVrednost.Location = new System.Drawing.Point(12, 12);
            this.pnlPrijavaVrednost.Name = "pnlPrijavaVrednost";
            this.pnlPrijavaVrednost.Size = new System.Drawing.Size(418, 120);
            this.pnlPrijavaVrednost.TabIndex = 0;
            // 
            // FormaPrijaviSe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 146);
            this.Controls.Add(this.btnNapraviNalog);
            this.Controls.Add(this.btnOtkrij);
            this.Controls.Add(this.btnPrijaviSe);
            this.Controls.Add(this.pnlPrijavaVrednost);
            this.Name = "FormaPrijaviSe";
            this.Text = "Prijava";
            this.ResumeLayout(false);

        }

        #endregion

        private PnlLogin pnlPrijavaVrednost;
        private System.Windows.Forms.Button btnOtkrij;
        private System.Windows.Forms.Button btnPrijaviSe;
        private System.Windows.Forms.Button btnNapraviNalog;
    }
}