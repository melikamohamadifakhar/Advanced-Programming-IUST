using System;
using System.IO;

namespace A8.OOCalculator
{
    public class AddOperator : BinaryOperator
    {
        public AddOperator(TextReader reader)
        :base(reader)
        {
            
        }
        public override string OperatorSymbol => "+";
        public override double Evaluate(){
            return base.LHS.Evaluate() + base.RHS.Evaluate();
        }
    }
}