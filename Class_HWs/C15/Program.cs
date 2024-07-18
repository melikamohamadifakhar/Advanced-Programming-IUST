using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace C15
{
    class ThreadParam
    {
        public int output;
    }
    class Program
    {
        static object sync_lock1 = new object();
        static void Test(object obj)
        {
            ThreadParam p = obj as ThreadParam;
            System.Console.WriteLine($"Begin Test - {Thread.CurrentThread.ManagedThreadId}");
            for(int i=0; i<p.output; i++)
            {
                Thread.Sleep(20);
                lock(sync_lock1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine($"Doing - {Thread.CurrentThread.ManagedThreadId}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            p.output = 234;
            System.Console.WriteLine($"End Test - {Thread.CurrentThread.ManagedThreadId}");
        }

        static bool JoinAll(Thread[] threads, int timeout)
        {
            foreach(var t in threads)
                if (! t.Join(timeout))
                    return false;
            return true;
        }

        static async Task<int> DownloadAsync()
        {
                Stopwatch sw = Stopwatch.StartNew();
                using HttpClient client = new HttpClient();
                string t1 = await client.GetStringAsync(@"http://www.iust.ac.ir");
                string t2 = await client.GetStringAsync(@"http://www.isna.ir");
                string t3 = await client.GetStringAsync(@"http://www.irna.ir");

                System.Console.WriteLine($"{t1.Substring(0, 50)} ... {t1.Length}");
                System.Console.WriteLine($"{t2.Substring(0, 50)} ... {t2.Length}");
                System.Console.WriteLine($"{t3.Substring(0, 50)} ... {t3.Length}");

                return t1.Length + t2.Length + t3.Length;
        }


        static void Main(string[] args)
        {
            Task<int> t = DownloadAsync();
            System.Console.WriteLine(t.Result);
            
        }


        static void Main123(string[] args)
        {
            Thread t;
            for (int i = 0; i< 10;  i++)
            {
                t = new Thread(Test);
                t.Start();
            }

            using (HttpClient client = new HttpClient())
            {
                Stopwatch sw = Stopwatch.StartNew();
                Task<string> t1 = client.GetStringAsync(@"http://www.iust.ac.ir");
                Task<string> t2 = client.GetStringAsync(@"http://www.isna.ir");
                Task<string> t3 = client.GetStringAsync(@"http://www.irna.ir");

                Task.WaitAll(t1, t2, t3);

                System.Console.WriteLine($"{t1.Result.Substring(0, 50)} ... {t1.Result.Length}");
                System.Console.WriteLine($"{t2.Result.Substring(0, 50)} ... {t2.Result.Length}");
                System.Console.WriteLine($"{t3.Result.Substring(0, 50)} ... {t3.Result.Length}");

                System.Console.WriteLine(sw.Elapsed.ToString());
            }
        }

        static void Main11(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                Stopwatch sw = Stopwatch.StartNew();
                string t1 = client.GetStringAsync(@"http://www.iust.ac.ir").Result;
                string t2 = client.GetStringAsync(@"http://www.isna.ir").Result;
                string t3 = client.GetStringAsync(@"http://www.irna.ir").Result;

                System.Console.WriteLine($"{t1.Substring(0, 50)} ... {t1.Length}");
                System.Console.WriteLine($"{t2.Substring(0, 50)} ... {t2.Length}");
                System.Console.WriteLine($"{t3.Substring(0, 50)} ... {t3.Length}");

                System.Console.WriteLine(sw.Elapsed.ToString());
            }
        }


        static void Main3(string[] args)
        {
            int w=0;
            Thread t = new Thread(() => {
                for(int i=0; i<10; i++)
                {
                    System.Console.WriteLine("test");
                }
                w = 5;
            });

            System.Console.WriteLine(w);
            t.Start();
            t.Join();
        }

        static void Main2(string[] args)
        {
            ThreadParam p = new ThreadParam() {output=5};
            Thread t = new Thread(Test);
            t.Start(p);
            System.Console.WriteLine(p.output);
        }

        static void Main5(string[] args)
        {
            Thread[] threads = new Thread[10];
            for(int i=0;i <10; i++)
            {
                threads[i] = new Thread(Test);
                threads[i].Start();
            }

            while (JoinAll(threads, 10))
                lock(sync_lock1)
                {
                    System.Console.WriteLine($"Waiting  - {Thread.CurrentThread.ManagedThreadId}");
                }
        }
    }
}
