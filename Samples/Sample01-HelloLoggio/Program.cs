using com.HellStormGames.Diagnostics;
using com.HellStormGames.Diagnostics.Logging;

namespace Sample01_HelloLoggio
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Loggio.Logger = new LoggioConfiguration().SubscribeTo.DebugOutput().
                SubscribeTo.File("log.txt").CreateLogger();
            Loggio.Info("Starting Application....");
            Application.Run(new Form1());
        }
    }
}