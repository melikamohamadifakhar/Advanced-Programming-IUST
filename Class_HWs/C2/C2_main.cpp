#include <vector>
#include <iostream>
#include <string.h>
#include <string>
using namespace std;

class newstring
{
public:
    newstring(const char* pch)
    :data(nullptr)
    ,size(0)
    {
        assign(pch);
    }

    ~newstring()
    {
        if(data)
            free(data);
    }


    void assign(const char* pch)
    {
        size = strlen(pch);
        data = (char*) malloc((size+1) * sizeof(char));
        strcpy(data, pch);
    }

    const char* get_data()
    {
        return data;
    }

    int get_size()
    {
        return size;
    }
private:
    char* data;
    int size;
};

int main()
{
    newstring myname("melika mohamadi");
    cout << myname.get_data() << endl;
    cout << myname.get_size() << endl;

    myname.assign("mahla");
    cout << myname.get_data() << endl;
    cout << myname.get_size() << endl;
    return 0;
}

