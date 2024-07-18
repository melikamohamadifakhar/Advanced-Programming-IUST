#include<string>
#include<vector>
#include<iostream>
using namespace std;

class Student
{
public:
    Student(string firstName, string lastName, int stdId, string major)
        : m_firstName(firstName)
        , m_lastName(lastName)
        , m_stdId(stdId)
        , m_major(major)
    {}

    Student(const Student& other)
    {
        m_firstName = other.m_firstName;
        m_lastName = other.m_lastName;
        m_stdId = other.m_stdId;
        m_major = other.m_major;
    }

    void PrintCompareTranscript(Student& aysa)
    {
        cout << "Course Name" << "       " << "Course Units" << "       " << "Aysa's grade" << endl;
        for (int i = 0; i < m_vGrades.size(); i++)
        {
            cout << m_vCourses[i] <<  "                   " << m_vCourseUnit[i] << "                     "<< aysa.m_vGrades[i] << endl;
        }
        for (int i = 0; i < 50; i++)
        {
            cout << "-";
        }
        cout<< "-" <<endl;
        cout << "Course Name" << "       " << "Course Units" << "       " << "Aylin's grade" << endl;
        for (int i = 0; i < m_vGrades.size(); i++)
        {
            cout << m_vCourses[i] <<  "                   " << m_vCourseUnit[i] << "                     " << m_vGrades[i] << endl;
        }
        for (int i = 0; i < 50; i++)
        {
            cout << "-";
        }
        cout<< "-" <<endl;
        cout << "Course Name" << "       " << "Course Units" << "       " <<"difference"<<endl;
        for (int i = 0; i < m_vGrades.size(); i++)
        {
            cout << m_vCourses[i] <<  "                   " << m_vCourseUnit[i] << "                     " << aysa.m_vGrades[i] - m_vGrades[i] << endl;
        }
    }

    void RegisterGrade(string course, int units, double grade)
    {
        m_vCourses.push_back(course);
        m_vCourseUnit.push_back(units);
        m_vGrades.push_back(grade);
    }

    void PrintTranscript()
    {
        cout << "Course Name" << "     " << "Course Units" << "     " << "Grade" << endl;
        for (int i=0; i<m_vGrades.size(); i++)
        {
            cout << m_vCourses[i] << "                    " << m_vCourseUnit[i] << "           " << m_vGrades[i] << endl;
        }
        cout<< "GPA: " << get_GPA() <<endl;
        PrintFailedCourses();
    }

    string get_fullName()
    {
        string fullname = m_firstName + " " + m_lastName;
        return fullname;
    }

    int get_stdId()
    {
        return m_stdId;
    }

    string get_major()
    {
        return m_major;
    } 

    void PrintFailedCourses()
    {
        cout << "Failed Courses:" << endl;
        for (int i=0; i< m_vGrades.size(); i++)
        {
            if (m_vGrades[i]<10)
                cout << m_vCourses[i] << endl;
        }
    } 

    double get_GPA()
    {
        double sum=0;
        int unit=0;
        for (int i = 0; i < m_vGrades.size(); i++)
        {
            sum += m_vGrades[i]*m_vCourseUnit[i];
            unit += m_vCourseUnit[i];
        }
        double GPA = sum/unit;
        return GPA;
    }


    void set_firstName(string firstName)
    {
        m_firstName = firstName;
    }

    void set_lastName(string lastName)
    {
        m_lastName = lastName;
    }

    void set_stdId(int stdId)
    {
        m_stdId = stdId;
    } 

    void set_major(string major)
    {
        m_major = major;
    }

private:
    string m_firstName;
    string m_lastName;
    int m_stdId;
    string m_major;
    vector<int> m_vCourseUnit;
    vector<double> m_vGrades;
    vector<string> m_vCourses;
};


int main()
{
    Student mn("Aysa", "Mayahinia", 99521231, "Computer");
    cout << mn.get_fullName() << endl;
    mn.RegisterGrade("AP", 3, 18);
    mn.RegisterGrade("DS", 3, 18.5);
    mn.RegisterGrade("FC", 3, 18);
    mn.RegisterGrade("CL", 3, 8);
    mn.RegisterGrade("AL", 3, 9);
    cout << "GPA: " << mn.get_GPA() << endl;
    mn.PrintTranscript();
    mn.PrintFailedCourses();

    Student nz(mn);
    nz.set_firstName("Aylin");
    nz.set_lastName("Naebzadeh");
    nz.set_stdId(99521111);
    nz.RegisterGrade("AP", 3, 20);
    nz.RegisterGrade("DS", 3, 18);
    nz.RegisterGrade("FC", 3, 16.5);
    nz.RegisterGrade("CL", 3, 8);
    nz.RegisterGrade("AL", 3, 4);
    cout << "GPA: " << nz.get_GPA() << endl;
    nz.PrintTranscript();
    nz.PrintFailedCourses();
    cout << mn.get_fullName() <<endl;
    cout << "GPA: " << mn.get_GPA() << endl;
    nz.PrintCompareTranscript(mn);
    return 0;
}