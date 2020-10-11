using KomunikacijaSaServerom;
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
    public partial class FormaPrijaviSe : Form
    {
        private OpstiKontrolerKI kontroler;
        public FormaPrijaviSe()
        {
            InitializeComponent();
        }

        private void btnOtkrij_Click(object sender, EventArgs e)
        {
            pnlPrijavaVrednost.PanelSifra.TxtVrednost.PasswordChar = (pnlPrijavaVrednost.PanelSifra.TxtVrednost.PasswordChar == '●') ? '\0' : '●';
        }

        private void btnNapraviNalog_Click(object sender, EventArgs e)
        {
            if (!Komunikacija.Instance.PoveziSe())
            {
                MessageBox.Show("Sistem ne moze da napravi nalog.");
                return;
            }

            bool signal = NapraviNalog();

            if (!signal)
            {
                return;
            }

            FormaKreirajNalog fkn = new FormaKreirajNalog();
            fkn.ShowDialog();
        }

        private bool NapraviNalog()
        {
            kontroler = new KontrolerKINalog();
            kontroler.ZahtevZaOperaciju = Domen.Operacija.KreirajNoviNalog;

            string ime = "";
            string prezime = "";
            string korisnickoime = "";
            string sifra = "";

            kontroler.GrafickiObjekti = new List<object>()
            {
                ime,
                prezime,
                korisnickoime,
                sifra
            };

            kontroler.IzvrsiZahtev();

            MessageBox.Show(kontroler.Poruka);

            return kontroler.Signal;
        }

        private void btnPrijaviSe_Click(object sender, EventArgs e)
        {

            try
            {
                if (!Komunikacija.Instance.PoveziSe())
                {
                    MessageBox.Show("Prijavljivanje nije uspelo.");
                    return;
                }

                if (!Validacija())
                {
                    MessageBox.Show("Validacija nije uspela.");
                }

                string korisnickoIme = pnlPrijavaVrednost.PanelKorisnickoIme.TxtVrednost.Text;
                string sifra = pnlPrijavaVrednost.PanelSifra.TxtVrednost.Text;


                kontroler = new KontrolerKIPrijava();

                kontroler.ZahtevZaOperaciju = Domen.Operacija.PrijaviSe;
                kontroler.GrafickiObjekti = new List<object>()
                {
                    korisnickoIme,
                    sifra
                };

                kontroler.IzvrsiZahtev();

                MessageBox.Show(kontroler.Poruka);

                if (kontroler.Signal)
                {
                    GlavnaForma glf = new GlavnaForma();
                    glf.ShowDialog();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Greska sa formom");
            }
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(pnlPrijavaVrednost.PanelKorisnickoIme.TxtVrednost.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(pnlPrijavaVrednost.PanelSifra.TxtVrednost.Text))
            {
                return false;
            }

            return true;
        }
    }
}
