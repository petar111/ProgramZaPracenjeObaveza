using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolerKI
{
    public class KontrolerKIStavkaObaveze : OpstiKontrolerKI
    {
        public override void IzvrsiKonverzijuObjekta()
        {
            StavkaObaveze stavka = (StavkaObaveze)ObjekatOdgovor;

            GrafickiObjektiOdgovor = new List<object>()
            {
                stavka.Naziv,
                stavka.Napomena
            };
        }

        protected override void NapraviObjekteOdForme()
        {
            DomenskiObjektiZahtev =  new StavkaObaveze()
            {
                RedniBroj = SesijaKlijent.Sesija.Instance.StavkeObaveze.Count + 1,
                Naziv = (string)GrafickiObjekti[0],
                Napomena = (string)GrafickiObjekti[1]
            };

            ((StavkaObaveze)DomenskiObjektiZahtev).IdObaveze = SesijaKlijent.Sesija.Instance.KreiranaObaveza.IdObaveze;
        }

        public void DodajStavku()
        {
            NapraviObjekteOdForme();
            StavkaObaveze stavka = (StavkaObaveze)DomenskiObjektiZahtev;
            SesijaKlijent.Sesija.Instance.StavkeObaveze.Add(stavka);
        }
        
    }
}
