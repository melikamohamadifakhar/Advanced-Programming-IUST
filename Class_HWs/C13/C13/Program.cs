using System;
using System.Collections.Generic;

namespace C13
{
    public class Program
    {
        public static void Swap<_Type>(_Type[] nums, int i, int j)
        {
            _Type temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        public static void Sort<_Type>(_Type[] nums, Func<_Type, _Type, bool> cmp)
        {
            for(int i=0; i<nums.Length; i++)
                for (int j=i; j<nums.Length; j++)
                    if (cmp(nums[i], nums[j]))
                        Swap<_Type>(nums, i, j);
        }
        delegate int binary_op(int a, int b);
        delegate bool predicate(int a, int b);

        static int[] combine(int[] a, int[] b, binary_op[] ops) =>
            combine(a, b, ops, always);

        static int[] combine(int[] a, int[] b, binary_op[] ops, predicate p)
        {
            foreach(var op in ops)
            {
                a = combine(a, b, op, p);
            }
            return a;
        }

        static int[] combine(int[] a, int[] b, binary_op op, predicate p)
        {
            if (a == null || b == null || a.Length != b.Length)
                return null;

            int[] c = new int[a.Length];
            for(int i=0; i<a.Length; i++)
            {
                if (p(a[i], b[i]))
                    c[i] = op(a[i], b[i]);
                else
                    c[i] = -1;
            }
            return c;
        }

        static int add(int a, int b) => a + b;
        static int sub(int a, int b) => a - b;
        static int mul(int a, int b) => a * b;

        static bool always(int a, int b) => true;
        static bool if_even(int a, int b) => a % 2 == 0;

        int div(int a, int b) => a / b;

        static void Main(string[] args)
        {
            int [] list1 = new int[]{2, 3, 4, 1, 4};
            int [] list2 = new int[]{0, -3, 1, 2, 4};
            // a * 3 + b * 2
            // ? a + b even

            var list3 = combine(list1, list2,
                (a, b) => a * 3 + b * 2,
                (a, b) => (a + b) % 2 == 0
            );

            var ops = new binary_op[] {
                (a,b)=>a+b, 
                (a,b)=>a*b, 
                (a,b)=>a-b
            };


            binary_op my_op = (a, b) => a * 3 + b * 2;
            predicate p = (a, b) => (a + b) % 2 == 0;
            var mylist = combine(list1, list2, my_op, p);

            var list4 = combine(list1, list2,
                new binary_op[] {
                    (a,b)=>a+b,
                    (a,b)=>a*b,
                    (a,b)=>a-b
                }
            );

        }

        static void Main2(string[] args)
        {
            int [] list1 = new int[]{2, 3, 4, 1, 4};
            int [] list2 = new int[]{0, -3, 1, 2, 4};

            var ops = new binary_op[] {add, mul, sub};
            var opslist = new List<binary_op>(ops);
            opslist.Add(new Program().div);

            // list1 = combine(list1, list2, ops);
            list1 = combine(list1, list2, add, if_even);
        }
    }
}
