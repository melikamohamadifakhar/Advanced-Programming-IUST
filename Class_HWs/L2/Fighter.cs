using System;
namespace New_folder__3_
{
public class Fighter{
    public string Name;
    public int Health;
    // public delegate void GOver(Fighter f1, Fighter f2);
    public event Action<Fighter, Fighter>  GameOver;
    public Fighter(string name, int health){
        Name = name;
        Health = health;
    }
    public void Attack(Fighter other_fighter){
        Random rnd = new Random();
        int defence = rnd.Next(0, 2);
        if (defence == 0)
        {
            Random r = new Random();
            int A = r.Next(0, 11);
            other_fighter.Health -= A;
        }
        if (other_fighter.Health <= 0)
        {
            GameOver(this, other_fighter);
            Environment.Exit(0);
        }
    }
}
}