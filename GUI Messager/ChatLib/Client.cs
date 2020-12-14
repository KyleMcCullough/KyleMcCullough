using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Client : NetworkingBase
    {
        TcpClient client = new TcpClient();

        //
        // Summary:
        //     Closes both the stream and client after checking to make 
        //     sure they are open.
        //
        public override void Disconnect()
        {
            if (client.Connected || client != null )
            {
                client.Close();
                stream.Close();
            }
        }



        //
        // Summary:
        //     Connects to the TcpServer and stream if avalible. If there 
        //     is no server running, it will output an error and exit the
        //     program gracefully.
        //
        public void StartTcpClient()
        {
            try
            { 
                client.Connect(IPAddress.Parse(IPADDRESS), PORT);
                stream = client.GetStream();
            }

            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
