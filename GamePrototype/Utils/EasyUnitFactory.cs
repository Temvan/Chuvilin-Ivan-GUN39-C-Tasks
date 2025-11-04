using GamePrototype.Units;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;


namespace GamePrototype.Utils
{
    public sealed class EasyUnitFactory : UnitFactoryBase
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Weapon(10, 15, 15, "Sword"));
            player.AddItemToInventory(new RangeWeapon(8, 12, 12, "Bow"));
            player.AddItemToInventory(new Armour(10, 15, 15, "Armour"));
            player.AddItemToInventory(new Helmet(5, 10, 10, "Helmet"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            player.AddItemToInventory(new Grindstone("Grindstone"));

            return player;
        }

        public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);
    }
}