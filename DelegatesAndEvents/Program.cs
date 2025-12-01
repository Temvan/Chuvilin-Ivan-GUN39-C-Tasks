using System.Diagnostics;

namespace DelegatesAndEvents
{
    public delegate void OnDamageReceivedDelegate<T>(T param) where T : Weapon;

      
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            var dummy = new DummyFirst(100);
            var sword = new Sword(25);
            var bow = new Bow(15);
            var staff = new Staff(40);

            dummy.OnDamageReceived += (Weapon weapon) =>
            {
                Console.WriteLine("Was hit");
                dummy.Health -= weapon.Damage;

            };

            dummy.OnDeath += () => Console.WriteLine("Dummy is dead");

            dummy.RecieveDamage(staff);
            dummy.RecieveDamage(bow);
            dummy.RecieveDamage(sword);
        }
    }
}