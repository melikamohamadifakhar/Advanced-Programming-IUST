using System;
using System.Collections.Generic;
using System.IO;

namespace C12
{
    class KeepTime: IDisposable
    {
        public KeepTime(string name)
        {
            Name = name;
            this.Start();
        }

        public string Name { get; }

        private DateTime StartTime;
        private TimeSpan _ElapsedTime;
        public TimeSpan ElapsedTime { get =>_ElapsedTime;}

        public void Start()
        {
            this.StartTime = DateTime.Now;
        }

        public void Stop()
        {
            this._ElapsedTime = new TimeSpan(DateTime.Now.Ticks - StartTime.Ticks);
        }

        public void PrintInfo()
        {
            System.Console.WriteLine($"Task: {this.Name} took {this.ElapsedTime.TotalMilliseconds} ms");
        }

        public void Dispose()
        {
            this.Stop();
            this.PrintInfo();
        }
    }


    public class Program
    {
        // static void LinesNum(string )
        public static void ReverseTextFile(string inFile, string outFile)
        {
            using (StreamReader reader = new StreamReader(inFile))
            {
                using (StreamWriter writer = new StreamWriter(outFile))
                {
                    List<string> m_lines = new List<string>();
                    string line;

                    while (null != (line = reader.ReadLine()))
                    {
                        m_lines.Add(line);
                    }
                    for (int i = m_lines.Count -1; i>=0; i--)
                    {
                        writer.WriteLine(m_lines[i]);
                    }
                }
            }
            // string[] lines = File.ReadAllLines(inFile);
            // File.WriteAllLines(outFile, lines);
        }

        static void Main(string[] args)
        {
            // Program.ReverseTextFile(@"C:\Users\User\file.txt",@"C:\Users\User\file1.txt");
            // using (KeepTime timer = new KeepTime("Nested Loop"))
            // {
            //     double d = 1.9;
            //     for(int i=0; i<10000; i++)
            //         for(int j=0; j<10000; j++)
            //         {
            //             d = d * d;
            //             if (d > 900)
            //                 break;
            //         }
            // }


            // using (StreamReader reader = new StreamReader(@"c:\Data\wordlist.txt"))
            // {
            //     using (StreamWriter writer = new StreamWriter(@"c:\Data\wordlist.copy.txt"))
            //     {
            //         string line;
            //         while (null != (line = reader.ReadLine()))
            //         {
            //             if (line.Length < 10)
            //                 writer.WriteLine(line);
            //             else
            //                 return;
            //         }
            //     }
            // }

            // using (StreamReader reader = new StreamReader(@"C:\Users\User\file.txt"))
            // {
            //     using (StreamWriter writer = new StreamWriter(@"C:\Users\User\file1.txt"))
            //     {
            //         List<string> lines = new List<string>();
            //         string line;
            //         while (null != (line = reader.ReadLine()))
            //         {
            //             lines.Add(line);
            //         }
            //     }
            // }

            // foreach(string s in args)
            // {}

        }
        static void Main2(string[] args)
        {
            

            Student s = new Student("Zhaleh", 995212212, 15.5);
            double gpa = 22;
            if (!s.SetGPA(gpa))
                System.Console.WriteLine($"Error invalid GPA {gpa}");

            double d = s.GPA;
            s.GPA = 19.9;
            s.Id = 989898;
            System.Console.WriteLine(s.Id);
            System.Console.WriteLine(s.Name);
            
            // s.Name = "hossein";

        }
    }
}
