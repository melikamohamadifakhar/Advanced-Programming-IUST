using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace C16
{
    class InOut<_Type>
    {
        public _Type In {get; set;}
        public _Type Out {get; set;}
    }

    class Program
    {
        static void Test(object obj)
        {
            int x = (int) obj;
            for(int i=0; i<x; i++)
            {
                System.Console.WriteLine($"Start {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
                System.Console.WriteLine($"End {Thread.CurrentThread.ManagedThreadId}");            
            }
        }



        static async Task<long> DoWorkAsync()
        {
            long l1 = await new Task<long>( () => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Boiling Water");
                return sw.ElapsedMilliseconds;
            });
            long l2 = await new Task<long>( () => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Add Beans");
                return sw.ElapsedMilliseconds ;
            });
            long l3 = await new Task<long>( () => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Add Meat");
                return sw.ElapsedMilliseconds;
            });
            return l1 + l2 + l3;

        }

        static void Main2(string[] args)
        {
            Task<long> lt = DoWorkAsync();
            lt.Wait();
            System.Console.WriteLine(lt.Result);
        }
        static void Mainadf(string[] args)
        {
            Task<long> s = new Task<long>( () => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Boiling Water");
                return sw.ElapsedMilliseconds;
            }).ContinueWith( (s1) => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Add Beans");
                return sw.ElapsedMilliseconds + s1.Result;
            }).ContinueWith( (s1) => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Add Meat");
                return sw.ElapsedMilliseconds + s1.Result;
            });
            s.Start();
            s.Wait();
            System.Console.WriteLine(s.Result);
        }

        static void Mainfd(string[] args)
        {
            Task t1 = Task.Delay(1000).ContinueWith((Task t) => System.Console.WriteLine("Eslamikhah Turn"));
            Task t2 = Task.Delay(500).ContinueWith((Task t) => System.Console.WriteLine("NaebZadeh Turn"));
            Task t3 = Task.Delay(100).ContinueWith((Task t) => System.Console.WriteLine("Rahmani Turn"));
            Task t4 = Task.Delay(400).ContinueWith((Task t) => System.Console.WriteLine("Vafaei Turn"));
            // for (int i = 1; i < 100; i++) why can not execute?
            // {
            //     i *=i;
            // }
            // t1.Wait();
            // Task.WaitAll(t1, t2, t3, t4);
            // Thread.CurrentThread.Join();
            // Thread.Sleep(2000); 
        }


        static void Mainv(string[] args)
        {
            System.Console.WriteLine("Test 1");
            Task t = Task.Delay(10000);
            Task mt = Task.Run(() => Thread.Sleep(10000));
            System.Console.WriteLine("Test 2");
            t.Wait();
            System.Console.WriteLine("Test Done");
            mt.Wait();

        }


        static void Mainjh(string[] args)
        {
            List<Task> tasks = new List<Task>();
            for(int i=0; i<5; i++)
            {
                Task t = new Task((object obj) => {
                    int n = (int) obj;
                    System.Console.WriteLine($"Start {n} {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(100);
                    System.Console.WriteLine($"End {n} {Thread.CurrentThread.ManagedThreadId}");
                }, i);
                t.Start();
                //Task.Delay(100).Wait(); // Thread.Sleep(100);                
                tasks.Add(t);
            }
            Thread.Sleep(100);
            System.Console.WriteLine("Done Creating Tasks.");
            Task.WaitAll(tasks.ToArray());
        }

        static void Main566(string[] args)
        {
            List<Task> tasks = new List<Task>();
            for(int i=0; i<10; i++)
            {
                Task t = Task.Run(() => {
                    System.Console.WriteLine($"Start {i} {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(10000);
                    System.Console.WriteLine($"End {i} {Thread.CurrentThread.ManagedThreadId}");
                });
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
            // Console.WriteLine("after wait all");
        }
        static long Test2(object obj)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int x = (int) obj;
            for(int i=0; i<x; i++)
            {
                System.Console.WriteLine($"Start {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
                System.Console.WriteLine($"End {Thread.CurrentThread.ManagedThreadId}");            
            }
            return sw.ElapsedMilliseconds;
        }
        static void Main798(string[] args)
        {
            Task<long> t = new Task<long>(Test2, 6);
            t.Start();
            t.Wait(); //bud o nabudesh inja farghi nemikone chon bekhatere inke khate 155 ro ejra kone(result ro begire) behar hal majbure task ro ta tah bere
            //vlai age 155 comment beshe fargh mikone wait bezarim ya na!
            System.Console.WriteLine(t.Result);
            // Task t = new Task(Test, 5);
            // t.Start();
            // t.Wait();
        }

        static void MyThreadMethod<_Type>(object obj)
        {
            InOut<_Type> inout = obj as InOut<_Type>;
            Thread.Sleep(500);
            System.Console.WriteLine($"Working {Thread.CurrentThread.ManagedThreadId}");
            inout.Out = inout.In;
        }
        static void Main679(string[] args)
        {
            InOut<int> inout = new InOut<int>() {In = 5};
            Thread t = new Thread(MyThreadMethod<int>);
            // t.IsBackground = false;
            t.Start(inout);
            while (!t.Join(50))
            {
                System.Console.WriteLine($"Waiting {Thread.CurrentThread.ManagedThreadId}");
            }
            System.Console.WriteLine(inout.Out);
        }
        static void Main876532(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string>[] results = new Task<string>[] {
                    client.GetStringAsync("http://www.irna.ir"),
                    client.GetStringAsync("http://www.isna.ir"),
                    client.GetStringAsync("http://www.iust.ac.ir")};
                
                Task.WaitAll(results);//ask => solved
                Stopwatch sw = new Stopwatch();
                sw.Start();
                foreach(Task<string> r in results)
                {
                    System.Console.WriteLine(r.Result.Length);
                }
                System.Console.WriteLine(sw.ElapsedMilliseconds); 
            }
            Console.WriteLine("Hello World!");
        }
    }
}
