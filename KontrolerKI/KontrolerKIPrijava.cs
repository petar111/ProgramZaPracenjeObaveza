using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace KontrolerKI
{
    public class KontrolerKIPrijava : OpstiKontrolerKI
    {


        public override void IzvrsiKonverzijuObjekta()
        {
           
        }

        protected override void IzvrsiDodatneOperacije()
        {

            base.IzvrsiDodatneOperacije();

            if (Signal)
            {
                SesijaKlijent.Sesija.Instance.Korisnik = (Korisnik)ObjekatOdgovor;
            }
            else
            {
                KomunikacijaSaServerom.Komunikacija.Instance.ZatvoriKonekciju();
            }

        }


        

    protected override void NapraviObjekteOdForme()
        {
            DomenskiObjektiZahtev =  new Korisnik()
            {
                KorisnickoIme = (string)GrafickiObjekti[0],
                Sifra = (string)GrafickiObjekti[1]
            };

        }

    }
}
