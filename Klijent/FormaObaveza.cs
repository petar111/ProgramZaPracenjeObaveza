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

namespace Klijent
{
    public partial class FormaObaveza : Form
    {
        private OpstiKontrolerKI kontroler;
        public FormaObaveza()
        {
            kontroler = new KontrolerKIObaveza();
            InitializeComponent();
        }

        private void FormaObaveza_Load(object sender, EventArgs e)
        {
            FormManager.Instance.AddForm(this);

            KontrolerKIObaveza kkio = (KontrolerKIObaveza)kontroler;

            

            kkio.VratiSveKorisnike();

            if (!kkio.Signal)
            {
                MessageBox.Show(kkio.Poruka);
                this.Close();
                return;
            }

            dgvKorisnici.DataSource = kkio.Korisnici;

            kkio.VratiSveTipoveObaveza();

            if (!kkio.Signal)
            {
                MessageBox.Show(kkio.Poruka);
                this.Close();
                return;
            }

            cmbTip.DataSource = kkio.TipoviObaveze;

            dgvStavke.DataSource = Sesija.Instance.StavkeObaveze;

            dgvStavke.Columns[0].Width = 40;
            dgvStavke.Columns[1].Width = 200;

            NapuniFormuPoRezimu(kkio);

            kkio.FixLists();

            

            //if (Sesija.Instance.KreiranaObaveza.Naziv != "")
            //{
            //    txtNaziv.Text = Sesija.Instance.KreiranaObaveza.Naziv;
            //    dtpDatRokaIzvrsenja.Value = Sesija.Instance.KreiranaObaveza.DatumRokaIzvrsenja;
            //    dtpDatumPostavljanja.Value = Sesija.Instance.KreiranaObaveza.DatumPostavljanja;

            //    cmbTip.SelectedItem = kkio.FindTipObavezeById(Sesija.Instance.KreiranaObaveza.TipObaveze);
                
            //    dtpDatumPostavljanja.Visible = true;
            //    lblDatumPostavljanja.Visible = true;

            //    chbPonistena.Visible = true;
            //    chbPotvrdjena.Visible = true;

            //    chbPonistena.Checked = Sesija.Instance.KreiranaObaveza.Ponistena;
            //    chbPotvrdjena.Checked = Sesija.Instance.KreiranaObaveza.Potvrdjena;
            //}

        }

        private void NapuniFormuPoRezimu(KontrolerKIObaveza kkio)
        {
            if (Sesija.Instance.RezimRadaSaObavezom != RezimRadaSaObavezom.PostavljanjeNove)
            {
                txtNaziv.Text = Sesija.Instance.KreiranaObaveza.Naziv;
                dtpDatRokaIzvrsenja.Value = Sesija.Instance.KreiranaObaveza.DatumRokaIzvrsenja;
                dtpDatumPostavljanja.Value = Sesija.Instance.KreiranaObaveza.DatumPostavljanja;

                cmbTip.SelectedItem = kkio.FindTipObavezeById(Sesija.Instance.KreiranaObaveza.TipObaveze);

                dtpDatumPostavljanja.Visible = true;
                lblDatumPostavljanja.Visible = true;

                chbPonistena.Visible = true;
                chbPotvrdjena.Visible = true;

                chbPonistena.Checked = Sesija.Instance.KreiranaObaveza.Ponistena;
                chbPotvrdjena.Checked = Sesija.Instance.KreiranaObaveza.Potvrdjena;

                lblPostavio.Visible = true;
                txtPostavio.Visible = true;
                txtPostavio.Text = Sesija.Instance.KreiranaObaveza.Postavio;

            }

            dgvIzvrsioci.DataSource = Sesija.Instance.KreiranaObaveza.IzvrsiociObaveze;
            dgvIzvrsioci.Columns[0].Width = 110;
            dgvIzvrsioci.Columns[1].Width = 110;
            dgvIzvrsioci.Columns[2].Width = 110;
            dgvIzvrsioci.Columns[3].Width = 40;


            switch (Sesija.Instance.RezimRadaSaObavezom)
            {
                case RezimRadaSaObavezom.Ponistavanje:
                    btnPonisti.Visible = true;
                    break;
                case RezimRadaSaObavezom.PotvrdaIzvrsenja:
                    btnPotvrdiIzvrsenje.Visible = true;
                    break;
                case RezimRadaSaObavezom.Potvrda:
                    btnPotvrdi.Visible = true;
                    break;
                case RezimRadaSaObavezom.Izmena:
                case RezimRadaSaObavezom.PostavljanjeNove:
                    btnSacuvaj.Visible = true;
                    btnDodajIzvrsioca.Visible = true;
                    btnDodajStavku.Visible = true;
                    btnObrisiIzvrsioca.Visible = true;
                    btnObrisiStavke.Visible = true;
                    dgvKorisnici.Visible = true;
                    dgvIzvrsioci.DataSource = Sesija.Instance.IzvrsiociObaveze;
                    txtNaziv.ReadOnly = false;
                    dtpDatRokaIzvrsenja.Enabled = true;
                    break;
                default:
                    break;
  
            }
        }

        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
            FormaStavka fs = new FormaStavka();
            fs.ShowDialog();
        }

        private void btnObrisiStavke_Click(object sender, EventArgs e)
        {
            if(dgvStavke.SelectedRows.Count == 1)
            {
                ((KontrolerKIObaveza)kontroler).ObrisiStavku(dgvStavke.SelectedRows[0].DataBoundItem);
            }
        }

        private void btnDodajIzvrsioca_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.SelectedRows.Count == 1)
            {
                ((KontrolerKIObaveza)kontroler).DodajIzvrsioca(dgvKorisnici.SelectedRows[0].DataBoundItem);
                dgvIzvrsioci.DataSource = Sesija.Instance.IzvrsiociObaveze;
            }
        }

        private void btnObrisiIzvrsioca_Click(object sender, EventArgs e)
        {
            if (dgvIzvrsioci.SelectedRows.Count == 1)
            {
                ((KontrolerKIObaveza)kontroler).IzbaciIzvrsioca(dgvIzvrsioci.SelectedRows[0].DataBoundItem);
                dgvKorisnici.DataSource = ((KontrolerKIObaveza)kontroler).Korisnici;
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
            {
                MessageBox.Show("Validacija nije uspela.");
                return;
            }

            kontroler.ZahtevZaOperaciju = Domen.Operacija.ZapamtiObavezu;

            SakupiGrafickeObjekte();

            kontroler.IzvrsiZahtev();

            MessageBox.Show(kontroler.Poruka);

            this.Close();
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                return false;
            }

            if(dtpDatRokaIzvrsenja.Value < dtpDatumPostavljanja.Value)
            {
                return false;
            }

            if(Sesija.Instance.IzvrsiociObaveze.Count == 0)
            {
                return false;
            }

            return true;
        }

        private void FormaObaveza_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Instance.RemoveForm(this);
            Sesija.Instance.ResetLists();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            kontroler.ZahtevZaOperaciju = Domen.Operacija.PotvrdiObavezu;
            chbPotvrdjena.Checked = true;

            SakupiGrafickeObjekte();

            kontroler.IzvrsiZahtev();

            MessageBox.Show(kontroler.Poruka);

            this.Close();

        }




        private void SakupiGrafickeObjekte()
        {
            string nazivObaveze = txtNaziv.Text;
            DateTime datumPostavljanja = dtpDatumPostavljanja.Value;
            DateTime datumRokaIzvrsenja = dtpDatRokaIzvrsenja.Value;
            bool potvrdjena = chbPotvrdjena.Checked;
            bool ponistena = chbPonistena.Checked;
            int idPostavio = Sesija.Instance.Korisnik.Id;
            string imePostavio = Sesija.Instance.Korisnik.Ime;
            string prezimePostavio = Sesija.Instance.Korisnik.Prezime;
            string korisnickoImePostavio = Sesija.Instance.Korisnik.KorisnickoIme;
            object tipObaveze = cmbTip.SelectedItem;

            kontroler.GrafickiObjekti = new List<object>()
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
                tipObaveze
            };
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            kontroler.ZahtevZaOperaciju = Domen.Operacija.PonistiObavezu;
            chbPonistena.Checked = true;

            SakupiGrafickeObjekte();

            kontroler.IzvrsiZahtev();

            MessageBox.Show(kontroler.Poruka);

            this.Close();
        }

        private void btnPotvrdiIzvrsenje_Click(object sender, EventArgs e)
        {
            SakupiGrafickeObjekte();

            kontroler.ZahtevZaOperaciju = Domen.Operacija.PotvrdiIzvrsenjeObaveze;

            ((KontrolerKIObaveza)kontroler).PotvrdiIzvrsenjeObaveze();

            MessageBox.Show(kontroler.Poruka);

            this.Close();
        }

        private void dgvStavke_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FormaStavka frmStavka = new FormaStavka();
                frmStavka.NapuniFormuStavkom(dgvStavke.Rows[e.RowIndex].DataBoundItem);
                frmStavka.ShowDialog();
            }


        }

        private void dgvStavke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
