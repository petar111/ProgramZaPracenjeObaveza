namespace Klijent
{
    partial class FormaObaveze
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
            this.dgvObaveze = new System.Windows.Forms.DataGridView();
            this.lblObaveze = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPostavio = new System.Windows.Forms.TextBox();
            this.txtIzvrsava = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatumPostavljanja = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumRokaIzvrsenja = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPronadji = new System.Windows.Forms.Button();
            this.btnOnOffDatumPostavljanja = new System.Windows.Forms.Button();
            this.btnOnOffDatumRokaIzvrsenja = new System.Windows.Forms.Button();
            this.btnOdaberi = new System.Windows.Forms.Button();
            this.lblPrikazi = new System.Windows.Forms.Label();
            this.cmbPrikazi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObaveze)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvObaveze
            // 
            this.dgvObaveze.AllowUserToAddRows = false;
            this.dgvObaveze.AllowUserToDeleteRows = false;
            this.dgvObaveze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObaveze.Location = new System.Drawing.Point(15, 200);
            this.dgvObaveze.Name = "dgvObaveze";
            this.dgvObaveze.ReadOnly = true;
            this.dgvObaveze.Size = new System.Drawing.Size(825, 328);
            this.dgvObaveze.TabIndex = 0;
            this.dgvObaveze.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvObaveze_CellMouseClick);
            // 
            // lblObaveze
            // 
            this.lblObaveze.AutoSize = true;
            this.lblObaveze.Location = new System.Drawing.Point(12, 175);
            this.lblObaveze.Name = "lblObaveze";
            this.lblObaveze.Size = new System.Drawing.Size(53, 13);
            this.lblObaveze.TabIndex = 1;
            this.lblObaveze.Text = "Obaveze:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Postavio:";
            // 
            // txtPostavio
            // 
            this.txtPostavio.Location = new System.Drawing.Point(15, 26);
            this.txtPostavio.Name = "txtPostavio";
            this.txtPostavio.Size = new System.Drawing.Size(145, 20);
            this.txtPostavio.TabIndex = 3;
            // 
            // txtIzvrsava
            // 
            this.txtIzvrsava.Location = new System.Drawing.Point(175, 26);
            this.txtIzvrsava.Name = "txtIzvrsava";
            this.txtIzvrsava.Size = new System.Drawing.Size(145, 20);
            this.txtIzvrsava.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Izvrsava:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Datum postavljanja:";
            // 
            // dtpDatumPostavljanja
            // 
            this.dtpDatumPostavljanja.Location = new System.Drawing.Point(15, 77);
            this.dtpDatumPostavljanja.Name = "dtpDatumPostavljanja";
            this.dtpDatumPostavljanja.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumPostavljanja.TabIndex = 7;
            // 
            // dtpDatumRokaIzvrsenja
            // 
            this.dtpDatumRokaIzvrsenja.Location = new System.Drawing.Point(223, 77);
            this.dtpDatumRokaIzvrsenja.Name = "dtpDatumRokaIzvrsenja";
            this.dtpDatumRokaIzvrsenja.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumRokaIzvrsenja.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Datum roka izvrsenja:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(449, 26);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(145, 20);
            this.txtNaziv.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(446, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Naziv:";
            // 
            // btnPronadji
            // 
            this.btnPronadji.Location = new System.Drawing.Point(12, 127);
            this.btnPronadji.Name = "btnPronadji";
            this.btnPronadji.Size = new System.Drawing.Size(88, 35);
            this.btnPronadji.TabIndex = 12;
            this.btnPronadji.Text = "Pronadji";
            this.btnPronadji.UseVisualStyleBackColor = true;
            this.btnPronadji.Click += new System.EventHandler(this.btnPronadji_Click);
            // 
            // btnOnOffDatumPostavljanja
            // 
            this.btnOnOffDatumPostavljanja.Location = new System.Drawing.Point(140, 103);
            this.btnOnOffDatumPostavljanja.Name = "btnOnOffDatumPostavljanja";
            this.btnOnOffDatumPostavljanja.Size = new System.Drawing.Size(75, 23);
            this.btnOnOffDatumPostavljanja.TabIndex = 13;
            this.btnOnOffDatumPostavljanja.Text = "On/Off";
            this.btnOnOffDatumPostavljanja.UseVisualStyleBackColor = true;
            this.btnOnOffDatumPostavljanja.Click += new System.EventHandler(this.btnOnOffDatumPostavljanja_Click);
            // 
            // btnOnOffDatumRokaIzvrsenja
            // 
            this.btnOnOffDatumRokaIzvrsenja.Location = new System.Drawing.Point(348, 103);
            this.btnOnOffDatumRokaIzvrsenja.Name = "btnOnOffDatumRokaIzvrsenja";
            this.btnOnOffDatumRokaIzvrsenja.Size = new System.Drawing.Size(75, 23);
            this.btnOnOffDatumRokaIzvrsenja.TabIndex = 14;
            this.btnOnOffDatumRokaIzvrsenja.Text = "On/Off";
            this.btnOnOffDatumRokaIzvrsenja.UseVisualStyleBackColor = true;
            this.btnOnOffDatumRokaIzvrsenja.Click += new System.EventHandler(this.btnOnOffDatumRokaIzvrsenja_Click);
            // 
            // btnOdaberi
            // 
            this.btnOdaberi.Location = new System.Drawing.Point(846, 472);
            this.btnOdaberi.Name = "btnOdaberi";
            this.btnOdaberi.Size = new System.Drawing.Size(75, 56);
            this.btnOdaberi.TabIndex = 15;
            this.btnOdaberi.Text = "Odaberi";
            this.btnOdaberi.UseVisualStyleBackColor = true;
            this.btnOdaberi.Click += new System.EventHandler(this.btnOdaberi_Click);
            // 
            // lblPrikazi
            // 
            this.lblPrikazi.AutoSize = true;
            this.lblPrikazi.Location = new System.Drawing.Point(12, 534);
            this.lblPrikazi.Name = "lblPrikazi";
            this.lblPrikazi.Size = new System.Drawing.Size(35, 13);
            this.lblPrikazi.TabIndex = 16;
            this.lblPrikazi.Text = "label6";
            // 
            // cmbPrikazi
            // 
            this.cmbPrikazi.FormattingEnabled = true;
            this.cmbPrikazi.Location = new System.Drawing.Point(123, 534);
            this.cmbPrikazi.Name = "cmbPrikazi";
            this.cmbPrikazi.Size = new System.Drawing.Size(34, 21);
            this.cmbPrikazi.TabIndex = 17;
            this.cmbPrikazi.SelectedIndexChanged += new System.EventHandler(this.cmbPrikazi_SelectedIndexChanged);
            // 
            // FormaObaveze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 566);
            this.Controls.Add(this.cmbPrikazi);
            this.Controls.Add(this.lblPrikazi);
            this.Controls.Add(this.btnOdaberi);
            this.Controls.Add(this.btnOnOffDatumRokaIzvrsenja);
            this.Controls.Add(this.btnOnOffDatumPostavljanja);
            this.Controls.Add(this.btnPronadji);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDatumRokaIzvrsenja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDatumPostavljanja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIzvrsava);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPostavio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblObaveze);
            this.Controls.Add(this.dgvObaveze);
            this.Name = "FormaObaveze";
            this.Text = "Obaveze";
            this.Load += new System.EventHandler(this.FormaObaveze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObaveze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvObaveze;
        private System.Windows.Forms.Label lblObaveze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPostavio;
        private System.Windows.Forms.TextBox txtIzvrsava;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatumPostavljanja;
        private System.Windows.Forms.DateTimePicker dtpDatumRokaIzvrsenja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPronadji;
        private System.Windows.Forms.Button btnOnOffDatumPostavljanja;
        private System.Windows.Forms.Button btnOnOffDatumRokaIzvrsenja;
        private System.Windows.Forms.Button btnOdaberi;
        private System.Windows.Forms.Label lblPrikazi;
        private System.Windows.Forms.ComboBox cmbPrikazi;
    }
}