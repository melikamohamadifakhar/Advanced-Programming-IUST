using System;
using System.IO;
using System.Text;

namespace A7
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter swr = new StringWriter(sb);
            sb.Append("hello");
            Console.WriteLine(swr);
        }
    }
}
