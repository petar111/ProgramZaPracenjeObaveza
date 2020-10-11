namespace Klijent
{
    partial class PnlLogin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlKorisnickoIme = new Klijent.PnlVrednostZaUnos();
            this.pnlSifra = new Klijent.PnlVrednostZaUnos();
            this.SuspendLayout();
            // 
            // pnlKorisnickoIme
            // 
            this.pnlKorisnickoIme.Location = new System.Drawing.Point(3, 3);
            this.pnlKorisnickoIme.Name = "pnlKorisnickoIme";
            this.pnlKorisnickoIme.Size = new System.Drawing.Size(413, 54);
            this.pnlKorisnickoIme.TabIndex = 0;
            // 
            // pnlSifra
            // 
            this.pnlSifra.Location = new System.Drawing.Point(3, 63);
            this.pnlSifra.Name = "pnlSifra";
            this.pnlSifra.Size = new System.Drawing.Size(413, 54);
            this.pnlSifra.TabIndex = 1;
            // 
            // PnlLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSifra);
            this.Controls.Add(this.pnlKorisnickoIme);
            this.Name = "PnlLogin";
            this.Size = new System.Drawing.Size(418, 120);
            this.ResumeLayout(false);

        }

        #endregion

        private PnlVrednostZaUnos pnlKorisnickoIme;
        private PnlVrednostZaUnos pnlSifra;
    }
}
