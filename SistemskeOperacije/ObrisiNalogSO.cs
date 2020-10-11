using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class ObrisiNalogSO : OpstaSO
    {
        public Korisnik ObrisaniNalog { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {
                int rows = broker.DeleteObject(objekat);

                if (rows == 1)
                {
                    ObrisaniNalog = (Korisnik)objekat;
                }
            }
            catch (Exception)
            {

                ObrisaniNalog = null;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
        }
    }
}
