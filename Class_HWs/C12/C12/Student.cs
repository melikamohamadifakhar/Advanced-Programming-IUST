using System.Collections.Generic;
using System.IO;

interface IPerson
{
    int NationalId {get; set;}
}

public class Student: IPerson
{
    public string Name {get; private set;}

    public readonly bool IsFemale;

    public const int MinId = 99521000;

    private int _Id;
    public int Id 
    {
        get
        {
            return _Id;
        }

        set
        {
            if (value > MinId)
                this._Id = value;
        }
    }
    private double _GPA;

    private List<double> Grades = new List<double>();

    private bool IsFailing;

    public Student(string name, int id, double gpa, bool isFemale=true)
    {
        this.Name = name;
        this.Id = id;
        this.SetGPA(gpa);
        this.IsFemale = isFemale;
    }

    private static int LastStdNum;

    private static int NewStdNum
    {
        get => ++LastStdNum;
    }

    public static void CreateRandomStudent()
    {
        if (MinId > 10)
            System.Console.WriteLine();
    }

    public double GPA
    {
        get
        {
            return this._GPA;
        }

        set
        {
            if (value <= 20 && value >= 0)
            {
                this._GPA = value;

                if (value < 10)
                    this.IsFailing = true;
            }
            else
                throw new InvalidDataException();
        }
    }

    public int NationalId { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public bool SetGPA(double gpa)
    {
        if (gpa <= 20 && gpa >= 0)
        {
            this._GPA = gpa;

            if (gpa < 10)
                this.IsFailing = true;

            return true;
        }

        return false;

    }

    public double GetGPA()
    {
        return this._GPA;
        // double sum = 0;
        // foreach(double g in this.Grades)
        //     sum += g;

        // return sum / this.Grades.Count;
    }



}