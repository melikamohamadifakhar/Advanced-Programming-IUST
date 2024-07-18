using System;
using System.Collections.Generic;

namespace C18
{

    public class MyPoint : IComparable<MyPoint>
    {
        private int[] Dim;
        private string Name;
        public MyPoint(params int[] nums)
        {
            this.Dim = new int[nums.Length];
            for(int i=0; i<nums.Length; i++)
                this.Dim[i] = nums[i];
        }
        public double Magnitude(){
            double sum=0;
            for (int i=0; i < Dim.Length; i++){
                sum+= Math.Pow(Dim[i], 2);
            }
            return Math.Sqrt(sum);
        }
        public static MyPoint operator+(MyPoint p1,MyPoint p2){
            List<int> Dim = new List<int>();
            for (int i=0; i<p1.Dim.Length; i++)
                Dim.Add(p1.Dim[i] + p2.Dim[i]);
            return new MyPoint(Dim.ToArray());
        }
        public static MyPoint operator-(MyPoint p1,MyPoint p2){
            List<int> Dim = new List<int>();
            for (int i=0; i<p1.Dim.Length; i++)
                Dim.Add(p1.Dim[i] - p2.Dim[i]);
            return new MyPoint(Dim.ToArray());
        }
        public static MyPoint operator*(MyPoint p1,MyPoint p2){
            List<int> Dim = new List<int>();
            for (int i=0; i<p1.Dim.Length; i++)
                Dim.Add(p1.Dim[i] * p2.Dim[i]);
            return new MyPoint(Dim.ToArray());
        }
        public static MyPoint operator/(MyPoint p1,MyPoint p2){
            List<int> Dim = new List<int>();
            for (int i=0; i<p1.Dim.Length; i++)
                Dim.Add(p1.Dim[i] / p2.Dim[i]);
            return new MyPoint(Dim.ToArray());;
        }
        public static bool operator==(MyPoint p1, MyPoint p2)
        {
            if (ReferenceEquals(p2, null) || ReferenceEquals(p1, null))
                return false;
            for (int i=0; i<p1.Dim.Length; i++)
                if (p1.Dim[i] != p2.Dim[i])
                    return false;
            return true;
        }

        public static bool operator!=(MyPoint p1, MyPoint p2) => !(p1 == p2);
        public static bool operator<(MyPoint p1, MyPoint p2) => p1.Magnitude() < p2.Magnitude();
        public static bool operator>(MyPoint p1, MyPoint p2) => p1.Magnitude() > p2.Magnitude();
        public int this[int idx]{
            get{
                if(idx <= Dim.Length)
                    return Dim[idx];
                return -1;
            }
            set{
                Dim[idx] = value;
            }
        }
        public int CompareTo(MyPoint other)
        {
            return this.Magnitude().CompareTo(other.Magnitude());
        }
    }

}