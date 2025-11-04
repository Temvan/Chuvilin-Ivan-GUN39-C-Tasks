using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {
  
        }

        public override uint GetUnitDamage()
        {
            
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var meleeItem) && meleeItem is Weapon meleeWeapon)
            {
                if (meleeWeapon.Durability > 0)
                {
                    return BaseDamage + meleeWeapon.Damage;
                }
                else
                {
                    Console.WriteLine("Melee weapon is broken!");
                }
            }
            if (_equipment.TryGetValue(EquipSlot.RangeWeapon, out var rangeItem) && rangeItem is RangeWeapon rangeWeapon)
            {
                if (rangeWeapon.Durability > 0)
                {
                    return BaseDamage + rangeWeapon.Damage;
                }
                else
                {
                    Console.WriteLine("Range weapon is broken!");
                }
            }
            
            return BaseDamage;
        }

         private void UnequipSlot(EquipSlot slot)
        {
            if (_equipment.ContainsKey(slot))
            {
                _equipment.Remove(slot);
            }
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is EconomicItem economicItem)
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }
        
        private bool ConfirmEquip(EquipItem current, EquipItem newItem)
        {
            Console.WriteLine($"You have already equipped {current.Name} in slot {current.Slot}. Do you want to replace it with {newItem.Name}? (y/n)");
            var input = Console.ReadLine();
            return input != null && input.ToLower() == "y";
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem)
            {
                if (_equipment.TryGetValue(equipItem.Slot, out var current))
                {
                    var shouldReplace = ConfirmEquip(current, equipItem);
                    if (shouldReplace)
                    {
                        _equipment[equipItem.Slot] = equipItem;
                        Console.WriteLine($"{equipItem.Name} is equipped in slot {equipItem.Slot}, replacing {current.Name}");
                        base.AddItemToInventory(current);
                    }
                    else
                    {
                        base.AddItemToInventory(item); 
                    }
                    return;
                }
                else
                {
                    _equipment.Add(equipItem.Slot, equipItem);
                    Console.WriteLine($"{equipItem.Name} is equipped in slot {equipItem.Slot}");
                    return;
                }
            }

            
            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion)
            {
                Health += healthPotion.HealthRestore;
            }
            else if (economicItem is Grindstone grindstone)
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var weaponItem) && weaponItem is Weapon weapon)
                {
                    
                        weapon.Repair(grindstone.RepairAmount);
                        Inventory.TryRemove(grindstone);
                        Console.WriteLine("Weapon is repaired!");
                    
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            uint totalDefence = 0;
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour)
            {
                if (armour.Durability > 0)
                {
                    totalDefence += armour.Defence;
                    
                    armour.ReduceDurability(1);
                    if (armour.Durability == 0)
                    {
                        Console.WriteLine("Armour is broken!");
                        UnequipSlot(EquipSlot.Armour);
                    }
                }
                else
                {
                    Console.WriteLine("Armour is broken!");
                }

            }

            if (_equipment.TryGetValue(EquipSlot.Helmet, out var helmetItem) && helmetItem is Helmet helmet)
            {
                if (helmet.Durability > 0)
                {
                    totalDefence += helmet.Defence;
                   
                    helmet.ReduceDurability(1);
                    if (helmet.Durability == 0)
                    {
                        Console.WriteLine("Helmet is broken!");
                        UnequipSlot(EquipSlot.Helmet);
                    }
                }
                else
                {
                    Console.WriteLine("Helmet is broken!");
                }

            }
            damage -= (uint)(damage * (totalDefence / 100f));
            return damage ;
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}