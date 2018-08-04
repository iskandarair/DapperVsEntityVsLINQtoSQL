using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Log
{
    public static class TimeCountLogger
    {
        private static NLog.Logger _logger = null;

        public static void Initialize()
        {
            _logger = LogManager.GetLogger("TimeCount");
        }
        public static void Info(string message, string prefix)
        {
            var logEvent = new LogEventInfo(LogLevel.Info, _logger.Name, message);
            var filePrefix = string.Empty;
            logEvent.Properties.Add("Prefix", prefix);
            _logger.Log(logEvent);
        }
    }
}
