using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
class Program  
  {  
    static async Task Mainadf(string[] args)  
    {  
      await callMethod();  
      //  Console.ReadKey();  
      System.Console.WriteLine("in main after callmethod");
    }  
    
    public static async Task callMethod()  
    {  
      Method2();  
      Task t = Task.Run(() => Method1()) ;  
      t.Wait();
      System.Console.WriteLine("in callmethod after await");
      Method3(50);  
    }  
    
    public static async Task<int> Method1()  
    {  
      int count = 0;  
      await Task.Run(() =>  
      {  
        for (int i = 0; i < 100; i++)  
        {  
          Console.WriteLine("Method 1");  
          count += 1;  
        }  
      });  
      return count;  
    }  
    
    public static void Method2()  
    {  
      for (int i = 0; i < 25; i++)  
      {  
        Console.WriteLine(" Method 2");  
      }  
    }  
    
    public static void Method3(int count)  
    {  
      Console.WriteLine("Total count is " + count);  
    }  
  }  