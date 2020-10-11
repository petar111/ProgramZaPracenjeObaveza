using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        private Socket serverSoket;
        public List<ObradaKlijenta> Klijenti { get; set; }

        internal void Pokrerni()
        {
            try
            {
                string ip = ConfigurationManager.AppSettings.Get("IP");
                int port = int.Parse(ConfigurationManager.AppSettings.Get("Port"));

                serverSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSoket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                serverSoket.Listen(20);
                Klijenti = new List<ObradaKlijenta>();

                Thread nitZaOsluskivanjeKorisnika = new Thread(OsluskujKlijente);
                nitZaOsluskivanjeKorisnika.Start();
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OsluskujKlijente()
        {
            bool kraj = false;

            while (!kraj)
            {
                try
                {
                    ObradaKlijenta obradaKlijenta = new ObradaKlijenta();
                    obradaKlijenta.Soket = serverSoket.Accept();
                    obradaKlijenta.Tok = new NetworkStream(obradaKlijenta.Soket);

                    Klijenti.Add(obradaKlijenta);

                    Thread nitZaKlijenta = new Thread(obradaKlijenta.PocniObradu);
                    nitZaKlijenta.Start();
                }
                catch (Exception)
                {
             
                    kraj = true;
                }
            }
           
        }

        internal void ProveriAktivnostKlijenata()
        {
            for (int i = 0; i < Klijenti.Count; i++)
            {
                if (!Klijenti[i].Soket.Connected)
                {
                    Klijenti.RemoveAt(i);
                }
            }
        }

        internal void Zaustavi()
        {
            foreach (var item in Klijenti)
            {
                item.Soket.Close();
            }
            Klijenti.Clear();
            Klijenti = null;
            serverSoket.Close();
        }
    }
}
