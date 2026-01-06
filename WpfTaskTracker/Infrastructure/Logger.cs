using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTaskTracker.Infrastructure
{
    public static class Logger
    {
        private static readonly string LogFile = "app.log";

        public static void Info(string message)
        {
            File.AppendAllText(LogFile, $"INFO: {message}{Environment.NewLine}");
        }

        public static void Error(string message)
        {
            File.AppendAllText(LogFile, $"ERROR: {message}{Environment.NewLine}");
        }
    }
}
