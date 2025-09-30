namespace Classes;

public class Unit
{
    private float _health;
    private float _armor;

    private int _damage;

    public string Name { get; }

    public float Health => _health;

    public int Damage => _damage;

    public float Armor => _armor;

// Конструкторы
    public Unit() : this(name: "Unknown Unit")
    { }
    public Unit(string name, float health = 100f)
    {
        Name = name;
        _health = health;
        _armor = 0.6f;
        _damage = 5;
      
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
    

}