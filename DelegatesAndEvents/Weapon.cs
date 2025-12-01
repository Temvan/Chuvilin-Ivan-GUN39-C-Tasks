namespace DelegatesAndEvents
{
    public abstract class Weapon
    {
        public int Damage { get; }
        protected Weapon(int damage)
        {
            Damage = damage;
        }
    }

    public class Sword : Weapon
    {
        public Sword(int damage) : base(damage) { }
    }

    public class Bow : Weapon
    {
        public Bow(int damage) : base(damage) { }
    }
    
    public class Staff : Weapon
    {
        public Staff(int damage) : base(damage) { }
    }
}