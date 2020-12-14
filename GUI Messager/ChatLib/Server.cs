using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Server : NetworkingBase
    {
        TcpListener server;

        public override void Disconnect()
        {
            if (server.Server.IsBound || server.Server.Connected)
            {
                server.Server.Close();
                server.Stop();
                stream.Close();
            }

            else
            {
                Console.WriteLine("Object reference not set to an instance of an object.");
            }
        }

        //
        // Summary:
        //     Starts the server and assigns the stream for later use.
        //
        public void StartServer()
        {
            server = new TcpListener(IPAddress.Parse(IPADDRESS), PORT);
            server.Start();
            TcpClient serverClient = server.AcceptTcpClient();
            stream = serverClient.GetStream();
        }
    }
}
