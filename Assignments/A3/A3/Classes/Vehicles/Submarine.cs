using A3.Interfaces;

namespace A3.Classes.Vehicles
{
    public class Submarine : ISwimable
    { 
        public string Model{get; set;}
        public double SpeedRate { get; set;}
        public double MaxDepthSupported{get; set;}
        public Submarine(string model, double maxDepthSupported, double speedRate)
        {
            Model = model;
            MaxDepthSupported = maxDepthSupported;
            SpeedRate = speedRate;
        }


        public string Swim()
        {
            string result = $"{Model} is a {typeof(Submarine).Name} and is swimming in {MaxDepthSupported} meter depth";
            return result;

        }
    }
}