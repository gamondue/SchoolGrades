using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamon
{
    internal class ThreadServerReceiver
    {
        private volatile bool finito = false;
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.

        // comunicazione con il programma principale attraverso la variabile comando
        public volatile string Comando;
        public volatile bool NuovoComando;

        // proprietà di sola lettura 
        public string Ip { get; }
        public int TcpPort { get; }
        public string Password { get; }

        // costruttore con parametri obbligatori 
        public ThreadServerReceiver(string IpOrDns, int TcpPort, string Password)
        {
            this.Ip = IpOrDns; 
            this.TcpPort = TcpPort;
            this.Password = Password;
        }
        // This method will be called when the thread is started.
        public void Inizia()
        {
            // istanzia ed esegue un thread per la ricezione
            Console.WriteLine("Attesa del collegamento del client");
            ServerTcp.Listen(Ip, TcpPort, Password);

            Console.WriteLine("Ricevitore acceso");
            while (!finito)
            {
                Comando = ServerTcp.Receive();
                if (!ServerTcp.isError) RequestStop(); 
                NuovoComando = true; 
            }
            Console.WriteLine("Terminazione corretta del ricevitore.");
        }
        public void RequestStop()
        {
            finito = true;
        }
    }
}
