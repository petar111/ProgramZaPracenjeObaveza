using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class PonistiObavezuSO : OpstaSO
    {
        public Obaveza PonistenaObaveza { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {

                int rows = broker.UpdateObject(objekat);
                if (rows != 1)
                {
                    throw new Exception();
                }
                PonistenaObaveza = (Obaveza)objekat;
            }
            catch (Exception)
            {
                PonistenaObaveza = null;
                
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            
        }
    }
}
