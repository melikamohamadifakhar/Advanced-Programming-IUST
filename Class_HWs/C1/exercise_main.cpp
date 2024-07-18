#include<iostream>
#include<string>
// #include<sstream>
using namespace std;

void get_input()
{
    string mystr;
    cout << "What's your name? ";
    getline (cin, mystr);
    cout << "Hello " << mystr << ".\n";
    cout << "What is your favorite team? ";
    getline (cin, mystr);
    cout << "I like " << mystr << " too!\n";
}

int main()
{
    int s = 2;
    int a;
    int b;
    get_input();
    cout << s << "\n";
    cout << "hello\n" <<endl;
    cin >> a >> b; //cin >> a >> b == cin>> a
                   //                 cin>> b  
    cout << a << b << endl;
}



//code male internete. karborde string stream ro nafahmidam.
// int main ()
// {
//     string mystr;
//     float price=0;
//     int quantity=0;

//     cout << "Enter price: ";
//     getline (cin,mystr);
//     stringstream(mystr) >> price;
//     cout << "Enter quantity: ";
//     getline (cin,mystr);
//     stringstream(mystr) >> quantity;
//     cout << "Total price: " << price*quantity << endl;
//     return 0;
// }




