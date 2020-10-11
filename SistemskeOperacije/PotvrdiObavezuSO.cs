using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class PotvrdiObavezuSO : OpstaSO
    {
        public Obaveza PotvrdjenaObaveza { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {

                int rows = broker.UpdateObject(objekat);
                if (rows != 1)
                {
                    throw new Exception();
                }
                PotvrdjenaObaveza = (Obaveza)objekat;
            }
            catch (Exception)
            {

                PotvrdjenaObaveza = null;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
        }
    }
}
