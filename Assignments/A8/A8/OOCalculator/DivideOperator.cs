using System;
using System.IO;

namespace A8.OOCalculator
{
    public class DivideOperator : BinaryOperator
    {
        public DivideOperator(TextReader reader)
        :base(reader)
        {
            Evaluate();
        }
        public override string OperatorSymbol => "/";
        public override double Evaluate() => base.LHS.Evaluate()/base.RHS.Evaluate();
    }
}