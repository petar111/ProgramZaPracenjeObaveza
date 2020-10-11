using KontrolerKI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class FormaStavka : Form
    {
        private OpstiKontrolerKI kontroler;

        public FormaStavka()
        {
            InitializeComponent();
            kontroler = new KontrolerKIStavkaObaveze();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
            {
                MessageBox.Show("Validacija nije uspela.");
                return;
            }

            kontroler.GrafickiObjekti = new List<object>()
            {
                txtNaziv.Text,
                txtNapomena.Text
            };

            ((KontrolerKIStavkaObaveze)kontroler).DodajStavku();

            this.Close();
        }


        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                return false;
            }

            return true;
        }

        internal void NapuniFormuStavkom(object stavkaView)
        {
            kontroler.ObjekatOdgovor = stavkaView;
            kontroler.IzvrsiKonverzijuObjekta();

            txtNaziv.Text = (string)kontroler.GrafickiObjektiOdgovor[0];
            txtNapomena.Text = (string)kontroler.GrafickiObjektiOdgovor[1];

            btnDodaj.Visible = false;
        }
    }
}
