using System;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes.Animals
{
    public class Snake : IAnimal, ICrawlable
    {
        public string Name{get; set;}
        public int Age {get; set;}
        public double Heal{get; set;}
        public double SpeedRate{get; set;}       
        public Snake(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Heal = health;
            SpeedRate = speedRate;
        }
        public string Crawl()
        {
            string reuslt = $"{Name} is a {typeof(Snake).Name} and is crawling";
            return reuslt;
        }

        public string EatFood()
        {
            string reuslt = $"{Name} is a {typeof(Snake).Name} and is eating";
            return reuslt;
        }

        public string Move(Environment environment)
        {
            if (environment == Environment.Air)
                return $"{Name} is a {typeof(Snake).Name} and can't move in Air environment";
            if (environment == Environment.Watery)
                return $"{Name} is a {typeof(Snake).Name} and can't move in Watery environment";
            else
                return Crawl();
        }

        public string Reproduction(IAnimal animal)
        {
            return $"{Name} is a {typeof(Snake).Name} and reproductive with {animal.Name}";
        }
    }
}