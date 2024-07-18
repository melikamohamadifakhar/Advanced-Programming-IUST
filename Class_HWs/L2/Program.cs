// using System;

// namespace New_folder__3_
// {
//     class Program
//     {

//         static void Main(string[] args)
//         {
//             Fighter f1 = new Fighter("first fighter", 50);
//             Fighter f2 = new Fighter("second fighter", 50);
//             f1.GameOver += Dead;
//             f2.GameOver += Dead;

//         while (true)
//         {
//             f2.Attack(f1);
//             f1.Attack(f2);
//             System.Console.WriteLine($"{f1.Name}:{f1.Health}-----{f2.Name}:{f2.Health}");
//         }

//         }
//     public static void Dead(Fighter f1, Fighter f2){
//         System.Console.WriteLine($"{f1.Name}:{f1.Health}-----{f2.Name}:{f2.Health}");
//     }
//     }
// }
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
// class Program
// {
//     static async Task Main(string[] args)
//     {
//         await callMethod();
//         //  Console.ReadKey();  
//         System.Console.WriteLine("in main after callmethod");
//     }

//     public static async Task callMethod()
//     {
//         Method2();
//         var count = await Method1();
//         System.Console.WriteLine("in callmethod after await");
//         Method3(count);
//     }

//     public static async Task<int> Method1()
//     {
//         int count = 0;
//         await Task.Run(() =>
//         {
//             for (int i = 0; i < 100; i++)
//             {
//                 Console.WriteLine("Method 1");
//                 count += 1;
//             }
//         });
//         return count;
//     }

//     public static void Method2()
//     {
//         for (int i = 0; i < 25; i++)
//         {
//             Console.WriteLine(" Method 2");
//         }
//     }

//     public static void Method3(int count)
//     {
//         Console.WriteLine("Total count is " + count);
//     }
// }
// class Name
// {
//     static int Calculate()
//     {
//         // calculate total count of digits in strings.
//         int size = 0;
//         for (int z = 0; z < 100; z++)
//         {
//             for (int i = 0; i < 100000; i++)
//             {
//                 string value = i.ToString();
//                 size += value.Length;
//             }
//         }
//         return size;
//     }

//     public static async Task Execute()
//     {
//         // running this method asynchronously.
//         int t = await Task.Run(() => Calculate());
//         Console.WriteLine("Result: " + t);
//     }

//     static async Task  Main(string[] args)
//     {
//         Stopwatch s = new Stopwatch();
//         s.Start();
//         await Execute();
//         // Thread.Sleep(800);
//         Console.WriteLine("Hello World");
//         // Console.ReadLine();
//         System.Console.WriteLine(s.ElapsedMilliseconds);
//     }
// }
public static class _mainclass{
    static void Mainasdf(string[] args){
        var thread = new Thread(() => 
        {
            System.Console.WriteLine("start downloading...");
            using( var html = new HttpClient()){
            html.GetStringAsync("http://google.com");
            System.Console.WriteLine("done downloading");}
        }
        );
        thread.Start();
        thread.Join(); //thats the point! chera bedone join khate 19 ghabl az 11 ejra mishe?
        System.Console.WriteLine("end of main!");
    }
    static void Mainadf(string[] args){
        //start va end be tartib nist :\\
        //belafasele bad az start runing mishe. vaghti miad ro break point pause mishe!
        object forlock = new object();
        Enumerable.Range(0, 500).ToList().ForEach(f =>
        {
            
        new Thread(() => 
        {
            //lock(forlock){ =>Thats the point!
            System.Console.WriteLine($"creating started {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1);
            System.Console.WriteLine($"end {Thread.CurrentThread.ManagedThreadId}");
        }).Start();
        //}
        });
    }
    static void Mainasdff(string[] args){
        // Task t = Task.Run(()=> 
        // {
        //     for (int i = 0; i < 2000; i++)
        //     {
        //         System.Console.WriteLine(i);
        //     }
        // });
        Thread t = new Thread(()=>
        {
            for (int i = 0; i < 2000; i++)
            {
                System.Console.WriteLine(i);
            }
        });
        t.Start();
        t.IsBackground = true;
        // var thread = new Thread(()=> {Thread.Sleep(1000);
        // System.Console.WriteLine("HttpKeepAlivePingPolicy");
        // });
        // thread.IsBackground = true;
        // thread.Start();
        // Thread.Sleep(1000);
        System.Console.WriteLine("main");
    }

    static void Main(string[] args){
        Stopwatch s = new Stopwatch();
        s.Start();
        //         Thread.Sleep(1000);
        // System.Console.WriteLine("hello");
        //         Thread.Sleep(1000);
        // System.Console.WriteLine("hello");
        //         Thread.Sleep(1000);
        // System.Console.WriteLine("hello");
        Thread t = new Thread(() => 
        {
        // Thread.Sleep(5000);
        for(int i=0; i<100 ; i++)
        System.Console.WriteLine("1");
        // Thread.CurrentThread.Join();
        // System.Console.WriteLine(s.ElapsedMilliseconds);
        }
        );
        t.Start();
        t.IsBackground = true;
        Thread t1 = new Thread(() => 
        {
            for(int i=0; i<100 ; i++)
        // Thread.Sleep(5000);
        System.Console.WriteLine("2");
        }
        );
        t1.IsBackground = true;
        t1.Start();
        // new Thread(() => 
        // {
        //     for(int i=0; i<100 ; i++)
        // // Thread.Sleep(5000);
        // System.Console.WriteLine("3");
        // }
        // ).Start();
        
        System.Console.WriteLine($"elapsed time: {s.ElapsedMilliseconds}");
    }
}