﻿namespace A8.StatePattern
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    /// #2 لطفا!
    /// </summary>
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { }
        public override IState EnterEqual() => new StartState(this.Calc);
        public override IState EnterNonZeroDigit(char c) => new StartState(this.Calc);
        public override IState EnterZeroDigit() => new StartState(this.Calc);
        public override IState EnterOperator(char c) => new StartState(this.Calc);
        public override IState EnterPoint() => new StartState(this.Calc);
    }
}