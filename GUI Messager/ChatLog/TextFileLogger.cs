using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLog
{
    public class TextFileLogger : ILoggingService
    {

        //
        // Summary:
        //     Logs the given message into the chatLog.txt file
        //     
        public void Log(string message)
        {
            
            //Appends the current text to the 
            using (StreamWriter write = File.AppendText("chatLog.txt"))
            {
                write.WriteLine(message);
            }
        }
    }
}
