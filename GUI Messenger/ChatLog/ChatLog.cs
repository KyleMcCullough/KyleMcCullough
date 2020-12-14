using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace ChatLog
{
    public class ChatLog
    {

        public string filePath = "chatLog.txt";
        private ILoggingService logging;

        public ChatLog(ILoggingService logging)
        {
            this.logging = logging;
        }

        //
        // Summary:
        //     Calls the dedicated logging method with the formatted string
        //     
        public void WriteToFile(object sender, ChatLib.Events.StreamMessageArgs e)
        {
            if (e.LocalMessage)
            {
                logging.Log(DateTime.Now + " - Client: " + e.Message);
            }
            else
            {
                logging.Log(DateTime.Now + " - Server: " + e.Message);
            }
        }

        //
        // Summary:
        //     Logs the beginning of the connection.
        //     
        public void BeginConnection()
        {
            logging.Log("\n\n" + DateTime.Now + " - Client connected to server at " + ChatLib.NetworkingBase.IPADDRESS + " port " + ChatLib.NetworkingBase.PORT);
        }

        //
        // Summary:
        //     Logs the end of the connection.
        //    
        public void EndConnection()
        {
            logging.Log(DateTime.Now + " - Client has disconnected, session has ended.");
        }
    }
}
