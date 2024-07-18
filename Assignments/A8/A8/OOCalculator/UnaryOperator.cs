﻿using System;
using System.IO;

namespace A8.OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        public UnaryOperator()
        {
            throw new NotImplementedException();
        }

        public UnaryOperator(TextReader reader)
        {
            Operand = Expression.BuildExpressionTree((StreamReader) reader);
        }

        public sealed override string ToString() => $"{OperatorSymbol}({Operand})";

        public abstract string OperatorSymbol { get; }
    }
}