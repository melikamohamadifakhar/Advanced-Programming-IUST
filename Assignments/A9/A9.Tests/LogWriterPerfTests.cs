using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Logger.Tests
{
    [TestClass()]
    public class LogWriterPerfTests
    {
        [TestMethod()]
        public void LockedLogWriterPerfTest()
        {
            var time = PerfTest<LockedLogWriter>(threadCount: 100, linePerThread:1000);
            System.Console.WriteLine(time);
        }

        [TestMethod()]
        public void ConcurrentLogWriterPerfTest()
        {
            var time = PerfTest<ConcurrentLogWriter>(threadCount: 100, linePerThread: 1000);
            System.Console.WriteLine(time);
        }

        [TestMethod()]
        public void  LockedQueueLogWriterPerfTest()
        {
            var time = PerfTest<LockedQueueLogWriter>(threadCount: 25, linePerThread: 1000);
            System.Console.WriteLine(time);
        }

        // [TestMethod()]
        // public void NoLockPerfTest()
        // {
        //     var time = PerfTest<NoLockLogWriter>(threadCount: 25, linePerThread: 1000);
        // }

        // از آنجا که از کلاس 
        // NoLockLogWriter
        // استفاده کردیم و از داده‌ها محافظت نشده که همزمان بیش از
        // یک ترد به آنها دسترسی نداشته باشند و همچنین تعداد تردها خیلی زیاد است و هرکدام میخواهند
        // تعداد زیادی خط را در فایل بنویسند تداخل پیدا می‌کنند
        // با ارور
        // Arithmetic operation resulted in an overflow
        // مواجه می‌شود.
        private string PerfTest<_LogWriter>(int threadCount, int linePerThread)
            where _LogWriter: GuardedLogWriter, new()
        {
            string logDir = Path.GetTempFileName();
            File.Delete(logDir);
            string logPrefix = "sauleh_all";
            string time = string.Empty;
            using (FileLogger<_LogWriter> logger = new FileLogger<_LogWriter>(
                    XmlLogFormatter.Instance,
                    new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                    new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
                    LogLevels.All,
                    LogSources.All,
                    false))
            {
                var threads = Enumerable.Range(0, threadCount)
                                        .Select(n => new Thread(
                                            new ThreadStart(() => LogRandomMessages(linePerThread, logger))))
                                        .ToList();

                Stopwatch sw = Stopwatch.StartNew();
                threads.ForEach(t => t.Start());
                threads.ForEach(t => t.Join());
                sw.Stop();

                time = sw.Elapsed.TotalSeconds.ToString();
                
            }

            int actualLogLines = CountLogLines(logDir, pattern: $"{logPrefix}*.{XmlLogFormatter.Instance.FileExtention}");

            Assert.AreEqual(linePerThread * threadCount + 2, actualLogLines); // plus 2 for header and footer

            return time;
        }

        private int CountLogLines(string logDir, string pattern)
        {
            return Directory.GetFiles(logDir, pattern).Sum(f => File.ReadAllLines(f).Length);
        }

        private void LogRandomMessages(int count, ILogger logger)
        {
            for (int i=0; i<count; i++)
            {
                LogEntry logEntry = new LogEntry(LogSource.Client, LogLevel.Debug,
                    $"student {i} created", ("FirstName", $"Pegah_{i}"), ("LastName", $"Ayati_{i}"));
                logger.Log(logEntry);
            }
        }
    }
}
//         ConcurrentLogWriterPerfTest     LockedLogWriterPerfTesr      LockedQueueLogWriterPerfTest
//***************************************************************************************************
//1             0.1925511                        0.2026967                      0.2045907
//2             0.2050208                        0.2305965                      0.2230788
//5             0.3437889                        0.3807564                      0.4215408
//10            0.6171052                        0.6406764                      0.6318841
//20            1.2665425                        1.223571                       1.399108
//50            3.9501896                        3.2406218                      2.9581911
//100           9.6705974                        6.5018148                      6.6943728

// در حالت کلی در تعداد ترد کم 
// LockedLogWriter
// کارآمد باشد چون شانس تداخل کمتر است و تاثیر زیادی روی سرعت 
// ندارد و تردها زیاد معطل لاک نمی‌شوند.
// اما وقتی تعدادتردها از حدی بیشتر شود
// ConcurrentLogWriter 
// بهتر است چون تردها زیاد معطل یکدیگر نمی شوند و به ادامه ی کارها می‌پردازند
// که در جدول فوق عکس این موضوع مشاهده می‌شود که میتوند به دلیل
// linePerThread
// باشد
