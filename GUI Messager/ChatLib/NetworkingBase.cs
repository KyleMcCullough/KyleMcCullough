using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters;
using System.Net.Configuration;

namespace ChatLib
{
    public abstract class NetworkingBase
    {
        public static string IPADDRESS = "127.0.0.1";
        public static Int32 PORT = 5555;
        public NetworkStream stream { get; set; }

        public abstract void Disconnect();

        //
        // Summary:
        //     Gets the data from the stream to decode and return as a 
        //     regular string.
        //     
        public string GetMessage()
        {
            
            Byte[] bytes = new Byte[256];

            // Translate data bytes to a ASCII string.
            int index = stream.Read(bytes, 0, bytes.Length);
            string data = Encoding.ASCII.GetString(bytes, 0, index);

            // return the decoded string.
            return data;
        }

        //
        // Summary:
        //     Gets a string in order to encode the string and enter it onto the
        //     stream for other users to pick up.
        //
        // Parameters:
        //   encodingString:
        //     The regular string that will be encoded.
        //

        public void SendMessage(String encodingString)
        {

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(encodingString); 

            stream.Write(msg, 0, msg.Length);
        }
    }
}
