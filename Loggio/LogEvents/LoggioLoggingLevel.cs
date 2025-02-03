using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{
    public static class LoggioLoggingLevel
    {
        public const LoggioEventType Minimal = LoggioEventType.VERBOSE;
        public const LoggioEventType Normal = LoggioEventType.INFO;
        public const LoggioEventType Maximum = LoggioEventType.FATAL;
    }
}
