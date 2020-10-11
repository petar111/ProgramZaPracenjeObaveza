using Domen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KomunikacijaSaServerom
{
    public class Komunikacija
    {

        private static Komunikacija instance = new Komunikacija();
        private Socket klijentskiSocket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();

        public void PosaljiZahtev(Zahtev z)
        {
            formatter.Serialize(stream, z);
        }

        public Odgovor ProcitajOdgovor()
        {
            try
            {
                return (Odgovor)formatter.Deserialize(stream);
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>>" + e.Message);
                return null;
            }
        }

        public void ZatvoriKonekciju()
        {
            klijentskiSocket.Close();
        }

        private Komunikacija()
        {
        }
        public static Komunikacija Instance
        {
            get
            {
                return instance;
            }
        }

        public bool PoveziSe()
        {
            try
            {
                if (klijentskiSocket == null || !klijentskiSocket.Connected)
                {
                    string IPServera = ConfigurationManager.AppSettings["IPServera"];
                    int portServera = int.Parse(ConfigurationManager.AppSettings["PortServera"]);

                    klijentskiSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    klijentskiSocket.Connect(IPServera, portServera);
                    stream = new NetworkStream(klijentskiSocket);
                }
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }
    }
}
