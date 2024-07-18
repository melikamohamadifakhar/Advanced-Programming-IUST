using System.Collections.Generic;

namespace Logger
{
    public static class FileLoggerFactory{
        public static FileLogger<LockedLogWriter> FileLogger1(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, ConsoleLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<LockedLogWriter> FileLogger2(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, CsvLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<LockedLogWriter> FileLogger3(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, XmlLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
        public static FileLogger<LockedLogWriter> FileLogger4(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, ConsoleLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
        public static FileLogger<LockedLogWriter> FileLogger5(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, CsvLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);

        public static FileLogger<LockedLogWriter> FileLogger6(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, XmlLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<LockedLogWriter> FileLogger7(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                ConsoleLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, ConsoleLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<LockedLogWriter> FileLogger8(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, CsvLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<LockedLogWriter> FileLogger9(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                XmlLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, XmlLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
        public static FileLogger<LockedLogWriter> FileLogger10(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                ConsoleLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, ConsoleLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
        public static FileLogger<LockedLogWriter> FileLogger11(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, CsvLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);

        public static FileLogger<LockedLogWriter> FileLogger12(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<LockedLogWriter>(
                XmlLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, XmlLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
        public static FileLogger<ConcurrentLogWriter> FileLogger13(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, ConsoleLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<ConcurrentLogWriter> FileLogger14(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, CsvLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<ConcurrentLogWriter> FileLogger15(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, XmlLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
        public static FileLogger<ConcurrentLogWriter> FileLogger16(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, ConsoleLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
        public static FileLogger<ConcurrentLogWriter> FileLogger17(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, CsvLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);

        public static FileLogger<ConcurrentLogWriter> FileLogger18(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, XmlLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<ConcurrentLogWriter> FileLogger19(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                ConsoleLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, ConsoleLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<ConcurrentLogWriter> FileLogger20(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                CsvLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, CsvLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
    
        public static FileLogger<ConcurrentLogWriter> FileLogger21(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                XmlLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new IncrementalLogFileName($@"{LogDir}", LogPrefix, XmlLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
        public static FileLogger<ConcurrentLogWriter> FileLogger22(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                ConsoleLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, ConsoleLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
        public static FileLogger<ConcurrentLogWriter> FileLogger23(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                CsvLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, CsvLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);

        public static FileLogger<ConcurrentLogWriter> FileLogger24(string LogDir, string LogPrefix, HashSet<LogLevel> loglevels,
        HashSet<LogSource> logSources, bool append) => new FileLogger<ConcurrentLogWriter>(
                XmlLogFormatter.Instance,
                NullPrivacyScrubber.Instance,
                new TimeBasedLogFileName($@"{LogDir}", LogPrefix, XmlLogFormatter.Instance.FileExtention),
                loglevels,
                logSources,
                append);
}
}
