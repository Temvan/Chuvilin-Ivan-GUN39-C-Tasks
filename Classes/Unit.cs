namespace Classes;

public class Unit
{
    private float _health;

    public string Name { get; }

    public float Health => _health;

    public int Damage;

    public float Armor { get; set; }

    public void Attack(Unit enemy)
    {
        enemy.Health -= Damage;
        Console.WriteLine($"{Name} attacks {enemy.Name} for {Damage} damage. {enemy.Name} has {enemy.Health} health left.");
    }

    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{Name} heals for {amount}. Now has {Health} health.");
    }
}