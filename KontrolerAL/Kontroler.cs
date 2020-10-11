using Domen;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolerAL
{
    public class Kontroler
    {

        private static Kontroler _instance = new Kontroler();
        public static Kontroler Instance
        {
            get
            {
                return _instance;
            }
        }
        private Kontroler()
        {
        }

        public Korisnik Prijava(Korisnik korisnikTryPrijava)
        {

                OpstaSO prijavaSO = new PrijavaSO();


                prijavaSO.Izvrsi(korisnikTryPrijava);


                return ((PrijavaSO)prijavaSO).PrijavljeniKorisnik;

        }

        public Korisnik KreirajNoviNalog(Korisnik noviKorisnik)
        {

                OpstaSO kreirajNoviNalogSO = new KreirajNoviNalogSO();


                kreirajNoviNalogSO.Izvrsi(noviKorisnik);


                return ((KreirajNoviNalogSO)kreirajNoviNalogSO).NoviKorisnik;
        }

        public Korisnik ZapamtiNalog(Korisnik korisnikZaPamcenje)
        {
                OpstaSO zapamtiNalogSO = new ZapamtiNalogSO();


                zapamtiNalogSO.Izvrsi(korisnikZaPamcenje);


                return ((ZapamtiNalogSO)zapamtiNalogSO).ZapamceniKorisnik;
        }

        public Korisnik ObrisiNalog(Korisnik korisnikZaBrisanje)
        {

                OpstaSO obrisiNalogSO = new ObrisiNalogSO();


                obrisiNalogSO.Izvrsi(korisnikZaBrisanje);


                return ((ObrisiNalogSO)obrisiNalogSO).ObrisaniNalog;

        }

        public List<Korisnik> VratiSveKorisnike()
        {
            OpstaSO vratiSveKorisnike = new VratiSveKorisnikeSO();

            vratiSveKorisnike.Izvrsi(new Korisnik());

            return ((VratiSveKorisnikeSO)vratiSveKorisnike).Korisnici;
        }

        public List<TipObaveze> VratiSveTipoveObaveza()
        {
            OpstaSO vratiSveKorisnike = new VratiTipoveObavezaSO();

            vratiSveKorisnike.Izvrsi(new TipObaveze());

            return ((VratiTipoveObavezaSO)vratiSveKorisnike).TipoviObaveza;
        }

        public Obaveza KreirajNovuObavezu(Obaveza novaObaveza)
        {
            OpstaSO kreirajObavezu = new KreirajObavezuSO();

            kreirajObavezu.Izvrsi(novaObaveza);

            return ((KreirajObavezuSO)kreirajObavezu).KreiranaObaveza;
        }

        public Obaveza ZapamtiObavezu(Obaveza obavezaZaPamcenje)
        {
            OpstaSO zapamtiObavezu = new ZapamtiObavezuSO();

            zapamtiObavezu.Izvrsi(obavezaZaPamcenje);

            return ((ZapamtiObavezuSO)zapamtiObavezu).ZapamcenaObaveza;
        }

        public List<Obaveza> VratiSveObaveze()
        {
            OpstaSO ucitajObaveze = new UcitajObavezeSO();

            ucitajObaveze.Izvrsi(new Obaveza());

            return ((UcitajObavezeSO)ucitajObaveze).UcitaneObaveze;
        }

        public List<Obaveza> PronadjiObaveze(Obaveza obavezaKriterijum)
        {
            OpstaSO pronadjiObaveze = new PronadjiObavezeSO();

            pronadjiObaveze.Izvrsi(obavezaKriterijum);

            return ((PronadjiObavezeSO)pronadjiObaveze).PronadjeneObaveze;
        }

        public Obaveza OdaberiObavezu(Obaveza tryObaveza)
        {
            OpstaSO odaberiObavezu = new OdaberiObavezuSO();

            odaberiObavezu.Izvrsi(tryObaveza);

            return ((OdaberiObavezuSO)odaberiObavezu).OdabranaObaveza;
        }

        public Obaveza PotvrdiObavezu(Obaveza obavezaZaPotvrdu)
        {
            OpstaSO potvrdiObavezu = new PotvrdiObavezuSO();

            potvrdiObavezu.Izvrsi(obavezaZaPotvrdu);

            return ((PotvrdiObavezuSO)potvrdiObavezu).PotvrdjenaObaveza;
        }

        public Obaveza PonistiObavezu(Obaveza obavezaZaPonistavanje)
        {
            OpstaSO ponistiObavezu = new PonistiObavezuSO();

            ponistiObavezu.Izvrsi(obavezaZaPonistavanje);

            return ((PonistiObavezuSO)ponistiObavezu).PonistenaObaveza;
        }

        public IzvrsilacObaveze PotvrdiIzvrsenjeObaveze(IzvrsilacObaveze potvrdaIzvrsioca)
        {
            OpstaSO potvrdiIzvrsenjeObaveze = new PotvrdiIzvrsenjeObavezeSO();

            potvrdiIzvrsenjeObaveze.Izvrsi(potvrdaIzvrsioca);

            return ((PotvrdiIzvrsenjeObavezeSO)potvrdiIzvrsenjeObaveze).PotvrdjenIzvrsilac;
        }
    }
}
