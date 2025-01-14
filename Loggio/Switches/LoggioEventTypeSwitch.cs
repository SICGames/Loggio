using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{
    public class LoggioEventTypeSwitch
    {
        readonly LoggioEventType eventtype;
        readonly object typeswitchLock = new();
        public LoggioEventTypeSwitch(LoggioEventType initialType = LoggioLoggingLevel.Minimal)
        {
            this.eventtype = initialType;
        }
        public event EventHandler<LoggioEventTypeChangedArgs> EventTypeChanged;
        protected void onLoggioEventTypeChanged(LoggioEventTypeChangedArgs args)
        {
            if (EventTypeChanged != null)
            {
                EventTypeChanged(this, args);
            }
        }
        public LoggioEventType MinimalEventType
        {
            get => eventtype;
            set
            {
                lock (typeswitchLock)
                {
                    var oldValue = eventtype;
                    if (oldValue != value)
                    {

                        onLoggioEventTypeChanged(new LoggioEventTypeChangedArgs(oldValue, value));
                    }
                }
            }
        }
    }
}
