using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
public static class _mainclass{
    static void Maind(string[] args){
        var thread = new Thread(() => 
        {
            System.Console.WriteLine("start downloading...");
            var html = new HttpClient();
            html.GetStringAsync("http://google.com");
            System.Console.WriteLine("done downloading");
        }
        );
        thread.Start();
        thread.Join(); //thats the point! chera bedone join khate 19 ghabl az 11 ejra mishe?
        System.Console.WriteLine("end of main!");
    }
    static void Main3(string[] args){
        //start va end be tartib nist :\\
        //belafasele bad az start runing mishe. vaghti miad ro break point pause mishe!
        Enumerable.Range(0, 500).ToList().ForEach(f =>
        {
        new Thread(() => 
        {
            System.Console.WriteLine($"creating started {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1);
            System.Console.WriteLine($"end {Thread.CurrentThread.ManagedThreadId}");
        }).Start();
        });
    }
    static void Main2(string[] args){
        var thread = new Thread(()=> {Thread.Sleep(1000);
        System.Console.WriteLine("HttpKeepAlivePingPolicy");
        });
        thread.IsBackground = true;
        thread.Start();
        // Thread.Sleep(1000);
        System.Console.WriteLine("main");
    }

    static void Main1(string[] args){
        Stopwatch s = new Stopwatch();
        s.Start();
        //         Thread.Sleep(1000);
        // System.Console.WriteLine("hello");
        //         Thread.Sleep(1000);
        // System.Console.WriteLine("hello");
        //         Thread.Sleep(1000);
        // System.Console.WriteLine("hello");
        new Thread(() => 
        {
        Thread.Sleep(5000);
        System.Console.WriteLine("hello");
        // Thread.CurrentThread.Join();
        // System.Console.WriteLine(s.ElapsedMilliseconds);
        }
        ).Start();
        new Thread(() => 
        {
        Thread.Sleep(5000);
        System.Console.WriteLine("hello");
        }
        ).Start();
        new Thread(() => 
        {
        Thread.Sleep(5000);
        System.Console.WriteLine("hello");
        }
        ).Start();
        
        System.Console.WriteLine(s.ElapsedMilliseconds);
    }
}