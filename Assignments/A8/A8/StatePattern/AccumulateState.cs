using static System.Console;

namespace A8.StatePattern
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        // #7 لطفا
        public override IState EnterEqual(){
            return this.ProcessOperator(new ComputeState(base.Calc), base.Calc.PendingOperator);
        }
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display += c.ToString();
            return this;
        }

        // #9 لطفا!
        public override IState EnterOperator(char c){
            base.Calc.Evalute();
            // base.Calc.Display = base.Calc.Accumulation.ToString();
            this.Calc.PendingOperator = c;
            // this.Calc.Accumulation = double.Parse(this.Calc.Display.ToString());
            return new ComputeState(base.Calc);
        }

        public override IState EnterPoint()
        {
            return new PointState(Calc);
        }
    }
}