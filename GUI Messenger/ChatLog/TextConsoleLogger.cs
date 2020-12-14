using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ChatLog
{
    public class TextConsoleLogger : ILoggingService
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        //
        // Summary:
        //     Using the NLog framework, it logs the sent message to the console.
        //             
        public void Log(string message)
        {
            logger.Info(message);
        }
    }
}
