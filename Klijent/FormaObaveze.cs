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
    public partial class FormaObaveze : Form
    {
        OpstiKontrolerKI kontroler;
        public FormaObaveze()
        {
            InitializeComponent();
            kontroler = new KontrolerKIObaveze();
        }

        private void FormaObaveze_Load(object sender, EventArgs e)
        {
            FormManager.Instance.AddForm(this);

            KontrolerKIObaveze kkiObaveze = (KontrolerKIObaveze)kontroler;

            kkiObaveze.VratiSveObaveze();

            if (!kkiObaveze.Signal)
            {
                MessageBox.Show(kkiObaveze.Poruka);
                this.Close();
                return;
            }

            PostaviDataTable();

            dgvObaveze.DataSource = kkiObaveze.PrikaziObaveze(1);

            

            dgvObaveze.Columns[0].Width = 150;

            dtpDatumPostavljanja.Enabled = false;
            dtpDatumRokaIzvrsenja.Enabled = false;

        }

        private void btnOnOffDatumPostavljanja_Click(object sender, EventArgs e)
        {
            if (dtpDatumPostavljanja.Enabled)
            {
                dtpDatumPostavljanja.Enabled = false;
            }
            else
            {
                dtpDatumPostavljanja.Enabled = true;
            }
        }

        private void btnOnOffDatumRokaIzvrsenja_Click(object sender, EventArgs e)
        {
            if (dtpDatumRokaIzvrsenja.Enabled)
            {
                dtpDatumRokaIzvrsenja.Enabled = false;
            }
            else
            {
                dtpDatumRokaIzvrsenja.Enabled = true;
            }
        }

        private void btnPronadji_Click(object sender, EventArgs e)
        {
            string Postavio = !string.IsNullOrWhiteSpace(txtPostavio.Text) ? txtPostavio.Text : null;
            string Izvrsava = !string.IsNullOrWhiteSpace(txtIzvrsava.Text) ? txtIzvrsava.Text : null;
            string Naziv = !string.IsNullOrWhiteSpace(txtNaziv.Text) ? txtNaziv.Text : null;
            DateTime datumPostavljanja  = dtpDatumPostavljanja.Enabled ? dtpDatumPostavljanja.Value : DateTime.MinValue;
            DateTime datumRokaIzvrsenja = dtpDatumRokaIzvrsenja.Enabled ? dtpDatumRokaIzvrsenja.Value : DateTime.MinValue;

            kontroler.ZahtevZaOperaciju = Domen.Operacija.PronadjiObaveze;

            kontroler.GrafickiObjekti = new List<object>()
            {
                Postavio,
                datumPostavljanja,
                datumRokaIzvrsenja,
                Naziv,
                Izvrsava
            };

            kontroler.IzvrsiZahtev();

            PostaviDataTable();

            dgvObaveze.DataSource = ((KontrolerKIObaveze)kontroler).PrikaziObaveze(1);

            

            MessageBox.Show(kontroler.Poruka);
        }

        private void PostaviDataTable()
        {
            lblPrikazi.Text = $"{((KontrolerKIObaveze)kontroler).Obaveze.Count} prikaza.";
            cmbPrikazi.DataSource = ((KontrolerKIObaveze)kontroler).OdrediBrojStranica();
        }


        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            if(dgvObaveze.SelectedRows.Count == 1)
            {
                kontroler.ZahtevZaOperaciju = Domen.Operacija.OdaberiObavezu;

                ((KontrolerKIObaveze)kontroler).OdaberiObavezu(dgvObaveze.SelectedRows[0].DataBoundItem);

                MessageBox.Show(kontroler.Poruka);


                if (kontroler.Signal)
                {
                    FormaObaveza fo = new FormaObaveza();
                    fo.ShowDialog();
                }
            }
        }

        private void dgvObaveze_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                ((KontrolerKIObaveze)kontroler).SortirajObaveze(dgvObaveze.Columns[e.ColumnIndex].HeaderText);
                dgvObaveze.DataSource = ((KontrolerKIObaveze)kontroler).PrikaziObaveze((int)cmbPrikazi.SelectedItem);
            }
            
        }

        private void cmbPrikazi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvObaveze.DataSource = ((KontrolerKIObaveze)kontroler).PrikaziObaveze((int)cmbPrikazi.SelectedItem);
        }
    }
}
