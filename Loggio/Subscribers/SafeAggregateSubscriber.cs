using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{
    public class SafeAggregateSubscriber : ISubscriber
    {
        readonly ISubscriber[] _subscribers;

        public SafeAggregateSubscriber(IEnumerable<ISubscriber> subscriber) 
        { 
            _subscribers = subscriber.ToArray();
        }

        public void Invoke(LoggioEvent loggioEvent)
        {
            foreach(var subscriber in _subscribers)
            {
                subscriber.Invoke(loggioEvent);
            }
        }
    }
}
