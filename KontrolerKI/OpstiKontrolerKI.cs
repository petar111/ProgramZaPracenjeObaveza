using Domen;
using SesijaKlijent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KontrolerKI
{
    public abstract class OpstiKontrolerKI
    {
        public Operacija ZahtevZaOperaciju { get; set; }

        public List<object> GrafickiObjekti { get; set; }

        public object DomenskiObjektiZahtev { get; set; }

        public object ObjekatOdgovor { get; set; }

        public string Poruka { get; set; }

        public Status StatusOdgovora { get; set; }

        public List<object> GrafickiObjektiOdgovor { get; set; }

        public bool Signal { get; set; }


        public void IzvrsiZahtev()
        {
            NapraviObjekteOdForme();

            Zahtev zahtev = new Zahtev()
            {
                Operacija = ZahtevZaOperaciju,
                Objekat = DomenskiObjektiZahtev
            };

            SinhronoSlanjeZahtevaICitanjeOdgovora(zahtev);

            IzvrsiDodatneOperacije();

            if (Signal)
            {
                IzvrsiKonverzijuObjekta();
            }
        }

        protected void SinhronoSlanjeZahtevaICitanjeOdgovora(Zahtev zahtev)
        {
            try
            {
                KomunikacijaSaServerom.Komunikacija.Instance.PosaljiZahtev(zahtev);

                Odgovor odgovor = KomunikacijaSaServerom.Komunikacija.Instance.ProcitajOdgovor();

                Poruka = odgovor.Poruka;
                ObjekatOdgovor = odgovor.Objekat;
                StatusOdgovora = odgovor.Status;
            }
            catch (Exception)
            {
                Poruka = "SERVER JE PAO.";
                ObjekatOdgovor = null;
                StatusOdgovora = Status.SERVERDOWN;
                FormManager.Instance.ServerDown();
            }
        }

        protected virtual void IzvrsiDodatneOperacije() {

            Signal = StatusOdgovora == Status.OK;
        }


        public abstract void IzvrsiKonverzijuObjekta();

        protected abstract void NapraviObjekteOdForme();
        

    }
}
