using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{
    public static class DebugOutputConfiguration
    {
        public static LoggioConfiguration DebugOutput(this LoggioSubscriberConfiguration config, LoggioEventType minimalEvent = LoggioLoggingLevel.Minimal, LoggioEventTypeSwitch? eventSwitch = null)
        {
            return CreateDebugOutput(config.Subscribe, minimalEvent, eventSwitch);
        }
        static LoggioConfiguration CreateDebugOutput(this Func<ISubscriber,LoggioEventType, LoggioEventTypeSwitch?, LoggioConfiguration>? addListener, LoggioEventType minimalEventType, LoggioEventTypeSwitch? eventSwitch)
        {
            if(addListener == null) throw new ArgumentNullException(nameof(addListener));

            ISubscriber subscriber = new DebugOutputSubscriber();

            return addListener(subscriber, minimalEventType, eventSwitch);
        }
    }
}
