using A3.Enums;

namespace A3.Interfaces
{
    public interface IAnimal
    {
        string Name{get; set;}
        int Age{get; set;}
        double Heal{get; set;}
        string EatFood();
        string Reproduction(IAnimal x);
        string Move(Environment x);
    }
}