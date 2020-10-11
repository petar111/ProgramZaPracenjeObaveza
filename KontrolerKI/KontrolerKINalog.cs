using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace KontrolerKI
{
    public class KontrolerKINalog : OpstiKontrolerKI
    {


        protected override void IzvrsiDodatneOperacije()
        {
            base.IzvrsiDodatneOperacije();

            if (Signal)
            {
                SesijaKlijent.Sesija.Instance.Korisnik = (Korisnik)ObjekatOdgovor;
            }
        }
        public override void IzvrsiKonverzijuObjekta()
        {
            Korisnik korisnik = (Korisnik)ObjekatOdgovor;

            GrafickiObjektiOdgovor = new List<object>()
            {
                korisnik.Ime,
                korisnik.Prezime,
                korisnik.KorisnickoIme,
                korisnik.Sifra
            };
        }

        protected override void NapraviObjekteOdForme()
        {
            DomenskiObjektiZahtev = new Korisnik()
            {
                Ime = (string)GrafickiObjekti[0],
                Prezime = (string)GrafickiObjekti[1],
                KorisnickoIme = (string)GrafickiObjekti[2],
                Sifra = (string)GrafickiObjekti[3]
            };

            if(SesijaKlijent.Sesija.Instance.Korisnik != null)
            {
                ((Korisnik)DomenskiObjektiZahtev).Id = SesijaKlijent.Sesija.Instance.Korisnik.Id;
            }

        }
    }
}
