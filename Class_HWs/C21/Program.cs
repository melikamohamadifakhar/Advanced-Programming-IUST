using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace C21
{
    static class MyExt
    {
        public static int MyCount<Type>(this IEnumerable<Type> input)
        {
            int c = 0;
            foreach(var e in input)
                c++;
            return  c;
        }
        public static Type[] MyToArray<Type>(this IEnumerable<Type> input)
        {
            List<Type> values = new List<Type>();
            foreach(var e in input)
                values.Add(e);
            return values.ToArray();
        }
        public static IEnumerable<Type> Skip2<Type>(this IEnumerable<Type> input, int count)
        {
            int i = 0;
            foreach(var e in input)
            {
                if (i >= count)
                    yield return e;
                i++;
            }
        }
        //average✅
        public static double MyAverage(this IEnumerable<double> input)
        {
            double sum = 0;
            foreach(var i in input)
            {
                sum += i ;
            }
            return sum/input.Count() ;
        }
        // TODO: Implement MyWhere like Where✅
        public static IEnumerable<Type> MyWhere<Type>(this IEnumerable<Type> input, Func<Type,bool> where)
        {
            foreach(var i in input)
            {
                if(where(i))
                    yield return i ;
            }
        }
        public static int ConvertToInt(string input)
        {
            return int.Parse(input);
        }
        public static IEnumerable<TypeOut> MySelector<TypeIn, TypeOut>(this IEnumerable<TypeIn> input, Func<TypeIn, TypeOut> selector)
        {
            foreach(var e in input)
                yield return selector(e);
        }
        public static IEnumerable<Type> Skip3<Type>(this IEnumerable<Type> input, int count)
        {
            var e = input.GetEnumerator();
            System.Console.WriteLine(e);
            for(int i=0; i<count; i++)
                e.MoveNext();
            
            while (e.MoveNext())
                yield return e.Current;
        }
        public static Type MyAggregate<Type>(this IEnumerable<Type> input, Func<Type, Type, Type> aggregator)
        {
            // TODO: Optional: Implement MyAggregate correctly✅
            var e = input.GetEnumerator();
            e.MoveNext();
            Type t = e.Current ;
            foreach(var i in input)
                t = aggregator(t, i);
            return t;
        }
    }

    class Program
    {   
        public static void PrintToConsole( (int x, string y) input)             
        {
            System.Console.WriteLine($"{input.x} ==> {input.y}");
        }
        static void Main(string[] args) //test MyAggregate - MyWhere
        {
            int[] array = {1,2,3,4,5};
            int result = array.MyAggregate((x,y)=> x*y );
            System.Console.WriteLine(result);
            // IEnumerable<int> a = array.Skip3(2);
            // System.Console.WriteLine(a);
            // IEnumerable<int> a = array ;
            // IEnumerable<int> b = a.MyWhere(d => d>2 ? true : false );
        }
        static void Main755(string[] args) //test MyWhere
        {
            string w = "test";
            string w1 = w.ToUpper();
            int len = w1.Length;
            int mylen = w.ToUpper().Length;

            var item = 
            File.ReadLines(@"ChildMortality.csv")
                .Skip(2)
                .Select(s => {
                    var toks = s.Split(',').Select(t => t.Trim(new char[]{'\"', ' '})).ToArray(); ///trim => hazf "
                    return new {
                        Country = toks[0], 
                        Year = int.Parse(toks[1]),
                        Both = double.Parse(toks[2].Split(' ')[0])
                    };
                })
                .MyWhere(d => d.Country.StartsWith("Iran"))//2
                .Aggregate( (d1, d2) => d1.Both > d2.Both ? d1 : d2);//1

            System.Console.WriteLine($"{item.Country} - {item.Year} - {item.Both}");
            // foreach(var i in item)
            //     System.Console.WriteLine($"{i.Country} - {i.Year} - {i.Both}");

        }
        static void Main44(string[] args)
        {
            // var item = 
            File.ReadLines(@"ChildMortality.csv")
                .Skip(2)
                .Select(s => {
                    var toks = s.Split(',').Select(t => t.Trim(new char[]{'\"', ' '})).ToArray();
                    return new {
                        Country = toks[0], 
                        Year = int.Parse(toks[1].Split(' ')[0]),
                        Both = double.Parse(toks[2].Split(' ')[0])
                    };
                })
                .GroupBy(d => d.Country)
                // .Select(g => (country: g.Key, both: g.Select(d => d.Both).Max()))
                // .Select(g => new {country= g.Key, both= g.Select(d => d.Both).Max()})
                .Select(g => new {country= g.Key, both= g.Select(d => d.Both).MyAverage()})
                .OrderBy(d => d.both)
                .Take(10)
                .ToList()
                .ForEach(d => System.Console.WriteLine($"{d.country} {d.both}"));
        }

        static void Main55(string[] args)
        {
            int x = Enumerable.Range(1, 10).Aggregate( (x,y) => x+y );
            System.Console.WriteLine(x);
            Random random= new Random();
            int y = Enumerable.Range(1, 10).Select(x => random.Next()).Aggregate( (x,y) => x>y ? x : y);
            System.Console.WriteLine(y);
        }

        static void Main3(string[] args)
        {
            // var result = Enumerable.Range(1, 20).Select(n => n*n).Select(n => n.ToString());
            // File.WriteAllLines("out.txt", result);

            PrintToConsole((123, "asdf"));
            var t = (5, "dsfds");
            PrintToConsole(t);

            ValueTuple<string, int, int, int, int, int> xw = new ValueTuple<string, int, int, int, int, int>();

            ValueTuple<string, int> vt = new ValueTuple<string, int>("test", 5);

            var result = File.ReadAllLines("out.txt").MySelector(MyExt.ConvertToInt).ToArray();
            foreach(var r in result)
                System.Console.WriteLine(Math.Sqrt(r));

            var d = new {Count=5, Sum=15, Division=2};
            int w = d.Count + d.Sum - d.Division;

            (int Count, int Sum, int Division, string s) wt = (4, 7, 12, "test");
            int x = wt.Count + wt.Sum + wt.Division;
            int n1;
            string s2;
            (n1, _, _, s2) = wt;
            int a = 5;
            int b = 6;
            (a, b) = (b, a);

            ValueTuple<int,int> ttt = new ValueTuple<int, int>(b, a);
            (a, b) = ttt;
        }
    }
}
