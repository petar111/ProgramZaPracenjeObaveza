using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private Server server;
        public Form1()
        {
            InitializeComponent();
            btnZaustavi.Enabled = false;
            txtStatus.Text = "Server NIJE pokrenut.";
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            try
            {
                server = new Server();
                server.Pokrerni();

                Thread nitAzurirajTabelu = new Thread(AzurirajTabelu);
                nitAzurirajTabelu.IsBackground = true;
                nitAzurirajTabelu.Start();
                

                btnZaustavi.Enabled = true;
                btnPokreni.Enabled = false;

                txtStatus.Text = "Server je pokrenut.";

            }
            catch (Exception)
            {
                MessageBox.Show("Greska pri otvatanju servera!!!");
            }
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            dgvKlijenti.DataSource = null;

            server.Zaustavi();

            btnZaustavi.Enabled = false;
            btnPokreni.Enabled = true;

            txtStatus.Text = "Server NIJE pokrenut.";
        }


        private void AzurirajTabelu()
        {

            bool kraj = false;

            while (!kraj)
            {
                if (server != null)
                {
                    try
                    {
                        server.ProveriAktivnostKlijenata();
                        this.Invoke(new Action(() => dgvKlijenti.DataSource = new List<ObradaKlijenta>(server.Klijenti)));
                        this.Invoke(new Action(() => dgvKlijenti.Columns[0].Width = 150));
                    }
                    catch (Exception)
                    {

                        kraj = true;
                        break;
                    }
                }
                Thread.Sleep(5000);
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
