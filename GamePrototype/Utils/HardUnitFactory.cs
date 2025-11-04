using GamePrototype.Units;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;


namespace GamePrototype.Utils
{
    public sealed class HardUnitFactory : UnitFactoryBase
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 20, 20, 4);
            player.AddItemToInventory(new Weapon(7, 10, 10, "Sword"));
            player.AddItemToInventory(new Armour(8, 10, 10, "Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));

            return player;
        }

        public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 25, 25, 4);
    }
}