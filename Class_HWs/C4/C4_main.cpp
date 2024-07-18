#include<vector>
#include<string>
#include<iostream>

using namespace std;

class University{
private:
    string uni_name;
    string uni_address;
public:
    University(const string& name, const string& address){
        uni_name = name;
        uni_address = address;
    }
    void PrintInfo(){
        cout << "University Name: " << uni_name << endl;
        cout << "University Address: " << uni_address << endl; 
    }
    string get_uni_name() const{
        return uni_name;
    }
};

class Instructor{
private:
    University uni;
    string Ins_name;
    int Ins_id;
    string Ins_department;
public:
    Instructor(const University& univ, string name, int id, string department):
    uni(univ),
    Ins_name(name),
    Ins_id(id),
    Ins_department(department)
    {

    }
    void PrintInfo(){
        cout << "Ins_name: " << Ins_name << endl;
        cout << "Ins_university name: " << uni.get_uni_name() << endl;
        cout << "Ins_Id: " << Ins_id << endl;
        cout << "Ins_Department: " << Ins_department << endl;
    }
};

class Course
{
private:
    University uni;
    Instructor Ins;
    string C_name;
    int C_unit;

public:
    double C_grade;
    Course(const University& univ, const Instructor& instructor, const string& name, double grade, int unit)
    :uni(univ),
    Ins(instructor),
    C_name(name),
    C_grade(grade),
    C_unit(unit)
    {
        uni = univ;
    }
    string getname(){
        return C_name;
    }
    // double getgrade(){
    //     return C_grade;
    // }
    void PrintInfo(){
        cout << "Course: " << C_name << endl;
        cout << "Unit: " << C_unit << endl;
        cout << "Grade: " << C_grade << endl;
        // uni.PrintInfo();
        Ins.PrintInfo(); 
    }
};

class Student
{
private:
    University uni;
    string S_name;
    int S_id;
    string S_major;
    vector<Course> m_Courses;
public:    
    Student(const University& univ, const string& name, int id, const string& major)
    :uni(univ),
    S_name(name),
    S_id(id),
    S_major(major)
    {}

    void PrintTranscript(){
        cout << "Std_Name: " << S_name << endl;
        cout << "Std_ID: " << S_id << endl;
        cout << "Std_Major: " << S_major << endl;
        uni.PrintInfo();
        for (int i = 0; i < m_Courses.size(); i++)
        {
            m_Courses[i].PrintInfo();
        }
    }

    void RegisterCourse(const Course& course)
    {
        m_Courses.push_back(course);
    }
    void RegisterGrade(const string &C_name, double grade)
    {
        
        for(int i=0; i<m_Courses.size(); i++){
            if (C_name == m_Courses[i].getname())
            {
                m_Courses[i].C_grade = grade;
            }
        }
    }
};


int main(int argc, char const *argv[])
{
    University iust("Iran University of Science and Technology", "Median resalat....");
    // iust.PrintInfo();
    Instructor ostad_hoseini(iust, "hosseini", 923423, "Math");
    // ostad_hoseini.PrintInfo();
    Course math101(iust, ostad_hoseini, "Math 101", 0, 3);
    // math101.PrintInfo();
    Student sara(iust, "sara pejmani", 98342342, "EE");
    sara.RegisterCourse(math101);
    sara.RegisterGrade("Math 101", 19.8);
    sara.PrintTranscript();

    return 0;
}
