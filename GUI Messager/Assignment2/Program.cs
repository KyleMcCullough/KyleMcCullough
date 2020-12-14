using ChatLog;
using System;
using System.Windows.Forms;
using Unity;
using Ninject;
using Ninject.Modules;

namespace Assignment2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Unity dependency injector

            //UnityContainer container = new UnityContainer();
            //container.RegisterType<ILoggingService, TextFileLogger>();
            //container.RegisterType<ILoggingService, TextConsoleLogger>();
            //Application.Run(container.Resolve<GameScreen>());

            // Ninject dependency injector

            IKernel kernal = new StandardKernel();
            //kernal.Bind<ILoggingService>().To<TextFileLogger>();
            kernal.Bind<ILoggingService>().To<TextConsoleLogger>();
            Application.Run(kernal.Get<GameScreen>());
        }
    }
}
