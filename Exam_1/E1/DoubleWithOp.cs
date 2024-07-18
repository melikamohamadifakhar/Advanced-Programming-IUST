using System;
using System.Globalization;

namespace E1
{
    public struct DoubleWithOp :
        ICalculable<DoubleWithOp>, IEquatable<DoubleWithOp>
    {
        private double Num;
        public DoubleWithOp(double n){
            Num = n;
        }
        private static Random Rnd = new Random(0);
        public double Value {
            get{
                return Num;
            }
            private set{
                Num = value;
            }}

        public DoubleWithOp PlusIdentity => new DoubleWithOp(1);

        public DoubleWithOp NegIdentity => new DoubleWithOp(-1);

        public DoubleWithOp AddWith(DoubleWithOp other)
        {
            return new DoubleWithOp(other.Num + this.Num);
        }

        public DoubleWithOp Clone()
        {
            return new DoubleWithOp(this.Num);
        }

        public bool Equals(DoubleWithOp other)
        {
            if (other.Value == this.Value)
                return true;
            return false;
        }

        public void LoadFromStr(string str)
        {
            double result = double.Parse(str, CultureInfo.InvariantCulture);
            Num = result;
        }

        public DoubleWithOp MultiplyBy(DoubleWithOp other)
        {
            return new DoubleWithOp(other.Num * this.Num);
        }

        public void Reset()
        {
            Num = 0;
        }

        public void RndSet()
        {
            Num = Rnd.Next();
        }
        public override string ToString()
        {
            return this.Num.ToString().Replace("/", ".");
        }

        public void Set(DoubleWithOp o)
        {
            this.Num = o.Num;
        }
        public bool AreEqual(DoubleWithOp a, DoubleWithOp b){
            return a.Num == b.Num;
        }
    }
}
