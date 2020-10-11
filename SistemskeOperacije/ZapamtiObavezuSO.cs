using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class ZapamtiObavezuSO : OpstaSO
    {
        public Obaveza ZapamcenaObaveza { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {
                
                int rows = broker.UpdateSlozeniObjekat(objekat);
                if(rows != 1)
                {
                    throw new Exception();
                }
                ZapamcenaObaveza = (Obaveza)objekat;
            }
            catch (Exception)
            {

                ZapamcenaObaveza = null;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
        }
    }
}
