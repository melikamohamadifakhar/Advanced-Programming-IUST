#include<iostream>
using namespace std;

void plus1(int &num)//pass by reference
{
    num += 1;
}

void plusa1(int num)
{
    num += 1;
}


void ptr_ref(int *&ptr, int x)
{
    x += 1;
    ptr = &x; 
}

void ptr_ref1(int* ptr, int* x)
{
    *x +=1;
    ptr = x;
}
int main()
{
    int num =5;
    int* ptr;
    // plus1(num);
    // cout<<num<<endl;
    // plusa1(num);
    // cout<<num<<endl;
    cout<<"&ptr: "<< &ptr <<"  ptr: " << ptr << endl; 
    ptr_ref(ptr, num);
    cout<<"&ptr: "<< &ptr <<"  ptr: " << ptr <<endl; 
}

