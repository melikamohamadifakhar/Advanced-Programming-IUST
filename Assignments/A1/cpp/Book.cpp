#pragma once
#include "Member.cpp"
#include<string>
namespace A1{
class Book{
public:
    Book(){}

    Book(string Author, string Title, long int Price, float Rating, string ISBN_10, string Publishdate, string Category)
    :_Author(Author), _Title(Title), _Price(Price), _Rating(Rating), _ISBN_10(ISBN_10), _Publishdate(Publishdate), _Category(Category)
    {}

    Book(const Book& book2){
        _Author = book2._Author;
        _Title = book2._Title;
        _Price = book2._Price;
        _Rating = book2._Rating;
        _ISBN_10 = book2._ISBN_10;
        _Publishdate = book2._Publishdate;
        _Category = book2._Category;
    }

    string GetAuthor(){
        return _Author;
    }

    string GetTitle(){
        return _Title;
    }

    int GetPrice(){
        SetPrice(_Price);
        return _Price;
    }

    double GetRating(){
        return _Rating;
    }

    string GetCategory(){
        return _Category;
    }

    void SetPrice(int NewPrice){
        int a = NewPrice % 100;
        if (a>0)
            NewPrice = (NewPrice-a)+100;
        _Price = NewPrice;
        }
    
    void SetRating(float Rate){
        if (1<Rate && Rate<5)
            _Rating = Rate;
    }
    
    Member* GetPersonBorrowed(){
        return PersonBorrowed;
    }
bool borrowed=false;
Member* PersonBorrowed;
private:
    string _Title;
    string _Author;
    long _Price;
    float _Rating;
    string _ISBN_10;
    string _Publishdate;
    string _Category;
};
}