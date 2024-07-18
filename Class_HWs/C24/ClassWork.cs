using System;
namespace HW
{
    public class Person //name, natid, ToString()
    {
        string Name{get; set;}
        int National_Id{get; set;}
        public Person(string name, int nid){
            this.Name = name;
            this.National_Id = nid;
        }
        public override string ToString(){
            return $"Name:{Name}\nNational Id:{National_Id}";
        }

    }

    public class Employee : Person // empid, salary, ToString()
    // : base(string Name, int naid)
    {
        int Employee_Id{get; set;}
        double Salary{get; set;}

        public Employee(string name, int nid, int empid, double salary) : base(name, nid){
            this.Employee_Id = nid;
            this.Salary = salary;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nSalary:{Salary}\nEmployee Id:{Employee_Id}";
        }
    }

    public class Student : Person // stdid, gpa, ToString()
    {
        int Student_Id{get; set;}
        double GPA{get; set;}
        public Student(string name, int nid, int sid, double gpa) : base(name, nid)
        {
            this.Student_Id = sid;
            this.GPA = gpa;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nStudent Id:{Student_Id}\nGPA:{GPA}";
        }
    }

    public class GradudateStudent : Student // thesis_title, ToString()
    {
        string Thesis_title{get; set;}
        public GradudateStudent(string name, int nid, int sid, double gpa, string thesis_title) : base(name, nid, sid, gpa)
        {
            this.Thesis_title = thesis_title;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nThesis Title:{Thesis_title}";
        }
    }

    public class Instructor : Employee // teacher_rating
    {
        double Teacher_Rating{get; set;}
        public Instructor(string name, int nid, int empid, double salary, double Trating) : base(name, nid, empid, salary)
        {
            this.Teacher_Rating = Trating;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nRating:{Teacher_Rating}";
        }
    }
    public class test
    {
        static void Main(string[] args){  
            Student s = new Student("melika", 0372368859, 99522086, 18.5);
            System.Console.WriteLine(s.ToString());      
    }
    }

}