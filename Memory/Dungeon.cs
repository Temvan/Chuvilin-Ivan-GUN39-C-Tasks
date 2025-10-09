    namespace Memory;

    public class Dungeon
    {
        public Room[] rooms { get; }

        public Interval healthRange1 = new Interval(50, 100);
        public Interval healthRange2 = new Interval(100, 150);
        public Interval healthRange3 = new Interval(150, 200);   
        public Interval healthRange4 = new Interval(300, 500);

        public Interval damageRange1 = new Interval(5, 20);
        public Interval damageRange2 = new Interval(10, 30);
        public Interval damageRange3 = new Interval(20, 40);
        public Interval damageRange4 = new Interval(50, 100);

    public Dungeon()
    {
        rooms = new Room[4];
        rooms[0] = new Room(new Unit("Goblin", healthRange1), new Weapon("Sword", damageRange1));
        rooms[1] = new Room(new Unit("Orc", healthRange2), new Weapon("Axe", damageRange2));
        rooms[2] = new Room(new Unit("Troll", healthRange3), new Weapon("Pickaxe", damageRange3));
        rooms[3] = new Room(new Unit("Dragon", healthRange4), new Weapon("Fire Breath", damageRange4));
    }

    public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];
                Console.WriteLine($"Room {i + 1}:");
                Console.WriteLine($"  Unit: {rooms[i].Unit.Name}, Health: {rooms[i].Unit.Health}");
                Console.WriteLine($"  Weapon: {rooms[i].Weapon.Name}, Damage: {rooms[i].Weapon.DamageRange.Min}-{rooms[i].Weapon.DamageRange.Max}");
                Console.WriteLine("--------------------------");
            }
        }
    }