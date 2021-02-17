using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class ServerTcp
{
    static TcpListener listener; 
    static Socket socket; 
    static string password;

    public static bool isError = false;
    public static bool isConnected = false; 

    internal static void Listen(string IpOrDns, int TcpPort, string Password)
    {
        password = Password; 
        try
        {
            IPAddress ipAd = IPAddress.Parse(IpOrDns);
            /* Initializes the Listener */
            listener = new TcpListener(ipAd, TcpPort);

            /* Start Listening at the specified port */
            listener.Start();

            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is  :" + listener.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");

            socket = listener.AcceptSocket();
            Console.WriteLine("Connection accepted from " + socket.RemoteEndPoint);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
            throw e; 
        }
    }
    internal static string Receive()
    {
        try
        {
            byte[] buffer = new byte[100];
            int k = socket.Receive(buffer);
            Console.WriteLine("Received...");
            string str = ""; 
            for (int i = 0; i < k; i++)
                str += Convert.ToChar(buffer[i]);
            return str;
        }
        catch (Exception E)
        {
            if (E.HResult == -2147467259)
                return "Collegamento interrotto.\n" + E.Message;
            else
                return "";
        }
    }
    internal static void Send(string Message)
    {
        ASCIIEncoding asen = new ASCIIEncoding();
        socket.Send(asen.GetBytes("Stringa ricevuta"));
	}
    internal static void Close()
    {
        if(socket != null)
            socket.Close();
        if (listener != null)
            listener.Stop();
    }
}
