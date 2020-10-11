using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class KreirajObavezuSO : OpstaSO
    {
        public Obaveza KreiranaObaveza { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Obaveza obaveza = (Obaveza)objekat;

            obaveza.TipObaveze = new TipObaveze()
            {
                IdTipaObaveze = broker.SearchMaxIdForObject(new TipObaveze())
            };

            try
            {
                int id = (int)broker.Insert(obaveza);
                KreiranaObaveza = obaveza;
                KreiranaObaveza.IdObaveze = id;
            }
            catch (Exception)
            {

                KreiranaObaveza = null;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            //throw new NotImplementedException();
        }
    }
}
