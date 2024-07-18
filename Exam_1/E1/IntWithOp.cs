using System;

namespace E1
{
    public struct IntWithOp : ICalculable<IntWithOp>, IEquatable<IntWithOp>
    {
        private int Num;
        public IntWithOp(int n){
            Num = n;
        }
        private static Random Rnd = new Random(0);
        public int Value {
            get{
                return Num;
            }
            private set{
                Num = value;
            }}

        public IntWithOp PlusIdentity => new IntWithOp(1);

        public IntWithOp NegIdentity => new IntWithOp(-1);

        public IntWithOp AddWith(IntWithOp other)
        {
            return new IntWithOp(other.Num + this.Num);
        }

        public IntWithOp Clone()
        {
            return new IntWithOp(this.Value);
        }

        public bool Equals(IntWithOp other)
        {
            if(this.Value == other.Value)
                return true;
            return false;
        }

        public void LoadFromStr(string str)
        {
            int result = Int32.Parse(str);
            Num = result;
        }

        public IntWithOp MultiplyBy(IntWithOp other)
        {
            return new IntWithOp(other.Num * this.Num);
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
            return this.Num.ToString();
        }

        public void Set(IntWithOp o)
        {
            this.Num = o.Num;
        }
        public bool AreEqual(IntWithOp a, IntWithOp b){
            return a.Num == b.Num;
        }
    }
}
