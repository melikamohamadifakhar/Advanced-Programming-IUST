#pragma once
#include <vector>
#include <string>
#include <stdbool.h>
using namespace std;

namespace A1
{
    class Member
    {
    public:
        Member() {}
        Member(int Money, string Name)
        {
            _Money = Money;
            _Name = Name;
        }

        Member(const Member &C_Member)
        {
            _Money = C_Member._Money;
        }

        int GetSavingMoney()
        {
            return _Money;
        }

        void SetMoney(int new_m)
        {
            _Money = new_m;
        }

        void Setname(string new_n)
        {
            _Name = new_n;
        }

        const string GetName() const
        {
            return _Name;
        }

        bool IsBorrowed()
        {
            return borrowed;
        }

        void Set_Borrowed(bool TOrF)
        {
            borrowed = TOrF;
        }
        bool borrowed = false;
        bool registered = false;
        string _Name;

    private:
        int _Money;
    };
}