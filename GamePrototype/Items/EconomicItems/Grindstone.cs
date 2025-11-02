

namespace GamePrototype.Items.EconomicItems
{
    public sealed class Grindstone : EconomicItem
    {
        public uint RepairAmount { get; }

        public override bool Stackable => false;

        public Grindstone(string name) : base(name)
        {
            RepairAmount = 5;
        }
        
    
    }
}