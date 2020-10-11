using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class PrijavaSO : OpstaSO
    {
        public Korisnik PrijavljeniKorisnik { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {
                List<Korisnik> korisnici = broker.Search("", objekat).ConvertAll(o => (Korisnik)o);

                if (korisnici.Count == 1)
                {
                    PrijavljeniKorisnik = korisnici[0];
                }
                else
                {
                    PrijavljeniKorisnik = null;
                }
            }
            catch (Exception)
            {

                PrijavljeniKorisnik = null;
            }

        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            Korisnik korisnik = (Korisnik)objekat;

            if (string.IsNullOrEmpty(korisnik.KorisnickoIme))
            {
                throw new Exception("Korisnicko ime je null ili prazan string.");
            }

        }
    }
}
