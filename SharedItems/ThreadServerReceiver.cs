using System;

namespace gamon
{
    internal class ThreadServerReceiver
    {
        private volatile bool finished = false;
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.

        // communication with the main program through the command variable
        public volatile string command;
        public volatile bool newCommand;

        // read-only properties
        public string Ip { get; }
        public int TcpPort { get; }
        public string Password { get; }

        // constructor with mandatory parameters
        public ThreadServerReceiver(string IpOrDns, int TcpPort, string Password)
        {
            this.Ip = IpOrDns;
            this.TcpPort = TcpPort;
            this.Password = Password;
        }
        // This method will be called when the thread is started.
        public void StartColorTimerThread()
        {
            // instantiate and run a thread for reception
            Console.WriteLine("Attesa del collegamento del client");
            ServerTcp.Listen(Ip, TcpPort, Password);

            Console.WriteLine("Ricevitore acceso");
            while (!finished)
            {
                command = ServerTcp.Receive();
                if (!ServerTcp.isError) RequestStop();
                newCommand = true;
            }
            Console.WriteLine("Receiver stopped correctly.");
        }
        public void RequestStop()
        {
            finished = true;
        }
    }
}
