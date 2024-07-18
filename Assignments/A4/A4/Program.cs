using System;
using System.Collections.Generic;
using System.IO;
namespace IDGFileSystemWatcher
{
    class Program

    {
        public enum adasf{
            a, b
        }
        public delegate void x();
        static void Main(string[] args)  
        {  
            // x += (()=>
            // {
            //     System.Console.WriteLine("asdf");
            // });

            System.Console.WriteLine(adasf.a.GetType());
            System.Console.WriteLine(adasf.b.GetType());
            
            object name = "sandeep";  
            char[] values = {'s','a','n','d','e','e','p'};  
            object myName = new string(values);
            List<int> refe = new List<int>();
            for (int i = 0; i < 10; i++)
                refe.Add(i);
            List<int> result = new List<int>(){1,2,3,4,5,6,7,8,9};
            Console.WriteLine("== operator result is {0}", result == refe);  
            Console.WriteLine("Equals method result is {0}", result.Equals(refe));  
        }  














      static void Mainj(string[] args)   
       {   
          string name = "sandeep";   
          string myName = name;   
          Console.WriteLine("== operator result is {0}", name == myName);  
            Console.WriteLine("Equals method result is {0}", name.Equals(myName)); 
        }    
  

        static void Maing(string[] args)
        {
            object a = "hello";
            object b = "hello";
            if(a==b)
                System.Console.WriteLine("entered to if");
        }

        private static void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;

            fileSystemWatcher.EnableRaisingEvents = true;

        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)

        {

            Console.WriteLine("File created: {0}", e.Name);

        }

        private static void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)

        {

            Console.WriteLine("File renamed: {0}", e.Name);

        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)

        {

            Console.WriteLine("File deleted: {0}", e.Name);

        }

    }

}