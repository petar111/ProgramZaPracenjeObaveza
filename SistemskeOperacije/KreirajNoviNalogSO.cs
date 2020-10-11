using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class KreirajNoviNalogSO : OpstaSO
    {
        public Korisnik NoviKorisnik { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {
                int id = (int)broker.Insert(objekat);
                NoviKorisnik = (Korisnik)objekat;
                NoviKorisnik.Id = id;
            }
            catch (Exception)
            {

                NoviKorisnik = null;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if(objekat is null)
            {
                throw new Exception("Objekat je null vrednost.");
            }
        }
    }
}
