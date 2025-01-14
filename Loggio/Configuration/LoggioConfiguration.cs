using com.HellStormGames.Diagnostics.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics
{
    public class LoggioConfiguration
    {
        #region Declaration Fields
        readonly List<ISubscriber>? subscribers = [];
        bool createdLogger = false;

        public LoggioSubscriberConfiguration SubscribeTo { get; private set; }

        #endregion
        public LoggioConfiguration()
        {
            try
            {
                SubscribeTo = new LoggioSubscriberConfiguration(this, s => subscribers.Add(s));
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }

        public Logger CreateLogger()
        {
            if (createdLogger) throw new Exception("Only One Logger Can Exist.");

            createdLogger = true;

            ISubscriber? subscriber = null;
            if (subscribers?.Count > 0)
            {
                subscriber = new SafeAggregateSubscriber(subscribers);
            }
            var _disposeablesubscribers = subscribers?.Where(s => s is IDisposable).ToArray();

            void Dispose()
            {
                foreach (var listener in _disposeablesubscribers)
                {
                    (listener as IDisposable)?.Dispose();
                }
            }

            return new Logger(subscriber, Dispose);
        }
    }
}
