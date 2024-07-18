#include<vector>
#include<iostream>
#include<string>
#include<string.h>

using namespace std;

class myvector
{
public:
    myvector()
    {}

    ~myvector()
    {}

    void resize()
    {}

    void push_back(int x)
    {}

    int get(int i)
    {}

    int size()
    {}

private:
    int* m_pData;
    int m_nSize;
    int m_nCapacity;
};

class mystr
{
public:
    mystr(const char* pch) 
        : m_pData(nullptr)
        , m_nSize(0)
    {        
        assign(pch);
    }

    ~mystr()
    {
        if (m_pData)
            free(m_pData);
    }

    int get_size()
    {
        return m_nSize;
    }

    void assign(const char* pch)
    {
        if (m_pData)
            free(m_pData);

        m_nSize = strlen(pch);
        m_pData = (char*) malloc((m_nSize+1) * sizeof(char));
        strcpy(m_pData, pch);
    }

    const char* get_data()
    {
        return m_pData;
    }

private:
    int m_nSize;
    char* m_pData;  
};

vector<int> get_list()
{
    vector<int> mylist;
    mylist.push_back(5);
    mylist.push_back(10);
    return mylist;    
}

void myvector_main()
{
    myvector v;
    cout << v.size() << endl;
    v.push_back(5);
    v.push_back(3);
    cout << v.size() << endl;
    v.push_back(12);
    v.push_back(15);
    v.push_back(-1);
    v.push_back(0);
    v.push_back(1);
    cout << v.size() << endl;
    for(int i=0; i<v.size(); i++)
        cout << v.get(i) << endl;        
}

int main(int argc, char const *argv[])
{
    vector<int> thelist = get_list();

    int x = 5;
    char buf[5] = "asd";
    string str = "ali";
    str = "alksdjflas;kdjf;alsdkfj";

    mystr name("hosseingholikhan");

    cout << name.get_size() << endl;
    cout << name.get_data() << endl;

    name.assign("khaleghezi");
    cout << name.get_size() << endl;
    cout << name.get_data() << endl;

    for(int i=0; i<10000; i++)
    {
        char buf[6] = "abcde";
        buf[4] = (i % 26) + 65;

        mystr name1(buf);
        cout << name1.get_data() << endl;
    }
    if (0)
    {
        mystr name2("ali");
    }

    return 0;
}

void test()
{
    mystr name3("ali");
}