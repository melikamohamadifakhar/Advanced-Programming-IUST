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
