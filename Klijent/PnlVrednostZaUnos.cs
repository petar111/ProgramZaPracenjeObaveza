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
    public partial class PnlVrednostZaUnos : UserControl
    {
        public Label LblVrednost { get { return lblVrednost; } }

        public Label LblVrednostUpozorenje { get { return lblVrednostUpozorenje; } }

        public TextBox TxtVrednost { get { return txtVrednost; } }

        public PnlVrednostZaUnos()
        {
            InitializeComponent();
        }
    }
}
