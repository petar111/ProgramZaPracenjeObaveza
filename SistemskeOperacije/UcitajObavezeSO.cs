using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class UcitajObavezeSO : OpstaSO
    {
        public List<Obaveza> UcitaneObaveze { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            try
            {
                UcitaneObaveze = broker.SearchJoin("", objekat).ConvertAll(o => (Obaveza)o);
            }
            catch (Exception)
            {

                UcitaneObaveze = null;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
        }
    }
}
