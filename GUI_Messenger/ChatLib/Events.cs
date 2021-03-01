using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Events
    {

        public delegate void streamReceieveMessageHandler(object sender, StreamMessageArgs e);
        public delegate void streamSendMessageHandler(object sender, StreamMessageArgs e);

        public class StreamMessageArgs : EventArgs
        {
            public string Message { get; set; }
            public bool LocalMessage { get; set; }
        }
    }
}
