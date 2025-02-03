using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.HellStormGames.Diagnostics.Logging
{
    public class FileSubscriber : ISubscriber, IDisposable
    {
        readonly StreamWriter StreamWriter;
        readonly string File;
        readonly object syncroot = new object();

        public FileSubscriber(string file)
        {
            if (String.IsNullOrEmpty(file)) throw new ArgumentNullException(nameof(file));

            var directory = Path.GetDirectoryName(file);

            if (!String.IsNullOrEmpty(directory))
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }

            Stream stream = System.IO.File.Open(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            stream.Seek(0, SeekOrigin.End); //-- go to end of file.
            StreamWriter = new StreamWriter(stream, Encoding.UTF8);
        }

        public void Dispose()
        {
            lock (syncroot)
            {
                StreamWriter.Close();
                StreamWriter.Dispose();
            }
        }

        public void Invoke(LoggioEvent loggioEvent)
        {
            if (loggioEvent == null) throw new ArgumentNullException(nameof(loggioEvent));

            //-- write to file.
            lock (syncroot)
            {
                string tag = String.IsNullOrEmpty(loggioEvent.Tag) ? "" : $"[{loggioEvent.Tag}]";
                string exceptionString = String.Empty;
                if (loggioEvent.Exception != null)
                {
                    var loggioEx = loggioEvent.Exception;
                    StackTrace stackTrace = new StackTrace(loggioEx, true);
                    StackFrame? frame = stackTrace.GetFrames().Where(f => f.GetFileName() != null).FirstOrDefault();

                    exceptionString = $"\n\t Exception Information: \n\t\t Type: {loggioEx.GetType()}\n\t\t Message: {loggioEx.Message}\n\t\t" +
                        $" Method Name: {frame?.GetMethod()?.Name}\n\t\t Line: {frame?.GetFileLineNumber()}.\n\t\t Source File: {frame?.GetFileName()}\n";
                }

                var str = $"[{loggioEvent.DateTimeOffset.ToString(@"yyyy-MM-dd HH:mm:ss")}] " +
                        $"[{loggioEvent.LogType.ToString()}] {tag} => {loggioEvent.Message}\n{exceptionString}";

                StreamWriter.Write(str, 0, str.Length);
            }
        }
    }
}
