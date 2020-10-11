namespace Klijent
{
    partial class FormaKreirajNalog
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
            this.btnZapamtiNalog = new System.Windows.Forms.Button();
            this.pnlPotvrdaSifre = new Klijent.PnlVrednostZaUnos();
            this.pnlSifra = new Klijent.PnlVrednostZaUnos();
            this.pnlKorisnickoIme = new Klijent.PnlVrednostZaUnos();
            this.pnlPrezime = new Klijent.PnlVrednostZaUnos();
            this.pnlIme = new Klijent.PnlVrednostZaUnos();
            this.btnOtkrij = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZapamtiNalog
            // 
            this.btnZapamtiNalog.Location = new System.Drawing.Point(432, 255);
            this.btnZapamtiNalog.Name = "btnZapamtiNalog";
            this.btnZapamtiNalog.Size = new System.Drawing.Size(84, 36);
            this.btnZapamtiNalog.TabIndex = 5;
            this.btnZapamtiNalog.Text = "Zapamti";
            this.btnZapamtiNalog.UseVisualStyleBackColor = true;
            this.btnZapamtiNalog.Click += new System.EventHandler(this.btnZapamtiNalog_Click);
            // 
            // pnlPotvrdaSifre
            // 
            this.pnlPotvrdaSifre.Location = new System.Drawing.Point(13, 255);
            this.pnlPotvrdaSifre.Name = "pnlPotvrdaSifre";
            this.pnlPotvrdaSifre.Size = new System.Drawing.Size(413, 54);
            this.pnlPotvrdaSifre.TabIndex = 4;
            // 
            // pnlSifra
            // 
            this.pnlSifra.Location = new System.Drawing.Point(13, 194);
            this.pnlSifra.Name = "pnlSifra";
            this.pnlSifra.Size = new System.Drawing.Size(413, 54);
            this.pnlSifra.TabIndex = 3;
            // 
            // pnlKorisnickoIme
            // 
            this.pnlKorisnickoIme.Location = new System.Drawing.Point(13, 133);
            this.pnlKorisnickoIme.Name = "pnlKorisnickoIme";
            this.pnlKorisnickoIme.Size = new System.Drawing.Size(413, 54);
            this.pnlKorisnickoIme.TabIndex = 2;
            // 
            // pnlPrezime
            // 
            this.pnlPrezime.Location = new System.Drawing.Point(12, 72);
            this.pnlPrezime.Name = "pnlPrezime";
            this.pnlPrezime.Size = new System.Drawing.Size(413, 54);
            this.pnlPrezime.TabIndex = 1;
            // 
            // pnlIme
            // 
            this.pnlIme.Location = new System.Drawing.Point(12, 12);
            this.pnlIme.Name = "pnlIme";
            this.pnlIme.Size = new System.Drawing.Size(413, 54);
            this.pnlIme.TabIndex = 0;
            // 
            // btnOtkrij
            // 
            this.btnOtkrij.Location = new System.Drawing.Point(432, 204);
            this.btnOtkrij.Name = "btnOtkrij";
            this.btnOtkrij.Size = new System.Drawing.Size(84, 22);
            this.btnOtkrij.TabIndex = 6;
            this.btnOtkrij.Text = "Otkrij";
            this.btnOtkrij.UseVisualStyleBackColor = true;
            this.btnOtkrij.Click += new System.EventHandler(this.btnOtkrij_Click);
            // 
            // FormaKreirajNalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 319);
            this.Controls.Add(this.btnOtkrij);
            this.Controls.Add(this.btnZapamtiNalog);
            this.Controls.Add(this.pnlPotvrdaSifre);
            this.Controls.Add(this.pnlSifra);
            this.Controls.Add(this.pnlKorisnickoIme);
            this.Controls.Add(this.pnlPrezime);
            this.Controls.Add(this.pnlIme);
            this.Name = "FormaKreirajNalog";
            this.Text = "Nalog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormaKreirajNalog_FormClosed);
            this.Load += new System.EventHandler(this.FormaKreirajNalog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PnlVrednostZaUnos pnlIme;
        private PnlVrednostZaUnos pnlPrezime;
        private PnlVrednostZaUnos pnlKorisnickoIme;
        private PnlVrednostZaUnos pnlSifra;
        private PnlVrednostZaUnos pnlPotvrdaSifre;
        private System.Windows.Forms.Button btnZapamtiNalog;
        private System.Windows.Forms.Button btnOtkrij;
    }
}