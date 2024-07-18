using System;
public class Point
{
    public double X;
    public double Y;
    public double Z;
    public Point(double x, double y, double z){
        X=x;
        Y=y;
        Z=z;
    }

    public double DistanceTo(Point other)
    {
        double result = DistanceTo(other, this);
        return result;
    }

    public static double DistanceTo(Point a, Point b)
    {
        double sum = Math.Pow((a.X-b.X), 2) + Math.Pow((a.Y-b.Y), 2) + Math.Pow((a.Z-b.Z), 2);
        double distance = Math.Sqrt(sum);
        return distance;
    }
    void PrintInfo()
    {
        Console.WriteLine("X: "+ X);
        Console.WriteLine("Y: "+ Y);
        Console.WriteLine("Z: "+ Z);
    }
    static void Main(string [] args)
    {
        Console.WriteLine("Z: ");
    }
}

public struct PointValue
{
    double X;
    double Y;
    double Z;
    public PointValue(double x, double y, double z){
        X=x;
        Y=y;
        Z=z;
    }
    public double DistanceTo(PointValue other)
    {
        double result = DistanceTo(other, this);
        return result;
    }
    public static double DistanceTo(PointValue a, PointValue b)
    {
        double sum = Math.Pow((a.X-b.X), 2) + Math.Pow((a.Y-b.Y), 2) + Math.Pow((a.Z-b.Z), 2);
        double distance = Math.Sqrt(sum);
        return distance;
    }
    void PrintInfo()
    {
        Console.WriteLine("X: "+ X);
        Console.WriteLine("Y: "+ Y);
        Console.WriteLine("Z: "+ Z);
    }
}
