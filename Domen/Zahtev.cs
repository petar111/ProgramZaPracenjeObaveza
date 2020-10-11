using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Zahtev
    {
        public Operacija Operacija { get; set; }
        public object Objekat { get; set; }
    }

    public enum Operacija
    {
        PrijaviSe,
        KreirajNoviNalog,
        ZapamtiNalog,
        ObrisiNalog,
        VratiSveKorisnike,
        VratiSveTipoveObaveza,
        NapraviNovuObavezu,
        ZapamtiObavezu,
        VratiSveObaveze,
        PronadjiObaveze,
        OdaberiObavezu,
        PotvrdiObavezu,
        PonistiObavezu,
        PotvrdiIzvrsenjeObaveze
    }
}
