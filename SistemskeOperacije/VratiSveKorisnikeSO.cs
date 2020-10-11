using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class VratiSveKorisnikeSO : OpstaSO
    {
        public List<Korisnik> Korisnici { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {
                Korisnik korisnik = (Korisnik)objekat;
                Korisnici = broker.VratiSve(korisnik).ConvertAll(o => (Korisnik)o);
            }
            catch (Exception)
            {

                Korisnici = null;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
        }
    }
}
