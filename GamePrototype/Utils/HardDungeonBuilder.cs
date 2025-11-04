using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;


namespace GamePrototype.Utils
{
    public sealed class HardDungeonBuilder : DungeonBuilder
    {
        private readonly UnitFactoryBase _unitFactory;
        public HardDungeonBuilder(UnitFactoryBase unitFactory)
        {
            _unitFactory = unitFactory;
        }

        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", _unitFactory.CreateGoblinEnemy());
            var monsterRoom2 = new DungeonRoom("Monster2", _unitFactory.CreateGoblinEnemy());
            var monsterRoom3 = new DungeonRoom("Monster3", _unitFactory.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot2", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final");

            enter.TrySetDirection(Direction.Forward, monsterRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);

            lootRoom.TrySetDirection(Direction.Forward, monsterRoom2);

            monsterRoom2.TrySetDirection(Direction.Forward, monsterRoom3);

            monsterRoom3.TrySetDirection(Direction.Forward, finalRoom);

            
            enter.TrySetDirection(Direction.Left, emptyRoom);
            emptyRoom.TrySetDirection(Direction.Forward, monsterRoom2);

            monsterRoom3.TrySetDirection(Direction.Right, lootStoneRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);


            
            return enter;
        }
    }
}