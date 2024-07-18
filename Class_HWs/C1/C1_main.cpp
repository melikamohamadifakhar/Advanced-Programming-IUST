#include<iostream>
#include<vector>
using namespace std;
int main()
{
    int n=1;
    vector<int> array;
    while (n != -1)
    {
        cin >> n;
        if (n != -1)
            array.push_back(n);
    }

    // for(int n: array)
    // {
    //     cout << n << endl;
    // }

    for(int i=array.size()-1; i>=0; i--)
    {
        cout << array[i] << endl;           
    }
}