#pragma once
#include "Book.cpp"
#include <vector>
#include <algorithm>
#include <cctype>
#include <string>
using namespace std;

namespace A1
{
    class Library
    {
        const int InitialBorrowDays = 120;

    public:
        Library()
        {
            _library = nullptr;
            _Members = nullptr;
        }

        ~Library()
        {
            if (_Members != nullptr)
            {
                for (int i = 0; i < (*_Members).size(); i++)
                    delete (*_Members)[i];
                delete _Members;
                _Members = nullptr;
            }
            if (_library != nullptr)
            {
                delete _library;
                _library = nullptr;
            }
        }
        Library(string _Name)
        {
            Name = _Name;
        }

        Library(const Library &lib)
        {
            *(_library) = *(lib._library);
        }

        string GetName()
        {
            return Name;
        }

        void AddBook(Book *NewBook)
        {
            (*_library).push_back(NewBook);
        }

        void SetName(string NewName)
        {
            Name = NewName;
        }

        void RegisterMember(Member *New_mem)
        {
            if (New_mem->GetSavingMoney() >= 1000)
            {
                (*_Members).push_back(New_mem);
                (*New_mem).registered = true;
                New_mem->SetMoney(
                    New_mem->GetSavingMoney() - 1000);
            }
        }

        vector<Member *> *GetAllMembers()
        {
            return _Members;
        }

        vector<Book *> *GetAllBooks()
        {
            return _library;
        }

        void BorrowBook(Book *book, Member *member)
        {
            if ((member->GetSavingMoney() >= (book->GetPrice()) / 4) && (*member).IsBorrowed() == false && (*book).borrowed == false && (*member).registered == true)
            {
                int changed_money = member->GetSavingMoney() - (book->GetPrice()) / 4;
                member->SetMoney(changed_money);
                (*book).PersonBorrowed = member;
                (*member).borrowed = true;
                (*book).borrowed = true;
            }
        }


        void SortMembersByName()
        {
            int i = 1;
            while (i < (*_Members).size())
            {
                for (int j = i; j > 0; j--)
                {
                    string s1 = (*_Members)[j - 1]->_Name;
                    string s2 = (*_Members)[j]->_Name;
                    if (s1 < s2)
                        continue;
                    Member *temp = (*_Members)[j - 1];
                    (*_Members)[j - 1] = (*_Members)[j];
                    (*_Members)[j] = temp;
                }
                i++;
            }
        }
        
        void DaysPassed(int day){
            for (int idx = 0; idx < this->_library->size(); idx++)
            {
                auto book = (*this->_library)[idx];
                if (book->borrowed)
                {
                    auto m_b = book->PersonBorrowed;
                    m_b->SetMoney(m_b->GetSavingMoney() - (day * book->GetPrice() / 10));
                }
            }
        }

        string lower(string s)
        {
            for (int i = 0; i < s.size(); i++)
            {
                s.at(i) = tolower(s.at(i));
            }
            return s;
        }

        vector<Book *> *FindBooks(string category, float rating)
        {
            vector<Book *> *Book_List = new vector<Book *>();
            string cat = lower(category);
            for (int i = 0; i < (*_library).size(); i++)
            {
                string categ = lower((*(*_library)[i]).GetCategory());
                if ((rating <= (*(*_library)[i]).GetRating()) && categ.find(cat) != string::npos)
                {
                    (*Book_List).push_back((*_library)[i]);
                }
            }
            return Book_List;
        }

    private:
        string Name;
        vector<Book *> *_library = new vector<Book *>();
        vector<Member *> *_Members = new vector<Member *>();
    };
}
