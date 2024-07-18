using System;
using System.IO;

namespace A8.OOCalculator
{
    public class NumberExpression : Expression
    {
        protected double Number;
        public NumberExpression(string line)
        {
            double rad;
            if (!double.TryParse(line, out rad))
                Number=0;
            else
                Number = double.Parse(line);
            Evaluate();
        }
        public override double Evaluate() => Number;
        public override string ToString() => $"{Number}";
    }
}