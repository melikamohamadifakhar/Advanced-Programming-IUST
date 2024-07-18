using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E1
{
    public class Matrix<_Type> :
        ICalculable<Matrix<_Type>>,
        IEquatable<Matrix<_Type>>
        where
            _Type : ICalculable<_Type>, IEquatable<_Type>
    {
        private _Type[,] Data;
        public Matrix(int a, int b){
            Data = new _Type[a, b];
            this.RowCount = a;
            this.ColumnCount = b;
        }
        public void SetData(int row, int col, _Type x){
            Data[row, col] = x;
        }
        public _Type GetData(int row, int col){
            return Data[row, col];
        }
        public int RowCount;
        public int ColumnCount;

        // public Matrix<_Type> PlusIdentity(){
        //     Matrix<_Type> x = new Matrix<_Type>(RowCount, ColumnCount);
        //     for (int i = 0; i < this.RowCount; i++)
        //         for(int j=0; j< this.ColumnCount; j++){
        //             if(i == j)
        //                 x.SetData(i, j, Data[i, j].PlusIdentity);
        //             else
        //                 x.Data[i, j].Reset();
        //         }
        //     return x;
        // }
        // public _Type[] Rows{
        //     get{
        //         _Type[] x = new _Type[RowCount];
        //         for(int i=0; i<RowCount; i++){

        //         }
        //     }
        // }

        // public Matrix<_Type> NegIdentity(){
        //     Matrix<_Type> x = new Matrix<_Type>(RowCount, ColumnCount);
        //     for (int i = 0; i < this.RowCount; i++)
        //         for(int j=0; j< this.ColumnCount; j++){
        //             if(i == j)
        //                 x.SetData(i, j, Data[i, j].NegIdentity);
        //             else
        //                 x.Data[i, j].Reset();
        //         }
        //     return x;
        // }
        public Matrix<_Type> NegIdentity{
            get{
            Matrix<_Type> x = new Matrix<_Type>(RowCount, ColumnCount);
            for (int i = 0; i < this.RowCount; i++)
                for(int j=0; j< this.ColumnCount; j++){
                    if(i == j)
                        x.SetData(i, j, Data[i, j].NegIdentity);
                    else
                        x.Data[i, j].Reset();
                }
            return x;
            }
        }

        public Matrix<_Type> PlusIdentity{
            get{
            Matrix<_Type> x = new Matrix<_Type>(RowCount, ColumnCount);
            for (int i = 0; i < this.RowCount; i++)
                for(int j=0; j< this.ColumnCount; j++){
                    if(i == j)
                        x.SetData(i, j, Data[i, j].PlusIdentity);
                    else
                        x.Data[i, j].Reset();
                }
            return x;
            }
        }

        public Matrix<_Type> AddWith(Matrix<_Type> other)
        {
            Matrix<_Type> m1 = new Matrix<_Type>(other.RowCount, other.ColumnCount);
            for (int i = 0; i < other.RowCount; i++)
                for(int j=0; j< other.ColumnCount; j++){
                    m1.SetData(i, j, this.Data[i, j].AddWith(other.GetData(i, j)));
                }
            return m1;
        }

        public override string ToString()
        {
            string result = "" +RowCount.ToString() +" " +ColumnCount.ToString() + "\n";
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (j == ColumnCount-1)
                    {
                        result +=  this.GetData(i, j).ToString() + "\n";
                    }
                    else
                    {
                        result += this.GetData(i , j).ToString() + " ";
                    }
                }
            }
            return result;

        }
        public Matrix<_Type> Clone()
        {
            Matrix<_Type> result = new Matrix<_Type>(this.RowCount, this.ColumnCount);
                for (int i = 0; i < RowCount; i++)
                    for (int j = 0; j < ColumnCount; j++)
                        result.Data[i, j].Set(this.Data[i, j]);
            return result;
        }

        public bool Equals(Matrix<_Type> other)
        {
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    if (!this.Data[i, j].Equals(other.Data[i, j]))
                        return false;
            return true;
        }
        public IEnumerable<_Type[]> Rows{
            get{
                List<_Type[]> x = new List<_Type[]>();
                for (int i = 0; i < RowCount; i++)
                {
                    _Type[] t = new _Type[this.ColumnCount];
                    for(int j=0; j< ColumnCount; j++){
                        t[j] = this.GetData(i, j);
                    }
                    x.Add(t);
                }
                return x;
            }
        }
        public IEnumerable<_Type[]> Columns{
            get{
                List<_Type[]> x = new List<_Type[]>();
                for (int i = 0; i < ColumnCount; i++)
                {
                    _Type[] t = new _Type[this.RowCount];
                    for(int j=0; j< RowCount; j++){
                        t[j] = this.GetData(j, i);
                    }
                    x.Add(t);
                }
                return x;
            }
        }

        public void LoadFromStr(string str)
        {
            throw new NotImplementedException();
        }

        public Matrix<_Type> MultiplyBy(Matrix<_Type> other)
        {
            Matrix<_Type> m1 = new Matrix<_Type>(other.RowCount, other.ColumnCount);
            int r=0;
            int c=0;
            for (int i = 0; i < this.RowCount; i++){
                _Type x = default;
                for(int j=0; j< this.ColumnCount; j++){
                    x.AddWith(this.GetData(i, j).MultiplyBy(other.GetData(j, i)));
                    // m1.SetData(i, j, this.Data[i, j].MultiplyBy(other.GetData(i, j)));
                }
                m1.SetData(r, c, x);
                r+=1; c+=1;
            }
            return m1;
        }

        public void Reset()
        {
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    Data[i, j].Reset();
        }

        public void RndSet()
        {
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    Data[i, j].RndSet();
        }

        public void Set(Matrix<_Type> o)
        {
            throw new NotImplementedException();
        }
    }
}
