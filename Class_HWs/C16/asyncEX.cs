using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
class Name
{
    static int Calculate()
    {
        // calculate total count of digits in strings.
        int size = 0;
        for (int z = 0; z < 100; z++)
        {
            for (int i = 0; i < 100000; i++)
            {
                string value = i.ToString();
                size += value.Length;
            }
        }
        return size;
    }

    public static async void Execute()
    {
        // running this method asynchronously.
        int t = await Task.Run(() => Calculate());
        Console.WriteLine("Result: " + t);
    }

    static void Main(string[] args)
    {
        Execute();
        Thread.Sleep(800);
        Console.WriteLine("Hello World");
        // Console.ReadLine();
    }
}