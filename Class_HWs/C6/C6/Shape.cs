using System;
public class Shape
{
    public Shape(string name, int cornerCount)
    {
        Corners = new Point[cornerCount];
    }

    public void UpdateCorner(int i, Point p)
    {
        Corners[i].X = p.X;
        Corners[i].Y = p.Y;
    }

    public Point GetCorner(int i)
    {
        return Corners[i];
    }

    public void SwitchXY(ref Point p)
    {
        int empty = p.X;
        p.X = p.Y;
        p.Y = empty;
    }

    public void ExchangeCorners(int i, int j)
    {
        // Point empty = new Point{X=1, Y=2} ;
        Point empty = Corners[i];
        Corners[i] = Corners[j];
        Corners[j] = empty;
    }

    public void PrintCorners()
    {
        for(int i=0; i< Corners.Length; i++)
        {
            string p = String.Format("Corners[{0}].X: {1} and Corners[{2}].Y: {3}", i, Corners[i].X, i, Corners[i].Y);
            Console.WriteLine(p);
        }
    }

    private Point[] Corners;

}

