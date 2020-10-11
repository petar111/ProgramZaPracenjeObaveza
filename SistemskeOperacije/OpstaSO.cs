using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public abstract class OpstaSO
    {

        protected Broker broker = new Broker();
        public string Poruka { get; set; }
        protected abstract void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat);
        protected abstract void Validacija(IDomenskiObjekat objekat);
        public void Izvrsi(IDomenskiObjekat objekat)
        {
            try
            {
                Validacija(objekat);
                broker.OtvoriKonekciju();
                broker.PokreniTransakciju();
                IzvrsiKonkretnuOperaciju(objekat);
                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

    }
}
