using System;
public class Point
{
    public Point(int x, int y){
        X = x;
        Y = y;
    }
    public int X{get; set;}
    public int Y{get; set;}
    public double magnitud(){
        return Math.Sqrt((Math.Pow(X, 2) + Math.Pow(Y, 2)));
    }
}
public interface IMyComparer<_Type>
{
    bool Compare(_Type a, _Type b);
}
public class PointXComparer :IMyComparer<Point>
{
    public bool Compare(Point p1, Point p2) => p1.X>p2.X;
}

public class PointYComparer :IMyComparer<Point>
{
    public bool Compare(Point p1, Point p2) => p1.Y>p2.Y;
}

public class PointMagnitudeComparer :IMyComparer<Point>
{
    public bool Compare(Point p1, Point p2){
        double S_1 = Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2);
        double S_2 = Math.Pow(p2.X, 2) + Math.Pow(p2.Y, 2);
        return S_1 > S_2;
    }
}

public static class PointComparer 
{
    public static PointXComparer PointXComparer = new PointXComparer();
    public static PointYComparer PointYComparer = new PointYComparer();
    public static PointMagnitudeComparer PointMagnitudeComparer = new PointMagnitudeComparer();
}
