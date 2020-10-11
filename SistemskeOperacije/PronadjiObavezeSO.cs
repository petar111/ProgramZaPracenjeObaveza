using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class PronadjiObavezeSO : OpstaSO
    {
        public List<Obaveza> PronadjeneObaveze { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Obaveza obavezaKriterijum = (Obaveza)objekat;

            string criteria = "where ";
            if(obavezaKriterijum.Naziv != null)
            {
                criteria += $"obaveza.Naziv LIKE '%{obavezaKriterijum.Naziv}%' AND ";
            }

            if (obavezaKriterijum.PostavioObavezu.KorisnickoIme != null)
            {
                
                criteria += $"obaveza.IdKorisnika IN (SELECT IdKorisnika from Korisnik WHERE KorisnickoIme LIKE '%{obavezaKriterijum.PostavioObavezu.KorisnickoIme}%') AND " ;
            }

            if (obavezaKriterijum.DatumPostavljanja != DateTime.MinValue)
            {

                criteria += $"obaveza.DatumPostavljanja = '{obavezaKriterijum.DatumPostavljanja.ToShortDateString()}' AND ";
            }

            if (obavezaKriterijum.DatumRokaIzvrsenja != DateTime.MinValue)
            {

                criteria += $"obaveza.DatumRokaIzvrsenja = '{obavezaKriterijum.DatumRokaIzvrsenja.ToShortDateString()}' AND ";
            }

            if (obavezaKriterijum.IzvrsiociObaveze[0].Korisnik.KorisnickoIme != null)
            {

                criteria += $"izvrsilacObaveze.IdKorisnika IN(SELECT IdKorisnika from Korisnik WHERE KorisnickoIme LIKE '%{obavezaKriterijum.IzvrsiociObaveze[0].Korisnik.KorisnickoIme}%')";
            }

            if(criteria.EndsWith(" AND "))
            {
                criteria += "1=1";
            }

            if (criteria.EndsWith("where "))
            {
                criteria = "";
            }

            try
            {
                PronadjeneObaveze = broker.SearchJoin(criteria, objekat).ConvertAll(o => (Obaveza)o);

                if(PronadjeneObaveze.Count == 0)
                {
                    PronadjeneObaveze = null;
                }
            }
            catch (Exception)
            {

                PronadjeneObaveze = null;
            }

        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
        }
    }
}
