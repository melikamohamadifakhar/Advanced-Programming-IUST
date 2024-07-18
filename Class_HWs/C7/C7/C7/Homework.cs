using System;
namespace  C7
{
    class Homework{
        class Point{
            public double X;
            public double Y;
            public Point(){}
            public Point(double x1, double y1){
                X = x1;
                Y = y1;
            }
            public Point(Point other)
            {
                X = other.X;
                Y = other.Y;
            }
        }
        struct PointS
        {
            public double X;
            public double Y;
            public PointS(double x1, double y1){
                X = x1;
                Y = y1;
            }
            public PointS(Point other)
            {
                X = other.X;
                Y = other.Y;
            }
        }
        static double Distance(Point p1, Point p2){
            double xd = Math.Pow((p1.X - p2.X), 2);
            double yd = Math.Pow((p1.Y - p2.Y), 2);
            return Math.Sqrt(xd+yd);
        }
        static double DistanceS(PointS p1,PointS  p2){
            double xd = Math.Pow((p1.X - p2.X), 2);
            double yd = Math.Pow((p1.Y - p2.Y), 2);
            return Math.Sqrt(xd+yd);
        }
        static void ProcessPointsRef()
        {
            int n;
            string x1;
            string x2;
            string y1;
            string y2;
        
            do
            {

                Console.Write("Enter Numbers: ");
                x1 = Console.ReadLine();
                x2 = Console.ReadLine();
                y1 = Console.ReadLine();
                y2 = Console.ReadLine();
            } 
            while(! int.TryParse(x1, out n) && ! int.TryParse(x2, out n) && ! int.TryParse(y1, out n) && ! int.TryParse(y2, out n));
            double  nx1 = double.Parse(x1);
            double  nx2 = double.Parse(x2);
            double  ny1 = double.Parse(y1);
            double  ny2 = double.Parse(y2);
            Point p1 = new Point(nx1, ny1);
            Point p2 = new Point(nx2, ny2);
            double d = Distance(p1, p2);
            Console.WriteLine($"distance of tow points is: {d}");            
        }

        static void ProcessPointsValue()
        {
            int n;
            string x1;
            string x2;
            string y1;
            string y2;
        
            do
            {

                Console.Write("Enter Numbers: ");
                x1 = Console.ReadLine();
                x2 = Console.ReadLine();
                y1 = Console.ReadLine();
                y2 = Console.ReadLine();
            } 
            while(! int.TryParse(x1, out n) && ! int.TryParse(x2, out n) && ! int.TryParse(y1, out n) && ! int.TryParse(y2, out n));
            double  nx1 = double.Parse(x1);
            double  nx2 = double.Parse(x2);
            double  ny1 = double.Parse(y1);
            double  ny2 = double.Parse(y2);
            PointS p1 = new PointS(nx1, ny1);
            PointS p2 = new PointS(nx2, ny2);
            double d = DistanceS(p1, p2);
            Console.WriteLine($"distance of tow points is: {d}");
        }
        static void Main(){
            ProcessPointsRef();
            ProcessPointsValue();

        }
    }
}