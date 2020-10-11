using Domen;
using KomunikacijaSaServerom;
using SesijaKlijent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolerKI
{
    public class Kontroler
    {

        public static readonly Kontroler Instance = new Kontroler();


        private Kontroler()
        {

        }

        public bool PrijaviSe(string korisnickoIme, string sifra, out string poruka)
        {

            Zahtev zahtev = new Zahtev()
            {
                Objekat = new Korisnik
                {
                    KorisnickoIme = korisnickoIme,
                    Sifra = sifra
                },
                Operacija = Operacija.PrijaviSe
            };

            Komunikacija.Instance.PosaljiZahtev(zahtev);

            Odgovor odgovor = Komunikacija.Instance.ProcitajOdgovor();
            poruka = odgovor.Poruka;

            bool signal = odgovor.Status != Status.ERROR;

            if (signal)
            {
                Sesija.Instance.Korisnik = (Korisnik)odgovor.Objekat;
            }
            else
            {
                Komunikacija.Instance.ZatvoriKonekciju();
            }

            return signal;
        }
    }
}
