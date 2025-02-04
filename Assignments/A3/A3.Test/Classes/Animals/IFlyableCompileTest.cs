﻿using A3.Interfaces;

namespace A3Tests.Classes.Animals
{
    public class IFlyableCompileTest
    {
        public class FlyableImp : IFlyable
        {
            public double SpeedRate { get; set; }
            public string Fly() => null;
        }

        public void IFlyableTest()
        {
            IFlyable f = new FlyableImp();
            string flystring = f.Fly();
            double speed = f.SpeedRate;
            f.SpeedRate = f.SpeedRate + 1;
        }
    }

}