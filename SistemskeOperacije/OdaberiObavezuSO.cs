using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class OdaberiObavezuSO : OpstaSO
    {
        public Obaveza OdabranaObaveza { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            string criteria = $"where obaveza.{objekat.SearchId} = {objekat.ColumnId}";

            try
            {
                OdabranaObaveza = (Obaveza)broker.SearchSlozeniObjekat(criteria, objekat);
            }
            catch (Exception)
            {

                OdabranaObaveza = null;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
        }
    }
}
