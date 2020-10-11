using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Odgovor
    {
        public object Objekat { get; set; }
        public Status Status { get; set; }

        public string Poruka { get; set; }
    }

    public enum Status
    {
        OK,
        ERROR,
        SERVERDOWN
    }
}
