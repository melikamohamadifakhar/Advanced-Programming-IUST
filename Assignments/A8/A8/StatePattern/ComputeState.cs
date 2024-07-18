namespace A8.StatePattern
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }

        public override IState EnterEqual()
        {
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }

        public override IState EnterNonZeroDigit(char c)
        {
            base.Calc.Display = c.ToString();
            return new AccumulateState(Calc);
        }

        public override IState EnterZeroDigit()
        {
            // #4 لطفا
            return EnterNonZeroDigit('0');
        }

        // #5 لطفا
        public override IState EnterOperator(char c){
            ProcessOperator(new ComputeState(this.Calc), c);
            return this;
        }
        public override IState EnterPoint()
        {
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }

    }
}