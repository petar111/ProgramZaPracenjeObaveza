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
using SesijaKlijent;

namespace Klijent
{
    public partial class FormaKreirajNalog : Form
    {
        private OpstiKontrolerKI kontroler;
        public FormaKreirajNalog()
        {
            InitializeComponent();
            kontroler = new KontrolerKINalog();
            PripremiFormu();
        }

        private void PripremiFormu()
        {
            pnlIme.LblVrednost.Text = "Ime:";
            pnlIme.TxtVrednost.Text = Sesija.Instance.Korisnik.Ime;
            pnlIme.LblVrednostUpozorenje.Text = "";

            pnlPrezime.LblVrednost.Text = "Prezime:";
            pnlPrezime.TxtVrednost.Text = Sesija.Instance.Korisnik.Prezime;
            pnlPrezime.LblVrednostUpozorenje.Text = "";

            pnlKorisnickoIme.LblVrednost.Text = "Korisnicko ime:";
            pnlKorisnickoIme.TxtVrednost.Text = Sesija.Instance.Korisnik.KorisnickoIme;
            pnlKorisnickoIme.LblVrednostUpozorenje.Text = "";

            pnlSifra.LblVrednost.Text = "Sifra:";
            pnlSifra.TxtVrednost.Text = Sesija.Instance.Korisnik.Sifra;
            pnlSifra.LblVrednostUpozorenje.Text = "";
            pnlSifra.TxtVrednost.PasswordChar = '●';

            pnlPotvrdaSifre.LblVrednost.Text = "Potvrda sifre:";
            pnlPotvrdaSifre.LblVrednostUpozorenje.Text = "";
            pnlPotvrdaSifre.TxtVrednost.PasswordChar = '●';
        }

        private void btnOtkrij_Click(object sender, EventArgs e)
        {
            pnlSifra.TxtVrednost.PasswordChar = (pnlSifra.TxtVrednost.PasswordChar == '●') ? '\0' : '●';
            pnlPotvrdaSifre.TxtVrednost.PasswordChar = (pnlPotvrdaSifre.TxtVrednost.PasswordChar == '●') ? '\0' : '●';
        }

        private void btnZapamtiNalog_Click(object sender, EventArgs e)
        {
            if (!Validacija())
            {
                MessageBox.Show("Validacija nije uspela.");
                return;
            }

            kontroler.ZahtevZaOperaciju = Domen.Operacija.ZapamtiNalog;

            string ime = pnlIme.TxtVrednost.Text;
            string prezime = pnlPrezime.TxtVrednost.Text;
            string korisnickoime = pnlKorisnickoIme.TxtVrednost.Text;
            string sifra = pnlSifra.TxtVrednost.Text;

            kontroler.GrafickiObjekti = new List<object>()
            {
                ime,
                prezime,
                korisnickoime,
                sifra
            };

            kontroler.IzvrsiZahtev();

            MessageBox.Show(kontroler.Poruka);

            this.Close();
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(pnlIme.TxtVrednost.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(pnlPrezime.TxtVrednost.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(pnlKorisnickoIme.TxtVrednost.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(pnlSifra.TxtVrednost.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(pnlPotvrdaSifre.TxtVrednost.Text))
            {
                return false;
            }

            if (pnlSifra.TxtVrednost.Text != pnlPotvrdaSifre.TxtVrednost.Text)
            {
                return false;
            }
            
            return true;
        }

        private void FormaKreirajNalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Instance.RemoveForm(this);
        }

        private void FormaKreirajNalog_Load(object sender, EventArgs e)
        {
            FormManager.Instance.AddForm(this);
        }
    }
}
