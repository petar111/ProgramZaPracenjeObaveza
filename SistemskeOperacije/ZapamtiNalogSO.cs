using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class ZapamtiNalogSO : OpstaSO
    {
        public Korisnik ZapamceniKorisnik { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {
                int updatedRows = broker.UpdateObject(objekat);

                if (updatedRows == 1)
                {
                    ZapamceniKorisnik = (Korisnik)objekat;
                }
            }
            catch (Exception)
            {
                ZapamceniKorisnik = null;
                Korisnik tmp = (Korisnik)broker.SearchById(objekat);
                if (string.IsNullOrWhiteSpace(tmp.KorisnickoIme))
                {
                    broker.DeleteObject(tmp);
                }
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
