using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
public static class mainclass{
    public static void A1(){
        Stopwatch stopwatch = Stopwatch.StartNew();
        using HttpClient client = new HttpClient();
            Task<string> t1 = client.GetStringAsync(@"https://google.com");
            Task<string> t2 = client.GetStringAsync(@"https://github.com");
            Task.WaitAll(t1, t2);
        Console.WriteLine($"A1: {stopwatch.ElapsedMilliseconds}");
    }
    public static void A2(){
        Stopwatch stopwatch = Stopwatch.StartNew();
        using HttpClient client = new HttpClient();
            Task<string> t1 = client.GetStringAsync(@"https://google.com");
            Task<string> t2 = client.GetStringAsync(@"https://github.com");
            Task.WaitAll(t1, t2);
        Console.WriteLine($"A2: {stopwatch.ElapsedMilliseconds}");
    }
    public static void Mainh(){
        Stopwatch stopwatch = Stopwatch.StartNew();
        A1();
        A2();
        System.Console.WriteLine(stopwatch.ElapsedMilliseconds);
        System.Console.WriteLine("____________________________");

        Stopwatch sw = Stopwatch.StartNew();
        Task task1 = Task.Run(A1);
        Task task2 = Task.Run(A2);
        // Task.WaitAll(task1, task2);
        System.Console.WriteLine(sw.ElapsedMilliseconds);
        System.Console.WriteLine("_____________________________");

        Thread TA1 = new Thread(A1);
        Thread TA2 = new Thread(A2);
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        TA1.Start();
        TA2.Start();
        // TA1.Join(3500);
        // TA2.Join(3500);
        System.Console.WriteLine(stopwatch1.ElapsedMilliseconds);
        
    }

}