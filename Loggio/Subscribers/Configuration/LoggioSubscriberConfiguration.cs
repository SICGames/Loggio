using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{
    public class LoggioSubscriberConfiguration
    {
        readonly LoggioConfiguration _loggioConfiguration;
        readonly Action<ISubscriber> _subscriber;
        public LoggioSubscriberConfiguration(LoggioConfiguration loggioConfiguration, Action<ISubscriber> loggioListener)
        {
            _loggioConfiguration = loggioConfiguration;
            _subscriber = loggioListener;
        }

        public LoggioConfiguration Subscribe(ISubscriber listener)
        {
            return Subscribe(listener);
        }
        public LoggioConfiguration Subscribe(ISubscriber subscriber, LoggioEventType minimalEventType = LoggioLoggingLevel.Minimal)
        {
            return Subscribe(subscriber, minimalEventType);
        }
        public LoggioConfiguration Subscribe(ISubscriber eventSubscriber, LoggioEventType minimalEventType, LoggioEventTypeSwitch? eventswitch = null)
        {
            var subscriber = eventSubscriber;

            if(eventswitch != null)
            {
                subscriber = new GatedSubscriber(subscriber, eventswitch);
            }
            else if(minimalEventType > LoggioLoggingLevel.Minimal)
            {
                subscriber = new GatedSubscriber(subscriber, new LoggioEventTypeSwitch(minimalEventType));
            }

            _subscriber(subscriber);
            return _loggioConfiguration;
        }
    }
}
