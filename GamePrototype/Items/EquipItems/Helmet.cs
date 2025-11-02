using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public sealed class Helmet : EquipItem
    {
        public Helmet(uint defence, uint durability, uint maxDurability, string name) : base(durability, maxDurability, name) => Defence = defence;
        public uint Defence { get; }
        public override EquipSlot Slot => EquipSlot.Helmet;

    }
}