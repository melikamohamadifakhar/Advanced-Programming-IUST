using System;

namespace C10
{
    public class Student
    {
        public Student(string name, int stdNum)
            : this(name, stdNum, 20)
        {}

        public Student(string name)
            : this(name, NewStdNum(), 20)
        {}

        public Student(string name, int stdNum, double GPA)
        {
            this.Name = name;
            this.StdId = stdNum;
            this.GPA = GPA;
        }

        public override string ToString()
        {
            return $"{this.Name}\t{this.StdId}\t{this.GPA}";
        }

        // public string Name
        // {
        //     get
        //     {
        //         return this._Name.ToUpper();
        //     }
        //     set
        //     {
        //         // string s = null; = ""; = "     "
        //         // if (s == null || s == "" || s.Trim() == ""
        //         // string s = "  .,  asdfa    ";
        //         // string w = s.Trim(new char[]{' ', ',', '.'}); // "asdfa"
        //         if (!string.IsNullOrWhiteSpace(value))
        //             this._Name = value;
        //     }
            
        // }

        // private string _Name;
        public string Name;
        public int StdId;
        public double GPA; 

        private static int LastStdNum = 99521000;
        private static int NewStdNum() => ++LastStdNum;
    }

    public class StudentGPAComparer: IMyComparer<Student>
    {
        public bool Compare(Student s1, Student s2) 
        {
            return s1.GPA < s2.GPA;
        }
    }

    public class StudentIdComparer: IMyComparer<Student>
    {
        public bool Compare(Student s1, Student s2) => s1.StdId < s2.StdId;
    }

    public class StudentNameComparer: IMyComparer<Student>
    {
        public bool Compare(Student s1, Student s2)
        {
            return StringComparer.CurrentCulture.Compare(s1.Name, s2.Name) < 0;
        }
    }

    public static class StudentComparer
    {
        public static StudentGPAComparer StudentGPAComparer = new StudentGPAComparer();    
        public static StudentIdComparer StudentIdComparer = new StudentIdComparer();    
        public static StudentNameComparer StudentNameComparer = new StudentNameComparer();    
    }
}