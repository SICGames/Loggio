using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.HellStormGames.Diagnostics.Logging;

namespace com.HellStormGames.Diagnostics
{
    /// <summary>
    /// Usages:<br/>
    /// //-- ALl events goes to debug output window while debugging.
    /// Loggio.Logger = new LoggioConfiguration().SubscribeTo.DebugOutput().CreateLogger();<br/>
    /// Loggio.Info("I am alive!");<br/>
    /// var eggs = new List<float>();<br/>
    /// try { <br/>
    ///     eggs[13] = 1.0f; <br/>
    /// } <br/>
    /// catch(Exception ex) { <br/>
    ///     Loggio.Error(ex, "Bad Easter Bunny","Something happened and it's sad."); <br/>
    /// } <br/>
    /// </summary>
    
    public class Loggio 
    {
        static ILogger? _logger = null;
        public static ILogger? Logger
        {
            get => _logger;
            set => _logger = value; 
        }

        public static void Shutdown()
        {
            (_logger as  IDisposable)?.Dispose();    
        }

        public static void Write(LoggioEventType eventType, string message)
        {
            _logger?.Write(eventType, message);
        }
        public static void Write(LoggioEventType eventType, string tag, string message)
        {
            _logger?.Write(eventType, tag, message);
        }
        public static void Write(LoggioEventType eventType, string tag, string message, Exception exception)
        {
            _logger?.Write(eventType, exception, tag, message);
        }

        public static void Info(string message)
        {
            _logger?.Info(message);  
        }
        public static void Info(string tag, string message)
        {
            _logger?.Info(tag, message);
        }
        public static void Info(Exception exception,string tag, string message)
        {
            _logger?.Info(exception, tag, message);
        }

        public static void Warn(string message)
        {
            _logger?.Warn(message);
        }
        public static void Warn(string tag, string message)
        {
            _logger?.Warn(tag, message);
        }
        public static void Warn(Exception exception,  string tag, string message)
        {
            _logger?.Warn(exception, tag, message);  
        }

        public static void Error(string message)
        {
            _logger?.Error(message);    
        }
        public static void Error(string tag, string message)
        {
            _logger?.Error(tag, message);
        }
        public static void Error(Exception exception, string tag, string message)
        {
            _logger?.Error(exception, tag, message);
        }

        public static void Fatal(string message)
        {
            _logger?.Fatal(message);
        }
        public static void Fatal(string tag, string message)
        {
            _logger?.Fatal(tag, message);
        }
        public static void Fatal(Exception exception, string tag, string message)
        {
            _logger?.Fatal(exception, tag, message);
        }
    }
}