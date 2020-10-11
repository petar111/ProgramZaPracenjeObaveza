using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SesijaKlijent;

namespace KontrolerKI
{
    public class KontrolerKIObaveze : OpstiKontrolerKI
    {
        public List<Obaveza> Obaveze { get; set; }
        public override void IzvrsiKonverzijuObjekta()
        {
            
        }

        protected override void IzvrsiDodatneOperacije()
        {
            base.IzvrsiDodatneOperacije();

            if (Signal)
            {
                List<Obaveza> obaveze = ((List<Obaveza>)ObjekatOdgovor).OrderBy(o => o.Naziv).ToList();
                Obaveze = obaveze;
            }
        }

        protected override void NapraviObjekteOdForme()
        {
            DomenskiObjektiZahtev = new Obaveza()
            {
                PostavioObavezu = new Korisnik()
                {
                    KorisnickoIme = (string)GrafickiObjekti[0]
                },
                DatumPostavljanja = (DateTime)GrafickiObjekti[1],
                DatumRokaIzvrsenja = (DateTime)GrafickiObjekti[2],
                Naziv = (string)GrafickiObjekti[3]
            };

            Obaveza currObaveza = (Obaveza)DomenskiObjektiZahtev;

            currObaveza.IzvrsiociObaveze = new List<IzvrsilacObaveze>()
            {
                new IzvrsilacObaveze()
                {
                    Obaveza = currObaveza,
                    Korisnik = new Korisnik()
                    {
                        KorisnickoIme = (string)GrafickiObjekti[4]
                    }
                }
            };
        }

        public void VratiSveObaveze()
        {
            ZahtevZaOperaciju = Operacija.VratiSveObaveze;

            Zahtev zahtev = new Zahtev()
            {
                Operacija = ZahtevZaOperaciju
            };

            SinhronoSlanjeZahtevaICitanjeOdgovora(zahtev);

            Signal = StatusOdgovora == Status.OK;

            if (!Signal)
            {
                return;
            }

            List<Obaveza> obaveze = ((List<Obaveza>)ObjekatOdgovor).OrderBy(o => o.Naziv).ToList();
            Obaveze = obaveze;
            

        }

        public void OdaberiObavezu(object obaveza)
        {
            Obaveza obavezaZaOdabiranje = (Obaveza)obaveza;

            obavezaZaOdabiranje.StavkeObaveze = new List<StavkaObaveze>()
            {
                new StavkaObaveze()
            };
            obavezaZaOdabiranje.Izvrsavaju = new List<Korisnik>()
            {
                new Korisnik()
            };
            obavezaZaOdabiranje.IzvrsiociObaveze = new List<IzvrsilacObaveze>()
            {
                new IzvrsilacObaveze()
            };

            Zahtev zahtev = new Zahtev()
            {
                Operacija = ZahtevZaOperaciju,
                Objekat = obavezaZaOdabiranje
            };

            SinhronoSlanjeZahtevaICitanjeOdgovora(zahtev);

            Signal = StatusOdgovora == Status.OK;

            ValidacijaOdgovora();

            if (Signal)
            {
                Sesija.Instance.KreiranaObaveza = (Obaveza)ObjekatOdgovor;
                Sesija.Instance.StavkeObaveze = new BindingList<StavkaObaveze>(Sesija.Instance.KreiranaObaveza.StavkeObaveze);
                Sesija.Instance.IzvrsiociObaveze = new BindingList<Korisnik>(Sesija.Instance.KreiranaObaveza.Izvrsavaju);
            }

        }

        public List<Obaveza> PrikaziObaveze(int index)
        {
            int startIndex = 15 * (index - 1);
            int endIndex = 15 * index - 1;

            if(endIndex < startIndex)
            {
                return new List<Obaveza>();
            }

            if(endIndex > Obaveze.Count)
            {
                endIndex = Obaveze.Count - 1;
            }

            return Obaveze.GetRange(startIndex, endIndex - startIndex + 1);
        }

        public List<int> OdrediBrojStranica()
        {
            List<int> stranice = new List<int>();

            int brStanica = Obaveze.Count / 15;
            for (int i = 1; i <= brStanica; i++)
            {
                stranice.Add(i);
            }

            if(Obaveze.Count % 15 != 0)
            {
                stranice.Add(brStanica + 1);
            }

            return stranice;
        }


        private void ValidacijaOdgovora()
        {
            if (Signal)
            {
                Obaveza provera = (Obaveza)ObjekatOdgovor;
                if((Sesija.Instance.RezimRadaSaObavezom == RezimRadaSaObavezom.Izmena ||
                    Sesija.Instance.RezimRadaSaObavezom == RezimRadaSaObavezom.Ponistavanje ||
                    Sesija.Instance.RezimRadaSaObavezom == RezimRadaSaObavezom.Potvrda ||
                    Sesija.Instance.RezimRadaSaObavezom == RezimRadaSaObavezom.PotvrdaIzvrsenja) &&
                    (provera.Ponistena || provera.Potvrdjena))
                {
                    Signal = false;
                    Poruka = "Sistem ne moze da odabere obavezu.";
                }

                if((Sesija.Instance.RezimRadaSaObavezom == RezimRadaSaObavezom.Izmena ||
                    Sesija.Instance.RezimRadaSaObavezom == RezimRadaSaObavezom.Ponistavanje ||
                    Sesija.Instance.RezimRadaSaObavezom == RezimRadaSaObavezom.Potvrda) &&
                    provera.PostavioObavezu.Id != Sesija.Instance.Korisnik.Id)
                {
                    Signal = false;
                    Poruka = "Sistem ne moze da odabere obavezu.";
                }

                if (Sesija.Instance.RezimRadaSaObavezom == RezimRadaSaObavezom.PotvrdaIzvrsenja && provera.FindIzvrsilac(Sesija.Instance.Korisnik) == null)
                {
                    Signal = false;
                    Poruka = "Sistem ne moze da odabere obavezu.";
                }
                
            }
        }

        public void SortirajObaveze(string headerText)
        {
            switch (headerText)
            {
                case "DatumPostavljanja":
                    Obaveze = Obaveze.OrderBy(o => o.DatumPostavljanja).ToList();
                    break;
                case "DatumRokaIzvrsenja":
                    Obaveze = Obaveze.OrderBy(o => o.DatumRokaIzvrsenja).ToList();
                    break;
                case "Postavio":
                    Obaveze = Obaveze.OrderBy(o => o.NazivPostavio).ToList();
                    break;
                case "Naziv":
                    Obaveze = Obaveze.OrderBy(o => o.Naziv).ToList();
                    break;
                case "TipObaveze":
                    Obaveze = Obaveze.OrderBy(o => o.TipObaveze.Naziv).ToList();
                    break;
            }
        }
    }
}
