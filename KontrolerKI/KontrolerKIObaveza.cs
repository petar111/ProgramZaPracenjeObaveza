using Domen;
using SesijaKlijent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolerKI
{
    public class KontrolerKIObaveza : OpstiKontrolerKI
    {
        public BindingList<Korisnik> Korisnici { get; set; }

        public List<TipObaveze> TipoviObaveze { get; set; }

        protected override void IzvrsiDodatneOperacije()
        {
            base.IzvrsiDodatneOperacije();

            if (Signal)
            {
                Sesija.Instance.KreiranaObaveza = (Obaveza)ObjekatOdgovor;
            }
        }

        public override void IzvrsiKonverzijuObjekta()
        {
            Obaveza obaveza = (Obaveza)ObjekatOdgovor;

            GrafickiObjektiOdgovor = new List<object>()
            {
                obaveza.Naziv,
                obaveza.DatumPostavljanja,
                obaveza.DatumRokaIzvrsenja,
                obaveza.Potvrdjena,
                obaveza.Ponistena,
                obaveza.PostavioObavezu.Id,
                obaveza.PostavioObavezu.Ime,
                obaveza.PostavioObavezu.Prezime,
                obaveza.PostavioObavezu.KorisnickoIme,
                obaveza.TipObaveze.IdTipaObaveze,
                obaveza.TipObaveze.Naziv
            };
        }


        protected override void NapraviObjekteOdForme()
        {
            DomenskiObjektiZahtev = new Obaveza()
            {
                Naziv = (string)GrafickiObjekti[0],
                DatumPostavljanja = (DateTime)GrafickiObjekti[1],
                DatumRokaIzvrsenja = (DateTime)GrafickiObjekti[2],
                Potvrdjena = (bool)GrafickiObjekti[3],
                Ponistena = (bool)GrafickiObjekti[4],
                PostavioObavezu = new Korisnik()
                {
                    Id = (int)GrafickiObjekti[5],
                    Ime = (string)GrafickiObjekti[6],
                    Prezime = (string)GrafickiObjekti[7],
                    KorisnickoIme = (string)GrafickiObjekti[8]
                },
                TipObaveze = GrafickiObjekti[9] as TipObaveze,
                StavkeObaveze = new List<StavkaObaveze>(SesijaKlijent.Sesija.Instance.StavkeObaveze),
                Izvrsavaju = new List<Korisnik>(SesijaKlijent.Sesija.Instance.IzvrsiociObaveze)
            };

            ((Obaveza)DomenskiObjektiZahtev).IzvrsiociObaveze = NapraviListuIzvrsioca();

            if (SesijaKlijent.Sesija.Instance.KreiranaObaveza != null)
            {
                ((Obaveza)DomenskiObjektiZahtev).IdObaveze = SesijaKlijent.Sesija.Instance.KreiranaObaveza.IdObaveze;
            }
        }

        public object FindTipObavezeById(TipObaveze tipObaveze)
        {
            foreach (var tipObavezeCurr in TipoviObaveze)
            {
                if(tipObavezeCurr.IdTipaObaveze == tipObaveze.IdTipaObaveze)
                {
                    return tipObavezeCurr;
                }
            }

            throw new Exception($"Unknown {tipObaveze.GetType()}");
        }

        public void FixLists()
        {
            foreach (var izvrsilac in Sesija.Instance.IzvrsiociObaveze)
            {
                foreach (var korisnik in Korisnici)
                {
                    if(korisnik.Id == izvrsilac.Id)
                    {
                        Korisnici.Remove(korisnik);
                        break;
                    }
                }
            }
        }

        private List<IzvrsilacObaveze> NapraviListuIzvrsioca()
        {
            List<IzvrsilacObaveze> result = new List<IzvrsilacObaveze>();

            foreach (var item in Sesija.Instance.IzvrsiociObaveze)
            {
                result.Add(new IzvrsilacObaveze()
                {
                    Obaveza = (Obaveza)DomenskiObjektiZahtev,
                    Korisnik = item,
                    Potvrdjena = false
                });
            }

            return result;
        }

        public void VratiSveKorisnike()
        {
            ZahtevZaOperaciju = Operacija.VratiSveKorisnike;

            Zahtev zahtev = new Zahtev()
            {
                Operacija = ZahtevZaOperaciju
            };

            SinhronoSlanjeZahtevaICitanjeOdgovora(zahtev);


            Signal = StatusOdgovora == Status.OK;

            List<Korisnik> korisnici = ((List<Korisnik>)ObjekatOdgovor).OrderBy(k => k.KorisnickoIme).ToList();
            Korisnici = new BindingList<Korisnik>(korisnici);

        }

        public void VratiSveTipoveObaveza()
        {
            ZahtevZaOperaciju = Operacija.VratiSveTipoveObaveza;

            Zahtev zahtev = new Zahtev()
            {
                Operacija = ZahtevZaOperaciju
            };

            SinhronoSlanjeZahtevaICitanjeOdgovora(zahtev);


            Signal = StatusOdgovora == Status.OK;

            TipoviObaveze = (List<TipObaveze>)ObjekatOdgovor;
        }

        public void DodajIzvrsioca(object izvrsilacObjekat)
        {
            Korisnik izvrsilac = (Korisnik)izvrsilacObjekat;

            Sesija.Instance.IzvrsiociObaveze.Add(izvrsilac);
            Korisnici.Remove(izvrsilac);

            Sesija.Instance.IzvrsiociObaveze = new BindingList<Korisnik>(Sesija.Instance.IzvrsiociObaveze.OrderBy(i => i.KorisnickoIme).ToList());
        }


        public void IzbaciIzvrsioca(object izvrsilacObjekat)
        {
            Korisnik izvrsilac = (Korisnik)izvrsilacObjekat;

            Korisnici.Add(izvrsilac);
            Sesija.Instance.IzvrsiociObaveze.Remove(izvrsilac);

            Korisnici = new BindingList<Korisnik>(Korisnici.OrderBy(i => i.KorisnickoIme).ToList());
        }


        public void ObrisiStavku(object stavkaZaBrisanje)
        {
            int indexOdObrisanog = Sesija.Instance.StavkeObaveze.IndexOf((StavkaObaveze)stavkaZaBrisanje);
            Sesija.Instance.StavkeObaveze.Remove((StavkaObaveze)stavkaZaBrisanje);

            for (int i = indexOdObrisanog; i < Sesija.Instance.StavkeObaveze.Count; i++)
            {
                Sesija.Instance.StavkeObaveze[i].RedniBroj--;
            }
        }

        public void PotvrdiIzvrsenjeObaveze()
        {
            NapraviObjekteOdForme();

            IzvrsilacObaveze izvrsilacObaveze = new IzvrsilacObaveze()
            {
                Obaveza = (Obaveza)DomenskiObjektiZahtev,
                Korisnik = Sesija.Instance.Korisnik,
                Potvrdjena = true
            };

            Zahtev zahtev = new Zahtev()
            {
                Operacija = ZahtevZaOperaciju,
                Objekat = izvrsilacObaveze
            };

            SinhronoSlanjeZahtevaICitanjeOdgovora(zahtev);


            Signal = StatusOdgovora == Status.OK;
        }
    }
}
