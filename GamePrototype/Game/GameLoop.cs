using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;

        private UnitFactoryBase _factory;

        private DungeonBuilder _dungeonBuilder;

        private Difficulty _difficulty;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();

        public void StartGame()
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {
            Console.WriteLine("Welcome, player!");
            

            Console.WriteLine("Choose difficulty: 1 - Easy, 2 - Hard");

            var currentDifficulty = Console.ReadLine();
            switch (currentDifficulty)
            {
                case "1":
                    _difficulty = Difficulty.Easy;
                    _factory = new EasyUnitFactory();
                    _dungeonBuilder = new EasyDungeonBuilder(_factory);
                    Console.WriteLine("Let's go on Easy mode!");
                    break;
                case "2":
                    _difficulty = Difficulty.Hard;
                    _factory = new HardUnitFactory();
                    _dungeonBuilder = new HardDungeonBuilder(_factory);
                    Console.WriteLine("Let's go on Hard mode!");
                    break;
                default:
                    Console.WriteLine("You're wrong, I'll choose for u - Easy");
                     _difficulty = Difficulty.Easy;
                    _factory = new EasyUnitFactory();
                    _dungeonBuilder = new EasyDungeonBuilder(_factory);
                    break;
            }

            
          


            Console.WriteLine("Enter your name:");
            _player = _factory.CreatePlayer(Console.ReadLine());
            Console.WriteLine($"Hello {_player.Name}");
            _dungeon = _dungeonBuilder.BuildDungeon();
            Console.WriteLine("Dungeon is created!");
           
        
                        
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;

            while (currentRoom.IsFinal == false)
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success)
                {
                    Console.WriteLine("Game over!");
                    return;
                }

                DisplayRouteOptions(currentRoom);

                while (true)
                {
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction))
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong direction!");
                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result:");
            Console.WriteLine(_player.ToString());
        }
        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null)
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null)
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int)room.Key}\t");
            }
        }

#endregion

    }
}