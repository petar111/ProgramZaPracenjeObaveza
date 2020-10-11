using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SesijaKlijent
{
    public enum RezimRadaSaObavezom
    {
        Pretraga,
        PotvrdaIzvrsenja,
        Ponistavanje,
        PostavljanjeNove,
        Potvrda,
        Izmena
    }
    public class Sesija
    {

        public static readonly Sesija Instance = new Sesija();

        private Sesija()
        {
            Korisnik = new Korisnik()
            {
                Id = int.MinValue,
                KorisnickoIme = "",
                Sifra = "",
                Ime = "",
                Prezime = ""
            };

            StavkeObaveze = new BindingList<StavkaObaveze>();
            IzvrsiociObaveze = new BindingList<Korisnik>();
        }

        public void ResetLists()
        {
            StavkeObaveze?.Clear();
            IzvrsiociObaveze?.Clear();
        }
        public RezimRadaSaObavezom RezimRadaSaObavezom { get; set; }
        public Obaveza KreiranaObaveza { get; set; }

        //public Obaveza OdabranaObaveza { get; set; }

        public BindingList<StavkaObaveze> StavkeObaveze { get; set; }
        public BindingList<Korisnik> IzvrsiociObaveze { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
