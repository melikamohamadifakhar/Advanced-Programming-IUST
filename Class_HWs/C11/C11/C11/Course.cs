using System;
using System.Collections;
using System.Collections.Generic;

namespace C11
{
    public class Course : IEnumerable<string>
    {
        public string Instructor;
        public string AssistnatInstructor;
        public Student[] Students;

        public Student[] TAs;
        public string Name {get; set;}

        public IEnumerable<string> GetInstructors()
        {
            yield return this.Instructor;
            yield return this.AssistnatInstructor;
        }

        public IEnumerable<string> GetAdmins()
        {
            yield return this.Instructor;
            foreach (Student s in this.TAs)
                yield return s.Name;
        }


        public IEnumerable<string> Members
        {
            get
            {
                foreach (Student s in this.Students)
                    yield return s.Name;

                foreach (Student s in this.TAs)
                    yield return s.Name;
                yield return this.Instructor;            
            }
        }


        public IEnumerator<string> GetEnumerator()
        {
            return new CourseEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CourseEnumerator(this);
        }        

        #region  Hide
        public IEnumerable<string> GetMembers1()
        {
            List<string> members = new List<string>();
            members.Add(this.Instructor);
            foreach (Student s in this.Students)
                members.Add(s.Name);

            foreach (Student s in this.TAs)
                members.Add(s.Name);

            return members;

        }


        #endregion

        public Course(string instructorName, string name, Student[] students, Student[] TAs)
        {
            this.Instructor = instructorName;
            this.Name = name;
            this.Students = students;
            this.TAs = TAs;
        }
    }

    public class CourseEnumerator : IEnumerator<string>, IComparable<string>
    {
        private Course Course;
        public CourseEnumerator(Course c)
        {
            this.Course = c;
        }

        private int Pos = -1;

        public string Current 
        {
            get
            {
                if (Pos == 0)
                    return this.Course.Instructor;
                else if (Pos < this.Course.TAs.Length + 1)
                    return this.Course.TAs[Pos-1].Name;
                else 
                    return this.Course.Students[Pos-this.Course.TAs.Length-1].Name;
            }
        }


        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()
        {}

        public bool MoveNext()
        {
            this.Pos++;
            return this.Pos < this.Course.TAs.Length + this.Course.Students.Length + 1;
        }

        public void Reset()
        {
            this.Pos = -1;
        }

        public int CompareTo(string other)
        {
            throw new NotImplementedException();
        }
    }
}