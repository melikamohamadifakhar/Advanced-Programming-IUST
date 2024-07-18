using System;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes.Animals
{
    public class Partridge : IAnimal, IWalkable, IFlyable
    {
        public string Name{get; set;}
        public int Age {get; set;}
        public double Heal{get; set;}
        public double SpeedRate{get; set;}  
        public Partridge(string name, int age, double speedRate, double health)
        {
            Name = name;
            Age = age;
            Heal = health;
            SpeedRate = speedRate;
        }

        public string EatFood()
        {
            return $"{Name} is a {typeof(Partridge).Name} and is eating";
        }

        public string Fly()
        {
            return $"{Name} is a {typeof(Partridge).Name} and is flying";
        }

        public string Move(Environment environment)
        {
            if (environment == Environment.Air)
                return Fly();
            else if(environment == Environment.Watery)
                return $"{Name} is a {typeof(Partridge).Name} and can't move in Watery environment";
            else
                return $"{Name} is a {typeof(Partridge).Name} and is walking";
        }

        public string Reproduction(IAnimal animal)
        {
            return $"{Name} is a {typeof(Partridge).Name} and reproductive with {animal.Name}";
        }

        public string Walk()
        {
            return $"{Name} is a {typeof(Partridge).Name} and is walking";
        }
    }
}