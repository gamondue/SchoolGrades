using System;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Net;

public class ClientTcp

{
    static TcpClient tcpclnt;
    static Stream stream;
    static string password;

    //internal static void Connect(string IpOrDns, int TcpPort, string Password)
    internal static void Connect(string IpOrDns, int TcpPort)
    {
        try
        {
            //password = Password; 
            tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");
            IPAddress ipAd = IPAddress.Parse(IpOrDns);

            tcpclnt.Connect(ipAd, TcpPort);

            Console.WriteLine("Connected");

            stream = tcpclnt.GetStream();
        }

        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
            throw; 
        }
    }

    internal static void Write(string Stringa)
    {
        try { 
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(Stringa);
            Console.WriteLine("Transmitting.....");

            stream.Write(ba, 0, ba.Length);
        }
        catch
        {
            throw;
        }
    }
    internal static string Read(string Stringa)
    {
        try { 
            byte[] buffer = new byte[100];
            int k = stream.Read(buffer, 0, 100);

            for (int i = 0; i < k; i++)
                Stringa += Convert.ToChar(buffer[i]);
            return Stringa;
        }
        catch
        {
            throw;
        }
    }
    internal static void Close()
    {
        tcpclnt.Close();
    }
}