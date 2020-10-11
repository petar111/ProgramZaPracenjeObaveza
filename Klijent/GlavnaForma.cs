using Domen;
using KontrolerKI;
using SesijaKlijent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace Klijent
{
    public partial class GlavnaForma : Form
    {
        private OpstiKontrolerKI kontroler;
        public GlavnaForma()
        {
            InitializeComponent();
        }

        private void izmeniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormaKreirajNalog fkn = new FormaKreirajNalog();
            fkn.ShowDialog();
        }

        private void obrisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kontroler = new KontrolerKINalog();
            kontroler.ZahtevZaOperaciju = Domen.Operacija.ObrisiNalog;

            string ime = Sesija.Instance.Korisnik.Ime;
            string prezime = Sesija.Instance.Korisnik.Prezime;
            string korisnickoime = Sesija.Instance.Korisnik.KorisnickoIme;
            string sifra = Sesija.Instance.Korisnik.Sifra;

            kontroler.GrafickiObjekti = new List<object>()
            {
                ime,
                prezime,
                korisnickoime,
                sifra
            };

            kontroler.IzvrsiZahtev();

            MessageBox.Show(kontroler.Poruka);

            if (kontroler.Signal)
            {
                this.Close();
            }
        }

        private void postaviNovuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesija.Instance.RezimRadaSaObavezom = RezimRadaSaObavezom.PostavljanjeNove;
            bool signal = NapraviObavezu();

            if (!signal)
            {
                return;
            }

            FormaObaveza fo = new FormaObaveza();
            fo.ShowDialog();
        }

        private bool NapraviObavezu()
        {
            
            KontrolerKIObaveza kkio = new KontrolerKIObaveza();

            kkio.ZahtevZaOperaciju = Operacija.NapraviNovuObavezu;

            string nazivObaveze = "";
            DateTime datumPostavljanja = DateTime.Now;
            DateTime datumRokaIzvrsenja = DateTime.Now;
            bool potvrdjena = false;
            bool ponistena = false;
            int idPostavio = Sesija.Instance.Korisnik.Id;
            string imePostavio = Sesija.Instance.Korisnik.Ime;
            string prezimePostavio = Sesija.Instance.Korisnik.Prezime;
            string korisnickoImePostavio = Sesija.Instance.Korisnik.KorisnickoIme;

            kkio.GrafickiObjekti = new List<object>()
            {
                nazivObaveze,
                datumPostavljanja,
                datumRokaIzvrsenja,
                potvrdjena,
                ponistena,
                idPostavio,
                imePostavio,
                prezimePostavio,
                korisnickoImePostavio,
                null
            };


            kkio.IzvrsiZahtev();

            MessageBox.Show(kkio.Poruka);

            return kkio.Signal;
        }

        private void pretraziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesija.Instance.RezimRadaSaObavezom = RezimRadaSaObavezom.Pretraga;
            FormaObaveze fObaveze = new FormaObaveze();
            DialogResult dr = fObaveze.ShowDialog();
        }

        private void GlavnaForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Instance.RemoveForm(this);
            KomunikacijaSaServerom.Komunikacija.Instance.ZatvoriKonekciju();
        }

        private void izmeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesija.Instance.RezimRadaSaObavezom = RezimRadaSaObavezom.Izmena;
            FormaObaveze fObaveze = new FormaObaveze();
            fObaveze.ShowDialog();
        }

        private void ponistiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesija.Instance.RezimRadaSaObavezom = RezimRadaSaObavezom.Ponistavanje;
            FormaObaveze fObaveze = new FormaObaveze();
            fObaveze.ShowDialog();
        }

        private void potvrdiIzvrsenjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesija.Instance.RezimRadaSaObavezom = RezimRadaSaObavezom.PotvrdaIzvrsenja;
            FormaObaveze fObaveze = new FormaObaveze();
            fObaveze.ShowDialog();
        }

        private void potvrdiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesija.Instance.RezimRadaSaObavezom = RezimRadaSaObavezom.Potvrda;
            FormaObaveze fObaveze = new FormaObaveze();
            fObaveze.ShowDialog();
        }

        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            FormManager.Instance.AddForm(this);
        }

        private void btnPlayMe_Click(object sender, EventArgs e)
        {
            string message = StartAGame.StartGame();
            if(message != null)
            {
                MessageBox.Show(message);
            }
        }
    }
}
