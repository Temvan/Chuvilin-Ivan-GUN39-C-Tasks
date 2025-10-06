namespace Memory;

public class Unit
{
    private float _health;
    private float _armor;

    public string Name { get; }

    public float Health => _health;

    public Interval DamageRange { get; private set; }

    public int Damage => DamageRange.Get;

    public float Armor => _armor;

    // Конструкторы
    public Unit() : this(name: "Unknown Unit")
    { }
    public Unit(string name, Interval healthRange)
    {
        Name = name;
        _health = healthRange.Get;
        _armor = 0.6f;
        DamageRange = new Interval(0, 10);

    }
    public Unit(string name, float health, int minDamage, int maxDamage) : this(name, health)
    {
        SetDamageParams(minDamage, maxDamage);
  
        _armor = 0.6f;
    }


    // Метод для получения реального здоровья с учетом брони
    public float GetRealHealth()
    {
        return Health * (1f + Armor);
    }

    // Метод для нанесения урона с учетом брони
    public bool SetDamage(float value)
    {
        _health -= value * Armor;
        if (_health <= 0f)
        {
            Console.WriteLine("Unit is dead");
            return true;

        }
        else
        {
            Console.WriteLine("Unit is alive");
            return false;

        }
    }

    // Конструктор для установки параметров урона
    public void SetDamageParams(int minDamage, int maxDamage)
    {
        DamageRange = new Interval(minDamage, maxDamage);
    }
    

}