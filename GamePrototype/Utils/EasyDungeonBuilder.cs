using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;


namespace GamePrototype.Utils
{
    public sealed class EasyDungeonBuilder : DungeonBuilder
    {
        private readonly UnitFactoryBase _unitFactory;
        public EasyDungeonBuilder(UnitFactoryBase unitFactory)
        {
            _unitFactory = unitFactory;
        }

        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", _unitFactory.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot2", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final");
            
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            

            enter.TrySetDirection(Direction.Right, monsterRoom);
            

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
         

            return enter;
        }
    }
}