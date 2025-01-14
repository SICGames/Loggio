using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{
    public class LoggioEventTypeChangedArgs : EventArgs
    {
        public LoggioEventType OldEventType {get; set;}
        public LoggioEventType NewEventType {get;set;}
        public LoggioEventTypeChangedArgs(LoggioEventType oldValue, LoggioEventType newValue)
        {
            OldEventType = oldValue;
            NewEventType = newValue;
        }
    }
}
