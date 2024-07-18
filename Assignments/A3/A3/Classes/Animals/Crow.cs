using System;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes.Animals
{
    public class Crow : IAnimal, IFlyable
    {
        public string Name{get; set;}
        public int Age {get; set;}
        public double Heal{get; set;}
        public double SpeedRate{get; set;}  

        public Crow(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Heal = health;
            SpeedRate = speedRate;
        }


        public string EatFood()
        {
            string reuslt = $"{Name} is a {typeof(Crow).Name} and is eating";
            return reuslt;
        }

        public string Move(Environment environment)
        {
            if (environment == Environment.Land)
                return $"{Name} is a {typeof(Crow).Name} and can't move in Land environment";
            if (environment == Environment.Watery)
                return $"{Name} is a {typeof(Crow).Name} and can't move in Watery environment";
            else
                return Fly();
        }

        public string Reproduction(IAnimal animal)
        {
            return $"{Name} is a {typeof(Crow).Name} and reproductive with {animal.Name}";
        }

        public string Fly()
        {
            string reuslt = $"{Name} is a {typeof(Crow).Name} and is flying";
            return reuslt;
        }
    }
}