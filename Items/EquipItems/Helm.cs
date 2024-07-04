using System;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
	public class Helm : Armour
	{
        public Helm(uint defence, uint durability, string name) : base(defence, durability, name)
        {

        }

       public override EquipSlot Slot => EquipSlot.Helm;
    }
}

