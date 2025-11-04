using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public abstract class UnitFactoryBase
    {
        public abstract Unit CreatePlayer(string name);
        public abstract Unit CreateGoblinEnemy();
    }
}