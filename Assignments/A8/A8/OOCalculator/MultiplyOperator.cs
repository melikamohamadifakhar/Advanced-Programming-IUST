using System;
using System.IO;

namespace A8.OOCalculator
{
    public class MultiplyOperator : BinaryOperator
    {
        public MultiplyOperator(TextReader reader)
        :base(reader)
        {
        }
        public override string OperatorSymbol => "*";
        public override double Evaluate()=> base.LHS.Evaluate() * base.RHS.Evaluate();
    }
}