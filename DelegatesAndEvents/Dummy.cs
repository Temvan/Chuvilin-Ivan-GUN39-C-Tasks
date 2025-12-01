namespace DelegatesAndEvents
{

    public abstract class Dummy
    {
        public event OnDamageReceivedDelegate<Weapon> OnDamageReceived;

        public event Action OnDeath;

        private int _health;
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    OnDeath();
                }
            } 
        }

        protected Dummy(int health)
        {
            Health = health;
        }

        public virtual void RecieveDamage(Weapon weapon) => OnDamageReceived?.Invoke(weapon);

    }

    public class DummyFirst : Dummy
    {
        public DummyFirst(int health) : base(health)
        {
        }
        public override void RecieveDamage(Weapon weapon)
        {
            if (weapon is Sword)
            {
                base.RecieveDamage(weapon);
            }
            else 
            {
                Console.WriteLine("Hit with wrong weapon");
            }
        }
    }

    public class DummySecond : Dummy
    {
        public DummySecond(int health) : base(health)
        {
        }
        public override void RecieveDamage(Weapon weapon)
        {
            if (weapon is Staff)
            {
                base.RecieveDamage(weapon);
            }
        }
    }
}