using System;
using System.Collections.Generic;
using System.Linq;
using A3.Interfaces;
using Environment = A3.Enums.Environment;

namespace A3.Classes
{
    public class GameBoard<_Type> where  _Type : IAnimal
    {
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            Animals = animals.ToList();
        }

        public List<IAnimal> Animals { get; set; }

        
        public string[] MoveAnimals()
        {
            List<string> result = new List<string>();
            // Environment[] environments = new Environment[]{Environment.Air, Environment.Land, Environment.Watery};
            foreach (var animal in Animals)
                foreach (Environment env in System.Enum.GetValues(typeof(Environment)))
                    result.Add(animal.Move(env));
            return result.ToArray();
        }
    }
}

