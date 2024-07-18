using A3.Interfaces;

namespace A3.Classes.Vehicles
{
    public class Airplane : IFlyable
    {
        public double SpeedRate{get; set;}
        public string Model{get; set;}
        public string Fly(){
            string reuslt = $"{Model} with {SpeedRate} speed rate is flying" ;
            return reuslt;
        }
        public Airplane(double speedRate, string model)
        {
            SpeedRate = speedRate;
            Model = model;
        }
    }
}