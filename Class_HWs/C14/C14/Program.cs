using System;
using System.Collections.Generic;

namespace C14
{
    public class Program
    {
        #region  Hide
        static int add(int a, int b) => a + b;
        static _T[] Perform<_T>(_T[] a, _T[] b, Func<_T,_T,_T> op)
        {
            _T[] c = new _T[a.Length];
            for(int i=0; i<a.Length; i++)
                c[i] = op(a[i], b[i]);
            return c;
        }

        static void do1(int a)
        {}

        static Random rnd = new Random();

        // Func<int>
        static int get_random()
        {
            return rnd.Next();
        }

        static void PrintRndNums(int count, Func<int> rndGen)
        {
            for(int i=0; i<count; i++)
            {
                int rnd = rndGen();
                System.Console.WriteLine(rnd);
            }                
        }

        static void Do(int[] nums, Action<int> action)
        {
            foreach(var n in nums)
                action(n);
        }

        // delegate void MyAction(int a, int b);
        static void Print(int i) 
        {
            System.Console.WriteLine(i);
        } 
        #endregion        
        
        static void Test()
        {
            System.Console.WriteLine("In Test");
        }

        // delegate int MyDelegate(int a, int b);
        // static int myop(int a, int b) => a + b;
        public static void TestAction(int[] nums, 
            Func<int, int>[] op,
            Func<bool>[] iff,
            Action<int>[] dof)
        {
            for (int i=0; i< nums.Length; i++)
            {
                nums[i] = op[i](nums[i]);
                if (iff[i]())
                {
                    dof[i](nums[i]);                    
                }
            }
        }

        static void Main(string[] args)
        {        
            int[] nums = new int[]{1,2,3,4};
            Func<int, int>[] op = new Func<int, int>[nums.Length];
            Func<bool>[] iff = new Func<bool>[nums.Length];
            Action<int>[] dof = new Action<int>[nums.Length];
            for (int i=0; i < nums.Length; i++)
            {
                if(nums[i] % 4 == 0)
                    op[i] = (x) => x+5;
                else if(nums[i] % 4 == 1)
                    op[i] = (x) => x*5;
                else if(nums[i] % 4 == 2)
                    op[i] = (x) => x-5;
                else
                    op[i] = (x) => x/5;
                
                iff[i] = () => true;

                if(i % 2 ==0){
                    dof[i] = (x) =>{
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        System.Console.WriteLine(x);
                    };
                }
                if (i % 2 ==1 )
                {
                    dof[i] = (x) =>{
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        System.Console.WriteLine(x);
                    };
                }
            }
            TestAction(nums,op,iff,dof);
            List<Action> funcs = new List<Action>();
            funcs.Add(Test);
            for(int i=0; i<10; i++)
            {
                void c(){
                    System.Console.WriteLine(i);
                    i++;
                }
                funcs.Add(c);
                c();
            }
            foreach(var fn in funcs)
                fn();

            for(int i=0; i<10; i++)
            {
                Action a = () => 
                {
                    System.Console.WriteLine(i);
                    i++;
                };
                funcs.Add(a);
                a();

            }

            foreach(var fn in funcs)
                fn();
        }

        static void Main1(string[] args)
        {
            int rand = get_random();
            PrintRndNums(5, get_random); //write 5 random int
            int[] l1 = new int[] {1,2,3,4};
            int[] l2 = new int[] {3,4,1,2};
            int[] l3 = Perform<int>(l1, l2, (k,s) => k+s);
            int[] l4 = Perform<int>(l1, l2, add);

            int c = 10;
            // static void herrl(int a){    => can not access to c
            //     a +=c;
            // }

            Action<int> myAction = (a) => {
                for(int i=0; i<a; i++)
                    System.Console.WriteLine(a+c);
                System.Console.WriteLine("Done");
            };

            myAction(5);
            Do(l1, myAction);
            // tow Dos are equal
            Do(l1, (a) => {
                for(int i=0; i<a; i++)
                    System.Console.WriteLine(a);
                System.Console.WriteLine("Done");
            });
            // Do(l1, Print);

            Console.WriteLine("Hello World!");
        }
    }
}
