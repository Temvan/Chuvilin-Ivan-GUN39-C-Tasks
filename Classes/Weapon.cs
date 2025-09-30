namespace Classes;

public class Weapon
{
    public string Name { get; }

    public int MinDamage { get; private set; }
    public int MaxDamage { get; private set; }
    public float Durability { get; } = 1f;

    // Конструкторы
    public Weapon(string name)
    {
        Name = name;
    }
    public Weapon(string name, int minDamage, int maxDamage) : this(name)
    {
        SetDamageParams(minDamage, maxDamage);
    }

    // Метод для установки параметров урона
    public void SetDamageParams(int minDamage, int maxDamage)
    {
        if (minDamage > maxDamage)
        {
            int value = minDamage;
            minDamage = maxDamage;
            maxDamage = value;
            Console.WriteLine("MinDamage cannot be greater than MaxDamage. Setting MinDamage to MaxDamage value. Weapon: " + Name);
        }
        if (minDamage < 1)
        {
            minDamage = 1;
            Console.WriteLine("Forced installation of the minimum value: " + Name);
        }
        if (maxDamage <= 1)
        {
            maxDamage = 10;
        }
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    // Метод для нанесения урона
    public int GetDamage()
    {
        return (MinDamage + MaxDamage) / 2;
    }
}