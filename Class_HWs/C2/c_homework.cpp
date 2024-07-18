#include <iostream>
#include <vector>
#include <string.h>
using namespace std;

class myvector
{
private:
    int* array;
    int _size;
    int capacity ;
    int* empty;
public:
    myvector()
    : _size(0)
    , capacity(0)
    ,array(nullptr) 
    {}
    
    ~myvector()
    {
        if (array)
            free(array);
    }


    int size()
    {
        return _size;
    }


    void resize()
    {
        capacity = capacity*2;
        empty = array;
        array = (int*)malloc(capacity*sizeof(int));
        for(int i = 0 ; i < _size ; i++)
        {
            array[i] = empty[i];
        }
        free(empty);
    }

    void pushback(int x)
    {
        if(capacity==0)
        {
            capacity++;
            array = (int*)malloc(capacity * sizeof(int));
            array[_size] = x ;
            _size++;
            
        }
        else if(capacity== _size)
        {
            resize();
            array[_size] = x ;
            _size++;
        }
        else if(_size<capacity)
        {
            array[_size]= x ;
            _size++;
        }
    }
    int get(int x)
    {
        return array[x];
    }

    void show()
    {
        cout << "array elements:" << endl;
        for (int index=0; index<_size; index++)
            cout << array[index] << endl;
    }
};

int main()
{
    myvector array;
    cout << array.size() << endl;
    array.pushback(5);
    array.pushback(3);
    cout << array.size() << endl;
    array.pushback(1);
    array.pushback(0);
    array.pushback(3);
    cout << array.size() << endl;
    array.get(9);
    array.show();
    return 0;
}