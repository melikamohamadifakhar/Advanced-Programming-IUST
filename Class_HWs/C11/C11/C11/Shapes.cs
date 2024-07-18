
using System;
using System.Collections;
using System.Collections.Generic;

public interface IShape
{
    void Move(int x, int y);
    string Name {get;}
}
public class Point{
    public Point(int x, int y){
        this.X = x;
        this.Y = y;
    }
    public int X;
    public int Y;
}

public class Triangle : IShape // Constructor?
{
    public Point p1;
    public Point p2;
    public Point p3;
    public string Name{get; set;}
    public Triangle(string name, Point P1, Point P2, Point P3){
        this.p1 = P1;
        this.p2 = P2;
        this.p3 = P3;
        this.Name = name;
    }
    public void Move(int x, int y)
    {
        p1.X += x;
        p2.X += x;
        p3.X += x;
        p1.Y += y;
        p2.Y += y;
        p3.Y += y;
    }
}

public class Circle: IShape
{
    public Point Center;
    public string Name{get; set;}
    public int r;

    public Circle(string name, int xC, int yC, int R)
    {
        this.Name = name;
        this.Center.X = xC;
        this.Center.Y = yC;
        this.r = R;
    }


    public void Move(int x, int y)
    {
        this.Center.X += x;
        this.Center.Y += y;
    }
}

public class Square : IShape // Constructor?
{
    public Point P1;
    public Point P2;
    public Point P3;
    public Point P4;
    public string Name{get; set;}
    public Square(string name, Point p1, Point p2, Point p3, Point p4)
    {
        this.Name = name;
        this.P1 = p1;
        this.P2 = p2;
        this.P3 = p3;
    }

    public void Move(int x, int y)
    {
        P1.X += x;
        P2.X += x;
        P3.X += x;
        P4.X += x;
        P1.Y += y;
        P2.Y += y;
        P3.Y += y;
        P4.Y += y;
    }
}

public class Board: IEnumerable<IShape>
{
    void MoveAllShapes(int x, int y)
    {
        foreach(IShape shape in this)
            shape.Move(x, y);
    }

    public List<IShape> l = new List<IShape>();
    public IEnumerable<IShape> Shapes { get; }

    public void AddShape(IShape s){
        l.Add(s);
    }

    public IEnumerator<IShape> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class BoardProgram
{
    public static void Main3(string[] args)
    {
        Board b = new Board();
        Circle c = new Circle("ball", 1, 2, 3);
        Circle c2 = new Circle("target", 1, 2, 3);
        // Square s1 = new Square();//("target", 1, 2, 3);
        b.AddShape(c);
        b.AddShape(c2);
        // b.AddShape(s1);
        foreach(IShape s in b)
        {
            Console.WriteLine(s.Name);
        }
    }
}