using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{

    /// <summary>
    /// MINIMAL outputs message, log type and date<br/>
    /// NORMAL outputs message, log type, date, and origin class.<br/>
    /// FULL outputs message, log type, date, origin class, function name and line number.
    /// </summary>
    public static class LoggioLoggingLevel
    {
        public const LoggioEventType Minimal = LoggioEventType.DEBUG;
        public const LoggioEventType Normal = LoggioEventType.INFO;
        public const LoggioEventType Maximum = LoggioEventType.FATAL;
    }
}
