using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class VratiTipoveObavezaSO : OpstaSO
    {
        public List<TipObaveze> TipoviObaveza { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {
                TipObaveze tipObaveze = (TipObaveze)objekat;
                TipoviObaveza = broker.VratiSve(tipObaveze).ConvertAll(o => (TipObaveze)o);
            }
            catch (Exception)
            {

                TipoviObaveza = null;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
        }
    }
}
