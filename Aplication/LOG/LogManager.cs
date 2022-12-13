using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Aplication.LOG
{
    public class LogManager
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void initialize()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logconsole);
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;
        }
        public static void shutdown()
        {
            NLog.LogManager.Shutdown();
        }

        public static NLog.Logger GetLogger()
        {
            return logger; 
        }



    }
}