#include<iostream>
#include<vector>
#include<stdlib.h>


using namespace std;

//Default Value --> tafavot ba initialize kardan ine keh toye main mitonim taghiresh bedim
class myvector{
public:
//myvector(int capacity = 5)-->meghdare default-->parametrhaee keh meghdare default daran bayad tahe list biyan
//:m_nCapacity(capacity)
    myvector()//initializer list kamel to yek khay ejra mishe
    : m_nCapacity(5),
    m_nSize(0),
    m_pData(nullptr)
    {
        m_pData = (int*)malloc(m_nCapacity*sizeof(int));
    }


    ~myvector(){
        free(m_pData);
    }

    //COPY CONSTRUCTOR--> yek object jadid bayad dorost beshe az noe myvector va constructor on bayad seda zadeh beshe
    myvector(const myvector& other){//&-->PASS BY REFERENCE: const--> nemikhaym taghiresh bedim faghat copish mikonim
        //other chon pass by ref hast be andaze yek pointer ja migire
        m_nSize = other.m_nSize;
        m_nCapacity = other.m_nCapacity;
        m_pData = (int*)malloc(m_nCapacity*sizeof(int));
        for(int i=0;i<m_nSize;i++)
        {
            m_pData[i] = other.m_pData[i];
        }
    }

    myvector clone(){
        return *this;
    }


    void resize(){
        m_nCapacity*=2;
        int* new_mem = (int*)malloc(m_nCapacity*sizeof(int));
        for(int i=0;i<m_nSize;i++){
            new_mem[i] = m_pData[i];
        }
        free(m_pData);
        m_pData = new_mem;

    }

    void push_back(int x){
        if(m_nSize == m_nCapacity)
            resize();
        m_pData[m_nSize] = x;
        m_nSize++;

    }

    int get_mem(int i){
        if(i<m_nSize)
            return m_pData[i];
        cout<<"index out of range"<<"\n";
    }

    int get_size(){
        return m_nSize;
    }

    void func(int m_nSize)
    {
        this->m_nSize = m_nSize;
    }
private:
    int m_nSize;//other mesle yek struct aval miyad toye size badesh 4 ta mireh jolo mire to capacity ba 4 ta badesh toye data
    int m_nCapacity;
    int* m_pData;
};


void swap(int& x,int& y){
    int tmp = x;
    x = y;
    y = tmp;
}

//this (toye debug) --> tamam vizhegi haye class ro dare-->yek pointer be kelasi ke tosh hastim be hame private ha ba this mitonim eshare konim-->this->m_nSize
                                                                                                                                                    //this->m_nCapacity

int main(){//vaghti az main kharej mishe hame ro free mikone
    int a=5,b=4;
    swap(a,b);//dar halat & chon digeh pointer nadarim nemitonim az null ptr estefadeh konim fahgat baraye int 
    myvector v;//sizeof(v)==12-->chon toye private 3 ta chiz darim,hala pas chetor push mikonim-->in 12 byte toye stack hastan ama ma baghiye element haro ja barashon allocate kardim-->toye dynamic memory ya heap,hame adresa 4 byte
    cout << v.get_size() << endl;
    v.push_back(5);
    v.push_back(3);
    cout << v.get_size() << endl;
    v.push_back(12);
    v.push_back(15);
    v.push_back(-1);
    v.push_back(0);
    v.push_back(1);
    cout << v.get_size() << endl;
    for(int i=0; i<v.get_size(); i++)
        cout << v.get_mem(i) << endl;  

    myvector v2(v);
}