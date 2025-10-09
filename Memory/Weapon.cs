namespace Memory;

public class Weapon
{
    public string Name { get; }

   public Interval DamageRange { get; private set; }

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
    public Weapon(string name, Interval damageRange)
{
    Name = name;
    DamageRange = damageRange;
}

    // Метод для установки параметров урона
    public void SetDamageParams(int minDamage, int maxDamage)
    {
        DamageRange = new Interval(minDamage, maxDamage);
    }

    // Метод для нанесения урона
    public int GetDamage()
    {
        return DamageRange.Get();
    }
}