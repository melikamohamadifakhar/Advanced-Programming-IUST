using System;

namespace C7
{
    class Program
    {
        static int Test1(int a)
        {
            return Test2(a)+1;
        }

        static int Test2(int a)
        {
            return Test3(a)+1;
        }

        static int Test3(int a)
        {
            return a+1;
        }

        static int Fib(int n)
        {   
            int x = 5;
            int w = 6;
            int t = 2;
            // if (n <= 1)  
            //     return 1;

            if (n % 100 == 0)
                Console.WriteLine("{0},{1},{2},{3}", n, x, w, t);            

            return Fib(n-1) + Fib(n-2);
        }
        class Person
        {
            public int id;
            public Person Clone()
            {
                Person p = new Person(){id=this.id};
                return p;
            }
        }
        struct PersonV
        {         
            public int id;
        }
        static void Modify(ref Person p)
        {
            p.id = 5;
            p = new Person() {id=16};
        }

        // static int Update1(ref int n)
        // {
        //     return n+1;
        // }

        // static void Update(out int n, out int w, out int x, out int s)
        // {
        //     n = 1;
        //     n = n + 1;
        //     return n;
        // }

        static void ProcessPointsRef()
        {
            // class Point (x, y)
            // Console.ReadLine, double.TryParse
            // 2 Point from Input
            // cw Distance

            // Define 1 method to get numbers from input (without error)
            // Define 1 method to get a Point from input

        }

        static void ProcessPointsValue()
        {
            // struct Point (x, y)
            // Console.ReadLine, double.TryParse
            // 2 Point from Input
            // cw Distance

            // Define 1 method to get numbers from input (without error)
            // Define 1 method to get a Point from input
        }



        static void Main(string[] args)
        {   
            // int n1;
            // Update1(ref n1)
            // Update(out n1);                

            Person p2;
            p2.id;
            Person p = new Person{id=5};
            Person p1 = p;
            p.id = 6;
            p = new Person{id=12};
            System.Console.WriteLine(p1.id);

            PersonV pv;
            pv.id = 6;
            PersonV pv1 = pv;
            pv.id=6;
            System.Console.WriteLine(pv1.id);

            int n;
            string str;
            do
            {
                Console.Write("Enter? ");
                str = Console.ReadLine();
            } while(! int.TryParse(str, out n));
            Console.WriteLine($"You number plus 1 is: {n+1}");            


            // int n;
            // if (!int.TryParse(str, out n))
            // {
            //     Console.Write("Enter? ");
            //     str = Console.ReadLine();
            //     n = int.Parse(str);
            // }
        }
    }
}
