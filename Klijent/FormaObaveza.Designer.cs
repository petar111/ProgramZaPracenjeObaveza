namespace Klijent
{
    partial class FormaObaveza
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
            this.lblNaziv = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.dtpDatRokaIzvrsenja = new System.Windows.Forms.DateTimePicker();
            this.lblDatRokaIzvrsenja = new System.Windows.Forms.Label();
            this.lblStavke = new System.Windows.Forms.Label();
            this.dgvStavke = new System.Windows.Forms.DataGridView();
            this.dgvIzvrsioci = new System.Windows.Forms.DataGridView();
            this.lblIzvrsavaju = new System.Windows.Forms.Label();
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.btnDodajStavku = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnDodajIzvrsioca = new System.Windows.Forms.Button();
            this.btnObrisiStavke = new System.Windows.Forms.Button();
            this.btnObrisiIzvrsioca = new System.Windows.Forms.Button();
            this.dtpDatumPostavljanja = new System.Windows.Forms.DateTimePicker();
            this.lblDatumPostavljanja = new System.Windows.Forms.Label();
            this.chbPotvrdjena = new System.Windows.Forms.CheckBox();
            this.chbPonistena = new System.Windows.Forms.CheckBox();
            this.btnPonisti = new System.Windows.Forms.Button();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.btnPotvrdiIzvrsenje = new System.Windows.Forms.Button();
            this.txtPostavio = new System.Windows.Forms.TextBox();
            this.lblPostavio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvrsioci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(13, 13);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(37, 13);
            this.lblNaziv.TabIndex = 0;
            this.lblNaziv.Text = "Naziv:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(55, 13);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.ReadOnly = true;
            this.txtNaziv.Size = new System.Drawing.Size(184, 20);
            this.txtNaziv.TabIndex = 1;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(560, 13);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(25, 13);
            this.lblTip.TabIndex = 2;
            this.lblTip.Text = "Tip:";
            // 
            // cmbTip
            // 
            this.cmbTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Location = new System.Drawing.Point(591, 13);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(148, 21);
            this.cmbTip.TabIndex = 3;
            // 
            // dtpDatRokaIzvrsenja
            // 
            this.dtpDatRokaIzvrsenja.Enabled = false;
            this.dtpDatRokaIzvrsenja.Location = new System.Drawing.Point(142, 57);
            this.dtpDatRokaIzvrsenja.Name = "dtpDatRokaIzvrsenja";
            this.dtpDatRokaIzvrsenja.Size = new System.Drawing.Size(200, 20);
            this.dtpDatRokaIzvrsenja.TabIndex = 7;
            // 
            // lblDatRokaIzvrsenja
            // 
            this.lblDatRokaIzvrsenja.AutoSize = true;
            this.lblDatRokaIzvrsenja.Location = new System.Drawing.Point(8, 57);
            this.lblDatRokaIzvrsenja.Name = "lblDatRokaIzvrsenja";
            this.lblDatRokaIzvrsenja.Size = new System.Drawing.Size(109, 13);
            this.lblDatRokaIzvrsenja.TabIndex = 6;
            this.lblDatRokaIzvrsenja.Text = "Datum roka izvrsenja:";
            // 
            // lblStavke
            // 
            this.lblStavke.AutoSize = true;
            this.lblStavke.Location = new System.Drawing.Point(10, 97);
            this.lblStavke.Name = "lblStavke";
            this.lblStavke.Size = new System.Drawing.Size(44, 13);
            this.lblStavke.TabIndex = 8;
            this.lblStavke.Text = "Stavke:";
            // 
            // dgvStavke
            // 
            this.dgvStavke.AllowUserToAddRows = false;
            this.dgvStavke.AllowUserToDeleteRows = false;
            this.dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavke.Location = new System.Drawing.Point(11, 125);
            this.dgvStavke.Name = "dgvStavke";
            this.dgvStavke.ReadOnly = true;
            this.dgvStavke.Size = new System.Drawing.Size(436, 181);
            this.dgvStavke.TabIndex = 9;
            this.dgvStavke.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStavke_CellContentClick);
            this.dgvStavke.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStavke_CellDoubleClick);
            // 
            // dgvIzvrsioci
            // 
            this.dgvIzvrsioci.AllowUserToAddRows = false;
            this.dgvIzvrsioci.AllowUserToDeleteRows = false;
            this.dgvIzvrsioci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzvrsioci.Location = new System.Drawing.Point(10, 325);
            this.dgvIzvrsioci.Name = "dgvIzvrsioci";
            this.dgvIzvrsioci.ReadOnly = true;
            this.dgvIzvrsioci.Size = new System.Drawing.Size(437, 174);
            this.dgvIzvrsioci.TabIndex = 11;
            // 
            // lblIzvrsavaju
            // 
            this.lblIzvrsavaju.AutoSize = true;
            this.lblIzvrsavaju.Location = new System.Drawing.Point(8, 309);
            this.lblIzvrsavaju.Name = "lblIzvrsavaju";
            this.lblIzvrsavaju.Size = new System.Drawing.Size(58, 13);
            this.lblIzvrsavaju.TabIndex = 10;
            this.lblIzvrsavaju.Text = "Izvrsavaju:";
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.AllowUserToAddRows = false;
            this.dgvKorisnici.AllowUserToDeleteRows = false;
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Location = new System.Drawing.Point(599, 309);
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.ReadOnly = true;
            this.dgvKorisnici.Size = new System.Drawing.Size(358, 190);
            this.dgvKorisnici.TabIndex = 12;
            this.dgvKorisnici.Visible = false;
            // 
            // btnDodajStavku
            // 
            this.btnDodajStavku.Location = new System.Drawing.Point(453, 124);
            this.btnDodajStavku.Name = "btnDodajStavku";
            this.btnDodajStavku.Size = new System.Drawing.Size(92, 26);
            this.btnDodajStavku.TabIndex = 13;
            this.btnDodajStavku.Text = "Dodaj Stavku";
            this.btnDodajStavku.UseVisualStyleBackColor = true;
            this.btnDodajStavku.Visible = false;
            this.btnDodajStavku.Click += new System.EventHandler(this.btnDodajStavku_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(10, 572);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(131, 38);
            this.btnSacuvaj.TabIndex = 14;
            this.btnSacuvaj.Text = "Zapamti";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Visible = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnDodajIzvrsioca
            // 
            this.btnDodajIzvrsioca.Location = new System.Drawing.Point(847, 507);
            this.btnDodajIzvrsioca.Name = "btnDodajIzvrsioca";
            this.btnDodajIzvrsioca.Size = new System.Drawing.Size(110, 31);
            this.btnDodajIzvrsioca.TabIndex = 15;
            this.btnDodajIzvrsioca.Text = "Dodaj Izvrsioca";
            this.btnDodajIzvrsioca.UseVisualStyleBackColor = true;
            this.btnDodajIzvrsioca.Visible = false;
            this.btnDodajIzvrsioca.Click += new System.EventHandler(this.btnDodajIzvrsioca_Click);
            // 
            // btnObrisiStavke
            // 
            this.btnObrisiStavke.Location = new System.Drawing.Point(453, 169);
            this.btnObrisiStavke.Name = "btnObrisiStavke";
            this.btnObrisiStavke.Size = new System.Drawing.Size(92, 28);
            this.btnObrisiStavke.TabIndex = 16;
            this.btnObrisiStavke.Text = "Obrisi stavku";
            this.btnObrisiStavke.UseVisualStyleBackColor = true;
            this.btnObrisiStavke.Visible = false;
            this.btnObrisiStavke.Click += new System.EventHandler(this.btnObrisiStavke_Click);
            // 
            // btnObrisiIzvrsioca
            // 
            this.btnObrisiIzvrsioca.Location = new System.Drawing.Point(10, 505);
            this.btnObrisiIzvrsioca.Name = "btnObrisiIzvrsioca";
            this.btnObrisiIzvrsioca.Size = new System.Drawing.Size(107, 31);
            this.btnObrisiIzvrsioca.TabIndex = 17;
            this.btnObrisiIzvrsioca.Text = "Izbaci izvrsioca";
            this.btnObrisiIzvrsioca.UseVisualStyleBackColor = true;
            this.btnObrisiIzvrsioca.Visible = false;
            this.btnObrisiIzvrsioca.Click += new System.EventHandler(this.btnObrisiIzvrsioca_Click);
            // 
            // dtpDatumPostavljanja
            // 
            this.dtpDatumPostavljanja.Enabled = false;
            this.dtpDatumPostavljanja.Location = new System.Drawing.Point(724, 59);
            this.dtpDatumPostavljanja.Name = "dtpDatumPostavljanja";
            this.dtpDatumPostavljanja.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumPostavljanja.TabIndex = 19;
            this.dtpDatumPostavljanja.Visible = false;
            // 
            // lblDatumPostavljanja
            // 
            this.lblDatumPostavljanja.AutoSize = true;
            this.lblDatumPostavljanja.Location = new System.Drawing.Point(590, 59);
            this.lblDatumPostavljanja.Name = "lblDatumPostavljanja";
            this.lblDatumPostavljanja.Size = new System.Drawing.Size(101, 13);
            this.lblDatumPostavljanja.TabIndex = 18;
            this.lblDatumPostavljanja.Text = "Datum Postavljanja:";
            this.lblDatumPostavljanja.Visible = false;
            // 
            // chbPotvrdjena
            // 
            this.chbPotvrdjena.AutoSize = true;
            this.chbPotvrdjena.Enabled = false;
            this.chbPotvrdjena.Location = new System.Drawing.Point(847, 133);
            this.chbPotvrdjena.Name = "chbPotvrdjena";
            this.chbPotvrdjena.Size = new System.Drawing.Size(77, 17);
            this.chbPotvrdjena.TabIndex = 20;
            this.chbPotvrdjena.Text = "Potvrdjena";
            this.chbPotvrdjena.UseVisualStyleBackColor = true;
            this.chbPotvrdjena.Visible = false;
            // 
            // chbPonistena
            // 
            this.chbPonistena.AutoSize = true;
            this.chbPonistena.Enabled = false;
            this.chbPonistena.Location = new System.Drawing.Point(847, 176);
            this.chbPonistena.Name = "chbPonistena";
            this.chbPonistena.Size = new System.Drawing.Size(73, 17);
            this.chbPonistena.TabIndex = 21;
            this.chbPonistena.Text = "Ponistena";
            this.chbPonistena.UseVisualStyleBackColor = true;
            this.chbPonistena.Visible = false;
            // 
            // btnPonisti
            // 
            this.btnPonisti.Location = new System.Drawing.Point(749, 173);
            this.btnPonisti.Name = "btnPonisti";
            this.btnPonisti.Size = new System.Drawing.Size(92, 28);
            this.btnPonisti.TabIndex = 23;
            this.btnPonisti.Text = "Ponisti";
            this.btnPonisti.UseVisualStyleBackColor = true;
            this.btnPonisti.Visible = false;
            this.btnPonisti.Click += new System.EventHandler(this.btnPonisti_Click);
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(749, 124);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(92, 26);
            this.btnPotvrdi.TabIndex = 22;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Visible = false;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // btnPotvrdiIzvrsenje
            // 
            this.btnPotvrdiIzvrsenje.Location = new System.Drawing.Point(291, 500);
            this.btnPotvrdiIzvrsenje.Name = "btnPotvrdiIzvrsenje";
            this.btnPotvrdiIzvrsenje.Size = new System.Drawing.Size(131, 38);
            this.btnPotvrdiIzvrsenje.TabIndex = 24;
            this.btnPotvrdiIzvrsenje.Text = "Potvrdi izvrsenje";
            this.btnPotvrdiIzvrsenje.UseVisualStyleBackColor = true;
            this.btnPotvrdiIzvrsenje.Visible = false;
            this.btnPotvrdiIzvrsenje.Click += new System.EventHandler(this.btnPotvrdiIzvrsenje_Click);
            // 
            // txtPostavio
            // 
            this.txtPostavio.Location = new System.Drawing.Point(335, 14);
            this.txtPostavio.Name = "txtPostavio";
            this.txtPostavio.ReadOnly = true;
            this.txtPostavio.Size = new System.Drawing.Size(184, 20);
            this.txtPostavio.TabIndex = 26;
            this.txtPostavio.Visible = false;
            // 
            // lblPostavio
            // 
            this.lblPostavio.AutoSize = true;
            this.lblPostavio.Location = new System.Drawing.Point(278, 13);
            this.lblPostavio.Name = "lblPostavio";
            this.lblPostavio.Size = new System.Drawing.Size(51, 13);
            this.lblPostavio.TabIndex = 25;
            this.lblPostavio.Text = "Postavio:";
            this.lblPostavio.Visible = false;
            // 
            // FormaObaveza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 616);
            this.Controls.Add(this.txtPostavio);
            this.Controls.Add(this.lblPostavio);
            this.Controls.Add(this.btnPotvrdiIzvrsenje);
            this.Controls.Add(this.btnPonisti);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.chbPonistena);
            this.Controls.Add(this.chbPotvrdjena);
            this.Controls.Add(this.dtpDatumPostavljanja);
            this.Controls.Add(this.lblDatumPostavljanja);
            this.Controls.Add(this.btnObrisiIzvrsioca);
            this.Controls.Add(this.btnObrisiStavke);
            this.Controls.Add(this.btnDodajIzvrsioca);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.btnDodajStavku);
            this.Controls.Add(this.dgvKorisnici);
            this.Controls.Add(this.dgvIzvrsioci);
            this.Controls.Add(this.lblIzvrsavaju);
            this.Controls.Add(this.dgvStavke);
            this.Controls.Add(this.lblStavke);
            this.Controls.Add(this.dtpDatRokaIzvrsenja);
            this.Controls.Add(this.lblDatRokaIzvrsenja);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblNaziv);
            this.Name = "FormaObaveza";
            this.Text = "Obaveza";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormaObaveza_FormClosed);
            this.Load += new System.EventHandler(this.FormaObaveza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvrsioci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.DateTimePicker dtpDatRokaIzvrsenja;
        private System.Windows.Forms.Label lblDatRokaIzvrsenja;
        private System.Windows.Forms.Label lblStavke;
        private System.Windows.Forms.DataGridView dgvStavke;
        private System.Windows.Forms.DataGridView dgvIzvrsioci;
        private System.Windows.Forms.Label lblIzvrsavaju;
        private System.Windows.Forms.DataGridView dgvKorisnici;
        private System.Windows.Forms.Button btnDodajStavku;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnDodajIzvrsioca;
        private System.Windows.Forms.Button btnObrisiStavke;
        private System.Windows.Forms.Button btnObrisiIzvrsioca;
        private System.Windows.Forms.DateTimePicker dtpDatumPostavljanja;
        private System.Windows.Forms.Label lblDatumPostavljanja;
        private System.Windows.Forms.CheckBox chbPotvrdjena;
        private System.Windows.Forms.CheckBox chbPonistena;
        private System.Windows.Forms.Button btnPonisti;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Button btnPotvrdiIzvrsenje;
        private System.Windows.Forms.TextBox txtPostavio;
        private System.Windows.Forms.Label lblPostavio;
    }
}