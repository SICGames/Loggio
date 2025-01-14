using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{
    public class GatedSubscriber : ISubscriber, IDisposable
    {
        readonly ISubscriber subscriber;
        readonly LoggioEventTypeSwitch switchtype;

        public GatedSubscriber(ISubscriber sub, LoggioEventTypeSwitch switchType) 
        { 
            subscriber = sub;
            switchtype = switchType;
        }
        
        public void Invoke(LoggioEvent loggioEvent)
        {
            if(loggioEvent.LogType < switchtype.MinimalEventType)
            {
                return;
            }
            subscriber.Invoke(loggioEvent);
        }

        public void Dispose()
        {

        }
    }
}
