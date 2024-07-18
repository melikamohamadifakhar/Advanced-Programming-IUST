using System;

namespace C18
{

    public class Point: IComparable<Point>
    {
        private int[] Dim;
        public int X {
            get => Dim[0];
            set => Dim[0] = value;
        }
        public int Y {
            get => Dim[1];
            set => Dim[1] = value;
        }  

        public int Z {
            get => Dim[2];
            set => Dim[2] = value;
        }  

        public int Length => Dim.Length;      
        public string Name {get; set;}
        public Point(int x, int y)
        {
            this.Dim = new int[2];
            this.X = x;
            this.Y = y;
        }

        public Point(int x, int y, int z)
        {
            this.Dim = new int[3];
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public void Swap(ref int[] a1, ref int[] b1)
        {
            int[] t = a1;
            a1 = b1;
            b1 = t;
        }

        public Point(params int[] nums)
        {
            this.Dim = new int[nums.Length];
            for(int i=0; i<nums.Length; i++)
                this.Dim[i] = nums[i];
        }

        public Point()
        {
        }

        public double Magnitude => Math.Sqrt(this.X*this.X + this.Y*this.Y);

        public Point AddTo(Point p) => new Point(this.X + p.X , this.Y + p.Y);
        public static Point operator+(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);
        public static Point operator+(Point p1, int n) => new Point(p1.X + n , p1.Y + n);
        public static Point operator*(Point p1, int n) => new Point(p1.X * n , p1.Y * n);

        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            if (null == p)
                return false;
            return this.X == p.X && this.Y == p.Y;
        }

        public int CompareTo(Point other)
        {
            return this.Magnitude.CompareTo(other.Magnitude);
        }

        public static bool operator==(Point p1, Point p2)
        {
            if (ReferenceEquals(p2, null) || ReferenceEquals(p1, null))
                return false;

            return p1.X == p2.X && p1.Y == p2.Y;
        }

        // Operator -
        // Operator /

        public static bool operator!=(Point p1, Point p2) => ! (p1 == p2);
        public static bool operator<(Point p1, Point p2) => p1.Magnitude < p2.Magnitude;
        public static bool operator>(Point p1, Point p2) => p1.Magnitude > p2.Magnitude;
        public static bool operator>=(Point p1, Point p2) => p1.Magnitude >= p2.Magnitude;
        public static bool operator<=(Point p1, Point p2) => p1.Magnitude <= p2.Magnitude;

        public int this[int x, int y]
        {
            get
            {
                return this.Dim[x + y];
            }
            set
            {
                this.Dim[x+y] = value;
            }   
        }

        public int this[string s]
        {
            get
            {
                return this.Dim[int.Parse(s)];
            }
            set
            {
                this.Dim[int.Parse(s)] = value;
            }
        }

        public int this[int n]
        {
            get{
                return this.Dim[n];
            }
            set{
                if (value >= 0)
                    this.Dim[n] = value;
            }
        }    
    }

    class Program1
    {
        public static void Main88(string[]  args)
        {
            int[] nums = new int[3] { 1, 2, 3};
            Point p = new Point(nums);
            nums[1] = 4;
            Point p1 = new Point(nums);
            Point p3 = new Point(5, 4, 2, 3, 1);

            p3[2] = 5;
            int w = p3[3];

            p3["3"] = 5;

        }
        public static void Main2(string[]  args)
        {
            Point p1 = new Point(5, 10);
            Point p2 = new Point(3, 4);
            Point psum = p1.AddTo(p2);
            Point psum1 = p1 + p2;
            Point psum2 = p1 + 5;
            Point pScale = p1 * 5;
            
            Point p3 = new Point(5, 10);            

            if (p3 == p1)
            {
                System.Console.WriteLine("Is Equal");
            }
            else
            {
                System.Console.WriteLine("Not Equal");
            }

            Point p4 = null;
            if (p3.Equals(p4))
            {
                System.Console.WriteLine("Is Equal");
            }
            else
            {
                System.Console.WriteLine("Not Equal");
            }

            if (p1 < p2)
                System.Console.WriteLine("p1 < p2");

            Point[] points = new Point[]{p1, p2, p3};
            Array.Sort(points);


        }
    }

}