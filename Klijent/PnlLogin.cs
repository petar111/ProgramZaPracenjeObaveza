using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class PnlLogin : UserControl
    {

        public PnlVrednostZaUnos PanelSifra { get { return pnlSifra; } }

        public PnlVrednostZaUnos PanelKorisnickoIme { get { return pnlKorisnickoIme; } }
        public PnlLogin()
        {
            InitializeComponent();

            PrepareView();
        }

        private void PrepareView()
        {
            pnlKorisnickoIme.LblVrednost.Text = "Korisnicko ime:";
            pnlKorisnickoIme.LblVrednostUpozorenje.Text = "";

            pnlSifra.LblVrednost.Text = "Sifra:";
            pnlSifra.LblVrednostUpozorenje.Text = "";

            pnlSifra.TxtVrednost.PasswordChar = '●';
        }
    }
}
