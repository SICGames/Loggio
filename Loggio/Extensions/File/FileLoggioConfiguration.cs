using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{

    public static class FileLoggioConfiguration
    {
        public static LoggioConfiguration File(this LoggioSubscriberConfiguration config,
            string file, 
            LoggioEventType minimalEvent = LoggioLoggingLevel.Minimal, 
            LoggioEventTypeSwitch? eventSwitch = null)
        {
            if(config == null) throw new ArgumentNullException(nameof(config)); 
            if(file == null) throw new ArgumentNullException(nameof(file));
            return CreateFileSubscriber(config.Subscribe, file, minimalEvent, eventSwitch);
        }
        public static LoggioConfiguration CreateFileSubscriber(this Func<ISubscriber, LoggioEventType, LoggioEventTypeSwitch?, LoggioConfiguration>? addFileSubscriber,
            string file,
            LoggioEventType minimalEvent, 
            LoggioEventTypeSwitch? switchEvent)
        {
            if(addFileSubscriber == null) throw new ArgumentNullException(nameof(addFileSubscriber));

            ISubscriber subscriber = new FileSubscriber(file);

            return addFileSubscriber(subscriber, minimalEvent, switchEvent);
        }
    }
}