using System;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes.Animals
{
    public class Frog : IAnimal, IWalkable, ISwimable
    {
        public string Name{get; set;}
        public int Age {get; set;}
        public double Heal{get; set;}
        public double SpeedRate{get; set;}  
        public Frog(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Heal = health;
            SpeedRate = speedRate;
        }

        public string EatFood()
        {
            string reuslt = $"{Name} is a {typeof(Frog).Name} and is eating";
            return reuslt;
        }

        public string Move(Environment environment)
        {
            if (environment == Environment.Air)
                return $"{Name} is a {typeof(Frog).Name} and can't move in Air environment";
            else if(environment == Environment.Watery)
                return Swim();
            else
                return Walk();
        }

        public string Reproduction(IAnimal animal)
        {
            return $"{Name} is a {typeof(Frog).Name} and reproductive with {animal.Name}";
        }
        public string Swim()
        {
            return $"{Name} is a {typeof(Frog).Name} and is swimming";
        }

        public string Walk()
        {
            return $"{Name} is a {typeof(Frog).Name} and is walking";
        }
    }
}