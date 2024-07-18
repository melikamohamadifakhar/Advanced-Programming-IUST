using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {
            public static Dictionary<string, int> Characters = new Dictionary<string, int>();
            public static void CalculateCharNums(LogEntry logEntry){
                string LogLevel = logEntry.Level.ToString();
                int MessageLen = logEntry.Message.Length;
                if (Characters.Keys.Contains(LogLevel))
                    Characters[LogLevel] += MessageLen;
                else
                    Characters.Add(LogLevel, MessageLen);
                System.Console.WriteLine($"LogLevel:{logEntry.Level}\nMessage Length:{Characters[LogLevel]}");
            
            }
        static void Main(string[] args)
        {

            ConsoleLogger clogger = new ConsoleLogger();

            FileLogger<LockedLogWriter> errorLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_error", CsvLogFormatter.Instance.FileExtention),
                LogLevels.ErrorOnly,
                LogSources.All,
                true);

            FileLogger<LockedLogWriter> allLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_all", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);

            FileLogger<LockedLogWriter> uiLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_ui", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.Create(LogSource.UI),
                true);

            FileLogger<LockedLogWriter> allLogger_ToDo = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_allTodo", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);

            FileLogger<LockedLogWriter> allLogger_ToDo1 = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_allTodo1", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.Create(LogSource.Client),
                true);
            
            Logger.Instance.OnLog += CalculateCharNums;
            Logger.Loggers.Add(allLogger_ToDo);
            Logger.Loggers.Add(allLogger_ToDo1);
            Logger.Loggers.Add(errorLogger);
            Logger.Loggers.Add(allLogger);
            Logger.Loggers.Add(clogger);
            Logger.Loggers.Add(uiLogger);

            // Logger is set up and ready to use

            // درسته که همه این دستورات را پشت سر هم زدم
            // ولی شما فرض کنید که اینها در جاهای مختلف برنامه 
            // زده شده...
            Logger.Instance.Debug(LogSource.UI, "Login button clicked");
            Logger.Instance.Debug(LogSource.Client, "User logged in", ("Name", "Mr. Ali Hassan"));
            Logger.Instance.Debug(LogSource.UI, "Add phone number cliecked");
            Logger.Instance.Info(LogSource.Client, "User number added", ("Name", "Mr. Ali Hassan"), ("PhoneNumber", "+9821 2543331"));
            Logger.Instance.Debug(LogSource.UI, "Add national ID cliecked");
            Logger.Instance.Warn(LogSource.Client, "User national ID added", ("ID", "232-12-1212"));
            Logger.Instance.Debug(LogSource.UI, "Display error to user");
            Logger.Instance.Error(LogSource.Client, "Unable to add user", ("ID", "232-12-1212"));
        }
    }
}

