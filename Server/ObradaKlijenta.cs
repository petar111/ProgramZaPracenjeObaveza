using Domen;
using KontrolerAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ObradaKlijenta
    {
        [Browsable(false)]
        public Korisnik PodaciKlijenta { get; set; }

        public string KorisnickoImePrijavljenog { get { return PodaciKlijenta != null ? PodaciKlijenta.KorisnickoIme : "Neprijavljen"; } }

        //public string IP { get => Soket.RemoteEndPoint.ToString(); }

        [Browsable(false)]
        public Socket Soket { get; set; }

        [Browsable(false)]
        public NetworkStream Tok { get; set; }

        private BinaryFormatter formatter = new BinaryFormatter();


        public Odgovor NapraviOdgovor(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();

            switch (zahtev.Operacija)
            {
                case Operacija.PrijaviSe:
                    Korisnik korisnikTryPrijava = (Korisnik)zahtev.Objekat;
                    Korisnik korisnikOdgovor = Kontroler.Instance.Prijava(korisnikTryPrijava);
                    odgovor.Objekat = korisnikOdgovor;

                    if (korisnikOdgovor != null)
                    {
                        odgovor.Poruka = "Uspesno ste se prijavili.";
                        odgovor.Status = Status.OK;

                        PodaciKlijenta = korisnikOdgovor;
                    }
                    else
                    {
                        odgovor.Poruka = "Prijavljivanje nije uspelo.";
                        odgovor.Status = Status.ERROR;
                    }

                    break;
                case Operacija.KreirajNoviNalog:
                    Korisnik noviKorisnik = (Korisnik)zahtev.Objekat;
                    Korisnik kreiraniKorisnik = Kontroler.Instance.KreirajNoviNalog(noviKorisnik);
                    odgovor.Objekat = kreiraniKorisnik;

                    if (kreiraniKorisnik != null)
                    {
                        odgovor.Poruka = "Sistem je kreirao nalog.";
                        odgovor.Status = Status.OK;
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem ne moze da kreira nalog.";
                        odgovor.Status = Status.ERROR;
                    }

                    break;
                case Operacija.ZapamtiNalog:
                    Korisnik korisnikZaPamcenje = (Korisnik)zahtev.Objekat;
                    Korisnik zapamceniKorisnik = Kontroler.Instance.ZapamtiNalog(korisnikZaPamcenje);
                    odgovor.Objekat = zapamceniKorisnik;

                    if (zapamceniKorisnik != null)
                    {
                        odgovor.Poruka = "Sistem je zapamtio nalog.";
                        odgovor.Status = Status.OK;

                        PodaciKlijenta = zapamceniKorisnik;
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem ne moze da zapamti nalog.";
                        odgovor.Status = Status.ERROR;
                    }

                    break;
                case Operacija.ObrisiNalog:
                    Korisnik korisnikZaBrisanje = (Korisnik)zahtev.Objekat;
                    Korisnik obrisaniKorisnik = Kontroler.Instance.ObrisiNalog(korisnikZaBrisanje);
                    odgovor.Objekat = obrisaniKorisnik;

                    if (obrisaniKorisnik != null)
                    {
                        odgovor.Poruka = "Sistem je obrisao nalog.";
                        odgovor.Status = Status.OK;
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem ne moze da obrise nalog.";
                        odgovor.Status = Status.ERROR;
                    }

                    break;

                case Operacija.VratiSveKorisnike:
                    List<Korisnik> sviKorisnici = Kontroler.Instance.VratiSveKorisnike();
                    odgovor.Objekat = sviKorisnici;

                    if (sviKorisnici == null)
                    {
                        odgovor.Status = Status.ERROR;
                        odgovor.Poruka = "Sistem ne moze da ucita korisnike.";
                    }
                    else
                    {
                        odgovor.Status = Status.OK;
                    }

                    break;

                case Operacija.VratiSveTipoveObaveza:
                    List<TipObaveze> tipoviObaveza = Kontroler.Instance.VratiSveTipoveObaveza();
                    odgovor.Objekat = tipoviObaveza;

                    if (tipoviObaveza == null)
                    {
                        odgovor.Status = Status.ERROR;
                        odgovor.Poruka = "Sistem ne moze da ucita tipove obaveza.";
                    }
                    else
                    {
                        odgovor.Status = Status.OK;
                    }

                    break;
                case Operacija.NapraviNovuObavezu:
                    Obaveza novaObaveza = (Obaveza)zahtev.Objekat;
                    Obaveza kreiranaObaveza = Kontroler.Instance.KreirajNovuObavezu(novaObaveza);
                    odgovor.Objekat = kreiranaObaveza;

                    if (kreiranaObaveza != null)
                    {
                        odgovor.Poruka = "Sistem je kreirao obavezu.";
                        odgovor.Status = Status.OK;
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem ne moze da kreira obavezu.";
                        odgovor.Status = Status.ERROR;
                    }

                    break;
                case Operacija.ZapamtiObavezu:
                    Obaveza obavezaZaPamcenje = (Obaveza)zahtev.Objekat;
                    Obaveza zapamcenaObaveza = Kontroler.Instance.ZapamtiObavezu(obavezaZaPamcenje);
                    odgovor.Objekat = zapamcenaObaveza;

                    if (zapamcenaObaveza != null)
                    {
                        odgovor.Poruka = "Sistem je zapamtio obavezu.";
                        odgovor.Status = Status.OK;
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem ne moze da zapamti obavezu.";
                        odgovor.Status = Status.ERROR;
                    }

                    break;
                case Operacija.VratiSveObaveze:
                    List<Obaveza> obaveze = Kontroler.Instance.VratiSveObaveze();

                    odgovor.Objekat = obaveze;

                    if (obaveze == null)
                    {
                        odgovor.Status = Status.ERROR;
                        odgovor.Poruka = "Sistem ne moze da ucita obaveze.";
                    }
                    else
                    {
                        odgovor.Status = Status.OK;
                    }

                    break;
                case Operacija.PronadjiObaveze:
                    Obaveza obavezaKriterijum = (Obaveza)zahtev.Objekat;
                    List<Obaveza> pronadjeneObaveze = Kontroler.Instance.PronadjiObaveze(obavezaKriterijum);

                    odgovor.Objekat = pronadjeneObaveze;

                    if (pronadjeneObaveze == null)
                    {
                        odgovor.Status = Status.ERROR;
                        odgovor.Poruka = "Sistem ne moze da pronadje obaveze po zadatoj vrednosti.";
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem je nasao obaveze po zadatoj vrednosti.";
                        odgovor.Status = Status.OK;
                    }


                    break;
                case Operacija.OdaberiObavezu:
                    Obaveza tryObaveza = (Obaveza)zahtev.Objekat;
                    Obaveza odabranaObaveza = Kontroler.Instance.OdaberiObavezu(tryObaveza);

                    odgovor.Objekat = odabranaObaveza;

                    if (odabranaObaveza == null)
                    {
                        odgovor.Status = Status.ERROR;
                        odgovor.Poruka = "Sistem ne moze da odabere obavezu.";
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem je odabrao obavezu.";
                        odgovor.Status = Status.OK;
                    }

                    break;
                case Operacija.PotvrdiObavezu:
                    Obaveza obavezaZaPotvrdu = (Obaveza)zahtev.Objekat;
                    Obaveza potvrdjenaObaveza = Kontroler.Instance.PotvrdiObavezu(obavezaZaPotvrdu);
                    odgovor.Objekat = potvrdjenaObaveza;

                    if (potvrdjenaObaveza != null)
                    {
                        odgovor.Poruka = "Sistem je potvrdio obavezu.";
                        odgovor.Status = Status.OK;
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem ne moze da potvdi obavezu.";
                        odgovor.Status = Status.ERROR;
                    }

                    break;
                case Operacija.PonistiObavezu:
                    Obaveza obavezaZaPonistavanje = (Obaveza)zahtev.Objekat;
                    Obaveza ponistenaObaveza = Kontroler.Instance.PonistiObavezu(obavezaZaPonistavanje);
                    odgovor.Objekat = ponistenaObaveza;

                    if (ponistenaObaveza != null)
                    {
                        odgovor.Poruka = "Sistem je ponistio obavezu.";
                        odgovor.Status = Status.OK;
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem ne moze da ponisti obavezu.";
                        odgovor.Status = Status.ERROR;
                    }

                    break;
                case Operacija.PotvrdiIzvrsenjeObaveze:
                    IzvrsilacObaveze potvrdaIzvrsioca = (IzvrsilacObaveze)zahtev.Objekat;
                    IzvrsilacObaveze potvrdjenIzvrsilac = Kontroler.Instance.PotvrdiIzvrsenjeObaveze(potvrdaIzvrsioca);

                    odgovor.Objekat = potvrdjenIzvrsilac;

                    if (potvrdjenIzvrsilac != null)
                    {
                        odgovor.Poruka = "Sistem je potvrdio izvrsenje obaveze.";
                        odgovor.Status = Status.OK;
                    }
                    else
                    {
                        odgovor.Poruka = "Sistem ne moze da potvrdi izvrsenje obaveze.";
                        odgovor.Status = Status.ERROR;
                    }
                    break;
                default:
                    break;
            }


            return odgovor;
        }

        internal void PocniObradu()
        {
            bool kraj = false;

            while (!kraj)
            {
                try
                {
                    Zahtev zahtev = ProcitajZahtev();
                    Odgovor odgovor = NapraviOdgovor(zahtev);
                    PosaljiOdgovor(odgovor);
                }
                catch (Exception)
                {
                    Soket.Close();
                    kraj = true;
                }
            }
        }

        private Zahtev ProcitajZahtev()
        {
            return (Zahtev)formatter.Deserialize(Tok);
        }

        public void PosaljiOdgovor(Odgovor odgovor)
        {
            formatter.Serialize(Tok, odgovor);
        }
       
    }
}
